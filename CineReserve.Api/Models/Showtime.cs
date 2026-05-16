namespace CineReserve.Api.Models;

public class Showtime
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
    public string HallName { get; set; } = string.Empty;
    public DateTime ShowDate { get; set; }
    public TimeSpan ShowTime { get; set; }
    public decimal TicketPrice { get; set; }
    public decimal VipPremiumPercent { get; set; }
    public List<Booking> Bookings { get; set; } = new();
    public List<TicketDetail> TicketDetails { get; set; } = new();
}