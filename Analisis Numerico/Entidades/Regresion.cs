using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ResultadoRegresionLineal
    {
       public double Resultadoa1 { get; set; }
        public double Resultadoa0 { get; set; }
    }


    public class Regresion
    {
        public double CoefienteCorrelacion(double[,] coordenadas, int cantidadPuntos, double a1, double a0)
        {
            double st = 0;
            double sr = 0;
            double promedioY = 0;
            double r;
            for (int i = 0; i < cantidadPuntos; i++)
            {
                promedioY = promedioY + coordenadas[i, 1];
                sr = sr + Math.Pow((coordenadas[i, 1] - a1 * coordenadas[i, 0] - a0 ), 2);
            }
            promedioY = promedioY / cantidadPuntos;

            for (int i = 0; i < cantidadPuntos; i++)
            {
                st = st + Math.Pow((coordenadas[i, 1] -promedioY), 2);
            }

            r = Math.Sqrt(Math.Abs((st - sr) / st)) * 100;
            

            return r;

        }

        public ResultadoRegresionLineal CalcularRegresionLineal(double[,] coordenadas, int cantidadPuntos)
        {
            ResultadoRegresionLineal nuevoResultado = new ResultadoRegresionLineal();

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

            return nuevoResultado;
        }

        public ResultadoRegresionLineal CalcularRegresionPolimonial(double[,] coordenadas, int cantidadPuntos, int gradoCurva)
        {
            ResultadoRegresionLineal nuevoResltado = new ResultadoRegresionLineal();
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

            //Como calculamos coeficiete de grado mayor a 1?
            return nuevoResltado;

        }
    }
}
