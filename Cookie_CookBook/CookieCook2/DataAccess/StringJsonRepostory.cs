using System.Text.Json;

namespace CookieCook2.DataAccess;

//Json icin sadece json i ilgilendiren bir class yapariz...dikkat edelim..gidip de StringTextualRepostory icerisinde, parametreden json mi, text mi oldugunu bilip switch case ile json ise json in islemini text ise textin islemini yapayim gibi bir yaklasi tamammen yanlistir..ve clean-code solid..prensiblerinin hepsini alt ust eder...Dolayisi ile json i ilglendiren class tamamen ayri olmalidir
public class StringJsonRepostory : StringRepostoryBase
{
    protected override string StringsToText(List<string> strings)
    {
        return JsonSerializer.Serialize(strings);
    }

    protected override List<string> TextToStrings(string content)
    {
        return JsonSerializer.Deserialize<List<string>>(content) ?? new List<string>();
    }
}
