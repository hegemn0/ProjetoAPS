using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APSCC2_3P34
{
    [Serializable]
    public class Configuracoes
    {
        public string Nome { get; set; }
        public string DiretorioProjeto { get; set; }
        public string Local { get; set; }
        public string DiretorioBancoDeDados { get; set; }

        public StringCollection BancoDeDados { get; set; }
        public StringCollection BancoDeDadosConnectionString { get; set; }
    }
}

