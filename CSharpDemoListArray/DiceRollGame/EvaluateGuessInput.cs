using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static DiceRollGame.GameMessenger;

namespace DiceRollGame
{
    public class EvaluateGuessInput
    {
        /*
         *6- func nanmes are inconvinent...and SINGLE RESPONSIBILITY Now change this class to only evaluate logic, and return a GuessResult: Handle output in the controller / game loop NOT HERE!!!!
         *
        const string INCORRECT_INPUT = "Incorrect input";
        const string YOU_WIN = "You win";
        const string WRONG_NUMBER = "Wrong number";
        const string YOU_LOSE = "You lose!";

        public void Evaluate(bool success, ref int _index, GenerateRandomNumber generateRandomNumber , int result, ref bool _isGameContinue)
        {
            if (!success)//input is not number
            {
                Console.WriteLine(INCORRECT_INPUT);
            }
            else
            {
                
                ApplyInCaseIsInputNumber(generateRandomNumber.RandomNumber, result,ref _index,ref _isGameContinue);
            }
        }

        private void InCaseRandomNumberIsNotMatch( int _index,ref bool _isGameContinue)
        {
            Console.WriteLine(WRONG_NUMBER);
            if (_index == 3)
            {
                Console.WriteLine(YOU_LOSE);
                _isGameContinue = false;

            }
        }

        private void InCaseRandomNumberIsMatch(ref bool _isGameContinue)
        {
            Console.WriteLine(YOU_WIN);
            _isGameContinue = false;
        }

        private void ApplyInCaseIsInputNumber(int generatedNumber, int result, ref int _index,ref bool _isGameContinue)
        {
            _index++;
            if (generatedNumber == result)
            {
                InCaseRandomNumberIsMatch(ref _isGameContinue);
            }
            else
            {
                Console.WriteLine($"index: {_index}");
                //if result and randomnumber don't match
                InCaseRandomNumberIsNotMatch(_index, ref _isGameContinue);

            }
        } */

        public GuessResult Evaluate(bool success, ref int guessCount, int generatedNumber, int userInput)
        {
            guessCount++;

            Console.WriteLine($"guessCount: {guessCount}");
            if (!success)
            {
                return GuessResult.InvalidInput;
            }

            if (generatedNumber == userInput)
            {
                return GuessResult.Win;
            }

            if (guessCount >= 3)
            {
                return GuessResult.Lose;
            }
            return GuessResult.TryAgain;
        }

    }
}
