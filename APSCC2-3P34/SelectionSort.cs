using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class SelectionSort
    {
        public static void Ordenar(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                OrdenarNumeros(dataSet, indiceColuna, maiorParaMenor);
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                OrdenarStrings(dataSet, indiceColuna, maiorParaMenor);
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                OrdenarData(dataSet, indiceColuna, maiorParaMenor);
            }
        }

        private static void OrdenarNumeros(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (maiorParaMenor)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if (((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > (((int)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])))
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if (((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) < (((int)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])))
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
        }       

        private static void OrdenarStrings(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (maiorParaMenor)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if(((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo(((string)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])) == -1)
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if (((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo(((string)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])) == 1)
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
        }

        private static void OrdenarData(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (maiorParaMenor)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo(((DateTime)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])) == -1)
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
                {
                    int indiceMinimo = i;
                    for (int j = i + 1; j < dataSet.Tables[0].Rows.Count - 1; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo(((DateTime)dataSet.Tables[0].Rows[indiceMinimo].ItemArray[indiceColuna])) == 1)
                        {
                            indiceMinimo = j;
                        }
                        Trocar(dataSet, i, indiceMinimo);
                    }
                }
            }
        }
        private static void Trocar(DataSetBase dataSet, int i, int indiceMinimo)
        {
            var temporario = dataSet.Tables[0].Rows[i].ItemArray;
            dataSet.Tables[0].Rows[i].ItemArray = dataSet.Tables[0].Rows[indiceMinimo].ItemArray;
            dataSet.Tables[0].Rows[indiceMinimo].ItemArray = temporario;
        }
    }
}