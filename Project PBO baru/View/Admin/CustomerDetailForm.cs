using Project_PBO_baru.Models;
using System;
using System.Windows.Forms;

namespace Project_PBO_baru.View.Admin
{
    public partial class CustomerDetailForm : Form
    {
        private User _customer;

        public CustomerDetailForm(User customer)
        {
            InitializeComponent();
            _customer = customer;
        }

        private void CustomerDetailForm_Load(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                TxtUsername.Text = _customer.Username;
                TxtNamaUser.Text = _customer.NamaUser;
                TxtNoHp.Text = _customer.NoHp.ToString();
                // Do not display internal id or password to admin per requirements
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
