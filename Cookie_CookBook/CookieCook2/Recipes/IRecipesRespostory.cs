namespace CookieCook2.Recipes;

public interface IRecipesRespostory
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);

    //IEnumerable veririz ki daha genel bir type vermis oluruz..implemente edilirken ihtiyac hangi type ile almak ise list, array..o tipe gore implemente edilebilr
}
//A recipe is simply a wrapper for a collection of Ingredients
