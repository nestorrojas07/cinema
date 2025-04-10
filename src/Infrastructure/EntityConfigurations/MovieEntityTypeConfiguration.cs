using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class MovieEntityTypeConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Title)
            .HasColumnName("title")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)            
            .HasColumnName("description")
            .HasMaxLength(500);

        builder.Property(p => p.Genre)
            .HasColumnName("genre")
            .IsRequired(true);

        builder.Property(p => p.LaunchAt)
            .HasColumnName("launch_at")
            .IsRequired(true);

        builder.Property(p => p.DurationMinutes)
            .HasColumnName("duration_minutes")
            .IsRequired(true)
            .HasDefaultValue(60);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }
}