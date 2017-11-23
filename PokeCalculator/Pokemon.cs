using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{
    enum Types
    {
        None = 0,
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Electric,
        Psychic,
        Ice,
        Dragon,
        Dark,
        Fairy
    }

    

    class Pokemon
    {
        public String Type1;
        public String Type2;
        //public int Forme;
        public int level;
        public int HP;
        public int Atk;
        public int Def;
        public int SpAtk;
        public int SpDef;
        public int Spd;
        public String Nature;
        public String Ability;
        public String Item;
        public String Stats;
        public int CurrentHP;

        

        Pokemon()
        {

        }

    }
}
