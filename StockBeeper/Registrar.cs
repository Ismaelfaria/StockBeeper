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
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtDestribuidora.Text) ||
                txtData == null)
            {
                MessageBox.Show("Por favor, preencha todos os campos antes de registrar.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string filePath = @"Local do arquivo .xlsx";

            try
            {
                bool fileExists = File.Exists(filePath);

                using (var workbook = fileExists ? new XLWorkbook(filePath) : new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.FirstOrDefault(w => w.Name == "Registro") ?? workbook.Worksheets.Add("Registro");

                    if (!fileExists)
                    {
                        worksheet.Cell(1, 1).Value = "Código";
                        worksheet.Cell(1, 2).Value = "Nome";
                        worksheet.Cell(1, 3).Value = "Distribuidora";
                        worksheet.Cell(1, 4).Value = "Data";
                    }

                    var lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1;
                    var nextRow = lastRow + 1;

                    worksheet.Cell(nextRow, 1).Value = txtCodigo.Text;
                    worksheet.Cell(nextRow, 2).Value = txtNome.Text;
                    worksheet.Cell(nextRow, 3).Value = txtDestribuidora.Text;
                    worksheet.Cell(nextRow, 4).Value = txtData.Value.ToString("dd/MM/yyyy");

                    workbook.SaveAs(filePath);
                    MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar os dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
