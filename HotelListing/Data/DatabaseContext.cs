using HotelListing.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data;

public class DatabaseContext : IdentityDbContext<APIUser>
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Jamica",
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
                Name = "Caiman Island",
                ShortName = "CI"
            },
            new Country
            {
                Id = 4,
                Name = "Ukraine",
                ShortName = "UA"
            }
        );

        builder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Sandals Resort and SPA",
                Address = "Negril",
                CountryId = 1,
                Raiting = 4.5
            },
            new Hotel
            {
                Id = 2,
                Name = "Comfort Suites",
                Address = "Gearoge Town",
                CountryId = 3,
                Raiting = 4.3
            },
            new Hotel
            {
                Id = 3,
                Name = "Grand Palladium",
                Address = "Nassua",
                CountryId = 2,
                Raiting = 4
            },
            new Hotel
            {
                Id = 4,
                Name = "Grand Palladium",
                Address = "Georgievska",
                CountryId = 4,
                Raiting = 3
            }
        );
    }
}
