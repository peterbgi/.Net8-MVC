using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repository.IRepository;
using Shop.Web.Data;


namespace Shop.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopDbContext _db;

        internal DbSet<T> dbSet;

        public Repository(ShopDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();  
        }

        public void Add(T enitiy)
        {
           dbSet.Add(enitiy);
        }

        public T Get(Expression<Func<T, bool>> fiter)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(fiter);

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);  
        }
    }
}
