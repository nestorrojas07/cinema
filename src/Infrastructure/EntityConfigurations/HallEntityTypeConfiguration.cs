using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations;

public class HallEntityTypeConfiguration : IEntityTypeConfiguration<Hall>
{
    public void Configure(EntityTypeBuilder<Hall> builder)
    {
        builder.ToTable("halls");

        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.TheaterId)
            .HasColumnName("theater_id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Seats)            
            .HasColumnName("seats")
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.Property(p => p.Rows)            
            .HasColumnName("rows")
            .IsRequired()
            .HasDefaultValue(0);
        
        builder.Property(p => p.Columns)            
            .HasColumnName("columns")
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
        
        builder.HasOne<Theater>(x => x.Theater)
            .WithMany()
            .HasForeignKey(e => e.TheaterId)
            
            .IsRequired(false);
    }
}