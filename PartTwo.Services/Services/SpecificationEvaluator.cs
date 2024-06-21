using Microsoft.EntityFrameworkCore;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;

namespace PartTwo.Services;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
    {
        var query = inputQuery;

        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

        return query;
    }
}
