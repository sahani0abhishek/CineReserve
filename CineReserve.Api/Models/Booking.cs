namespace CineReserve.Api.Models;

public class Booking
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int ShowtimeId { get; set; }
    public Showtime Showtime { get; set; } = null!;
    public string BookingReference { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string BookingStatus { get; set; } = "Confirmed";
    public DateTime CreatedAt { get; set; }
    public List<TicketDetail> TicketDetails { get; set; } = new();
}