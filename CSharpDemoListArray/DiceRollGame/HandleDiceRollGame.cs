using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceRollGame.GameMessenger;

namespace DiceRollGame
{
    public class HandleDiceRollGame
    {
        private int _index = 0;
        private bool _isGameContinue = true;
        const string ENTER_NUMBER = "Enter number:";

        public HandleDiceRollGame()
        {
            
            /*
             * 1-Correction:HandleDiceRollGame runs the whole game inside the constructor, which violates SRP(Single Resp) and makes testing hard.
             Why this violates SRP(Single Resp):
            The constructor should only initialize the object, not run game logic.
            Now HandleDiceRollGame has two responsibilities:
            Representing/configuring the game
            Executing game logic / controlling the loop
             */
            //var generateRandomNumber = new GenerateRandomNumber();
            //var guessNumberInput = new GuessNumberInput();
            //while (_isGameContinue)
            //{
            //    Console.WriteLine(ENTER_NUMBER);
            //    guessNumberInput.GetInputData();
            //    bool success = int.TryParse(guessNumberInput.GuessInput, out int result);
            //    EvaluateGuessInput evaluateGuessInput = new EvaluateGuessInput();
            //    evaluateGuessInput.Evaluate(success, ref _index, generateRandomNumber, result, ref _isGameContinue);
            //}
        }
        public void Start() 
        {
            var generateRandomNumber = new GenerateRandomNumber();
            generateRandomNumber.GenerateNewNumber();
            Console.WriteLine($"RandomNumber: {generateRandomNumber.RandomNumber}");

            GameMessenger gameMessenger = new GameMessenger();
            Console.WriteLine("Dice rolled.  Guess what number it shows in 3 tries.");
            var guessNumberInput = new UserInputHandler();

            //2.This class handles both game flow and game loop logic.
            //while (_isGameContinue)
            //{
            //    Console.WriteLine(ENTER_NUMBER);
            //    guessNumberInput.GetInputData();
            //    bool success = int.TryParse(guessNumberInput.GuessInput, out int result);
            //    EvaluateGuessInput evaluateGuessInput = new EvaluateGuessInput();
            //    evaluateGuessInput.Evaluate(success, ref _index, generateRandomNumber, result, ref _isGameContinue);

            //}

            GameEngine(guessNumberInput, generateRandomNumber);

        }

        public void GameEngine(UserInputHandler guessNumberInput, GenerateRandomNumber generateRandomNumber)
        {
            while (_isGameContinue)
            {
                Console.WriteLine(ENTER_NUMBER);
                guessNumberInput.GetInputData();
                bool success = int.TryParse(guessNumberInput.GuessInput, out int parsedInput);
                EvaluateGuessInput evaluateGuessInput = new EvaluateGuessInput();
                /*evaluateGuessInput.Evaluate(success, ref _index, generateRandomNumber, parsedInput, ref _isGameContinue); */

                GuessResult result = evaluateGuessInput.Evaluate(success, ref _index, generateRandomNumber.RandomNumber, parsedInput);

                //Handle output in the controller....tha class that handle the result...
                GameMessenger gameMessenger = new GameMessenger();
                gameMessenger.PrintMessage(result, ref _isGameContinue, parsedInput);

            }
        }

    }
}
