using HotelListing.Models;
using Microsoft.Identity.Client;

namespace HotelListing.Repository;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Country> Countries { get; }

    IGenericRepository<Hotel> Hotels { get; }

    Task Save();
}
