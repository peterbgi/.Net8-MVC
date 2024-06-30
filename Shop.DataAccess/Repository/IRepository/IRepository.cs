using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(string? includeProp = null);
        T Get(Expression<Func<T, bool>> fiter, string? includeProp = null);

        void Add(T enitiy);  
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
