//Console.WriteLine("Hello, World!");
//This make the execution console wait until we press a key
/*
 1-Compilation from .cs to *.dll(0010101010,001010101011,...)
from human readable source code to computer readable files...
Built menusunde CleanSolution dersek Run yaptigimzda olusturulan , compile edildginde olusturulan dosyalari siler
TodoList.csproj-> dosyasi projeyi temsil eder 
Program.cs, bin/Debug/.Net8/ bu klasor alti proje ilk olusturuldugunda bostur..ve projeyi run ettgimzde compile islemi gerceklesir  ya da menu de built ten built solution yaparsak bin altindaki .net8 klasor altina .json, .exe, pdb, .dll uzantili dosyalar geldigni gorebilriz iste bnlarin hepsi compile isleminde sonra geliyor..., .exe dosyasi ile artik executable, yani calistirilabilir bir uygulama haline gelmis oluyor... .exe uzantili dosya dogrudan uzerine tiklanarak calistirilabilir..Bu .exe nin calismasi icin vstudio ya ihtiyac yok 
.dll -> Dynamic Link Library...Bu bizim kodumuz bilgisayarin anlayacagi haline donusmus formatidir...
.exe dosyasi .dll dosyasini kullanir..Biz eger .dll i silersek , artik .exe de calismayacaktir..Her turlu C# projesi .dll dosyasi olusturmak icin compile edilir
, obj folders
 */

/*
 Hello!
What do you want to do?

[S]ee all TODOs
[A]dd a TODO
[R]emove a TODO
[E]xit
 */

/*
 Debugging yaparken degub esnasinda kod satirinin bir kismini secip o kismin degerini gorebiliriz 
Shift+ F9 ile...
 */
/*
1.si C# dilinin cok iyi bilinmesi gereken alanlarindan bir tanesi...C# static type oldugundan dolayi bu static type olmasi 
cok ciddi ileri seviyede type lar ile ilgili hazir methodlarin yanindan getiriyor...
Dolayisi ile... 


 
 */
using System.Threading.Channels;
using TodoList;

var city = "SKIEN";//implicitly typed variable...compiler does 
                   //Console.WriteLine(city);
                   //Console.ReadLine();


foreach(var item in city)
{
    Console.WriteLine($"item!!: {item}");
    if(Char.IsUpper(item))
    {

    }
}

bool result = city.All(c=>char.IsUpper(c));
Console.WriteLine($"result ; {result}");

MyList<string> list = new MyList<string>();
list.Add("Skien");
list.Add("Porsgrunn");

foreach (var item in list.MyItems)
{
    Console.WriteLine("item: " + item);
}

Console.WriteLine("Press enter to close...");
Console.ReadLine();

//string? Operation2 = Console.ReadLine();

//EGer kullanici integer girerse o string olarak gelir ki biz onu integere 

/*
int myNum = int.Parse(Operation2);
if(int.TryParse(Operation2, out int result))
{

}
*/




//comes all the time string...even if
/*
Todo myTodo = new Todo();
string? Operation = myTodo.ShowOperations();
myTodo.ApplyCommandOrder(Operation);

public class Todo
{
    public List<string> Operations { get; set; }    
    public List<string>? Todos { get; set; }
    public Todo()
    {
        Operations = new List<string>()
        {
            "[S]ee all TODOs",
            "[A]dd a TODO",
            "[R]emove a TODO",
            "[E]xit"
        };

        Todos = new List<string>(); // Initialize Todos


    }

    public string? ShowOperations()
    {
        Console.WriteLine("");
        Console.WriteLine("What do you want to do?\r\n");
        foreach (var operation in Operations)
        {
            Console.WriteLine(operation);
        }

        string? Operation = Console.ReadLine();
       return Operation;
    }
    
    public void ShowAllTodos()
    {
        if(Todos != null) 
        {
            if (Todos.Count == 0)
            {
                Console.WriteLine("There is no todo so far!\r\n");
            }
            else
            {
                foreach (var operation in Todos)
                {
                    Console.WriteLine(operation);
                }
            }
        }else
        {
            Console.WriteLine("There is no todo so farrrr!\r\n");
        }


        string? Operation = ShowOperations();
        ApplyCommandOrder(Operation);
    }

    public void AddNewTodo()
    {
        Console.WriteLine("Enter the TODO description\r\n");
        string? NewTodo = Console.ReadLine();
        /*
        if (NewTodo != null)
        {
            if (Todos != null)
            {
                int NumberOfTodo = Todos.Count + 1;
                NewTodo = $"{NumberOfTodo}. {NewTodo}";
                Todos.Add(NewTodo);
            }
               

        } */
/*
        if(!string.IsNullOrEmpty(NewTodo))
        {
            if (Todos != null)
            {
                int NumberOfTodo = Todos.Count + 1;
                NewTodo = $"{NumberOfTodo}. {NewTodo}";
                Todos.Add(NewTodo);
            }
        }

        string? Operation = ShowOperations();
        ApplyCommandOrder(Operation);

    }


    public string? getInputValue()
    {
        string? Command = Console.ReadLine();
        if(Command is null)
            return null;
        return Command;
    }
    
    public void RemoveTodo()
    {
        Console.WriteLine("Just write down the todo you want to remove");
        string? Todo = Console.ReadLine();
        if(!string.IsNullOrEmpty(Todo))
        {
            Console.WriteLine($"{Todo} is not null or empty");
            Console.WriteLine((Todos == null));
            Console.WriteLine(Todos?.Contains(Todo));
            if (Todos is not null && Todos.Contains(Todo))
            {
                Console.WriteLine($"\n'{Todo}' found in the list. Removing it...");
                Todos.Remove(Todo);
            }
        }

        string? Operation = ShowOperations();
        ApplyCommandOrder(Operation);
    }

    public void ApplyCommandOrder(string? Command)
    {
        switch (Command)
        {
            case "S":
                ShowAllTodos();
                break;
            case "A":
                AddNewTodo();

                break;
            case "R":
               
                RemoveTodo();

                break;
            case "E":
                Console.WriteLine("Exiting the application...");
                Environment.Exit(0);
                break;
            default:
                string? Operation = ShowOperations();
                ApplyCommandOrder(Operation);
                break;
        }

    }
}
/*
 Bool 

 
 */