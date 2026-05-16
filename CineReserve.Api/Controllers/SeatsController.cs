using CineReserve.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SeatsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SeatsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{hallName}")]
    public async Task<IActionResult> GetSeats(string hallName)
    {
        var seats = await _context.Seats
            .Where(x => x.HallName == hallName)
            .ToListAsync();

        return Ok(seats);
    }
}