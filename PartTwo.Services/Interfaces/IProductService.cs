using PartTwo.Entities.Entities;

namespace PartTwo.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product> GetProduct(int id);
}
