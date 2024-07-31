using BulkyRazor.Data;
using BulkyRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazor.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
       
            private readonly ApplicationDbContext _db;

            public Category category { get; set; }
            public DeleteModel(ApplicationDbContext db) => _db = db;
            public void OnGet(int? id)
            {

            if (id != null && id != 0)
            {
                category = _db.Categories.Find(id);


            }

        }
        public IActionResult OnPost()
        {



          
                _db.Categories.Remove(category);
                _db.SaveChanges();
               TempData["success"] = "Category Deleted Succesfully";
            return RedirectToPage("./Index");



        }

    }
}
