namespace FIAP.Consumer.Exceptions;

internal class ClienteException : Exception
{
    public ClienteException()
    {
    }

    public ClienteException(string? message) : base(message)
    {
    }

    public ClienteException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
