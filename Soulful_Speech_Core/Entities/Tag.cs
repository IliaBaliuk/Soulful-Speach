using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    class Tag
    {
        [Key]
        public string Name { get; set; }

        public List<TagInRoom> TagInRooms { get; set; }

        public Tag()
        {
            TagInRooms = new List<TagInRoom>();
        }
    }
}
