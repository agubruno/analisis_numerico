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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBoxXINI.Text;

            if (texto == "")
            {
                texto = "invalido";
            }

            double textoAInt = 0;
            double texto2AInt = 0;

            bool result = double.TryParse(texto, out textoAInt);

            if (result)
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
