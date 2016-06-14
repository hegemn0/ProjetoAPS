using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSCC2_3P34
{
    public class Imagem : IDisposable
    {
        bool disposed;

        public string Id { get; set; }
        public byte[] IMG { get; set; }
        public string Nome { get; set; }
        public string Formato { get; set; }
        public int Tamanho { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public string DataCriacao { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {   
                }
            }

            disposed = true;
        }
    }
}
