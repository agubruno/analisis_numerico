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

        public ResultadoRegresion CalcularRegresionPolimonial(double[,] coordenadas, int cantidadPuntos, int gradoCurva)
        {
            ResultadoRegresion nuevoResltado = new ResultadoRegresion();
            double elevado = 0;

            double[,] Matriz = new double[gradoCurva + 2, gradoCurva + 2];

            Matriz[0, 0] = cantidadPuntos;

            for (int i = 0; i < gradoCurva + 3; i++)
            {
                elevado = i;
                for (int j = 0; i < gradoCurva + 3; i++)
                {
                    for (int sumatoria = 0; i < cantidadPuntos + 1; i++)
                    {
                        //-----------------------CALCULA COEFICIENTES
                        if (elevado != 0)
                        {
                            Matriz[i, j] = Matriz[i, j] + Math.Pow(coordenadas[1, sumatoria], elevado);
                        }
                        //------------------------CALCULA TERMINO INDEPENDIENTE------------------------------------------                
                        if (j == gradoCurva + 2)
                        {
                            if (i == 0)
                            {
                                Matriz[i, j] = Matriz[i, j] + coordenadas[0, sumatoria];
                            }
                            else
                            {
                                Matriz[i, j] = Matriz[i, j] + (coordenadas[0, sumatoria] * Math.Pow(coordenadas[1, sumatoria], i));
                            }
                        }

                    }
                    elevado = elevado + 1;
                }
            }

            SistemaDeEcuacion nuevoSistema = new SistemaDeEcuacion();
            var nuevoRsultadoSistemas = nuevoSistema.CalcularSistemaGaussJordam(Matriz, gradoCurva + 2);

            nuevoResltado.Resultados=nuevoRsultadoSistemas.resultado;
            CoefienteCorrelacion(coordenadas, cantidadPuntos, nuevoResltado.Resultados);

            return nuevoResltado;

        }
    }
}
