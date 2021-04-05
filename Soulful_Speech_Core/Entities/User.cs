using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class User : IdentityUser
    {
        public List<FriendRequest> ToFriendRequests { get; set; }
        public List<FriendRequest> FromFriendRequests { get; set; }
        public List<Friend> Friends { get; set; }
        public List<PersonalMessage> ToPersonalMessages { get; set; }
        public List<PersonalMessage> FromPersonalMessages { get; set; }
        public List<UserRoom> UserRooms { get; set; }
        public List<Message> Messages { get; set; }

        public User()
        {
            ToFriendRequests = new List<FriendRequest>();
            FromFriendRequests = new List<FriendRequest>();
            Friends = new List<Friend>();
            ToPersonalMessages = new List<PersonalMessage>();
            FromPersonalMessages = new List<PersonalMessage>();
            UserRooms = new List<UserRoom>();
            Messages = new List<Message>();
        }

    }
}
