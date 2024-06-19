using Microsoft.AspNetCore.Mvc;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;

namespace PartTwo.WebAPI.Controllers;


public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _productService.GetProducts();

        if(products is null)
            return NotFound();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Product>>> GetProduct(int id)
    {
        var product = await _productService.GetProduct(id);

        if (product is null)
            return NotFound();

        return Ok(product);
    }
}
