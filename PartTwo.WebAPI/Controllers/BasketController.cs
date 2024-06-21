using Microsoft.AspNetCore.Mvc;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;

namespace PartTwo.WebAPI.Controllers;

public class BasketController : BaseController
{
    private readonly IBasketService _basketService;
    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet]
    public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
    {
        var basket = await _basketService.GetBasket(id);

        return Ok(basket ?? new CustomerBasket());
    }

    [HttpPost]
    public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasket basket)
    {
        var updatedBasket = await _basketService.UpdateBasket(basket);

        return Ok(updatedBasket);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteBasket(string id)
    {
        var basket = await _basketService.DeleteBasket(id);

        return Ok(basket);
    }

}
