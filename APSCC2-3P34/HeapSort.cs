using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class HeapSort
    {
        public static void Ordenar(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
        {
            GerarHeapMaximo(dataSet, maiorParaMenor, indiceColuna);
            int tamanhoArray = dataSet.Tables[0].Rows.Count;

            for (int i = dataSet.Tables[0].Rows.Count - 1; i > 0 ; i--)
            {
                Trocar(dataSet, i, 0);
                HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, 0, --tamanhoArray);
            }
        }

        private static void GerarHeapMaximo(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna)
        {
            for (int i = dataSet.Tables[0].Rows.Count / 2 - 1; i >= 0; i--)
            {
                HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, dataSet.Tables[0].Rows.Count);
            }
        }

        private static void HeapficadorMaximo(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna, int k, int tamanhoArray)
        {
            int i = 2 * k + 1;
            int j = i + 1;

            if(i < tamanhoArray)
            {
                if(maiorParaMenor)
                {
                    MaiorParMenor(dataSet, maiorParaMenor, indiceColuna, tamanhoArray, i, j, k);
                }
                else
                {
                    MenorParaMaior(dataSet, maiorParaMenor, indiceColuna, tamanhoArray, i, j, k);
                }
            }
        }

        private static void MaiorParMenor(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna, int tamanhoArray, int i, int j, int k)
        {
            if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(int))
            {
                if (j < tamanhoArray && ((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(string))
            {
                if (j < tamanhoArray && ((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(DateTime))
            {
                if (j < tamanhoArray && ((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
        }

        private static void MenorParaMaior(DataSetBase dataSet, bool maiorParaMenor, int indiceColuna, int tamanhoArray, int i, int j, int k)
        {
            if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(int))
            {
                if (j < tamanhoArray && ((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((int)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((int)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(string))
            {
                if (j < tamanhoArray && ((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((string)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((string)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
            else if (dataSet.Tables[0].Rows[i].ItemArray[indiceColuna].GetType() == typeof(DateTime))
            {
                if (j < tamanhoArray && ((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[j].ItemArray[indiceColuna]) > 0)
                {
                    i = j;
                }

                if (((DateTime)dataSet.Tables[0].Rows[i].ItemArray[indiceColuna]).CompareTo((DateTime)dataSet.Tables[0].Rows[k].ItemArray[indiceColuna]) < 0)
                {
                    Trocar(dataSet, i, k);
                    HeapficadorMaximo(dataSet, maiorParaMenor, indiceColuna, i, tamanhoArray);
                }
            }
        }

        private static void Trocar(DataSetBase dataSet, int j, int posicaoJ)
        {
            object[] temporario = dataSet.Tables[0].Rows[j].ItemArray;
            dataSet.Tables[0].Rows[j].ItemArray = dataSet.Tables[0].Rows[posicaoJ].ItemArray;
            dataSet.Tables[0].Rows[posicaoJ].ItemArray = temporario;
        }
    }
}
