namespace Golestan.Business.Exceptions;

public class ReLoginException : Exception
{
    public ReLoginException() : base("Error: YOU HAVE ALREADY LOGGED IN") { }
}