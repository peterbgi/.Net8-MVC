using Microsoft.AspNetCore.Mvc;
using Shop.Web.Data;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShopDbContext _db;

        public CategoryController(ShopDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category obj)
        {
          
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
           
        }
    }
}
