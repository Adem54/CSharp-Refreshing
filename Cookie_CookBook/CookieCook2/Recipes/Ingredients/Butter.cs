namespace CookieCook2.Recipes.Ingredients;

public class Butter : Ingredient
{
    public override int Id => 3;
    public override string Name => "Butter";
    public override string PreparationInstructions => "Melt on low heat. Add to other ingredients.";
}
//A recipe is simply a wrapper for a collection of Ingredients
