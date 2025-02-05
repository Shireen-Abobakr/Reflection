using OfficeOpenXml;
using Reflection;
using System.Collections.Generic;
using System.IO;

public class ExcelReader : IExcelReader
{
    public List<Dictionary<string, string>> ReadExcel(string filePath)
    {
        var result = new List<Dictionary<string, string>>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];  // Assuming data is on the first sheet.
            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;

            for (int row = 2; row <= rowCount; row++) // Skipping the header row
            {
                var rowData = new Dictionary<string, string>();
                for (int col = 1; col <= colCount; col++)
                {
                    string key = worksheet.Cells[1, col].Text; // The first row as column names
                    string value = worksheet.Cells[row, col].Text;
                    rowData.Add(key, value);
                }
                result.Add(rowData);
            }
        }

        return result;
    }
}