using Microsoft.EntityFrameworkCore;
using myHotelListing.Data;

namespace myHotelListing.API.Data // the rules/ 'contract' between the app and the database
{
    public class myHotelListingDbContext : DbContext
    {

        public myHotelListingDbContext(DbContextOptions options) : base(options) // options defined in Program.cs
        {
            // this is where table outlines and table configs are put so that when the db is being generated/ interacted with, 
            // then we have a set of objects outlined here
        }

        // After typing the DbSets below, create a Migration by doing the following:
        // Go to Tools -> NuGet Package Manager -> Package Manager Console
        // In the console, type: add-migration <name_of_migration>
        public DbSet<Hotel> Hotels { get; set; } 
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    Id = 2,
                    Name = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    Id = 3,
                    Name = "Cayman Island",
                    ShortName = "CI"
                }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Hotel1",
                    Address = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Hotel2",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Hotel3",
                    Address = "Grand Palldium",
                    CountryId = 2,
                    Rating = 4
                }
            );
        }

    }
}
