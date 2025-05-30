// See https://aka.ms/new-console-template for more information


[Serializable]
internal class AuthorizationException : Exception
{
    public AuthorizationException()
    {
    }

    public AuthorizationException(string? message) : base(message)
    {
    }

    public AuthorizationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}