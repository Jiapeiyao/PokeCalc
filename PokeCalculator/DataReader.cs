using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace PokeCalculator
{
    class DataReader
    {
        Excel.Workbook wb;
        Excel.Worksheet ws;
        //String[,] dataTable;
        public int nrow;
        public int ncol;

        public DataReader(string path, int sheet) {
            Excel.Application excel = new Excel.Application();
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
            nrow = ws.UsedRange.Rows.Count;
            Console.Out.WriteLine(nrow);
            ncol = ws.UsedRange.Columns.Count;
        }

        public string ReadCell(int i, int j) {
            i++;
            j++;
            if (ws.Cells[i, j].Value2 != null) {
                return ws.Cells[i, j].Value2.ToString();
            }
            return "";
        }
    }
}
