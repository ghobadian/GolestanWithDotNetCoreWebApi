namespace Golestan.Business.Exceptions;

public class InactiveUserException : Exception
{
    public InactiveUserException() : base("Error 401: YOU MUST BE ACTIVATED FIRST") { }
}