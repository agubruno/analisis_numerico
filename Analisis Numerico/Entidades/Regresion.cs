using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoRegresion
    {
       public double Resultadoa1 { get; set; }
        public double Resultadoa0 { get; set; }
        public List<double> Resultados { get; set;}

        public ResultadoRegresion ()
        {
            Resultados = new List<double>();
        }
    }


    public class Regresion
    {
        public double CoefienteCorrelacion(double[,] coordenadas, int cantidadPuntos, List<double> listaCoeficientes)
        {
            double st = 0;
            double calculoPrevio = 0;
            double sr = 0;
            double promedioY = 0;
            double r;

            for (int filas = 0; filas < cantidadPuntos; filas++)
            {

                promedioY = promedioY + coordenadas[filas, 1];
                for (int indice = 0; indice < listaCoeficientes.Count(); indice++)
                {
                    if (indice != 0 )
                    {
                        calculoPrevio = calculoPrevio + (listaCoeficientes[indice] * (Math.Pow(coordenadas[filas, 0],indice)));
                    }
                }
                calculoPrevio = calculoPrevio + listaCoeficientes[0];
                calculoPrevio = coordenadas[filas, 1] - calculoPrevio;

                sr = sr + Math.Pow(calculoPrevio, 2);

                calculoPrevio = 0;

            }





            //for (int i = 0; i < cantidadPuntos; i++)
            //{
            //    promedioY = promedioY + coordenadas[i, 1];
            //    sr = sr + Math.Pow((coordenadas[i, 1] - a1 * coordenadas[i, 0] - a0 ), 2);
            //}
            promedioY = promedioY / cantidadPuntos;

            for (int i = 0; i < cantidadPuntos; i++)
            {
                st = st + Math.Pow((coordenadas[i, 1] -promedioY), 2);
            }

            r = Math.Sqrt(Math.Abs((st - sr) / st)) * 100;
            

            return r;

        }

        public ResultadoRegresion CalcularRegresionLineal(double[,] coordenadas, int cantidadPuntos)
        {
            ResultadoRegresion nuevoResultado = new ResultadoRegresion();

            double sumatoriaXY = 0;
            double x2 = 0;
            double x = 0;
            double y = 0;

            for (int i = 0; i < cantidadPuntos; i++)
            {
                sumatoriaXY = sumatoriaXY + (coordenadas[i, 0] * coordenadas[i, 1]);
                x2 = x2 + Math.Pow(coordenadas[i, 0], 2);
                x = x + coordenadas[i, 0];
                y = y + coordenadas[i, 1];
            }
            var a1 = ((cantidadPuntos * sumatoriaXY) - (x * y)) / ((cantidadPuntos * x2) - Math.Pow(x, 2));
            var a0 = ((y/cantidadPuntos) - a1 * (x/cantidadPuntos)) ;
            nuevoResultado.Resultadoa0 = a0;
            nuevoResultado.Resultadoa1 = a1;

            nuevoResultado.Resultados.Add(a0);
            nuevoResultado.Resultados.Add(a1);

            return nuevoResultado;
        }

        public ResultadoRegresion CalcularRegresionPolimonialInterno(double[,] coordenadas, int cantidadPuntos, int gradoCurva)
        {
            ResultadoRegresion nuevoResltado = new ResultadoRegresion();
            double elevado = 0;

            double[,] Matriz = new double[gradoCurva + 3, gradoCurva + 3];

            Matriz[0, 0] = cantidadPuntos;

            for (int i = 0; i < gradoCurva + 3; i++)
            {
                elevado = i;
                for (int j = 0; j < gradoCurva + 3; j++)
                {
                    for (int sumatoria = 0; sumatoria < cantidadPuntos ; sumatoria++)
                    {
                        //-----------------------CALCULA COEFICIENTES
                        if (elevado != 0 && j != gradoCurva + 2)
                        {
                            Matriz[i, j] = Matriz[i, j] + Math.Pow(coordenadas[sumatoria, 0], elevado);
                        }
                        //------------------------CALCULA TERMINO INDEPENDIENTE------------------------------------------                
                        if (j == gradoCurva + 2)
                        {
                            if (i == 0)
                            {
                                Matriz[i, j] = Matriz[i, j] + coordenadas[sumatoria, 1];
                            }
                            else
                            {
                                Matriz[i, j] = Matriz[i, j] + (coordenadas[sumatoria, 1] * Math.Pow(coordenadas[sumatoria, 0], i));
                            }
                        }

                    }
                    elevado = elevado + 1;
                }
            }

            SistemaDeEcuacion nuevoSistema = new SistemaDeEcuacion();
            var nuevoRsultadoSistemas = nuevoSistema.CalcularSistemaGaussJordam(Matriz, gradoCurva + 2);

            nuevoResltado.Resultados=nuevoRsultadoSistemas.resultado;

            var coeficiente = CoefienteCorrelacion(coordenadas, cantidadPuntos, nuevoResltado.Resultados);

            return nuevoResltado;

        }

        public ResultadoRegresion CalcularRegrecionPolinomial(double[,] coordenadas, int cantidadPuntos, int gradoCurba)
        {
            var nuevoResultado =CalcularRegresionPolimonialInterno(coordenadas, cantidadPuntos, gradoCurba);

            var coeficiente = CoefienteCorrelacion(coordenadas, cantidadPuntos, nuevoResultado.Resultados);

            while (coeficiente < 85)
            {
                gradoCurba = gradoCurba + 1;
                nuevoResultado = CalcularRegresionPolimonialInterno(coordenadas, cantidadPuntos, gradoCurba);
                coeficiente = CoefienteCorrelacion(coordenadas, cantidadPuntos, nuevoResultado.Resultados);
            }

            return nuevoResultado;
        }

        public double CalcularLagrange(double[,] Coordenas, int CantidadPuntos, double numero)
        {


            double[] Vector = new double[CantidadPuntos];
            double Polinomio = 0;


            for (int i = 0; i < CantidadPuntos + 1; i++)
            {

                for (int j = 0; j < CantidadPuntos; j++)
                {
                    if (i != j)
                    {
                        Polinomio = Polinomio + ((numero - Coordenas[j, 0]) / Coordenas[i, 0] - Coordenas[i, j]);
                    }
                }
                Polinomio = Polinomio + Polinomio * Coordenas[i, 1];
                Vector[i] = Polinomio;

            }

            double sumaTotal = 0;

            for (int i = 0; i < CantidadPuntos; i++)
            {
                sumaTotal = sumaTotal + Vector[i];
            }

            return sumaTotal;
        }

    }
}
