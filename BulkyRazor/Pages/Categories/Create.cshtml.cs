using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public   Category?  category { get; set; }
        public CreateModel(ApplicationDbContext db) => _db = db;
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }
            if (category == null) {
                return Page();
            }

            
            _db.Categories.Add(category);
            TempData["success"] = "Category Created Successfully";
            await _db.SaveChangesAsync();

            
            return RedirectToPage("./Index");
        }
    }
}
