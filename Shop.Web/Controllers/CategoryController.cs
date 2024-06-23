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
    }
}
