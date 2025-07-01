using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;

namespace StockBeeper.Tables
{
    internal static class ProductTableBuilder
    {
        public static DataTable CreateSchema()
        {
            var table = new DataTable();
            table.Columns.Add("Code");
            table.Columns.Add("Name");
            table.Columns.Add("Distributor");
            table.Columns.Add("Date");
            return table;
        }

        public static void Fill(DataTable table, IEnumerable<IXLRow> rows)
        {
            foreach (var row in rows)
            {
                table.Rows.Add(
                    row.Cell(1).GetString(),
                    row.Cell(2).GetString(),
                    row.Cell(3).GetString(),
                    row.Cell(4).GetString()
                );
            }
        }
    }
}
