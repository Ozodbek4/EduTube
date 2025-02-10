using EduTube.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EduTube.WebUI.ExceptionHandlers;

public class AlreadyExistsExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not AlreadyExistException)
            return false;

        httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(exception.Message, cancellationToken);

        return true;
    }
}