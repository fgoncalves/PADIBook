using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PADIBook.Utils;
using PADIBook.Utils.Exceptions;
using PADIBook.Server;
using System.IO;
using System.Net.Sockets;

namespace PADIBook.Server
{
    public class ServerRequestManager
    {

        public void SendFriendRequest(FriendRequest fr)
        {
            for (int i = 1; i <= Config.Instance.NumberOfReplicas; i++)
            {
                ServerToServerServices obj = (ServerToServerServices)Activator.GetObject(typeof(ServerToServerServices), fr.SendTo + ":" + (fr.SendToPort + i) + "/ServerToServerServices");
                if (obj != null)
                {
                    try
                    {
                        obj.ReceiveFriendRequest(fr);
                        return;
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Could not deliver friend request, please try again later.");
        }

        public void RejectFriendRequest(FriendRequest fr)
        {
            for (int i = 1; i <= Config.Instance.NumberOfReplicas; i++)
            {
                ServerToServerServices obj = (ServerToServerServices)Activator.GetObject(typeof(ServerToServerServices), fr.FromAddress + ":" + (fr.FromPort+ i) + "/ServerToServerServices");
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
            throw new ServiceUnavailableException("Could not notify user of rejection.");
        }

        public void AcceptFriendRequest(FriendRequest fr)
        {
            Profile profile = (Profile)ServerManager.Instance.ServerInstance.ReadDomainObject("Profile");
            fr.RequestedUserName = profile.UserName;
            for (int i = 1; i <= Config.Instance.NumberOfReplicas; i++)
            {
                ServerToServerServices obj = (ServerToServerServices)Activator.GetObject(typeof(ServerToServerServices), fr.FromAddress + ":" + (fr.FromPort + i) + "/ServerToServerServices");
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
            throw new ServiceUnavailableException("Could not notify user of acceptance.");
        }

        public List<Post> GetPostsFromLastDate(DateTime dt, Friend friend)
        {
            for (int i = 1; i <= Config.Instance.NumberOfReplicas; i++)
            {
                ServerToServerServices obj = (ServerToServerServices)Activator.GetObject(typeof(ServerToServerServices), friend.Address + ":" + (friend.Port + i) + "/ServerToServerServices");
                if (obj != null)
                {
                    try
                    {
                        return obj.GetPostsFromLastDate(dt);                        
                    }
                    catch (IOException) { }
                    catch (SocketException) { }
                }
            }
            throw new ServiceUnavailableException("Could not notify user of acceptance.");
        }
    }

    public class ServerToServerServices : MarshalByRefObject
    {
        public void ReceiveFriendRequest(FriendRequest fr)
        {
            //Return if we're already friends
            Friends friends = (Friends)ServerManager.Instance.ServerInstance.ReadDomainObject("Friends");
            if (friends != null && friends.FriendsInfo.ContainsKey(fr.RequestingUserName))
                return;

            FriendRequestList pl = (FriendRequestList)ServerManager.Instance.ServerInstance.ReadDomainObject("ReceivedFriendRequests");
            if (pl == null)
            {
                pl = new FriendRequestList("ReceivedFriendRequests");
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
            pl.AddFriendRequest(fr);
            ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
        }

        public void RejectFriendRequest(FriendRequest fr)
        {
            FriendRequestList pl = (FriendRequestList)ServerManager.Instance.ServerInstance.ReadDomainObject("SentFriendRequests");
            if (pl != null)
            {
                pl.RemoveFriendRequest(fr);
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }
        }

        public void AcceptFriendRequest(FriendRequest fr)
        {
            //Remove request
            FriendRequestList pl = (FriendRequestList)ServerManager.Instance.ServerInstance.ReadDomainObject("SentFriendRequests");
            if (pl != null)
            {
                pl.RemoveFriendRequest(fr);
                ServerManager.Instance.ServerInstance.WriteDomainObject(pl);
            }            

            //Add friend
            Friends plist = (Friends)ServerManager.Instance.ServerInstance.ReadDomainObject("Friends");
            if (plist == null)
            {
                plist = new Friends("Friends");                
            }
            //  Add only if we're not already friends
            if (!plist.FriendsInfo.ContainsKey(fr.RequestedUserName))
            {
                plist.AddFriend(fr.RequestedUserName, fr.SendTo, fr.SendToPort);
                ServerManager.Instance.ServerInstance.WriteDomainObject(plist);

                //Add post
                Post p = new Post("PADIBook de " + fr.RequestingUserName, fr.RequestedUserName + " ficou seu amigo.O seu endereço é " + fr.SendTo + ":" + fr.SendToPort);
                PostList postl = (PostList)ServerManager.Instance.ServerInstance.ReadDomainObject("PostList");
                if (postl == null)
                {
                    postl = new PostList("PostList");
                    ServerManager.Instance.ServerInstance.WriteDomainObject(postl);
                }
                postl.AddPost(p);
                ServerManager.Instance.ServerInstance.WriteDomainObject(postl);
            }
        }

        private PostList GetPostList()
        {
            PostList pl = (PostList)ServerManager.Instance.ServerInstance.ReadDomainObject("PostList");
            return pl;
        }

        public List<Post> GetPostsFromLastDate(DateTime dt)
        {
            PostList pl = GetPostList();
            if (pl != null)
            {
                return (pl.PList.Where<Post>(x => x.TimeStamp.CompareTo(dt) > 0)).ToList<Post>();
            }
            return null;
        }
    }
}
