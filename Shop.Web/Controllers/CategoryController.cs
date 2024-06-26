using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Repository.IRepository;
using Shop.Web.Data;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoyRepository;

        public CategoryController(ICategoryRepository db)
        {
            _categoyRepository = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoyRepository.GetAll().ToList();
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
                _categoyRepository.Add(obj);
                _categoyRepository.Save();
                TempData["success"] = "Kategoria sikeresen hozzáadva";
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
            Category? categoryFormDb = _categoyRepository.Get(x => x.Id == id); 
            
            //Category? categoryFormDb2 = _db.Categories.Where(x => x.Id == id).FirstOrDefault(); 

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
                _categoyRepository.Update(obj);
                _categoyRepository.Save();
                TempData["success"] = "Kategoria sikeresen frissítve";
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
            Category? categoryFormDb = _categoyRepository.Get(x => x.Id == id);

            if (categoryFormDb == null)
            {
                return NotFound();
            }

            return View(categoryFormDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _categoyRepository.Get(x => x.Id == id);
            if (obj == null)
            {
                NotFound();
            }

            _categoyRepository.Remove(obj);
            _categoyRepository.Save();
            TempData["success"] = "Kategoria sikeresen törölve";
            return RedirectToAction("Index");

        }


    }
}
