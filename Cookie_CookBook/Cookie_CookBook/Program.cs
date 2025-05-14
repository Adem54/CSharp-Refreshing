// See https://aka.ms/new-console-template for more information

RecipeManager recipeManager = new RecipeManager();
recipeManager.Run();


Console.ReadKey();
public abstract class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty ;

    protected Ingredient(int id, string name, string description)
    {
        Id = id ;
        Name = name ;
        Description = description ;
    }

}

public class WheatFlour:Ingredient
{
    public WheatFlour() : base(1, "Wheat flour", "Sieve. Add to other ingredients.\r\n")
    {
        
    }
}
public class CoconutFlour : Ingredient
{
    public CoconutFlour() : base(2, "Coconut flour", "Sieve. Add to other ingredients.\r\n")
    {
        
    }
}
public class Butter : Ingredient
{
    public Butter() : base(3, "Butter", "Melt on low heat. Add to other ingredients.\r\n")
    {
        
    }
}
public class Chocolate : Ingredient
{
    public Chocolate():base(4, "Chocolate", "Melt in a water bath. Add to other ingredients.\r\n")
    {
        
    }
}
public class Sugar : Ingredient
{
    public Sugar() : base(5, "Sugar", "Add to other ingredients.\r\n")
    {
        
    }
}
public class Cardamon : Ingredient
{
    public Cardamon() : base(6, "Cardamon", "Take half a teaspoon. Add to other ingredients.\r\n")
    {
        
    }
}
public class Cinnamon : Ingredient
{

    public Cinnamon() : base(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.\r\n")
    {
        
    }
}

public class CocoaPowder : Ingredient
{
    public CocoaPowder() : base(8, "Cocoa powder", "Add to other ingredients.\r\n")
    {
        
    }
}

//What Recipe class does?
//1-AddIngredient in RecipeList, have own id, and description about the added ingredient
public class Recipe
{
    public static int RecipeNo;
    public List<Ingredient> Ingredients = new List<Ingredient>();

    public Recipe()
    {
        RecipeNo++;//tell intstance number..
    }

    //It must be here because every time user key the number, it add a new ingredient to the current recipe..so it is relevant
    public void AddIngredient(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }

    //Description of Recipe...
    public string Description(Ingredient ingredient)
    {
        return $"Added {ingredient}";
    }
}


//What RecipeBuilder class 
//1-Build or create a new recipe 
//2-Get users input value and add ingredient the currentrecipe til user click the any key aside from a number...
//3-Show the all ingredients...before we 

public class RecipeBuilder
{
   

    public void Create()
    {

    }

}

public class RecipeManager
{
    private List<Ingredient> _availableIngredients = new List<Ingredient>();

    public RecipeManager()
    {
        _availableIngredients = new List<Ingredient>
        {
            new WheatFlour(),
            new CoconutFlour(),
            new Butter(),
            new Chocolate(),
            new Sugar(),
            new Cardamon(),
            new Cinnamon(),
            new CocoaPowder(),
        };
    }
    public void Run()
    {
        //Check if there is a .txt or .json file content...first 
        //if there is no recipe before just start here 
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _availableIngredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }

        Console.WriteLine("Add an ingredient by it's Id or type anything else if finished.");

    }
}

public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result=0;

        do
        {

            Console.WriteLine(result);
            //display a message
            Console.WriteLine(message);
        }
        while ((int.TryParse(Console.ReadLine(), out result)));
        Console.WriteLine("Recipe added:");
        return result;
    }
}