using CookieCook2.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCook2.App;


public class CookiesRecipesApp
{
    //private readonly RecipesRepostory _recipesRepostory = new RecipesRepostory();
    private readonly IRecipesRespostory _recipesRepostory;
    //private readonly RecipesConsoleUserInteraction _recipesUserInteraction = new RecipesConsoleUserInteraction();
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRespostory recipesRepostory, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepostory = recipesRepostory;
        _recipesUserInteraction = recipesUserInteraction;
    }
    //Su anda biz henuz RecipesRepostory, RecipesUserInteraction type lari tanimlamadigmiz icin, hata mesajlari aliyoruz alti cizili vs ama bu intentional programming bize, bu bizim dogru ve daha surdurulebilir bir design yapabilmemizi sagliyor
    public void Run(string filePath)
    {
        // 1.Load recipes from a file
        var allRecipes = _recipesRepostory.Read(filePath);

        //2.Print existing recipes
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        //3.Ask user to create a new recipe	
        //4.Print available ingredients
        _recipesUserInteraction.PromptToCreateRecipe();

        //5.Let the user choose ingredients	
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        /*
         6.If user selects none: print a message and exit	
         7.If user selects any:	
                Create a new recipe
                Add it to the existing recipes
                Save everything back to the file
                Print confirmation + recipe
         */

        //Tekrar hatirlayalim..Count ingredient-IEnumerable<Ingredient> type inda Count propertysi yoktu ve Count exthention mehtod olarak kullaniliyor burda
        if (ingredients.Count() > 0)
        {
            //7.If user selects any:
            //Create a new recipe
            var recipe = new Recipe(ingredients);

            //    Add it to the existing recipes
            allRecipes.Add(recipe);

            //    Save everything back to the file
            _recipesRepostory.Write(filePath, allRecipes);

            //    Print confirmation +recipe
            _recipesUserInteraction.ShowMessage("Recipe added: ");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            //Let's start with the case when no ingredients are selected, because it is easier
            //6.If user selects none: print a message and exit	
            _recipesUserInteraction.ShowMessage("No ingredients have been selected" +
                "Recipe will not be saved.");

        }

        //8.Exit the app
        _recipesUserInteraction.Exit();

    }
}
