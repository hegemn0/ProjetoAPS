using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class InsertionSort
    {
        public static void Ordenar(DataSetBase dataSet, int indiceColuna, bool maiorParaMenor)
        {
            if(maiorParaMenor)
            {
                MaiorParaMenor(dataSet, indiceColuna);
            }
            else
            {
                MenorParaMaior(dataSet, indiceColuna);
            }
        }

        private static void MaiorParaMenor(DataSetBase dataSet, int indiceColuna)
        {
            int i, j;
            object[] eleito;

            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((int)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((int)eleito[indiceColuna]) > 0))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) > 0))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((DateTime)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((DateTime)eleito[indiceColuna]) > 0))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, int indiceColuna)
        {
            int i, j;
            object[] eleito;

            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((int)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((int)eleito[indiceColuna]) < 0))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((string)eleito[indiceColuna]) < 0))
                    {
                        dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                        j = j - 1;
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = eleito;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                for (i = 1; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    eleito = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;
                    while ((j > 0) && (((DateTime)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]).CompareTo((DateTime)eleito[indiceColuna]) < 0))
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
            object[] temporario = dataSet.Tables[0].Rows[i].ItemArray;
            dataSet.Tables[0].Rows[i].ItemArray = dataSet.Tables[0].Rows[j].ItemArray;
            dataSet.Tables[0].Rows[j].ItemArray = temporario;
        }
    }
}