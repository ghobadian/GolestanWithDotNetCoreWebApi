namespace Golestan.Business.Exceptions;

public class ExpiredTokenException : Exception
{
    public ExpiredTokenException() : base("Error: TOKEN HAS BEEN EXPIRED") { }
}