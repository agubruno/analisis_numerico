using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserInterface.Sistemas_de_ecuaciones;

namespace UnitTestProject2
{
    public partial class SistemasEcuaciones : Form, InterfaceIncognitas
    {
        public int CantidadIncognitas { get; set; }

        public SistemasEcuaciones()
        {
            InitializeComponent();
        }

        public int RetornarIncogita()
        {
            return CantidadIncognitas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string texto = textBox1.Text;
            
            if (texto == "")
            {
                texto = "Invalido";
            }
            int textoAInt;
            bool result = int.TryParse(texto, out textoAInt);

            if (result)
            {
                CantidadIncognitas = textoAInt;

                Seleccion_del_metodo nuevaSeleccion = new Seleccion_del_metodo();
                nuevaSeleccion.Owner = this;
                nuevaSeleccion.Show();

            }

        }
    }
}
