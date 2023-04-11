using DataLayer.Enums;
using DataLayer.Models;

namespace Golestan.Utils;

public static class TokenGenerator
{
    private static string GenerateToken() => Guid.NewGuid().ToString();

    public static Token GenerateToken(Role role, string username) => new()
    {
        Role = role,
        UserName = username,
        ValidUntil = DateTime.Now + TimeSpan.FromMinutes(30 /*todo read from config*/),
        Value = GenerateToken()//todo test the program
        //todo read todo.txt
        //todo use regex for validating username, password, etc
    };
}