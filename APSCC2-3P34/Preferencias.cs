using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APSCC2_3P34
{
    public partial class Preferencias : Form
    {
        public Preferencias()
        {
            InitializeComponent();
        }

        private void Preferencias_Load(object sender, EventArgs e)
        {
            DGV_MenuPreferencias.Rows.Add("Local");
            DGV_MenuPreferencias.Rows.Add("Imagens");
            DGV_MenuPreferencias.Rows.Add("Mapa");
            DGV_MenuPreferencias.Rows.Add("Sobre");

        }
    }
}
