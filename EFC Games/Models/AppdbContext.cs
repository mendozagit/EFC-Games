using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Games.Models
{
    public class AppdbContext : DbContext
    {


        public static readonly ILoggerFactory MyLoggerFactory =
           LoggerFactory.Create(
                builder =>
                {
                    builder.AddConsole();
                }
           );

        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
        public DbSet<SaleTax> SaleTaxes { get; set; }
        public DbSet<SaleItemTax> SaleItemTaxes { get; set; }

        public DbSet<Entity> Entities { get; set; }
        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }
        public DbSet<MoralPerson> MoralPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EFCGames;Trusted_Connection=True;");
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Concept>()
            .HasOne(c => c.Product)
            .WithOne(p => p.Concept)
            .HasForeignKey<Product>(p => p.ProductId);


            modelBuilder.Entity<Concept>()
           .HasOne(c => c.Service)
           .WithOne(s => s.Concept)
           .HasForeignKey<Service>(s => s.ServiceId);


            modelBuilder.Entity<Entity>()
                .HasOne(e => e.PhysicalPerson)
                .WithOne(pp => pp.Entity)
                .HasForeignKey<PhysicalPerson>(pp => pp.PhysicalPersonId);


            modelBuilder.Entity<Entity>()
                .HasOne(mp => mp.MoralPerson)
                .WithOne(e => e.Entity)
                .HasForeignKey<MoralPerson>(x => x.MoralPersonId);

            //modelBuilder.Entity<SaleItem>()
            //    .HasOne(x=> x.Concept)
            //    .WithMany(x=> x.SaleItem)
        }
    }
}
