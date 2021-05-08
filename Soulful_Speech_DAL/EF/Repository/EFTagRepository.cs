using Soulful_Speech_Core.Entities;
using Soulful_Speech_DAL.Interfaces.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.EF.Repository
{
    public class EFTagRepository : EFRepository<Tag>, ITagRepository
    {
        public EFTagRepository(SSContext context):base(context)
        {}

        public override void Insert(Tag entity)
        {
            if (GetById(entity.Name) == null)
            {
                context.Set<Tag>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
