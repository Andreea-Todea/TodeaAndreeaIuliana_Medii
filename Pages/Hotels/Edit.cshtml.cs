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
    public class EditModel : HotelCategoriesPageModel
    {
        private readonly TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext _context;

        public EditModel(TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext context)
        {
            _context = context;
        }


        [BindProperty]
        public Hotel Hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel

            .Include(b => b.Country)
            .Include(b => b.HotelCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Hotel);
            Hotel = hotel;
            ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "ID", "CountryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelToUpdate = await _context.Hotel
            .Include(i => i.Country)
            .Include(i => i.HotelCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (hotelToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Hotel>(
           hotelToUpdate,
            "Hotel",
            i => i.Name, i => i.Price,
            i => i.RoomNumbers, i => i.CountryID, i => i.Location))
            {
                UpdateHotelCategories(_context, selectedCategories, hotelToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateHotelCategories(_context, selectedCategories, hotelToUpdate);
            PopulateAssignedCategoryData(_context, hotelToUpdate);
            return Page();
        }
        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.ID == id);
        }
    }
}





