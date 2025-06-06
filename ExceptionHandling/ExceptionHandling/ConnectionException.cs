﻿// See https://aka.ms/new-console-template for more information


[Serializable]
internal class ConnectionException : Exception
{
    public ConnectionException()
    {
    }

    public ConnectionException(string? message) : base(message)
    {
    }

    public ConnectionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}