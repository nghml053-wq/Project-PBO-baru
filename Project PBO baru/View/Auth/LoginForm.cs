using Npgsql;
using Project_PBO_baru.Database;
using Project_PBO_baru.View.Customer;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project_PBO_baru.View.Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Tempat event handler username jika diperlukan
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Tempat event handler password jika diperlukan
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Mengatur default role agar tidak kosong saat login pertama kali klik
            radioButton1.Checked = true; // Default pilih Admin
        }

        private void BTNOWNER_CheckedChanged(object sender, EventArgs e)
        {
            // Event handler Radio Button Owner/Customer
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Event handler Radio Button Admin
        }

        private void BTNLOGIN_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnection db = new DBConnection();

                using (NpgsqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    //string roleDipilih = "";

                    //// Logika penentuan role berdasarkan Radio Button kamu
                    //if (BTNOWNER.Checked)
                    //    roleDipilih = "customer";

                    //if (radioButton1.Checked)
                    //    roleDipilih = "admin";

                    string query = @"
                        SELECT
                            id_user,
                            username
                        FROM ""user""
                        WHERE username = @username
                          AND password = @password";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());
                        //cmd.Parameters.AddWithValue("@role", roleDipilih);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show(
                                    "Login Berhasil!",
                                    "Informasi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                this.Hide();

                                DashboardCustomer dashboard = new DashboardCustomer();
                                dashboard.Show();

                                // Atau jika ingin form login tertutup:
                                // dashboard.Show();
                                // this.Hide();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Username atau Password salah!",
                                    "Peringatan",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BNTSIGNUP_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.Show();

            this.Hide();
        }
    }
}