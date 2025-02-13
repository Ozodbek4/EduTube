using EduTube.Application.Abstractions.Persistence;
using EduTube.Infrastructure.Persistence;
using EduTube.Infrastructure.Persistence.Contexts;
using EduTube.Infrastructure.Persistence.Interceptors;
using EduTube.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EduTube.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register AppDbContext
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection"), sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(Assembly.GetExecutingAssembly());
            });
            options.AddInterceptors(new AuditableInterceptor());
        });

        // Register unit of work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserCredentialsRepository, UserCredentialsRepository>();

        return services;
    }
}