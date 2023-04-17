namespace Golestan.Business.Exceptions;

public class UnAuthorizedException : Exception
{
    public UnAuthorizedException() : base("Error 401: YOU DON'T HAVE ACCESS TO THIS API") { }
}