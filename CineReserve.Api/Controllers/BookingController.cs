using CineReserve.Api.Data;
using CineReserve.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookingController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> BookSeat([FromBody] BookingRequest request)
    {
        // check if same seat already booked for same showtime
        var exists = await _context.TicketDetails.AnyAsync(x =>
            x.ShowtimeId == request.ShowtimeId &&
            x.SeatId == request.SeatId
        );

        if (exists)
        {
            return BadRequest("Seat Already Reserved");
        }

        var booking = new Booking
        {
            UserId = request.UserId,
            ShowtimeId = request.ShowtimeId,
            BookingReference = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper(),
            TotalAmount = request.Price,
            BookingStatus = "Confirmed",
            CreatedAt = DateTime.Now
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        var ticket = new TicketDetail
        {
            BookingId = booking.Id,
            ShowtimeId = request.ShowtimeId,
            SeatId = request.SeatId,
            RowNumber = request.RowNumber,
            SeatNumber = request.SeatNumber,
            Price = request.Price
        };

        _context.TicketDetails.Add(ticket);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Booking Successful",
            bookingReference = booking.BookingReference
        });
    }
}