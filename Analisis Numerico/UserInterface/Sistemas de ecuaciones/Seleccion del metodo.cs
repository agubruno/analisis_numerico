using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface.Sistemas_de_ecuaciones
{
    public partial class Seleccion_del_metodo : Form, MetodoSeleccionado
    {
        public string Metodo_Seleccionado { get; set; }
        public Seleccion_del_metodo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Metodo_Seleccionado = comboBox1.Text;
            if (Metodo_Seleccionado != "Método Gauss Jordan" || Metodo_Seleccionado != "Método Gauss Seidel")
            {

                GrillaMatriz nuevaGrilla = new GrillaMatriz();
                nuevaGrilla.Owner = this;
                nuevaGrilla.Show();
            }
            else
            {
                MessageBox.Show("No se ingreso un metodo correcto, por favor corroborar");
            }
        }

        public string retornarmetodo()
        {
            return Metodo_Seleccionado;
        }
    }
}
