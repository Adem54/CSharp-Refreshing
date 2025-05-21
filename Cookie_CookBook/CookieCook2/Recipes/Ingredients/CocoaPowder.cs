namespace CookieCook2.Recipes.Ingredients;

public class CocoaPowder : Ingredient
{
    public override int Id => 8;
    public override string Name => "Cocoa powder";
    // Uses default PreparationInstructions — no override needed
}
//A recipe is simply a wrapper for a collection of Ingredients
