namespace EduTube.WebUI.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseWebApplicationMiddleware(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.UseRouting();

        app.UseExceptionHandler();

        return app;
    }
}