using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatok.Data
{
    public class AllatokContext : DbContext
    {
        public DbSet<Adatok.Models.Animal> Animal { get; set; } = default!;

        public DbSet<Adatok.Models.Gazda>? Gazda { get; set; }

        public AllatokContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=API.Data0312;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
