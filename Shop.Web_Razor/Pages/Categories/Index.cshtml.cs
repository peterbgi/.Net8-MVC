using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Web_Razor.Data;
using Shop.Web_Razor.Models;

namespace Shop.Web_Razor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ShopDbContext _db;

        public List<Category> CategoryList { get; set; }

        public IndexModel(ShopDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
