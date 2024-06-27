using Microsoft.EntityFrameworkCore;
using Shop.Models.Models;
using Shop.Web.Models;
namespace Shop.Web.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) :base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Akció", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Sci-Fi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Történelmi", DisplayOrder = 3 }
                );


            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "Az idő szerencséje",
                   Author = "Billy Spark",
                   Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "SWD9999001",
                   ListPrice = 9900,
                   Price = 9000,
                   Price50 = 8500,
                   Price100 = 8000
               },
                new Product
                {
                    Id = 2,
                    Title = "Sötét égbolt",
                    Author = "Nancy Hoover",
                    Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 4000,
                    Price = 3000,
                    Price50 = 2500,
                    Price100 = 2000
                },
                new Product
                {
                    Id = 3,
                    Title = "Tűnj el a naplementében",
                    Author = "Julian Button",
                    Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 5500,
                    Price = 5000,
                    Price50 = 4000,
                    Price100 = 3500
                },
                new Product
                {
                    Id = 4,
                    Title = "Vattacukor",
                    Author = "Abby Muscles",
                    Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 7000,
                    Price = 6500,
                    Price50 = 6000,
                    Price100 = 5500
                },
                new Product
                {
                    Id = 5,
                    Title = "Szikla az óceánban",
                    Author = "Ron Parker",
                    Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 3000,
                    Price = 2700,
                    Price50 = 2500,
                    Price100 = 2000
                },
                new Product
                {
                    Id = 6,
                    Title = "Levelek és csodák",
                    Author = "Laura Phantom",
                    Desc = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 2500,
                    Price = 2300,
                    Price50 = 2200,
                    Price100 = 2000
                }

                );
        }
    }
}
