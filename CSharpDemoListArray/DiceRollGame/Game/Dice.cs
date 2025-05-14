using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollGame.Game
{


    //className is important it is real-life scenaria-fit named
    public class Dice
    {
        //1.readonly becuase it musn't be assigned a new value..Random is a inbuild class already
        //2.Dependency injection testable, flexiable..in the future it can be change, changable..
        private readonly Random _random;
        private const int SidesCount = 6;

        public Dice(Random random)
        {
            _random = random;
        }

        //methodname is convinent for real-life use-case or scenario..Roll..it is also ijmportant
        public int Roll() => _random.Next(1, SidesCount + 1);

    }
}
