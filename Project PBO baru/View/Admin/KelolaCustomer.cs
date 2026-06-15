using Project_PBO_baru.View.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_PBO_baru.View.Admin
{
    public partial class KelolaCustomer : Form
    {
        public KelolaCustomer()
        {
            InitializeComponent();
            this.Load += KelolaCustomer_Load;
        }

        private System.Windows.Forms.DataGridView DgvCustomers;
        private System.Windows.Forms.Label LblNoUsers;

        private void KelolaCustomer_Load(object sender, EventArgs e)
        {
            // create DataGridView dynamically
            DgvCustomers = new System.Windows.Forms.DataGridView();
            DgvCustomers.Left = 160;
            DgvCustomers.Top = 20;
            DgvCustomers.Width = 420;
            DgvCustomers.Height = 320;
            DgvCustomers.ReadOnly = false;
            DgvCustomers.AllowUserToAddRows = false;
            DgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvCustomers.CellDoubleClick += DgvCustomers_CellDoubleClick;
            DgvCustomers.CellContentClick += DgvCustomers_CellContentClick;
            this.Controls.Add(DgvCustomers);

            // label shown when no users found
            LblNoUsers = new Label() { Left = 160, Top = 60, Width = 300, Height = 24, Text = "No users found", ForeColor = Color.Red, Visible = false };
            this.Controls.Add(LblNoUsers);

            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                var users = Project_PBO_baru.Services.UserService.GetAllUsers();
                var dgv = DgvCustomers;
                dgv.Columns.Clear();
                dgv.Rows.Clear();
                dgv.Columns.Add("Id", "ID");
                dgv.Columns["Id"].Visible = false; // hide internal id
                dgv.Columns.Add("Username", "Username");
                dgv.Columns.Add("Nama", "Nama");
                dgv.Columns.Add("NoHp", "No HP");

                var deleteCol = new DataGridViewButtonColumn();
                deleteCol.Name = "DeleteBtn";
                deleteCol.HeaderText = "Action";
                deleteCol.Text = "Delete";
                deleteCol.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(deleteCol);

                if (users.Count == 0)
                {
                    dgv.Visible = false;
                    LblNoUsers.Visible = true;
                }
                else
                {
                    LblNoUsers.Visible = false;
                    dgv.Visible = true;
                    foreach (var u in users)
                    {
                        dgv.Rows.Add(u.IdUser, u.Username, u.NamaUser, u.NoHp.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("KelolaCustomer.LoadCustomers error: " + ex);
            }
        }

        private void DgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            try
            {
                var row = DgvCustomers.Rows[e.RowIndex];
                string username = row.Cells["Username"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(username))
                {
                    var customer = Project_PBO_baru.Services.UserService.GetUserByUsername(username);
                    if (customer != null)
                    {
                        var detail = new CustomerDetailForm(customer);
                        detail.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DgvCustomers_CellDoubleClick error: " + ex);
            }
        }

        private void DgvCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var dgv = DgvCustomers;
            try
            {
                var colName = dgv.Columns[e.ColumnIndex].Name;
                if (colName == "DeleteBtn")
                {
                    var row = dgv.Rows[e.RowIndex];
                    int userId = Convert.ToInt32(row.Cells["Id"].Value ?? 0);
                    var username = row.Cells["Username"].Value?.ToString() ?? "";
                    var res = MessageBox.Show($"Are you sure you want to delete user '{username}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        // Prevent deletion if user has reservations or transactions
                        if (Project_PBO_baru.Services.UserService.UserHasActivity(userId))
                        {
                            MessageBox.Show("Cannot delete user because they have reservations or transactions.", "Action denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (Project_PBO_baru.Services.UserService.DeleteUser(userId))
                            {
                                MessageBox.Show("User deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadCustomers();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DgvCustomers_CellContentClick error: " + ex);
            }
        }


        private void BtnLogoutAdm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void BtnLaporanAdm_Click(object sender, EventArgs e)
        {
            LaporanForm laporanForm = new LaporanForm();
            laporanForm.Show();
            this.Hide();
        }



        private void BtnReservasiAdm_Click(object sender, EventArgs e)
        {
            KelolaReservasiForm kelolaReservasiForm = new KelolaReservasiForm();
            kelolaReservasiForm.Show();
            this.Hide();
        }

        private void BtnJenisKamarAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnDataKamarAdm_Click(object sender, EventArgs e)
        {
            KelolaKamarForm kelolaKamarForm = new KelolaKamarForm();
            kelolaKamarForm.Show();
            this.Hide();
        }

        private void LabelDataUserAdm_Click(object sender, EventArgs e)
        {
            KelolaCustomer kelolaCustomer = new KelolaCustomer ();
            kelolaCustomer.Show();
            this.Hide();
        }

        private void BtnDashboardBtn_Click(object sender, EventArgs e)
        {
            DashboardAdmincs dashboardAdmincs = new DashboardAdmincs ();
            dashboardAdmincs.Show();
            this.Hide();
        }
    }
}
