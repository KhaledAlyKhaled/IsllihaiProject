using IsllihaiProjectDAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Contexts
{
    public class IslahiniDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public IslahiniDbContext (DbContextOptions<IslahiniDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        
        public DbSet<Technican> Technican { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
