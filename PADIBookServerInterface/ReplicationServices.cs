using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Net.Sockets;
using PADIBook.Utils;
using PADIBook.Server;

using PADIBook.Utils.Exceptions;

namespace PADIBook.Server.Replication
{
    public class ReplicationServices : MarshalByRefObject
    {
        public void WriteEntity(Entity e)
        {
            Thread.Sleep(Config.Instance.FreezeTime);
            ServerManager.Instance.ServerInstance.SimpleWriteEntity(e);
        }

        public Entity ReadEntity(string id)
        {
            Thread.Sleep(Config.Instance.FreezeTime);
            return ServerManager.Instance.ServerInstance.SimpleReadEntity(id);
        }
    }

    public class QuorunRead
    {
        delegate void GotEntityDel(Entity e);
        delegate void FinishedRequestDel();

        private Entity response;
        private int countSuccessfulReads, countAnswers;

        public QuorunRead()
        {
            response = null;
            countAnswers = 0;
            countSuccessfulReads = 0;
            GotEntityEvent += new GotEntityDel(GotEntityEventHandler);
            FinishedRequestEvent += new FinishedRequestDel(FinishedRequestEventHandler);
        }

        private GotEntityDel gotEntityDel;
        private event GotEntityDel GotEntityEvent
        {
            add { gotEntityDel += value; }
            remove
            {
                if (gotEntityDel != null)
                    gotEntityDel -= value;
            }
        }

        private FinishedRequestDel finishedRequestDel;
        private event FinishedRequestDel FinishedRequestEvent
        {
            add { finishedRequestDel += value; }
            remove
            {
                if (finishedRequestDel != null)
                    finishedRequestDel -= value;
            }
        }

        class ThreadedRead
        {
            private string entityID;
            private string address;
            private QuorunRead quorunRead;

            public ThreadedRead(string entityID, string address, QuorunRead quorunRead)
            {
                this.entityID = entityID;
                this.address = address;
                this.quorunRead = quorunRead;
            }

            public void RemoteRead()
            {
                ReplicationServices obj = (ReplicationServices)Activator.GetObject(typeof(ReplicationServices), address + "/ReplicationServices");
                try
                {
                    if (obj != null)
                    {
                        Entity e = obj.ReadEntity(entityID);
                        quorunRead.gotEntityDel(e);
                    }
                }
                catch (IOException) { }
                catch (SocketException) { }
                quorunRead.finishedRequestDel();
            }
        }

        private void GotEntityEventHandler(Entity e)
        {
            lock (this)
            {
                if (response == null)
                    response = e;
                else
                {
                    if (e != null)
                        response = (response.Timestamp > e.Timestamp) ? response : e;
                }
                countSuccessfulReads++;
                Monitor.Pulse(this);
                return;
            }
        }

        private void FinishedRequestEventHandler()
        {
            lock (this)
            {
                countAnswers++;
                Monitor.Pulse(this);
            }
        }

        public Entity Read(string entityID, List<string> replicas)
        {
            Entity local = ServerManager.Instance.ServerInstance.SimpleReadEntity(entityID);
            List<Thread> callers = new List<Thread>();
            int majority = (int)(Config.Instance.NumberOfReplicas / 2.0);

            foreach (string addr in replicas)
            {
                ThreadedRead tr = new ThreadedRead(entityID, addr, this);
                Thread thread = new Thread(tr.RemoteRead);
                callers.Add(thread);
                thread.Start();
            }

            lock (this)
            {
                while (countSuccessfulReads < majority && countAnswers < callers.Count)
                    Monitor.Wait(this);
            }

            foreach (Thread t in callers)
                if (t.IsAlive)
                    t.Abort();

            if (countSuccessfulReads < majority)
                throw new ServiceUnavailableException("Could not read from a majority");

            if (response != null && local != null)
                return (response.Timestamp > local.Timestamp) ? response : local;
            if (response == null)
                return local;
            return response;
        }
    }

    public class QuorunWrite
    {
        delegate void EntityWritenDel();
        delegate void FinishedRequestDel();

        private int countSuccessfulWrites, countAnswers;

        public QuorunWrite()
        {
            countAnswers = 0;
            countSuccessfulWrites = 0;
            EntityWritenEvent += new EntityWritenDel(EntityWritenEventHandler);
            FinishedRequestEvent += new FinishedRequestDel(FinishedRequestEventHandler);
        }

        private EntityWritenDel entityWritenDel;
        private event EntityWritenDel EntityWritenEvent
        {
            add { entityWritenDel += value; }
            remove
            {
                if (entityWritenDel != null)
                    entityWritenDel -= value;
            }
        }

        private FinishedRequestDel finishedRequestDel;
        private event FinishedRequestDel FinishedRequestEvent
        {
            add { finishedRequestDel += value; }
            remove
            {
                if (finishedRequestDel != null)
                    finishedRequestDel -= value;
            }
        }

        class ThreadedWrite
        {
            private Entity e;
            private string address;
            private QuorunWrite quorunWrite;

            public ThreadedWrite(Entity e, string address, QuorunWrite quorunWrite){
                this.e = e;
                this.address = address;
                this.quorunWrite = quorunWrite;
            }

            public void RemoteWrite()
            {
                ReplicationServices obj = (ReplicationServices)Activator.GetObject(typeof(ReplicationServices), address + "/ReplicationServices");
                try
                {
                    if (obj != null)
                    {
                        obj.WriteEntity(e);
                        quorunWrite.entityWritenDel();
                    }
                }
                catch (IOException) { }
                catch (SocketException) { }
                quorunWrite.finishedRequestDel();
            }
        }

        private void EntityWritenEventHandler()
        {
            lock (this)
            {
                countSuccessfulWrites++;
                Monitor.Pulse(this);
                return;
            }
        }

        private void FinishedRequestEventHandler()
        {
            lock (this)
            {
                countAnswers++;
                Monitor.Pulse(this);
            }
        }

        public void Write(DomainObject o, List<string> replicas)
        {
            Entity ent = new QuorunRead().Read(o.ID, replicas);
            if (ent == null)
            {
                ent = new Entity();
                ent.Value = o;
            }
            else
            {
                ent.Timestamp++;
                ent.Value = o;
            }

            List<Thread> callers = new List<Thread>();
            int majority = (int)(Config.Instance.NumberOfReplicas / 2.0);

            foreach (string addr in replicas)
            {
                ThreadedWrite tw = new ThreadedWrite(ent, addr, this);
                Thread thread = new Thread(tw.RemoteWrite);
                callers.Add(thread);
                thread.Start();
            }

            lock (this)
            {
                while (countSuccessfulWrites < majority && countAnswers < callers.Count)
                    Monitor.Wait(this);
            }

            foreach (Thread t in callers)
                if (t.IsAlive)
                    t.Abort();

            if (countSuccessfulWrites < majority)
                throw new ServiceUnavailableException("Could not write to a majority");

            ServerManager.Instance.ServerInstance.SimpleWriteEntity(ent);
        }
    }
}
