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
            //Si es una matriz 2x2 pasa por aca (necesario tambien cuando redusimos)
            if (CantidadIncongitas == 2)
            {
                determinante = (Matriz[0, 0] * Matriz[1, 1]) - (Matriz[1, 0] * Matriz[0, 1]);
            }
            else
            {
                //Reducimoms
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
                                int indice = 0;
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

                    //Dependiendo si es par o no se resta o se suma.
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

        public double DevuolverDeterminante(double[,] nuevaMatriz, int CantidadIncongitas)
        {
            return determinante(nuevaMatriz, CantidadIncongitas);
        }
    }
}
