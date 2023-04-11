namespace Golestan.Business.Exceptions;

public class UsernameOrPasswordInvalidException : Exception
{
    public UsernameOrPasswordInvalidException() : base("Error 400: USERNAME/PASSWORD IS INCORRECT") { }
}