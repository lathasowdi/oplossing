using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oefening1
{
    public partial class Addperson : Form
    {
        public Addperson()
        {
            InitializeComponent();
        }

        private void Oefening1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OefeningEntities ctx = new OefeningEntities())
            {
                string voornaam = "";
                if (textBox1.Text.Trim() != "")
                {
                    voornaam = textBox1.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Geef een Voornaam a.u.b");
                }
                string achternaam = "";
                if (textBox2.Text.Trim() != "")
                {
                    achternaam = textBox2.Text.Trim();
                }
                else
                {
                    MessageBox.Show("Geef een Achternaam a.u.b");
                }

                int leeftijd;
                leeftijd = (int)numericUpDown1.Value;

                ctx.Persoons.Add(new Persoon() { Voornaam = voornaam, Achternaam = achternaam, Leeftijd = leeftijd });
                ctx.SaveChanges();
                MessageBox.Show("Persoon Toevoegd");
            }
        }
    }
}
