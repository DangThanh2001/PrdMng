using ManagerCustomer.Entity;
using ManagerCustomer.Service;
using ManagerCustomer.Ulti;

namespace ManagerCustomer
{
    public partial class UpdateForm : Form
    {
        private ExcelService excelService;
        Customer customer;

        public UpdateForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;
            excelService = new ExcelService();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!Common.winCf())
            {
                return;
            }
            resetData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Common.winCf())
            {
                return;
            }
            try
            {
                if (Common.checkStringsIsNullOrEmpty(
                    new string[]
                    {
                        tbName.Text,
                        tbPhone.Text,
                        tbMachineLeft.Text,
                        tbMachineRight.Text,
                        tbRealLeft.Text,
                        tbRealRight.Text,
                    }
                    ))
                {
                    MessageBox.Show("Hay nhap du cac truong du lieu");
                    return;
                }
                Customer c = new Customer()
                {
                    id = customer.id,
                    fullName = tbName.Text.Trim(),
                    phone = tbPhone.Text.Trim(),
                    address = tbAdd.Text.Trim(),
                    machineRecordL = tbMachineLeft.Text.Trim(),
                    machineRecordR = tbMachineRight.Text.Trim(),
                    realRecordL = tbRealLeft.Text.Trim(),
                    realRecordR = tbRealRight.Text.Trim(),
                    note = rtbNote.Text.Trim(),
                    recordDate = dateCreate.Value,
                };
                excelService.updateCustomer(c);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi xay ra " + ex.Message);
            }
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            tbName.Text = customer.fullName;
            tbPhone.Text = customer.phone;
            tbAdd.Text = customer.address;
            tbMachineLeft.Text = customer.machineRecordL;
            tbMachineRight.Text = customer.machineRecordR;
            tbRealLeft.Text = customer.realRecordL;
            tbRealRight.Text = customer.realRecordR;
            rtbNote.Text = customer.note;
            dateCreate.Value = customer.recordDate;
        }
    }
}
