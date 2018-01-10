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

    enum Stats : int {
        HP,
        ATK,
        DEF,
        SP_ATK,
        SP_DEF,
        SPD
    }

    enum Stats2 : int
    {
        HP,
        ATK,
        DEF,
        SPD,
        SP_ATK,
        SP_DEF
    }

    enum Stage : int {
        ATK,
        DEF,
        SP_ATK,
        SP_DEF,
        SPD,
        ACC,
        EVA
    }


    class Pokemon
    {
        public String Name;
        public Type Type1;
        public Type Type2;
        public List<int> Forme;
        public int level;
        private int _HP;
        public int HP {
            get {
                int Base = Bases[(int)Stats.HP];
                int IV = IVs[(int)Stats.HP];
                int EV = EVs[(int)Stats.HP];
                return ((2 * Base + IV + EV / 4) * level / 100) + level + 10;
            }
            set {
                _HP = value;
            }
        }
        private int _Atk;
        public int Atk {
            get {
                int Base = Bases[(int)Stats.ATK];
                int IV = IVs[(int)Stats.ATK];
                int EV = EVs[(int)Stats.ATK];
                return (int)((((2 * Base + IV + EV / 4) * level / 100) + 5) * NatureModifier(Stats2.ATK, this.Nature));
            }
            set {
                _Atk = value;
            }
        }
        private int _Def;
        public int Def
        {
            get
            {
                int Base = Bases[(int)Stats.DEF];
                int IV = IVs[(int)Stats.DEF];
                int EV = EVs[(int)Stats.DEF];
                return (int)((((2 * Base + IV + EV / 4) * level / 100) + 5) * NatureModifier(Stats2.DEF, this.Nature));
            }
            set
            {
                _Def = value;
            }
        }
        private int _SpAtk;
        public int SpAtk
        {
            get
            {
                int Base = Bases[(int)Stats.SP_ATK];
                int IV = IVs[(int)Stats.SP_ATK];
                int EV = EVs[(int)Stats.SP_ATK];
                return (int)((((2 * Base + IV + EV / 4) * level / 100) + 5) * NatureModifier(Stats2.SP_ATK, this.Nature));
            }
            set
            {
                _SpAtk = value;
            }
        }
        private int _SpDef;
        public int SpDef
        {
            get
            {
                int Base = Bases[(int)Stats.SP_DEF];
                int IV = IVs[(int)Stats.SP_DEF];
                int EV = EVs[(int)Stats.SP_DEF];
                return (int)((((2 * Base + IV + EV / 4) * level / 100) + 5) * NatureModifier(Stats2.SP_DEF, this.Nature));
            }
            set
            {
                _SpDef = value;
            }
        }
        private int _Spd;
        public int Spd
        {
            get
            {
                int Base = Bases[(int)Stats.SPD];
                int IV = IVs[(int)Stats.SPD];
                int EV = EVs[(int)Stats.SPD];
                return (int)((((2 * Base + IV + EV / 4) * level / 100) + 5) * NatureModifier(Stats2.SPD, this.Nature));
            }
            set
            {
                _Spd = value;
            }
        }

        public int[] Bases;
        public int[] IVs;
        public int[] EVs;
        public int[] Stages;

        public Nature Nature;
        public String Ability;
        public String Item;
        public Status Status;
        public int CurrentHP;
        public double weight;

        public Move move1;
        public Move move2;
        public Move move3;
        public Move move4;

        public Pokemon()
        {
            Name = "";
            Type1 = Type.None;
            Type2 = Type.None;
            Forme = null;
            level = 100;
            HP = 0;
            Atk = 0;
            Def = 0;
            SpAtk = 0;
            SpDef = 0;
            Spd = 0;
            Bases = new int[6];
            IVs = new int[6];
            EVs = new int[6];
            Stages = new int[7];
            Nature = (Nature)0;
            Ability = "其它";
            Item = "Life Orb";
            Status = Status.Healthy;
            CurrentHP = 231;
            move1 = new Move("", 0, Type.None, 100, "物理");
            move2 = new Move("", 0, Type.None, 100, "物理");
            move3 = new Move("", 0, Type.None, 100, "物理");
            move4 = new Move("", 0, Type.None, 100, "物理");
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

        public static Type stringToType(String s)
        {
            switch (s)
            {
                case "(无)":
                    return Type.None;
                case "一般":
                    return Type.Normal;
                case "格斗":
                    return Type.Fighting;
                case "飞行":
                    return Type.Flying;
                case "毒":
                    return Type.Poison;
                case "地面":
                    return Type.Ground;
                case "岩石":
                    return Type.Rock;
                case "虫":
                    return Type.Bug;
                case "幽灵":
                    return Type.Ghost;
                case "钢":
                    return Type.Steel;
                case "火":
                    return Type.Fire;
                case "水":
                    return Type.Water;
                case "草":
                    return Type.Grass;
                case "电":
                    return Type.Electric;
                case "超能力":
                    return Type.Psychic;
                case "冰":
                    return Type.Ice;
                case "龙":
                    return Type.Dragon;
                case "恶":
                    return Type.Dark;
                case "妖精":
                    return Type.Fairy;

            }
            return Type.None;
        }

        public static String natureToString(Nature n) {
            switch (n) {
                case Nature.Hardy:
                    return "勤奋";
                case Nature.Lonely:
                    return "怕寂寞     (Atk+, Def-)";
                case Nature.Brave:
                    return "勇敢      (Atk+, Spd-)";
                case Nature.Adamant:
                    return "固执      (Atk+, S.Atk-)";
                case Nature.Naughty:
                    return "顽皮      (Atk+, S.Def-)";
                case Nature.Bold:
                    return "大胆      (Def+, Atk-)";
                case Nature.Docile:
                    return "坦率";
                case Nature.Relaxed:
                    return "悠闲      (Def+, Spd-)";
                case Nature.Impish:
                    return "淘气      (Def+, S.Atk-)";
                case Nature.Lax:
                    return "乐天      (Def+, S.Def-)";
                case Nature.Timid:
                    return "胆小      (Spd+, Atk-)";
                case Nature.Hasty:
                    return "急躁      (Spd+, Def-)";
                case Nature.Serious:
                    return "认真";
                case Nature.Jolly:
                    return "爽朗      (Spd+, S.Atk-)";
                case Nature.Naive:
                    return "天真      (Spd+, S.Def-)";
                case Nature.Modest:
                    return "内敛      (S.Atk+, Atk-)";
                case Nature.Mild:
                    return "慢吞吞     (S.Atk+, Def-)";
                case Nature.Quiet:
                    return "冷静      (S.Atk+, Spd-)";
                case Nature.Bashful:
                    return "害羞";
                case Nature.Rash:
                    return "马虎      (S.Atk+, S.Def-)";
                case Nature.Calm:
                    return "温和      (S.Def+, Atk-)";
                case Nature.Gentle:
                    return "温顺      (S.Def+, Def-)";
                case Nature.Sassy:
                    return "自大      (S.Def+, Spd-)";
                case Nature.Careful:
                    return "慎重      (S.Def+, S.Atk-)";
                case Nature.Quirky:
                    return "浮躁";
            }
            return "(无)";
        }

        public static double NatureModifier(Stats2 s, Nature n) {
            int natureIndex = (int)n;
            double retVal = 1;
            if (natureIndex / 5 == ((int)s) - 1) {
                retVal += 0.1;
            }
            if (natureIndex % 5 == ((int)s) - 1)
            {
                retVal -= 0.1;
            }
            return retVal;
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
