using AnnonsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnonsWebAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.Advertisements.Any())
            {
                var adsToAdd = new List<Advertisement>
        {
              new Advertisement
            {
                Title = "Super Richard",
                Description = "Book",
                Price = 40.99m,
                DatePosted = new DateTime(2022, 1, 9),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Awesome Product",
                Description = "Electronics",
                Price = 99.99m,
                DatePosted = new DateTime(2022, 2, 15),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Fancy Watch",
                Description = "Accessories",
                Price = 299.99m,
                DatePosted = new DateTime(2022, 3, 20),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Vintage Camera",
                Description = "Photography",
                Price = 199.99m,
                DatePosted = new DateTime(2022, 4, 5),
                IsActive = true
            },
                 new Advertisement
            {
                Title = "Gaming Laptop",
                Description = "High-performance gaming laptop with RGB keyboard",
                Price = 1499.99m,
                DatePosted = new DateTime(2022, 5, 10),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Designer Handbag",
                Description = "Luxurious designer handbag made from genuine leather",
                Price = 899.99m,
                DatePosted = new DateTime(2022, 6, 18),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Smart Home Kit",
                Description = "Complete smart home kit with smart bulbs, plugs, and hub",
                Price = 299.99m,
                DatePosted = new DateTime(2022, 7, 25),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Fitness Tracker",
                Description = "Waterproof fitness tracker with heart rate monitor and GPS",
                Price = 79.99m,
                DatePosted = new DateTime(2022, 8, 30),
                IsActive = true
            },
              new Advertisement
            {
                Title = "Bluetooth Earbuds",
                Description = "Wireless earbuds with noise cancellation and long battery life",
                Price = 59.99m,
                DatePosted = new DateTime(2022, 9, 5),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Coffee Machine",
                Description = "Automatic coffee machine with built-in grinder and milk frother",
                Price = 199.99m,
                DatePosted = new DateTime(2022, 10, 12),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Digital Drawing Tablet",
                Description = "Graphic drawing tablet with pressure-sensitive pen and customizable keys",
                Price = 299.99m,
                DatePosted = new DateTime(2022, 11, 20),
                IsActive = true
            },
            new Advertisement
            {
                Title = "Hiking Backpack",
                Description = "Durable hiking backpack with multiple compartments and hydration system",
                Price = 79.99m,
                DatePosted = new DateTime(2022, 12, 8),
                IsActive = true
            },
        };

                _dbContext.Advertisements.AddRange(adsToAdd);
            }
        }
    }
}
