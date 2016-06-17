using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Ordenador
{
    public partial class Controle : Form
    {
        private Projeto projeto;
        private int totalRegistros, indiceColuna;
        private int[] listaTamanhoColunas, listaPaginas;
        private const string RegexImagem = "Arquivos de Imagem|*.bmp;*.jpg;*.png;";
        private const string RegexProjeto = "Projeto|*.cc3p34;";
        private string[] listaNomeColunas;
        private bool projetoEstaAberto = false, projetoAlterado = false, dadosOrdenados = false;
        private DataSetBase dataSetOriginal, dataSetBubbleSort, dataSetInsertionSort, dataSetSelectionSort, dataSetQuickSort, dataSetShellSort, dataSetHeapSort;
        private Stopwatch cronometroExecucao;
        private DataGridView[] listaDataGridView;
        private DataSetBase[] listaDataSet;
        private TextBox[] listaTextBox;
        private ToolStripMenuItem[] listaTSMISelecionar;
        private TabPage[] listaTabPages;
        private ToolStripMenuItem[] listaTSMIVisibilidade;
        private Type[] listaTipos;

        public int[] ListaPaginas
        {
            get { return listaPaginas; }
            set { listaPaginas = value; }
        }

        public DataGridView[] ListaDataGridView
        {
            get { return listaDataGridView; }
            set { listaDataGridView = value; }
        }

        public Controle()
        {
            InitializeComponent();
        }

        private void Novo()
        {
            if (projetoEstaAberto == true)
            {
                DialogoSalvarOuDescartarProjeto();
            }
            else
            {
                using (SaveFileDialog sFD_NovoProjeto = new SaveFileDialog())
                {
                    if (sFD_NovoProjeto.ShowDialog() == DialogResult.OK)
                    {
                        projeto = new Projeto(sFD_NovoProjeto.FileName);
                        this.Text = projeto.Nome;
                        projetoEstaAberto = true;
                        projetoAlterado = true;
                        AtualizarInterface();
                    }
                }
            }
        }

        private void Abrir()
        {
            if (projetoEstaAberto == true)
            {
                DialogoSalvarOuDescartarProjeto();
            }
            else
            {
                using (OpenFileDialog oFD_AbrirProjeto = new OpenFileDialog() { Filter = RegexProjeto })
                {
                    if (oFD_AbrirProjeto.ShowDialog() == DialogResult.OK)
                    {
                        projeto = Serializador.Deserializar<Projeto>(oFD_AbrirProjeto.FileName);
                        totalRegistros = BancoDeDados.Contar();
                        this.Text = projeto.Nome;                        
                        projetoEstaAberto = true;
                        dadosOrdenados = false;
                        AtualizarInterface();
                        Atualizar();
                    }
                }
            }
        }

        private void Salvar()
        {
            projeto.Salvar(Properties.Settings.Default.LocalProjeto);
            projetoAlterado = false;
        }

        private void Fechar()
        {
            if (projeto.CompararHash() == false)
            {
                DialogoSalvarOuDescartarProjeto();
            }
            else
            {
                Descartar();
            }
        }

        private void Sair()
        {
            if (projetoEstaAberto && projetoAlterado)
            {
                DialogoSalvarOuDescartarSair();
            }
            else
            {
                this.Close();
            }
        }

        private void Adicionar()
        {
            try
            {
                using (OpenFileDialog oFD_AdicionarImagem = new OpenFileDialog() { Filter = RegexImagem, Multiselect = true })
                {
                    if (oFD_AdicionarImagem.ShowDialog() == DialogResult.OK)
                    {
                        BancoDeDados.Inserir(
                            AuxiliarImagem.Gerar(oFD_AdicionarImagem.FileNames));
                        projetoAlterado = true;
                        dadosOrdenados = false;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao inserir items no banco de dados: " + exception.Message);
            }
            finally
            {
                Atualizar();
            }
        }

        private void Remover()
        {
            try
            {
                if (ModifierKeys == Keys.Control)
                {
                    DialogResult resultadoDialogo = MessageBox.Show($"Esta operação apagará todos os registros de '{projeto.Nome}', desaja prosseguir? ", $"Apagar registros {projeto.Nome}",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    switch (resultadoDialogo)
                    {
                        case DialogResult.Yes:
                            BancoDeDados.Deletar();
                            projetoAlterado = true;
                            dadosOrdenados = false;
                            PB_Preview.Image = null;
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {                    
                    if (totalRegistros > 0)
                    {
                        int[] linhasSelecionas = new int[totalRegistros];

                        for (int i = 0; i < listaDataGridView[TC_BancoDeDados.SelectedIndex].SelectedRows.Count; i++)
                        {
                            linhasSelecionas[i] = Convert.ToInt32(listaDataGridView[TC_BancoDeDados.SelectedIndex].SelectedRows[i].Cells[0].Value);
                        }

                        BancoDeDados.Deletar(linhasSelecionas);
                        projetoAlterado = true;
                        dadosOrdenados = false;
                        PB_Preview.Image = null;
                    }
                    else
                    {
                        int[] linhas = new int[1];

                        for (int i = 0; i < listaDataGridView[TC_BancoDeDados.SelectedIndex].SelectedRows.Count; i++)
                        {
                            linhas[i] = Convert.ToInt32(listaDataGridView[TC_BancoDeDados.SelectedIndex].SelectedRows[i].Cells[0].Value);
                        }

                        BancoDeDados.Deletar(linhas);
                        projetoAlterado = true;
                        dadosOrdenados = false;
                        PB_Preview.Image = null;
                    }                                    
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Erro ao remover um ou mais items do banco de dados: " + exception.Message);
            }
            finally
            {
                Atualizar();
            }
        }

        private void Atualizar()
        {
            try
            {
                totalRegistros = BancoDeDados.Contar();

                if (projetoEstaAberto)
                {
                    if (totalRegistros >= 0)
                    {
                        listaDataSet[0] = BancoDeDados.Select();  
                                                                                              
                        OrganizarDataGridView(listaDataSet[0], listaDataGridView[0]);                       
                        AtualizarInterface();
                    }
                    else
                    {
                        listaDataGridView[TC_BancoDeDados.SelectedIndex].DataSource = null;
                        listaDataGridView[TC_BancoDeDados.SelectedIndex].Refresh();
                        TSB_Remover.Enabled = false;
                        TSB_Atualizar.Enabled = false;
                        TC_BancoDeDados.Enabled = false;
                        PB_Preview.Image = null;
                        TSDDB_Ocultar.Enabled = false;
                        TSDDB_Selecionar.Enabled = true;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ocorreu um erro ao atualizar DataGridView: " + exception.Message);
            }
        }

        private void OrganizarDataGridView(DataSetBase dataSet, DataGridView dataGridView)
        {
            try
            {
                dataGridView.DataSource = dataSet.Tables[0];

                dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                for (int i = 0; i < 8; i++)
                {
                    dataGridView.Columns[i].HeaderText = listaNomeColunas[i];
                    dataGridView.Columns[i].Width = listaTamanhoColunas[i];
                    dataGridView.Columns[i].ValueType = listaTipos[i];

                    if (i != 2)
                    {
                        dataGridView.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }                

                for(int i = 0; i < TSDDB_Ocultar.DropDownItems.Count; i++)
                {
                    if (((ToolStripMenuItem)TSDDB_Ocultar.DropDownItems[i]).Checked)
                    {
                        dataGridView.Columns[i].Visible = true;
                    }
                    else
                    {
                        dataGridView.Columns[i].Visible = false;
                    }
                }

                dataGridView.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ocorreu um erro ao gerar o DataGridView: " + exception.Message);
            }
        }

        private void AtualizarInterface()
        {
            if (projetoEstaAberto == true)
            {                
                TSB_Salvar.Enabled = true;
                TSB_Adicionar.Enabled = true;
                TSB_Ordenar.Enabled = true;
                TSB_Remover.Enabled = true;
                TSB_Atualizar.Enabled = true;
                TSDDB_Selecionar.Enabled = true;
                TSDDB_Ocultar.Enabled = true;
                TSDDB_Algoritmo.Enabled = true;
                TSDDB_Sentido.Enabled = true;
                TSMI_Salvar.Enabled = true;
                TSMI_Fechar.Enabled = true;
                TC_BancoDeDados.Enabled = true;
                PB_Preview.Enabled = true;
                this.Text = $"{projeto.Nome} - ({totalRegistros}) Imagens";
            }
            else
            {
                TSB_Salvar.Enabled = false;
                TSB_Adicionar.Enabled = false;
                TSB_Remover.Enabled = false;
                TSB_Ordenar.Enabled = true;
                TSB_Atualizar.Enabled = false;
                TSDDB_Selecionar.Enabled = false;
                TSDDB_Ocultar.Enabled = false;
                TSDDB_Algoritmo.Enabled = false;
                TSDDB_Sentido.Enabled = false;
                TSMI_Salvar.Enabled = false;
                TSMI_Fechar.Enabled = false;
                TC_BancoDeDados.Enabled = false;
                PB_Preview.Enabled = false;
                this.Text = null;
            }
        }

        private void Descartar()
        {
            projeto = null;
            listaDataGridView[0].DataSource = null;
            listaDataGridView[0].Refresh();            
            projetoEstaAberto = false;
            projetoAlterado = false;
            PB_Preview.Image = null;
            AtualizarInterface();
        }

        private void Detalhes()
        {
            Detalhes detalhesImagem = new Detalhes(listaDataSet[TC_BancoDeDados.SelectedIndex],
                listaDataGridView[TC_BancoDeDados.SelectedIndex].CurrentRow.Index, totalRegistros,
                TC_BancoDeDados.SelectedIndex, TC_BancoDeDados.SelectedTab.Text)
            { StartPosition = FormStartPosition.WindowsDefaultLocation };
            
            detalhesImagem.Show();
        }

        private void DialogoSalvarOuDescartarProjeto()
        {
            DialogResult resultadoDialogo = MessageBox.Show($"Salvar alterações feitas no projeto '{projeto.Nome}' antes de fechar?", $"Fechar {projeto.Nome}",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (resultadoDialogo)
            {
                case DialogResult.Yes:
                    Salvar();
                    Descartar();
                    break;
                case DialogResult.No:
                    Descartar();
                    break;
            }
        }

        private void DialogoSalvarOuDescartarSair()
        {
            DialogResult resultadoDialogo = MessageBox.Show($"Salvar alterações feitas no projeto '{projeto.Nome}' antes de fechar?", $"Fechar {projeto.Nome}",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            switch (resultadoDialogo)
            {
                case DialogResult.Yes:
                    Salvar();
                    Descartar();
                    Sair();
                    break;
                case DialogResult.No:
                    Descartar();
                    Sair();
                    break;
            }
        }

        private void TempoDeExecucao(bool iniciarContagem, TextBox textBox)
        {
            if(iniciarContagem)
            {
                cronometroExecucao.Start();
            }
            else
            {
                cronometroExecucao.Stop();
                GerarStringTempoDeExecucao(cronometroExecucao.Elapsed, textBox);
                cronometroExecucao.Reset();
            }            
        }

        private void GerarStringTempoDeExecucao(TimeSpan tempoExecucao, TextBox textBox)
        {
            if(tempoExecucao.Days > 0)
            {
                textBox.Text = $"{Convert.ToString(tempoExecucao.Minutes)}d";
            }
            else
            {
                if (tempoExecucao.Hours > 0)
                {
                    textBox.Text = $"{Convert.ToString(tempoExecucao.Minutes)}h";
                }
                else
                {
                    if (tempoExecucao.Minutes > 0)
                    {
                        textBox.Text = $"{Convert.ToString(tempoExecucao.Minutes)}m";
                    }
                    else
                    {
                        if (tempoExecucao.Seconds > 0)
                        {
                            textBox.Text = $"{Convert.ToString(tempoExecucao.Seconds)}s";
                        }
                        else
                        {
                            textBox.Text = $"{Convert.ToString(tempoExecucao.Milliseconds)}ms";
                        }
                    }
                }
            }
        }

        private void CarregarPreviewLateral(DataGridViewRow linhaSelecionada)
        {
            if (linhaSelecionada != null)
            {
                using (MemoryStream memoryStreamImagem = new MemoryStream((byte[])linhaSelecionada.Cells[1].Value))
                {
                    PB_Preview.Image = Image.FromStream(memoryStreamImagem);
                }
            }
        }

        private void CarregarPreviewLateral()
        {
            using (MemoryStream memoryStreamImagem = new MemoryStream((byte[])listaDataGridView[TC_BancoDeDados.SelectedIndex].Rows[0].Cells[1].Value))
            {
                PB_Preview.Image = Image.FromStream(memoryStreamImagem);
            }
        }

        private void GerarColunaSelecionada()
        {
            for(int i = 0; i < TSDDB_Selecionar.DropDownItems.Count; i++)
            {
                if(((ToolStripMenuItem)TSDDB_Selecionar.DropDownItems[i]).Checked)
                {
                    indiceColuna = i;
                }
            }
        }

        private void Ordenar(bool maiorParaMenor)
        {
            GerarColunaSelecionada();

            if (TSMI_BubbleSort.Checked)
            {
                listaDataSet[1] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_BubbleSort);                

                BubbleSort.Ordenar(listaDataSet[1], TSMI_MaiorParaMenor.Checked, indiceColuna);

                TempoDeExecucao(false, TXB_BubbleSort);

                OrganizarDataGridView(listaDataSet[1], listaDataGridView[1]);
            }

            if (TSMI_QuickSort.Checked)
            {
                listaDataSet[2] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_QuickSort);

                QuickSort.Ordenar(listaDataSet[2], TSMI_MaiorParaMenor.Checked, indiceColuna);

                TempoDeExecucao(false, TXB_QuickSort);

                OrganizarDataGridView(listaDataSet[2], listaDataGridView[2]);
            }

            if (TSMI_InsertionSort.Checked)
            {
                listaDataSet[3] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_InsertionSort);                

                InsertionSort.Ordenar(listaDataSet[3], indiceColuna, TSMI_MaiorParaMenor.Checked);

                TempoDeExecucao(false, TXB_InsertionSort);

                OrganizarDataGridView(listaDataSet[3], listaDataGridView[3]);
            }

            if (TSMI_ShellSort.Checked)
            {
                listaDataSet[4] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_ShellSort);

                ShellSort.Ordenar(listaDataSet[4], TSMI_MaiorParaMenor.Checked, indiceColuna);

                TempoDeExecucao(false, TXB_ShellSort);

                OrganizarDataGridView(listaDataSet[4], listaDataGridView[4]);
            }

            if (TSMI_SelectionSort.Checked)
            {
                listaDataSet[5] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_SelectionSort);
               
                SelectionSort.Ordenar(listaDataSet[5], TSMI_MaiorParaMenor.Checked, indiceColuna);

                TempoDeExecucao(false, TXB_SelectionSort);

                OrganizarDataGridView(listaDataSet[5], listaDataGridView[5]);

            }

            if (TSMI_HeapSort.Checked)
            {
                listaDataSet[6] = (DataSetBase)listaDataSet[0].Copy();

                TempoDeExecucao(true, TXB_HeapSort);

                QuickSort.Ordenar(listaDataSet[6], TSMI_MaiorParaMenor.Checked, indiceColuna);

                TempoDeExecucao(false, TXB_HeapSort);

                OrganizarDataGridView(listaDataSet[6], listaDataGridView[6]);
            }
        }

        private void AtualizarVisibilidadeColunas()
        {
            for (int i = 0; i < TSDDB_Ocultar.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)TSDDB_Ocultar.DropDownItems[i]).Checked)
                {
                    if(DGV_Original.RowCount > 0)
                        DGV_Original.Columns[i].Visible = true;

                    if(DGV_BubbleSort.RowCount > 0)
                        DGV_BubbleSort.Columns[i].Visible = true;

                    if (DGV_QuickSort.RowCount > 0)
                        DGV_QuickSort.Columns[i].Visible = true;

                    if (DGV_InsertionSort.RowCount > 0)
                        DGV_InsertionSort.Columns[i].Visible = true;

                    if (DGV_ShellSort.RowCount > 0)
                        DGV_ShellSort.Columns[i].Visible = true;

                    if (DGV_SelectionSort.RowCount > 0)
                        DGV_SelectionSort.Columns[i].Visible = true;

                    if (DGV_HeapSort.RowCount > 0)
                        DGV_HeapSort.Columns[i].Visible = true;
                }
                else
                {
                    if (DGV_Original.RowCount > 0)
                        DGV_Original.Columns[i].Visible = false;

                    if (DGV_BubbleSort.RowCount > 0)
                        DGV_BubbleSort.Columns[i].Visible = false;

                    if (DGV_QuickSort.RowCount > 0)
                        DGV_QuickSort.Columns[i].Visible = false;

                    if (DGV_InsertionSort.RowCount > 0)
                        DGV_InsertionSort.Columns[i].Visible = false;

                    if (DGV_ShellSort.RowCount > 0)
                        DGV_ShellSort.Columns[i].Visible = false;

                    if (DGV_SelectionSort.RowCount > 0)
                        DGV_SelectionSort.Columns[i].Visible = false;

                    if (DGV_HeapSort.RowCount > 0)
                        DGV_HeapSort.Columns[i].Visible = false;
                }
            }
        }
       
        private void TSMI_NovoProjeto_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void TSB_NovoProjeto_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void TSMI_Fechar_Click(object sender, EventArgs e)
        {
            Fechar();
        }

        private void TSMI_Sair_Click(object sender, EventArgs e)
        {
            Sair();
        }

        private void TSB_AbrirProjeto_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void TSMI_AbrirProjeto_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void TSB_Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar();
        }

        private void DGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detalhes();
        }

        private void TSB_Remover_Click(object sender, EventArgs e)
        {
            Remover();
        }

        private void DGV_BDInicial_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            listaDataGridView[TC_BancoDeDados.SelectedIndex].ClearSelection();
        }

        private void TSB_SalvarProjeto_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void DGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CarregarPreviewLateral(listaDataGridView[TC_BancoDeDados.SelectedIndex].CurrentRow);            
        }

        private void TSMI_SalvarProjeto_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void TSDDB_Selecionar_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            for (int i = 0; i < TSDDB_Selecionar.DropDownItems.Count; i++)
            {
                if(((ToolStripMenuItem)TSDDB_Selecionar.DropDownItems[i]).Checked)
                {
                    ((ToolStripMenuItem)TSDDB_Selecionar.DropDownItems[i]).Checked = false;
                    ((ToolStripMenuItem)TSDDB_Selecionar.DropDownItems[i]).Image = null;
                }
            }

            if(!((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = true;
                ((ToolStripMenuItem)e.ClickedItem).Image = Properties.Resources.ponto;
            }

            GerarColunaSelecionada();
        }

        private void TSMI_Sobre_Click(object sender, EventArgs e)
        {
            using (Sobre sobre = new Sobre())
            {
                sobre.ShowDialog();
            }
        }

        private void TSDDB_Ocultar_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = true;
                ((ToolStripMenuItem)e.ClickedItem).Image = Properties.Resources.ponto;
            }
            else
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;
                ((ToolStripMenuItem)e.ClickedItem).Image = null;
            }

            AtualizarVisibilidadeColunas();
        }

        private void TSDDB_Algoritmo_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int cont = 0;

            for (int i = 0; i < TSDDB_Algoritmo.DropDownItems.Count; i++)
            {
                if (((ToolStripMenuItem)TSDDB_Algoritmo.DropDownItems[i]).Checked)
                {
                    cont++;
                }
            }

            if (!((ToolStripMenuItem)e.ClickedItem).Checked)
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = true;
                ((ToolStripMenuItem)e.ClickedItem).Image = Properties.Resources.ponto;
            }
            else if(((ToolStripMenuItem)e.ClickedItem).Checked && cont > 1)
            {
                ((ToolStripMenuItem)e.ClickedItem).Checked = false;
                ((ToolStripMenuItem)e.ClickedItem).Image = null;
            }
        }

        private void TC_BancoDeDados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TC_BancoDeDados.SelectedIndex != 0)
            {
                TSB_Atualizar.Enabled = false;
                TSB_Adicionar.Enabled = false;
                TSB_Remover.Enabled = false;
            }
            else
            {
                TSB_Atualizar.Enabled = true;
                TSB_Adicionar.Enabled = true;
                TSB_Remover.Enabled = true;
            }

            if (listaDataGridView[TC_BancoDeDados.SelectedIndex].RowCount > 0)
            {
                CarregarPreviewLateral();
            }
        }

        private void TSB_Ordenar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaTextBox.Length; i++)
            {
                listaTextBox[i].Clear();
            }
            
            Ordenar(TSMI_MaiorParaMenor.Checked);
        }

        private void TSDDB_Sentido_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (((ToolStripMenuItem)e.ClickedItem).Equals(TSMI_MaiorParaMenor))
            {
                TSMI_MaiorParaMenor.Checked = true;
                TSMI_MenorParaMaior.Checked = false;                
            }
            else
            {                
                TSMI_MaiorParaMenor.Checked = false;
                TSMI_MenorParaMaior.Checked = true;
            }
        }

        private void DGV_BubbleSort_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            listaDataGridView[TC_BancoDeDados.SelectedIndex].ClearSelection();
        }

        private void TSB_Adicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void TSMI_Adicionar_Click(object sender, EventArgs e)
        {
            Adicionar();
        }

        private void Controle_Load(object sender, EventArgs e)
        {
            cronometroExecucao = new Stopwatch();

            listaTSMIVisibilidade = new ToolStripMenuItem[]
            {
                TSMI_OcultarId,
                TSMI_OcultarImagem,
                TSMI_OcultarNome,
                TSMI_OcultarFormato,
                TSMI_OcultarTamanho,
                TSMI_OcultarAltura,
                TSMI_OcultarLargura,
                TSMI_OcultarDataCriacao
            };

            listaTSMISelecionar = new ToolStripMenuItem[]
            {
                TSMI_SelecionarId,
                TSMI_SelecionarImagem,
                TSMI_SelecionarNome,
                TSMI_SelecionarFormato,
                TSMI_SelecionarTamanho,
                TSMI_SelecionarAltura,
                TSMI_SelecionarLargura,
                TSMI_SelecionarDataCriacao,
            };

            listaTabPages = new TabPage[]
            {
                TB_Original,
                TB_BubbleSort,
                TB_QuickSort,
                TB_InsertionSort,
                TB_ShellSort,
                TB_SelectionSort,                               
                TB_HeapSort,
            };

            listaTextBox = new TextBox[]
            {
                TXB_BubbleSort,
                TXB_QuickSort,
                TXB_InsertionSort,
                TXB_ShellSort,
                TXB_SelectionSort,                               
                TXB_HeapSort
            };

            dataSetOriginal = new DataSetBase();
            dataSetBubbleSort = new DataSetBase();
            dataSetInsertionSort = new DataSetBase();
            dataSetSelectionSort = new DataSetBase();
            dataSetQuickSort = new DataSetBase();
            dataSetShellSort = new DataSetBase();
            dataSetHeapSort = new DataSetBase();

            listaDataSet = new DataSetBase[]
            {
                dataSetOriginal,
                dataSetBubbleSort,
                dataSetQuickSort,                
                dataSetInsertionSort,
                dataSetShellSort,
                dataSetSelectionSort,
                dataSetHeapSort,
            };

            listaDataGridView = new DataGridView[]
            {
                DGV_Original,
                DGV_BubbleSort,
                DGV_QuickSort,
                DGV_InsertionSort,
                DGV_ShellSort,
                DGV_SelectionSort,                                
                DGV_HeapSort,
            };

            listaTipos = new Type[]
            {
                typeof(Int64),
                typeof(Image),
                typeof(string),
                typeof(string),
                typeof(Int64),
                typeof(Int64),
                typeof(Int64),
                typeof(DateTime),
            };

            listaNomeColunas = new string[]
            {
                "Id",
                "Preview",
                "Nome",
                "Formato",
                "Tamanho (bytes)",
                "Altura (pixels)",
                "Largura (pixels)",
                "Data de Criação",
            };

            listaTamanhoColunas = new int[]
            {
                30,
                50,
                200,
                70,
                100,
                80,
                80,
                120,
            };

            GerarColunaSelecionada();
        }

        private void Controle_FormClosing(object sender, FormClosingEventArgs e)
        {        
        }              
    }
}
