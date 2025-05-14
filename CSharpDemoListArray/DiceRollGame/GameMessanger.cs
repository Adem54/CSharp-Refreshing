using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame
{
        public class GameMessenger
        {

          
        public void PrintMessage(GuessResult result, ref bool isGameContinue, int? correctNumber = null)
            {
                switch (result)
                {
                    case GuessResult.InvalidInput:
                        Console.WriteLine("Invalid input. Please enter a number.");
                        break;
                    case GuessResult.Win:
                        Console.WriteLine("🎉 You win!");
                        isGameContinue = false;
                        break;
                    case GuessResult.Lose:
                        Console.WriteLine($"😢 You lose! The correct number was {correctNumber}");
                        isGameContinue = false;

                        break;
                    case GuessResult.TryAgain:
                        Console.WriteLine("Wrong number. Try again!");
                        break;
                }
            }
        }

    }

