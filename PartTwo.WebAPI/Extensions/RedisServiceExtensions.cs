using StackExchange.Redis;

namespace PartTwo.WebAPI.Extensions;

public static class RedisServiceExtensions
{
    public static IServiceCollection AddRedisServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IConnectionMultiplexer>(c =>
        {
            var options = ConfigurationOptions.Parse(config.GetConnectionString("Redis"));
            return ConnectionMultiplexer.Connect(options);
        });

        return services;
    }
}
