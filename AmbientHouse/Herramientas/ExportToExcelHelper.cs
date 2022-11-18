using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using DbEntidades.Entities;
using DbEntidades.Operators;

namespace AmbientHouse.Herramientas
{
    public static class ExportToExcelHelper
    {
        public static Stream UpdateDataIntoExcelTemplate(List<Items> cList, FileInfo path)
        {
            Stream stream = new MemoryStream();
            if (path.Exists)
            {
                using (ExcelPackage p = new ExcelPackage(path))
                {
                    ExcelWorksheet comandaXLS = p.Workbook.Worksheets["Comanda"];
                    comandaXLS.Cells["B5:E8"].Value = cList.Count;
                    p.SaveAs(stream);
                    stream.Position = 0;
                }
            }
            return stream;
        }
    }

}