using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category>  categories{ get; set; }
        public IndexModel(ApplicationDbContext db )
        {
            _db = db;
        }
        public void OnGet()
        {
         categories=   _db.Categories.ToList();
        }
    }
}
