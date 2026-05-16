using CineReserve.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CineReserve.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Movie> Movies => Set < Movie > ();
    public DbSet<Showtime> Showtimes => Set < Showtime > ();
    public DbSet<Seat> Seats => Set < Seat > ();
    public DbSet<Booking> Bookings => Set < Booking > ();
    public DbSet<TicketDetail> TicketDetails => Set<TicketDetail>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TicketDetail>()
            .HasIndex(t => new { t.ShowtimeId, t.RowNumber, t.SeatNumber })
            .IsUnique()
            .HasDatabaseName("UQ_Ticket_Showtime_Seat");

        modelBuilder.Entity < Seat > ()
            .HasIndex(s => new { s.HallName, s.RowNumber, s.SeatNumber })
            .IsUnique()
            .HasDatabaseName("UQ_Seats_Hall_Row_Seat");

        modelBuilder.Entity<User>()
            .Property(u => u.CreditBalance)
            .HasPrecision(10, 2);

        modelBuilder.Entity < Showtime > ()
            .Property(s => s.TicketPrice)
            .HasPrecision(8, 2);

        modelBuilder.Entity < Showtime > ()
            .Property(s => s.VipPremiumPercent)
            .HasPrecision(5, 2);

        modelBuilder.Entity < Booking > ()
            .Property(b => b.TotalAmount)
            .HasPrecision(10, 2);

        modelBuilder.Entity<TicketDetail>()
            .Property(t => t.Price)
            .HasPrecision(8, 2);
    }
}