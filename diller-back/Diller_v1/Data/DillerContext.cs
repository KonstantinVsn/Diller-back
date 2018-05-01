using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Diller.Models;

namespace Diller.Data
{
    public class DillerContext : DbContext
    {
        public DillerContext(DbContextOptions<DillerContext> options)
            : base(options)
        {
        }

        public DbSet<AutoBrand> AutoBrand { get; set; }

        public DbSet<Client> Client { get; set; }

        public DbSet<Manager> Manager { get; set; }

        public DbSet<AutoCategory> AutoCategory { get; set; }

        public DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutoBrand>().ToTable("AutoBrand");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Manager>().ToTable("Manager");
            modelBuilder.Entity<AutoCategory>().ToTable("AutoCategory");
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
