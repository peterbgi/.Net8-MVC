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

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFormDb = _db.Categories.Find(id); 

            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);

        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFormDb = _db.Categories.Find(id);

            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                NotFound();
            }

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
