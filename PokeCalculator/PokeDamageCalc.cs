using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokeCalculator
{
    public partial class PokeDamageCalc : Form
    {
        Pokemon p1;
        Pokemon p2;
        Field f;
        String[,] pokemonTable;
        String[,] moveTable;
        String[,] itemTable;
        String[,] abilityTable;
        Dictionary<String, String> pokemon_CN_to_EN = new Dictionary<string, string>();
        Dictionary<String, String> move_CN_to_EN = new Dictionary<string, string>();
        Dictionary<String, String> item_CN_to_EN = new Dictionary<string, string>();
        Dictionary<String, String> ability_CN_to_EN = new Dictionary<string, string>();
        private bool updating = false;
        Font RegularFont;
        Font BoldFont;


        public PokeDamageCalc()
        {
            InitializeComponent();
        }

        private void PokeDamageCalc_Load(object sender, EventArgs e)
        {
            DataReader reader = new DataReader(@"" + Application.StartupPath + "/db.xlsx");
            pokemonTable = reader.dataSheet(1);
            moveTable = reader.dataSheet(2);
            itemTable = reader.dataSheet(3);
            abilityTable = reader.dataSheet(4);
            p1 = new Pokemon();
            p2 = new Pokemon();
            RegularFont = new Font(this.Font, FontStyle.Regular);
            BoldFont = new Font(this.Font, FontStyle.Bold);
            InitializeField();
            InitializePokemonCombobox();
            InitializeTypeCombobox();
            InitializeNatureCombobox();
            InitializeStatusCombobox();
            InitializeItemCombobox();
            //InitializeStats();
            InitializeMove();
            InitializeStage();
            pokemon1.SelectedIndex = 0;
            pokemon2.SelectedIndex = 0;

        }

        private void InitializePokemonCombobox() {
            int nrow = pokemonTable.GetLength(0);
            for (int i = 0; i < nrow; i++) {
                String pokemonName = pokemonTable[i,1];
                if (pokemon_CN_to_EN.ContainsKey(pokemonName))
                {
                    Console.Out.WriteLine("重复： " + pokemonName);
                }
                else
                    pokemon_CN_to_EN.Add(pokemonName, pokemonTable[i, 2]);
                pokemon1.Items.Add(pokemonName);
                pokemon2.Items.Add(pokemonName);
            }

        }

        private void InitializeTypeCombobox() {
            p1_type1.SelectedIndex = 0;
            p1_type2.SelectedIndex = 0;
            p2_type1.SelectedIndex = 0;
            p2_type2.SelectedIndex = 0;
            //moves type
            p1_m1_type.SelectedIndex = 0;
            p1_m2_type.SelectedIndex = 0;
            p1_m3_type.SelectedIndex = 0;
            p1_m4_type.SelectedIndex = 0;
            p2_m1_type.SelectedIndex = 0;
            p2_m2_type.SelectedIndex = 0;
            p2_m3_type.SelectedIndex = 0;
            p2_m4_type.SelectedIndex = 0;

        }

        private void InitializeNatureCombobox() {
        }

        private void InitializeStatusCombobox() {
            //for (int i = 0; i < 7; i++) {
            //    p1_status.Items.Add(Pokemon.statusToString((Status)i));
            //    p2_status.Items.Add(Pokemon.statusToString((Status)i));
            //}
            p1_status.SelectedIndex = 0;
            p2_status.SelectedIndex = 0;
        }

        private void InitializeItemCombobox()
        {
            int nrow = itemTable.GetLength(0);
            for (int i = 0; i < nrow; i++)
            {
                String item = itemTable[i, 0];
                if (item_CN_to_EN.ContainsKey(item))
                    Console.Out.WriteLine("重复: " + item);
                else
                    item_CN_to_EN.Add(itemTable[i, 0], itemTable[i, 1]);
                p1_item.Items.Add(item);
                p2_item.Items.Add(item);
            }

            updating = true;
            p1_item.SelectedIndex = 0;
            p2_item.SelectedIndex = 0;
            updating = false;
        }

        private void InitializeMove()
        {
            int nrow = moveTable.GetLength(0);
            for (int i = 0; i < nrow; i++) 
            {
                if (move_CN_to_EN.ContainsKey(moveTable[i, 0]))
                    Console.Out.WriteLine("重复: " + moveTable[i, 0]);
                else
                    move_CN_to_EN.Add(moveTable[i, 0], moveTable[i, 1]);
                p1_move1.Items.Add(moveTable[i, 0]);
                p1_move2.Items.Add(moveTable[i, 0]);
                p1_move3.Items.Add(moveTable[i, 0]);
                p1_move4.Items.Add(moveTable[i, 0]);
                p2_move1.Items.Add(moveTable[i, 0]);
                p2_move2.Items.Add(moveTable[i, 0]);
                p2_move3.Items.Add(moveTable[i, 0]);
                p2_move4.Items.Add(moveTable[i, 0]);
            }
            updating = true;
            p1_m1_crit.SelectedIndex = 0;
            p1_m2_crit.SelectedIndex = 0;
            p1_m3_crit.SelectedIndex = 0;
            p1_m4_crit.SelectedIndex = 0;
            p2_m1_crit.SelectedIndex = 0;
            p2_m2_crit.SelectedIndex = 0;
            p2_m3_crit.SelectedIndex = 0;
            p2_m4_crit.SelectedIndex = 0;
            updating = false;
        }

        private void InitializeStage()
        {
            //updating = true;
            p1_stage_atk.SelectedIndex = 6;
            p1_stage_def.SelectedIndex = 6;
            p1_stage_spatk.SelectedIndex = 6;
            p1_stage_spdef.SelectedIndex = 6;
            p1_stage_spd.SelectedIndex = 6;
            p1_stage_acc.SelectedIndex = 6;
            p1_stage_eva.SelectedIndex = 6;
            p2_stage_atk.SelectedIndex = 6;
            p2_stage_def.SelectedIndex = 6;
            p2_stage_spatk.SelectedIndex = 6;
            p2_stage_spdef.SelectedIndex = 6;
            p2_stage_spd.SelectedIndex = 6;
            p2_stage_acc.SelectedIndex = 6;
            p2_stage_eva.SelectedIndex = 6;
            //updating = false;
        }

        private void InitializeField() {
            f = new Field();
            btn_single.Font = BoldFont;
            weather_none.Font = BoldFont;
        }

        private void DisplayPokemon1() {
            if (updating) return;
            updating = true;
            p1_type1.SelectedIndex = (int)p1.Type1;
            p1_type2.SelectedIndex = (int)p1.Type2;
            p1_level.Text = "" + p1.level;
            p1_base_hp.Text = "" + p1.Bases[(int)Stats.HP];
            p1_base_atk.Text = "" + p1.Bases[(int)Stats.ATK];
            p1_base_def.Text = "" + p1.Bases[(int)Stats.DEF];
            p1_base_spatk.Text = "" + p1.Bases[(int)Stats.SP_ATK];
            p1_base_spdef.Text = "" + p1.Bases[(int)Stats.SP_DEF];
            p1_base_spd.Text = "" + p1.Bases[(int)Stats.SPD];
            p1_totalhp.Text = "" + p1.HP;
            p1_nature.SelectedIndex = (int)p1.Nature;
            p1_ability.SelectedItem = p1.Ability;
            p1_item.SelectedItem = p1.Item;
            p1_status.SelectedIndex = (int)p1.Status;
            p1_curhp.Text = "" + p1.CurrentHP;
            //
            p1_move1.SelectedItem = p1.move1.Name;
            p1_m1_power.Text = "" + p1.move1.power;
            p1_m1_type.SelectedItem = Pokemon.typeToString(p1.move1.Type);
            p1_m1_category.SelectedItem = p1.move1.Category;
            //
            p1_move2.SelectedItem = p1.move2.Name;
            p1_m2_power.Text = "" + p1.move2.power;
            p1_m2_type.SelectedItem = Pokemon.typeToString(p1.move2.Type);
            p1_m2_category.SelectedItem = p1.move2.Category;
            //
            p1_move3.SelectedItem = p1.move3.Name;
            p1_m3_power.Text = "" + p1.move3.power;
            p1_m3_type.SelectedItem = Pokemon.typeToString(p1.move3.Type);
            p1_m3_category.SelectedItem = p1.move3.Category;
            //
            p1_move4.SelectedItem = p1.move4.Name;
            p1_m4_power.Text = "" + p1.move4.power;
            p1_m4_type.SelectedItem = Pokemon.typeToString(p1.move4.Type);
            p1_m4_category.SelectedItem = p1.move4.Category;
            updating = false;
            displayPanelResult1();
        }

        private void displayPanelResult1() {
            p1_panel_hp.Text = "" + p1.HP;
            p1_panel_atk.Text = "" + p1.Atk;
            p1_panel_def.Text = "" + p1.Def;
            p1_panel_spatk.Text = "" + p1.SpAtk;
            p1_panel_spdef.Text = "" + p1.SpDef;
            p1_panel_spd.Text = "" + p1.Spd;
            p1_totalhp.Text = "/" + p1.HP;
            //viewDamage();
        }

        private void DisplayPokemon2()
        {
            if (updating) return;
            updating = true;
            p2_type1.SelectedIndex = (int)p2.Type1;
            p2_type2.SelectedIndex = (int)p2.Type2;
            p2_level.Text = "" + p2.level;
            p2_base_hp.Text = "" + p2.Bases[(int)Stats.HP];
            p2_base_atk.Text = "" + p2.Bases[(int)Stats.ATK];
            p2_base_def.Text = "" + p2.Bases[(int)Stats.DEF];
            p2_base_spatk.Text = "" + p2.Bases[(int)Stats.SP_ATK];
            p2_base_spdef.Text = "" + p2.Bases[(int)Stats.SP_DEF];
            p2_base_spd.Text = "" + p2.Bases[(int)Stats.SPD];
            p2_totalhp.Text = "" + p2.HP;
            p2_nature.SelectedIndex = (int)p2.Nature;
            p2_ability.SelectedItem = p2.Ability;
            p2_item.SelectedItem = p2.Item;
            p2_status.SelectedIndex = (int)p2.Status;
            p2_curhp.Text = "" + p2.CurrentHP;
            //
            p2_move1.SelectedItem = p2.move1.Name;
            p2_m1_power.Text = "" + p2.move1.power;
            p2_m1_type.SelectedItem = Pokemon.typeToString(p2.move1.Type);
            p2_m1_category.SelectedItem = p2.move1.Category;
            //
            p2_move2.SelectedItem = p2.move2.Name;
            p2_m2_power.Text = "" + p2.move2.power;
            p2_m2_type.SelectedItem = Pokemon.typeToString(p2.move2.Type);
            p2_m2_category.SelectedItem = p2.move2.Category;
            //
            p2_move3.SelectedItem = p2.move3.Name;
            p2_m3_power.Text = "" + p2.move3.power;
            p2_m3_type.SelectedItem = Pokemon.typeToString(p2.move3.Type);
            p2_m3_category.SelectedItem = p2.move3.Category;
            //
            p2_move4.SelectedItem = p2.move4.Name;
            p2_m4_power.Text = "" + p2.move4.power;
            p2_m4_type.SelectedItem = Pokemon.typeToString(p2.move4.Type);
            p2_m4_category.SelectedItem = p2.move4.Category;
            updating = false;
            displayPanelResult2();
        }

        private void displayPanelResult2()
        {
            p2_panel_hp.Text = "" + p2.HP;
            p2_panel_atk.Text = "" + p2.Atk;
            p2_panel_def.Text = "" + p2.Def;
            p2_panel_spatk.Text = "" + p2.SpAtk;
            p2_panel_spdef.Text = "" + p2.SpDef;
            p2_panel_spd.Text = "" + p2.Spd;
            p2_totalhp.Text = "/" + p2.HP;
            //viewDamage();
        }

        private void viewDamage() {
            view_p1_m1_damage();
            view_p1_m2_damage();
            view_p1_m3_damage();
            view_p1_m4_damage();
            view_p2_m1_damage();
            view_p2_m2_damage();
            view_p2_m3_damage();
            view_p2_m4_damage();
        }

        //pokemon selection
        private void pokemon1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = pokemon1.SelectedIndex;
            p1.Name = pokemonTable[index, 1];
            p1.Type1 = Pokemon.stringToType(pokemonTable[index, 3]);
            p1.Type2 = Pokemon.stringToType(pokemonTable[index, 4]);
            
            //forme
            p1.Forme = new List<int>();
            p1_forme.Items.Clear();
            int result;
            if (Int32.TryParse(pokemonTable[index, 5], out result) && result == 1)
            {
                int tmp = index;
                while (true)
                {
                    tmp++;
                    if (!Int32.TryParse(pokemonTable[tmp, 5], out result) || result == 0)
                    {
                        break;
                    }
                    p1_forme.Items.Add(pokemonTable[tmp, 1]);
                    p1.Forme.Add(result);
                    p1_forme.Enabled = true;
                }
            }
            else {
                p1_forme.Enabled = false;
            }

            p1.Bases[(int)Stats.HP] = Int32.Parse(pokemonTable[index, 6]);
            p1.Bases[(int)Stats.ATK] = Int32.Parse(pokemonTable[index, 7]);
            p1.Bases[(int)Stats.DEF] = Int32.Parse(pokemonTable[index, 8]);
            p1.Bases[(int)Stats.SP_ATK] = Int32.Parse(pokemonTable[index, 9]);
            p1.Bases[(int)Stats.SP_DEF] = Int32.Parse(pokemonTable[index, 10]);
            p1.Bases[(int)Stats.SPD] = Int32.Parse(pokemonTable[index, 11]);
            p1.IVs[(int)Stats.HP] = Int32.Parse(p1_iv_hp.Text);
            p1.IVs[(int)Stats.ATK] = Int32.Parse(p1_iv_atk.Text);
            p1.IVs[(int)Stats.DEF] = Int32.Parse(p1_iv_def.Text);
            p1.IVs[(int)Stats.SP_ATK] = Int32.Parse(p1_iv_spatk.Text);
            p1.IVs[(int)Stats.SP_DEF] = Int32.Parse(p1_iv_spdef.Text);
            p1.IVs[(int)Stats.SPD] = Int32.Parse(p1_iv_spd.Text);
            p1.EVs[(int)Stats.HP] = Int32.Parse(p1_ev_hp.Text);
            p1.EVs[(int)Stats.ATK] = Int32.Parse(p1_ev_atk.Text);
            p1.EVs[(int)Stats.DEF] = Int32.Parse(p1_ev_def.Text);
            p1.EVs[(int)Stats.SP_ATK] = Int32.Parse(p1_ev_spatk.Text);
            p1.EVs[(int)Stats.SP_DEF] = Int32.Parse(p1_ev_spdef.Text);
            p1.EVs[(int)Stats.SPD] = Int32.Parse(p1_ev_spd.Text);

            //Ability
            p1_ability.Items.Clear();
            p1_ability.Items.Add(pokemonTable[index, 12]);
            if (!pokemonTable[index, 13].Equals("")) p1_ability.Items.Add(pokemonTable[index, 13]);
            if (!pokemonTable[index, 14].Equals("")) p1_ability.Items.Add(pokemonTable[index, 14]);
            p1.Ability = pokemonTable[index, 12];
            try
            {
                p1.weight = Convert.ToDouble(pokemonTable[index, 13]);
            }
            catch (Exception){
                p1.weight = 0;
            }
            //p1.CurrentHP = p1.HP;
            DisplayPokemon1();
            viewDamage();
        }

        private void pokemon2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = pokemon2.SelectedIndex;
            p2.Name = pokemonTable[index, 1];
            p2.Type1 = Pokemon.stringToType(pokemonTable[index, 3]);
            p2.Type2 = Pokemon.stringToType(pokemonTable[index, 4]);

            //forme
            p2.Forme = new List<int>();
            p2_forme.Items.Clear();
            int result;
            if (Int32.TryParse(pokemonTable[index, 5], out result) && result == 1)
            {
                int tmp = index;
                while (true)
                {
                    tmp++;
                    if (!Int32.TryParse(pokemonTable[tmp, 5], out result) || result == 0)
                    {
                        break;
                    }
                    p2_forme.Items.Add(pokemonTable[tmp, 1]);
                    p2.Forme.Add(result);
                    p2_forme.Enabled = true;
                }
            }
            else
            {
                p2_forme.Enabled = false;
            }

            p2.Bases[(int)Stats.HP] = Int32.Parse(pokemonTable[index, 6]);
            p2.Bases[(int)Stats.ATK] = Int32.Parse(pokemonTable[index, 7]);
            p2.Bases[(int)Stats.DEF] = Int32.Parse(pokemonTable[index, 8]);
            p2.Bases[(int)Stats.SP_ATK] = Int32.Parse(pokemonTable[index, 9]);
            p2.Bases[(int)Stats.SP_DEF] = Int32.Parse(pokemonTable[index, 10]);
            p2.Bases[(int)Stats.SPD] = Int32.Parse(pokemonTable[index, 11]);
            p2.IVs[(int)Stats.HP] = Int32.Parse(p2_iv_hp.Text);
            p2.IVs[(int)Stats.ATK] = Int32.Parse(p2_iv_atk.Text);
            p2.IVs[(int)Stats.DEF] = Int32.Parse(p2_iv_def.Text);
            p2.IVs[(int)Stats.SP_ATK] = Int32.Parse(p2_iv_spatk.Text);
            p2.IVs[(int)Stats.SP_DEF] = Int32.Parse(p2_iv_spdef.Text);
            p2.IVs[(int)Stats.SPD] = Int32.Parse(p2_iv_spd.Text);
            p2.EVs[(int)Stats.HP] = Int32.Parse(p2_ev_hp.Text);
            p2.EVs[(int)Stats.ATK] = Int32.Parse(p2_ev_atk.Text);
            p2.EVs[(int)Stats.DEF] = Int32.Parse(p2_ev_def.Text);
            p2.EVs[(int)Stats.SP_ATK] = Int32.Parse(p2_ev_spatk.Text);
            p2.EVs[(int)Stats.SP_DEF] = Int32.Parse(p2_ev_spdef.Text);
            p2.EVs[(int)Stats.SPD] = Int32.Parse(p2_ev_spd.Text);

            //Ability
            p2_ability.Items.Clear();
            p2_ability.Items.Add(pokemonTable[index, 12]);
            if (!pokemonTable[index, 13].Equals("")) p2_ability.Items.Add(pokemonTable[index, 13]);
            if (!pokemonTable[index, 14].Equals("")) p2_ability.Items.Add(pokemonTable[index, 14]);
            p2.Ability = pokemonTable[index, 12];
            try
            {
                p2.weight = Convert.ToDouble(pokemonTable[index, 13]);
            }
            catch (Exception)
            {
                p2.weight = 0;
            }
            //p2.CurrentHP = p2.HP;
            DisplayPokemon2();
            viewDamage();
        }

        private void pokemon1_SelectedIndexChanged_alter(object sender, EventArgs e)
        {
            updating = true;
            int index = pokemon1.SelectedIndex;
            //Types
            p1_type1.SelectedItem = pokemonTable[index, 3];
            if (pokemonTable[index, 4].Equals(""))
                p1_type2.SelectedIndex = 0;
            else
                p1_type2.SelectedItem = pokemonTable[index, 4];
            //forms
            p1_forme.Items.Clear();
            p1.Forme = new List<int>();
            if (pokemonTable[index, 5].Equals("1"))
            {
                p1_forme.Enabled = true;
                String dexNum = pokemonTable[index, 0];
                for (int i = 0; i < pokemonTable.GetLength(0); i++)
                {
                    if (dexNum.Equals(pokemonTable[i, 0]))
                    {
                        p1_forme.Items.Add(pokemonTable[i, 1]);
                        p1.Forme.Add(i);
                    }
                }
            }
            else
            {
                p1_forme.Enabled = false;
            }
            //stats
            p1_base_hp.Text = pokemonTable[index, 6];
            p1_base_atk.Text = pokemonTable[index, 7];
            p1_base_def.Text = pokemonTable[index, 8];
            p1_base_spatk.Text = pokemonTable[index, 9];
            p1_base_spdef.Text = pokemonTable[index, 10];
            p1_base_spd.Text = pokemonTable[index, 11];
            //ability
            p1_ability.Items.Clear();
            for (int i = 12; i < 15; i++)
            {
                String to_add = pokemonTable[index, i];
                if (!to_add.Equals(""))
                    p1_ability.Items.Add(to_add);
            }
            p1_ability.SelectedIndex = 0;
            try
            {
                p1.weight = Convert.ToDouble(pokemonTable[index, 13]);
            }
            catch (Exception)
            {
                p1.weight = 1;
            }
            updating = false;
            p1_hp_percent.Text = "" + 100;
        }

        private void pokemon2_SelectedIndexChanged_alter(object sender, EventArgs e)
        {
            updating = true;
            int index = pokemon2.SelectedIndex;
            //Types
            p2_type1.SelectedItem = pokemonTable[index, 3];
            if (pokemonTable[index, 4].Equals(""))
                p2_type2.SelectedIndex = 0;
            else
                p2_type2.SelectedItem = pokemonTable[index, 4];
            //forms
            p2_forme.Items.Clear();
            p2.Forme = new List<int>();
            if (pokemonTable[index, 5].Equals("1"))
            {
                p2_forme.Enabled = true;
                String dexNum = pokemonTable[index, 0];
                for (int i = 0; i < pokemonTable.GetLength(0); i++)
                {
                    if (dexNum.Equals(pokemonTable[i, 0]))
                    {
                        p2_forme.Items.Add(pokemonTable[i, 1]);
                        p2.Forme.Add(i);
                    }
                }
            }
            else
            {
                p2_forme.Enabled = false;
            }
            //stats
            p2_base_hp.Text = pokemonTable[index, 6];
            p2_base_atk.Text = pokemonTable[index, 7];
            p2_base_def.Text = pokemonTable[index, 8];
            p2_base_spatk.Text = pokemonTable[index, 9];
            p2_base_spdef.Text = pokemonTable[index, 10];
            p2_base_spd.Text = pokemonTable[index, 11];

            //ability
            p2_ability.Items.Clear();
            for (int i = 12; i < 15; i++)
            {
                String to_add = pokemonTable[index, i];
                if (!to_add.Equals(""))
                    p2_ability.Items.Add(to_add);
            }
            p2_ability.SelectedIndex = 0;

            try
            {
                p2.weight = Convert.ToDouble(pokemonTable[index, 13]);
            }
            catch (Exception)
            {
                p2.weight = 1;
            }
            updating = false;
            p2_hp_percent.Text = "" + 100;
        }


        //Types events
        private void p1_type1_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Type1 = (Type)p1_type1.SelectedIndex;
        }
        private void p1_type2_SelectedIndexChanged(object sender, EventArgs e) {
            p1.Type2 = (Type)p1_type2.SelectedIndex;
        }
        private void p2_type1_SelectedIndexChanged(object sender, EventArgs e) {
            p2.Type1 = (Type)p2_type1.SelectedIndex;
        }
        private void p2_type2_SelectedIndexChanged(object sender, EventArgs e) {
            p2.Type2 = (Type)p2_type2.SelectedIndex;
        }

        //Natures events
        private void p1_nature_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Nature = (Nature)p1_nature.SelectedIndex;
            displayPanelResult1();
            viewDamage();
        }
        private void p2_nature_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Nature = (Nature)p2_nature.SelectedIndex;
            displayPanelResult2();
            viewDamage();
        }

        //Abilities event
        private void p1_ability_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Ability = p1_ability.SelectedItem.ToString();
            viewDamage();
        }

        private void p2_ability_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Ability = p2_ability.SelectedItem.ToString();
            viewDamage();
        }

        private void p1_level_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_level.Text, out result)  && result > 0 && result <= 100 )
            {
                p1.level = result;
            }
            else {
                p1_level.Text = "" + p1.level;
            }
            updating = false;
            displayPanelResult1();
            viewDamage();
        }

        private void p2_level_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_level.Text, out result) && result > 0 && result <= 100)
            {
                p2.level = result;
            }
            else
            {
                p2_level.Text = "" + p2.level;
            }
            updating = false;
            displayPanelResult2();
            viewDamage();
        }

        private void p1_base_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_hp.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.HP] = result;
                updating = false;
                p1_panel_hp.Text = "" + p1.HP;
                p1_totalhp.Text = "/" + p1.HP;
            }
            else {
                p1_base_hp.Text = "" + p1.Bases[(int)Stats.HP]; 
                updating = false;
            }
        }

        private void p1_base_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_atk.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.ATK] = result;
                updating = false;
                p1_panel_atk.Text = "" + p1.Atk;
            }
            else
            {
                p1_base_atk.Text = "" + p1.Bases[(int)Stats.ATK];
                updating = false;
            }
        }

        private void p1_base_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_def.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.DEF] = result;
                updating = false;
                p1_panel_def.Text = "" + p1.Def;
            }
            else
            {
                p1_base_def.Text = "" + p1.Bases[(int)Stats.DEF];
                updating = false;
            }
        }

        private void p1_base_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_spatk.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.SP_ATK] = result;
                updating = false;
                p1_panel_spatk.Text = "" + p1.SpAtk;
            }
            else
            {
                p1_base_spatk.Text = "" + p1.Bases[(int)Stats.SP_ATK];
                updating = false;
            }
        }

        private void p1_base_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_spdef.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.SP_DEF] = result;
                updating = false;
                p1_panel_spdef.Text = "" + p1.SpDef;
            }
            else
            {
                p1_base_spdef.Text = "" + p1.Bases[(int)Stats.SP_DEF];
                updating = false;
            }
        }

        private void p1_base_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_base_spd.Text, out result) && (result >= 0) && (result < 256))
            {
                p1.Bases[(int)Stats.SPD] = result;
                updating = false;
                p1_panel_spd.Text = "" + p1.Spd;
            }
            else
            {
                p1_base_spd.Text = "" + p1.Bases[(int)Stats.SPD];
                updating = false;
            }
        }

        private void p1_iv_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_hp.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.HP] = result;
                updating = false;
                p1_panel_hp.Text = "" + p1.HP;
                p1_totalhp.Text = "/" + p1.HP;
            }
            else
            {
                p1_iv_hp.Text = "" + p1.IVs[(int)Stats.HP];
                updating = false;
            }
        }

        private void p1_iv_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_atk.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.ATK] = result;
                updating = false;
                p1_panel_atk.Text = "" + p1.Atk;
            }
            else
            {
                p1_iv_atk.Text = "" + p1.IVs[(int)Stats.ATK];
                updating = false;
            }
        }

        private void p1_iv_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_def.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.DEF] = result;
                updating = false;
                p1_panel_def.Text = "" + p1.Def;
            }
            else
            {
                p1_iv_def.Text = "" + p1.IVs[(int)Stats.DEF];
                updating = false;
            }
        }

        private void p1_iv_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_spatk.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.SP_ATK] = result;
                updating = false;
                p1_panel_spatk.Text = "" + p1.SpAtk;
            }
            else
            {
                p1_iv_spatk.Text = "" + p1.IVs[(int)Stats.SP_ATK];
                updating = false;
            }
        }

        private void p1_iv_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_spdef.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.SP_DEF] = result;
                updating = false;
                p1_panel_spdef.Text = "" + p1.SpDef;
            }
            else
            {
                p1_iv_spdef.Text = "" + p1.IVs[(int)Stats.SP_DEF];
                updating = false;
            }
        }

        private void p1_iv_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_iv_spd.Text, out result) && (result >= 0) && (result < 32))
            {
                p1.IVs[(int)Stats.SPD] = result;
                updating = false;
                p1_panel_spd.Text = "" + p1.Spd;
            }
            else
            {
                p1_iv_spd.Text = "" + p1.IVs[(int)Stats.SPD];
                updating = false;
            }
        }

        private void p1_ev_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_hp.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.HP] = result;
                updating = false;
                p1_panel_hp.Text = "" + p1.HP;
                p1_totalhp.Text = "/" + p1.HP;
            }
            else
            {
                p1_ev_hp.Text = "" + p1.EVs[(int)Stats.HP];
                updating = false;
            }
        }

        private void p1_ev_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_atk.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.ATK] = result;
                updating = false;
                p1_panel_atk.Text = "" + p1.Atk;
            }
            else
            {
                p1_ev_atk.Text = "" + p1.EVs[(int)Stats.ATK];
                updating = false;
            }
        }

        private void p1_ev_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_def.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.DEF] = result;
                updating = false;
                p1_panel_def.Text = "" + p1.Def;
            }
            else
            {
                p1_ev_def.Text = "" + p1.EVs[(int)Stats.DEF];
                updating = false;
            }
        }

        private void p1_ev_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_spatk.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.SP_ATK] = result;
                updating = false;
                p1_panel_spatk.Text = "" + p1.SpAtk;
            }
            else
            {
                p1_ev_spatk.Text = "" + p1.EVs[(int)Stats.SP_ATK];
                updating = false;
            }
        }

        private void p1_ev_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_spdef.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.SP_DEF] = result;
                updating = false;
                p1_panel_spdef.Text = "" + p1.SpDef;
            }
            else
            {
                p1_ev_spdef.Text = "" + p1.EVs[(int)Stats.SP_DEF];
                updating = false;
            }
        }

        private void p1_ev_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_ev_spd.Text, out result) && (result >= 0) && (result <= 255))
            {
                p1.EVs[(int)Stats.SPD] = result;
                updating = false;
                p1_panel_spd.Text = "" + p1.Spd;
            }
            else
            {
                p1_ev_spd.Text = "" + p1.EVs[(int)Stats.SPD];
                updating = false;
            }
        }

        private void p1_panel_hp_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_panel_atk_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_panel_def_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_panel_spatk_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_panel_spdef_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_panel_spd_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p1_totalhp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_hp_percent.Text, out result)) {
                int curhp = result * p1.HP /100;
                p1_curhp.Text = "" + curhp;
                p1.CurrentHP = curhp;
            }
            updating = false;
        }

        private void p1_curhp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_curhp.Text, out result) && result >= 0 && result <= p1.HP)
            {
                p1.CurrentHP = result;
                p1_hp_percent.Text = "" + (int)((double)result / (double)p1.HP * 100);
            }
            else {
                p1_curhp.Text = "" + p1.CurrentHP;
            }
            updating = false;
        }

        private void p1_hp_percent_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result1, result2;
            if (Int32.TryParse(p1_hp_percent.Text, out result1) && result1 >= 0 && result1 <= 100)
            {
                p1.CurrentHP = result1 * p1.HP / 100;
                p1_curhp.Text = "" + p1.CurrentHP;
            }
            else if (Int32.TryParse(p1_curhp.Text, out result2))
            {
                p1_hp_percent.Text = ""+ (int)(((double)result2 / (double)p1.HP) * 100) ;
            }
            else {

            }
            updating = false;
        }

        private void p1_stage_atk_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.ATK] = p1_stage_atk.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_def_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.DEF] = p1_stage_def.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_spatk_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.SP_ATK] = p1_stage_spatk.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_spdef_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.SP_DEF] = p1_stage_spdef.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_spd_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.SPD] = p1_stage_spd.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.ACC] = p1_stage_acc.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_stage_eva_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Stages[(int)Stage.EVA] = p1_stage_eva.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_move1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p1_move1.SelectedIndex;
            p1.move1.Name = moveTable[index, 0];
            btn_p1_m1.Text = p1.move1.Name;
            p1.move1.power = Int32.Parse(moveTable[index, 2]);
            p1.move1.Type = Pokemon.stringToType(moveTable[index, 3]);
            p1.move1.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p1_m1_acc.Enabled = true;
                p1.move1.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else {
                p1.move1.Accuracy = 0;
                p1_m1_acc.Text = "";
                p1_m1_acc.Enabled = false;
            }
            updating = true;
            p1_m1_power.Text = moveTable[index, 2];
            p1_m1_type.SelectedIndex = (int)p1.move1.Type;
            p1_m1_category.SelectedItem = p1.move1.Category;
            p1_m1_acc.Text = moveTable[index, 5];
            updating = false;
            view_p1_m1_damage();
        }

        private void p1_move2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p1_move2.SelectedIndex;
            p1.move2.Name = moveTable[index, 0];
            btn_p1_m2.Text = p1.move2.Name;
            p1.move2.power = Int32.Parse(moveTable[index, 2]);
            p1.move2.Type = Pokemon.stringToType(moveTable[index, 3]);
            p1.move2.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p1_m2_acc.Enabled = true;
                p1.move2.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p1.move2.Accuracy = 0;
                p1_m2_acc.Text = "--";
                p1_m2_acc.Enabled = false;
            }
            updating = true;
            p1_m2_power.Text = moveTable[index, 2];
            p1_m2_type.SelectedIndex = (int)p1.move2.Type;
            p1_m2_category.SelectedItem = p1.move2.Category;
            p1_m2_acc.Text = moveTable[index, 5];
            updating = false;
            view_p1_m2_damage();
        }

        private void p1_move3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p1_move3.SelectedIndex;
            p1.move3.Name = moveTable[index, 0];
            btn_p1_m3.Text = p1.move3.Name;
            p1.move3.power = Int32.Parse(moveTable[index, 2]);
            p1.move3.Type = Pokemon.stringToType(moveTable[index, 3]);
            p1.move3.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p1_m3_acc.Enabled = true;
                p1.move3.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p1.move3.Accuracy = 0;
                p1_m3_acc.Text = "--";
                p1_m3_acc.Enabled = false;
            }
            updating = true;
            p1_m3_power.Text = moveTable[index, 2];
            p1_m3_type.SelectedIndex = (int)p1.move3.Type;
            p1_m3_category.SelectedItem = p1.move3.Category;
            p1_m3_acc.Text = moveTable[index, 5];
            updating = false;
            view_p1_m3_damage();
        }

        private void p1_move4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p1_move4.SelectedIndex;
            p1.move4.Name = moveTable[index, 0];
            btn_p1_m4.Text = p1.move4.Name;
            p1.move4.power = Int32.Parse(moveTable[index, 2]);
            p1.move4.Type = Pokemon.stringToType(moveTable[index, 3]);
            p1.move4.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p1_m4_acc.Enabled = true;
                p1.move4.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p1.move4.Accuracy = 0;
                p1_m4_acc.Text = "--";
                p1_m4_acc.Enabled = false;
            }
            updating = true;
            p1_m4_power.Text = moveTable[index, 2];
            p1_m4_type.SelectedIndex = (int)p1.move4.Type;
            p1_m4_category.SelectedItem = p1.move4.Category;
            p1_m4_acc.Text = moveTable[index, 5];
            updating = false;
            view_p1_m4_damage();
        }

        private void p1_forme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void p2_forme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void p1_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Item = p1_item.Text;
            viewDamage();
        }

        private void p2_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Item = p2_item.Text;
            viewDamage();
        }

        private void p2_base_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_hp.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.HP] = result;
                updating = false;
                p2_panel_hp.Text = "" + p2.HP;
                p2_totalhp.Text = "/" + p2.HP;
            }
            else
            {
                p2_base_hp.Text = "" + p2.Bases[(int)Stats.HP];
                updating = false;
            }
            viewDamage();
        }

        private void p2_base_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_atk.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.ATK] = result;
                updating = false;
                p2_panel_atk.Text = "" + p2.Atk;
            }
            else
            {
                p2_base_atk.Text = "" + p2.Bases[(int)Stats.ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_base_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_def.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.DEF] = result;
                updating = false;
                p2_panel_def.Text = "" + p2.Def;
            }
            else
            {
                p2_base_def.Text = "" + p2.Bases[(int)Stats.DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_base_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_spatk.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.SP_ATK] = result;
                updating = false;
                p2_panel_spatk.Text = "" + p2.SpAtk;
            }
            else
            {
                p2_base_spatk.Text = "" + p2.Bases[(int)Stats.SP_ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_base_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_spdef.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.SP_DEF] = result;
                updating = false;
                p2_panel_spdef.Text = "" + p2.SpDef;
            }
            else
            {
                p2_base_spdef.Text = "" + p2.Bases[(int)Stats.SP_DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_base_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_base_spd.Text, out result) && (result >= 0) && (result < 256))
            {
                p2.Bases[(int)Stats.SPD] = result;
                updating = false;
                p2_panel_spd.Text = "" + p2.Spd;
            }
            else
            {
                p2_base_spd.Text = "" + p2.Bases[(int)Stats.SPD];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_hp.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.HP] = result;
                updating = false;
                p2_panel_hp.Text = "" + p2.HP;
                p2_totalhp.Text = "/" + p2.HP;
            }
            else
            {
                p2_iv_hp.Text = "" + p2.IVs[(int)Stats.HP];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_atk.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.ATK] = result;
                updating = false;
                p2_panel_atk.Text = "" + p2.Atk;
            }
            else
            {
                p2_iv_atk.Text = "" + p2.IVs[(int)Stats.ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_def.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.DEF] = result;
                updating = false;
                p2_panel_def.Text = "" + p2.Def;
            }
            else
            {
                p2_iv_def.Text = "" + p2.IVs[(int)Stats.DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_spatk.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.SP_ATK] = result;
                updating = false;
                p2_panel_spatk.Text = "" + p2.SpAtk;
            }
            else
            {
                p2_iv_spatk.Text = "" + p2.IVs[(int)Stats.SP_ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_spdef.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.SP_DEF] = result;
                updating = false;
                p2_panel_spdef.Text = "" + p2.SpDef;
            }
            else
            {
                p2_iv_spdef.Text = "" + p2.IVs[(int)Stats.SP_DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_iv_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_iv_spd.Text, out result) && (result >= 0) && (result < 32))
            {
                p2.IVs[(int)Stats.SPD] = result;
                updating = false;
                p2_panel_spd.Text = "" + p2.Spd;
            }
            else
            {
                p2_iv_spd.Text = "" + p2.IVs[(int)Stats.SPD];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_hp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_hp.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.HP] = result;
                updating = false;
                p2_panel_hp.Text = "" + p2.HP;
                p2_totalhp.Text = "/" + p2.HP;
            }
            else
            {
                p2_ev_hp.Text = "" + p2.EVs[(int)Stats.HP];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_atk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_atk.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.ATK] = result;
                updating = false;
                p2_panel_atk.Text = "" + p2.Atk;
            }
            else
            {
                p2_ev_atk.Text = "" + p2.EVs[(int)Stats.ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_def_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_def.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.DEF] = result;
                updating = false;
                p2_panel_def.Text = "" + p2.Def;
            }
            else
            {
                p2_ev_def.Text = "" + p2.EVs[(int)Stats.DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_spatk_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_spatk.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.SP_ATK] = result;
                updating = false;
                p2_panel_spatk.Text = "" + p2.SpAtk;
            }
            else
            {
                p2_ev_spatk.Text = "" + p2.EVs[(int)Stats.SP_ATK];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_spdef_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_spdef.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.SP_DEF] = result;
                updating = false;
                p2_panel_spdef.Text = "" + p2.SpDef;
            }
            else
            {
                p2_ev_spdef.Text = "" + p2.EVs[(int)Stats.SP_DEF];
                updating = false;
            }
            viewDamage();
        }

        private void p2_ev_spd_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_ev_spd.Text, out result) && (result >= 0) && (result <= 255))
            {
                p2.EVs[(int)Stats.SPD] = result;
                updating = false;
                p2_panel_spd.Text = "" + p2.Spd;
            }
            else
            {
                p2_ev_spd.Text = "" + p2.EVs[(int)Stats.SPD];
                updating = false;
            }
            viewDamage();
        }

        private void p2_panel_hp_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_panel_atk_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_panel_def_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_panel_spatk_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_panel_spdef_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_panel_spd_TextChanged(object sender, EventArgs e)
        {
            viewDamage();
        }

        private void p2_stage_atk_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.ATK] = p2_stage_atk.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_def_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.DEF] = p2_stage_def.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_spatk_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.SP_ATK] = p2_stage_spatk.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_spdef_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.SP_DEF] = p2_stage_spdef.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_spd_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.SPD] = p2_stage_spd.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.ACC] = p2_stage_acc.SelectedIndex - 6;
            viewDamage();
        }

        private void p2_stage_eva_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Stages[(int)Stage.EVA] = p2_stage_eva.SelectedIndex - 6;
            viewDamage();
        }

        private void p1_m1_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m1_power.Text, out result) && result >= 0 && result <= 255)
            {
                p1.move1.power = result;
            }
            else {
                p1_m1_power.Text = "" + p1.move1.power;
            }
            updating = false;
            view_p1_m1_damage();
        }

        private void p1_m2_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m2_power.Text, out result) && result >= 0 && result <= 255)
            {
                p1.move2.power = result;
            }
            else
            {
                p1_m2_power.Text = "" + p1.move2.power;
            }
            updating = false;
            view_p1_m2_damage();
        }

        private void p1_m3_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m3_power.Text, out result) && result >= 0 && result <= 255)
            {
                p1.move3.power = result;
            }
            else
            {
                p1_m3_power.Text = "" + p1.move3.power;
            }
            updating = false;
            view_p1_m3_damage();
        }

        private void p1_m4_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m4_power.Text, out result) && result >= 0 && result <= 255)
            {
                p1.move4.power = result;
            }
            else
            {
                p1_m4_power.Text = "" + p1.move4.power;
            }
            updating = false;
            view_p1_m4_damage();
        }

        private void p1_m1_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move1.Type = (Type)p1_m1_type.SelectedIndex;
            updating = false;
            view_p1_m1_damage();
        }

        private void p1_m2_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move2.Type = (Type)p1_m2_type.SelectedIndex;
            updating = false;
            view_p1_m2_damage();
        }

        private void p1_m3_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move3.Type = (Type)p1_m3_type.SelectedIndex;
            updating = false;
            view_p1_m3_damage();
        }

        private void p1_m4_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move3.Type = (Type)p1_m3_type.SelectedIndex;
            updating = false;
            view_p1_m4_damage();
        }

        private void p1_m1_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move1.Category = (String)p1_m1_category.SelectedItem;
            updating = false;
            view_p1_m1_damage();
        }

        private void p1_m2_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move2.Category = (String)p1_m2_category.SelectedItem;
            updating = false;
            view_p1_m2_damage();
        }

        private void p1_m3_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move3.Category = (String)p1_m3_category.SelectedItem;
            updating = false;
            view_p1_m3_damage();
        }

        private void p1_m4_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p1.move4.Category = (String)p1_m4_category.SelectedItem;
            updating = false;
            view_p1_m4_damage();
        }

        private void p1_m1_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m1_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p1.move1.Accuracy = result;
            }
            else
            {
                p1_m1_acc.Text = "" + p1.move1.Accuracy;
            }
            updating = false;
            view_p1_m1_damage();
        }

        private void p1_m2_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m2_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p1.move2.Accuracy = result;
            }
            else
            {
                p1_m2_acc.Text = "" + p1.move2.Accuracy;
            }
            updating = false;
            view_p1_m2_damage();
        }

        private void p1_m3_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m3_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p1.move3.Accuracy = result;
            }
            else
            {
                p1_m3_acc.Text = "" + p1.move3.Accuracy;
            }
            updating = false;
            view_p1_m3_damage();
        }

        private void p1_m4_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p1_m4_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p1.move4.Accuracy = result;
            }
            else
            {
                p1_m4_acc.Text = "" + p1.move4.Accuracy;
            }
            updating = false;
            view_p1_m4_damage();
        }

        private void p1_m1_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.move1.crit = p1_m1_crit.SelectedIndex;
            view_p1_m1_damage();
        }

        private void p1_m2_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.move2.crit = p1_m2_crit.SelectedIndex;
            view_p1_m2_damage();
        }

        private void p1_m3_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.move3.crit = p1_m3_crit.SelectedIndex;
            view_p1_m3_damage();
        }

        private void p1_m4_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.move4.crit = p1_m4_crit.SelectedIndex;
            view_p1_m4_damage();
        }

        private void p1_m1_Z_Click(object sender, EventArgs e)
        {
            p1.move1.Z = !p1.move1.Z;
            if (p1.move1.Z)
            {
                p1_m1_Z.Font = BoldFont;
            }
            else
            {
                p1_m1_Z.Font = RegularFont;
            }
        }

        private void p1_m2_Z_Click(object sender, EventArgs e)
        {
            p1.move2.Z = !p1.move2.Z;
            if (p1.move2.Z)
            {
                p1_m2_Z.Font = BoldFont;
            }
            else
            {
                p1_m2_Z.Font = RegularFont;
            }
        }

        private void p1_m3_Z_Click(object sender, EventArgs e)
        {
            p1.move3.Z = !p1.move3.Z;
            if (p1.move3.Z)
            {
                p1_m3_Z.Font = BoldFont;
            }
            else
            {
                p1_m3_Z.Font = RegularFont;
            }
        }

        private void p1_m4_Z_Click(object sender, EventArgs e)
        {
            p1.move4.Z = !p1.move4.Z;
            if (p1.move4.Z)
            {
                p1_m4_Z.Font = BoldFont;
            }
            else
            {
                p1_m4_Z.Font = RegularFont;
            }
        }

        private void p2_curhp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_curhp.Text, out result) && result >= 0 && result <= p2.HP)
            {
                p2.CurrentHP = result;
                p2_hp_percent.Text = "" + (int)((double)result / (double)p2.HP * 100);
            }
            else
            {
                p2_curhp.Text = "" + p2.CurrentHP;
            }
            updating = false;
        }

        private void p2_hp_percent_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result1, result2;
            if (Int32.TryParse(p2_hp_percent.Text, out result1) && result1 >= 0 && result1 <= 100)
            {
                p2.CurrentHP = result1 * p2.HP / 100;
                p2_curhp.Text = "" + p2.CurrentHP;
            }
            else if (Int32.TryParse(p2_curhp.Text, out result2))
            {
                p2_hp_percent.Text = "" + (int)(((double)result2 / (double)p2.HP) * 100);
            }
            else
            {

            }
            updating = false;
        }

        private void p2_totalhp_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_hp_percent.Text, out result))
            {
                int curhp = result * p2.HP / 100;
                p2_curhp.Text = "" + curhp;
                p2.CurrentHP = curhp;
            }
            updating = false;
        }

        private void p2_move1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p2_move1.SelectedIndex;
            p2.move1.Name = moveTable[index, 0];
            btn_p2_m1.Text = p2.move1.Name;
            p2.move1.power = Int32.Parse(moveTable[index, 2]);
            p2.move1.Type = Pokemon.stringToType(moveTable[index, 3]);
            p2.move1.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p2_m1_acc.Enabled = true;
                p2.move1.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p2.move1.Accuracy = 0;
                p2_m1_acc.Text = "--";
                p2_m1_acc.Enabled = false;
            }
            updating = true;
            p2_m1_power.Text = moveTable[index, 2];
            p2_m1_type.SelectedIndex = (int)p2.move1.Type;
            p2_m1_category.SelectedItem = p2.move1.Category;
            p2_m1_acc.Text = moveTable[index, 5];
            updating = false;
            view_p2_m1_damage();
        }

        private void p2_move2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p2_move2.SelectedIndex;
            p2.move2.Name = moveTable[index, 0];
            btn_p2_m2.Text = p2.move2.Name;
            p2.move2.power = Int32.Parse(moveTable[index, 2]);
            p2.move2.Type = Pokemon.stringToType(moveTable[index, 3]);
            p2.move2.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p2_m2_acc.Enabled = true;
                p2.move2.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p2.move2.Accuracy = 0;
                p2_m2_acc.Text = "--";
                p2_m2_acc.Enabled = false;
            }
            updating = true;
            p2_m2_power.Text = moveTable[index, 2];
            p2_m2_type.SelectedIndex = (int)p2.move2.Type;
            p2_m2_category.SelectedItem = p2.move2.Category;
            p2_m2_acc.Text = moveTable[index, 5];
            updating = false;
            view_p2_m2_damage();
        }

        private void p2_move3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p2_move3.SelectedIndex;
            p2.move3.Name = moveTable[index, 0];
            btn_p2_m3.Text = p2.move3.Name;
            p2.move3.power = Int32.Parse(moveTable[index, 2]);
            p2.move3.Type = Pokemon.stringToType(moveTable[index, 3]);
            p2.move3.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p2_m3_acc.Enabled = true;
                p2.move3.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p2.move3.Accuracy = 0;
                p2_m3_acc.Text = "--";
                p2_m3_acc.Enabled = false;
            }
            updating = true;
            p2_m3_power.Text = moveTable[index, 2];
            p2_m3_type.SelectedIndex = (int)p2.move3.Type;
            p2_m3_category.SelectedItem = p2.move3.Category;
            p2_m3_acc.Text = moveTable[index, 5];
            updating = false;
            view_p2_m3_damage();
        }

        private void p2_move4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = p2_move4.SelectedIndex;
            p2.move4.Name = moveTable[index, 0];
            btn_p2_m4.Text = p2.move4.Name;
            p2.move4.power = Int32.Parse(moveTable[index, 2]);
            p2.move4.Type = Pokemon.stringToType(moveTable[index, 3]);
            p2.move4.Category = moveTable[index, 4];
            String acc = moveTable[index, 5];
            if (!acc.Equals("null") && !acc.Equals(""))
            {
                p2_m4_acc.Enabled = true;
                p2.move4.Accuracy = Int32.Parse(moveTable[index, 5]);
            }
            else
            {
                p2.move4.Accuracy = 0;
                p2_m4_acc.Text = "--";
                p2_m4_acc.Enabled = false;
            }
            updating = true;
            p2_m4_power.Text = moveTable[index, 2];
            p2_m4_type.SelectedIndex = (int)p2.move4.Type;
            p2_m4_category.SelectedItem = p2.move4.Category;
            p2_m4_acc.Text = moveTable[index, 5];
            updating = false;
            view_p2_m4_damage();
        }

        private void p2_m1_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m1_power.Text, out result) && result >= 0 && result <= 255)
            {
                p2.move1.power = result;
            }
            else
            {
                p2_m1_power.Text = "" + p2.move1.power;
            }
            updating = false;
            view_p2_m1_damage();
        }

        private void p2_m2_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m2_power.Text, out result) && result >= 0 && result <= 255)
            {
                p2.move2.power = result;
            }
            else
            {
                p2_m2_power.Text = "" + p2.move2.power;
            }
            updating = false;
            view_p2_m2_damage();
        }

        private void p2_m3_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m3_power.Text, out result) && result >= 0 && result <= 255)
            {
                p2.move3.power = result;
            }
            else
            {
                p2_m3_power.Text = "" + p2.move3.power;
            }
            updating = false;
            view_p2_m3_damage();
        }

        private void p2_m4_power_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m4_power.Text, out result) && result >= 0 && result <= 255)
            {
                p2.move4.power = result;
            }
            else
            {
                p2_m4_power.Text = "" + p2.move4.power;
            }
            updating = false;
            view_p2_m4_damage();
        }

        private void p2_m1_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move1.Type = (Type)p2_m1_type.SelectedIndex;
            updating = false;
            view_p2_m1_damage();
        }

        private void p2_m2_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move2.Type = (Type)p2_m2_type.SelectedIndex;
            updating = false;
            view_p2_m2_damage();
        }

        private void p2_m3_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move3.Type = (Type)p2_m3_type.SelectedIndex;
            updating = false;
            view_p2_m3_damage();
        }

        private void p2_m4_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move3.Type = (Type)p2_m3_type.SelectedIndex;
            updating = false;
            view_p2_m4_damage();
        }

        private void p2_m1_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move1.Category = (String)p2_m1_category.SelectedItem;
            updating = false;
            view_p2_m1_damage();
        }

        private void p2_m2_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move2.Category = (String)p2_m2_category.SelectedItem;
            updating = false;
            view_p2_m2_damage();
        }

        private void p2_m3_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move3.Category = (String)p2_m3_category.SelectedItem;
            updating = false;
            view_p2_m3_damage();
        }

        private void p2_m4_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            p2.move4.Category = (String)p2_m4_category.SelectedItem;
            updating = false;
            view_p2_m4_damage();
        }

        private void p2_m1_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m1_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p2.move1.Accuracy = result;
            }
            else
            {
                p2_m1_acc.Text = "" + p2.move1.Accuracy;
            }
            updating = false;
            view_p2_m1_damage();
        }

        private void p2_m2_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m2_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p2.move2.Accuracy = result;
            }
            else
            {
                p2_m2_acc.Text = "" + p2.move2.Accuracy;
            }
            updating = false;
            view_p2_m2_damage();
        }

        private void p2_m3_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m3_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p2.move3.Accuracy = result;
            }
            else
            {
                p2_m3_acc.Text = "" + p2.move3.Accuracy;
            }
            updating = false;
            view_p2_m3_damage();
        }

        private void p2_m4_acc_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            int result;
            if (Int32.TryParse(p2_m4_acc.Text, out result) && result >= 0 && result <= 100)
            {
                p2.move4.Accuracy = result;
            }
            else
            {
                p2_m4_acc.Text = "" + p2.move4.Accuracy;
            }
            updating = false;
            view_p2_m4_damage();
        }

        private void p2_m1_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.move1.crit = p2_m1_crit.SelectedIndex;
            view_p2_m1_damage();
        }

        private void p2_m2_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.move2.crit = p2_m2_crit.SelectedIndex;
            view_p2_m2_damage();
        }

        private void p2_m3_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.move3.crit = p2_m3_crit.SelectedIndex;
            view_p2_m3_damage();
        }

        private void p2_m4_crit_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.move4.crit = p2_m4_crit.SelectedIndex;
            view_p2_m4_damage();
        }

        private void p2_m1_Z_Click(object sender, EventArgs e)
        {
            p2.move1.Z = !p2.move1.Z;
            if (p2.move1.Z)
            {
                p2_m1_Z.Font = BoldFont;
            }
            else
            {
                p2_m1_Z.Font = RegularFont;
            }
        }

        private void p2_m2_Z_Click(object sender, EventArgs e)
        {
            p2.move2.Z = !p2.move2.Z;
            if (p2.move2.Z)
            {
                p2_m2_Z.Font = BoldFont;
            }
            else
            {
                p2_m2_Z.Font = RegularFont;
            }
        }

        private void p2_m3_Z_Click(object sender, EventArgs e)
        {
            p2.move3.Z = !p2.move3.Z;
            if (p2.move3.Z)
            {
                p2_m3_Z.Font = BoldFont;
            }
            else
            {
                p2_m3_Z.Font = RegularFont;
            }
        }

        private void p2_m4_Z_Click(object sender, EventArgs e)
        {
            p2.move4.Z = !p2.move4.Z;
            if (p2.move4.Z)
            {
                p2_m4_Z.Font = BoldFont;
            }
            else
            {
                p2_m4_Z.Font = RegularFont;
            }
        }

        private void view_p1_m1_damage()
        {
            int damage1 = Calculator.calculateDamage(p1, p1.move1, p2, random: 0.85);
            int damage2 = Calculator.calculateDamage(p1, p1.move1, p2);
            double min = (1.0 * damage1 / p2.HP * 100);
            double max = (1.0 * damage2 / p2.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p1_m1_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p1_m2_damage()
        {
            int damage1 = Calculator.calculateDamage(p1, p1.move2, p2, random: 0.85);
            int damage2 = Calculator.calculateDamage(p1, p1.move2, p2);
            double min = (1.0 * damage1 / p2.HP * 100);
            double max = (1.0 * damage2 / p2.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p1_m2_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p1_m3_damage()
        {
            int damage1 = Calculator.calculateDamage(p1, p1.move3, p2, random: 0.85);
            int damage2 = Calculator.calculateDamage(p1, p1.move3, p2);
            double min = (1.0 * damage1 / p2.HP * 100);
            double max = (1.0 * damage2 / p2.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p1_m3_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p1_m4_damage()
        {
            int damage1 = Calculator.calculateDamage(p1, p1.move4, p2, random: 0.85);
            int damage2 = Calculator.calculateDamage(p1, p1.move4, p2);
            double min = (1.0 * damage1/ p2.HP * 100);
            double max = (1.0 * damage2 / p2.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p1_m4_damage.Text = s1 + "% ~ " + s2 + "%";
        }

        private void view_p2_m1_damage()
        {
            int damage1 = Calculator.calculateDamage(p2, p2.move1, p1, random: 0.85);
            int damage2 = Calculator.calculateDamage(p2, p2.move1, p1);
            double min = (1.0 * damage1 / p1.HP * 100);
            double max = (1.0 * damage2 / p1.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p2_m1_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p2_m2_damage()
        {
            int damage1 = Calculator.calculateDamage(p2, p2.move2, p1, random: 0.85);
            int damage2 = Calculator.calculateDamage(p2, p2.move2, p1);
            double min = (1.0 * damage1 / p1.HP * 100);
            double max = (1.0 * damage2 / p1.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p2_m2_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p2_m3_damage()
        {
            int damage1 = Calculator.calculateDamage(p2, p2.move3, p1, random: 0.85);
            int damage2 = Calculator.calculateDamage(p2, p2.move3, p1);
            double min = (1.0 * damage1 / p1.HP * 100);
            double max = (1.0 * damage2 / p1.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p2_m3_damage.Text = s1 + "% ~ " + s2 + "%";
        }
        private void view_p2_m4_damage()
        {
            int damage1 = Calculator.calculateDamage(p2, p2.move4, p1, random: 0.85);
            int damage2 = Calculator.calculateDamage(p2, p2.move4, p1);
            double min = (1.0 * damage1 / p1.HP * 100);
            double max = (1.0 * damage2 / p1.HP * 100);
            String s1 = String.Format("{0:0.0}", min);
            String s2 = String.Format("{0:0.0}", max);
            p2_m4_damage.Text = s1 + "% ~ " + s2 + "%";
        }

        private void btn_single_Click(object sender, EventArgs e)
        {
            if (!f.Singles)
            {
                f.Singles = true;
                btn_single.Font = BoldFont;
                btn_double.Font = RegularFont;
            }
        }

        private void btn_double_Click(object sender, EventArgs e)
        {
            if (!f.Doubles)
            {
                f.Doubles = true;
                btn_single.Font = RegularFont;
                btn_double.Font = BoldFont;
            }
        }

        private void weather_Click(object sender, EventArgs e)
        {
            weather_none.Font = RegularFont;
            weather_hail.Font = RegularFont;
            weather_harshsun.Font = RegularFont;
            weather_heavyrain.Font = RegularFont;
            weather_rain.Font = RegularFont;
            weather_sand.Font = RegularFont;
            weather_strongwind.Font = RegularFont;
            weather_sun.Font = RegularFont;
            switch (((System.Windows.Forms.Button)sender).Text)
            {
                case "无":
                    f.Weather = Weather.None;
                    weather_none.Font = BoldFont;
                    break;
                case "冰雹":
                    f.Weather = Weather.Hail;
                    weather_hail.Font = BoldFont;
                    break;
                case "大日照":
                    f.Weather = Weather.Harsh_Sun;
                    weather_harshsun.Font = BoldFont;
                    break;
                case "大雨天":
                    f.Weather = Weather.Heavy_Rain;
                    weather_heavyrain.Font = BoldFont;
                    break;
                case "下雨":
                    f.Weather = Weather.Rain;
                    weather_rain.Font = BoldFont;
                    break;
                case "沙暴":
                    f.Weather = Weather.Sand;
                    weather_sand.Font = BoldFont;
                    break;
                case "乱流":
                    f.Weather = Weather.Strong_Winds;
                    weather_strongwind.Font = BoldFont;
                    break;
                case "晴天":
                    f.Weather = Weather.Sun;
                    weather_sun.Font = BoldFont;
                    break;
            }

        }

        private void terrain_Click(object sender, EventArgs e)
        {
            terrain_electric.Font = RegularFont;
            terrain_grassy.Font = RegularFont;
            terrain_misty.Font = RegularFont;
            terrain_psychic.Font = RegularFont;
            
            switch (((System.Windows.Forms.Button)sender).Text) {
                case "电气场地":
                    f.terrain_electric = !f.terrain_electric;
                    if (f.terrain_electric) {
                        f.terrain_grassy = false;
                        f.terrain_misty = false;
                        f.terrain_psychic = false;
                        terrain_electric.Font = BoldFont;
                    }
                    break;
                case "青草场地":
                    f.terrain_grassy = !f.terrain_grassy;
                    if (f.terrain_grassy)
                    {
                        f.terrain_electric = false;
                        f.terrain_misty = false;
                        f.terrain_psychic = false;
                        terrain_grassy.Font = BoldFont;
                    }
                    break;
                case "薄雾场地":
                    f.terrain_misty = !f.terrain_misty;
                    if (f.terrain_misty) {
                        f.terrain_electric = false;
                        f.terrain_grassy = false;
                        f.terrain_psychic = false;
                        terrain_misty.Font = BoldFont;
                    }
                    break;
                case "精神场地":
                    f.terrain_psychic = !f.terrain_psychic;
                    if (f.terrain_psychic) {
                        f.terrain_electric = false;
                        f.terrain_grassy = false;
                        f.terrain_misty = false;
                        terrain_psychic.Font = BoldFont;
                    }
                    break;
            }
        }

        private void stealth_rock_1_Click(object sender, EventArgs e)
        {
            f.StealthRock_1 = !f.StealthRock_1;
            stealth_rock_1.Font = (f.StealthRock_1)?BoldFont:RegularFont;
        }

        private void stealth_rock_2_Click(object sender, EventArgs e)
        {
            f.StealthRock_2 = !f.StealthRock_2;
            stealth_rock_2.Font = (f.StealthRock_2) ? BoldFont : RegularFont;
        }

        private void reflect_1_Click(object sender, EventArgs e)
        {
            f.Reflect_1 = !f.Reflect_1;
            reflect_1.Font = (f.Reflect_1) ? BoldFont : RegularFont;
        }

        private void reflect_2_Click(object sender, EventArgs e)
        {
            f.Reflect_2 = !f.Reflect_2;
            reflect_2.Font = (f.Reflect_2) ? BoldFont : RegularFont;
        }

        private void light_screen_1_Click(object sender, EventArgs e)
        {
            f.LightScreen_1 = !f.LightScreen_1;
            light_screen_1.Font = (f.LightScreen_1) ? BoldFont : RegularFont;
        }

        private void light_screen_2_Click(object sender, EventArgs e)
        {
            f.LightScreen_2 = !f.LightScreen_2;
            light_screen_2.Font = (f.LightScreen_2) ? BoldFont : RegularFont;
        }

        private void protect_1_Click(object sender, EventArgs e)
        {
            f.Protect_1 = !f.Protect_1;
            protect_1.Font = (f.Protect_1) ? BoldFont : RegularFont;
        }

        private void protect_2_Click(object sender, EventArgs e)
        {
            f.Protect_2 = !f.Protect_2;
            protect_2.Font = (f.Protect_2) ? BoldFont : RegularFont;
        }

        private void leech_seed_1_Click(object sender, EventArgs e)
        {
            f.LeechSeed_1 = !f.LeechSeed_1;
            leech_seed_1.Font = (f.LeechSeed_1) ? BoldFont : RegularFont;
        }

        private void leech_seed_2_Click(object sender, EventArgs e)
        {
            f.LeechSeed_2 = !f.LeechSeed_2;
            leech_seed_2.Font = (f.LeechSeed_2) ? BoldFont : RegularFont;
        }

        private void foresight_1_Click(object sender, EventArgs e)
        {
            f.Foresight_1 = !f.Foresight_1;
            foresight_1.Font = (f.Foresight_1) ? BoldFont : RegularFont;
        }

        private void foresight_2_Click(object sender, EventArgs e)
        {
            f.Foresight_2 = !f.Foresight_2;
            foresight_2.Font = (f.Foresight_2) ? BoldFont : RegularFont;
        }

        private void helping_hand_1_Click(object sender, EventArgs e)
        {
            f.HelpingHand_1 = !f.HelpingHand_1;
            helping_hand_1.Font = (f.HelpingHand_1) ? BoldFont : RegularFont;
        }

        private void hightLight(object sender, EventArgs e) {
            if (((Button)sender).Font.Bold)
            {
                ((Button)sender).BackColor = System.Drawing.SystemColors.Menu;
            }
            else {
                ((Button)sender).UseVisualStyleBackColor = true;
            }
        }

        private void helping_hand_2_Click(object sender, EventArgs e)
        {
            f.HelpingHand_2 = !f.HelpingHand_2;
            helping_hand_2.Font = (f.HelpingHand_2) ? BoldFont : RegularFont;
        }

        private void friend_guard_1_Click(object sender, EventArgs e)
        {
            f.FriendGuard_1 = !f.FriendGuard_1;
            friend_guard_1.Font = (f.FriendGuard_1) ? BoldFont : RegularFont;
        }

        private void friend_guard_2_Click(object sender, EventArgs e)
        {
            f.FriendGuard_2 = !f.FriendGuard_2;
            friend_guard_2.Font = (f.FriendGuard_2) ? BoldFont : RegularFont;
        }

        private void aurora_veil_1_Click(object sender, EventArgs e)
        {
            f.AuroraVeil_1 = !f.AuroraVeil_1;
            aurora_veil_1.Font = (f.AuroraVeil_1) ? BoldFont : RegularFont;
        }

        private void aurora_veil_2_Click(object sender, EventArgs e)
        {
            f.AuroraVeil_2 = !f.AuroraVeil_2;
            aurora_veil_2.Font = (f.AuroraVeil_2) ? BoldFont : RegularFont;
        }

        private void spikes_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            f.Spikes_1 = spikes_1.SelectedIndex;
        }

        private void spikes_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            f.Spikes_2 = spikes_2.SelectedIndex;
        }
    }
}
