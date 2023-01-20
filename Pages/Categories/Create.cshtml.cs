using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodeaAndreeaIuliana_Medii.Data;
using TodeaAndreeaIuliana_Medii.Models;

namespace TodeaAndreeaIuliana_Medii.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext _context;

        public CreateModel(TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
