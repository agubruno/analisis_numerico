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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBoxVi.Text;
            string texto2 = textBoxVd.Text;

            if (texto == "" || texto2 == "")
            {
                texto = "invalido";
                texto2 = "invalido";
            }

            double textoAInt = 0;
            double texto2AInt = 0;

            bool result = double.TryParse(texto, out textoAInt);
            bool result2 = double.TryParse(texto2, out texto2AInt); 

            if (result && result2)
            {
                Interface1 owner = this.Owner as Interface1;
                owner.CalcularRaiz(textoAInt, texto2AInt);
            }
            else
            {
                MessageBox.Show("No se ingresaron datos correctos, por favor corroborar el intervalo");
            }
        }
    }
}
