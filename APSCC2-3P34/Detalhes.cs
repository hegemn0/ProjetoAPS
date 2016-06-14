using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenador
{
    public partial class Detalhes : Form
    {
        private DataSet dataSet;
        private int linhaAtual, totalRegistros, bancoDeDados;
        private bool linhaFinal, linhaInicial;
        private string nomeAba;

        public Detalhes(DataSet dataSet, int linhaAtual, int totalRegistros, int bancoDeDados, string nomeAba)
        {
            this.dataSet = dataSet;
            this.linhaAtual = linhaAtual;
            this.totalRegistros = totalRegistros;
            this.bancoDeDados = bancoDeDados;
            this.nomeAba = nomeAba;
                        
            InitializeComponent();
        }

        private void B_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detalhes_Load(object sender, EventArgs e)
        {                        
            CarregarPagina(linhaAtual);
        }

        private void B_Proximo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModifierKeys == Keys.Control)
                {
                    linhaAtual = totalRegistros;
                    CarregarPagina(linhaAtual);
                }
                else
                {
                    linhaAtual += 1;
                    CarregarPagina(linhaAtual);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ocorreu um erro ao carregar a proxíma imagem: " + exception.Message);
            }
        }

        private void B_Anterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (ModifierKeys == Keys.Control)
                {
                    linhaAtual = 0;
                    CarregarPagina(linhaAtual);
                }
                else
                {
                    linhaAtual -= 1;
                    CarregarPagina(linhaAtual);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ocorreu um erro ao carregar a imagem anterior: " + exception.Message);
            }
        }
    
        private void CarregarPagina(int linhaAtual)
        {
            try
            {
                VerificarPaginasELinhas();

                using (MemoryStream memoryStreamImagem = new MemoryStream((byte[])dataSet.Tables[0].Rows[linhaAtual].ItemArray[1]))
                {
                    PB_Detalhes.Image = Image.FromStream(memoryStreamImagem);
                }

                this.Text = $"{Convert.ToString(dataSet.Tables[0].Rows[linhaAtual].ItemArray[2])}.{Convert.ToString(dataSet.Tables[0].Rows[linhaAtual].ItemArray[3]).ToLower()} - {nomeAba}";
            }
            catch(Exception exception)
            {
                MessageBox.Show("Ocorreu um erro ao carregar a imagem: " + exception.Message);
            }
        }

        private void VerificarPaginasELinhas()
        {
            linhaInicial = linhaAtual == 0 ? true : false;
            linhaFinal = linhaAtual == totalRegistros ? true : false;
            B_Anterior.Enabled = linhaInicial == false ? true : false;
            B_Proximo.Enabled = linhaFinal == false ? true : false;
        }
    }
}
