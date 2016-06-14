using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class BubbleSort
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
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if ((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna] > (int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna])
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if ((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna] < (int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna])
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
        }        

        private static void OrdenarStrings(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (maiorParaMenor)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) == -1)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) == 1)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
        }

        private static void OrdenarData(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if (maiorParaMenor)
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) == -1)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) == 1)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
        }

        private static void Trocar(DataSetBase dataSet, int i, int j)
        {
            var temporario = dataSet.Tables[0].Rows[i].ItemArray;
            dataSet.Tables[0].Rows[i].ItemArray = dataSet.Tables[0].Rows[j].ItemArray;
            dataSet.Tables[0].Rows[j].ItemArray = temporario;
        }
    }
}