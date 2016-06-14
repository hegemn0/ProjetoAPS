using System;
using System.Collections.Generic;

namespace Ordenador
{
    public class ListaImagens : List<Imagem>, IDisposable
    {
        private bool disposed;

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
