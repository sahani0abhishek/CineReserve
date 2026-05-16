namespace CineReserve.Api.Models;

public class Seat
{
    public int Id { get; set; }
    public string HallName { get; set; } = string.Empty;
    public string RowNumber { get; set; } = string.Empty;
    public int SeatNumber { get; set; }
    public string SeatType { get; set; } = "Standard";
    public List<TicketDetail> TicketDetails { get; set; } = new();
}