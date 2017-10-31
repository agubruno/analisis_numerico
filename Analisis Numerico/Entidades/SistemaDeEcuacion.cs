using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class resultadoSistemas
    {
        public bool BienCondicionado { get; set; }
        public List<double> resultado { get; set; }

        public resultadoSistemas()
        {
            resultado = new List<double>();
        }
    }
    

    public class SistemaDeEcuacion
    {
        public resultadoSistemas CalcularSistemaGaussJordam(double[,] Sistemas, int CantidadIncognitas)
        {
            //------------ HACEMOS CEROS LOS COEFICIENTES POR DEBAJO DE LA DIAGONAL PRINCIPAL---------------
            resultadoSistemas nuevoResultado = new resultadoSistemas();
            double aux = 0;
            double aux2 = 0;
            int fila = 0;
            bool bandera = false;
            nuevoResultado.BienCondicionado = true;

            for (int i = 0; i < CantidadIncognitas; i++)
            {
                for (int j = 0; j < CantidadIncognitas + 1; j++)
                {
                    if (j == 0 && bandera == false)
                    {
                        aux = Sistemas[i, j];
                    }
                    if (j == 0 && bandera == true)
                    {
                        aux = Sistemas[i, fila];
                    }
                    if (i == j)
                    {
                        aux2 = Sistemas[i, j];

                        if (Sistemas[i, j] == 0)
                        {
                            int mayorCoeficiente = MayorCoeficiente(Sistemas, i, CantidadIncognitas, i);
                            if (mayorCoeficiente == 0)
                            {
                                nuevoResultado.BienCondicionado = false;
                            }
                            else
                            {
                                Sistemas = Pivoteo(Sistemas, i, mayorCoeficiente, CantidadIncognitas);
                                aux = Sistemas[i, j];
                            }
                        }
                    }
                    if (i != 0)
                    {
                        Sistemas[i, j] = Sistemas[i, j] - (Sistemas[fila, j] * aux);
                    }
                    if (j == CantidadIncognitas)
                    {
                        fila = fila + 1;
                        if (fila < i)
                        {
                            j = -1;
                            bandera = true;
                        }
                        else
                        {
                            fila = 0;
                            bandera = false;
                        }
                    }
                }

                for (int j = 0; j < CantidadIncognitas + 1; j++)
                {
                    if (i == j)
                    {
                        aux2 = Sistemas[i, j];
                    }
                    Sistemas[i, j] = (Sistemas[i, j]) / aux2;

                }

            }

            //------------ HACEMOS CEROS LOS COEFICIENTES POR ENCIMA DE LA DIAGONAL PRINCIPAL---------------
            double resultado = 0;
            aux = 0;
            int indice = CantidadIncognitas;
            for (int i = CantidadIncognitas - 2; i > -1; i--)
            {
                bandera = true;
                aux = 0;
                for (int j = 0; j < CantidadIncognitas + 1; j++)
                {
                    if (j > i)
                    {
                        if (Sistemas[i, j] != 0 && bandera == true && j != CantidadIncognitas)
                        {
                            aux = Sistemas[i, j];
                            bandera = false;
                            aux2 = Sistemas[i, i];
                            resultado = Sistemas[j, CantidadIncognitas];
                            indice = j;
                            Sistemas[i, j] = Sistemas[i, j] - (aux2 * aux);

                        }
                        if (j == CantidadIncognitas)
                        {
                            aux2 = resultado;
                            Sistemas[i, j] = Sistemas[i, j] - (aux2 * aux);
                        }
                    }


                    bool coninuar = false;
                    for (int k = 0; k < CantidadIncognitas; k++)
                    {
                        if (i != j)
                        {
                            if (Sistemas[i, k] != 0)
                            {
                                coninuar = true;
                            }
                        }

                    }
                    if ((indice != CantidadIncognitas - 1 && j == CantidadIncognitas) && coninuar == true)
                    {
                        j = 0;
                        bandera = true;
                        aux = 0;
                        aux2 = 0;
                    }

                    
                }

            }
            //----------------------RETORNA TERMINO INDEPENDIENTE-----------------
            for (int i = 0; i < CantidadIncognitas; i++)
            {
                nuevoResultado.resultado.Add(Sistemas[i, CantidadIncognitas]);
            }


            return nuevoResultado;

        }
        

        public resultadoSistemas CalcularSistemaGaussSeidel(double[,] Sistema, int CantidadIncognitas)
        {
            resultadoSistemas nuevoResultado = new resultadoSistemas();
            double Tole = 0.0001;
            double Er;

            List<double> listaResultado = new List<double>();
            bool DD = false;
            double suma = 0;
            double[] Solucion = new double[CantidadIncognitas];

            for (int i = 0; i < CantidadIncognitas; i++)
            {
                Solucion[i] = 0;
            }
            
            for (int i = 0; i < CantidadIncognitas - 1; i++)
            {
                DD = false;
                for (int j = 0; j < CantidadIncognitas; j++)
                {
                    if (i != j)
                    {
                        suma = suma + Math.Abs(Sistema[i, j]);
                    }

                }
                if (suma > Math.Abs(Sistema[i, i]))
                {
                    int fila = MayorCoeficiente(Sistema, i, CantidadIncognitas, i);

                    if (fila != 0)
                    {
                        nuevoResultado.BienCondicionado = true;
                        Sistema = Pivoteo(Sistema, i, fila, CantidadIncognitas);
                    }
                    else
                    {
                        nuevoResultado.BienCondicionado = false;
                    }
                }

            }

            int c = 0;
            double[] Xant = new double[CantidadIncognitas];
            for (int i = 0; i < CantidadIncognitas; i++)
            {
                Xant[i] = 0;
            }


            int Contador = 0;
            while (Contador < CantidadIncognitas && c < 100)
            {
                c = c + 1;
                Contador = 0;
                for (int i = 0; i < CantidadIncognitas; i++)
                {
                    suma = 0;

                    for (int j = 0; j < CantidadIncognitas; j++)
                    {

                        if (i == j)
                        {
                            continue;
                        }

                        suma = suma + (Sistema[i, j] * Solucion[j]);

                    }

                    Solucion[i] = (Sistema[i, CantidadIncognitas] - suma) / Sistema[i, i];

                    Er = Math.Abs((Solucion[i] - Xant[i]) / Solucion[i]);

                    if (c == 1) 
                    {
                        Xant[i] = Solucion[i];
                    }
                    //if (c == 1) //ACA ESTA MAL
                    //{
                    //    Xant[i] = Er;
                    //}
                    else
                    {

                        if (Er <= Tole) 
                        {
                            Contador = Contador + 1;
                        }
                        //if (Xant[i] <= Er) //ACA ESTÁ MAL.
                        //{
                        //    Contador = Contador + 1;
                        //}
                        else // ACA ESTA MAL
                        {
                            Xant[i] = Solucion[i];
                        }
                        //else // ACA ESTA MAL
                        //{
                        //    Xant[i] = Er;
                        //}
                    }

                }

            }

            for (int i = 0; i < CantidadIncognitas; i++)
            {
                nuevoResultado.resultado.Add(Solucion[i]);
            }

            return nuevoResultado;
        }


        //------------------------------ENCUENTRA LA FILA QUE SE VA A USAR PARA PIVOTEAR ------------------------
        public int MayorCoeficiente(double[,] Ecuaciones, int FilaPivotear, int CantidadIncognitas, int Columna)
        {
            int FilaIntercambiar = 0;
            double suma = 0;

            for (int i = FilaPivotear + 1; i < CantidadIncognitas-1; i++)
            {
                suma = 0;
                for (int j = 0; j < CantidadIncognitas-1; j++)
                {
                    if (j != Columna)
                    {

                        suma = suma + Math.Abs(Ecuaciones[i, j]);

                    }
                }

                if (suma < Math.Abs(Ecuaciones[i, Columna]))
                {
                    FilaIntercambiar = i;
                }
            }

            return FilaIntercambiar;

        }

        public double[,] Pivoteo(double[,] Ecuaciones, int FilaActual, int FilaPivotear, int CantidadIncognitas)
        {
            double aux;
            for (int j = 0; j < CantidadIncognitas + 1; j++)
            {
                aux = Ecuaciones[FilaActual, j];
                Ecuaciones[FilaActual, j] = Ecuaciones[FilaPivotear, j];
                Ecuaciones[FilaPivotear, j] = aux;
            }

            return Ecuaciones;
        }
    }

}
//public bool EsMayor (double[,] Sistema, int fila, int CantidadIncognitas)
//{
//    double resultado = Math.Abs(Sistema[fila, fila]);

//    for (int i = 0; i < CantidadIncognitas; i++)
//    {
//        if (i != fila)
//        {
//            resultado = resultado - Math.Abs(Sistema[fila, i]);
//        }
//    }
//    if (resultado > 0)
//    {
//        return true;
//    }

//    return false;
//}