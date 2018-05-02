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
        public DbSet<AutoBrand> AutoBrand { get; set; }
        public DbSet<AutoCategory> AutoCategory { get; set; }
        public DbSet<Order> Order { get; set; }

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
