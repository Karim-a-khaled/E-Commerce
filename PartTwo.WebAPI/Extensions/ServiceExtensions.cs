using PartTwo.Services.Interfaces;
using PartTwo.Services.Services;

namespace PartTwo.WebAPI.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services; 
    }
}
