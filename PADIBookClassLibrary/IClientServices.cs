using System.Collections.Generic;

namespace PADIBook.Utils
{
    public interface IClientServices
    {
        void AddPost(Post p);
        List<Post> GetPostList();

        void CreateProfile(string name, string gender, int age, List<string> interests, string addr, int port);
        Profile GetProfile(string username);
        void UpdateProfile(Profile p);

        void SendFriendRequest(FriendRequest f);
        void AcceptFriendRequest(FriendRequest f);
        void RejectFriendRequest(FriendRequest f);

        FriendRequestList GetSentFriendRequests();
        FriendRequestList GetReceivedFriendRequests();

        Friends GetFriendList();

        string LookupByUserName(string username);
        List<string> LookupByInterest(string interest);
        List<string> LookupByGenderAndAge(string gender, int lowerBound, int upperBound);
    }
}