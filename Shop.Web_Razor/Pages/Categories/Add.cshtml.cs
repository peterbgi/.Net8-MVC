using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Web_Razor.Data;
using Shop.Web_Razor.Models;

namespace Shop.Web_Razor.Pages.Categories
{
    public class AddModel : PageModel
    {
        private readonly ShopDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public AddModel(ShopDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
