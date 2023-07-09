using ManagerCustomer.Entity;
using System.Windows.Forms;

namespace ManagerCustomer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new List<Customer>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new Customer
                {
                    id = Guid.NewGuid(),
                    fullName = "thanh ne " + i,
                    address = "",
                    recordDate = DateTime.Now,
                    phone = "",
                    note = "",
                });
            }
            dtView.DataSource = list;
        }
    }
}