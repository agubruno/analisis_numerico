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

        public double TrapecioSimple (double vi, double vd, string funcion)
        {
            double superficie = 0; 
            
            
            

            return superficie
        }
    }
}
