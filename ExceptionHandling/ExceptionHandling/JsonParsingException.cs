// See https://aka.ms/new-console-template for more information


using System.Linq.Expressions;
using System.Text.Json;

[Serializable]
public class JsonParsingException : Exception
{
    public string JsonBody { get; }
    public JsonParsingException()
    {
    }

    public JsonParsingException(string? message) : base(message)
    {
    }

    public JsonParsingException(string? message, string jsonBody) : base(message)
    {
        JsonBody = jsonBody;
    }

    public JsonParsingException(string? message, string jsonBody, Exception innerException) : base(message, innerException)
    {
        JsonBody = jsonBody;
    }

    public JsonParsingException(string? message, Exception innerException) : base(message, innerException)
    {
    }



    
    //We use a library for reading data from a database.
    //It's not our code, and we didn't decide how it behaves exactly
    //As it turns out, it throws an exception when a person with a given ID is not present in the database,
    //but for our needs, we would rather want this method to return null as we don't consider it an exceptional situation when  the person is not present.
    //We are okay with handling the null result.

 

    //Here we have a method that tries to save a person object in a database, but this database is not local to our machine, but it lives on some remote server.
    //The server may sometimes have a lot of work because many users interact with it in the same time.
    //In this case, this method may throw a timeout exception, meaning that it could not finish its job in a given time.
    //We could put this method in a try-catch block which would be placed inside a while loop.
    //If a timeout exception is caught, we reduce the number of retries left by one, wait for some time,and then go back to the beginning of the loop to try to save this object again.




}