namespace CineReserve.Api.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public decimal CreditBalance { get; set; }
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; }
    public List<Booking> Bookings { get; set; } = new();
}