using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodeaAndreeaIuliana_Medii.Data;
using TodeaAndreeaIuliana_Medii.Models;

namespace TodeaAndreeaIuliana_Medii.Pages.Hotels
{
    public class CreateModel : HotelCategoriesPageModel
    {
        private readonly TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext _context;

        public CreateModel(TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "CountryName");
            var hotel = new Hotel();
            hotel.HotelCategories = new List<HotelCategory>();
            PopulateAssignedCategoryData(_context, hotel);
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newHotel = new Hotel();
            if (selectedCategories != null)
            {
                newHotel.HotelCategories = new List<HotelCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new HotelCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newHotel.HotelCategories.Add(catToAdd);
                }
            }
            Hotel.HotelCategories = newHotel.HotelCategories;
            _context.Hotel.Add(Hotel);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newHotel);
            return Page();
        }

    }
}
