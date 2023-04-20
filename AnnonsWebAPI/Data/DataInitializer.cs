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
            if (!_dbContext.Advertisements
        .Any(e => e.Title == "Super Richard"))
            {
                _dbContext.Add(new Advertisement
                {
                    Title = "Super Richard",
                    Description = "Book",
                    Price = 40,
                    DatePosted = new DateTime(2022, 1, 9),
                    IsActive = true,
                });
            }
        }

    }

}
