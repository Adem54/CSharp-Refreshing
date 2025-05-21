
namespace CookieCook2.FileAccess;

public class FileMetadata
{
    public string Name { get; }
    public FileFormat Format { get; }

    public FileMetadata(string name, FileFormat fileFormat)
    {
        Name = name;
        Format = fileFormat;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";

}
