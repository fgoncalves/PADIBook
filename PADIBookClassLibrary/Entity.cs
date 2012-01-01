using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Runtime.Remoting;

namespace PADIBook.Utils
{
    [Serializable()]
    public sealed class Entity : ISerializable
    {
        public int Timestamp
        {
            get;
            set;
        }

        public DomainObject Value
        {
            get;
            set;
        }

        //constructors
        public Entity()
        {
            Timestamp = 0;
        }

        public Entity(SerializationInfo info, StreamingContext ctxt)
        {
            DeserializeEntity(info, ctxt);
        }

        //methods
        private void SerializeEntity(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Timestamp", Timestamp);
            info.AddValue("Value", Value);
        }

        private void DeserializeEntity(SerializationInfo info, StreamingContext ctxt)
        {
            Timestamp = (int)info.GetValue("Timestamp", typeof(int));
            Value = (DomainObject)info.GetValue("Value", typeof(DomainObject));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            SerializeEntity(info, ctxt);
        }
    }

    [Serializable()]
    public abstract class DomainObject : EqualityComparer<DomainObject>, ISerializable
    {
        protected string id;

        public string ID
        {
            get
            {
                return id;
            }
        }

        public DomainObject(string id)
        {
            this.id = id;
        }

        public DomainObject(SerializationInfo info, StreamingContext ctxt)
        {
            DeserializeDomainObject(info, ctxt);
            Deserialize(info, ctxt);
        }

        private void SerializeDomainObject(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ID", id);
        }

        private void DeserializeDomainObject(SerializationInfo info, StreamingContext ctxt)
        {
            id = (string)info.GetValue("ID", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            SerializeDomainObject(info, ctxt);
            Serialize(info, ctxt);
        }

        public override int GetHashCode(DomainObject obj)
        {
            return obj.ID.GetHashCode();
        }

        public override bool Equals(DomainObject x, DomainObject y)
        {
            return x.ID.Equals(y.ID);
        }

        protected abstract void Serialize(SerializationInfo info, StreamingContext ctxt);
        protected abstract void Deserialize(SerializationInfo info, StreamingContext ctxt);
    }

    [Serializable()]
    public class Post : DomainObject, IComparable<Post>
    {
        public string Message
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get
            {
                return timeStamp;
            }
        }

        private static int postCounter = 1;

        public Post(string user, string message)
            : base(user + "Post" + postCounter)
        {
            postCounter++;
            UserName = user;
            Message = message;
            timeStamp = DateTime.Now;
        }

        public Post(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Post", Message);
            info.AddValue("UserName", UserName);
            info.AddValue("PostCounter", postCounter);
            info.AddValue("TimeStamp", TimeStamp);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            Message = (string)info.GetValue("Post", typeof(string));
            UserName = (string)info.GetValue("UserName", typeof(string));
            postCounter = (int)info.GetValue("PostCounter", typeof(int));
            timeStamp = (DateTime)info.GetValue("TimeStamp", typeof(DateTime));
        }

        public int CompareTo(Post o)
        {
            return -this.TimeStamp.CompareTo(((Post)o).timeStamp);
        }
    }

    [Serializable()]
    public class FriendRequest : DomainObject
    {
        public string SendTo
        {
            get;
            set;
        }

        public int SendToPort
        {
            get;
            set;
        }

        public string RequestingUserName
        {
            get;
            set;
        }

        public string FromAddress
        {
            get;
            set;
        }

        public int FromPort
        {
            get;
            set;
        }

        public enum RequestState { UNDECIDED, ACCEPTED, REJECTED };
        public RequestState FriendRequestState
        {
            get;
            set;
        }

        public string RequestedUserName
        {
            get;
            set;
        }

        private static int friendRequestCounter = 1;

        public FriendRequest(string fromAddr, int fromPort, string to, int toPort, string requestingUser)
            : base(friendRequestCounter + "FriendRequest")
        {
            friendRequestCounter++;
            SendTo = to;
            SendToPort = toPort;
            FromAddress = fromAddr;
            RequestingUserName = requestingUser;
            FromPort = fromPort;
            FriendRequestState = RequestState.UNDECIDED;
        }

        public FriendRequest(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("SendTo", SendTo);
            info.AddValue("SendToPort", SendToPort);
            info.AddValue("state", FriendRequestState);
            info.AddValue("RequestingUserName", RequestingUserName);
            info.AddValue("RequestedUserName", RequestedUserName);
            info.AddValue("FromAddress", FromAddress);
            info.AddValue("FromPort", FromPort);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            SendTo = (string)info.GetValue("SendTo", typeof(string));
            SendToPort = (int)info.GetValue("SendToPort", typeof(int));
            RequestingUserName = (string)info.GetValue("RequestingUserName", typeof(string));
            FriendRequestState = (RequestState)info.GetValue("state", typeof(RequestState));
            FromAddress = (string)info.GetValue("FromAddress", typeof(string));
            RequestedUserName = (string)info.GetValue("RequestedUserName", typeof(string));
            FromPort = (int)info.GetValue("FromPort", typeof(int));            
        }

        public override string ToString()
        {
            return RequestingUserName;
        }
    }

    [Serializable()]
    public class PostList : DomainObject
    {
        private List<Post> plist;
        public List<Post> PList
        {
            get
            {
                return plist;
            }
        }

        public PostList(string id)
            : base(id)
        {
            plist = new List<Post>();
        }

