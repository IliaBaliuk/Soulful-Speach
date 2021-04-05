using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class PersonalMessage
    {
        public string Id { get; set; }
        public string FromId { get; set; }
        public User From { get; set; }
        public string ToId { get; set; }
        public User To { get; set; }
        public DateTime DateTime { get; set; }
        public string MessageText { get; set; }
    }
}
