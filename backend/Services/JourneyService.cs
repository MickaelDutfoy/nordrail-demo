using backend.Models;

namespace backend.Services;

public class JourneyService
{
    private readonly TripService _tripService;

    public JourneyService(TripService tripService)
    {
        _tripService = tripService;
    }

    public IReadOnlyList<Journey> SearchJourneys(string from, string to)
    {
        var allTrips = _tripService.GetAllTrips();

        var journeys = new List<Journey>();

        // Direct journeys
        var directTrips = allTrips
            .Where(trip =>
                trip.From == from &&
                trip.To == to);

        foreach (var trip in directTrips)
        {
            journeys.Add(new Journey
            {
                Id = $"direct-{trip.Id}",
                Segments = [trip],
                TotalPrice = trip.Price
            });
        }

        // One connection max
        var firstSegments = allTrips
            .Where(trip => trip.From == from);

        foreach (var firstTrip in firstSegments)
        {
            var secondSegments = allTrips
                .Where(trip =>
                    trip.From == firstTrip.To &&
                    trip.To == to);

            foreach (var secondTrip in secondSegments)
            {
                journeys.Add(new Journey
                {
                    Id = $"connection-{firstTrip.Id}-{secondTrip.Id}",

                    Segments =
                    [
                        firstTrip,
                        secondTrip
                    ],

                    TotalPrice =
                        firstTrip.Price +
                        secondTrip.Price
                });
            }
        }

        return journeys;
    }
}