using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Regresión
{
    public partial class NumeroAInterpolar : Form
    {
        public double  numerointerpolar {get ; set;}
        public NumeroAInterpolar()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text;

            if (texto == "" || textBox1.Text == "")
            {
                texto = "invalido";
            }


            double textoAInt = 0;

            bool result = double.TryParse(texto, out textoAInt);

            if (result)
            {
                Regresion nuevaRegresion = new Regresion();
                PasarNumero owner = this.Owner as PasarNumero;

                nuevaRegresion.CalcularLagrange(owner.PasarDatos(), owner.PasarPuntos(),textoAInt);
                
            }
            else
            {
                MessageBox.Show("Ingrese los datos correctamente");
            }
        }

     // (F(a) + F(b)* (b-a) /2 )
    }
}
