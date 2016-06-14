using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Text;

namespace APSCC2_3P34
{
    public static class BancoDeDados
    {
        const string comandoSQLInsert = "INSERT INTO Imagens(Imagem, Nome, Formato, Tamanho, Altura, Largura, DataCriacao) VALUES(?, ?, ?, ?, ?, ?, ?)";
        const string comandoSQLUpdate = "UPDATE Imagens SET Imagem = ?, Nome = ?, Formato = ?, Tamanho = ?, Altura = ?, Largura = ?, DataCriacao = ?, WHERE Id = ?";
        const string comandoSQLSelect = "SELECT * FROM Imagens";
        const string comandoSQLSelectColumn = "SELECT  FROM Imagens";
        const string comandoSQLSelectRows = "SELECT * FROM Imagens LIMIT @quantidade OFFSET @incio";
        const string comandoSQLCountRow = "SELECT COUNT(*) FROM Imagens";
        const string comandoSQLDelete = "DELETE FROM Imagens WHERE Id = ?";
        const string comandoSQLDeleteAll = "DELETE FROM Imagens";

        public static void Gerar()
        {
            GerarDiretorios();
            GerarLocalBancoDeDados();
            GerarConnectionString();
            GerarBancoDeDados();            
        }

        private static void GerarConnectionString()
        {
            Properties.Settings.Default.ListaConnectionStringsBancosDeDados = new System.Collections.Specialized.StringCollection();

            for (int i = 0; i < 4; i++)
            {
                SQLiteConnectionStringBuilder connectionStringSQL = new SQLiteConnectionStringBuilder();
                connectionStringSQL.DataSource = Properties.Settings.Default.ListaBancosDeDados[i];
                connectionStringSQL.DateTimeFormat = SQLiteDateFormats.CurrentCulture;
                connectionStringSQL.Version = 3;

                Properties.Settings.Default.ListaConnectionStringsBancosDeDados.Add(connectionStringSQL.ToString());
            }

            Properties.Settings.Default.Save();
        }

        private static void GerarLocalBancoDeDados()
        {
            Properties.Settings.Default.ListaBancosDeDados = new System.Collections.Specialized.StringCollection();

            for (int i = 0; i < 4; i++)
            {
                Properties.Settings.Default.ListaBancosDeDados.Add($@"{Properties.Settings.Default.DiretorioBancoDeDados}\{Properties.Settings.Default.ListaNomesBancosDeDados[i]}");
                Properties.Settings.Default.Save();
            }
        }

        private static void GerarDiretorios()
        {
            Properties.Settings.Default.DiretorioBancoDeDados = $@"{Properties.Settings.Default.DiretorioProjeto}\Banco de Dados";
            Directory.CreateDirectory(Properties.Settings.Default.DiretorioBancoDeDados);

            Properties.Settings.Default.Save();
        }

