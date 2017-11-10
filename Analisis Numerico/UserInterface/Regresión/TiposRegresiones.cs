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
    public partial class TiposRegresiones : Form, TransferenciaCantidadDePuntos
    {
        public int CantidadPuntos { get; set; }
        public string MetodoSeleccionado { get; set; }
        public double numeroLagrange { get; set; }

        public TiposRegresiones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text;

            if (texto == "" ||  textBox1.Text == "")
            {
                texto = "invalido";
            }

           
            int textoAInt = 0;
            double textoDouble = 0;

            bool result = int.TryParse(texto, out textoAInt);
            bool result2 = double.TryParse(textBox2.Text, out textoDouble);

            if (result && result2)
            {
                CantidadPuntos = textoAInt;
                MetodoSeleccionado = comboBox1.Text;
                numeroLagrange = textoDouble;

                    IngresoDePuntos IngresoDePuntos = new IngresoDePuntos();
                    IngresoDePuntos.Owner = this;
                    IngresoDePuntos.Show();
            }
        }

        public int RetornarCantidad()
        {
            return CantidadPuntos;
        }

        public string RetornarMetodo()
        {
            return MetodoSeleccionado;
        }

        public double RetornarNumero()
        {
            return numeroLagrange;
        }
    }
}
