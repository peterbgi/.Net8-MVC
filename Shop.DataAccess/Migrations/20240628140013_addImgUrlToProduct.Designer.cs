﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Web.Data;

#nullable disable

namespace Shop.DataAccess.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    [Migration("20240628140013_addImgUrlToProduct")]
    partial class addImgUrlToProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shop.Models.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListPrice")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Price100")
                        .HasColumnType("int");

                    b.Property<int>("Price50")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Billy Spark",
                            CategoryId = 1,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SWD9999001",
                            ImgUrl = "",
                            ListPrice = 9900,
                            Price = 9000,
                            Price100 = 8000,
                            Price50 = 8500,
                            Title = "Az idő szerencséje"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Nancy Hoover",
                            CategoryId = 1,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "CAW777777701",
                            ImgUrl = "",
                            ListPrice = 4000,
                            Price = 3000,
                            Price100 = 2000,
                            Price50 = 2500,
                            Title = "Sötét égbolt"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Julian Button",
                            CategoryId = 2,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "RITO5555501",
                            ImgUrl = "",
                            ListPrice = 5500,
                            Price = 5000,
                            Price100 = 3500,
                            Price50 = 4000,
                            Title = "Tűnj el a naplementében"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Abby Muscles",
                            CategoryId = 2,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "WS3333333301",
                            ImgUrl = "",
                            ListPrice = 7000,
                            Price = 6500,
                            Price100 = 5500,
                            Price50 = 6000,
                            Title = "Vattacukor"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Ron Parker",
                            CategoryId = 3,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SOTJ1111111101",
                            ImgUrl = "",
                            ListPrice = 3000,
                            Price = 2700,
                            Price100 = 2000,
                            Price50 = 2500,
                            Title = "Szikla az óceánban"
                        },
                        new
                        {
                            Id = 6,
                            Author = "Laura Phantom",
                            CategoryId = 3,
                            Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "FOT000000001",
                            ImgUrl = "",
                            ListPrice = 2500,
                            Price = 2300,
                            Price100 = 2000,
                            Price50 = 2200,
                            Title = "Levelek és csodák"
                        });
                });

            modelBuilder.Entity("Shop.Web.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Akció"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Történelmi"
                        });
                });

            modelBuilder.Entity("Shop.Models.Models.Product", b =>
                {
                    b.HasOne("Shop.Web.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
