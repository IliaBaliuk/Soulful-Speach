using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class FriendRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string FromId { get; set; }
        public User From { get; set; }
        public string ToId { get; set; }
        public User To { get; set; }
        public bool isDecline { get; set; }
        public DateTime DateTime { get; set; }
    }
}
