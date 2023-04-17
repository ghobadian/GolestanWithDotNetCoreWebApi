using DataLayer.Enums;
using DataLayer.Models.DTOs;

namespace Golestan.Utils;

public static class TokenGenerator
{
    private static string GenerateToken() => Guid.NewGuid().ToString();

    public static Token GenerateToken(Role role, string username) => new(Value: GenerateToken(),
        ValidUntil: DateTime.Now + TimeSpan.FromMinutes(30 /*todo read from config*/), Role: role, Username: username);
        //todo read todo.txt
        //todo use regex for validating username, password, etc
}