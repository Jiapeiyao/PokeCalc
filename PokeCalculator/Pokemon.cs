using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{
    

    class Pokemon
    {
        public Type Type1;
        public Type Type2;
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

        

        public Pokemon()
        {
            Type1 = Type.None;
            Type2 = Type.None;
            level = 100;
            HP = 321;
            Atk = 221;
            Def = 167;
            SpAtk = 311;
            SpDef = 206;
            Spd = 219;



        }

    }


}
