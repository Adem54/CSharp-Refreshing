namespace CookieCook2.DataAccess;

//Read and write ile ilgili bu class isimzi gorecektir..ve bu class i alip RecipeRepostory icerisinde dependency injeciton ile kullanacagiz ondan dolayi biz StringTextualRepostory icin IStringRepostory interface i olusturmamiz gerekiyor  !!!
public class StringTextualRepostory : StringRepostoryBase
{
    private static readonly string Seperator = Environment.NewLine;
    protected override string StringsToText(List<string> strings)
    {
        return string.Join(Seperator, strings);
    }

    protected override List<string> TextToStrings(string content)
    {
        return content.Split(Seperator).ToList();//Split string[] olarak donuyor, liste cevirmek icin ToList() kllanilir
    }
}
