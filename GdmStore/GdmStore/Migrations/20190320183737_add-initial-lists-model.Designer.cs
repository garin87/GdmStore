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
    [Migration("20190320183737_add-initial-lists-model")]
    partial class addinitiallistsmodel
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
                    b.Property<long>("ParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("ProductTypeId");

                    b.HasKey("ParameterId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Parameters");

                    b.HasData(
                        new { ParameterId = 1L, Name = "Тип трубы", ProductTypeId = 2L },
                        new { ParameterId = 2L, Name = "Тип штока", ProductTypeId = 1L },
                        new { ParameterId = 3L, Name = "Марка стали", ProductTypeId = 1L },
                        new { ParameterId = 4L, Name = "Диаметр", ProductTypeId = 1L }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<string>("Name");

                    b.Property<string>("Number");

                    b.Property<double>("PrimeCostEUR");

                    b.Property<long>("ProductTypeId");

                    b.HasKey("ProductId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");

                    b.HasData(
                        new { ProductId = 1L, Amount = 6.04, Name = "Шток хромированный", Number = "50-E-1", PrimeCostEUR = 34.65, ProductTypeId = 1L },
                        new { ProductId = 2L, Amount = 6.84, Name = "Шток хромированный", Number = "50-V2-1", PrimeCostEUR = 39.87, ProductTypeId = 1L },
                        new { ProductId = 3L, Amount = 7.24, Name = "Труба хонингованная", Number = "80*95-E-4", PrimeCostEUR = 25.85, ProductTypeId = 2L }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.ProductParameter", b =>
                {
                    b.Property<long>("ProductParameterId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ParameterId");

                    b.Property<long>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("ProductParameterId");

                    b.HasIndex("ParameterId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductParameters");

                    b.HasData(
                        new { ProductParameterId = 1L, ParameterId = 2L, ProductId = 2L, Value = "H9" },
                        new { ProductParameterId = 2L, ParameterId = 1L, ProductId = 1L, Value = "Обычный" },
                        new { ProductParameterId = 3L, ParameterId = 3L, ProductId = 1L, Value = "CK45" },
                        new { ProductParameterId = 4L, ParameterId = 4L, ProductId = 1L, Value = "40" },
                        new { ProductParameterId = 5L, ParameterId = 4L, ProductId = 2L, Value = "50" },
                        new { ProductParameterId = 6L, ParameterId = 4L, ProductId = 3L, Value = "80*95" }
                    );
                });

            modelBuilder.Entity("GdmStore.Models.ProductType", b =>
                {
                    b.Property<long>("ProductTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameType");

                    b.HasKey("ProductTypeId");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new { ProductTypeId = 1L, NameType = "Шток хромированный" },
                        new { ProductTypeId = 2L, NameType = "Труба хонингованная" }
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
