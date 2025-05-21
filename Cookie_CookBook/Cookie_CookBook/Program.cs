// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Nodes;
const string FileName = "recipes";
//const FileFormat fileFormat = FileFormat.Json;
const FileFormat fileFormat = FileFormat.Txt;
string fileURL = $"{FileName}.{fileFormat.ToString().ToLower()}";
StringsTextualRepository stringTextualRepostory = fileFormat switch
{ 
    FileFormat.Json => new JsonFileRepo(),
    FileFormat.Txt => new TxtFileRepo(),
    _ => throw new NotSupportedException()
};



Recipe recipe = new Recipe();
RecipeManager recipeManager = new RecipeManager(recipe, stringTextualRepostory, fileURL);
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

    public override string ToString()
    {
        return $"{Name}. {Description}";
    }

}

public class WheatFlour:Ingredient
{
    public WheatFlour() : base(1, "Wheat flour", "Sieve. Add to other ingredients.")
    {
        
    }
}
public class CoconutFlour : Ingredient
{
    public CoconutFlour() : base(2, "Coconut flour", "Sieve. Add to other ingredients.")
    {
        
    }
}
public class Butter : Ingredient
{
    public Butter() : base(3, "Butter", "Melt on low heat. Add to other ingredients.")
    {
        
    }
}
public class Chocolate : Ingredient
{
    public Chocolate():base(4, "Chocolate", "Melt in a water bath. Add to other ingredients.")
    {
        
    }
}
public class Sugar : Ingredient
{
    public Sugar() : base(5, "Sugar", "Add to other ingredients.")
    {
        
    }
}
public class Cardamon : Ingredient
{
    public Cardamon() : base(6, "Cardamon", "Take half a teaspoon. Add to other ingredients.")
    {
        
    }
}
public class Cinnamon : Ingredient
{

    public Cinnamon() : base(7, "Cinnamon", "Take half a teaspoon. Add to other ingredients.")
    {
        
    }
}

public class CocoaPowder : Ingredient
{
    public CocoaPowder() : base(8, "Cocoa powder", "Add to other ingredients.")
    {
        
    }
}

//What Recipe class does?
//1-AddIngredient in RecipeList, have own id, and description about the added ingredient
public class Recipe
{
    public static int RecipeNo;
    private List<Ingredient> _ingredients = new ();

    public Recipe()
    {
        RecipeNo++;//tell intstance number..
    }

    //It must be here because every time user key the number, it add a new ingredient to the current recipe..so it is relevant
    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    //Description of Recipe...
    public bool HasIngredients => _ingredients.Count > 0;

    public IEnumerable<Ingredient> GetIngredients() => _ingredients;
    public override string ToString()
    {
        return string.Join(Environment.NewLine, _ingredients.Select(i=>i.ToString()));
    }
}

public static class IngredientFactory
{
    public static List<Ingredient> CreateDefaultIngredients() => new()
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamon(),
        new Cinnamon(),
        new CocoaPowder()
    };
}


public class RecipeManager
{

    private readonly List<Ingredient> _availableIngredients = new();
    private Recipe _recipe;
    private StringsTextualRepository _repository;
    private string _fileURL;

    public RecipeManager(Recipe recipe, StringsTextualRepository stringsTextualRepository, string fileURL )
    {
        _availableIngredients = IngredientFactory.CreateDefaultIngredients();

        _recipe = recipe;
        _repository = stringsTextualRepository;
        _fileURL = fileURL;
    }
    public void Run()
    {
        //Check if there is a .txt or .json file content...first 
        List<string> strIds = new List<string>();
        string existingData = "";

        strIds = _repository.Read(_fileURL);
        //show existing recipies
        this.ShowRecipes(strIds);

        Console.WriteLine("\r");
        //if there is no recipe before just start here 
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        ShowAvailableRecipes();

        string message = "Add an ingredient by it's Id or type anything else if finished.";
        int result;

        while (true)
        {
            Console.WriteLine(message);
            if ((int.TryParse(Console.ReadLine(), out result)))
            {
                //number
                FindAndAddIngredientToRecipe(result);
                
            }else
            {
                //not number
                if(_recipe.HasIngredients)
                {
                    
                    Console.WriteLine("Recipe added:");
                    List<int> recipeIds = new List<int>();
                    //show current-recipe and add recipe's ingredient ids in a list...
                    ShowRecipeAndAddIds(recipeIds);

                    // Les eksisterende data eller start med tom liste
                    List<string> allData;
                    var isFileExist = FileManager.CheckFileExist(_fileURL);
                    if (isFileExist)
                    {
                       var isContentExist = FileManager.CheckFileContent(_fileURL);
                        if(!isContentExist)
                        {
                            allData = new List<string>();
                        }else
                        {
                            //if the file is .txt ...what will happen
                            allData = _repository.Read(_fileURL);
                        }
                    }
                    else
                    {
                        allData = new List<string>();
                      
                    }

                    //convert all data to string array  and write in file
                    string stringifiedList = string.Join(",", recipeIds);
                    allData.Add(stringifiedList);
                    _repository.Write(_fileURL, allData);
                 
                }
                break;
            }
        }

    }

