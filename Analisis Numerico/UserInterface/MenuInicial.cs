using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnitTestProject2;
using UserInterface.Iteración_Numérica;
using UserInterface.Regresión;

namespace UserInterface
{
    public partial class MenuInicial : Form
    {
        public MenuInicial()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 nuevaRaiz = new Form1();
            nuevaRaiz.Owner = this;

            nuevaRaiz.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SistemasEcuaciones nuevoSE = new SistemasEcuaciones();
            nuevoSE.Owner = this;

            nuevoSE.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TiposRegresiones nuevoTipo = new TiposRegresiones();
            nuevoTipo.Owner = this;
            nuevoTipo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IteracionNumerica nuevaIteracion = new IteracionNumerica();
            nuevaIteracion.Owner = this;
            nuevaIteracion.Show();
        }
    }
}
