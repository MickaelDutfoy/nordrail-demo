using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class CityService
{
    private readonly NordRailDbContext _context;

    public CityService(NordRailDbContext context)
    {
        _context = context;
    }

    public IReadOnlyList<City> GetAll()
    {
        return _context.Cities
            .OrderBy(city => city.Name)
            .ToList();
    }
}