    private void FindAndAddIngredientToRecipe(int result)
    {
        //number
        var findIngredient = _availableIngredients.Find(ingredient => ingredient.Id == result);
        //IF ID IS NOT FOUND,RETURN DEFAULT VALUE OF INGREDIENT IS NULL...
        //Console.WriteLine(JsonSerializer.Serialize(findIngredient));
        if (findIngredient is not null)
        {
            _recipe.AddIngredient(findIngredient);
        }
    }
    private void ShowRecipes(List<string> strIds)
    {
        for (var index = 0; index < strIds.Count; index++)
        {
            var ids = strIds[index];
            var recipeIdList = ids.Split(",");
            Console.WriteLine($"**** {index + 1}  ****");
            foreach (var id in recipeIdList)
            {
                var FindIngredient = _availableIngredients.Find(ingredient => ingredient.Id == int.Parse(id));
                if (FindIngredient is not null)
                {
                    Console.WriteLine($"{FindIngredient.Name} {FindIngredient.Description}");

                }
            }
        }
    }

    private void ShowAvailableRecipes()
    {
        foreach (var ingredient in _availableIngredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }
    }

    private void ShowRecipeAndAddIds(List<int> recipeIds)
    {
        foreach (var item in _recipe.Ingredients)
        {
            Console.WriteLine($"{item.Name}. {item.Description}");
            recipeIds.Add(item.Id);

        }
    }
}

public static class ConsoleReader
{
    public static int? ReadInteger(string message)
    {
        int result = 0;

        do
        {

            //Console.WriteLine(result);
            if(result != 0)
            {

            }
            //display a message
            
            Console.WriteLine(message);
        }
        while ((int.TryParse(Console.ReadLine(), out result)));
        Console.WriteLine("Recipe added: ");
        return result;
    }
}

public enum FileFormat
{
    Json,
    Txt
}

public interface IStringsTextualRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> idS);
}

public abstract class StringsTextualRepository : IStringsTextualRepository
{
    private static readonly string Seperator = Environment.NewLine;


    public abstract List<string> Read(string filePath);


    public abstract void Write(string filePath, List<string> idS);

}

public class JsonFileRepo : StringsTextualRepository
{
    public override List<string> Read(string filePath)
    {
        List<string> strIds = new List<string>();
        var isFileExist = FileManager.CheckFileExist(filePath);
        if (isFileExist) 
        {
            var existingData = File.ReadAllText(filePath);
            strIds = JsonSerializer.Deserialize<List<string>>(existingData) ?? new List<string>();
        }
        return strIds;
    }

    public override void Write(string filePath, List<string> idS)
    {
        string JsonString = JsonSerializer.Serialize(idS);
        Console.WriteLine($"JsonString: {JsonString}");
        File.WriteAllText(filePath, JsonString);
    }
}

public class TxtFileRepo : StringsTextualRepository
{
    public override List<string> Read(string filePath)
    {
        var isFileExist = FileManager.CheckFileExist(filePath);
        List<string>  strIds = isFileExist ? File.ReadAllLines(filePath).ToList() : new List<string>();
        return strIds;
    }

    public override void Write(string filePath, List<string> ids)
    {
        File.WriteAllLines(filePath, ids);

    }
}

public static class FileManager
{
    public static bool CheckFileExist(string filePath)
    {
        if(File.Exists(filePath))
        {
            Console.WriteLine("File exist");
            return true;


        }else
        {
            return false;
        }

    }

    public static bool CheckFileContent(string filePath)
    {
        string content = File.ReadAllText(filePath);
        if (!string.IsNullOrWhiteSpace(content))
        {
            Console.WriteLine("File has content");
            return true;

        }
        else
        {
            Console.WriteLine("⚠️ File is empty.");
            return false;
        }
    }
}