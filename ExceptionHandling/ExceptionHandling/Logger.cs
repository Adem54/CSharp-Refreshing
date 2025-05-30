// See https://aka.ms/new-console-template for more information


internal class Logger
{
    public Logger()
    {
    }

    internal void Log(Exception ex)
    {
        Console.WriteLine("Writing the exception to a file with a message " + ex.Message);
    }
}