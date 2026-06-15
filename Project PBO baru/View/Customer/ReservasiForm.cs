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

namespace Project_PBO_baru.View.Customer
{
    public partial class ReservasiForm : Form
    {
        public string SelectedRoomNumber { get; set; }
        public string SelectedRoomPrice { get; set; }

        private DateTimePicker dtpCheckIn;
        private DateTimePicker dtpCheckOut;
        private NumericUpDown numTamu;
        private Label lblSelectedRoom;
        private Label lblSelectedPrice;
        private ComboBox cbMetode;

        public ReservasiForm()
        {
            InitializeComponent();
            // add simple controls for selecting dates and show selected room
            lblSelectedRoom = new Label() { Left = 200, Top = 100, Width = 300 };
            lblSelectedPrice = new Label() { Left = 200, Top = 125, Width = 300 };
            dtpCheckIn = new DateTimePicker() { Left = 200, Top = 150 };
            dtpCheckOut = new DateTimePicker() { Left = 360, Top = 150 };
            numTamu = new NumericUpDown() { Left = 200, Top = 180, Minimum = 1, Maximum = 10, Value = 1 };
            cbMetode = new ComboBox() { Left = 200, Top = 210, Width = 200 };
            cbMetode.Items.Add("Transfer Bank"); cbMetode.Items.Add("Cash"); cbMetode.Items.Add("QRIS");
            cbMetode.SelectedIndex = 0;
            this.Controls.Add(lblSelectedRoom);
            this.Controls.Add(lblSelectedPrice);
            this.Controls.Add(dtpCheckIn);
            this.Controls.Add(dtpCheckOut);
            this.Controls.Add(numTamu);
            this.Controls.Add(cbMetode);

            this.Load += (s, e) => {
                if (!string.IsNullOrEmpty(SelectedRoomNumber)) lblSelectedRoom.Text = "Kamar: " + SelectedRoomNumber;
                if (!string.IsNullOrEmpty(SelectedRoomPrice)) lblSelectedPrice.Text = "Harga: " + SelectedRoomPrice;
            };
        }

        private void BtnReservasiSekarangCst_Click(object sender, EventArgs e)
        {
            var user = Project_PBO_baru.Models.UserSession.CurrentUser;
            if (user == null)
            {
                MessageBox.Show("Silakan login terlebih dahulu.");
                return;
            }

            DateTime ci = dtpCheckIn.Value.Date;
            DateTime co = dtpCheckOut.Value.Date;
            int tamu = (int)numTamu.Value;
            int metode = cbMetode.SelectedIndex + 1;

            // Navigate to PembayaranCustomer (only cash available there)
            var pembayaran = new PembayaranCustomer(
                SelectedRoomNumber ?? string.Empty,
                ci,
                co,
                tamu);
            pembayaran.Show();
            this.Hide();
        }

        private void BtnBatalkanReservasiCst_Click(object sender, EventArgs e)
        {
            // go back to dashboard
            var dash = new DashboardCustomer();
            dash.Show();
            this.Hide();
        }

        private void BtnRiwayatCst_Click(object sender, EventArgs e)
        {
            var hist = new ReservationHistoryForm();
            hist.Show();
            this.Hide();
        }

        private void BtnLogoutCst_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        private void LabelReservasi_Click(object sender, EventArgs e)
        {

        }

        private void BtnDaftarKamar_Click(object sender, EventArgs e)
        {
            DaftarKamarCustomer daftarKamarForm = new DaftarKamarCustomer();

            daftarKamarForm.Show();

            this.Hide();
        }

        private void BtnBerandaCst_Click(object sender, EventArgs e)
        {
            DashboardCustomer dashboardCustomer = new DashboardCustomer();

            dashboardCustomer.Show();

            this.Hide();
        }
    }
}
