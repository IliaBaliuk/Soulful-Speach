using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class TagInRoom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string TagId { get; set; }
        public Tag Tag { get; set; }
        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
