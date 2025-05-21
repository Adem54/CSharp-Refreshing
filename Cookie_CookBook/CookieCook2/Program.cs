// See https://aka.ms/new-console-template for more information

using CookieCook2.Recipes;
using CookieCook2.Recipes.Ingredients;
using System.Text.Json;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");
//!Burasi bildigmiz gibi Program class icinddeki Main methodun body sidir...
//Ve burasi ne idi hatirlayalimm..Console uygulamlarinin entry-pointi  yani burdan proje ayaga kalkiyordu
//Dolayisi ile projemizi baslatirken burdan new leyip cagirip run etmemiz gerekiyor

/*
1.Load recipes from a file	
2.Print existing recipes	
3.Ask user to create a new recipe	
4.Print available ingredients	
5.Let the user choose ingredients	
6.If user selects none: print a message and exit	
7.If user selects any:	
	Create a new recipe
	Add it to the existing recipes
	Save everything back to the file
	Print confirmation + recipe
8.Exit the app	
 
 */

const FileFormat Format = FileFormat.Json;
IStringRepostory stringRepostory1 = Format == FileFormat.Json ? new StringJsonRepostory() : new StringTextualRepostory();
IngredientsRegister ingredientsRegister = new IngredientsRegister();
const string FileName = "recipes";
var fileMetadata = new FileMetadata(FileName, Format);

StringTextualRepostory stringTextualRepostory = new StringTextualRepostory();
RecipesRepostory recipesRepostory1 = new RecipesRepostory(stringTextualRepostory, ingredientsRegister);
RecipesConsoleUserInteraction recipesConsoleUserInteraction1 = new RecipesConsoleUserInteraction(ingredientsRegister);
var cookiesRecipesApp = new CookiesRecipesApp(recipesRepostory1, recipesConsoleUserInteraction1);
cookiesRecipesApp.Run(fileMetadata.ToPath());

public enum FileFormat
{
    Json,
    Txt
}

public class FileMetadata
{
    public string Name { get; }
    public FileFormat Format { get; }

    public FileMetadata(string name, FileFormat fileFormat)
    {
        Name = name;
        Format = fileFormat;
    }

    public string ToPath() => $"{Name}.{Format.AsFileExtension()}";

}

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat)
    {
        //return fileFormat switch
        //{
        //    FileFormat.Json => "json",
        //    FileFormat.Txt => "txt",
        //    _ => throw new NotSupportedException()
        //};
        return fileFormat == FileFormat.Json ? "json" : "txt";
    }
}
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
//We have the high level design ready. 
//The implementation details are not yet defined, but the interface of those classes is..and it is more important than the details


//Dikkat edelim...interface imiz RecipesConsoleUserInteraction ile  ilgili herhangi bir sey soylemiyor bize..sadece user ile communication icin hangi methodlara ihtiyacimz var onlari bize veriyor...
public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> recipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

//I am not yet sure what this class will be doing exactly. So for now I will not create an interface it implements.
//We'll review it later to see if this design breaks the Dependency inversion principle.
//Let's use this class in the PromptToCreateRecipe method.
public class IngredientsRegister : IIngredientsRegister
{
    //Neden IEnumerable cunku, biz bu datayi sadece listleyecegiz modify etme, update etme vs gibi bir planmiz yok...
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
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

    public Ingredient GetById(int id)
    {
        //possible null referanse return in case if there is no data by this id....
        return All.FirstOrDefault(i => i.Id == id);
    }
    //Bu sekkile scann yapiliyor liste icinde tek tek ariyor ve ilk match olan i getiriyor...
    //Ama bu islem Dictionary ile daha hizli yapilabiliyor!!!
    /*
     Using Dictionary<int, Ingredient>
    private Dictionary<int, Ingredient> _ingredientById;

    public Ingredient? GetById(int id)
    {
        return _ingredientById.TryGetValue(id, out var ingredient) ? ingredient : null;
    }
    ✅ How it works:
    Ingredients are pre-indexed by their Id in a dictionary.
    TryGetValue retrieves the item directly by key.
    | Feature          | `FirstOrDefault` (List) | `Dictionary.TryGetValue`         |
| ---------------- | ----------------------- | -------------------------------- |
| **Performance**  | Slower (`O(n)`)         | Faster (`O(1)`)                  |
| **Simplicity**   | More concise to write   | Slightly more setup needed       |
| **Memory usage** | Low                     | Slightly higher (dictionary)     |
| **Best for**     | Small, fixed-size lists | Large or frequently queried data |
| **Flexibility**  | Search by any condition | Only search by ID (key)          |

    🧠 When to use which?
    | Situation                                              | Recommended                                                |
| ------------------------------------------------------ | ---------------------------------------------------------- |
| Less than 10–20 items, queried rarely                  | ✅ `FirstOrDefault` is fine                                 |
| Lots of items, queried frequently                      | ✅ Prefer `Dictionary`                                      |
| You need to search by **multiple fields**, not just ID | ❌ `Dictionary` won’t help → Use LINQ like `FirstOrDefault` |

    Eger elimizde tum liste var ise, o zaman Dictionaly listesini hemen doldurabiliriz... 

    You could build the dictionary once from the list:
    private readonly Dictionary<int, Ingredient> _ingredientById = All.ToDictionary(i => i.Id);
    🧠 What does “pre-indexed” mean?
    Before calling GetById(id), you've already organized (indexed) all ingredients into a Dictionary<int, Ingredient>.
    So instead of searching one-by-one each time, the Dictionary can instantly jump to the correct item using the id as a key.
    📦 Example:Let’s say you have a list of ingredients:
    var ingredients = new List<Ingredient>
    {
        new WheatFlour(),
        new Butter(),
        new Sugar()
    };
    Now you pre-index them by building a dictionary:
    private readonly Dictionary<int, Ingredient> _ingredientById =
    ingredients.ToDictionary(i => i.Id);
    🧠 What this does:
    Creates a map like:
    1 → WheatFlour  
    2 → Butter  
    3 → Sugar

    So when you later call:
    _ingredientById.TryGetValue(2, out var result);
    It goes straight to 2 → Butter without scanning.

    ⏱️ Why it’s fast
    Because dictionaries in .NET use a hash table internally. That means:
    Each key (like id) is hashed to find its storage location.
    Lookup is nearly instant — no looping through the entire collection.
     */
}

//Biraz daha bu class in ne islem yaptigi belli olsun diye class ismini RecipesUserINteraction dan RecipesConsoleUserInteraction
public class RecipesConsoleUserInteraction: IRecipesUserInteraction
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
            Console.WriteLine("Existing recipes are: "+ Environment.NewLine);
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
                if(selectedIngredient is not null)
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

public interface IRecipesRespostory
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);

    //IEnumerable veririz ki daha genel bir type vermis oluruz..implemente edilirken ihtiyac hangi type ile almak ise list, array..o tipe gore implemente edilebilr
}
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
            var id= int.Parse(textualId);
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

