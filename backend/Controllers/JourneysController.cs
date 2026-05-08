using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JourneysController : ControllerBase
{
    private readonly JourneyService _journeyService;

    public JourneysController(JourneyService journeyService)
    {
        _journeyService = journeyService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Journey>> SearchJourneys(
        [FromQuery] string from,
        [FromQuery] string to)
    {
        var journeys = _journeyService.SearchJourneys(from, to);

        return Ok(journeys);
    }
}