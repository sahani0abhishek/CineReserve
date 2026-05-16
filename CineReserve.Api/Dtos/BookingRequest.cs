public class BookingRequest
{
    public int UserId { get; set; }
    public int ShowtimeId { get; set; }
    public int SeatId { get; set; }
    public string RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public decimal Price { get; set; }
}