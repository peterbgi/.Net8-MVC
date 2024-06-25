using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Web_Razor.Data;
using Shop.Web_Razor.Models;

namespace Shop.Web_Razor.Pages.Categories
{

    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ShopDbContext _db;


        public Category? Category { get; set; }

        public DeleteModel(ShopDbContext db)
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
                Category? obj = _db.Categories.Find(Category.Id);
                if (obj == null)
                {
                    NotFound();
                }

                _db.Categories.Remove(obj);
                _db.SaveChanges();
                return RedirectToPage("Index");

        }
    }
}
