﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Domain;

namespace Shop.Domain.Migrations
{
    [DbContext(typeof(AeDbContext))]
    partial class AeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shop.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InsertedAt")
                        .HasColumnName("InsertedAt")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentId")
                        .HasColumnName("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedAt")
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, InsertedAt = 1540884043, Name = "Category001", ParentId = 1, UpdatedAt = 1540884043 },
                        new { Id = 2, InsertedAt = 1540884043, Name = "Category002", ParentId = 1, UpdatedAt = 1540884043 },
                        new { Id = 3, InsertedAt = 1540884043, Name = "Category003", ParentId = 2, UpdatedAt = 1540884043 },
                        new { Id = 4, InsertedAt = 1540884043, Name = "Category004", ParentId = 2, UpdatedAt = 1540884043 },
                        new { Id = 5, InsertedAt = 1540884043, Name = "Category005", ParentId = 1, UpdatedAt = 1540884043 }
                    );
                });

            modelBuilder.Entity("Shop.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("DiscountPrice")
                        .IsRequired()
                        .HasColumnName("DiscountPrice")
                        .HasColumnType("int");

                    b.Property<int>("InsertedAt")
                        .HasColumnName("InsertedAt")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RegularPrice")
                        .HasColumnName("RegularPrice")
                        .HasColumnType("int");

                    b.Property<string>("Sku")
                        .IsRequired()
                        .HasColumnName("Sku")
                        .HasColumnType("varchar(16)");

                    b.Property<int>("UpdatedAt")
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Description = "DescriptionDescriptionDescriptionDescription", DiscountPrice = 100000, InsertedAt = 1540884043, Name = "Product001", Quantity = 10, RegularPrice = 100000, Sku = "PD001", UpdatedAt = 1540884043 },
                        new { Id = 2, Description = "DescriptionDescriptionDescriptionDescription", DiscountPrice = 10000, InsertedAt = 1540884043, Name = "Product002", Quantity = 10, RegularPrice = 10000, Sku = "PD002", UpdatedAt = 1540884043 },
                        new { Id = 3, Description = "DescriptionDescriptionDescriptionDescription", DiscountPrice = 1000, InsertedAt = 1540884043, Name = "Product003", Quantity = 10, RegularPrice = 1000, Sku = "PD003", UpdatedAt = 1540884043 },
                        new { Id = 4, Description = "DescriptionDescriptionDescriptionDescription", DiscountPrice = 100, InsertedAt = 1540884043, Name = "Product004", Quantity = 10, RegularPrice = 100, Sku = "PD004", UpdatedAt = 1540884043 }
                    );
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnName("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("InsertedAt")
                        .HasColumnName("InsertedAt")
                        .HasColumnType("int");

                    b.Property<int>("UpdatedAt")
                        .HasColumnName("UpdatedAt")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");

                    b.HasData(
                        new { ProductId = 1, CategoryId = 1, InsertedAt = 1540884043, UpdatedAt = 1540884043 },
                        new { ProductId = 2, CategoryId = 1, InsertedAt = 1540884043, UpdatedAt = 1540884043 },
                        new { ProductId = 3, CategoryId = 2, InsertedAt = 1540884043, UpdatedAt = 1540884043 },
                        new { ProductId = 4, CategoryId = 4, InsertedAt = 1540884043, UpdatedAt = 1540884043 }
                    );
                });

            modelBuilder.Entity("Shop.Domain.Entities.ProductCategory", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shop.Domain.Entities.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}