using DataLayer.Enums;

namespace DataLayer.Models.DTOs;

public record Token(string Value, DateTime ValidUntil, Role Role, string Username);
