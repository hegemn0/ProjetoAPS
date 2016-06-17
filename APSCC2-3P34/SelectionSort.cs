using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class SelectionSort
    {

        public static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
        {
            for (int i = 0; i < dataSet.Tables[0].Rows.Count - 1; i++)
            {
                int j = i + 1;
                object[] temporario = dataSet.Tables[0].Rows[j].ItemArray;

                if(maiorParaMenor)
                {
                    MaiorParaMenor(dataSet, temporario, indiceColuna, ref j);
                }
                else
                {
                    MenorParaMaior(dataSet, temporario, indiceColuna, ref j);
                }

                dataSet.Tables[0].Rows[j].ItemArray = temporario;
            }
        }

        private static void MaiorParaMenor(DataSetBase dataSet, object[] temporario, int indiceColuna, ref int j)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                while (j > 0 && ((int)temporario[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                while (j > 0 && ((string)temporario[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                while (j > 0 && ((DateTime)temporario[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, object[] temporario, int indiceColuna, ref int j)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                while (j > 0 && ((int)temporario[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                while (j > 0 && ((string)temporario[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                while (j > 0 && ((DateTime)temporario[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j - 1].ItemArray[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - 1].ItemArray;
                    j--;
                }
            }
        }       
    }
}