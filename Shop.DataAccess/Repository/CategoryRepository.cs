using Shop.DataAccess.Repository.IRepository;
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
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
       private ShopDbContext _db;

        public CategoryRepository(ShopDbContext db) : base(db) 
        {
                
            _db = db;   
        }

      

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
