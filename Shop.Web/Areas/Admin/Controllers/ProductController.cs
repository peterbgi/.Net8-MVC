using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models.Models;
using Shop.Models.ViewModels;
using Shop.Web.Data;
using Shop.Web.Models;
using System.Collections.Generic;

namespace Shop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;  
        
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;   
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProp: "Category").ToList();
            
            return View(objProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductViewModel viewModel = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }),
                Product = new Product()
            };
            if (id == null || id == 0)
            {     //create
                return View(viewModel);
            }
            else
            {     //update
                viewModel.Product = _unitOfWork.Product.Get(x => x.Id == id);
                return View(viewModel);
            }

            
        }

        [HttpPost]
        public IActionResult Upsert(ProductViewModel productModel, IFormFile? file, ProductViewModel productViewModel)
        {

            if (ModelState.IsValid)
            {
                string www = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(www, @"images\product");
                    if (!string.IsNullOrEmpty(productViewModel.Product.ImgUrl))
                    {
                        //remove old img
                        var oldImg = Path.Combine(www, productViewModel.Product.ImgUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImg))
                        {
                            System.IO.File.Delete(oldImg);
                        }
                    }
                    using (var sr = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(sr);
                    }

                    productViewModel.Product.ImgUrl = @"\images\product\" + fileName;
                }

                if (productViewModel.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(productViewModel.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(productViewModel.Product);
                }

                
                _unitOfWork.Save();
                TempData["success"] = "Kategoria sikeresen hozzáadva";
                return RedirectToAction("Index");
            }
            else
            {

                productModel.CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                });
                
                return View(productModel);

            }
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
