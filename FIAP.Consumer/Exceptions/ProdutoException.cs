namespace FIAP.Consumer.Exceptions;

internal class ProdutoException : Exception
{
    public ProdutoException()
    {
    }

    public ProdutoException(string? message) : base(message)
    {
    }

    public ProdutoException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
