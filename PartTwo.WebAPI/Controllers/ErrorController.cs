using Microsoft.AspNetCore.Mvc;
using PartTwo.WebAPI.Errors;

namespace PartTwo.WebAPI.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : BaseController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}
