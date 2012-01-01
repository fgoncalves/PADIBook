using System;
using System.Collections.Generic;
using System.Linq;
using PADIBook.Utils;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net.Sockets;
using System.IO;
using PADIBook.Utils.Exceptions;

namespace PADIBook.Client
{
    public sealed class ServerServiceInvoker
    {
        private List<string> replicas;
        private readonly static object indexLock = new object();
        private int serverAddressToCall;
        public int ServerAddressToBeginCallIndex
        {
            set
            {
                lock (indexLock)
                {
                    serverAddressToCall = value;
                }
            }
        }

        private ServerServiceInvoker()
        {
            RemotingConfiguration.Configure("../../../App.config", true);
            replicas = new List<string>();
            serverAddressToCall = 0;
            foreach (string addr in Config.Instance.ServersConfiguration.Select(x => x.Address + ":" + x.Port + "/" + x.Name))
                replicas.Add(addr);

            System.Collections.IDictionary t = new System.Collections.Hashtable();
            t.Add("timeout", (uint)75000);
            TcpChannel channel = new TcpChannel(t, null, null);
            ChannelServices.RegisterChannel(channel, false);
        }

        private readonly static object singletonLock = new object();
        private static ServerServiceInvoker instance = null;
        public static ServerServiceInvoker Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (instance == null)
                        instance = new ServerServiceInvoker();
                    return instance;
                }
            }
        }

        public void CreateProfile(string name, string gender, int age, List<string> interests, string address, int port)
        {
            for(int i = 0; i < Config.Instance.NumberOfReplicas; i++)            
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        obj.CreateProfile(name, gender, age, interests, address, port);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public Profile GetUserProfile(string userName)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetProfile(userName);
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public void UpdateUserProfile(Profile profile)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        obj.UpdateProfile(profile);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public void Post(Profile user, string msg)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        Post p = new Post(user.UserName, msg);
                        obj.AddPost(p);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public List<Post> GetPostList()
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetPostList();
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public Friends GetFriends()
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetFriendList();
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public FriendRequestList GetSentRequests()
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetSentFriendRequests();
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public FriendRequestList GetReceivedRequests()
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetReceivedFriendRequests();
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public void AddFriend(FriendRequest fr)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {                        
                        obj.AcceptFriendRequest(fr);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public void RejectFriend(FriendRequest fr)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        obj.RejectFriendRequest(fr);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public void SendFriendRequest(FriendRequest fr)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        obj.SendFriendRequest(fr);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public string LookupByUserName(string username)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.LookupByUserName(username);
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public List<string> LookupByInterest(string interest)
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.LookupByInterest(interest);
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }

        public List<string> LookupByGenderAndAge(string gender, int lowerBound, int upperBound) 
        {
            for (int i = 0; i < Config.Instance.NumberOfReplicas; i++)
            {
                string addr;
                lock (indexLock)
                {
                    addr = replicas[(serverAddressToCall + i) % Config.Instance.NumberOfReplicas];
                }
                IClientServices obj = (IClientServices)Activator.GetObject(typeof(IClientServices), addr + "/ClientServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.LookupByGenderAndAge(gender, lowerBound, upperBound);
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Unable to contact any server.");
        }
    }
}
