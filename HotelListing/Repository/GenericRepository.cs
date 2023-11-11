using System.Linq.Expressions;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{

    private readonly DbSet<T> _db;
    private readonly DatabaseContext _context;
    public GenericRepository(DatabaseContext context)
    {
        _context = context;
        _db = _context.Set<T>();
    }

    public async Task Delete(int id)
    {
        var entity = await _db.FindAsync(id);
        _db.Remove(entity ?? throw new NullReferenceException());
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _db.RemoveRange(entities);
    }

    public async Task<T> Get(Expression<Func<T, bool>>? expression = null, List<string>? includes = null)
    {
        IQueryable<T> query = _db;

        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }

        return await query.AsNoTracking().FirstOrDefaultAsync(expression!) ?? throw new NullReferenceException();
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>>? expression = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, List<string>? includes = null)
    {
        IQueryable<T> query = _db;

        if (expression != null) query = query.Where(expression);

        if (includes != null)
        {
            foreach (var includeProperty in includes)
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy != null) query = orderBy(query);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task Insert(T entity)
    {
        await _db.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _db.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _db.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
    }

}
