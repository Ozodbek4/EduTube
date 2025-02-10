using Microsoft.AspNetCore.Diagnostics;

namespace EduTube.WebUI.ExceptionHandlers;

public class InternalServerExceptionHandler(ILogger<InternalServerExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        httpContext.Response.ContentType = "application/json";

        await httpContext.Response.WriteAsJsonAsync(exception.Message, cancellationToken);

        logger.LogError(exception.Message);

        return true;
    }
}