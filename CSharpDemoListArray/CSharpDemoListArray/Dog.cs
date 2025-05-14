using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class Dog
    {
        // TODO
        private string _name;
        private string _breed;
        private int _weight;

        public Dog(string name, string breed, int weight) : this(name, weight)
        {
            _breed = breed;
        }

        public Dog(string name, int weight)
        {
            _name = name;
            _weight = weight;
            _breed = "mixed-breed";
        }

        public string Describe()
        {
            string size = "";
            if (_weight < 5)
            {
                size = "tiny";
            }
            else if (_weight > 5 && _weight < 30)
            {
                size = "medium";
            }
            else
            {
                size = "large";
            }
            return $"This dog is named {_name}, it's a {_breed}, and it weighs {_weight} kilograms, so it's a {size} dog.";
        }


    }

}
