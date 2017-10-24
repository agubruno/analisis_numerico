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

namespace UserInterface.Sistemas_de_ecuaciones
{
    public partial class GrillaMatriz : Form
    {
        public int CantidadIncognitas { get; set; }
        public SistemaDeEcuacion nuevaEcuacion { get; set; }

        public DeterminanteMatriz nuevoDeterminante { get; set; }

        public GrillaMatriz()
        {
            CantidadIncognitas = new int();
            InitializeComponent();
            nuevaEcuacion = new SistemaDeEcuacion();
            nuevoDeterminante = new DeterminanteMatriz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double [,]  Matriz = new double [CantidadIncognitas, (CantidadIncognitas + 1)];
            double[,] MatrizParaDEterminante = new double[CantidadIncognitas, (CantidadIncognitas + 1)];

            for (int i = 0; i < CantidadIncognitas; i++)
            {
                for (int j = 0; j < CantidadIncognitas + 1; j++)
                {
                    string texto = dataGridView1.Rows[i].Cells[j].Value.ToString();

                    if (texto == "")
                    {
                        texto = "Invalido";
                    }
                    double textoADouble;

                    bool result = double.TryParse(texto, out textoADouble);
                    
                    if (result)
                    {
                        Matriz[i, j] = textoADouble; 
                        if (j != CantidadIncognitas)
                        {
                            MatrizParaDEterminante[i, j] = textoADouble;
                        }
                    }
                }
            }

            MetodoSeleccionado Owner = this.Owner as MetodoSeleccionado;
            string metodo = Owner.retornarmetodo();

            resultadoSistemas nuevoResultado = new resultadoSistemas();
           


            if (metodo == "Método Gauss Jordan")
            {
                nuevoResultado = nuevaEcuacion.CalcularSistemaGaussJordam(Matriz, CantidadIncognitas);
                if (Math.Abs(nuevoDeterminante.determinante(MatrizParaDEterminante, CantidadIncognitas)) < 1)
                {
                    MessageBox.Show("Teniendo en cuenta el valor de la determinante: "+ nuevoDeterminante.determinante(MatrizParaDEterminante, CantidadIncognitas) + ", podemos concluir que hay una probabilidad que el sistema esté mal condicionado");
                }
                else
                {
                    MessageBox.Show("Teniendo en cuenta el valor de la determinante: " + nuevoDeterminante.determinante(MatrizParaDEterminante, CantidadIncognitas) + ", podemos concluir que hay una probabilidad que el sistema esté bien condicionado");

                }
            }
            else
            {
                 
                nuevoResultado = nuevaEcuacion.CalcularSistemaGaussSeidel(Matriz, CantidadIncognitas);
                if (nuevoResultado.BienCondicionado)
                {
                    MessageBox.Show("El metodo es diagonalmente dominante. Y su determinate es: " + nuevoDeterminante.determinante(MatrizParaDEterminante, CantidadIncognitas));
                }
            }

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = null;
            dataGridView2.ColumnCount = CantidadIncognitas;
            dataGridView2.RowCount = 1;
            dataGridView2.DataSource = nuevoResultado.resultado;

            for (int i = 0; i < CantidadIncognitas; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = nuevoResultado.resultado[i].ToString();
            }
        }

        private void GrillaMatriz_Load(object sender, EventArgs e)
        {
            string a;
            InterfaceIncognitas Owner = this.Owner.Owner as InterfaceIncognitas;
            CantidadIncognitas = Owner.RetornarIncogita();
            dataGridView1.ColumnCount = CantidadIncognitas + 1;
            dataGridView1.RowCount = CantidadIncognitas;
            for (int i = 0; i < CantidadIncognitas; i++)
            {
                dataGridView1.Columns[i].HeaderText = "x"+i.ToString();
            }
            dataGridView1.Columns[CantidadIncognitas].HeaderText = "termino independiente";
            for (int i = 0; i < CantidadIncognitas; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "Ecuacion numero " + i.ToString();
            }
            
        }
    }
}
