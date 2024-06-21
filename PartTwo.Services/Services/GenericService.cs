using Microsoft.EntityFrameworkCore;
using PartTwo.Data;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;

namespace PartTwo.Services.Services;

public class GenericService<T> : IGenericService<T> where T : BaseEntity
{
    private readonly StoreContext _context;
    public GenericService(StoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var data = await _context.Set<T>().ToListAsync();

        if (data is null)
            return null;

        return data;
    }

    public async Task<T> GetById(int id)
    {
        var data = await _context.Set<T>().FirstOrDefaultAsync(d => d.Id == id);

        if (data is null)
            return null;

        return data;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
    {
        var query = ApplySpecification(spec);
        return await query.ToListAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
    }
}
