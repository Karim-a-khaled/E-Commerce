using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace PartTwo.Services.Services;

public class BasketService : IBasketService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;
    public BasketService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
    }


    public async Task<bool> DeleteBasket(string basketId)
    {
        return await _database.KeyDeleteAsync(basketId);
    }

    public async Task<CustomerBasket> GetBasket(string basketId)
    {
        var data = await _database.StringGetAsync(basketId);

        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
    }

    public async Task<CustomerBasket> UpdateBasket(CustomerBasket basket)
    {
        var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));

        if (!created) return null;

        return await GetBasket(basket.Id);

    }
}
