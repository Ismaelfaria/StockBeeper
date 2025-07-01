using StockBeeper.Excel;
using System.Linq;
using System.Data;
using StockBeeper.Tables;

namespace StockBeeper.Services
{
    internal class ProductSearchService
    {
        private readonly ExcelReader _excelReader;

        public ProductSearchService(string filePath)
        {
            _excelReader = new ExcelReader(filePath);
        }

        public DataTable Search(string code)
        {
            var rows = _excelReader.ReadRowsByCode("Registro", code);

            if (!rows.Any())
            {
                return null;
            }

            var table = ProductTableBuilder.CreateSchema();
            ProductTableBuilder.Fill(table, rows);
            return table;
        }
    }
}
