namespace Golestan.Business.Exceptions;

public class InvalidPhoneNumberException : Exception
{
    public InvalidPhoneNumberException() : base("INVALID PHONE NUMBER") { }
}