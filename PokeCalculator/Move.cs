using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{
    class Move
    {
        public String Name;
        public int power;
        public Type Type;
        public int Accuracy;
        public String Category;
        public bool Z;

        public Move(String _Name, int _power, Type _Type, int _Accuracy, String _Category) {
            Name = _Name;
            power = _power;
            Type = _Type;
            Accuracy = _Accuracy;
            Category = _Category;
            Z = false;
        }


    }
}
