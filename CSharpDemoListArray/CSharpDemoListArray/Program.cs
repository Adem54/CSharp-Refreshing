// See https://aka.ms/new-console-template for more information
using CSharpDemoListArray.DataAccess;
using DataAccess;
using System.Diagnostics;
using System;

var stopwatch = Stopwatch.StartNew();
for (int i=0; i<1000; ++i)
{
    Console.WriteLine($"Loop number {i}");
}

stopwatch.Stop();
Console.WriteLine("Time in ms: "+ stopwatch.ElapsedMilliseconds);
/*
 Dizilerin boyutu sabittir ve dizilere yeni element ekleme veya herhangi bir elementi silme yapamiyoruz...Ancak yeni element eklerken yeni bir dizi olustururuz...eski diziyi yeni diziye kopyalaraiz ve yeni elemani da dahil ederiz ya da cikaracagimz zaman da ayni mantikta yeni bir dizi olusturarak eski dizi icinde cikarmak istedgimzi yeni dizzi de almayiz..bu sekilde ve cok zahmetlidir..bundan dolayi diziler sadece kolesiyonumuzun, boyutu onceden belli oldugu durumlarda kullanislidir..
Dizilerde dimention, farkli boyutlarda kullanabiliyoruz...
Yani ornegin bir ucgeni 2 boyutlu bir uzayda temsil ederken Point[3] points; koselerinin koordinatlarini 3 boyutlu bir dizide saklyarak yapabiliriz.(Point(0,1), Point(-1,0) Point(1,0)
If you're using two separate lists for x and y:
x_coords = [0, 4, 2]
y_coords = [0, 0, 3]
2. Chessboard (2D array of 8x8)
A chessboard has 8 rows and 8 columns. You can represent it using a 2D array:
chessboard = [
  ["R", "N", "B", "Q", "K", "B", "N", "R"],
  ["P", "P", "P", "P", "P", "P", "P", "P"],
  ["", "", "", "", "", "", "", ""],
  ["", "", "", "", "", "", "", ""],
  ["", "", "", "", "", "", "", ""],
  ["", "", "", "", "", "", "", ""],
  ["p", "p", "p", "p", "p", "p", "p", "p"],
  ["r", "n", "b", "q", "k", "b", "n", "r"]
]

Seating Chart (e.g. in a theater or airplane)
seats = [
  ["A1", "A2", "A3"],
  ["B1", "B2", "B3"]
]

 */
//List<string> myCities = new List<string>();
//myCities = ["Skien", "Porsgrunn"];

//myCities.Add("Larvik");
//myCities.Remove(myCities[0]);
//Console.WriteLine(myCities.Count);
//foreach (var item in myCities)
//{
//    Console.WriteLine(item);
//}


//var numbers = new List<int> { 1, 3, 5 };
//numbers.RemoveAt(0);

//var myNum = new[]{12,15};

//numbers.AddRange(myNum);
//Console.WriteLine(numbers.Count);


//var userInput = Console.ReadLine();

//bool isSuccess = int.TryParse(userInput, out var number);
//Console.WriteLine(number);


/*
 OOP kullanim amaclari
1-Kodu daha kolay yonetebilmek, daha kolay surdurulebilir kod halinde kontrolu elde tutmak
2-Reusable sekilde class lari kullanabilmek
3-Ozellikle buyuk ve uzun vadeli uygulamalarda, uygulamamiza musterilerden surekli yeni talepler ve yeni eklemeler gelecektir ve uygulama cok advance seviye ayni anda birden fazla davranisi gostermeisi gereken durumlar cok fazla oalcaktir...Boyle durumlari biz surekli kodumuzda degisiklik yaparak degil de kodumuz surekli olarak gelisime, ve buyumeye hazir, acik , ama degisime kapali..yani mumkun oldugunca degisime kapali olmalidir
Yani gelen her yeni talep de gidip if statmetler le kodumuzu spagetti kod haline getirerek uygulamamizi surdurmemiz zordur biryerde tikanabiliriz..Her bir kod degisikligi uzun zaman alan ve cok ugrastirabilir
OOP SAYESINDE requriementlar cok SIK DEGISMESINE KARSIN, KOLAYCA SISTEMIMIZI MODIFIYE EDEBILECEGIZ...

PROCEDURAL PROGRAMMING.. CAUSE
SPAGETTI CODE
NO WAY TO CONTROL WHO CAN ACCESS METHODS
NO SEPERATION BY LEVELS OF ABSTRACTION
CHANGES IN REQUIREMENTS ARE HARD TO IMPLEMENT
LOGIC IS NOT EASILY CONFIGURABLE

OOP-CLASS 
class bir sablon-blueprint-pattern dir..yani bir sablon, veya model cizilir ornegin ev sablonu cizilir sonra bu ev sablonuna gore
bir suru ev insa edilir..ama sablon ayni olmasina ragmen evlerin renkleri farkli olabilir, ve bazi temel ozellikler de farkliliklar olabilir ama sablon aynidir..ayni sablondan cikar temelde...iste gercek hayat taki problemlere  cozum icin kullanacagimz icin class lari ve o class lardan olusacak olan instanceleri..bizim dogru anlamamiz gerekir


easy maintain, reuse, modify 
flexible, can adjust


Encapsulation
Polymorphism
Abstraction
Inheritance
 

DateTime is a struct not a class in C#
 */

