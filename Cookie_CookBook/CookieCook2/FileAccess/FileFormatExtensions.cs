
namespace CookieCook2.FileAccess;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat)
    {
        //return fileFormat switch
        //{
        //    FileFormat.Json => "json",
        //    FileFormat.Txt => "txt",
        //    _ => throw new NotSupportedException()
        //};
        return fileFormat == FileFormat.Json ? "json" : "txt";
    }
}
