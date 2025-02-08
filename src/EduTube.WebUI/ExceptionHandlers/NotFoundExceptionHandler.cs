using EduTube.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EduTube.WebUI.ExceptionHandlers;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
        httpContext.Response.ContentType = "application/json";

        var response = new
        {
            StatusCode = httpContext.Response.StatusCode,
            Message = exception.Message
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);


        return true;
    }
}