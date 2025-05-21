namespace CookieCook2.Recipes.Ingredients;

public class Sugar : Ingredient
{
    public override int Id => 5;
    public override string Name => "Sugar";
    // Uses default PreparationInstructions — no override needed
}
//A recipe is simply a wrapper for a collection of Ingredients
