using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockBeeper
{
    public partial class ALSEG : Form
    {
        public ALSEG()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Registrar_Click(object sender, EventArgs e)
        {
            Registrar reg = new Registrar();
            reg.Show();
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            Consultar con = new Consultar();
            con.Show();
        }
    }
}
