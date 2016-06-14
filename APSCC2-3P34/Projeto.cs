using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APSCC2_3P34
{
    [Serializable]
    class Projeto
    {
        private string nomeProjeto, diretorioProjeto, localProjeto, diretorioBancoDeDados;
        private byte[] hashProjeto;          

        private StringCollection listaBancosDeDados, listaConnectionStringsBancosDeDados;
        private DateTime dataCriacao, ultimaAlteracao;

        #region propriedades

        public string Nome
        {
            get { return nomeProjeto; }
            set { nomeProjeto = value; }
        }

        public string Diretorio
        {
            get { return diretorioProjeto; }
            set { diretorioProjeto = value; }
        }

        public string Local
        {
            get { return localProjeto; }
            set { localProjeto = value; }
        }

        public string DiretorioBancoDeDados
        {
            get { return diretorioBancoDeDados; }
            set { diretorioBancoDeDados = value; }
        }

        public byte[] Hash
        {
            get { return hashProjeto; }
            set { hashProjeto = value; }
        }

        public DateTime DataCriacao
        {
            get { return dataCriacao; }
        }

        public DateTime UltimaAlteracao
        {
            get { return ultimaAlteracao; }
            set { ultimaAlteracao = value; }
        }

        public StringCollection ListaBancosDeDados
        {
            get { return listaBancosDeDados; }
            set { listaBancosDeDados = value; }
        }
        public StringCollection ListaConnectionStringsBancosDeDados
        {
            get { return listaConnectionStringsBancosDeDados; }
            set { listaConnectionStringsBancosDeDados = value; }
        }

        public Projeto(string diretorioProjeto)
        {            
            if (dataCriacao.CompareTo(DateTime.Today) < 0)
            {
                this.diretorioProjeto = diretorioProjeto;
                InicializarCampos();
            }
            else
            {
                InicializarCampos();                
            }
        }

        #endregion

        private void CarregarConfiguracoes()
        {
            try
            {
                Properties.Settings.Default.ListaBancosDeDados = new StringCollection();
                Properties.Settings.Default.ListaConnectionStringsBancosDeDados = new StringCollection();

                Properties.Settings.Default.ListaBancosDeDados = listaBancosDeDados;
                Properties.Settings.Default.ListaConnectionStringsBancosDeDados = listaConnectionStringsBancosDeDados;

                Properties.Settings.Default.DiretorioBancoDeDados = diretorioBancoDeDados;
                Properties.Settings.Default.DiretorioProjeto = diretorioProjeto;
                Properties.Settings.Default.LocalProjeto = localProjeto;

                GerarUltimaAlteracao();
                Salvar();                
            }
            catch(Exception exception)
            {
                Console.WriteLine("Ocorreu um erro ao carregar as configurações do projeto: " + exception.Message);
            }
        }

        private void InicializarCampos()
        {
            GerarDiretorioProjeto();         
            GerarNomeProjeto();
            GerarLocalProjeto();
            GerarDataDeCriacao();
            GerarUltimaAlteracao();
            CriarBancoDeDados();
            Salvar();
        }

        private void GerarDiretorioProjeto()
        {            
            Properties.Settings.Default.DiretorioProjeto = diretorioProjeto;
            Properties.Settings.Default.Save();
            Directory.CreateDirectory(diretorioProjeto);
        }

        public void GerarNomeProjeto()
        {
            this.nomeProjeto = Path.GetFileNameWithoutExtension(Properties.Settings.Default.DiretorioProjeto);
        }

        public void GerarLocalProjeto()
        {
            Properties.Settings.Default.LocalProjeto = diretorioProjeto + "\\" + nomeProjeto + ".CC3P34";
            Properties.Settings.Default.Save();
        }

        private void GerarDataDeCriacao()
        {
            this.dataCriacao = DateTime.Now;
        }

        public void GerarUltimaAlteracao()
        {
            this.ultimaAlteracao = DateTime.Now;
        }

        private void CriarBancoDeDados()
        {
            BancoDeDados.Gerar();
        }

        private void Salvar()
        {
            Serializador.Serializar<Projeto>(Properties.Settings.Default.LocalProjeto, this);
            GerarHash();
            SalvarConfiguracoes();
        }

        private void SalvarConfiguracoes()
        {            
            try
            {
                listaBancosDeDados = Properties.Settings.Default.ListaBancosDeDados;
                listaConnectionStringsBancosDeDados = Properties.Settings.Default.ListaConnectionStringsBancosDeDados;
                diretorioBancoDeDados = Properties.Settings.Default.DiretorioBancoDeDados;
                diretorioProjeto = Properties.Settings.Default.DiretorioProjeto;
                localProjeto = Properties.Settings.Default.LocalProjeto;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Ocorreu um erro ao carregar as configurações do projeto: " + exception.Message);
            }
        }

        private void GerarHash()
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            using (FileStream fileStream = new FileStream(Properties.Settings.Default.LocalProjeto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                hashProjeto = sha256.ComputeHash(fileStream);
            }
        }

        private byte[] GerarHash(string localProjeto)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();

            using (FileStream fileStream = new FileStream(Properties.Settings.Default.LocalProjeto, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return sha256.ComputeHash(fileStream);
            }
        }

        public bool CompararHash()
        {
            try
            {
                Salvar($@"{Path.GetTempPath()}\{nomeProjeto}.CC3P34");
                var hash = GerarHash($@"{Path.GetTempPath()}\{nomeProjeto}");

                if (GerarHash($@"{Path.GetTempPath()}\{nomeProjeto}").Equals(hashProjeto))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Ocorreu um erro ao tentar comparar a hash deste projeto: " + exception.Message);
                return false;
            }
            finally
            {
                File.Delete($@"{Path.GetTempPath()}\{nomeProjeto}");
            }
        }

        public void Salvar(string destinoProjeto)
        {
            Serializador.Serializar<Projeto>(destinoProjeto, this);
            GerarHash();
            SalvarConfiguracoes();
        }
    }
}
