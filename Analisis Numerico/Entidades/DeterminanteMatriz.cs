using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DeterminanteMatriz
    {
        public double determinante(double[,] Matriz, int CantidadIncongitas)
        {
            double determinante = 0;
            if (CantidadIncongitas == 2)
            {
                determinante = (Matriz[0, 0] * Matriz[1, 1]) - (Matriz[1, 0] * Matriz[0, 1]);
            }
            else
            {
                determinante = 0;

                for (int i = 0; i < CantidadIncongitas; i++)
                {
                    double[,] nuevaMatriz = new double[CantidadIncongitas - 1, CantidadIncongitas - 1];
                    for (int j = 0; j < CantidadIncongitas; j++)
                    {
                        if (j != i)
                        {
                            for (int k = 1; k < CantidadIncongitas; k++)
                            {
                                int indice = -1;
                                if (j < i)
                                {
                                    indice = j;
                                }
                                else
                                {
                                    indice = j - 1;
                                }
                                nuevaMatriz[indice, k - 1] = Matriz[j, k];
                            }
                        }
                    }
                    if (i%2==0)
                    {
                        determinante = determinante + Matriz[i, 0] * DevuolverDeterminante(nuevaMatriz, CantidadIncongitas - 1);
                    }
                    else
                    {
                        determinante = determinante - Matriz[i, 0] * DevuolverDeterminante(nuevaMatriz, CantidadIncongitas - 1);
                    }
                }
            }
            return determinante;
        }

        public bool DeterminarParidad(int fila)
        {
            double resultado = fila / 2;
            string resultado2 = resultado.ToString();
            for (int i = 0; i < resultado2.Length; i++)
            {
                if (resultado2.Contains(",") || resultado2.Contains("."))
                {
                    return false;
                }
            }
            return true;
        }

        public double DevuolverDeterminante(double[,] nuevaMatriz, int CantidadIncongitas)
        {
            return determinante(nuevaMatriz, CantidadIncongitas);
        }
    }
}
