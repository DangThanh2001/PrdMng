using ManagerCustomer.Service;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //ExcelService excelService = new ExcelService();
            //if (!excelService.checkFileExist())
            //    excelService.createExcel();
            if (LoginService.Login(tbUserName.Text, tbPassword.Text))
            {
                Hide();
                Form1 form = new Form1();
                form.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công", "ERROR");
            }
        }
    }
}
