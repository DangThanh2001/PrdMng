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
            var search = tbSearch.Text.Trim().ToLower();
            if(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
            {
                loadData();
                return;
            }
            var rs = list.Where(x =>
            x.fullName.ToLower().Contains(search) ||
            x.phone.ToLower().Contains(search) ||
            x.address.ToLower().Contains(search) ||
            x.note.ToLower().Contains(search)
            ).ToList();
            dtView.DataSource = rs;
        }
    }
}