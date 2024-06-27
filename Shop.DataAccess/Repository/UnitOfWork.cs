using Shop.DataAccess.Repository.IRepository;
using Shop.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopDbContext _db;

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public UnitOfWork(ShopDbContext db) 
        {

            _db = db;

            Category = new CategoryRepository(_db);

            Product = new ProductRepository(_db);   
        }
          

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