        private static void GerarBancoDeDados()
        {
            SQLiteConnection.CreateFile(Properties.Settings.Default.ListaBancosDeDados[0]);

            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    StringBuilder stringBuilderSQL = new StringBuilder();
                    stringBuilderSQL.AppendLine("CREATE TABLE Imagens  (");
                    stringBuilderSQL.AppendLine("[Id]   INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,");
                    stringBuilderSQL.AppendLine("[Imagem]   BLOB NOT NULL,");
                    stringBuilderSQL.AppendLine("[Nome] VARCHAR(50) NOT NULL,");
                    stringBuilderSQL.AppendLine("[Formato]  VARCHAR(3) NOT NULL,");
                    stringBuilderSQL.AppendLine("[Tamanho]  INTEGER NOT NULL,");
                    stringBuilderSQL.AppendLine("[Altura]   INTEGER NOT NULL,");
                    stringBuilderSQL.AppendLine("[Largura]  INTEGER NOT NULL,");
                    stringBuilderSQL.AppendLine("[DataCriacao]  DATETIME NOT NULL");
                    stringBuilderSQL.AppendLine(");");

                    using (SQLiteTransaction transacaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(conexaoSQL))
                    {
                        comandoSQL.CommandText = stringBuilderSQL.ToString();

                        comandoSQL.ExecuteNonQuery();
                        GerarBancoDeDadosSecundarios();
                        transacaoSQL.Commit();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ocorreu um erro ao tentar criar o banco de dados: " + exception.Message);
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        private static void GerarBancoDeDadosSecundarios()
        {
            for (int i = 1; i < 4; i++)
            {
                switch (i)
                {
                    case 1:
                        File.Copy(Properties.Settings.Default.ListaBancosDeDados[0], Properties.Settings.Default.ListaBancosDeDados[i]);
                        break;
                    case 2:
                        File.Copy(Properties.Settings.Default.ListaBancosDeDados[0], Properties.Settings.Default.ListaBancosDeDados[i]);
                        break;
                    case 3:
                        File.Copy(Properties.Settings.Default.ListaBancosDeDados[0], Properties.Settings.Default.ListaBancosDeDados[i]);
                        break;
                }
            }
        }

        public static void Inserir(ListaImagens listaImagens)
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    using (SQLiteTransaction tansasaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(conexaoSQL))
                    {
                        comandoSQL.CommandText = comandoSQLInsert;

                        for (int i = 0; i < listaImagens.Count; i++)
                        {
                            comandoSQL.Parameters.AddWithValue("Imagem", listaImagens[i].IMG);
                            comandoSQL.Parameters.AddWithValue("Nome", listaImagens[i].Nome);
                            comandoSQL.Parameters.AddWithValue("Formato", listaImagens[i].Formato);
                            comandoSQL.Parameters.AddWithValue("Tamanho", listaImagens[i].Tamanho);
                            comandoSQL.Parameters.AddWithValue("Altura", listaImagens[i].Altura);
                            comandoSQL.Parameters.AddWithValue("Largura", listaImagens[i].Largura);
                            comandoSQL.Parameters.AddWithValue("DataCriacao", listaImagens[i].DataCriacao);

                            comandoSQL.ExecuteNonQuery();
                        }
                        tansasaoSQL.Commit();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ocorreu um erro ao adicionar um ou mais items ao banco de dados: " + exception.Message);
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        public static void Update(int[] Id, ListaImagens listaImagens)
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    using (SQLiteTransaction transacaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(conexaoSQL))
                    {
                        comandoSQL.CommandText = comandoSQLUpdate;

                        for (int i = 0; i < listaImagens.Count; i++)
                        {
                            comandoSQL.Parameters.AddWithValue("Imagem", listaImagens[i].IMG);
                            comandoSQL.Parameters.AddWithValue("Nome", listaImagens[i].Nome);
                            comandoSQL.Parameters.AddWithValue("Formato", listaImagens[i].Formato);
                            comandoSQL.Parameters.AddWithValue("Tamanho", listaImagens[i].Tamanho);
                            comandoSQL.Parameters.AddWithValue("Altura", listaImagens[i].Altura);
                            comandoSQL.Parameters.AddWithValue("Largura", listaImagens[i].Largura);
                            comandoSQL.Parameters.AddWithValue("DataCriacao", listaImagens[i].DataCriacao);
                            comandoSQL.Parameters.AddWithValue("Id", Id[i]);

                            comandoSQL.ExecuteNonQuery();
                        }
                        transacaoSQL.Commit();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ocorreu um erro ao adicionar um ou mais item ao banco de dados: " + exception.Message);
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        public static DataSetBase Select()
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();
                    DataSetBase dataSet = new DataSetBase();

                    using (SQLiteTransaction transacaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(comandoSQLSelect, conexaoSQL))
                    using (SQLiteDataAdapter adaptadorSQL = new SQLiteDataAdapter(comandoSQL))
                    {
                        comandoSQL.ExecuteNonQuery();

                        
                        adaptadorSQL.Fill(dataSet, "Imagens");
                        transacaoSQL.Commit();
                    }
                    return dataSet;
                }                
                catch (Exception exception)
                {
                    Console.WriteLine("Occoreu um erro ao acessar o banco de dados: " + exception.Message);
                    return null;
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        public static int Contar()
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    using (SQLiteCommand comandoSQL = new SQLiteCommand(comandoSQLCountRow, conexaoSQL))
                    {
                        return Convert.ToInt32(comandoSQL.ExecuteScalar()) - 1;
                    }                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Occoreu um erro ao acessar o banco de dados: " + exception.Message);
                    return -1;
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        public static void Deletar(int[] Id)
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    using (SQLiteTransaction transacaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(conexaoSQL))
                    {
                        comandoSQL.CommandText = comandoSQLDelete;

                        for (int i = 0; i < Id.Length; i++)
                        {
                            comandoSQL.Parameters.AddWithValue("Id", Id[i]);
                            comandoSQL.ExecuteNonQuery();
                        }

                        transacaoSQL.Commit();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ocorreu um erro ao tentar remover um ou mais item do banco de dados: " + exception.Message);
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }

        public static void Deletar()
        {
            using (SQLiteConnection conexaoSQL = new SQLiteConnection(Properties.Settings.Default.ListaConnectionStringsBancosDeDados[0]))
            {
                try
                {
                    conexaoSQL.Open();

                    using (SQLiteTransaction transacaoSQL = conexaoSQL.BeginTransaction())
                    using (SQLiteCommand comandoSQL = new SQLiteCommand(conexaoSQL))
                    {
                        comandoSQL.CommandText = comandoSQLDeleteAll;
                        comandoSQL.ExecuteNonQuery();

                        transacaoSQL.Commit();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Ocorreu um erro ao tentar remover um ou mais item do banco de dados: " + exception.Message);
                }
                finally
                {
                    conexaoSQL.Close();
                }
            }
        }
    }
}