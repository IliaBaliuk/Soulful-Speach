using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_BLL.Services
{
    public class ValueService
    {
        public int NumberOfPostedMessages { get; set; }
        public ValueService()
        {
            NumberOfPostedMessages = 0;
        }
    }
}
