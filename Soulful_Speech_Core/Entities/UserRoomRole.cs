using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class UserRoomRole
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<UserRoom> UserRooms { get; set; }

        public UserRoomRole()
        {
            UserRooms = new List<UserRoom>();
        }
    }
}
