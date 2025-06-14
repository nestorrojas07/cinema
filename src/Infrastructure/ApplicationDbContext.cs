﻿using Domain.Entities;
using Domain.Entities.Enums;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Movie> movies { get; set; }
    public DbSet<Theater> theaters { get; set; }
    public DbSet<Hall> halls { get; set; }
    public DbSet<ShowSchedule> showSchedules { get; set; }
    public DbSet<MovieList> moviesList { get; set; }
    public DbSet<Reservation> reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());
        modelBuilder.Entity<Movie>();
        
        modelBuilder.ApplyConfiguration(new TheaterEntityTypeConfiguration());
        modelBuilder.Entity<Theater>();
        
        modelBuilder.ApplyConfiguration(new HallEntityTypeConfiguration());
        modelBuilder.Entity<Hall>();
        
        modelBuilder.ApplyConfiguration(new MovieListEntityTypeConfiguration());
        modelBuilder.Entity<MovieList>();
        
        modelBuilder.ApplyConfiguration(new ShowScheduleEntityTypeConfiguration());
        modelBuilder.Entity<ShowSchedule>();
        
        modelBuilder.ApplyConfiguration(new ReservationEntityTypeConfiguration());
        modelBuilder.Entity<Reservation>();
    }
}
