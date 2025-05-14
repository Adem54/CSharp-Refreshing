using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiceRollGame
{
    //3. class name can be UserInputHandler instead of GuessNumberInput 
    public class UserInputHandler
    {
        public string? GuessInput { get; private set; }
      

        public void GetInputData()
        {
            GuessInput = Console.ReadLine();
           
        }

    }
}
