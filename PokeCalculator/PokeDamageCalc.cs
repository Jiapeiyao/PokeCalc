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
        DataReader pokemonReader;

        public PokeDamageCalc()
        {
            String[] tmp = Assembly.GetExecutingAssembly().GetManifestResourceNames();

            foreach (String i in tmp) {
                Console.Out.WriteLine(i);
            }

            Console.Out.WriteLine( Assembly.GetExecutingAssembly().GetManifestResourceStream("PokeCalculator.pokemon.xlsx") );

            //InitializeComponent();
        }

        private void PokeDamageCalc_Load(object sender, EventArgs e)
        {
            InitializePokemonCombobox();
            InitializeTypeCombobox();
            InitializeNatureCombobox();
            InitializeStatusCombobox();
            InitializeItemCombobox();
            InitializeMove();
            p1 = new Pokemon();
            p2 = new Pokemon();
            LoadPokemon1(p1);
            LoadPokemon2(p2);
            viewDamage();
        }

        private void InitializePokemonCombobox() {
            //String path = Assembly.GetExecutingAssembly().GetManifestResourceStream("PokeDamageCalc.pokemon.xlsx");
            pokemonReader = new DataReader(@"PokeCalculator.pokemon.xlsx", 1);
            for (int i = 0; i < pokemonReader.nrow; i++) {
                String pokemonName = pokemonReader.ReadCell(i, 1).Trim();
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
            for (int i = 0; i < 7; i++)
            {
                comboBox12.Items.Add("Life Ord");
                comboBox47.Items.Add("Life Ord");
            }
        }

        private void InitializeMove()
        {
            // move names
            String[] moveList = new String[4] { "Ice Shard", "Blizzard", "Giga Drain", "Earthquake" };
            foreach (String m in moveList)
            {
                comboBox14.Items.Add(m);
                comboBox21.Items.Add(m);
                comboBox25.Items.Add(m);
                comboBox29.Items.Add(m);
                comboBox45.Items.Add(m);
                comboBox41.Items.Add(m);
                comboBox37.Items.Add(m);
                comboBox33.Items.Add(m);
            }
            comboBox16.Items.Add("物理");
            comboBox19.Items.Add("物理");
            comboBox23.Items.Add("物理");
            comboBox27.Items.Add("物理");
            comboBox43.Items.Add("物理");
            comboBox39.Items.Add("物理");
            comboBox35.Items.Add("物理");
            comboBox31.Items.Add("物理");
            comboBox16.Items.Add("特殊");
            comboBox19.Items.Add("特殊");
            comboBox23.Items.Add("特殊");
            comboBox27.Items.Add("特殊");
            comboBox43.Items.Add("特殊");
            comboBox39.Items.Add("特殊");
            comboBox35.Items.Add("特殊");
            comboBox31.Items.Add("特殊");
            textBox49.Text = "100";
            textBox50.Text = "100";
            textBox51.Text = "100";
            textBox52.Text = "100";
            textBox53.Text = "100";
            textBox54.Text = "100";
            textBox55.Text = "100";
            textBox56.Text = "100";
            comboBox17.Items.Add("未会心");
            comboBox18.Items.Add("未会心");
            comboBox22.Items.Add("未会心");
            comboBox26.Items.Add("未会心");
            comboBox42.Items.Add("未会心");
            comboBox38.Items.Add("未会心");
            comboBox34.Items.Add("未会心");
            comboBox30.Items.Add("未会心");
            comboBox17.Items.Add("会心");
            comboBox18.Items.Add("会心");
            comboBox22.Items.Add("会心");
            comboBox26.Items.Add("会心");
            comboBox42.Items.Add("会心");
            comboBox38.Items.Add("会心");
            comboBox34.Items.Add("会心");
            comboBox30.Items.Add("会心");
            comboBox17.Items.Add("期望");
            comboBox18.Items.Add("期望");
            comboBox22.Items.Add("期望");
            comboBox26.Items.Add("期望");
            comboBox42.Items.Add("期望");
            comboBox38.Items.Add("期望");
            comboBox34.Items.Add("期望");
            comboBox30.Items.Add("期望");
            comboBox17.SelectedIndex = 0;
            comboBox18.SelectedIndex = 0;
            comboBox22.SelectedIndex = 0;
            comboBox26.SelectedIndex = 0;
            comboBox42.SelectedIndex = 0;
            comboBox38.SelectedIndex = 0;
            comboBox34.SelectedIndex = 0;
            comboBox30.SelectedIndex = 0;

        }

        private void LoadPokemon1(Pokemon p) {
            comboBox2.SelectedIndex = (int)p.Type1;
            comboBox3.SelectedIndex = (int)p.Type2;
            textBox1.Text = "" + p.level;
            label36.Text = "" + p.HP;
            label37.Text = "" + p.Atk;
            label38.Text = "" + p.Def;
            label39.Text = "" + p.SpAtk;
            label40.Text = "" + p.SpDef;
            label41.Text = "" + p.Spd;
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

        private void LoadPokemon2(Pokemon p)
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

        private void viewDamage() {
            label18.Text = "" + Calculator.calculateDamage(p1, p1.move1, p2);
        }

        //pokemon selection
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
