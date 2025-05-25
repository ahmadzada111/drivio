using Microsoft.AspNetCore.Diagnostics;

namespace Drivio.WebApi.ExceptionHandler;

public class GlobalExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}