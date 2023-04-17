namespace Golestan.Business.Exceptions;

public class WeakPasswordException : Exception
{
    public WeakPasswordException() : base("YOUR PASSWORD IS WEAK. TRY ANOTHER ONE. " +
                                          "YOUR PASSWORD MUST CONTAIN A MINIMUM LENGTH 8 MIXTURE OF NUMBERS, SMALL AND CAPITAL LETTERS.") { }
}