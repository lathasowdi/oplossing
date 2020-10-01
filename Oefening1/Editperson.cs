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
    public partial class Editperson : Form
    {
        public Editperson()
        {
            InitializeComponent();
        }
        public Persoon mijnpersoon;
        private void Editperson_Load(object sender, EventArgs e)
        {
            using (OefeningEntities ctx = new OefeningEntities())
            {
                var Query = ctx.Persoons.Select(a => a).ToList();
                comboBox1.DisplayMember = "Voornaam";
                comboBox1.ValueMember = "Id";
                comboBox1.DataSource = Query;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedperson = (Persoon)comboBox1.SelectedItem;
            textBox1.Text = selectedperson.Voornaam;
            textBox2.Text = selectedperson.Achternaam;
            numericUpDown1.Value = (int)selectedperson.Leeftijd;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //   var selectedperson = (Persoon)comboBox1.SelectedItem;
            //   textBox1.Text = selectedperson.Voornaam;
            //   textBox2.Text = selectedperson.Achternaam;
            //numericUpDown1.Value = (int)selectedperson.Leeftijd;
        }

        private void button3_Click(object sender, EventArgs e)
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
                int value = Convert.ToInt32(comboBox1.SelectedValue);
                ctx.Persoons.Where(p => p.Id == value).FirstOrDefault().Voornaam = voornaam;
                ctx.Persoons.Where(p => p.Id == value).FirstOrDefault().Achternaam = achternaam;
                ctx.Persoons.Where(p => p.Id == value).FirstOrDefault().Leeftijd = leeftijd;
                ctx.SaveChanges();
                MessageBox.Show("Persoon Bewerk is gedaan");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OefeningEntities ctx = new OefeningEntities())
            {
                int value = Convert.ToInt32(comboBox1.SelectedValue);
                ctx.Persoons.RemoveRange(ctx.Persoons.Where(p => p.Id == value));
                ctx.SaveChanges();
                MessageBox.Show("Persoon  is verwijderen");

            }
        }
    }
}
