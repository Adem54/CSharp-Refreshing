using CookieCook2.Recipes;

namespace CookieCook2.App;

//We have the high level design ready. 
//The implementation details are not yet defined, but the interface of those classes is..and it is more important than the details


//Dikkat edelim...interface imiz RecipesConsoleUserInteraction ile  ilgili herhangi bir sey soylemiyor bize..sadece user ile communication icin hangi methodlara ihtiyacimz var onlari bize veriyor...
public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}
