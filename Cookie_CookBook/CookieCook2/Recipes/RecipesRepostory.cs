using CookieCook2.DataAccess;
using CookieCook2.Recipes.Ingredients;

namespace CookieCook2.Recipes;

public class RecipesRepostory : IRecipesRespostory
{
    private const string Seperator = ",";
    private readonly IIngredientsRegister _ingredientsRegister;
    private readonly IStringRepostory _stringRepostory;

    public RecipesRepostory(IStringRepostory stringRepostory, IIngredientsRegister ingredientsRegister)
    {
        _stringRepostory = stringRepostory;
        _ingredientsRegister = ingredientsRegister;
    }

    //Ilk basta Read methodu icerisine dummy data ile doldurmustuk, yani  kendimz manuel olarak data eklemistik test edebilmek icin...ama artik Read methodunu stringRepostory uzerinden handle edecegiz
    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringRepostory.Read(filePath);//return every row as string "1,2,3" in a list
        var Recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            //recipeFromFile is like "1,2,3"..RecipeFromString receive recipe ingredient ids as "1,2,3" and build the recipe by using this string..see INTENTIONAL PROGRAMMING!!!
            var recipe = RecipeFromString(recipeFromFile);
            Recipes.Add(recipe);
        }

        return Recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        //BESTPRACTISE REad isleminde Split icinde de seperator olarak "," kullaniyoruz, ayni zamanda Write isleminde de Join icinde "," seperator olarak kullaniyoruz var allIdStr = string.Join(", ", allIds);...o zaman bu "," seperator u const olarak  bu class icinde tanimlamamiz daha dogru ve bestpractise bir yaklasimdir
        var textualIds = recipeFromFile.Split(Seperator);
        List<Ingredient> ingredients = new();
        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            //direk int.Parse kullandim cunku, biliyorum ki bu string integera donusebilen bir stringdir bundan eminim, cunku bunu integer dan string e de biz cevirdik ve dosyaya attik zaten..BU DA ONEMLI BIR BESTPRACTISE YAKLASIMDIR!!!
            //Ayrica da _ingredientsRegister i da dependency injection ile aliyoruz...ama onu da direk kendi class indan almamiz dependency inversion prensibine aykiri oldugu icin onu da interface uzerinden aliiyoruz...
            //ONEMLI BIR BESPTRACTISE  YAKLASIMI....!!!
            //BURAYA DIKKET ingredient in null olup olmadigini kontrol etmiyorum cunku id nin null olmadigini biliyoru..As you can see, I don't check if this ingredient is null because I know only valid IDs are saved to this file.
            Ingredient ingredient = _ingredientsRegister.GetById(id);
            //use Ingredient ingredient = _ingredientsRegister.GetById(id); …but only if: You fully control the data source, And you're sure IDs will always match real ingredients

            //Otherwise, use a ? return type or defensive null-checking.
            //🛡️ Optional Defensive Improvement -If an invalid ID somehow appears, your app fails fast with a meaningful message — not a mysterious null error later.
            //var ingredient = _ingredientsRegister.GetById(id)?? throw new InvalidDataException($"Invalid ingredient ID: {id} in file.");

        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        //_stringRepostory.Write parametreye string data bekliyor, ve biz txt dosyasina "1,2,3" seklinde satir satir alt alta yazmamiz gerkiyor .txt dosyasina..Dolayisi ile biz allRecipes listemizi her bir satir a 1 Recipe ye ait id ler "1,2,3" gelecek sekilde tranform etmeliyiz...
        var recipesAsStrings = new List<string>();

        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            var allIdStr = string.Join(Seperator, allIds);
            recipesAsStrings.Add(allIdStr);
        }
        _stringRepostory.Write(filePath, recipesAsStrings);

    }
}
//A recipe is simply a wrapper for a collection of Ingredients
