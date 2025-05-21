namespace CookieCook2.Recipes.Ingredients;

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
}
//A recipe is simply a wrapper for a collection of Ingredients
