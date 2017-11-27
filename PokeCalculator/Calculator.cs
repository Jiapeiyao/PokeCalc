using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{
    
    class Calculator
    {
        public static double[,] matchup = initialize();

        public static double[,] initialize()
        {
            // Attack->defend matchup chart: https://bulbapedia.bulbagarden.net/wiki/Type
            double[,] matchup = new double[19, 19];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    matchup[i, j] = 0;
                }
            }
            void addMatchup(Type t1, Type t2, double value)
            {
                matchup[(int)t1, (int)t2] = value;
            }
            addMatchup(Type.Normal, Type.Rock, 0.5);
            addMatchup(Type.Normal, Type.Ghost, 0);
            addMatchup(Type.Normal, Type.Steel, 0.5);
            addMatchup(Type.Fighting, Type.Normal, 2);
            addMatchup(Type.Fighting, Type.Flying, 0.5);
            addMatchup(Type.Fighting, Type.Poison, 0.5);
            addMatchup(Type.Fighting, Type.Rock, 2);
            addMatchup(Type.Fighting, Type.Bug, 0.5);
            addMatchup(Type.Fighting, Type.Ghost, 0);
            addMatchup(Type.Fighting, Type.Steel, 2);
            addMatchup(Type.Fighting, Type.Psychic, 0.5);
            addMatchup(Type.Fighting, Type.Ice, 2);
            addMatchup(Type.Fighting, Type.Dark, 2);
            addMatchup(Type.Fighting, Type.Fairy, 0.5);
            addMatchup(Type.Flying, Type.Fighting, 2);
            addMatchup(Type.Flying, Type.Rock, 0.5);
            addMatchup(Type.Flying, Type.Bug, 2);
            addMatchup(Type.Flying, Type.Steel, 0.5);
            addMatchup(Type.Flying, Type.Grass, 2);
            addMatchup(Type.Flying, Type.Electric, 0.5);
            addMatchup(Type.Poison, Type.Poison, 0.5);
            addMatchup(Type.Poison, Type.Ground, 0.5);
            addMatchup(Type.Poison, Type.Rock, 0.5);
            addMatchup(Type.Poison, Type.Ghost, 0.5);
            addMatchup(Type.Poison, Type.Steel, 0);
            addMatchup(Type.Poison, Type.Grass, 2);
            addMatchup(Type.Poison, Type.Fairy, 2);
            addMatchup(Type.Ground, Type.Flying, 0);
            addMatchup(Type.Ground, Type.Poison, 2);
            addMatchup(Type.Ground, Type.Rock, 2);
            addMatchup(Type.Ground, Type.Bug, 0.5);
            addMatchup(Type.Ground, Type.Steel, 2);
            addMatchup(Type.Ground, Type.Flying, 2);
            addMatchup(Type.Ground, Type.Grass, 0.5);
            addMatchup(Type.Ground, Type.Electric, 2);
            addMatchup(Type.Rock, Type.Fighting, 0.5);
            addMatchup(Type.Rock, Type.Flying, 2);
            addMatchup(Type.Rock, Type.Ground, 0.5);
            addMatchup(Type.Rock, Type.Bug, 2);
            addMatchup(Type.Rock, Type.Steel, 0.5);
            addMatchup(Type.Rock, Type.Fire, 2);
            addMatchup(Type.Rock, Type.Ice, 2);
            addMatchup(Type.Bug, Type.Fighting, 0.5);
            addMatchup(Type.Bug, Type.Flying, 0.5);
            addMatchup(Type.Bug, Type.Poison, 0.5);
            addMatchup(Type.Bug, Type.Ghost, 0.5);
            addMatchup(Type.Bug, Type.Steel, 0.5);
            addMatchup(Type.Bug, Type.Fire, 0.5);
            addMatchup(Type.Bug, Type.Grass, 2);
            addMatchup(Type.Bug, Type.Psychic, 2);
            addMatchup(Type.Bug, Type.Dark, 2);
            addMatchup(Type.Bug, Type.Fairy, 0.5);
            addMatchup(Type.Ghost, Type.Normal, 0);
            addMatchup(Type.Ghost, Type.Ghost, 2);
            addMatchup(Type.Ghost, Type.Psychic, 2);
            addMatchup(Type.Ghost, Type.Dark, 0.5);
            addMatchup(Type.Steel, Type.Rock, 2);
            addMatchup(Type.Steel, Type.Steel, 0.5);
            addMatchup(Type.Steel, Type.Fire, 0.5);
            addMatchup(Type.Steel, Type.Water, 0.5);
            addMatchup(Type.Steel, Type.Electric, 0.5);
            addMatchup(Type.Steel, Type.Ice, 2);
            addMatchup(Type.Steel, Type.Fairy, 2);
            addMatchup(Type.Fire, Type.Rock, 0.5);
            addMatchup(Type.Fire, Type.Bug, 2);
            addMatchup(Type.Fire, Type.Steel, 2);
            addMatchup(Type.Fire, Type.Fire, 0.5);
            addMatchup(Type.Fire, Type.Water, 0.5);
            addMatchup(Type.Fire, Type.Grass, 2);
            addMatchup(Type.Fire, Type.Ice, 2);
            addMatchup(Type.Fire, Type.Dragon, 0.5);
            addMatchup(Type.Water, Type.Ground, 2);
            addMatchup(Type.Water, Type.Rock, 2);
            addMatchup(Type.Water, Type.Fire, 2);
            addMatchup(Type.Water, Type.Water, 0.5);
            addMatchup(Type.Water, Type.Grass, 0.5);
            addMatchup(Type.Water, Type.Dragon, 0.5);
            addMatchup(Type.Grass, Type.Flying, 0.5);
            addMatchup(Type.Grass, Type.Poison, 0.5);
            addMatchup(Type.Grass, Type.Ground, 2);
            addMatchup(Type.Grass, Type.Rock, 2);
            addMatchup(Type.Grass, Type.Bug, 0.5);
            addMatchup(Type.Grass, Type.Steel, 0.5);
            addMatchup(Type.Grass, Type.Fire, 0.5);
            addMatchup(Type.Grass, Type.Water, 2);
            addMatchup(Type.Grass, Type.Grass, 0.5);
            addMatchup(Type.Grass, Type.Dragon, 0.5);
            addMatchup(Type.Electric, Type.Flying, 2);
            addMatchup(Type.Electric, Type.Ground, 0);
            addMatchup(Type.Electric, Type.Water, 2);
            addMatchup(Type.Electric, Type.Grass, 0.5);
            addMatchup(Type.Electric, Type.Electric, 0.5);
            addMatchup(Type.Electric, Type.Dragon, 0.5);
            addMatchup(Type.Psychic, Type.Fighting, 2);
            addMatchup(Type.Psychic, Type.Poison, 2);
            addMatchup(Type.Psychic, Type.Steel, 0.5);
            addMatchup(Type.Psychic, Type.Psychic, 0.5);
            addMatchup(Type.Psychic, Type.Dark, 0);
            addMatchup(Type.Ice, Type.Flying, 2);
            addMatchup(Type.Ice, Type.Ground, 2);
            addMatchup(Type.Ice, Type.Steel, 0.5);
            addMatchup(Type.Ice, Type.Fire, 0.5);
            addMatchup(Type.Ice, Type.Water, 0.5);
            addMatchup(Type.Ice, Type.Grass, 2);
            addMatchup(Type.Ice, Type.Ice, 0.5);
            addMatchup(Type.Ice, Type.Dragon, 2);
            addMatchup(Type.Dragon, Type.Steel, 0.5);
            addMatchup(Type.Dragon, Type.Dragon, 2);
            addMatchup(Type.Dragon, Type.Fairy, 0);
            addMatchup(Type.Dark, Type.Fighting, 0.5);
            addMatchup(Type.Dark, Type.Ghost, 2);
            addMatchup(Type.Dark, Type.Psychic, 2);
            addMatchup(Type.Dark, Type.Dark, 0.5);
            addMatchup(Type.Dark, Type.Fairy, 0.5);
            addMatchup(Type.Fairy, Type.Fighting, 2);
            addMatchup(Type.Fairy, Type.Poison, 0.5);
            addMatchup(Type.Fairy, Type.Steel, 0.5);
            addMatchup(Type.Fairy, Type.Fire, 0.5);
            addMatchup(Type.Fairy, Type.Dragon, 2);
            addMatchup(Type.Fairy, Type.Dark, 2);
            return matchup;
        }

        public static double Matchup(Type t1, Type t2) {
            return matchup[(int)t1, (int)t2];
        }


        public static int calculateDamage(Pokemon p1, Move m1, Pokemon p2) {
            //欺诈 地球上投
            double level = p1.level;

            double power = m1.power;

            double attack = (m1.Category.Equals("物理")) ? p1.Atk : p1.SpAtk;
            double defence = (m1.Category.Equals("物理")) ? p2.Def : p2.SpDef;
            if (m1.Name.Equals("精神击破") || m1.Name.Equals("精神冲击") || m1.Name.Equals("神秘之剑")) {
                defence = p2.Def;
            }

            double Targets = 1;
            double Weather = 1;
            double Critical = 1;
            double random = 1;
            double STAB = 1;
            if (m1.Type == p1.Type1 || m1.Type == p1.Type2) {
                if (p1.Ability.Equals("适应力"))
                    STAB = 2;
                else
                    STAB = 1.5;
            }

            //double Type = matchup[(int)m1.Type, (int)p2.Type1] * matchup[(int)m1.Type, (int)p2.Type2];
            double Type = Matchup(m1.Type, p2.Type1) * Matchup(m1.Type, p2.Type2);

            double Burn = 1;
            double other = 1;
            if (p1.Item.Equals("Life Orb")) {
                other *= 1.3;
            }

            double Modifier = Targets * Weather * Critical * random * STAB * Type * Burn * other;
            double damage = ((2 * level / 5 + 2) * power * attack / defence / 50 + 2) * Modifier;
            
            return (int)damage;
        }
    }

}
