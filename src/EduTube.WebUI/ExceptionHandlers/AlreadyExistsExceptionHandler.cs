using EduTube.Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace EduTube.WebUI.ExceptionHandlers;

public class AlreadyExistsExceptionHandler : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not AlreadyExistException)
            return new(false);

        httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
        httpContext.Response.ContentType = "application/json";

        return new(true);
    }
}