using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockBeeper
{
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Por favor, preencha o campo código.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = @"Local do arquivo .xlsx";

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("O arquivo de registros não foi encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string codigoConsulta = txtCodigo.Text;

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("Registro");

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("Código");
                    dataTable.Columns.Add("Nome");
                    dataTable.Columns.Add("Distribuidora");
                    dataTable.Columns.Add("Data");

                    var rows = worksheet.RowsUsed().Where(row => row.Cell(1).GetString() == codigoConsulta);

                    if (rows.Any())
                    {
                        foreach (var row in rows)
                        {
                            dataTable.Rows.Add(
                                row.Cell(1).GetString(),
                                row.Cell(2).GetString(),
                                row.Cell(3).GetString(),
                                row.Cell(4).GetString()
                            );
                        }

                        dataGridViewConsulta.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Código não encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show($"Erro ao consultar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
