
namespace PartTwo.WebAPI.Errors;

public class ApiResponse
{
    public ApiResponse()
    {
        
    }
    public ApiResponse(int statusCode, string message = null)
    {
        StatusCode = statusCode;
        Message = message ?? GetDefaultMessageForStatusCode(statusCode);
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }


    private string GetDefaultMessageForStatusCode(int statusCode)
    {
        return statusCode switch
        {
            400 => "Bad Request",
            401 => "Not Authorized ( Authenticated )",   
            403 => "Not Authorized",   
            404 => "Resourse Was Not Found",   
            500 => "Server Side Error",   
            _ => null   
        };
    }
}
