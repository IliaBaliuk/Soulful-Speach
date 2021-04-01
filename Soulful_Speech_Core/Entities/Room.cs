using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    class Room
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }

        public List<TagInRoom> TagsInRoom { get; set; }
        public List<UserRoom> UserRooms { get; set; }
        public List<Message> Messages { get; set; }

        public Room()
        {
            TagsInRoom = new List<TagInRoom>();
            UserRooms = new List<UserRoom>();
            Messages = new List<Message>();
        }
    }
}
