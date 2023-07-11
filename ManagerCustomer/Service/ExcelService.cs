using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using ManagerCustomer.Entity;
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

        public void addToExcel(List<Customer> customers)
        {
            using (XLWorkbook workbook = new XLWorkbook(GlobalStrings.FILE_EXCEL_NAME))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                int lastRow = worksheet.LastRowUsed()?.RowNumber() ?? 1;
                int rowIndex = lastRow + 1;
                foreach (Customer o in customers)
                {
                    worksheet.Cell(rowIndex, 1).Value = o.id.ToString();
                    worksheet.Cell(rowIndex, 2).Value = o.phone;
                    rowIndex++;
                }
                workbook.SaveAs(GlobalStrings.FILE_EXCEL_NAME);
            }
        }

        public List<Customer> readFromExcel()
        {
            List<Customer> list = new List<Customer>();
            using (XLWorkbook workbook = new XLWorkbook(GlobalStrings.FILE_EXCEL_NAME))
            {
                IXLWorksheet worksheet = workbook.Worksheet(1);
                var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header row
                foreach (var row in rows)
                {
                    //var rowNumber = row.RowNumber();
                    var idStr = row.Cell(1).Value.GetText();
                    Guid.TryParse(idStr, out Guid guid);
                    var d = row.Cell(10).GetValue<string>();
                    Customer c = new Customer()
                    {
                        id = guid,
                        fullName = row.Cell(2).GetValue<string>(),
                        phone = row.Cell(3).GetValue<string>(),
                        address = row.Cell(4).GetValue<string>(),
                        totalPrice = row.Cell(5).GetValue<double>(),
                        machineRecordL = row.Cell(6).GetValue<string>(),
                        machineRecordR = row.Cell(7).GetValue<string>(),
                        realRecordL = row.Cell(8).GetValue<string>(),
                        realRecordR = row.Cell(9).GetValue<string>(),
                        recordDate = DateTime.Parse(d),
                        note = row.Cell(11).GetValue<string>(),
                    };
                    list.Add(c);
                }
            }
            return list;
        }
    }
}
