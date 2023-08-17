using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Core.Utilities
{
    public static class ExcelExportUtility
    {
        public static byte[] ExportToExcel<T>(List<T> objectList) where T : class
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Get the properties of the object type T
                PropertyInfo[] properties = typeof(T).GetProperties();

                // Set the headers
                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }


                // Populate the data
                for (int row = 0; row < objectList.Count; row++)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(objectList[row]);
                    }
                }

                // Auto-fit columns for better display
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Convert the Excel package to a byte array
                byte[] fileContents = package.GetAsByteArray();

                return fileContents;
            }
        }


    }
}
