using HotelListing.Data;
using HotelListing.Models;

namespace HotelListing.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    public UnitOfWork(DatabaseContext context)
    {
        _context = context;
    }

    private IGenericRepository<Country>? _countries;
    public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

    private IGenericRepository<Hotel>? _hotels;
    public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }

}
