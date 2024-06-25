using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Web_Razor.Data;
using Shop.Web_Razor.Models;

namespace Shop.Web_Razor.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ShopDbContext _db;

        
        public Category? Category { get; set; }

        public EditModel(ShopDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Kategoria sikeresen hozzáadva";
                return RedirectToPage("Index");
            }

            return  Page();
           
        }
    }
}
