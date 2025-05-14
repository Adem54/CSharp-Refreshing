
namespace CSharpDemoListArray.DataAccess;

public class StringTextualRepostory
{
    private static readonly string Seperator = Environment.NewLine;


    public List<string> Read(string filePath)
    {
        var fileContents = File.ReadAllText(filePath);
        //Split ayri bir islem gibi gozukebilir ancak, burda split islemi read islemini bir parcasidir..ondan dolayi burda kalmasi gerekir..yani biz gidip Split i ayri bir method vs olusturalim..buna gerek yok
        var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
        return namesFromFile;
    }

    public void Write(string filePath, List<string> strings)
    {

        //Join islemi write isleminin bir parcasidir...ondan dolayi burda kalmasi gerekir gidip de ayri biryerde method veya class olusturalim demeiz cok mantikli olmaz burda kalmasi gerekir
        string textToBeSaved = string.Join(Seperator, strings);
        File.WriteAllText(filePath, textToBeSaved);
    }

    /*
        * Asagidaki fonksyonlarin da yeri NamesRepostory olmamalidir...cunku bunlar okuma ve yazma ile igli degildir ve bu class in gorevi degildir..

    private string BuildFilePath()
    {
        return "names.txt";
    }

    private string Format()
    {
        return string.Join(Environment.NewLine, _names);
    }

    */



}

