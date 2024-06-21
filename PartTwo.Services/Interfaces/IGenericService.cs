using PartTwo.Entities.Entities;

namespace PartTwo.Services.Interfaces;

public interface IGenericService<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> GetEntityWithSpec(ISpecification<T> spec);
    Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
}
