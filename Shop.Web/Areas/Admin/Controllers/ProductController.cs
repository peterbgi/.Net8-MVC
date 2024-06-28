using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Web.Data;
using Shop.Web.Models;
using System.Collections.Generic;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            
            return View(objProductList);
        }

        public IActionResult Add()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
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
            Product? productFormDb = _unitOfWork.Product.Get(x => x.Id == id);

            //Product? categoryFormDb2 = _db.Categories.Where(x => x.Id == id).FirstOrDefault(); 

            if (productFormDb == null)
            {
                return NotFound();
            }

            return View(productFormDb);

        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
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
            Product? productFormDb = _unitOfWork.Product.Get(x => x.Id == id);

            if (productFormDb == null)
            {
                return NotFound();
            }

            return View(productFormDb);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(x => x.Id == id);
            if (obj == null)
            {
                NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kategoria sikeresen törölve";
            return RedirectToAction("Index");

        }


    }
}
