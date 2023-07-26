using ManagerCustomer.Entity;
using ManagerCustomer.Service;
using ManagerCustomer.Ulti;

namespace ManagerCustomer
{
    public partial class Form1 : Form
    {
        ExcelService excelService;
        List<Customer> list;
        List<Customer> resultSearchList;
        Customer customer;
        int numsPerPage;
        int maxPage;
        int curPage;
        bool isSearch;

        public Form1()
        {
            InitializeComponent();
            excelService = new ExcelService();
            numsPerPage = int.Parse(Common.getDataInSetting("maxCusPerPage"));
            curPage = 0;
            isSearch = false;
        }

        private void loadData()
        {
            list = excelService.readFromExcel();
            if (resultSearchList == null)
                resultSearchList = new List<Customer>();
            else
                resultSearchList.Clear();
            maxPage = Common.calculateMaxPage(list.Count, numsPerPage);
            dtView.DataSource = list.Skip(0).Take(numsPerPage).ToList();
            dtView.Columns["recordDate"].Visible = false;
            dtView.ClearSelection();
            lbPage.Text = $"{curPage + 1}/{maxPage}";
            isSearch = false;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            var search = tbSearch.Text.Trim().ToLower();
            resultSearchList = list;
            isSearch = !(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search))
                || cbDate.Checked
                ? true : false;
            if (!(string.IsNullOrEmpty(search) || string.IsNullOrWhiteSpace(search)))
            {
                resultSearchList = list.Where(x =>
                x.id.ToString().ToLower().Contains(search) ||
                x.fullName.ToLower().Contains(search) ||
                (x.phone != null && x.phone.ToLower().Contains(search))
                ).ToList();
            }
            if (cbDate.Checked)
            {
                resultSearchList = resultSearchList.Where(x =>
                    x.recordDate.Date >= fromDate.Value.Date &&
                    x.recordDate.Date <= toDate.Value.Date
                    ).ToList();
            }
            dtView.DataSource = resultSearchList;
            maxPage = Common.calculateMaxPage(resultSearchList.Count, numsPerPage);
            curPage = 0;
            lbPage.Text = $"{curPage + 1}/{maxPage}";
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
            if (customer == null)
            {
                return;
            }
            UpdateForm updateForm = new UpdateForm(customer);
            updateForm.Show();
            updateForm.FormClosed += new FormClosedEventHandler(Form_Closed_Update);
            tbSearch.Text = customer.id + "";
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

        private void Form_Closed_Update(object? sender, FormClosedEventArgs e)
        {
            Form1_Load(sender, e);
            search();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Form1_Load(sender, e);
            tbSearch.Text = "";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (curPage == (maxPage - 1)) return;
            curPage++;
            lbPage.Text = $"{curPage + 1}/{maxPage}";
            var dummyList = isSearch ? resultSearchList : list;
            dtView.DataSource = dummyList.Skip(curPage * numsPerPage)
                .Take(numsPerPage).ToList();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (curPage <= 0) return;
            curPage--;
            var dummyList = isSearch ? resultSearchList : list;
            lbPage.Text = $"{curPage + 1}/{maxPage}";
            dtView.DataSource = dummyList.Skip(curPage * numsPerPage)
                .Take(numsPerPage).ToList();
        }
    }
}