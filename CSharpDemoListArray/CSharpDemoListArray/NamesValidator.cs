// See https://aka.ms/new-console-template for more information
public class NamesValidator
{
    //Naming convention ile ilgili cook onemli bir nokta..zaten class ismi NamesValiator ise, bu class in bu isi yaptigi belli o zaman icindeki fonksiyona gidip de IsValidName demeye gerek yok sadece IsValid dememiz yeterli olacaktir
    public bool IsValid(string name)
    {
        return name.Length >= 2 &&
            name.Length < 25 &&
            char.IsUpper(name[0]) &&
            name.All(char.IsLetter);
    }
}
