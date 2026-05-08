using backend.Models;

namespace backend.Services;

public class TripService
{
    private readonly List<Trip> _trips =
    [
        new Trip { Id = 1, From = "Oslo", To = "Trondheim", DepartureTime = "08:00", ArrivalTime = "14:30", Price = 699 },
        new Trip { Id = 2, From = "Oslo", To = "Trondheim", DepartureTime = "12:00", ArrivalTime = "18:30", Price = 649 },
        new Trip { Id = 3, From = "Trondheim", To = "Bodø", DepartureTime = "15:10", ArrivalTime = "23:00", Price = 799 },
        new Trip { Id = 4, From = "Trondheim", To = "Bodø", DepartureTime = "19:15", ArrivalTime = "03:20", Price = 749 },

        new Trip { Id = 5, From = "Oslo", To = "Bergen", DepartureTime = "09:15", ArrivalTime = "16:05", Price = 599 },
        new Trip { Id = 6, From = "Bergen", To = "Stavanger", DepartureTime = "17:00", ArrivalTime = "20:10", Price = 349 },
        new Trip { Id = 7, From = "Oslo", To = "Stavanger", DepartureTime = "07:45", ArrivalTime = "15:30", Price = 699 },

        new Trip { Id = 8, From = "Trondheim", To = "Ålesund", DepartureTime = "09:30", ArrivalTime = "13:45", Price = 399 },
        new Trip { Id = 9, From = "Ålesund", To = "Bergen", DepartureTime = "14:30", ArrivalTime = "19:20", Price = 449 },

        new Trip { Id = 10, From = "Bodø", To = "Narvik", DepartureTime = "08:20", ArrivalTime = "12:40", Price = 399 },
        new Trip { Id = 11, From = "Narvik", To = "Tromsø", DepartureTime = "13:30", ArrivalTime = "17:15", Price = 349 },

        new Trip { Id = 12, From = "Trondheim", To = "Tromsø", DepartureTime = "06:45", ArrivalTime = "18:20", Price = 1199 },
        new Trip { Id = 13, From = "Bergen", To = "Trondheim", DepartureTime = "08:30", ArrivalTime = "15:45", Price = 749 },
        new Trip { Id = 14, From = "Tromsø", To = "Trondheim", DepartureTime = "09:00", ArrivalTime = "20:30", Price = 1199 }
    ];

    public IReadOnlyList<Trip> GetAllTrips()
    {
        return _trips;
    }

    public IReadOnlyList<Trip> GetTrips(string from, string to)
    {
        return _trips
            .Where(trip =>
                trip.From == from &&
                trip.To == to)
            .ToList();
    }
}