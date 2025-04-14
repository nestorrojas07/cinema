using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityConfigurations;

public class ShowScheduleEntityTypeConfiguration : IEntityTypeConfiguration<ShowSchedule>
{
    public void Configure(EntityTypeBuilder<ShowSchedule> builder)
    {
        builder.ToTable("shows_schedule");

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.MovieId)
            .HasColumnName("movie_id")
            .IsRequired();
        
        builder.Property(p => p.TheaterId)
            .HasColumnName("theater_id")
            .IsRequired();
        
        builder.Property(p => p.From)
            .HasColumnName("from")
            .IsRequired();
        
        builder.Property(p => p.To)
            .HasColumnName("to")
            .IsRequired();
        
        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();

        builder.HasIndex(t => new {  t.TheaterId, t.Status, t.From, t.To })
            .HasDatabaseName("Idx_ShowSchedule_MovieId_From_To_TheaterId_Status");
        
        builder.HasOne<Movie>(x => x.Movie)
            .WithMany()
            .HasForeignKey(e => e.MovieId)
            .IsRequired();
        
        builder.HasOne<Theater>(x => x.Theater)
            .WithMany()
            .HasForeignKey(e => e.TheaterId)
            .IsRequired();
        
        builder.Property(p => p.SeatsAvailable)
            .HasColumnName("seats_available")
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.Property(p => p.SeatsSold)
            .HasColumnName("seats_sold")
            .IsRequired()
            .HasDefaultValue(0);
    }

   
}