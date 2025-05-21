namespace CookieCook2.Recipes;



public class Recipe
{
    //public List<Ingredient> Ingredients { get;  }
    public IEnumerable<Ingredient> Ingredients { get; }
    //get mehodu ile bile yapsak daha once konuystugmz gibi evet get methoud ile dogrudan Ingredients e bir atama yapilamiyor yani referans degisikligi soz konusu olmuyor ama referans type oldugu icin mutable yani icerigi degistirilebilir modify edilebilir...yani clear methodu  ile sifirlanabilir veya...icerisine List e ait metohdlardan Add...method lar kullanilarak modify edilebilir....
    //Biz Ingredient collection inin herhangi bir tarafindan modify edilmesini istemiyoruz bundan dolayi da type i List<Ingredient> dan,   IEnumerable interface IEnumerable<Ingredient> ile degistiririz..
    //IEnumerable is an interface that is implemented by almost every collection in C#
    //Generic types and mehtods are parameterized by types..
    //IEnumerable i secme sebeplerimzden biri de..The fact that IEnumerable doesn't have any methods for modifying the collection makes it perfect for expressing that we don't intend this collection to be modified
    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    /*
     It looks like we did not override the ToString method in the Recipe class.
    RESULT IS LIKE THAT:
           ***** 1 *****
    CookieCook2.Recipes.Recipe
    ***** 2 *****
    CookieCook2.Recipes.Recipe
    Press any key to close..DEFAULT IMPLEMNTASYON OLARAK GELIYOR TOSTRING IN DEFAULT U NAMESPACE LERLE BIRLIKTE FULLNAME OF CLASS I VERIYORDU

    The default implementation from the object type, the one that returns the name of the type has been used.
    Let's fix it.

    Let's look into the requirements.
    Printing the recipe is simply printing all its ingredients, including each ingredient's name and preparation instructions.
    So this is what I'm going to do.
    I'm going to iterate all the recipe ingredients in a loop.
    In this loop, I will build a string for each ingredient and add it to a list of strings.
    At the end of this method, I will join all those strings from this list with the new line symbol.
     */
    public override string ToString()
    {
        // return Ingredients.Select(i=>i.Name);

        //Normalde manuel olarak bu sekilde yapariz...ama 4-5 satirda yaptgimz bu isi LINQ sayesinde tek satirda yapabiliriz..
        //var steps = new List<string>();
        //foreach (var ingredient in Ingredients)
        //{
        //    steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");     
        //}

        //return string.Join(Environment.NewLine, steps);

        //ama 4-5 satirda yaptgimz bu isi LINQ sayesinde tek satirda yapabiliriz..
        return string.Join(Environment.NewLine, Ingredients.Select(i => $"{i.Name}.{i.PreparationInstructions}"));

    }
}

//Ingredient abstract olmali, cunku Ingredient basli basina somut bir base class degil, asil ingredient i inherit edecek olan, Sugar, Chocolate, Butter..bunlar somut ingredientler..bu Ingredient abstract base class tir...ve biz Ingredient adinda bir Ingredient olusturamayiz
public abstract class Ingredient
{
    //Simdi biz Id,Name olarak burda verecegimz herhangi bir default deger yok ondan dolayi abstract  yapariz ki her bir subclass-derived class kendi id,sini ve name ini kendi atasin
    public abstract int Id { get; }
    public abstract string Name { get; }

    //For some ingredients, like sugar or cocoa powder, there's nothing special you need to do to prepare them — you just add them in.So the default instruction — "Add to other ingredients" — is sufficient and makes sense for these simple ingredients.Therefore, subclasses like Sugar or CocoaPowder don’t need to override PreparationInstructions. They can inherit it as-is. But other type need more detailed instructions, they can override this property
    public virtual string PreparationInstructions => "Add to other ingredients";
    //REmember this defined a getter-only property
    //Yes this is a getter-only auto-property in C#, and it does exactly what a traditional getter method would do — but in a short, clean syntax.
    /*
     It's shorthand for 
        public virtual string PreparationInstructions
        {
            get { return "Add to other ingredients"; }
        }
     */

    public override string ToString()
    {
        return $"{Id}. {Name}";
    }
}

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions => "Sieve. Add to other ingredients.";
}

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions => "Take half a teaspoon. Add to other ingredients.";
}
//A recipe is simply a wrapper for a collection of Ingredients
