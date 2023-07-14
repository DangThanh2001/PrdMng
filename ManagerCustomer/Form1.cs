using ManagerCustomer.Entity;
using ManagerCustomer.Service;
using ManagerCustomer.Ulti;
using System.Net;
using System.Windows.Forms;

namespace ManagerCustomer
{
    public partial class Form1 : Form
    {
        ExcelService excelService;
        List<Customer> list;
        Customer customer;

        public Form1()
        {
            InitializeComponent();
            excelService = new ExcelService();
        }

        private void loadData()
        {
            dtView.DataSource = excelService.readFromExcel();
            list = excelService.readFromExcel();
            lbCount.Text = "Tong: " + list.Count;
            dtView.Columns["recordDate"].Visible = false;
            dtView.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!excelService.checkFileExist())
            {
                excelService.createExcel();
            }
            loadData();
            customer = null;
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
                x.id.ToString().ToLower().Contains(search) ||
                x.fullName.ToLower().Contains(search) ||
                (x.phone != null && x.phone.ToLower().Contains(search)) ||
                (x.note != null && x.note.ToLower().Contains(search))
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

        private void dtView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            DataGridViewRow row = new DataGridViewRow();
            row = dtView.Rows[e.RowIndex];
            var cusId = Convert.ToString(row.Cells[0].Value);
            var isG = Guid.TryParse(cusId, out Guid guid);
            if (isG)
            {
                customer = list.FirstOrDefault(x => x.id == guid);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(customer == null)
            {
                return;
            }
            UpdateForm updateForm = new UpdateForm(customer);
            updateForm.Show();
            updateForm.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (customer == null) return;
            try
            {
                if (Common.winCf("Chac chan xoa ?"))
                {
                    excelService.removeCustomer(customer);
                    MessageBox.Show("OK");
                    loadData();
                    customer = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCusForm addCusForm = new AddCusForm();
            addCusForm.Show();
            addCusForm.FormClosed += new FormClosedEventHandler(Form_Closed);
        }

        private void Form_Closed(object? sender, FormClosedEventArgs e)
        {
            Form1_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
        }
    }
}