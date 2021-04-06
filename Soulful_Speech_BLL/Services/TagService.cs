using Soulful_Speech_DAL.EF;
using Soulful_Speech_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_BLL.Services
{
    public class TagService
    {
        IUnitOfWork context;

        public TagService(IUnitOfWork context)
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
