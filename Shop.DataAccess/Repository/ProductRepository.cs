using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Web.Data;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
    public class ProduczRepository : Repository<Product>, IProductRepository 
    {
       private ShopDbContext _db;

        public ProduczRepository(ShopDbContext db) : base(db) 
        {
                
            _db = db;   
        }

      

        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
