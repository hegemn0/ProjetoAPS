using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class ShellSort
    {
        public static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
        {
            int diferenca = 1;
            int tamanho = dataSet.Tables[0].Rows.Count;

            while(diferenca < tamanho)
            {
                diferenca = diferenca * 3 + 1;
            }

            diferenca = diferenca / 3;

            object[] temporario;
            int j;

            while(diferenca >  0)
            {
                for (int i = diferenca; i < tamanho; i++)
                {
                    temporario = dataSet.Tables[0].Rows[i].ItemArray;
                    j = i;

                    if (maiorParaMenor)
                    {
                        MaiorParaMenor(dataSet, temporario, indiceColuna, diferenca, ref j);
                    }
                    else
                    {
                        MenorParaMaior(dataSet, temporario, indiceColuna, diferenca, ref j);
                    }

                    dataSet.Tables[0].Rows[j].ItemArray = temporario;
                }
                diferenca = diferenca / 2;
            }

        }

        private static void MaiorParaMenor(DataSetBase dataSet, object[] temporario, int indiceColuna, int diferenca, ref int j)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                while (j >= diferenca && ((int)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((int)temporario[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                while (j >= diferenca && ((string)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((string)temporario[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                while (j >= diferenca && ((DateTime)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((DateTime)temporario[indiceColuna]) < 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, object[] temporario, int indiceColuna, int diferenca, ref int j)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                while (j >= diferenca && ((int)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((int)temporario[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                while (j >= diferenca && ((string)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((string)temporario[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                while (j >= diferenca && ((DateTime)dataSet.Tables[0].Rows[j - diferenca].ItemArray[indiceColuna]).CompareTo((DateTime)temporario[indiceColuna]) > 0)
                {
                    dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[j - diferenca].ItemArray;
                    j = j - diferenca;
                }
            }
        }
    }    
}
