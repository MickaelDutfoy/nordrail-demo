using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly CityService _cityService;

    public CitiesController(CityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<string>> GetCities()
    {
        var cities = _cityService.GetAll();

        return Ok(cities);
    }
}