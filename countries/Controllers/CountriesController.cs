using countries.Api.Data;
using countries.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Dtos;

namespace countries.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {

        private readonly CountriesDbContext _context;

        public CountriesController(CountriesDbContext _context)
        {
            this._context = _context;
        }


        [HttpPost]
        public async Task<Countries> AddCountry(AddCountries addCountries)
        {
            var country = await this._context.Countries
               .FirstOrDefaultAsync(c => c.Name == addCountries.Name);


            if (country == null)
            {
                country = new Countries { Name = addCountries.Name, Continent = addCountries.Continent };
                await this._context.Countries.AddAsync(country);
                await this._context.SaveChangesAsync();
            }
            return country;
        }



        [HttpDelete("{Id}")]
        public async Task<Countries> DeleteCountry(int Id)
        {
            var country = await this._context.Countries.FindAsync(Id);

            if (country != null)
            {
                this._context.Countries.Remove(country);
                await this._context.SaveChangesAsync();
            }

            return country;
        }


        [HttpGet("{Id}")]
        public async Task<Countries> GetCountry(int Id)
        {
            return await this._context.Countries
                .Where(c => c.Id == Id)
                .Select(c => new Countries
                {
                    Id = c.Id,
                    Name = c.Name,
                    Continent = c.Continent
                })
                .SingleOrDefaultAsync<Countries>();
        }


        [HttpPatch]
        public async Task<Countries> UpdateCountry(UpdateCountry updateCountry)
        {
            var country = await this._context.Countries.FindAsync(updateCountry.id);

            if (country == null)
            {
                throw new InvalidOperationException("Country not found");
            }

            country.Name = updateCountry.Name;
            country.Continent = updateCountry.Continent;

            await this._context.SaveChangesAsync();
            return country;
        }
    }
}

