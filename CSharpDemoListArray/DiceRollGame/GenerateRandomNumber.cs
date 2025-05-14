using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
    /*
     4-The GenerateRandomNumber class should only be responsible for generating numbers.

It should NOT be responsible for talking to the user (e.g., Console.WriteLine()).
    Separation of concerns means each class should focus on one task.

GenerateRandomNumber = generate numbers, not UI.

Console.WriteLine = user interface (UI) task, should happen in another class like a ConsoleMessenger or UIService.

    public GenerateRandomNumber()
{
    RandomNumber = _random.Next(1, 7);
    Console.WriteLine($"RandomNumber: {RandomNumber}"); // 🚫 breaks separation
    Console.WriteLine(INITIAL_TEXT);
}
    You are mixing:

Business logic (generating a number)

Presentation logic (printing to screen)

➡ It makes the class harder to test and reuse elsewhere.
     */
    public class GenerateRandomNumber
    {
        private static readonly Random _random = new Random();
        public int RandomNumber { get; set; }

        //public const string INITIAL_TEXT = "Dice rolled.  Guess what number it shows in 3 tries.";

        //public GenerateRandomNumber()
        //{
        //    RandomNumber = _random.Next(1, 7);
        //    Console.WriteLine($"RandomNumber: {RandomNumber}");
        //    Console.WriteLine(INITIAL_TEXT);
        //}
        /*
         * 5
         If you create two Random objects very quickly (in the same tick or very close ticks),

They both get almost the same seed.

Therefore, they generate the same or very similar random numbers.
        var rnd1 = new Random();
var rnd2 = new Random();

Console.WriteLine(rnd1.Next(1, 100));
Console.WriteLine(rnd2.Next(1, 100));
        42
42
private static readonly Random _random = new Random();

public int GenerateNumber()
{
    return _random.Next(1, 7);
}
 
         */

        public int GenerateNewNumber()
        {
            RandomNumber = _random.Next(1, 7);
            return RandomNumber;
        }
    }
}
