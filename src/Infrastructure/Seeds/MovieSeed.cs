using Domain.Entities;

namespace Infrastructure.Seeds;

public static class MovieSeed
{
    public static void SeedMovies(this ApplicationDbContext context)
    {
        if( !context.movies.Any() )
        {
            var movies = new List<Movie>()
            {
                new Movie()
                {
                    Title = "Kaiju No. 8: Misión de Reconocimiento",
                    Description = "Un emocionante viaje al mundo de los kaijus, donde un grupo de exploradores enfrenta criaturas gigantes en una misión de alto riesgo.",
                    Genre = "Animado",
                    DurationMinutes = 120,
                    LaunchAt = new DateTime(2025, 05, 10).ToUniversalTime(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new Movie()
                {
                    Title = "The Chosen: La Última Cena",
                    Description = "Una representación conmovedora de los eventos previos a la Última Cena, explorando las emociones y conflictos de los discípulos. ",
                    Genre = "Historia",
                    DurationMinutes = 180,
                    LaunchAt = new DateTime(2025, 05, 10).ToUniversalTime(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                },
                new Movie()
                {
                    Title = "Pink Floyd at Pompeii - MCMLXXII",
                    Description = "Una experiencia cinematográfica única que revive el icónico concierto de Pink Floyd en Pompeya con imágenes restauradas y sonido mejorado.",
                    Genre = "Musical",
                    DurationMinutes = 60,
                    LaunchAt = new DateTime(2025, 04, 24).ToUniversalTime(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                }
            };
            
            context.movies.AddRange(movies);
            context.SaveChanges();

        }
    }
}