using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using PADIBook.Server.DB;
using PADIBook.Utils;
using PADIBook.Server.Replication;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using PADIBook.Utils.Exceptions;

namespace PADIBook.Server
{
    public class Server
    {
        private readonly string id;
        private readonly string address;
        private readonly int port;
        private readonly DataBase serverDB;
        private readonly List<string> replicas;
        private readonly ServerRequestManager serverRequestManager;
        private readonly ChordNode cn;

        public Server(string id, string address, int port, List<string> knownReplicas)
        {
            RemotingConfiguration.Configure("../../../App.config", true);
            IDictionary t = new Hashtable();
            t.Add("timeout", (uint)75000);
            t.Add("port", port);
            TcpChannel channel = new TcpChannel(t, null, null);
            ChannelServices.RegisterChannel(channel, false);

            this.id = id;
            this.address = address;
            this.port = port;
            Exit = false;
            string folderName = address.Split("://".ToCharArray())[3] + "." + port;
            serverDB = new DataBase(folderName, "server.db");
            replicas = new List<string>(knownReplicas);
            serverRequestManager = new ServerRequestManager();
            cn = new ChordNode(address, port);
        }

        public Server(string id, string address, int port, List<string> knownReplicas, string knownChordAddress, int knownChordPort)
        {
            RemotingConfiguration.Configure("../../../App.config", true);
            IDictionary t = new Hashtable();
            t.Add("timeout", (uint)75000);
            t.Add("port", port);
            TcpChannel channel = new TcpChannel(t, null, null);
            ChannelServices.RegisterChannel(channel, false);

            this.id = id;
            this.address = address;
            this.port = port;
            Exit = false;
            string folderName = address.Split("://".ToCharArray())[3] + "." + port;
            serverDB = new DataBase(folderName, "server.db");
            replicas = new List<string>(knownReplicas);
            serverRequestManager = new ServerRequestManager();
            cn = new ChordNode(address, port, knownChordAddress, knownChordPort);
        }

        //Properties
        public string ID
        {
            get { return id; }
        }

        public string Address
        {
            get { return address; }
        }

        public int Port
        {
            get { return port; }
        }

        public DataBase ServerDataBase
        {
            get { return serverDB; }
        }

        public bool Exit
        {
            get;
            set;
        }

        public ServerRequestManager ServerRequestInvoker
        {
            get
            {
                return serverRequestManager;
            }
        }
        //-----------------------

