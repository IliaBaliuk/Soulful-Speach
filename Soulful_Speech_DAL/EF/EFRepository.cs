using Microsoft.EntityFrameworkCore;
using Soulful_Speech_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_DAL.EF
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        protected readonly SSContext context;

        public EFRepository(SSContext context)
        {
            this.context = context;
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public T GetById(params object[] id)
        {
            return context.Set<T>().Find(id);
        }

        public IList<T> GetList(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
            {
                return context.Set<T>().ToList();
            }
            return context.Set<T>().Where(expression).ToList();
        }

        public virtual void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            //context.Entry<T>.Attach(T);
            context.Entry<T>(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IList<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = context.Set<T>().Include(includes[0]);
            foreach (var include in includes.Skip(1))
            {
                query = query.Include(include);
            }
            return query.ToList();
        }


    }
}
