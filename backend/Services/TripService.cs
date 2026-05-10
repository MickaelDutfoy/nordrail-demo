using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class TripService
{
    private readonly NordRailDbContext _context;

    public TripService(NordRailDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<Trip> GetAllTrips()
    {
        return _context.Trips
            .Include(trip => trip.FromCity)
            .Include(trip => trip.ToCity)
            .ToList();
    }

    public IReadOnlyList<Trip> GetTrips(string from, string to)
    {
        return _context.Trips
            .Include(trip => trip.FromCity)
            .Include(trip => trip.ToCity)
            .Where(trip =>
                trip.FromCity.Name == from &&
                trip.ToCity.Name == to)
            .ToList();
    }

    public Trip? GetTripById(int id)
    {
        return _context.Trips
            .Include(trip => trip.FromCity)
            .Include(trip => trip.ToCity)
            .FirstOrDefault(trip => trip.Id == id);
    }
}