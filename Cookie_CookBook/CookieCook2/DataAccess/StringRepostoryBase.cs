namespace CookieCook2.DataAccess;

public abstract class StringRepostoryBase : IStringRepostory
{

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return TextToStrings(fileContents);//Split string[] olarak donuyor, liste cevirmek icin ToList() kllanilir
        }
        return new List<string>();
    }

    // Abstract methods that subclasses will implement
    protected abstract List<string> TextToStrings(string content);     // from string to list
    protected abstract string StringsToText(List<string> strings);    // from list to string

    public void Write(string filePath, List<string> strings)
    {
        var content = StringsToText(strings);
        File.WriteAllText(filePath, content);
    }

}
