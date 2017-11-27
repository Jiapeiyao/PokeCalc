using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{
    enum Type : int
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

    enum Nature : int
    {
        Hardy = 0,
        Lonely,
        Brave,
        Adamant,
        Naughty,
        Bold,
        Docile,
        Relaxed,
        Impish,
        Lax,
        Timid,
        Hasty,
        Serious,
        Jolly,
        Naive,
        Modest,
        Mild,
        Quiet,
        Bashful,
        Rash,
        Calm,
        Gentle,
        Sassy,
        Careful,
        Quirky
    }

    enum Status : int
    {
        Healthy = 0,
        Poisoned,
        BadlyPoisoned,
        Burned,
        Paralyzed,
        Asleep,
        Frozen

    }


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
        public Nature Nature;
        public String Ability;
        public String Item;
        public Status Status;
        public int CurrentHP;
        public Move move1;
        public Move move2;
        public Move move3;
        public Move move4;


        public Pokemon()
        {
            Type1 = Type.Grass;
            Type2 = Type.Ice;
            level = 100;
            HP = 321;
            Atk = 221;
            Def = 167;
            SpAtk = 311;
            SpDef = 206;
            Spd = 219;
            Nature = Nature.Mild;
            Ability = "Other";
            Item = "Life Orb";
            Status = Status.Frozen;
            CurrentHP = 321;
            move1 = new Move("Ice Shard", 40, Type.Ice, 100, "物理");
            move2 = new Move("Blizzard", 110, Type.Ice, 100, "特殊");
            move3 = new Move("Giga Drain", 75, Type.Grass, 100, "物理");
            move4 = new Move("Earthquake", 100, Type.Ground, 100, "特殊");
        }

        public static String typeToString(Type t) {
            switch (t) {
                case Type.None:
                    return "(无)";
                case Type.Normal:
                    return "一般";
                case Type.Fighting:
                    return "格斗";
                case Type.Flying:
                    return "飞行";
                case Type.Poison:
                    return "毒";
                case Type.Ground:
                    return "地面";
                case Type.Rock:
                    return "岩石";
                case Type.Bug:
                    return "虫";
                case Type.Ghost:
                    return "幽灵";
                case Type.Steel:
                    return "钢";
                case Type.Fire:
                    return "火";
                case Type.Water:
                    return "水";
                case Type.Grass:
                    return "草";
                case Type.Electric:
                    return "电";
                case Type.Psychic:
                    return "超能力";
                case Type.Ice:
                    return "冰";
                case Type.Dragon:
                    return "龙";
                case Type.Dark:
                    return "恶";
                case Type.Fairy:
                    return "妖精";

            }
            return "(无)"; 
        }

        public static String natureToString(Nature n) {
            switch (n) {
                case Nature.Hardy:
                    return "勤奋";
                case Nature.Lonely:
                    return "怕寂寞(Atk+,Def-)";
                case Nature.Brave:
                    return "勇敢(Atk+,Spd-)";
                case Nature.Adamant:
                    return "固执(Atk+,S.Atk-)";
                case Nature.Naughty:
                    return "顽皮(Atk+,S.Def-)";
                case Nature.Bold:
                    return "大胆(Def+,Atk-)";
                case Nature.Docile:
                    return "坦率";
                case Nature.Relaxed:
                    return "悠闲(Def+,Spd-)";
                case Nature.Impish:
                    return "淘气(Def+,S.Atk-)";
                case Nature.Lax:
                    return "乐天(Def+,S.Def-)";
                case Nature.Timid:
                    return "胆小(Spd+,Atk-)";
                case Nature.Hasty:
                    return "急躁(Spd+,Def-)";
                case Nature.Serious:
                    return "认真";
                case Nature.Jolly:
                    return "爽朗(Spd+,S.Atk-)";
                case Nature.Naive:
                    return "天真(Spd+,S.Def-)";
                case Nature.Modest:
                    return "内敛(S.Atk+,Atk-)";
                case Nature.Mild:
                    return "慢吞吞(S.Atk+,Def-)";
                case Nature.Quiet:
                    return "冷静(S.Atk+,Spd-)";
                case Nature.Bashful:
                    return "害羞";
                case Nature.Rash:
                    return "马虎(S.Atk+,S.Def-)";
                case Nature.Calm:
                    return "温和(S.Def+,Atk-)";
                case Nature.Gentle:
                    return "温顺(S.Def+,Def-)";
                case Nature.Sassy:
                    return "自大(S.Def+,Spd-)";
                case Nature.Careful:
                    return "慎重(S.Def+,S.Atk-)";
                case Nature.Quirky:
                    return "浮躁";
            }
            return "(无)";
        }
        public static String statusToString(Status s) {
            switch (s) {
                case Status.Healthy:
                    return "无";
                case Status.Poisoned:
                    return "中毒";
                case Status.BadlyPoisoned:
                    return "剧毒";
                case Status.Burned:
                    return "灼伤";
                case Status.Paralyzed:
                    return "麻痹";
                case Status.Asleep:
                    return "睡眠";
                case Status.Frozen:
                    return "冰冻";

            }
            return "(无)";
        }
    }


}
