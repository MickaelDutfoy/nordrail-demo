using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly TripService _tripService;

    public TripsController(TripService tripService)
    {
        _tripService = tripService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Trip>> GetTrips(
        [FromQuery] string from,
        [FromQuery] string to)
    {
        var trips = _tripService.GetTrips(from, to);

        return Ok(trips);
    }
}