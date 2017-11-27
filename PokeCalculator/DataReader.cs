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
        Excel.Application excel;

        public DataReader(string path) {
            excel = new Excel.Application();
            wb = excel.Workbooks.Open(path, Password:"517672205", WriteResPassword:"517672205");
        }

        public String[,] dataSheet(int sheet) {
            Excel.Worksheet ws = wb.Worksheets[sheet];
            int nrow = ws.UsedRange.Rows.Count;
            int ncol = ws.UsedRange.Columns.Count;
            String[,] dataTable = new String[nrow, ncol];
            object[,] objectTable = ws.UsedRange.Value2;
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    if (objectTable[i + 1, j + 1] != null)
                    {
                        dataTable[i, j] = objectTable[i + 1, j + 1].ToString().Trim();
                    }
                    else
                    {
                        dataTable[i, j] = "";
                    }
                }
            }
            return dataTable;
        }

        ~DataReader() {
            excel.Workbooks.Close();
        }
    }
}
