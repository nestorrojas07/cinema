using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.EntityConfigurations;

public class ReservationEntityTypeConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("reservations");

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.ShowScheduleId)
            .HasColumnName("show_schedule_id")
            .IsRequired();
        
        builder.Property(p => p.MovieId)
            .HasColumnName("movie_id")
            .IsRequired();
        
        builder.Property(p => p.HallId)
            .HasColumnName("hall_id")
            .IsRequired();
        
        builder.Property(p => p.TheaterId)
            .HasColumnName("theater_id")
            .IsRequired();
        
        builder.Property(p => p.StartAt)
            .HasColumnName("start_at")
            .IsRequired();
        
        builder.Property(p => p.EndAt)
            .HasColumnName("end_at")
            .IsRequired();
        
        builder.Property(p => p.Location)
            .HasColumnName("location")
            .HasMaxLength(10)
            .IsRequired();
        
        builder.Property(p => p.Invoice)
            .HasColumnName("invoice")
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(p => p.Identification)
            .HasColumnName("identification")
            .HasMaxLength(50)
            .IsRequired(false);
        
        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasMaxLength(100)
            .IsRequired(false);
        
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

        builder.HasIndex(t => new {  t.TheaterId, t.Status, t.StartAt, t.EndAt })
            .HasDatabaseName("Idx_Reservation_MovieId_From_To_TheaterId_Status");
        
        builder.HasIndex(t => new {  t.Identification })
            .HasDatabaseName("Idx_Reservation_identification");
        
        builder.HasIndex(t => new {  t.Email })
            .HasDatabaseName("Idx_Reservation_email");
        
        builder.HasOne<ShowSchedule>(x => x.ShowSchedule)
            .WithMany()
            .HasForeignKey(e => e.ShowScheduleId)
            .IsRequired();
        
        builder.HasOne<Movie>(x => x.Movie)
            .WithMany()
            .HasForeignKey(e => e.MovieId)
            .IsRequired();
        
        builder.HasOne<Hall>(x => x.Hall)
            .WithMany()
            .HasForeignKey(e => e.HallId)
            .IsRequired();
        
        builder.HasOne<Theater>(x => x.Theater)
            .WithMany()
            .HasForeignKey(e => e.TheaterId)
            .IsRequired();
    }

   
}