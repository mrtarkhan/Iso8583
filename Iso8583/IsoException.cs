namespace Iso8583;

public class IsoException : Exception
{
    public IsoException(string? message) : base(message)
    {
    }

    public IsoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}