using IsllihaiProjectDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IsllihaiProjectDAL.Contexts
{
    public class islahiniDbContext : DbContext
    {
        public islahiniDbContext (DbContextOptions<islahiniDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER02;Database=IsllihaiProjectDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Technican> Technican { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Review> Reviews { get; set; }

    }
}
