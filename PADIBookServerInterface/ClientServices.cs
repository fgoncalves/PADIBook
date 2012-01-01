using System;
using System.Threading;
using PADIBook.Server;
using System.Collections.Generic;
using PADIBook.Utils;
using PADIBook.Utils.Exceptions;
using System.Runtime.Remoting;

namespace PADIBook.Server
{
    public class ClientServices : MarshalByRefObject, IClientServices
    {
        public string LookupByUserName(string username)
        {
            List<string> results = ChordModule.Instance.NodeInstance.Get(username);
            if (results != null && results.Count > 0)
                return results[0];
            return null;
        }

        public List<string> LookupByInterest(string interest)
        {
            return ChordModule.Instance.NodeInstance.Get(interest);
        }

        public List<string> LookupByGenderAndAge(string gender, int lowerBound, int upperBound)
        {
            List<string> results = new List<string>();

            for (; lowerBound <= upperBound; lowerBound++)
            {
                List<string> res = ChordModule.Instance.NodeInstance.Get(gender + lowerBound);
                if (res != null && res.Count > 0)
                    results.AddRange(res);
            }
            return results;
        }

        public void AddPost(Post p)
        {
            PostList pl = (PostList)ServerManager.Instance.ServerInstance.ReadDomainObject("PostList");
            if (pl == null)
            {
                pl = new PostList("PostList");
            }
            pl.AddPost(p);
            ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
        }

