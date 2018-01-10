using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeCalculator
{

    enum Weather : int {
        None,
        Sun,
        Rain,
        Sand,
        Hail,
        Harsh_Sun,
        Heavy_Rain,
        Strong_Winds
    }

    class Field
    {
        private bool _singles;
        public bool Singles {
            get {
                return _singles;
            }
            set {
                if (value)
                {
                    this._doubles = false;
                }
                _singles = value;
            }
        }

        public bool terrain_electric;
        public bool terrain_grassy;
        public bool terrain_misty;
        public bool terrain_psychic;

        private bool _doubles;
        public bool Doubles
        {
            get {
                return _doubles;
            }
            set
            {
                if (value)
                {
                    this._singles = false;
                }
                _doubles = value;
            }
        }

        public Weather Weather;

        public bool Gravity;
        public bool StealthRock_1;
        public bool StealthRock_2;
        public int Spikes_1;
        public int Spikes_2;
        public bool Reflect_1;
        public bool Reflect_2;
        public bool LightScreen_1;
        public bool LightScreen_2;
        public bool Protect_1;
        public bool Protect_2;
        public bool LeechSeed_1;
        public bool LeechSeed_2;
        public bool Foresight_1;
        public bool Foresight_2;
        public bool HelpingHand_1;
        public bool HelpingHand_2;
        public bool FriendGuard_1;
        public bool FriendGuard_2;
        public bool AuroraVeil_1;
        public bool AuroraVeil_2;

        public Field() {
            Singles = true;
            terrain_electric = false;
            terrain_grassy = false;
            terrain_misty = false;
            terrain_psychic = false;
            Weather = Weather.None;
            Gravity = false;
            StealthRock_1 = false;
            StealthRock_2 = false;
            Spikes_1 = 0;
            Spikes_2 = 0;
            Reflect_1 = false;
            Reflect_2 = false;
            LightScreen_1 = false;
            LightScreen_2 = false;
            Protect_1 = false;
            Protect_2 = false;
            LeechSeed_1 = false;
            LeechSeed_2 = false;
            Foresight_1 = false;
            Foresight_2 = false;
            HelpingHand_1 = false;
            HelpingHand_2 = false;
            FriendGuard_1 = false;
            FriendGuard_2 = false;
            AuroraVeil_1 = false;
            AuroraVeil_2 = false;

        }


    }
}
