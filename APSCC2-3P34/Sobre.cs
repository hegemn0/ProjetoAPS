using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenador
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void Sobre_Load(object sender, EventArgs e)
        {
            //LLB_CodigoFonte.Link = new LinkLabel();

            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "";
        }
    }
}
