using Npgsql;
using Project_PBO_baru.Database;
using Project_PBO_baru.View.Customer;
using Project_PBO_baru.View.Admin;
using Project_PBO_baru.Models;
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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            // Tempat event handler username jika diperlukan
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            // Tempat event handler password jika diperlukan
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Mengatur default role agar tidak kosong saat login pertama kali klik
            RadioBtnAdm.Checked = true; // Default pilih Admin
        }

        private void RadopBtnAdm(object sender, EventArgs e)
        {
            // Event handler Radio Button Owner/Customer
        }

        private void RadioBtnCust(object sender, EventArgs e)
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
                            username,
                            nama_user,
                            no_hp,
                            role_user_id
                        FROM ""user""
                        WHERE username = @username
                          AND password = @password";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", TextBox2.Text.Trim());
                        //cmd.Parameters.AddWithValue("@role", roleDipilih);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idUser = reader.GetInt32(reader.GetOrdinal("id_user"));
                                string username = reader.GetString(reader.GetOrdinal("username"));
                                string nama = reader.IsDBNull(reader.GetOrdinal("nama_user")) ? "" : reader.GetString(reader.GetOrdinal("nama_user"));
                                // Read columns as string first to avoid casting errors if DB uses varchar
                                int noHp = 0;
                                int role = 2; // default to customer

                                if (!reader.IsDBNull(reader.GetOrdinal("no_hp")))
                                {
                                    var noHpObj = reader.GetValue(reader.GetOrdinal("no_hp"));
                                    int.TryParse(noHpObj?.ToString(), out noHp);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("role_user_id")))
                                {
                                    var roleObj = reader.GetValue(reader.GetOrdinal("role_user_id"));
                                    int.TryParse(roleObj?.ToString(), out role);
                                }

                                // Periksa role yang dipilih lewat RadioButton
                                int selectedRole = RadioBtnAdm.Checked ? 1 : 2;

                                if (role != selectedRole)
                                {
                                    MessageBox.Show(
                                        "Role yang dipilih tidak sesuai dengan akun. Silakan pilih role yang benar.",
                                        "Peringatan",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return;
                                }

                                // Buat objek user sesuai role dan simpan di session
                                if (role == 1)
                                {
                                    Project_PBO_baru.Models.Admin admin = new Project_PBO_baru.Models.Admin
                                    {
                                        IdUser = idUser,
                                        Username = username,
                                        NamaUser = nama,
                                        NoHp = noHp,
                                        RoleUserId = role
                                    };

                                    UserSession.CurrentUser = admin;

                                    MessageBox.Show("Login Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Hide();
                                    DashboardAdmincs dashboard = new DashboardAdmincs();
                                    dashboard.Show();
                                }
                                else
                                {
                                    Project_PBO_baru.Models.Customer customer = new Project_PBO_baru.Models.Customer
                                    {
                                        IdUser = idUser,
                                        Username = username,
                                        NamaUser = nama,
                                        NoHp = noHp,
                                        RoleUserId = role
                                    };

                                    UserSession.CurrentUser = customer;

                                    MessageBox.Show("Login Berhasil!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    this.Hide();
                                    DashboardCustomer dashboard = new DashboardCustomer();
                                    dashboard.Show();
                                }

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }
    }
}