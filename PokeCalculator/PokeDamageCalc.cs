using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace PokeCalculator
{
    public partial class PokeDamageCalc : Form
    {
        Pokemon p1;
        Pokemon p2;
        String[,] pokemonTable;
        String[,] moveTable;
        String[,] abilityTable;
        private List<int> currentPokemonFormsIndex; 


        public PokeDamageCalc()
        {
            InitializeComponent();
        }

        private void PokeDamageCalc_Load(object sender, EventArgs e)
        {
            DataReader reader = new DataReader(@"" + Application.StartupPath + "/../../db/pokemon.xlsx");
            pokemonTable = reader.dataSheet(1);
            moveTable = reader.dataSheet(2);
            InitializePokemonCombobox();
            InitializeTypeCombobox();
            InitializeNatureCombobox();
            InitializeStatusCombobox();
            InitializeItemCombobox();
            //InitializeStats();
            InitializeMove();
            InitializeStage();
            p1 = new Pokemon();
            p2 = new Pokemon();
            DisplayPokemon1(p1);
            DisplayPokemon2(p2);
            viewDamage();
        }

        private void InitializePokemonCombobox() {
            int nrow = pokemonTable.GetLength(0);
            for (int i = 0; i < nrow; i++) {
                String pokemonName = pokemonTable[i,1];
                comboBox1.Items.Add(pokemonName);
                comboBox58.Items.Add(pokemonName);
            }

        }

        private void InitializeTypeCombobox() {
            for (int i = 0; i < 19; i++) {
                //pokemon type 1/2
                comboBox2.Items.Add(Pokemon.typeToString((Type)i));
                comboBox3.Items.Add(Pokemon.typeToString((Type)i));
                comboBox57.Items.Add(Pokemon.typeToString((Type)i));
                comboBox56.Items.Add(Pokemon.typeToString((Type)i));
                //moves type
                comboBox15.Items.Add(Pokemon.typeToString((Type)i));
                comboBox20.Items.Add(Pokemon.typeToString((Type)i));
                comboBox24.Items.Add(Pokemon.typeToString((Type)i));
                comboBox28.Items.Add(Pokemon.typeToString((Type)i));
                comboBox44.Items.Add(Pokemon.typeToString((Type)i));
                comboBox40.Items.Add(Pokemon.typeToString((Type)i));
                comboBox36.Items.Add(Pokemon.typeToString((Type)i));
                comboBox32.Items.Add(Pokemon.typeToString((Type)i));

            }
        }
        private void InitializeNatureCombobox() {
            for (int i = 0; i < 25; i++)
            {
                comboBox10.Items.Add(Pokemon.natureToString((Nature)i));
                comboBox49.Items.Add(Pokemon.natureToString((Nature)i));
            }
        }
        private void InitializeStatusCombobox() {
            for (int i = 0; i < 7; i++) {
                comboBox13.Items.Add(Pokemon.statusToString((Status)i));
                comboBox46.Items.Add(Pokemon.statusToString((Status)i));
            }
        }

        private void InitializeItemCombobox()
        {
            comboBox12.Items.Add("(无)");
            comboBox47.Items.Add("(无)");
            for (int i = 0; i < 7; i++)
            {
                comboBox12.Items.Add("Life Ord");
                comboBox47.Items.Add("Life Ord");
            }
            comboBox12.SelectedIndex = 0;
            comboBox47.SelectedIndex = 0;
        }

        private void InitializeMove()
        {
            int nrow = moveTable.GetLength(0);
            for (int i = 0; i < nrow; i++) 
            {
                comboBox14.Items.Add(moveTable[i, 0]);
                comboBox21.Items.Add(moveTable[i, 0]);
                comboBox25.Items.Add(moveTable[i, 0]);
                comboBox29.Items.Add(moveTable[i, 0]);
                comboBox45.Items.Add(moveTable[i, 0]);
                comboBox41.Items.Add(moveTable[i, 0]);
                comboBox37.Items.Add(moveTable[i, 0]);
                comboBox33.Items.Add(moveTable[i, 0]);
            }

            
            comboBox17.SelectedIndex = 0;
            comboBox18.SelectedIndex = 0;
            comboBox22.SelectedIndex = 0;
            comboBox26.SelectedIndex = 0;
            comboBox42.SelectedIndex = 0;
            comboBox38.SelectedIndex = 0;
            comboBox34.SelectedIndex = 0;
            comboBox30.SelectedIndex = 0;

        }



        public void InitializeStage()
        {
            for (int i = 6; i > 0; i--) {
                comboBox5.Items.Add("+" + i);
                comboBox6.Items.Add("+" + i);
                comboBox8.Items.Add("+" + i);
                comboBox7.Items.Add("+" + i);
                comboBox9.Items.Add("+" + i);
                comboBox60.Items.Add("+" + i);
                comboBox59.Items.Add("+" + i);
                comboBox61.Items.Add("+" + i);
                comboBox62.Items.Add("+" + i);
            }
            comboBox5.Items.Add("" + 0);
            comboBox6.Items.Add("" + 0);
            comboBox8.Items.Add("" + 0);
            comboBox7.Items.Add("" + 0);
            comboBox9.Items.Add("" + 0);
            comboBox60.Items.Add("" + 0);
            comboBox59.Items.Add("" + 0);
            comboBox61.Items.Add("" + 0);
            comboBox62.Items.Add("" + 0);
            for (int i = 1; i <= 6; i++)
            {
                comboBox5.Items.Add("-" + i);
                comboBox6.Items.Add("-" + i);
                comboBox8.Items.Add("-" + i);
                comboBox7.Items.Add("-" + i);
                comboBox9.Items.Add("-" + i);
                comboBox60.Items.Add("-" + i);
                comboBox59.Items.Add("-" + i);
                comboBox61.Items.Add("-" + i);
                comboBox62.Items.Add("-" + i);
            }
            comboBox5.SelectedIndex = 6;
            comboBox6.SelectedIndex = 6;
            comboBox8.SelectedIndex = 6;
            comboBox7.SelectedIndex = 6;
            comboBox9.SelectedIndex = 6;
            comboBox60.SelectedIndex = 6;
            comboBox59.SelectedIndex = 6;
            comboBox61.SelectedIndex = 6;
            comboBox62.SelectedIndex = 6;
        }

        private void DisplayPokemon1(Pokemon p) {
            comboBox2.SelectedIndex = (int)p.Type1;
            comboBox3.SelectedIndex = (int)p.Type2;
            textBox1.Text = "" + p.level;
            label36.Text = "" + p.HP;
            label37.Text = "" + p.Atk;
            label38.Text = "" + p.Def;
            label39.Text = "" + p.SpAtk;
            label40.Text = "" + p.SpDef;
            label41.Text = "" + p.Spd;
            label61.Text = "" + p.HP;
            comboBox10.SelectedIndex = (int)p.Nature;
            comboBox11.SelectedItem = p.Ability;
            comboBox12.SelectedItem = p.Item;
            comboBox13.SelectedIndex = (int)p.Status;
            textBox20.Text = "" + p.CurrentHP;
            //
            comboBox14.SelectedItem = p.move1.Name;
            textBox21.Text = "" + p.move1.power;
            comboBox15.SelectedItem = Pokemon.typeToString(p.move1.Type);
            comboBox16.SelectedItem = p.move1.Category;
            //
            comboBox21.SelectedItem = p.move2.Name;
            textBox22.Text = "" + p.move2.power;
            comboBox20.SelectedItem = Pokemon.typeToString(p.move2.Type);
            comboBox19.SelectedItem = p.move2.Category;
            //
            comboBox25.SelectedItem = p.move3.Name;
            textBox23.Text = "" + p.move3.power;
            comboBox24.SelectedItem = Pokemon.typeToString(p.move3.Type);
            comboBox23.SelectedItem = p.move3.Category;
            //
            comboBox29.SelectedItem = p.move4.Name;
            textBox24.Text = "" + p.move4.power;
            comboBox28.SelectedItem = Pokemon.typeToString(p.move4.Type);
            comboBox27.SelectedItem = p.move4.Category;

        }


        private void UpdatePokemon1Instance()
        {
            p1.Type1 = (Type)comboBox2.SelectedIndex;
            p1.Type2 = (Type)comboBox3.SelectedIndex;
            //p1.Forme = currentPokemonFormsIndex;
            p1.Item = comboBox12.SelectedItem.ToString();
            p1.level = Int32.Parse(textBox1.Text);
            p1.Ability = comboBox11.SelectedItem.ToString();
            p1.Bases[(int)Stats.HP] = Int32.Parse(textBox2.Text);
            p1.Bases[(int)Stats.ATK] = Int32.Parse(textBox7.Text);
            p1.Bases[(int)Stats.DEF] = Int32.Parse(textBox10.Text);
            p1.Bases[(int)Stats.SP_ATK] = Int32.Parse(textBox13.Text);
            p1.Bases[(int)Stats.SP_DEF] = Int32.Parse(textBox16.Text);
            p1.Bases[(int)Stats.SPD] = Int32.Parse(textBox19.Text);
            p1.IVs[(int)Stats.HP] = Int32.Parse(textBox3.Text);
            p1.IVs[(int)Stats.ATK] = Int32.Parse(textBox6.Text);
            p1.IVs[(int)Stats.DEF] = Int32.Parse(textBox9.Text);
            p1.IVs[(int)Stats.SP_ATK] = Int32.Parse(textBox12.Text);
            p1.IVs[(int)Stats.SP_DEF] = Int32.Parse(textBox15.Text);
            p1.IVs[(int)Stats.SPD] = Int32.Parse(textBox18.Text);
            p1.EVs[(int)Stats.HP] = Int32.Parse(textBox4.Text);
            p1.EVs[(int)Stats.ATK] = Int32.Parse(textBox5.Text);
            p1.EVs[(int)Stats.DEF] = Int32.Parse(textBox8.Text);
            p1.EVs[(int)Stats.SP_ATK] = Int32.Parse(textBox11.Text);
            p1.EVs[(int)Stats.SP_DEF] = Int32.Parse(textBox14.Text);
            p1.EVs[(int)Stats.SPD] = Int32.Parse(textBox17.Text);

        }

        private void displayResult1() {
            label36.Text = "" + p1.HP;
            label37.Text = "" + p1.Atk;
            label38.Text = "" + p1.Def;
            label39.Text = "" + p1.SpAtk;
            label40.Text = "" + p1.SpDef;
            label41.Text = "" + p1.Spd;
            label61.Text = "/" + p1.HP;
        }

        private void DisplayPokemon2(Pokemon p)
        {
            comboBox57.SelectedIndex = (int)p.Type1;
            comboBox56.SelectedIndex = (int)p.Type2;
            textBox48.Text = "" + p.level;
            label47.Text = "" + p.HP;
            label46.Text = "" + p.Atk;
            label45.Text = "" + p.Def;
            label44.Text = "" + p.SpAtk;
            label43.Text = "" + p.SpDef;
            label42.Text = "" + p.Spd;
            label62.Text = "" + p.HP;
            comboBox49.SelectedIndex = (int)p.Nature;
            comboBox48.SelectedItem = p.Ability;
            comboBox47.SelectedItem = p.Item;
            comboBox46.SelectedIndex = (int)p.Status;
            textBox29.Text = "" + p.CurrentHP;
            //
            comboBox45.SelectedItem = p.move1.Name;
            textBox28.Text = "" + p.move1.power;
            comboBox44.SelectedItem = Pokemon.typeToString(p.move1.Type);
            comboBox43.SelectedItem = p.move1.Category;
            //
            comboBox41.SelectedItem = p.move2.Name;
            textBox27.Text = "" + p.move2.power;
            comboBox40.SelectedItem = Pokemon.typeToString(p.move2.Type);
            comboBox39.SelectedItem = p.move2.Category;
            //
            comboBox37.SelectedItem = p.move3.Name;
            textBox26.Text = "" + p.move3.power;
            comboBox36.SelectedItem = Pokemon.typeToString(p.move3.Type);
            comboBox35.SelectedItem = p.move3.Category;
            //
            comboBox33.SelectedItem = p.move4.Name;
            textBox25.Text = "" + p.move4.power;
            comboBox32.SelectedItem = Pokemon.typeToString(p.move4.Type);
            comboBox31.SelectedItem = p.move4.Category;
        }

        private void UpdatePokemon2Instance()
        {
            p2.Type1 = (Type)comboBox57.SelectedIndex;
            p2.Type2 = (Type)comboBox56.SelectedIndex;
            //p2.Forme = currentPokemonFormsIndex;
            p2.Item = comboBox47.SelectedItem.ToString();
            p2.level = Int32.Parse(textBox48.Text);
            p2.Ability = comboBox48.SelectedItem.ToString();
            p2.Bases[(int)Stats.HP] = Int32.Parse(textBox47.Text);
            p2.Bases[(int)Stats.ATK] = Int32.Parse(textBox44.Text);
            p2.Bases[(int)Stats.DEF] = Int32.Parse(textBox41.Text);
            p2.Bases[(int)Stats.SP_ATK] = Int32.Parse(textBox38.Text);
            p2.Bases[(int)Stats.SP_DEF] = Int32.Parse(textBox35.Text);
            p2.Bases[(int)Stats.SPD] = Int32.Parse(textBox32.Text);
            p2.IVs[(int)Stats.HP] = Int32.Parse(textBox46.Text);
            p2.IVs[(int)Stats.ATK] = Int32.Parse(textBox43.Text);
            p2.IVs[(int)Stats.DEF] = Int32.Parse(textBox40.Text);
            p2.IVs[(int)Stats.SP_ATK] = Int32.Parse(textBox37.Text);
            p2.IVs[(int)Stats.SP_DEF] = Int32.Parse(textBox34.Text);
            p2.IVs[(int)Stats.SPD] = Int32.Parse(textBox31.Text);
            p2.EVs[(int)Stats.HP] = Int32.Parse(textBox45.Text);
            p2.EVs[(int)Stats.ATK] = Int32.Parse(textBox42.Text);
            p2.EVs[(int)Stats.DEF] = Int32.Parse(textBox39.Text);
            p2.EVs[(int)Stats.SP_ATK] = Int32.Parse(textBox36.Text);
            p2.EVs[(int)Stats.SP_DEF] = Int32.Parse(textBox33.Text);
            p2.EVs[(int)Stats.SPD] = Int32.Parse(textBox30.Text);

        }

        private void displayResult2()
        {
            label47.Text = "" + p1.HP;
            label46.Text = "" + p1.Atk;
            label45.Text = "" + p1.Def;
            label44.Text = "" + p1.SpAtk;
            label43.Text = "" + p1.SpDef;
            label42.Text = "" + p1.Spd;
            label62.Text = "/" + p1.HP;
        }

        private void viewDamage() {
            label18.Text = "" + Calculator.calculateDamage(p1, p1.move1, p2);
        }

        //pokemon selection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            //Types
            comboBox2.SelectedItem = pokemonTable[index, 3];
            if (pokemonTable[index, 4].Equals(""))
                comboBox3.SelectedIndex = 0;
            else
                comboBox3.SelectedItem = pokemonTable[index, 4];
            //forms
            comboBox4.Items.Clear();
            currentPokemonFormsIndex = new List<int>();
            if (pokemonTable[index, 5].Equals("1")) {
                comboBox4.Enabled = true;
                String dexNum = pokemonTable[index, 0];
                for (int i = 0; i < pokemonTable.GetLength(0); i++) {
                    if (dexNum.Equals(pokemonTable[i, 0])) {
                        comboBox4.Items.Add(pokemonTable[i, 1]);
                        currentPokemonFormsIndex.Add(i);
                    }
                }
                comboBox4.SelectedIndex = 0;
                p1.Forme = currentPokemonFormsIndex;
            }
            else {
                comboBox4.Enabled = false;
            }
            //ability
            comboBox11.Items.Clear();
            for (int i = 12; i < 15; i++) {
                String to_add = pokemonTable[index, i];
                if (!to_add.Equals(""))
                    comboBox11.Items.Add(to_add);
            }
            comboBox11.SelectedIndex = 0;

            //stats
            textBox2.Text = pokemonTable[index, 6];
            textBox7.Text = pokemonTable[index, 7];
            textBox10.Text = pokemonTable[index, 8];
            textBox13.Text = pokemonTable[index, 9];
            textBox16.Text = pokemonTable[index, 10];
            textBox19.Text = pokemonTable[index, 11];

            UpdatePokemon1Instance();
            displayResult1();

            textBox20.Text = "" + p1.HP;
            textBox57.Text = "" + 100;
        }


        private void comboBox58_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Types
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
            p1.Type1 = (Type)comboBox2.SelectedIndex;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            p1.Type2 = (Type)comboBox3.SelectedIndex;
        }
        private void comboBox57_SelectedIndexChanged(object sender, EventArgs e) {
            p2.Type1 = (Type)comboBox57.SelectedIndex;
        }
        private void comboBox56_SelectedIndexChanged(object sender, EventArgs e) {
            p2.Type2 = (Type)comboBox56.SelectedIndex;
        }

        //Natures
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            p1.Nature = (Nature)comboBox10.SelectedIndex;
        }
        private void comboBox49_SelectedIndexChanged(object sender, EventArgs e)
        {
            p2.Nature = (Nature)comboBox49.SelectedIndex;
        }
    }
}
