using EduTube.Application;
using EduTube.Infrastructure;
using EduTube.WebUI.ExceptionHandlers;

namespace EduTube.WebUI.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();

        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
        builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
        builder.Services.AddExceptionHandler<AlreadyExistsExceptionHandler>();
        builder.Services.AddExceptionHandler<InternalServerExceptionHandler>();
        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();

        builder.Services.AddApplication();
        builder.Services.AddInfrastructure(builder.Configuration);


        builder.Services.AddProblemDetails();

        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        return builder;
    }
}