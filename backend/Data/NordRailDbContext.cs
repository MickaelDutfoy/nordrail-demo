using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data;

public class NordRailDbContext : DbContext
{
    public NordRailDbContext(DbContextOptions<NordRailDbContext> options)
        : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }

    public DbSet<Trip> Trips { get; set; }

    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Oslo" },
            new City { Id = 2, Name = "Trondheim" },
            new City { Id = 3, Name = "Bodø" },
            new City { Id = 4, Name = "Narvik" },
            new City { Id = 5, Name = "Tromsø" },
            new City { Id = 6, Name = "Bergen" },
            new City { Id = 7, Name = "Stavanger" },
            new City { Id = 8, Name = "Ålesund" }
        );

        modelBuilder.Entity<Trip>().HasData(
            // Oslo ↔ Trondheim
            new Trip { Id = 1, FromCityId = 1, ToCityId = 2, DepartureTime = "07:00", ArrivalTime = "12:30", Price = 649 },
            new Trip { Id = 2, FromCityId = 1, ToCityId = 2, DepartureTime = "13:00", ArrivalTime = "18:30", Price = 699 },
            new Trip { Id = 3, FromCityId = 2, ToCityId = 1, DepartureTime = "07:00", ArrivalTime = "12:30", Price = 649 },
            new Trip { Id = 4, FromCityId = 2, ToCityId = 1, DepartureTime = "13:00", ArrivalTime = "18:30", Price = 699 },

            // Trondheim ↔ Bodø
            new Trip { Id = 5, FromCityId = 2, ToCityId = 3, DepartureTime = "07:30", ArrivalTime = "13:30", Price = 749 },
            new Trip { Id = 6, FromCityId = 2, ToCityId = 3, DepartureTime = "15:00", ArrivalTime = "21:00", Price = 799 },
            new Trip { Id = 7, FromCityId = 3, ToCityId = 2, DepartureTime = "07:30", ArrivalTime = "13:30", Price = 749 },
            new Trip { Id = 8, FromCityId = 3, ToCityId = 2, DepartureTime = "15:00", ArrivalTime = "21:00", Price = 799 },

            // Bodø ↔ Narvik
            new Trip { Id = 9, FromCityId = 3, ToCityId = 4, DepartureTime = "08:00", ArrivalTime = "11:30", Price = 349 },
            new Trip { Id = 10, FromCityId = 3, ToCityId = 4, DepartureTime = "14:30", ArrivalTime = "18:00", Price = 399 },
            new Trip { Id = 11, FromCityId = 4, ToCityId = 3, DepartureTime = "08:00", ArrivalTime = "11:30", Price = 349 },
            new Trip { Id = 12, FromCityId = 4, ToCityId = 3, DepartureTime = "14:30", ArrivalTime = "18:00", Price = 399 },

            // Narvik ↔ Tromsø
            new Trip { Id = 13, FromCityId = 4, ToCityId = 5, DepartureTime = "08:30", ArrivalTime = "11:45", Price = 329 },
            new Trip { Id = 14, FromCityId = 4, ToCityId = 5, DepartureTime = "14:00", ArrivalTime = "17:15", Price = 349 },
            new Trip { Id = 15, FromCityId = 5, ToCityId = 4, DepartureTime = "08:30", ArrivalTime = "11:45", Price = 329 },
            new Trip { Id = 16, FromCityId = 5, ToCityId = 4, DepartureTime = "14:00", ArrivalTime = "17:15", Price = 349 },

            // Oslo ↔ Bergen
            new Trip { Id = 17, FromCityId = 1, ToCityId = 6, DepartureTime = "07:30", ArrivalTime = "12:45", Price = 549 },
            new Trip { Id = 18, FromCityId = 1, ToCityId = 6, DepartureTime = "13:30", ArrivalTime = "18:45", Price = 599 },
            new Trip { Id = 19, FromCityId = 6, ToCityId = 1, DepartureTime = "07:30", ArrivalTime = "12:45", Price = 549 },
            new Trip { Id = 20, FromCityId = 6, ToCityId = 1, DepartureTime = "13:30", ArrivalTime = "18:45", Price = 599 },

            // Bergen ↔ Stavanger
            new Trip { Id = 21, FromCityId = 6, ToCityId = 7, DepartureTime = "08:00", ArrivalTime = "10:45", Price = 329 },
            new Trip { Id = 22, FromCityId = 6, ToCityId = 7, DepartureTime = "15:00", ArrivalTime = "17:45", Price = 349 },
            new Trip { Id = 23, FromCityId = 7, ToCityId = 6, DepartureTime = "08:00", ArrivalTime = "10:45", Price = 329 },
            new Trip { Id = 24, FromCityId = 7, ToCityId = 6, DepartureTime = "15:00", ArrivalTime = "17:45", Price = 349 },

            // Oslo ↔ Stavanger
            new Trip { Id = 25, FromCityId = 1, ToCityId = 7, DepartureTime = "08:00", ArrivalTime = "14:30", Price = 649 },
            new Trip { Id = 26, FromCityId = 1, ToCityId = 7, DepartureTime = "12:30", ArrivalTime = "19:00", Price = 699 },
            new Trip { Id = 27, FromCityId = 7, ToCityId = 1, DepartureTime = "08:00", ArrivalTime = "14:30", Price = 649 },
            new Trip { Id = 28, FromCityId = 7, ToCityId = 1, DepartureTime = "12:30", ArrivalTime = "19:00", Price = 699 },

            // Trondheim ↔ Ålesund
            new Trip { Id = 29, FromCityId = 2, ToCityId = 8, DepartureTime = "07:30", ArrivalTime = "10:45", Price = 369 },
            new Trip { Id = 30, FromCityId = 2, ToCityId = 8, DepartureTime = "14:00", ArrivalTime = "17:15", Price = 399 },
            new Trip { Id = 31, FromCityId = 8, ToCityId = 2, DepartureTime = "07:30", ArrivalTime = "10:45", Price = 369 },
            new Trip { Id = 32, FromCityId = 8, ToCityId = 2, DepartureTime = "14:00", ArrivalTime = "17:15", Price = 399 },

            // Bergen ↔ Ålesund
            new Trip { Id = 33, FromCityId = 6, ToCityId = 8, DepartureTime = "07:30", ArrivalTime = "11:00", Price = 399 },
            new Trip { Id = 34, FromCityId = 6, ToCityId = 8, DepartureTime = "14:00", ArrivalTime = "17:30", Price = 449 },
            new Trip { Id = 35, FromCityId = 8, ToCityId = 6, DepartureTime = "07:30", ArrivalTime = "11:00", Price = 399 },
            new Trip { Id = 36, FromCityId = 8, ToCityId = 6, DepartureTime = "14:00", ArrivalTime = "17:30", Price = 449 }
        );

        modelBuilder.Entity<Trip>()
            .HasOne(trip => trip.FromCity)
            .WithMany()
            .HasForeignKey(trip => trip.FromCityId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Trip>()
            .HasOne(trip => trip.ToCity)
            .WithMany()
            .HasForeignKey(trip => trip.ToCityId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Booking>()
            .HasMany(booking => booking.Segments)
            .WithMany()
            .UsingEntity(journey => journey.ToTable("BookingTrips"));

        modelBuilder.Entity<Trip>()
            .Property(trip => trip.Price)
            .HasPrecision(10, 2);

        modelBuilder.Entity<Booking>()
            .Property(booking => booking.TotalPrice)
            .HasPrecision(10, 2);
    }
}