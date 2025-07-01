using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace StockBeeper.Excel
{
    internal class ExcelReader
    {
        private readonly string _filePath;

        public ExcelReader(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<IXLRow> ReadRowsByCode(string worksheetName, string code)
        {
            using (var workbook = new XLWorkbook(_filePath))
            {
                var worksheet = workbook.Worksheet(worksheetName);
                return worksheet.RowsUsed().Where(row => row.Cell(1).GetString() == code).ToList();
            }
        }
    }
}
