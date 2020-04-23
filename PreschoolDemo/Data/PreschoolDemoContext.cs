using Microsoft.EntityFrameworkCore;
using PreschoolDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreschoolDemo.Data
{
    public class PreschoolDemoContext : DbContext
    {
        public PreschoolDemoContext (DbContextOptions<PreschoolDemoContext> options)
            : base(options)
        {

        }

        public DbSet<Child> Children { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Diaper> Diapers { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Nap> Naps { get; set; }

    }
}
