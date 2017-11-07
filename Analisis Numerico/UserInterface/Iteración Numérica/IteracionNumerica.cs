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

namespace UserInterface.Iteración_Numérica
{
    public partial class IteracionNumerica : Form
    {
        public IteracionNumerica()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox2.Text != "")
            {
                Iteracion_numerica_logica nuevaIteracion = new Iteracion_numerica_logica();
                double resultado;
                switch (comboBox1.Text)
                {
                    case "Trapecio Simple":
                        {
                            resultado = nuevaIteracion.CalcularTrapecioSimple(Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), textBox1.Text);
                        }
                        break;
                    case "Trapecio Múltiples":
                        {
                            resultado = nuevaIteracion.CalcularTrapecioMultiple(Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), textBox1.Text, Convert.ToInt32(textBox2.Text));
                        }
                        break;
                    case "Simpson 1 / 3 Simple":
                        {
                            resultado = nuevaIteracion.CalcularSimpson1_3Simple(Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), textBox1.Text);
                        }
                        break;
                    default:
                        resultado = nuevaIteracion.CalcularSimpson1_3(Convert.ToInt32(maskedTextBox1.Text), Convert.ToInt32(maskedTextBox2.Text), textBox1.Text, Convert.ToInt32(textBox2.Text));
                        break;
                }
                MessageBox.Show("El area debajo de la curva es: " + resultado);
            }
            else
            {
                MessageBox.Show("Ingresar correctamente los datos");
            }
        }
        
    }
}
