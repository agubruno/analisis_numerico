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
    public partial class ResultadosRegresion : Form
    {
        public ResultadosRegresion()
        {
            InitializeComponent();
        }

        private void ResultadosRegresion_Load(object sender, EventArgs e)
        {
            IRegresion Owner = this.Owner as IRegresion;
            var Coeficiente = Owner.RetorniarCoeficiente();
            var ListaResultados = Owner.RetornarResultadosRegresion();

            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = ListaResultados.Count + 1;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaResultados;

            for (int i = 0; i < ListaResultados.Count -1; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "a" + i.ToString();
            }

            for (int i = 0; i < ListaResultados.Count -1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = ListaResultados[i].ToString();
            }

            textBox1.Text = Coeficiente.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
