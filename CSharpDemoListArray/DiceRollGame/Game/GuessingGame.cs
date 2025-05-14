//First of all, this GuessingGame class needs to have a dice object that will be rolled at the beginning of the game
//Disardam GuessingGame class i icinde kullanilmasi gereken class lar, oncelikle static olabiliyorsa static yapilir..degil ise o zaman dependency injection ile GuessingGame class ina dahil edilir
using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game
{
    public class GuessingGame
    {
        private readonly Dice _dice;//Improvement-1(dependency inj) -readonly veririz cunku, Dice class i constructor da atanacak, baska birsey direk atanamasin hem bu class icinde hem de disardan...
        private const int InitalTries = 3;

        public GuessingGame(Dice dice)
        {
            _dice = dice;
        }

        //Improving-2.name Play fits ver well for real game

        //Improvement - 8 :Eger Play methodu bool-true-false win-loose return etmesini istersek o zaman bool return eden method lar in ismi de buna uygun olmalidir..Cunku bool xxx = guessingGame.Play(); boyle bir kullanim da yeni bir developer hicbirsey anlamaz...Yani yazilimci gidip de Play methodu ne imis bir gidp bakayi iceriigne demesi gerekecek bu da zaten bizim kodumuzun kalite sorunu, readability, clean..problemleri olddugunu gosterir..Bundan dolayi methyod ismi Play yerine IsGameWon(class hem play yapyor hem de result veriyor), PlayGameAndReturnResult(ama burda da true(victory-win)-false(loose) isimleri de olabilir ama bu isimler ikiside tam istedigmz neticeyi vermiyor, cunku victory, loose un yaninda biz bu oyunu, bir sonraki asamada esitlik olacak sekilde de oynamak isteyecegiz.... tie-esitlik de olabilir..bool ismizi gormuyor o zaman bizim kendi type imizi yani class imizi olusturmamiz gerekiyor

        //To represent a game's victory or loss, we can create an enumerated type, often called an enum
        //An enum type is a type, that defines a set of named constants
        //Ornegin sezonlari eger sistemimizde kullanacak olsa idik onlar icin Season enum i olusturabilirdik
        public GameResult Play()
        {
            var diceResult = _dice.Roll();
            Console.WriteLine(
                $"Dice rolled. Guess what number it shows in {InitalTries} tries.");//Improvement-3=>   3 is magic numer..it must be changed either const variable or , more flexiable field-parameter...ilerde bu 3 deneme 4,5 yapilmak istenirse ne yapacagiz gidip bu 3 un kullanildigi heryeri degistirecek miyiz...bu surdurulebilir degildir...

            //Improving-4. var index=0; baslatarak while icide index++ ile try- adedinin kontrol ederken index==InitialTries... yerine..triesLeft degisken ismi vererek, daha anlasilir hale getirmis oluyoruz...
            var triesLeft = InitalTries;
            while (triesLeft > 0)
            {
                var guess = ConsoleReader.ReadInteger("Enter a number:");
                if (guess == diceResult)
                {
                    //Play methodu Game in kazanilip kazanilmadigini donebilir true-false diye
                    return GameResult.Victory;
                }
                Console.WriteLine("Wrong number.");
                triesLeft--;
            }

            return GameResult.Loss;

        }

        public static void PrintResult(GameResult gameResult)
        {
            string message = "";

            message = gameResult == GameResult.Victory
                ? "You win!"
                : "You lose :(";

            Console.WriteLine(message);
        }
    }

}


