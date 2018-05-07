using Diller.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diller.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<AutoBrand> AutoBrands { get; set; }
        public DbSet<AutoCategory> AutoCategories { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Car> Cars { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Client>().ToTable("Client");
        //    modelBuilder.Entity<Manager>().ToTable("Manager");
        //    modelBuilder.Entity<AutoBrand>().ToTable("AutoBrand");
        //    modelBuilder.Entity<AutoCategory>().ToTable("AutoCategory");
        //    modelBuilder.Entity<Order>().ToTable("Order");
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
