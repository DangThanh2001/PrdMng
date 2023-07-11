using ManagerCustomer.Entity;
using ManagerCustomer.Service;
using System.Net;
using System.Windows.Forms;

namespace ManagerCustomer
{
    public partial class Form1 : Form
    {
        ExcelService excelService;
        List<Customer> list;

        public Form1()
        {
            InitializeComponent();
            excelService = new ExcelService();
        }

        private void loadData()
        {
            dtView.DataSource = excelService.readFromExcel();
            list = excelService.readFromExcel();
            dtView.Columns["recordDate"].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!excelService.checkFileExist())
            {
                excelService.createExcel();
            }
            loadData();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            var search = tbSearch.Text.Trim().ToLower();
            var rs = excelService.readFromExcel();
            if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
            {
                rs = list.Where(x =>
                x.fullName.ToLower().Contains(search) ||
                x.phone.ToLower().Contains(search) ||
                x.address.ToLower().Contains(search) ||
                x.note.ToLower().Contains(search)
                ).ToList();
            }
            if (cbDate.Checked)
            {
                rs = rs.Where(x =>
                    x.recordDate.Date >= fromDate.Value.Date &&
                    x.recordDate.Date <= toDate.Value.Date
                    ).ToList();
            }
            dtView.DataSource = rs;
        }
    }
}