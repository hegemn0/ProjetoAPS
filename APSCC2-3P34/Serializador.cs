using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenador
{
    public static class Serializador
    {
        public static void Serializar<T>(string localProjeto, T objeto, bool apendice = false)
        {
            using (Stream stream = File.Open(localProjeto, apendice ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objeto);
            }
        }

        public static T Deserializar<T>(string localProjeto)
        {
            using (Stream stream = File.Open(localProjeto, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
    }
}
