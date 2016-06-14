using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSCC2_3P34
{
    public static class InsertionSort
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
            int i, j;
            object[] eleito;

            if (maiorParaMenor)
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((int)dataSet.Tables[0].Rows[j-1].ItemArray[indiceColuna]) < (int)eleito[indiceColuna]))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j-1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((int)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) > (int)eleito[indiceColuna]))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
        }

        private static void OrdenarStrings(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            int i, j;
            object[] eleito;

            if (maiorParaMenor)
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) == 1))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) == -1))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
        }

        private static void OrdenarData(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            int i, j;
            object[] eleito;

            if (maiorParaMenor)
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) == 1))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) == -1))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
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