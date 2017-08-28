using org.mariuszgromada.math.mxparser;
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
        public bool PosibleCalcularRaiz { get; set; }
    }

    public class Raiz
    {
        public double Funcion(string f, double x)
        {
            Function funcion = new Function(f);

            string argumento = "x = "+Convert.ToString(x);

            Argument argument = new Argument(argumento);

            Expression r = new Expression("f(x)", funcion, argument);

            var a = r.calculate();

            return a;
        }

        public ResultadoRaiz CalcularRaizBiseccion(double xi, double xd, int iteracciones, double tole, string funcion)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;
            double multiplicacion = Funcion(funcion,xi) * Funcion(funcion,xd);
            double xr = 0;
            double xant = 0;

            if (multiplicacion == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;

                if (Funcion(funcion,xi) == 0)
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
                resultado.PosibleCalcularRaiz = false;
            }

            if (multiplicacion < 0)
            {
                resultado.PosibleCalcularRaiz = true;
                xr = (xi + xd) / 2;
                er = Math.Abs((xi - xant)) / xi;
                c = c + 1;
                while ((c <= iteracciones) && (Math.Abs(Funcion(funcion, xr)) > tole) && (xr > er))
                {
                    xr = (xi + xd) / 2;
                    er = Math.Abs((xi - xant)) / xr;

                    multiplicacion = Funcion(funcion,xi) * Funcion(funcion, xd);
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


        public ResultadoRaiz CalcularRaizReglaFalsa(double xi, double xd, int iteracciones, double tole, string funcion)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;
            double multiplicacion = Funcion(funcion, xi) * Funcion(funcion, xd);
            double xr = 0;
            double xant = 0;

            if (multiplicacion == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;

                if (Funcion(funcion, xi) == 0)
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
                resultado.PosibleCalcularRaiz = false;
            }

            if (multiplicacion < 0)
            {

                resultado.PosibleCalcularRaiz = true;
                xr = (Funcion(funcion, xi) *xd - Funcion(funcion, xd)*xi) / (Funcion (funcion, xi) - Funcion (funcion, xd));
                er = Math.Abs((xi - xant)) / xi;
                c = c + 1;
                while ((c <= iteracciones) && (Math.Abs(Funcion(funcion,xr)) > tole) && (xr > er))
                {
                    xr = (xi + xd) / 2;
                    er = Math.Abs((xi - xant)) / xr;

                    multiplicacion = Funcion(funcion,xi) * Funcion(funcion,xd);
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
