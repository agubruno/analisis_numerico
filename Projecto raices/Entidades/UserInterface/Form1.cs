using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBoxITER.Text;
            string texto2 = textBoxTOLE.Text;
            Form2 newForm2 = new Form2();
            newForm2.Owner = this.Owner;
            newForm2.Show();
        }
    }
}
