using Soulful_Speech_Core.Entities;
using Soulful_Speech_DAL.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.EF.Repository
{
    public class EFFriendRepository : EFRepository<Friend>, IFriendRepository
    {
        public EFFriendRepository(SSContext context):base(context)
        {
        }
    }
}
