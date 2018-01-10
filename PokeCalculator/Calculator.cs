using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{

    class Calculator
    {
        public static double[,] matchup = InitializeMatchUp();
        public static List<String> MovesWithAHighCriticalHit = InitializeMovesWithAHighCriticalHit();
        public static Dictionary<int, double> statModifier = InitializeStatModifier();

        public static double[,] InitializeMatchUp()
        {
            // Attack->defend matchup chart: https://bulbapedia.bulbagarden.net/wiki/Type
            double[,] matchup = new double[19, 19];
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    matchup[i, j] = 1;
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
            addMatchup(Type.Ground, Type.Flying, 0);
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
        public static List<String> InitializeMovesWithAHighCriticalHit() {
            List<String> l = new List<string>();
            l.Add("气旋攻击");
            l.Add("空气利刃");
            l.Add("攻击指令");
            l.Add("火焰踢");
            l.Add("蟹钳锤");
            l.Add("十字劈");
            l.Add("十字毒刃");
            l.Add("直冲钻");
            l.Add("气旋攻击");
            l.Add("空手劈");
            l.Add("叶刃");
            l.Add("暗袭要害");
            l.Add("气旋攻击");
            l.Add("毒尾");
            l.Add("精神利刃");
            l.Add("飞叶快刀");
            l.Add("旋风刀");
            l.Add("暗影爪");
            l.Add("神鸟猛击");
            l.Add("劈开");
            l.Add("亚空裂斩");
            l.Add("尖石攻击");
            return l;
        }


        public static double Matchup(Type t1, Type t2) {
            return matchup[(int)t1, (int)t2];
        }

        public static Dictionary<int, double> InitializeStatModifier() {
            Dictionary<int, double> dict = new Dictionary<int, double>();
            dict.Add(-6, 2 / 8);
            dict.Add(-5, 2 / 7);
            dict.Add(-4, 2 / 6);
            dict.Add(-3, 2 / 5);
            dict.Add(-2, 2 / 4);
            dict.Add(-1, 2 / 3);
            dict.Add(0, 2 / 2);
            dict.Add(1, 3 / 2);
            dict.Add(2, 4 / 2);
            dict.Add(3, 5 / 2);
            dict.Add(4, 6 / 2);
            dict.Add(5, 7 / 2);
            dict.Add(6, 8 / 2);
            return dict;
        }

        public static int calculateDamage(Pokemon p1, Move m1, Pokemon p2, Field f,double random = 1) {
            //欺诈 地球上投
            int level = p1.level;

            //power
            double power = m1.power;


            double attack;
            if (m1.Category.Equals("物理"))
            {
                attack = p1.Atk * statModifier[p1.Stages[(int)Stage.ATK]];
            }
            else
            {
                attack = p1.SpAtk * statModifier[p1.Stages[(int)Stage.SP_ATK]];
            }
            double defence;
            if (m1.Category.Equals("物理") || m1.Name.Equals("精神击破") || m1.Name.Equals("精神冲击") || m1.Name.Equals("神秘之剑"))
            {
                defence = p2.Def * statModifier[p2.Stages[(int)Stage.DEF]];
                if (m1.Name.Equals("DD金勾臂")) {
                    defence = p2.Def;
                }
            }
            else
            {
                defence = p2.SpDef * statModifier[p2.Stages[(int)Stage.SP_ATK]];
            }

            double Targets = 1;
            double Weather = 1;
            double Critical = 1;
            double STAB = 1;
            if (m1.Type == p1.Type1 || m1.Type == p1.Type2) {
                if (p1.Ability.Equals("适应力"))
                    STAB = 2;
                else
                    STAB = 1.5;
            }

            double Type = Matchup(m1.Type, p2.Type1) * Matchup(m1.Type, p2.Type2);
            double Burn = 1;
            double other = 1;
            if (p1.Item.Equals("生命宝玉")) {
                other *= 1.3;
            }

            

            //critical Section
            double criticalRate = 0;
            if (m1.crit == 1)
            {
                criticalRate = 1;
            }
            else if (m1.crit == 2)
            {
                //criticalRate = 1 / 16;
                int stage = 0;
                if (MovesWithAHighCriticalHit.Contains(m1.Name)) {
                    stage++;
                }
                if (p1.Item.Equals("锐利之爪") || p1.Item.Equals("焦点镜")) {
                    stage++;
                }
                if (p1.Ability.Equals("超幸运")) {
                    stage++;
                }
                if (p1.Name.Equals("皮卡丘") && p1.Item.Equals("智皮卡") && m1.Name.Equals("百万伏特") && m1.Z) {
                    stage = stage + 2;
                }
                if (p1.Name.Equals("大葱鸭") && p1.Item.Equals("大葱")) {
                    stage = stage + 2;
                }
                if (stage == 0)
                {
                    criticalRate = 1 / 16;
                }
                else if (stage == 1)
                {
                    criticalRate = 1 / 8;
                }
                else if (stage == 2)
                {
                    criticalRate = 1 / 2;
                }
                else {
                    criticalRate = 1;
                }
            }
            if (m1.Name.Equals("山岚摔") || m1.Name.Equals("冰息") || (p1.Ability.Equals("不仁不义") && (p2.Status == Status.BadlyPoisoned || p2.Status == Status.Poisoned)))
            {
                criticalRate = 1;
            }
            if (p2.Ability.Equals("战斗盔甲") || p2.Ability.Equals("硬壳盔甲"))
            {
                criticalRate = 0;
            }
            if (p1.Ability.Equals("狙击手"))
            {
                Critical = (1.5 * 1.5 * criticalRate + 1 - criticalRate);
            }
            else
            {
                Critical = (1.5 * criticalRate + 1 - criticalRate);
            }

            double Accuracy = 1;
            if (m1.crit == 2) {
                int accStage = p1.Stages[(int)Stage.ACC];
                int evaStage = p2.Stages[(int)Stage.EVA];
                double modify(double i) {
                    return (3+((i>0)?i:0))/(3-((i<0)?i:0));
                }
                double accuracyModifier = modify(accStage);
                double evasionModifier = modify(-evaStage);
                if (m1.Name.Equals("DD金勾臂"))
                {
                    evasionModifier = 1;
                }
                Accuracy = m1.Accuracy * accuracyModifier / evasionModifier; 
            }

            double Modifier = Targets * Weather * Critical * random * STAB * Type * Burn * other;

            double damage = 1;
            if (defence != 0)
            {
                damage = Math.Floor((2 * level / 5 + 2) * power * attack / defence / 50 + 2) * Modifier * Accuracy;
            }
            return (int)damage;
        }
    }

}
