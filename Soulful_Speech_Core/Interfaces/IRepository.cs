using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Soulful_Speech_Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(params object[] id);
        IList<T> GetList(Expression<Func<T, bool>> expression = null);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IList<T> Include(params Expression<Func<T, object>>[] includes);
    }
}
