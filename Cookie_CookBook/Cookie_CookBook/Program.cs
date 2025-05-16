// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using System.Text.Json.Nodes;
const string FileName = "recipes";
const FileFormat fileFormat = FileFormat.Json;


Recipe recipe = new Recipe();
RecipeManager recipeManager = new RecipeManager(recipe);
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
    const string FileName = "recipes";
  //  const FileFormat fileFormat = FileFormat.Json;
    const FileFormat fileFormat = FileFormat.Txt;
    private List<Ingredient> _availableIngredients = new List<Ingredient>();

    private Recipe _recipe;

    public RecipeManager(Recipe recipe)
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

        _recipe = recipe;
    }
    public void Run()
    {
        //Check if there is a .txt or .json file content...first 
        string fileURL = "";
        List<string> strIds = new List<string>();
        string existingData = "";

        var isFileExist = false;

        switch (fileFormat)
        {
            case FileFormat.Json:
                fileURL = $"{FileName}.json";

                existingData = File.ReadAllText(fileURL);
                strIds = JsonSerializer.Deserialize<List<string>>(existingData) ?? new List<string>();
                break;

            case FileFormat.Txt:
                fileURL = $"{FileName}.txt";
                isFileExist = FileManager.CheckFileExist(fileURL);
                strIds = isFileExist ? File.ReadAllLines(fileURL).ToList() : new List<string>();
                break;
        }
        
       


        for (var index=0; index<strIds.Count; index++)
        {
            var ids = strIds[index];
            var recipeIdList = ids.Split(",");
            Console.WriteLine($"**** {index+1}  ****");
            foreach (var id in recipeIdList)
            {
                var FindIngredient = _availableIngredients.Find(ingredient => ingredient.Id == int.Parse(id));
                if(FindIngredient is not null)
                {
                    Console.WriteLine($"{FindIngredient.Name} {FindIngredient.Description}");

                }
            }
        }

        Console.WriteLine("\r");
        //if there is no recipe before just start here 
        Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _availableIngredients)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }

        //        Console.WriteLine("Add an ingredient by it's Id or type anything else if finished.");

        string message = "Add an ingredient by it's Id or type anything else if finished.";

        int result;

        while (true)
        {
            Console.WriteLine(message);
            if ((int.TryParse(Console.ReadLine(), out result)))
            {
                //number
                var findIngredient = _availableIngredients.Find(ingredient=>ingredient.Id == result);
                //IF ID IS NOT FOUND,RETURN DEFAULT VALUE OF INGREDIENT IS NULL...
                //Console.WriteLine(JsonSerializer.Serialize(findIngredient));
                if(findIngredient is not null)
                {
                    _recipe.AddIngredient(findIngredient);
                }
                
            }else
            {
                //not number
                if(_recipe.Ingredients.Count > 0)
                {
                    
                    Console.WriteLine("Recipe added:");
                    Console.WriteLine($"Recipe no: {Recipe.RecipeNo}");
                    List<int> recipeIds = new List<int>();
                    foreach (var item in _recipe.Ingredients)
                    {
                        Console.WriteLine($"{item.Name}. {item.Description}");
                        recipeIds.Add(item.Id);
                    }
                
                    
                    // Les eksisterende data eller start med tom liste
                    List<string> allData;
                    if (isFileExist)
                    {
                       var isContentExist = FileManager.CheckFileContent(fileURL);
                        if(!isContentExist)
                        {
                            allData = new List<string>();
                        }else
                        {
                            //if the file is .txt ...what will happen
                            
                            string existingJson ;
                            switch (fileFormat)
                            {
                                case FileFormat.Json:
                                    existingJson = File.ReadAllText(fileURL);
                                    allData = JsonSerializer.Deserialize<List<string>>(existingJson) ?? new List<string>();

                                    break;

                                case FileFormat.Txt:
                                   
                                    //existingData = File.ReadAllText(fileURL);
                                    allData = File.ReadAllLines(fileURL).ToList() ?? new List<string>();
                                    
                                    break;
                            }
                        }
                    }
                    else
                    {
                        allData = new List<string>();
                      
                    }


                    string stringifiedList = string.Join(",", recipeIds);
                    Console.WriteLine($"allData!!!! {JsonSerializer.Serialize(allData)}");
                    Console.WriteLine($"stringifiedList: {stringifiedList}");

                    switch (fileFormat)
                    {
                        case FileFormat.Json:
                            JsonFileRepo jsonFileRepo = new JsonFileRepo();
                            
                            // Legg til den nye strengen
                            allData.Add(stringifiedList);
                            jsonFileRepo.Write(fileURL, allData);

                            break;

                        case FileFormat.Txt:

                            TxtFileRepo txtFileRepo = new TxtFileRepo();
                            allData.Add(stringifiedList);

                            txtFileRepo.Write(fileURL, allData);


                            break;
                    }
                }
                break;
            }
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

public abstract class StringsTextualRepository
{
    private static readonly string Seperator = Environment.NewLine;


    public abstract List<string> Read(string filePath);
    //{
    //    //var fileContents = File.ReadAllText(filePath);
    //    //var namesFromFile = fileContents
    //    //    .Split(Seperator, StringSplitOptions.RemoveEmptyEntries)
    //    //    .ToList();
    //    //return namesFromFile;  // List<string>
    //}

    public abstract void Write(string filePath, List<string> idS);
    //{
    //    //var textToBeSaved = string.Join(Environment.NewLine, names);
    //    //File.WriteAllText(filePath, textToBeSaved);
    //}
}

public class JsonFileRepo : StringsTextualRepository
{
    public override List<string> Read(string filePath)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
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