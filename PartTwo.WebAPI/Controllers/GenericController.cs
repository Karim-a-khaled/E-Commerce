using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PartTwo.Entities.DTOs;
using PartTwo.Entities.Entities;
using PartTwo.Entities.Entities.Specifications;
using PartTwo.Services.Interfaces;

namespace PartTwo.WebAPI.Controllers;

public class GenericController : BaseController
{
    private readonly IGenericService<Product> _productService;
    private readonly IGenericService<ProductBrand> _productBrandService;
    private readonly IGenericService<ProductType> _productTypeService;
    private readonly IMapper _mapper;

    public GenericController(IGenericService<Product> productService, 
                             IGenericService<ProductBrand> productBrandService, 
                             IGenericService<ProductType> productTypeService,
                             IMapper mapper)
    {
        _productService = productService;
        _productBrandService = productBrandService;
        _productTypeService = productTypeService;
        _mapper = mapper;
    }


    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProducts()
    {
        var spec = new ProductsWithTypesAndBrandsSpecification();

        var products = await _productService.ListAsync(spec);

        if (products is null)
            return NotFound();

        IEnumerable<ProductToReturnDto> productsToReturn = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductToReturnDto>>(products);

        return Ok(productsToReturn);
    }

    [HttpGet("products{id}")]
    public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
    {
        ProductsWithTypesAndBrandsSpecification spec = new ProductsWithTypesAndBrandsSpecification(id);

        Product product = await _productService.GetEntityWithSpec(spec);

        if (product is null)
            return NotFound();

        ProductToReturnDto productToReturn = _mapper.Map<Product, ProductToReturnDto>(product);

        return Ok(productToReturn);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrands()
    {
        var productBrands = await _productBrandService.GetAll();

        if (productBrands is null)
            return NotFound();

        return Ok(productBrands);
    }

    [HttpGet("brands/{id}")]
    public async Task<ActionResult<IEnumerable<ProductBrand>>> GetProductBrandById(int id)
    {
        var productBrand = await _productBrandService.GetById(id);

        if (productBrand is null)
            return NotFound();

        return Ok(productBrand);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
    {
        var productTypes = await _productTypeService.GetAll();

        if (productTypes is null)
            return NotFound();

        return Ok(productTypes);
    }

    [HttpGet("types/{id}")]
    public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypeById(int id)
    {
        var productType = await _productTypeService.GetById(id);

        if (productType is null)
            return NotFound();

        return Ok(productType);
    }
}
