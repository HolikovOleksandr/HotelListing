using HotelListing.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Country> Countries { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }
}
