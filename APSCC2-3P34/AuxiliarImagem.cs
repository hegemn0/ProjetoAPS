using System;
using System.Drawing;
using System.IO;

namespace APSCC2_3P34
{
    public static class AuxiliarImagem
    {
        public static ListaImagens Gerar(string[] localImagens)
        {
            using (ListaImagens listaImagens = new ListaImagens())
            {
                for (int i = 0; i < localImagens.Length; i++)
                {
                    Imagem imagem = new Imagem();

                    imagem.IMG = GerarImagem(localImagens[i]);
                    imagem.Nome = GerarNome(localImagens[i]);
                    imagem.Formato = GerarFormato(localImagens[i]);
                    imagem.Tamanho = GerarTamanho(localImagens[i]);
                    imagem.Altura = GerarAltura(localImagens[i]);
                    imagem.Largura = GerarLargura(localImagens[i]);
                    imagem.DataCriacao = GerarDataCriacao(localImagens[i]);

                    listaImagens.Add(imagem);
                }
                return listaImagens;
            }
        }            
    
        public static byte[] GerarImagem(string localImagem)
        {
            return File.ReadAllBytes(localImagem);
        }

        public static string GerarNome(string localImagem)
        {
            return Path.GetFileNameWithoutExtension(localImagem);
        }

        public static string GerarFormato(string localImagem)
        {
            string extensao = Path.GetExtension(localImagem);
            string formato = Path.GetExtension(localImagem).Replace(".", string.Empty);
            return formato.ToUpper();

        }

        public static int GerarTamanho(string localImagem)
        {
            FileInfo imagem = new FileInfo(localImagem);
            return Convert.ToInt32(imagem.Length);
        }

        public static int GerarAltura(string localImagem)
        {
            return Image.FromFile(localImagem).Height;
        }

        public static int GerarLargura(string localImagem)
        {
            return Image.FromFile(localImagem).Width;
        }

        public static string GerarDataCriacao(string localImagem)
        {
            FileInfo imagem = new FileInfo(localImagem);
            string formatoData = "{0}/{1}/{2} {3}:{4}:{5}";

            return string.Format(formatoData,
                imagem.CreationTime.Day, imagem.CreationTime.Month,
                imagem.CreationTime.Year, imagem.CreationTime.Hour,
                imagem.CreationTime.Minute, imagem.CreationTime.Second);
        }
    }
}