//var internationPizzaDay = new DateTime(2025, 2, 9);

//Console.WriteLine(internationPizzaDay.Subtract(new DateTime(2025, 1, 19)));

//Console.WriteLine(internationPizzaDay.Year);
//Console.WriteLine(internationPizzaDay.Month);
//Console.WriteLine(internationPizzaDay.Day);
//Console.WriteLine(internationPizzaDay.DayOfWeek);//Hangi gue geldgini gosteriyor...

/*
 Abstraction
What is Abstraction in C# / OOP?
Abstraction means showing only the essential features of an object and hiding the internal details.

A class is a blueprint or model.

From this blueprint, we can create multiple objects (instances).

These objects expose what they can do, but not how they do it.

➤ So yes — users of the object see what it does, but not how it works inside.
That’s the heart of abstraction.
In C#, we use classes as blueprints or models to define what an object is and what it can do.
When we create an object (an instance) from a class, we are creating a specific version of that model.

Through abstraction, the outside world can use the object (the instance) without knowing how it is implemented internally.

The user of the object only sees the public methods and properties — not the internal code, logic or complexity behind them.
 

Example (Real-world analogy):
Imagine a coffee machine:

You press a button: ☕️

It gives you coffee.

You don’t need to know how the water heats up, how the pressure works, etc.

That's abstraction:

You use it — without seeing how it works inside.

Public interface leri vardir bir class in yani aslinda demek istedigmz su ornegin 
bir kahve makinesinin farkli kahve turlerini hazirlamak icin butonlari vardir, ve sicak su doldurmak icin butonlari vardir.. 
bu kahve makinesi gelistirilir ama ana kullanilan ozellikler, genel ozellikler degismez, ekstra yeni ozellikler gelir ve mevcut ozelllikler de daha advance seviyede kullaniciya sunulur ama kahve makinesi her zaman farkli farkli kahveler sunmaya devam edecektir ana ozellilkeri itibari ile

 */
//var rectangle1 = new Rectangle();
//Console.WriteLine(rectangle1.width);//Warning Rectangle.width is never assigned to , and will always have its default value...we can not use unitinalized values...in C#

//Console.ReadKey();

//class Rectangle
//{
//    public int width;//
//    int? height;
//    //Burda su anda initialize etmiyhoruz yani declearation var ama herhangi bir deger atamasi  yok...
//    public Rectangle()
//    {

//    }
//}

//C# da biz bir degiskeni, variable i eger initialize etmeden yani deger atamsi yapnadan kullanmak istersek o zaman compile error hatasi aliriz...ama C# da biz atama yapmasak bile kendisi otomatik olarak default bir deger atayacaktir

//Dog dog = new Dog("Lucky", "germen shepherd", 40);
//Console.WriteLine(dog.Describe());

var person1 = new Person("Adam", 1984)
{
    Name = "Johnson",
    YearOfBirth = 1981
};

//person1.YearOfBirth = 1983;//error

//var rectangle = new Rectangle(3,6);

//Console.WriteLine(rectangle.LongDescription);

//var person2 = new Person();
//person2.Name = "John";
//person2.YearOfBirth = 1981;

var myRectangle1 = new MyRectangle(5, 4);
var myRectangle2 = new MyRectangle(5, 4);
var myRectangle3 = new MyRectangle(5, 4);
Console.WriteLine($"Count of Rectangle objects is : {MyRectangle.CountOfInstances}");
/*
 Hello, World!
Count of Rectangle objects is : 3
 */


var names = new Names();
var path = new NamesFilePathBuilder().BuildFilePath();
var stringsTextualRepository = new StringTextualRepostory();
if(File.Exists(path))
{
    Console.WriteLine("Name file already exists. Loading names.");
    var stringsFromFile = stringsTextualRepository.Read(path);
    names.AddNames(stringsFromFile);
    //names.ReadFromTextFile();
}else
{
    Console.WriteLine("Names file does not yet exist.");

    names.AddName("John");
    names.AddName("not a valid name");
    names.AddName("Claire");
    names.AddName("123 definitely not a valid name");

    Console.WriteLine("Saving names to a file");
    stringsTextualRepository.Write(path, names.All);
    //Even if it doesn't have a setter, it can still be modified from outside of the Names class.
    //The lack of a setter only prevents us from assigning it a new value
    //names.WriteToTextFile();
}

Console.WriteLine(new NamesFormatter().Format(names.All));


Console.ReadKey();