        public List<Post> GetPostList()
        {
            PostList pl = (PostList)ServerManager.Instance.ServerInstance.ReadDomainObject("PostList");
            if (pl == null)
            {
                pl = new PostList("PostList");
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
            //obter posts de amigos
            List<Post> Friends = UpdateFriends();
            Friends.AddRange(pl.PList);
            Friends.Sort();
            return Friends;
        }

        public void CreateProfile(string name, string gender, int age, List<string> interests, string addr, int port)
        {
            Profile p = new Profile(name, gender, age, interests, addr, port);
            ServerManager.Instance.ServerInstance.WriteDomainObject(p);
            ServerManager.Instance.ServerInstance.InitKeys();
        }

        public Profile GetProfile(string username)
        {
            Profile p = (Profile)ServerManager.Instance.ServerInstance.ReadDomainObject("Profile");
            if (p != null)
                return p.UserName == username ? p : null;
            return null;
        }

        public void UpdateProfile(Profile p)
        {
            ServerManager.Instance.ServerInstance.DeleteKeys();
            ServerManager.Instance.ServerInstance.WriteDomainObject(p);
            ServerManager.Instance.ServerInstance.InitKeys();
        }

        public void SendFriendRequest(FriendRequest f)
        {
            //Return if we're already friends
            Friends friends = GetFriendList();
            foreach (Friend friend in friends.FriendsInfo.Values)
                if (friend.Address == f.SendTo && friend.Port == f.SendToPort)
                    return;
            try
            {
                ServerManager.Instance.ServerInstance.ServerRequestInvoker.SendFriendRequest(f);
            }
            catch (ServiceUnavailableException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar o pedido.Por favor tente mais tarde.");
            }
            catch (RemotingException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar o pedido.");
            }
            FriendRequestList pl = GetSentFriendRequests();
            pl.AddFriendRequest(f);
            ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
        }

        public void AcceptFriendRequest(FriendRequest f)
        {
            try
            {
                ServerManager.Instance.ServerInstance.ServerRequestInvoker.AcceptFriendRequest(f);
                //Get processed requests

                Post p = new Post("PADIBook de " + f.RequestedUserName, f.RequestingUserName + " ficou seu amigo. O seu endereço é " + f.FromAddress + ":" + f.FromPort);
                PostList pl = (PostList)ServerManager.Instance.ServerInstance.ReadDomainObject("PostList");
                if (pl == null)
                {
                    pl = new PostList("PostList");
                }
                pl.AddPost(p);
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
            catch (ServiceUnavailableException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar a resposta.");
            }
            catch (RemotingException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar o pedido.");
            }
            f.FriendRequestState = FriendRequest.RequestState.ACCEPTED;
            FriendRequestList recvFrdReqs = GetReceivedFriendRequests();

            //add friend
            Friends friends = GetFriendList();
            friends.AddFriend(f.RequestingUserName, f.FromAddress, f.FromPort);
            ServerManager.Instance.ServerInstance.WriteDomainObject(friends);

            //Remove request from received requests
            recvFrdReqs.RemoveFriendRequest(f);
            ServerManager.Instance.ServerInstance.WriteDomainObject(recvFrdReqs);
        }

        public void RejectFriendRequest(FriendRequest f)
        {
            try
            {
                ServerManager.Instance.ServerInstance.ServerRequestInvoker.RejectFriendRequest(f);

                f.FriendRequestState = FriendRequest.RequestState.REJECTED;
                FriendRequestList receivedReqs = GetReceivedFriendRequests();
                receivedReqs.RemoveFriendRequest(f);
                ServerManager.Instance.ServerInstance.WriteDomainObject(receivedReqs);
            }
            catch (ServiceUnavailableException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar o pedido.");
            }
            catch (RemotingException)
            {
                throw new ServiceUnavailableException("Não foi possível enviar o pedido.");
            }
        }

        public FriendRequestList GetSentFriendRequests()
        {
            FriendRequestList pl = (FriendRequestList)ServerManager.Instance.ServerInstance.ReadDomainObject("SentFriendRequests");
            if (pl == null)
            {
                pl = new FriendRequestList("SentFriendRequests");
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
            return pl;
        }

        public FriendRequestList GetReceivedFriendRequests()
        {
            FriendRequestList pl = (FriendRequestList)ServerManager.Instance.ServerInstance.ReadDomainObject("ReceivedFriendRequests");
            if (pl == null)
            {
                pl = new FriendRequestList("ReceivedFriendRequests");
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
            return pl;
        }

        public Friends GetFriendList()
        {
            Friends plist = (Friends)ServerManager.Instance.ServerInstance.ReadDomainObject("Friends");
            if (plist == null)
            {
                plist = new Friends("Friends");
            }
            return plist;
        }

        private List<Post> UpdateFriends()
        {
            Friends friends = GetFriendList();
            List<Post> pl = new List<Post>();
            foreach (Friend friend in friends.FriendsInfo.Values)
            {
                try
                {
                    PostList Friends = GetPostListOfFriend(friend.UserName);
                    Post lastPost = null;
                    if (Friends.PList.Count > 0)
                    {
                        pl.AddRange(Friends.PList);
                        lastPost = Friends.PList[0];
                    }

                    List<Post> mostRecentPosts = null;

                    if (lastPost != null)
                        mostRecentPosts = ServerManager.Instance.ServerInstance.ServerRequestInvoker.GetPostsFromLastDate(lastPost.TimeStamp, friend);
                    else
                        mostRecentPosts = ServerManager.Instance.ServerInstance.ServerRequestInvoker.GetPostsFromLastDate(DateTime.MinValue, friend);

                    if (mostRecentPosts != null)
                    {
                        //guardar actualizações
                        UpdateFriendPosts(friend.UserName, mostRecentPosts);
                        pl.AddRange(mostRecentPosts);
                    }
                }
                catch (ServiceUnavailableException)
                {
                    //Se os servidores dos amigos estiverem em baixo, não fazer nada
                }
            }
            return pl;
        }

        private PostList GetPostListOfFriend(string username)
        {
            Friends fp = (Friends)ServerManager.Instance.ServerInstance.ReadDomainObject("Friends");
            if (fp == null)
            {
                fp = new Friends("Friends");
                ServerManager.Instance.ServerInstance.WriteDomainObject(fp);
            }
            if (fp.FriendsInfo.ContainsKey(username))
            {
                return fp.FriendsInfo[username].Posts;
            }
            return null;
        }

        private void UpdateFriendPosts(string username, List<Post> newPosts)
        {
            Friends fp = (Friends)ServerManager.Instance.ServerInstance.ReadDomainObject("Friends");
            if (fp == null)
            {
                fp = new Friends("Friends");
                ServerManager.Instance.ServerInstance.WriteDomainObject(fp);
            }
            fp.FriendsInfo[username].Posts.AddAll(newPosts);
            ServerManager.Instance.ServerInstance.WriteDomainObject(fp);
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}
