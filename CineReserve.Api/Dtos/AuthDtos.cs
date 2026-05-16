namespace CineReserve.Api.Dtos;

public record LoginRequest(string Email, string Password);
public record LoginResponse(string Token, string Role, decimal CreditBalance);
public record RegisterRequest(string Email, string Password, string FullName);