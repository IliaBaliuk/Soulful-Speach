using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Entities
{
    public class Friend
    {
        public string Id { get; set; }
        public string UserMainId { get; set; }
        public string UserSubId { get; set; }
        public User UserMain { get; set; }
        public User UserSub { get; set; }
        public bool IsIgnore { get; set; }
        public bool IsSelect { get; set; }
    }
}
