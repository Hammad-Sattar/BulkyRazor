using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BulkyRazor.Pages.Categories
{
   
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category? category { get; set; }
        public EditModel(ApplicationDbContext db) => _db = db;
        public void OnGet(int? id)
        {
            if (id != null && id != 0) { 
            
            category = _db.Categories.Find(id);
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Succesfully";
                return RedirectToPage("./Index");
            }


            return Page();
        }

    }
}
