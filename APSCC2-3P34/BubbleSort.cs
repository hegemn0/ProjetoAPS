using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class BubbleSort
    {
        public static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
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
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, int indiceColuna)
        {
            if (dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(int))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) < 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(string)))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) < 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
                }
            }
            else if ((dataSet.Tables[0].Columns[indiceColuna].DataType == typeof(DateTime)))
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < dataSet.Tables[0].Rows.Count; j++)
                    {
                        if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) < 0)
                        {
                            Trocar(dataSet, i, j);
                        }
                    }
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