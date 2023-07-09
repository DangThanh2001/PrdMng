using ClosedXML.Excel;
using ManagerCustomer.Ulti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomer.Service
{
    internal class ExcelService
    {
        public void createExcel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[11] {
                new DataColumn("id"),
                new DataColumn("fullName"),
                new DataColumn("phone"),
                new DataColumn("address"),
                new DataColumn("totalPrice"),
                new DataColumn("machineRecordL"),
                new DataColumn("machineRecordR"),
                new DataColumn("realRecordL"),
                new DataColumn("realRecordR"),
                new DataColumn("recordDate"),
                new DataColumn("note")
            });

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.AddWorksheet(dt);
                wb.SaveAs(GlobalStrings.FILE_EXCEL_NAME);
            }
        }

        public bool checkFileExist()
        {
            return File.Exists(GlobalStrings.FILE_EXCEL_NAME);
        }
    }
}
