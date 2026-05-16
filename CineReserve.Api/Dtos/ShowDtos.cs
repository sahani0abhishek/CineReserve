namespace CineReserve.Api.Dtos;

public record ShowtimeDto(int Id, string MovieTitle, string HallName, DateTime ShowDate, TimeSpan ShowTime, decimal TicketPrice, decimal VipPremiumPercent);
public record SeatStatusDto(string RowNumber, int SeatNumber, string SeatType, bool IsSold, decimal CurrentPrice);
public record CreateShowtimeRequest(int MovieId, string HallName, DateTime ShowDate, TimeSpan ShowTime, decimal TicketPrice, decimal? VipPremiumPercent);