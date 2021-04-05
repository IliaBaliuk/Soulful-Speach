using Soulful_Speech_DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_BLL.Services
{
    public class TagService
    {
        UnitOfWork context;

        public TagService(UnitOfWork context)
        {
            this.context = context;
        }

        public bool CreateTag()
        {
            try
            {

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
