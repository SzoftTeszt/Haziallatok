using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Adatok.Models;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        public DbSet<Adatok.Models.Animal> Animal { get; set; } = default!;

        public DbSet<Adatok.Models.Gazda>? Gazda { get; set; }
    }
}
