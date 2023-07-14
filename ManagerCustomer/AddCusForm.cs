using ManagerCustomer.Entity;
using ManagerCustomer.Service;
using ManagerCustomer.Ulti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerCustomer
{
    public partial class AddCusForm : Form
    {
        ExcelService excelService;

        public AddCusForm()
        {
            InitializeComponent();
            excelService = new ExcelService();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
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
                    id = Guid.NewGuid(),
                    fullName = tbName.Text.Trim(),
                    phone = tbPhone.Text.Trim(),
                    address = tbAdd.Text.Trim(),
                    machineRecordL = tbMachineLeft.Text.Trim(),
                    machineRecordR = tbMachineRight.Text.Trim(),
                    realRecordL = tbRealLeft.Text.Trim(),
                    realRecordR = tbRealRight.Text.Trim(),
                    note = rtbNote.Text.Trim(),
                    recordDate = DateTime.Now,
                };
                excelService.addCustomer(c);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi xay ra " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!Common.winCf())
            {
                return;
            }
            tbName.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbAdd.Text = string.Empty;
            tbMachineLeft.Text = string.Empty;
            tbMachineRight.Text = string.Empty;
            tbRealLeft.Text = string.Empty;
            tbRealRight.Text = string.Empty;
            rtbNote.Text = string.Empty;
        }
    }
}
