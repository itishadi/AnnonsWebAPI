using AnnonsWebAPI.Data;
using AnnonsWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnonsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AdvertisementController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        private static List<Advertisement> ads = new List<Advertisement>
        {
            new Advertisement
            {
                Id = 1,
                Title = "Spiderman",
                Description = "Book",
                Price=20,
                IsActive=true,
                DatePosted=new DateTime(2022,01,09)},



            new Advertisement
            {
                Id = 2,
                Title = "Ironman",
                Description = "CD",
                Price=30,
                IsActive=false,
                DatePosted=new DateTime(2022,01,10)},
        };

        [HttpGet]
        public async Task<ActionResult<List<Advertisement>>> GetAll()
        {
            return Ok(await _dbContext.Advertisements.ToListAsync());

        }


        [HttpGet]
        [Route("{id}")]
        //[Route("GetOne/{id:int}")]
        public async Task<ActionResult<Advertisement>> GetOne(int id)
        {
            var product = _dbContext.Advertisements.Find(id);


            if (product == null)
            {
                return BadRequest("Superhero not found");
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Advertisement>> PostProduct(Advertisement product)
        {
            _dbContext.Advertisements.Add(product);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisements.ToListAsync());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Advertisement>> UpdateProduct(Advertisement product)
        {
            // OBS: PUT Uppdaterar HELA SuperHero (ALLA properties)
            var adsToUpdate = await _dbContext.Advertisements.FindAsync(product.Id);

            if (adsToUpdate == null)
            {
                return BadRequest("Superhero not found");
            }
            adsToUpdate.Title = product.Title;
            adsToUpdate.Description = product.Description;
            adsToUpdate.Price = product.Price;
            adsToUpdate.DatePosted = product.DatePosted;
            adsToUpdate.IsActive = product.IsActive;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.Advertisements.ToListAsync());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Advertisement>> Delete(int id)
        {
            var product = await _dbContext.Advertisements.FindAsync(id);

            if (product == null)
            {
                return BadRequest("Superhero not found");
            }

            _dbContext.Advertisements.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.Advertisements.ToListAsync());

        }
    }
}
