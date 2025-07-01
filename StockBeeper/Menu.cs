using System;
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
