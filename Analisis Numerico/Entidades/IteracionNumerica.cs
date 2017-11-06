using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class IteracionNumerica
    {
        public double Funcion(string f, double x)
        {
            Function funcion = new Function(f);

            string argumento = "x = " + Convert.ToString(x).Replace(',', '.');

            Argument argument = new Argument(argumento);

            Expression r = new Expression("f(x)", funcion, argument);

            
            var a = r.calculate();

            return a;
        }

        public double CalcularTrapecioSimple(double vi, double vd, string funcion)
        {
            double superficie = ((Funcion(funcion, vi) + Funcion(funcion, vd)) * (vd - vi)) / 2;

            return superficie;
        }

        public double CalcularTrapecioMultiple(double vi, double vd, string funcion, int CantidadIntervalos)
        {
            double h = (vd - vi) / CantidadIntervalos;
            double superficie = Funcion(funcion, vi) + Funcion(funcion, vd);
            double calculoIntermedio = 0;
            double xi = vi;
            for (int i = 1; i < CantidadIntervalos; i++)
            {
                xi = xi + h;
                calculoIntermedio = calculoIntermedio + Funcion(funcion, xi);
            }
            superficie = superficie + (2 * calculoIntermedio);
            superficie = (h / 2) * superficie;

            return superficie;
        }


        //-------------------SIMPSON 1/3
        public double CalcularSimpson1_3Simple(double vi, double vd, string funcion)
        {
            double h = (vd - vi) / 2;
            double xi = vi + h;

            double superficie = Funcion(funcion, vi) + Funcion(funcion, vd) + (4 * Funcion(funcion, xi));
            
            superficie = (h / 3) * superficie;

            return superficie;
        }

        //-------------------CALCULAR SIMPSON EN BASE AL VALOR DE LA CANT DE INTERVALOS.
        public double CalcularSimpson1_3(double vi, double vd, string funcion, int CantidadIntervalos)
        {
            double resultado = 0;

            if (CantidadIntervalos%2 == 0)
            {
                resultado = CalcularSimpson1_3Multiple(vi, vd, funcion, CantidadIntervalos);
            }
            else
            {
                resultado = CalcularSimpson1_3Multiple(vi, vd, funcion, CantidadIntervalos-3);
                resultado = resultado + CalcularSimpson3_8Simple(vi, vd, funcion, CantidadIntervalos);
            }

            return resultado;
        }
        


        public double CalcularSimpson1_3Multiple (double vi, double vd, string funcion, int CantidadIntervalos)
        {
            double superficie = Funcion(funcion, vi) + Funcion(funcion, vd);
            double h = (vd - vi) / CantidadIntervalos;
            double calculoIntermedio = 0;
            double xi = vi;
            for (int i = 1; i <(CantidadIntervalos/2); i = i + 2)
            {
                xi = vi + 2 * h;
                calculoIntermedio = calculoIntermedio + Funcion(funcion, xi);
            }
            superficie = superficie + (4 * calculoIntermedio);
            calculoIntermedio = 0;
            xi = vi + 2 * h;
            for (int i = 2; i < (CantidadIntervalos/2) -1; i = i +2)
            {
                xi = vi + 2 * h;
                calculoIntermedio = calculoIntermedio + Funcion(funcion, xi);
            }
            superficie = superficie + (4 * calculoIntermedio);

            superficie = (h / 3) * superficie;

            return superficie;
        }

        //------------------------SIMPSON 3/8
        public double CalcularSimpson3_8Simple(double vi, double vd, string funcion, int CantidadIntervalos)
        {
            double h = (vd - vi) / CantidadIntervalos;
            double superficie = Funcion(funcion, vd - 3 * h) + (3*Funcion(funcion, vd - 2 * h)) + (3*Funcion(funcion, vd - h)) + Funcion(funcion, vd);



            superficie = (3 * h / 8) * superficie;

            return superficie;
        }
    }
}
