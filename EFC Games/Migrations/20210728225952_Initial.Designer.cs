﻿// <auto-generated />
using EFC_Games.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFC_Games.Migrations
{
    [DbContext(typeof(AppdbContext))]
    [Migration("20210728225952_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFC_Games.Models.Concept", b =>
                {
                    b.Property<int>("ConceptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ConceptId");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("EFC_Games.Models.Entity", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("EntityId");

                    b.ToTable("Entities");
                });

            modelBuilder.Entity("EFC_Games.Models.MoralPerson", b =>
                {
                    b.Property<int>("MoralPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MoralPersonId");

                    b.ToTable("MoralPersons");
                });

            modelBuilder.Entity("EFC_Games.Models.PhysicalPerson", b =>
                {
                    b.Property<int>("PhysicalPersonId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhysicalPersonId");

                    b.ToTable("PhysicalPersons");
                });

            modelBuilder.Entity("EFC_Games.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EFC_Games.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleId");

                    b.HasIndex("EntityId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("EFC_Games.Models.SaleItem", b =>
                {
                    b.Property<int>("SaleItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConceptId")
                        .HasColumnType("int");

                    b.Property<string>("Desription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleItemId");

                    b.HasIndex("ConceptId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItems");
                });

            modelBuilder.Entity("EFC_Games.Models.SaleItemTax", b =>
                {
                    b.Property<int>("SaleItemTaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Base")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleItemId")
                        .HasColumnType("int");

                    b.Property<string>("TACode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaleItemTaxId");

                    b.HasIndex("SaleItemId");

                    b.ToTable("SaleItemTaxes");
                });

            modelBuilder.Entity("EFC_Games.Models.SaleTax", b =>
                {
                    b.Property<int>("SaleTaxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Base")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<string>("TACode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SaleTaxId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleTaxes");
                });

            modelBuilder.Entity("EFC_Games.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("EFC_Games.Models.MoralPerson", b =>
                {
                    b.HasOne("EFC_Games.Models.Entity", "Entity")
                        .WithOne("MoralPerson")
                        .HasForeignKey("EFC_Games.Models.MoralPerson", "MoralPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.PhysicalPerson", b =>
                {
                    b.HasOne("EFC_Games.Models.Entity", "Entity")
                        .WithOne("PhysicalPerson")
                        .HasForeignKey("EFC_Games.Models.PhysicalPerson", "PhysicalPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.Product", b =>
                {
                    b.HasOne("EFC_Games.Models.Concept", "Concept")
                        .WithOne("Product")
                        .HasForeignKey("EFC_Games.Models.Product", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.Sale", b =>
                {
                    b.HasOne("EFC_Games.Models.Entity", "Entity")
                        .WithMany()
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.SaleItem", b =>
                {
                    b.HasOne("EFC_Games.Models.Concept", "Concept")
                        .WithMany("SaleItems")
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFC_Games.Models.Sale", "Sale")
                        .WithMany("SaleItems")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.SaleItemTax", b =>
                {
                    b.HasOne("EFC_Games.Models.SaleItem", "SaleItem")
                        .WithMany("SaleItemTaxes")
                        .HasForeignKey("SaleItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.SaleTax", b =>
                {
                    b.HasOne("EFC_Games.Models.Sale", "Sale")
                        .WithMany("SaleTaxes")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFC_Games.Models.Service", b =>
                {
                    b.HasOne("EFC_Games.Models.Concept", "Concept")
                        .WithOne("Service")
                        .HasForeignKey("EFC_Games.Models.Service", "ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}