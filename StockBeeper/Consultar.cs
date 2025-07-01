using ClosedXML.Excel;
using StockBeeper.Configuration;
using StockBeeper.Services;
using StockBeeper.Validator;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StockBeeper
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private readonly string _filePath = FileConfig.FilePath;

        private void button1_Click(object sender, EventArgs e)
        {
            if (CodeValidator.Valid(txtCodigo.Text) == true) { 

            var service = new ProductSearchService(_filePath);
            var result = service.Search(txtCodigo.Text);

            if (result == null)
            {
                MessageBox.Show("Código não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataGridViewConsulta.DataSource = result;
            }
        }
    }
}
