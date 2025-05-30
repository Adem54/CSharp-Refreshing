// See https://aka.ms/new-console-template for more information


[Serializable]
internal class DataAccessException : Exception
{
    public DataAccessException()
    {
    }

    public DataAccessException(string? message) : base(message)
    {
    }

    public DataAccessException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}