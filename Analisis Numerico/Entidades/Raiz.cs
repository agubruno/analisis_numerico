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

            string argumento = "x = "+Convert.ToString(x).Replace(',','.');

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
                resultado.PosibleCalcularRaiz = true;

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
                er = Math.Abs((xr - xant) / xr);
                double calculoaux = Math.Abs(Funcion(funcion, xr));
                while ((c+1 <= iteracciones) && (calculoaux > tole) && (er > tole))
                {
                    calculoaux = Math.Abs(Funcion(funcion, xr));
                    xr = (xi + xd) / 2;
                    er = Math.Abs((xr - xant) / xr);

                    multiplicacion = Funcion(funcion,xi) * Funcion(funcion, xr);
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
                resultado.PosibleCalcularRaiz = true;

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
                xr = (Funcion(funcion, xd) *xi - Funcion(funcion, xi)*xd) / (Funcion (funcion, xd) - Funcion (funcion, xi));
                er = Math.Abs((xr - xant) / xr);
                while ((c + 1 <= iteracciones) && (Math.Abs(Funcion(funcion,xr)) > tole) && (er > tole))
                {
                    xr = (Funcion(funcion, xd) * xi - Funcion(funcion, xi) * xd) / (Funcion(funcion, xd) - Funcion(funcion, xi));

                    er = Math.Abs((xr - xant) / xr);

                    multiplicacion = Funcion(funcion,xi) * Funcion(funcion,xr);
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

        public ResultadoRaiz CalcularRaizTangente(double xi,  int iteracciones, double tole, string funcion)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;
            
            double xr = 0;
            double xant = 0;
                
            if (Funcion(funcion,xi) == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;
                resultado.ValorRaiz = xi;
                resultado.PosibleCalcularRaiz = true;
               
                return resultado;
            }

            else 
            {
                double casiderivada = (Funcion(funcion, xi + tole) - Funcion(funcion, xi)) / tole; 
                if (casiderivada == 0)
                {
                    resultado.PosibleCalcularRaiz = false;
                }
                else
                {
                    resultado.PosibleCalcularRaiz = true;
                    xr = xi - (Funcion(funcion, xi) / casiderivada);
                    er = Math.Abs((xr - xant) / xr );
                    double calculoaux = Math.Abs(Funcion(funcion, xr));
                    while ((c + 1 <= iteracciones) && (calculoaux > tole) && (er > tole))
                    {
                        xr = xi - (Funcion(funcion, xi) / casiderivada);
                        er = Math.Abs((xr - xant) / xr );
                        
                        xant = xr;
                        c = c + 1;
                        xi = xr;

                    }

                    resultado.ValorRaiz = xr;
                    resultado.Iteraciones = c;
                    resultado.Error = er;
                }
                
            }
            
            return resultado;
        }

        public ResultadoRaiz CalcularRaizSecante(double xi, double xd, int iteracciones, double tole, string funcion)
        {
            double er = 0;
            ResultadoRaiz resultado = new ResultadoRaiz();
            int c = 0;

            double xr = 0;
            double xant = 0;

            if (Funcion(funcion, xi) == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;
                resultado.ValorRaiz = xi;
                resultado.PosibleCalcularRaiz = true;

                return resultado;
            }

            if (Funcion(funcion, xd) == 0)
            {
                resultado.Iteraciones = c;
                resultado.Error = 0;
                resultado.ValorRaiz = xd;
                resultado.PosibleCalcularRaiz = true;

                return resultado;
            }

            if (resultado.PosibleCalcularRaiz == false)
            {
                double divisor = Funcion(funcion, xi) - Funcion(funcion, xd);
                if (divisor == 0)
                {
                    resultado.PosibleCalcularRaiz = false;
                }
                else
                {
                    resultado.PosibleCalcularRaiz = true;
                    xr = ((Funcion (funcion, xi) * xd) - (Funcion(funcion, xd) * xi) )/ divisor;
                    er = Math.Abs((xr - xant) / xr);
                    c = c + 1;
        
                    double calculoaux = Math.Abs(Funcion(funcion, xr));
                    while ((c+1 <= iteracciones) && (calculoaux > tole) && (er > tole))
                    {
                        xr = ((Funcion(funcion, xi) * xd) - (Funcion(funcion, xd) * xi)) / divisor;
                        er = Math.Abs((xr - xant) / xr);
                        
                        xant = xr;
                        c = c + 1;
                        xd = xi;
                        xi = xr;

                        divisor = Funcion(funcion, xi) - Funcion(funcion, xd);
                        if (divisor == 0 )
                        {
                            resultado.PosibleCalcularRaiz = false;
                            break;
                        }
                    }

                    resultado.ValorRaiz = xr;
                    resultado.Iteraciones = c;
                    resultado.Error = er;
                }

            }

            return resultado;
        }

    }
}



