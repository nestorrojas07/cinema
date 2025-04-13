using Api.Controllers.Middlewares;
using Application.Services;

namespace Api;

public static class DependencyInyection
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GloblalExceptionHandlingMiddleware>();
        
        services.AddScoped<MovieService>();
        services.AddScoped<TheaterService>();
        
        return services;

    }
}