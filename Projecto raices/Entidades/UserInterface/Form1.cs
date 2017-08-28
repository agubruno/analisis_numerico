using Entidades.Logica;
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
    public partial class Form1 : Form, Interface1
    {
        public int Iteraciones { get; set; }
        public double Tolerancia { get; set; }
        public string Metodo { get; set; }
        public Raiz NuevaRaiz { get; set; }
        public string FuncionElegida { get; set; }

        public Form1()
        {
            NuevaRaiz = new Raiz();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string texto = textBoxITER.Text;
            string texto2 = textBoxTOLE.Text;

            if (texto == "" || texto2 == "" || textBoxFUNCION.Text == "") 
            {
                texto = "invalido";
                texto2 = "invalido";
            }

            FuncionElegida = "f(x) = " + textBoxFUNCION.Text;
            int textoAInt = 0;
            double texto2ADouble = 0;

            bool result = int.TryParse(texto, out textoAInt);       
            bool result2 = double.TryParse(texto2, out texto2ADouble);  

            if (result && result2)
            {
               Iteraciones = textoAInt;
               Tolerancia = texto2ADouble;
               Metodo = MetodoSeleccionado.Text;
               if (MetodoSeleccionado.Text == "Biseccion" || MetodoSeleccionado.Text == "Regla falsa")
               {
                    Form2 newForm2 = new Form2();
                    newForm2.Owner = this;
                    newForm2.Show();
               }

               if (MetodoSeleccionado.Text == "Newton (tangente)" || MetodoSeleccionado.Text == "Secante")
               {
                    Form3 newForm3 = new Form3();
                    newForm3.Owner = this;
                    newForm3.Show();
               }

               if (MetodoSeleccionado.Text == "") // como hago para que no puedan escribir en el metodoseleccionado
                {
                    MessageBox.Show("No se ingreso metodo válido, por favor corregir para continuar");
                }
            }
            else
            {
                MessageBox.Show("No se ingresaron datos correctos, por favor corroborar");
            }
            
        }

        void Interface1.CalcularRaiz(double vi, double vd)
        {
            ResultadoRaiz nuevoResultado = new ResultadoRaiz();
            if (Metodo == "Biseccion")
            {
                nuevoResultado = NuevaRaiz.CalcularRaizBiseccion(vi, vd, Iteraciones, Tolerancia, FuncionElegida);
                if (nuevoResultado.PosibleCalcularRaiz)
                {
                    MessageBox.Show("El resultado de la raiz es: " + nuevoResultado.ValorRaiz + ", cuya cantidad de iteracones fueron: " + nuevoResultado.Iteraciones + ", con un error de: " + nuevoResultado.Error);
                }
                else
                {
                    MessageBox.Show("No es posible calcular la raiz, el intervalo seleccionado no tiene raiz");
                }
            }
            else
            {
                nuevoResultado = NuevaRaiz.CalcularRaizReglaFalsa(vi, vd, Iteraciones, Tolerancia, FuncionElegida);
                if (nuevoResultado.PosibleCalcularRaiz)
                {
                    MessageBox.Show("El resultado de la raiz es: " + nuevoResultado.ValorRaiz + ", cuya cantidad de iteracones fueron: " + nuevoResultado.Iteraciones + ", con un error de: " + nuevoResultado.Error);
                }
                else
                {
                    MessageBox.Show("No es posible calcular la raiz, el intervalo seleccionado no tiene raiz");
                }
            }
        }
        
        void Interface1.CalcularRaiz(double vini)
        {
            throw new NotImplementedException();
        }
    }
}
