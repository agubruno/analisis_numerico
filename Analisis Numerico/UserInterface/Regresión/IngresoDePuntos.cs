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
    public partial class IngresoDePuntos : Form, IRegresion
    {
        public string Metodo { get; set; }
        public int Cantidad { get; set; }
        public List<double> ResultadosRegresion { get; set; }
        public double CoeficienteCorrelacion { get; set; }

        public IngresoDePuntos()
        {
            InitializeComponent();
            ResultadosRegresion = new List<double>();
        }

        private void IngresoDePuntos_Load(object sender, EventArgs e)
        {
            TransferenciaCantidadDePuntos owner = this.Owner as TransferenciaCantidadDePuntos;
            Cantidad = owner.RetornarCantidad();
            Metodo =  owner.RetornarMetodo();

            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = Cantidad;

            dataGridView1.Columns[0].HeaderText = "X";
            dataGridView1.Columns[1].HeaderText = "Y";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double[,] Matriz = new double[Cantidad, 2];

            for (int i = 0; i < Cantidad; i++)
            {
                for (int j = 0; j < 2 ; j++)
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
                    }
                }
            }
            Regresion nuevaRegresion = new Regresion();

            if (Metodo == "Regresión Lineal por mínimos cuadrados ")
            {
                ResultadoRegresion nuevoResultado = new ResultadoRegresion();
                nuevoResultado = nuevaRegresion.CalcularRegresionLineal(Matriz, Cantidad);

                MessageBox.Show("El termino independiente es: "+nuevoResultado.Resultadoa0 + ", su coeficiente es: "+nuevoResultado.Resultadoa1+", y su coeficiente de correlacion es: " + nuevaRegresion.CoefienteCorrelacion(Matriz, Cantidad, nuevoResultado.Resultados));
            }
            else
            {
                var nuevoResultado = nuevaRegresion.CalcularRegrecionPolinomial(Matriz, Cantidad, 2);
                ResultadosRegresion = nuevoResultado.Resultados;
                CoeficienteCorrelacion = nuevaRegresion.CoefienteCorrelacion(Matriz, Cantidad, nuevoResultado.Resultados);
                ResultadosRegresion nuevoResultadoRegresion = new Regresión.ResultadosRegresion();
                nuevoResultadoRegresion.Owner = this;
                nuevoResultadoRegresion.Show();
            }           
        }

        public List<double> RetornarResultadosRegresion()
        {
            return ResultadosRegresion;
        }

        public double RetorniarCoeficiente()
        {
            return CoeficienteCorrelacion;
        }
    }
}
