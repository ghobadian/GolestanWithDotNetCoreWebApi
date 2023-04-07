namespace Golestan.Utils;

public static class TokenGenerator
{
    public static string GenerateToken() => Guid.NewGuid().ToString();
}