using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Data
{
    public class StoreContext :DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) :
base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<DistributedLaptop> DistributedLaptops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Laptop>().ToTable("Laptop");
            modelBuilder.Entity<Distributor>().ToTable("Distributor");
            modelBuilder.Entity<DistributedLaptop>().ToTable("DistributedLaptop");
            modelBuilder.Entity<DistributedLaptop>()
            .HasKey(c => new { c.LaptopID, c.DistributorID });//configureaza cheia primara compusa
        }
    }
}
