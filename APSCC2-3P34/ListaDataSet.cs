using System;
using System.Collections.Generic;
using System.Data;

namespace APSCC2_3P34
{
    public class ListaDataSet : List<DataSet>, IDisposable
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