
namespace CookieCook2.Recipes.Ingredients;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}
//A recipe is simply a wrapper for a collection of Ingredients
