using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class AppdbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SaleTax> SaleTaxes { get; set; }
        public DbSet<SaleItemTax> SaleItemTaxes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCGames;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Concept)
            .WithOne(i => i.Product)
            .HasForeignKey<Concept>(b => b.ConceptId);

            modelBuilder.Entity<Service>()
           .HasOne(p => p.Concept)
           .WithOne(i => i.Service)
           .HasForeignKey<Concept>(b => b.ConceptId);
        }
    }
}
