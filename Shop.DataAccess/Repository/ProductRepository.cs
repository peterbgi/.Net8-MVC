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
    public class ProductRepository : Repository<Product>, IProductRepository 
    {
       private ShopDbContext _db;

        public ProductRepository(ShopDbContext db) : base(db) 
        {
                
            _db = db;   
        }

      

        public void Update(Product obj)
        {
            var formDb = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (formDb != null)
            {
                formDb.Title = obj.Title;

                formDb.ISBN = obj.ISBN; 

                formDb.ListPrice = obj.ListPrice;

                formDb.Price = obj.Price;   

                formDb.Price50 = obj.Price50;   

                formDb.Price100 = obj.Price100;

                formDb.Desc = obj.Desc;

                formDb.Author = obj.Author; 

                formDb.CategoryId = obj.CategoryId; 
                
                if (obj.ImgUrl != null)
                {
                    formDb.ImgUrl = obj.ImgUrl;
                }
            }
            
        }
    }
}
