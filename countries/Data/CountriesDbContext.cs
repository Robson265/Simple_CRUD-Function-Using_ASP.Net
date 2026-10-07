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


        }

    }
}
