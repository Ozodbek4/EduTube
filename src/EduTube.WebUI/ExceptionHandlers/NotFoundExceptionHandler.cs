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

        await httpContext.Response.WriteAsJsonAsync(exception.Message, cancellationToken);


        return true;
    }
}