using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly BookingService _bookingService;

    public BookingsController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<Booking>> GetBookings()
    {
        var bookings = _bookingService.GetAllBookings();

        return Ok(bookings);
    }

    [HttpGet("{id}")]
    public ActionResult<Booking> GetBookingById(int id)
    {
        var booking = _bookingService.GetBookingById(id);

        if (booking is null)
        {
            return NotFound();
        }

        return Ok(booking);
    }

    [HttpPost]
    public ActionResult<Booking> CreateBooking(
        [FromBody] CreateBookingRequest request)
    {
        var booking = _bookingService.CreateBooking(request);

        return Ok(booking);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var deleted = _bookingService.DeleteBooking(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}