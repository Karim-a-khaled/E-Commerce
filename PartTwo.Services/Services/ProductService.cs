using Microsoft.EntityFrameworkCore;
using PartTwo.Data;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;

namespace PartTwo.Services.Services;

public class ProductService : IProductService
{
    private readonly StoreContext _context;
    public ProductService(StoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();

        if(products == null) 
            return null;

        return products;
    }

    public async Task<Product> GetProduct(int id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
            return null;

        return product;
    }
}
