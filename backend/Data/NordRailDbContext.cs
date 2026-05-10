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
}