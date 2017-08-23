using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Logica
{
    public class ResultadoRaiz
    {
        public double ValorRaiz { get; set; }
        public int Iteraciones { get; set; }
        public double Error { get; set; }
    }

    public class Raiz
    {
        public double Funcion(double x)
        {
            // POENELE QUE ES UNA PARABOLA CUYO MIN ES -2;

            double doble = 0;

            doble = (x * x) - 4;

            return doble;
        }

        public ResultadoRaiz CalcularRaizBiseccion(double xi, double xd, int iteracciones, double tole)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;
            double multiplicacion = Funcion(xi) * Funcion(xd);
            double xr = 0;
            double xant = 0;

            if (multiplicacion == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;

                if (Funcion(xi) == 0)
                {
                    resultado.ValorRaiz = xi;
                }
                else
                {
                    resultado.ValorRaiz = xd;
                }
                return resultado;
            }

            if (multiplicacion > 0)
            {
                throw new Exception("No hay raiz entre estas dos variables");
            }

            if (multiplicacion < 0)
            {
                xr = (xi + xd) / 2;
                er = Math.Abs((xi - xant)) / xr;
                c = c + 1;
                while ((c <= iteracciones) && (Math.Abs(Funcion(xr)) > tole) && (xr > er))
                {
                    xr = (xi + xd) / 2;
                    er = Math.Abs((xi - xant)) / xr;

                    multiplicacion = Funcion(xi) * Funcion(xd);
                    if (multiplicacion > 0)
                    {
                        xi = xr;
                    }
                    else
                    {
                        xd = xr;
                    }

                    xant = xr;
                    c = c + 1;
                }

                resultado.ValorRaiz = xr;
                resultado.Iteraciones = c;
                resultado.Error = er;
            }

            return resultado;
        }


        public ResultadoRaiz CalcularRaizReglaFalsa(double xi, double xd, int iteracciones, double tole)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;
            double multiplicacion = Funcion(xi) * Funcion(xd);
            double xr = 0;
            double xant = 0;

            if (multiplicacion == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;

                if (Funcion(xi) == 0)
                {
                    resultado.ValorRaiz = xi;
                }
                else
                {
                    resultado.ValorRaiz = xd;
                }
                return resultado;
            }

            if (multiplicacion > 0)
            {
                throw new Exception("No hay raiz entre estas dos variables");
            }

            if (multiplicacion < 0)
            {
                xr = (Funcion(xi) *xd - Funcion(xd)*xi) / (Funcion (xi) - Funcion (xd));
                er = Math.Abs((xi - xant)) / xr;
                c = c + 1;
                while ((c <= iteracciones) && (Math.Abs(Funcion(xr)) > tole) && (xr > er))
                {
                    xr = (xi + xd) / 2;
                    er = Math.Abs((xi - xant)) / xr;

                    multiplicacion = Funcion(xi) * Funcion(xd);
                    if (multiplicacion > 0)
                    {
                        xi = xr;
                    }
                    else
                    {
                        xd = xr;
                    }

                    xant = xr;
                    c = c + 1;
                }

                resultado.ValorRaiz = xr;
                resultado.Iteraciones = c;
                resultado.Error = er;
            }

            return resultado;
        }
    }
}
