using Domain.Interfaces.MovieLists;
using Domain.Interfaces.Movies;
using Domain.Interfaces.ShowSchedules;
using Domain.Interfaces.Theaters;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInyection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);
        services.AddRepositories();

        return services;

    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("AuthDb"));
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<ITheaterRepository, TheaterRepository>();
        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<IMovieListRepository, MovieListRepository>();
        services.AddScoped<IShowScheduleRepository, ShowScheduleRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();

        return services;
    }
}