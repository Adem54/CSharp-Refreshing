// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Text.Json.Serialization;

var logger = new Logger();
try
{
    Run();
}catch(Exception ex)
{
    Console.WriteLine("Sorry. The application has experienced "+ 
        "an error. The error message: " + ex.Message);
    logger.Log(ex);
}

Console.ReadKey();
void Run()
{
    try
    {
        Console.WriteLine("Enter a word");
        var word = Console.ReadLine();
        Console.WriteLine("Count of character is " + word.Length);
    }
    catch (NullReferenceException ex)
    {
        Console.WriteLine("The input is null, and its length cannot be calculated. " + 
            "Did you press CTRL+Z in the console?");
        logger.Log(ex);
        throw;
    }
}
