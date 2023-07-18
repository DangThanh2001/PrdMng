using ManagerCustomer.Service;

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
