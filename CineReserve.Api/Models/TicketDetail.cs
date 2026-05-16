namespace CineReserve.Api.Models;

public class TicketDetail
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    public int ShowtimeId { get; set; }
    public Showtime Showtime { get; set; } = null!;
    public int SeatId { get; set; }
    public Seat Seat { get; set; } = null!;
    public string RowNumber { get; set; } = string.Empty;
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
}