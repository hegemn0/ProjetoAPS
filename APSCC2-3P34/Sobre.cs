using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "https://github.com/hegemn0/ProjetoAPS";
            LLB_CodigoFonte.Links.Add(link);
        }

        private void LLB_CodigoFonte_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
