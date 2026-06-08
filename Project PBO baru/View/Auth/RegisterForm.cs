using Npgsql;
using Project_PBO_baru.Database;
using Project_PBO_baru.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_PBO_baru.View.Auth
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void BTNDAFTAR_Click_1(object sender, EventArgs e)
        {
            try
            {

                int noHp;

                if (!int.TryParse(textBox3.Text.Trim(), out noHp))
                {
                    MessageBox.Show("Nomor HP harus berupa angka!");
                    return;
                }

                DBConnection db = new DBConnection();

                using (NpgsqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    string query = @"

                        INSERT INTO ""user""
                        (
                            username,
                            nama_user,
                            no_hp,
                            password
                        )
                        VALUES
                        (
                            @username,
                            @nama,
                            @nohp,
                            @password
                        )";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@nama",
                            textBox1.Text.Trim());

                        cmd.Parameters.AddWithValue("@nohp", Convert.ToInt32(textBox3.Text));

                        cmd.Parameters.AddWithValue(
                            "@username",
                            textBox4.Text.Trim());

                        cmd.Parameters.AddWithValue(
                            "@password",
                            textBox5.Text.Trim());

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Registrasi berhasil!");

                        LoginForm login = new LoginForm();
                        login.Show();

                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error : " + ex.Message);
            }
        }
    }
    
}
