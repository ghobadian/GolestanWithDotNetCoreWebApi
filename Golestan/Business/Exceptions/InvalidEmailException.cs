namespace Golestan.Business.Exceptions;

public class InvalidEmailException : Exception
{
    public InvalidEmailException() : base("INVALID EMAIL") { }
}