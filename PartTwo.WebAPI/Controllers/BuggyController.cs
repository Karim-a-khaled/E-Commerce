using Microsoft.AspNetCore.Mvc;
using PartTwo.Data;
using PartTwo.Entities.Entities;
using PartTwo.Services.Interfaces;
using PartTwo.WebAPI.Errors;

namespace PartTwo.WebAPI.Controllers;

public class BuggyController : BaseController
{
    private readonly StoreContext _context;

    public BuggyController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet("not-found")]
    public ActionResult GetNotFound()
    {
        Product product = _context.Products.Find(4324);
        
        if(product is null)
            return NotFound(new ApiResponse(404));
        
        return Ok(product);
    }

    [HttpGet("servererror")]
    public ActionResult GetServerError()
    {
        Product product = _context.Products.Find(4324);

        var thing = product.ToString();

        return Ok();
    }

    [HttpGet("badrequest")]
    public ActionResult GetBadRequest()
    {
        return BadRequest(new ApiResponse(400));
    }

    [HttpGet("badrequest/{id}")]
    public ActionResult GetNotFoundRequest(int id)
    { 
        return Ok();
    }
}
