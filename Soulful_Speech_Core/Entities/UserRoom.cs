using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class UserRoom
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string RoomId { get; set; }
        public Room Room { get; set; }
        public string UserRoomRoleId { get; set; }
        public UserRoomRole UserRoomRole { get; set; }
    }
}
