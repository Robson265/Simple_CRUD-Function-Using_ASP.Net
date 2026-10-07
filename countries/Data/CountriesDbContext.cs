using countries.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace countries.Api.Data
{
    public class CountriesDbContext: DbContext
    {

        public CountriesDbContext(DbContextOptions<CountriesDbContext> options) : base(options)
        {         
        }


        public DbSet<Countries> Countries => Set<Countries>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Countries>().HasData(new Countries
            //{
            //    Id = 1,
            //    Name = "United State Of America",
            //    Continent = "North America"

            //});
            //modelBuilder.Entity<Countries>().HasData(new Countries
            //{
            //    Id = 2,
            //    Name = " Nigeria",
            //    Continent = "Africa"

            //});
            //modelBuilder.Entity<Countries>().HasData(new Countries
            //{
            //    Id = 3,
            //    Name = " Egypt",
            //    Continent = "Africa "

            //});
            //modelBuilder.Entity<Countries>().HasData(new Countries
            //{
            //    Id = 4,
            //    Name = "Ghana",
            //    Continent = "Africa "

            //});
        }

    }
}
