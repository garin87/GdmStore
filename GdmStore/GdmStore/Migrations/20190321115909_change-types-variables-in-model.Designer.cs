﻿// <auto-generated />
using GdmStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GdmStore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190321115909_change-types-variables-in-model")]
    partial class changetypesvariablesinmodel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GdmStore.Models.Parameter", b =>
                {
                    b.Property<int>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("ProductTypeId");

                    b.HasKey("ParameterId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Parameters");

                    b.HasData(
                        new { ParameterId = 1, Name = "Тип трубы", ProductTypeId = 2 },
                        new { ParameterId = 2, Name = "Тип штока", ProductTypeId = 1 },
                        new { ParameterId = 3, Name = "Марка стали", ProductTypeId = 1 },
                        new { ParameterId = 4, Name = "Диаметр", ProductTypeId = 1 }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<double>("PrimeCostEUR");

                    b.Property<int>("ProductTypeId");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new { ProductId = 1, Amount = 6.04, Name = "Шток хромированный", Number = "50-E-1", PrimeCostEUR = 34.65, ProductTypeId = 1 },
                        new { ProductId = 2, Amount = 6.84, Name = "Шток хромированный", Number = "50-V2-1", PrimeCostEUR = 39.87, ProductTypeId = 1 },
                        new { ProductId = 3, Amount = 7.24, Name = "Труба хонингованная", Number = "80*95-E-4", PrimeCostEUR = 25.85, ProductTypeId = 2 }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.ProductParameter", b =>
                {
                    b.Property<int>("ProductParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParameterId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("ProductParameterId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductParameters");

                    b.HasData(
                        new { ProductParameterId = 1, ParameterId = 2, ProductId = 2, Value = "H9" },
                        new { ProductParameterId = 2, ParameterId = 1, ProductId = 1, Value = "Обычный" },
                        new { ProductParameterId = 3, ParameterId = 3, ProductId = 1, Value = "CK45" },
                        new { ProductParameterId = 4, ParameterId = 4, ProductId = 1, Value = "40" },
                        new { ProductParameterId = 5, ParameterId = 4, ProductId = 2, Value = "50" },
                        new { ProductParameterId = 6, ParameterId = 4, ProductId = 3, Value = "80*95" }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.ProductType", b =>
                {
                    b.Property<int>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameType");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new { ProductTypeId = 1, NameType = "Шток хромированный" },
                        new { ProductTypeId = 2, NameType = "Труба хонингованная" }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.Parameter", b =>
                {
                    b.HasOne("GdmStore.Models.ProductType", "ProductType")
                        .WithMany("Parameters")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GdmStore.Models.Product", b =>
                {
                    b.HasOne("GdmStore.Models.ProductType", "ProductType")
                        .WithMany("Products")
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GdmStore.Models.ProductParameter", b =>
                {
                    b.HasOne("GdmStore.Models.Parameter", "Parameter")
                        .WithMany("ProductParameters")
                        .HasForeignKey("ParameterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GdmStore.Models.Product", "Product")
                        .WithMany("ProductParameters")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
