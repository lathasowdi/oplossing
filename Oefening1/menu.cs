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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addperson oef = new Addperson();
            oef.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Editperson oef = new Editperson();
            oef.Show();
        }
    }
}
