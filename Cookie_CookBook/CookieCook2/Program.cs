// See https://aka.ms/new-console-template for more information

using CookieCook2.App;
using CookieCook2.DataAccess;
using CookieCook2.FileAccess;
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