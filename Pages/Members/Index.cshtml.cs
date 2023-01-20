using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TodeaAndreeaIuliana_Medii.Data;
using TodeaAndreeaIuliana_Medii.Models;

namespace TodeaAndreeaIuliana_Medii.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext _context;

        public IndexModel(TodeaAndreeaIuliana_Medii.Data.TodeaAndreeaIuliana_MediiContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Member != null)
            {
                Member = await _context.Member.ToListAsync();
            }
        }
    }
}
