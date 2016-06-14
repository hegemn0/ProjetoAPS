using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSCC2_3P34
{
    public static class QuickSort
    {
        public static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
        {
            Ordenar(dataSet, maiorParaMenor, indiceColuna, 0, dataSet.Tables[0].Rows.Count - 1);
        }

        private static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna, int esquerda, int direira)
        {
            int i = esquerda;
            int j = direira;
            object[] pivo = dataSet.Tables[0].Rows[(esquerda + direira) / 2].ItemArray;

            while (i <= j)
            {
                if (maiorParaMenor)
                {
                    MaiorParaMenor(dataSet, pivo, indiceColuna, ref i, ref j);                    
                }
                else
                {
                    MenorParaMaior(dataSet, pivo, indiceColuna, ref i, ref j);                    
                }

                if (i <= j)
                {
                    object[] temporario = dataSet.Tables[0].Rows[i].ItemArray;
                    dataSet.Tables[0].Rows[i].ItemArray = dataSet.Tables[0].Rows[j].ItemArray;
                    dataSet.Tables[0].Rows[j].ItemArray = temporario;

                    i++;
                    j--;
                }
            }

            if (esquerda < j)
            {
                Ordenar(dataSet, maiorParaMenor, indiceColuna, esquerda, j);
            }

            if (i < direira)
            {
                Ordenar(dataSet, maiorParaMenor, indiceColuna, i, direira);
            }
        }

        private static void MaiorParaMenor(DataSetBase dataSet, object[] pivo, int indiceColuna, ref int i, ref int j)
        {
            if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(int))
            {
                while (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)pivo[indiceColuna]) > 0)
                {
                    i++;
                }

                while (((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((int)pivo[indiceColuna]) < 0)
                {
                    j--;
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(string))
            {
                while (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)pivo[indiceColuna]) < 0)
                {
                    i++;
                }

                while (((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((string)pivo[indiceColuna]) > 0)
                {
                    j--;
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(DateTime))
            {
                while (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)pivo[indiceColuna]) < 0)
                {
                    i++;
                }

                while (((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((DateTime)pivo[indiceColuna]) > 0)
                {
                    j--;
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, object[] pivo, int indiceColuna, ref int i, ref int j)
        {
            if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(int))
            {
                while (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)pivo[indiceColuna]) < 0)
                {
                    i++;
                }

                while (((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((int)pivo[indiceColuna]) > 0)
                {
                    j--;
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(string))
            {
                while (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)pivo[indiceColuna]) > 0)
                {
                    i++;
                }

                while (((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((string)pivo[indiceColuna]) < 0)
                {
                    j--;
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(DateTime))
            {
                while (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)pivo[indiceColuna]) > 0)
                {
                    i++;
                }

                while (((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]).CompareTo((DateTime)pivo[indiceColuna]) < 0)
                {
                    j--;
                }
            }
        }
    }   
}
