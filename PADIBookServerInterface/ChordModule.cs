using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.IO;
using System.Net.Sockets;
using PADIBook.Utils;
using PADIBook.Utils.Exceptions;
using System.Collections;
using System.Threading;

namespace PADIBook.Server
{
    public class ChordModule
    {
        private ChordModule() { }

        public readonly static object singletonLock = new object();
        private static ChordModule instance = null;
        public static ChordModule Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (instance == null)
                        instance = new ChordModule();
                    return instance;
                }
            }
        }

        private ChordNode nodeInstance;
        public ChordNode NodeInstance
        {
            get
            {
                lock (nodeInstance)
                {
                    return nodeInstance;
                }
            }
        }

        public void RegisterChordInstance(ChordNode cn)
        {
            nodeInstance = cn;
            nodeInstance.Init();
        }
    }

    public sealed class ChordNode
    {
        private static readonly int MAX_SUCESSORS = 10;
        private ArrayList successors;
        public ArrayList Successors
        {
            get
            {
                return successors;
            }
        }

        private NodeInfo predecessor;
        private static readonly object predecessorLock = new object();
        public NodeInfo Predecessor
        {
            get
            {
                lock (predecessorLock)
                {
                    return predecessor;
                }
            }
            set
            {
                lock (predecessorLock)
                {
                    predecessor = value;
                }
            }
        }

        private NodeInfo[] fingers;
        public NodeInfo[] Fingers
        {
            get
            {
                return fingers;
            }
        }

        private int next = 0;
        private NodeInfo myData;
        public BigInteger ChordID { get { return myData.ID; } }

        private readonly static int chordKeyLength = 160;//size of SHA1 hash in bits
        private readonly static SHA1 sha = new SHA1CryptoServiceProvider();
        private readonly static ASCIIEncoding encoding = new ASCIIEncoding();
        private static BigInteger maxValue;

        private Dictionary<BigInteger, List<string>> keyTable;
        public Dictionary<BigInteger, List<string>> Keys
        {
            get
            {
                lock (keyTable)
                {
                    return keyTable;
                }
            }
        }

        public ChordNode(string myAddress, int myPort)
        {
            Predecessor = null;
            keyTable = new Dictionary<BigInteger, List<string>>();
            fingers = new NodeInfo[chordKeyLength];
            successors = ArrayList.Synchronized(new ArrayList());
            myData = new NodeInfo(myAddress, myPort, new BigInteger(SHA(myAddress + ":" + myPort)));
            byte[] max = new byte[20];
            for (int i = 0; i < 20; i++)
                max[i] = 255;
            maxValue = new BigInteger(max);
            for(int i = 0; i < MAX_SUCESSORS; i++)
                successors.Add(myData);
        }

        public ChordNode(string myAddress, int myPort, string knownChordNodeAddress, int knownChordNodePort)
        {
            Predecessor = null;
            fingers = new NodeInfo[chordKeyLength];
            successors = ArrayList.Synchronized(new ArrayList());
            myData = new NodeInfo(myAddress, myPort, new BigInteger(SHA(myAddress + ":" + myPort)));
            byte[] max = new byte[20];
            for (int i = 0; i < 20; i++)
                max[i] = 255;
            maxValue = new BigInteger(max);
            NodeInfo ni = Join(knownChordNodeAddress, knownChordNodePort);
            if (ni != null)
            {
                //In the beginning this node should only know it's sucessor.
                //So we initialize them all as the same one.
                for (int i = 0; i < MAX_SUCESSORS; i++) 
                    successors.Add(ni);
                ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), ni.Address + ":" + ni.Port + "/ChordServices");
                if (obj != null)
                {
                    try
                    {
                        keyTable = obj.CopyKeys(myData.ID);
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            else
            {
                //known node is dead
                throw new ServiceUnavailableException("Known chord node is dead.");
            }
        }

        public void Put(BigInteger key, string value)
        {
            lock (keyTable)
            {
                if (keyTable.ContainsKey(key))
                {
                    if (!keyTable[key].Contains(value))
                        keyTable[key].Add(value);
                }
                else
                {
                    List<string> newOne = new List<string>();
                    newOne.Add(value);
                    keyTable.Add(key, newOne);
                }
            }
        }

        public void Remove(BigInteger key, string value)
        {
            lock (keyTable)
            {
                if (keyTable.ContainsKey(key))
                {
                    keyTable[key].Remove(value);
                    if (keyTable[key].Count == 0)
                        keyTable.Remove(key);
                }
            }
        }

        public List<string> Get(BigInteger key)
        {
            lock (keyTable)
            {
                if (keyTable.ContainsKey(key))
                {
                    return keyTable[key];
                }
                return null;
            }
        }

        public Dictionary<BigInteger, List<string>> CopyKeys(BigInteger nodeID)
        {
            lock (keyTable)
            {
                Dictionary<BigInteger, List<string>> copiedValues = new Dictionary<BigInteger, List<string>>();
                foreach (BigInteger key in keyTable.Keys.Where<BigInteger>(x => x < nodeID))
                    copiedValues.Add(key, keyTable[key]);
                return copiedValues;
            }
        }

        public void Init()
        {
            //Spawn threads
            new Thread(Stabilize).Start();
            new Thread(FixFingers).Start();
            new Thread(CheckPredecessor).Start();
        }

        private static byte[] StrToByteArray(string str)
        {
            return encoding.GetBytes(str);
        }

        public static byte[] SHA(string args)
        {
            return sha.ComputeHash(StrToByteArray(args));
        }

        private bool TestKey(BigInteger a,BigInteger key,BigInteger s)
        {
            BigInteger k = key;
            if (s < a) { s += maxValue; }
            if (k < a) { k += maxValue; }

            return a < k && k <= s;
        }

        private NodeInfo ClosestsPrecedingNode(BigInteger id)
        {
            lock (fingers)
            {
                for (int i = chordKeyLength - 1; i >= 0; i--)
                    if (fingers[i] != null
                        &&
                        TestKey(myData.ID,fingers[i].ID,id))
                        return fingers[i];
                return myData;
            }
        }

        public NodeInfo FindSuccessor(BigInteger id)
        {
            if (TestKey(myData.ID,id,((NodeInfo)successors[0]).ID))
                return (NodeInfo)successors[0];

            NodeInfo cpn = ClosestsPrecedingNode(id);

            if (cpn.Equals(myData))
                return myData;

            ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), cpn.Address + ":" + cpn.Port + "/ChordServices");
            if (obj != null)
            {
                try
                {
                    return obj.Findsuccessor(id);
                }
                catch (IOException) { }
                catch (SocketException) { }
            }

            //Unable to find successor for node. Return null
            return null;
        }

        public NodeInfo Join(string knownChordNodeAddress, int knownChordNodePort) //Return successor
        {
            Predecessor = null;
            ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), knownChordNodeAddress + ":" + knownChordNodePort + "/ChordServices");
            if (obj != null)
            {
                try
                {
                    return obj.Findsuccessor(myData.ID);
                }
                catch (IOException) { }
                catch (SocketException) { }
            }

            return null;
        }

        private void Stabilize()
        {
            while (true)
            {
                if (successors.Count != 0 && !((NodeInfo)successors[0]).Equals(myData))
                {
                    NodeInfo pred = null;
                    NodeInfo suc = (NodeInfo)successors[0];
                    ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), suc.Address + ":" + suc.Port + "/ChordServices");
                    if (obj != null)
                    {
                        try
                        {
                            pred = obj.Predecessor();
                            if (pred != null &&
                                TestKey(myData.ID, pred.ID, ((NodeInfo)this.successors[0]).ID))
                                successors[0] = pred;
                            NodeInfo ni = (NodeInfo)successors[0];
                            ChordNodeProxy obj2 = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), ni.Address + ":" + ni.Port + "/ChordServices");
                            if (obj2 != null)
                            {
                                try
                                {
                                    FixSucessors(obj2.Notify(myData));
                                }
                                catch (IOException) {
                                }
                                catch (SocketException) {
                                }
                            }
                        }
                        catch (IOException) { RotateSucessors(); }
                        catch (SocketException) { RotateSucessors(); }
                    }
                }
                Thread.Sleep(5000); //5s
            }
        }

        private void FixSucessors(ArrayList succs)
        {
            //This should keep the first successor, copy the rest and remove the last one
            for (int i = 1; i < MAX_SUCESSORS; i++)
                successors[i] = succs[i - 1];
            //Replicate my data to my successors
            Dictionary<BigInteger, List<string>> data;
            if (Predecessor != null)
            {
                data = new Dictionary<BigInteger, List<string>>();
                foreach (BigInteger key in keyTable.Keys.Where<BigInteger>(x => x > Predecessor.ID))
                    data.Add(key, keyTable[key]);
            }
            else
            {
                data = new Dictionary<BigInteger, List<string>>(keyTable);
            }
            foreach (object succ in successors)
            {
                NodeInfo casted = (NodeInfo)succ;
                if (casted != myData)
                {
                    ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), casted.Address + ":" + casted.Port + "/ChordServices");
                    if (obj != null)
                    {
                        try
                        {
                            obj.ReplicateData(data);
                        }
                        catch (IOException){}
                        catch (SocketException){}
                    }
                }
            }
        }

        private void RotateSucessors()
        {
            successors.RemoveAt(0);
            //Here we are safe. Eventually stabilize will fix this.
            successors.Add(myData);
        }

        public void ReplicateData(Dictionary<BigInteger, List<string>> data)
        {
            foreach (BigInteger i in data.Keys)
            {
                if (!keyTable.ContainsKey(i))
                {
                    keyTable.Add(i, data[i]);
                }
            }
        }

        public void Notify(NodeInfo pred)
        {
            if (((NodeInfo)successors[0]).Equals(myData))
                successors[0] = pred; 
            if (Predecessor == null ||
                TestKey(Predecessor.ID,pred.ID,myData.ID))
                Predecessor = pred;
        }

        private void FixFingers()
        {
            while (true)
            {
                if (next == chordKeyLength)
                    next = 0;
                lock (fingers)
                {
                    fingers[next] = FindSuccessor((myData.ID + BigInteger.Power(2, next)) % maxValue);
                }
                next++;
                Thread.Sleep(300); //0.3s
            }
        }

        private void CheckPredecessor()
        {
            while (true)
            {
                if (Predecessor != null)
                {
                    ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), Predecessor.Address + ":" + Predecessor.Port + "/ChordServices");
                    if (obj != null)
                    {
                        try
                        {
                            obj.Ping();
                            continue;
                        }
                        catch (IOException) { }
                        catch (SocketException) { }
                    }
                    Predecessor = null;
                }
                Thread.Sleep(30000); //30s
            }
        }

        public void Put(string key, string value)
        {
            BigInteger keyID = new BigInteger(ChordNode.SHA(key));
            NodeInfo ni = ChordModule.Instance.NodeInstance.FindSuccessor(keyID);
            ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), ni.Address + ":" + ni.Port + "/ChordServices");
            if (obj != null)
            {
                try
                {
                    obj.Put(keyID, value);
                }
                catch (IOException) { }
                catch (SocketException) { }
            }
        }

        public List<string> Get(string key)
        {
            BigInteger keyID = new BigInteger(ChordNode.SHA(key));
            NodeInfo ni = ChordModule.Instance.NodeInstance.FindSuccessor(keyID);
            ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), ni.Address + ":" + ni.Port + "/ChordServices");
            if (obj != null)
            {
                try
                {
                    return obj.Get(keyID);
                }
                catch (IOException) { }
                catch (SocketException) { }
            }
            return null;
        }

        public void Remove(string key, string value)
        {
            BigInteger keyID = new BigInteger(ChordNode.SHA(key));
            NodeInfo ni = ChordModule.Instance.NodeInstance.FindSuccessor(keyID);
            ChordNodeProxy obj = (ChordNodeProxy)Activator.GetObject(typeof(ChordNodeProxy), ni.Address + ":" + ni.Port + "/ChordServices");
            if (obj != null)
            {
                try
                {
                    obj.Remove(keyID, value);
                }
                catch (IOException) { }
                catch (SocketException) { }
            }
        }
    }

    [Serializable]
    public class NodeInfo : ISerializable
    {
        public NodeInfo(SerializationInfo info, StreamingContext ctxt)
        {
            ID = (BigInteger)info.GetValue("ID", typeof(BigInteger));
            Address = (string)info.GetValue("Address", typeof(string));
            Port = (int)info.GetValue("Port", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ID", ID);
            info.AddValue("Address", Address);
            info.AddValue("Port", Port);
        }

        public NodeInfo(string address, int port, BigInteger id)
        {
            Address = address;
            Port = port;
            ID = id;
        }

        public override int GetHashCode()
        {
            return 1;
        }

        public override bool Equals(object obj)
        {
            if (obj is NodeInfo)
            {
                return (ID == ((NodeInfo)obj).ID);
            } return false;
        }

        public BigInteger ID { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
    }

    public class ChordNodeProxy : MarshalByRefObject
    {
        public NodeInfo Findsuccessor(BigInteger id)
        {
            return ChordModule.Instance.NodeInstance.FindSuccessor(id);
        }

        public NodeInfo Predecessor()
        {
            return ChordModule.Instance.NodeInstance.Predecessor;
        }

        public ArrayList Notify(NodeInfo pred)
        {
            ChordModule.Instance.NodeInstance.Notify(pred);
            return ChordModule.Instance.NodeInstance.Successors;
        }

        public void Ping()
        {
        }

        public void Put(BigInteger key, string value)
        {
            ChordModule.Instance.NodeInstance.Put(key, value);
        }

        public List<string> Get(BigInteger key)
        {
            return ChordModule.Instance.NodeInstance.Get(key);
        }

        public void Remove(BigInteger key, string value)
        {
            ChordModule.Instance.NodeInstance.Remove(key,value);
        }

        public Dictionary<BigInteger, List<string>> CopyKeys(BigInteger nodeID)
        {
            return ChordModule.Instance.NodeInstance.CopyKeys(nodeID);
        }

        public void ReplicateData(Dictionary<BigInteger, List<string>> data)
        {
            ChordModule.Instance.NodeInstance.ReplicateData(data);
        }
    }
}