        public PostList(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        public void AddPost(Post post)
        {
            plist.Add(post);
            plist.Sort();
        }

        public void RemovePost(Post p)
        {
            plist.Remove(p);
            plist.Sort();
        }

        public void AddAll(List<Post> pl)
        {
            plist.AddRange(pl);
            plist.Sort();
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("PList", plist);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            plist = (List<Post>)info.GetValue("PList", typeof(List<Post>));
        }
    }


    [Serializable()]
    public class Friends : DomainObject
    {
        private Dictionary<string, Friend> friends;
        public Dictionary<string, Friend> FriendsInfo
        {
            get
            {
                return friends;
            }
        }

        public Friends(string id)
            : base(id)
        {
            friends = new Dictionary<string, Friend>();
        }

        public Friends(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        public void AddPost(string username,Post post)
        {
            if (friends.ContainsKey(username))
            {
                friends[username].Posts.AddPost(post);
            }
        }

        public void RemovePost(string username, Post p)
        {
            if (friends.ContainsKey(username))
            {
                friends[username].Posts.RemovePost(p);
            }
        }

        public void AddAll(string username, List<Post> pl)
        {
            if (friends.ContainsKey(username))
            {
                friends[username].Posts.AddAll(pl);
            }
        }

        public void AddFriend(string username, string addr, int port)
        {
            friends.Add(username, new Friend(username,addr,port));
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Friends", friends);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            friends = (Dictionary<string, Friend>)info.GetValue("Friends", typeof(Dictionary<string, Friend>));
        }
    }

    [Serializable()]
    public class Friend : DomainObject
    {
        public string UserName { get; set; }

        public string Address { get; set; }

        public int Port { get; set; }

        public PostList Posts { get; set; }

        public Friend(string username, string addr, int port)
            : base(username)
        {
            UserName = username;
            Address = addr;
            Port = port;
            Posts = new PostList(username);
        }

        public Friend(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Address", Address);
            info.AddValue("Username", UserName);
            info.AddValue("Port", Port);
            info.AddValue("Posts", Posts);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            Address = (string)info.GetValue("Address", typeof(string));
            UserName = (string)info.GetValue("Username", typeof(string));
            Port = (int)info.GetValue("Port", typeof(int));
            Posts = (PostList)info.GetValue("Posts", typeof(PostList));
        }
    }

    [Serializable()]
    public class Profile : DomainObject
    {
        //-- atributos + propriedades --

        private string userName; //atributo
        public string UserName //propriedade
        {
            get
            {
                return userName;
            }
        }

        public int Age
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public List<string> Interests
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public int Port
        {
            get;
            set;
        }
        //---fim de atributos + propriedades --

        public Profile(string name, string gender, int age, List<string> interests, string addr, int port)
            : base("Profile")
        {
            userName = name;
            Age = age;
            Gender = gender;
            Interests = new List<string>(interests);
            Address = addr;
            Port = port;
        }

        public Profile(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        public void AddInterest(string interest)
        {
            if (!Interests.Contains(interest))
            {
                Interests.Add(interest);
            }
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("userName", userName);
            info.AddValue("Age", Age);
            info.AddValue("Gender", Gender);
            info.AddValue("Interests", Interests);
            info.AddValue("Address", Address);
            info.AddValue("Port", Port);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            userName = (string)info.GetValue("userName", typeof(string));
            Age = (int)info.GetValue("Age", typeof(int));
            Gender = (string)info.GetValue("Gender", typeof(string));
            Interests = (List<string>)info.GetValue("Interests", typeof(List<string>));
            Address = (string)info.GetValue("Address", typeof(string));
            Port = (int)info.GetValue("Port", typeof(int));
        }

        public override string ToString()
        {
            return userName;
        }
    }

    [Serializable()]
    public class ProfileList : DomainObject
    {
        private Dictionary<string, Profile> proList;
        public Dictionary<string, Profile> ProList
        {
            get
            {
                return proList;
            }
        }

        public ProfileList(string id)
            : base(id)
        {
            proList = new Dictionary<string, Profile>();
        }

        public ProfileList(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        public void AddProfile(Profile profile)
        {
            string id = profile.UserName;
            try
            {
                ProList.Add(id, profile);
            }
            catch (ArgumentException)
            {
                //duplicated user
            }
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ProList", ProList);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            proList = (Dictionary<string, Profile>)info.GetValue("ProList", typeof(Dictionary<string, Profile>));
        }

        public void RemoveProfile(Profile p)
        {
            this.ProList.Remove(p.UserName);
        }
    }


    [Serializable()]
    public class FriendRequestList : DomainObject
    {
        private Dictionary<string, FriendRequest> requests;
        public Dictionary<string, FriendRequest> Requests
        {
            get
            {
                return requests;
            }
        }

        public FriendRequestList(string id)
            : base(id)
        {
            requests = new Dictionary<string, FriendRequest>();
        }

        public FriendRequestList(SerializationInfo info, StreamingContext ctxt)
            : base(info, ctxt)
        {
        }

        public void AddFriendRequest(FriendRequest fr)
        {
            string id = fr.ID;
            try
            {
                requests.Add(id, fr);
            }
            catch (ArgumentException)
            {
                //duplicated request
            }
        }

        public void RemoveFriendRequest(FriendRequest fr)
        {
            requests.Remove(fr.ID);
        }

        protected override void Serialize(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Requests", requests);
        }

        protected override void Deserialize(SerializationInfo info, StreamingContext ctxt)
        {
            requests = (Dictionary<string, FriendRequest>)info.GetValue("Requests", typeof(Dictionary<string, FriendRequest>));
        }
    }
}
