using PartTwo.Entities.Entities;
using System.Text.Json;

namespace PartTwo.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {

        if (!context.Products.Any())
        {
            var productsData = File.ReadAllText("C:\\Users\\USER\\source\\repos\\PartTwo\\PartTwo.WebAPI\\SeedData\\products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(productsData);
            context.Products.AddRange(products);
        }

        if(context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
    }
}