        public void Start()
        {
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ClientServices),
                id + "/ClientServices", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ReplicationServices),
                id + "/ReplicationServices", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ServerToServerServices),
                "ServerToServerServices", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(ChordNodeProxy),
               "ChordServices", WellKnownObjectMode.Singleton);

            //Initialize Chord stuff
            ChordModule.Instance.RegisterChordInstance(cn);

            InitKeys();
            //======================
            while (!Exit) ;
        }

        public void InitKeys()
        {
            try
            {
                Profile pro = (Profile)ReadDomainObject("Profile");
                if (pro != null)
                {
                    ChordModule.Instance.NodeInstance.Put(pro.UserName, pro.Address + ":" + pro.Port);
                    foreach(string interest in pro.Interests)
                        ChordModule.Instance.NodeInstance.Put(interest, pro.Address + ":" + pro.Port);                    
                    ChordModule.Instance.NodeInstance.Put(pro.Gender + pro.Age, pro.Address + ":" + pro.Port);
                }
            }
            catch (ServiceUnavailableException)
            {

            }
        }

        public void DeleteKeys()
        {
            try
            {
                Profile pro = (Profile)ReadDomainObject("Profile");
                if (pro != null)
                {
                    ChordModule.Instance.NodeInstance.Remove(pro.UserName, pro.Address + ":" + pro.Port);
                    foreach (string interest in pro.Interests)
                        ChordModule.Instance.NodeInstance.Remove(interest, pro.Address + ":" + pro.Port);
                    ChordModule.Instance.NodeInstance.Remove(pro.Gender + pro.Age, pro.Address + ":" + pro.Port);
                }
            }
            catch (ServiceUnavailableException)
            {

            }
        }

        public void SimpleWriteEntity(Entity o)
        {
            Entity old = serverDB.GetEntity(o.Value.ID);
            if (old == null || old.Timestamp < o.Timestamp)
            {
                serverDB.AddEntity(o);
                return;
            }
        }

        public void WriteDomainObject(DomainObject o)
        {
            new QuorunWrite().Write(o, replicas);
        }

        public Entity SimpleReadEntity(string id)
        {
            return serverDB.GetEntity(id);
        }

        public DomainObject ReadDomainObject(string id)
        {
            Entity e = new QuorunRead().Read(id, replicas);
            if (e != null)
                return e.Value;
            return null;
        }

        public string Status(bool verbose)
        {
            string result;
            result = "Address: " + address + ":" + port + "/" + id + "\r\n";
            result += "Known replicas:\r\n";
            foreach (string addr in replicas)
                result += "\t" + addr + "\r\n";
            Entity posts = SimpleReadEntity("PostList");
            if (posts != null)
            {
                result += "Posts:\r\n";
                foreach (Post p in ((PostList)posts.Value).PList)
                    result += "\t" + p.UserName + ": " + p.Message + "\r\n";
            }
            result += "Chord info:\r\n";
            result += "\tid: " + ChordModule.Instance.NodeInstance.ChordID + "\r\n";
            if (ChordModule.Instance.NodeInstance.Predecessor != null)
            {
                result += "\tPredecessor info:\r\n";
                result += "\t\tPredecessor ID: " + ChordModule.Instance.NodeInstance.Predecessor.ID + "\r\n";
                result += "\t\tPredecessor Address: " + ChordModule.Instance.NodeInstance.Predecessor.Address + ":" + ChordModule.Instance.NodeInstance.Predecessor.Port + "\r\n";
            }
            if (ChordModule.Instance.NodeInstance.Successors != null)
            {
                result += "\tsuccessors info:\r\n";
                foreach (object succ in ChordModule.Instance.NodeInstance.Successors)
                {
                    result += "\t\tsuccessor ID: " + ((NodeInfo) succ).ID + "\r\n";
                    result += "\t\tsuccessor Address: " + ((NodeInfo)succ).Address + ":" + ((NodeInfo)succ).Port + "\r\n";
                }
            }

            if (verbose)
            {
                result += "\tFingers:\r\n";
                for (int i = 0; i < ChordModule.Instance.NodeInstance.Fingers.Length; i++)
                {
                    NodeInfo ni = ChordModule.Instance.NodeInstance.Fingers[i];
                    if (ni != null)
                        result += "\t\t[" + i + "]: " + ni.Address + ":" + ni.Port + " ID: " + ni.ID + "\r\n";
                }
                result += "\tKeys:\r\n";
                Dictionary<BigInteger, List<string>> chordKeys = ChordModule.Instance.NodeInstance.Keys;
                foreach (BigInteger key in chordKeys.Keys)
                {
                    result += "\t\t" + key + ":\r\n";
                    foreach (string addr in chordKeys[key])
                        result += "\t\t\t" + addr + "\r\n";
                }
            }
            return result;
        }
    }

    public sealed class ServerManager
    {
        private static ServerManager instance = null;
        private readonly static object singLock = new object();
        public static ServerManager Instance
        {
            get
            {
                lock (singLock)
                {
                    if (instance == null)
                        instance = new ServerManager();
                    return instance;
                }
            }
        }

        private ServerManager() { }

        private Server server = null;
        public Server ServerInstance
        {
            get
            {
                return server;
            }
        }

        public void RegisterServer(Server server)
        {
            this.server = server;
        }

        public void StartServer()
        {
            if (server == null)
                throw new Exception("Server not registered.");

            new Thread(this.server.Start).Start();
        }
    }
}
