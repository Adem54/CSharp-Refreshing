using CookieCook2.Recipes.Ingredients;
using CookieCook2.Recipes;

namespace CookieCook2.App;

//Biraz daha bu class in ne islem yaptigi belli olsun diye class ismini RecipesUserINteraction dan RecipesConsoleUserInteraction
public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to close");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        //Please notice that for IEnumerable, Count is a method, not a property.
        //We did not see this method in the IEnumerable interface when we looked at it.
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are: " + Environment.NewLine);
            int counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"***** {counter} *****");
                Console.WriteLine(recipe);
                //we must override ToString method in the Recipe class..
                ++counter;
            }

        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
            "Available ingredients are:");

        //This part is problematic because we don't have the list of all ingredients anywhere.
        //It would be useful to have a class that stores it.It will also be helpful later when the user selects an ingredient by its ID.
        //Bu plani yaptiktan sonra direk gidip RecipesConsoleUserInteraction icerisinde...henuz IngredientsRegister olusturmadik ama intentional programming mantiginda, nerde implemente edecegmizi nerde kullanacagimzi gireriz... private readonly IngredientsRegister _ingredientsRegister;
        foreach (var ingredient in _ingredientsRegister.All)
        {
            //We must also override the ToString method in the Ingredient class.According to the requrments it shold print ingredient id and name
            /* in Ingredient classs    public override string ToString()
        {
            return $"{Id}. {Name}";
        }*/
            Console.WriteLine(ingredient);
        }
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;//whild loop shallStop or not...
        var ingredients = new List<Ingredient>();
        //list of ingredients to which we will add any ingredient the user selected and which will finally be returned as the method's result...

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, " +
                "or type anything else if finished.");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id))
            {
                //Yine intentional programming...mantigindan gidiyourz ve gercekten harika faydali ve real-life practise e cok uygun bir yaklasim..hem adim adim hem de detaylari ilerledikce ve ihtiyaci gordukce..coze coze gidilyor!!!
                var selectedIngredient = _ingredientsRegister.GetById(id);
                //EGer ki girilen id, ingredient id leri arasinda bulunmayan birsayi ise..o zaman GetById null donebilme durumunu handle etmemiz gerek
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else//if id is not int...so out of the loop
            {
                shallStop = true;
            }
        }
        return ingredients;
    }
}
