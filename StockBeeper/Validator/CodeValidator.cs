using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockBeeper.Validator
{
    internal class CodeValidator
    {
        public static bool Valid(string txtCodigo)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo))
            {
                MessageBox.Show("Por favor, preencha o campo código.", "Campo obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
