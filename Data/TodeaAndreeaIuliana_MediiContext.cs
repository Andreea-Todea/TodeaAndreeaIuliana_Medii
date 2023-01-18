using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodeaAndreeaIuliana_Medii.Models;

namespace TodeaAndreeaIuliana_Medii.Data
{
    public class TodeaAndreeaIuliana_MediiContext : DbContext
    {
        public TodeaAndreeaIuliana_MediiContext (DbContextOptions<TodeaAndreeaIuliana_MediiContext> options)
            : base(options)
        {
        }

        public DbSet<TodeaAndreeaIuliana_Medii.Models.Hotel> Hotel { get; set; } = default!;

        public DbSet<TodeaAndreeaIuliana_Medii.Models.Country> Country { get; set; }
    }
}
