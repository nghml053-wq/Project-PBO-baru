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
    public partial class DaftarKamarCustomer : Form
    {
        private readonly Project_PBO_baru.Controllers.ReservationController _reservationController = new Project_PBO_baru.Controllers.ReservationController();
        public DaftarKamarCustomer()
        {
            InitializeComponent();
            // subscribe to room name and price updates
            Project_PBO_baru.Models.RoomStore.RoomNameChanged += OnRoomNameChanged;
            Project_PBO_baru.Models.RoomStore.RoomPriceChanged += OnRoomPriceChanged;
            // set initial values
            this.Load += (s, e) => {
                LblNamaKamar1Cst.Text = Project_PBO_baru.Models.RoomStore.GetName(1);
                LblNamaKamar2Cst.Text = Project_PBO_baru.Models.RoomStore.GetName(2);
                LblNamaKamar3Cst.Text = Project_PBO_baru.Models.RoomStore.GetName(3);
                LblNamaKamar4Cst.Text = Project_PBO_baru.Models.RoomStore.GetName(4);
                LblHargaKamar1Cst.Text = Project_PBO_baru.Models.RoomStore.GetPrice(1);
                LblHargaKamar2Cst.Text = Project_PBO_baru.Models.RoomStore.GetPrice(2);
                LblHargaKamar3Cst.Text = Project_PBO_baru.Models.RoomStore.GetPrice(3);
                LblHargaKamar4Cst.Text = Project_PBO_baru.Models.RoomStore.GetPrice(4);
                // payment method: only Cash for daftar kamar selection UI
                try
                {
                    this.CmbMetode.Items.Clear();
                    this.CmbMetode.Items.Add("Cash");
                    this.CmbMetode.SelectedIndex = 0;
                    this.CmbMetode.Enabled = false; // not editable here
                }
                catch { }
            };
            this.FormClosed += (s, e) => {
                Project_PBO_baru.Models.RoomStore.RoomNameChanged -= OnRoomNameChanged;
                Project_PBO_baru.Models.RoomStore.RoomPriceChanged -= OnRoomPriceChanged;
            };
            // hide date pickers on room listing page (dates selected on ReservasiForm)
            try
            {
                this.DtpCheckin.Visible = false;
                this.DtpCheckout.Visible = false;
            }
            catch { }
            // selected index set after DataSource load
            // Add dynamic rooms panel populated from DB
            this.Load += (s, e) => {
                try
                {
                    LoadRoomsDynamic();
                }
                catch { }
            };
        }

        private FlowLayoutPanel flRooms;

        private void LoadRoomsDynamic()
        {
            // remove/hide static room labels and buttons to avoid overlap
            try
            {
                this.LblNamaKamar1Cst.Visible = false;
                this.LblNamaKamar2Cst.Visible = false;
                this.LblNamaKamar3Cst.Visible = false;
                this.LblNamaKamar4Cst.Visible = false;
                this.LblHargaKamar1Cst.Visible = false;
                this.LblHargaKamar2Cst.Visible = false;
                this.LblHargaKamar3Cst.Visible = false;
                this.LblHargaKamar4Cst.Visible = false;
                this.BtnPesan1.Visible = false;
                this.BtnPesan2.Visible = false;
                this.BtnPesan3.Visible = false;
                this.BtnPesan4.Visible = false;
            }
            catch { }

            if (flRooms != null)
            {
                this.Controls.Remove(flRooms);
                flRooms.Dispose();
            }

            flRooms = new FlowLayoutPanel();
            flRooms.Left = 300;
            flRooms.Top = 100;
            flRooms.Width = 420;
            flRooms.Height = 280;
            flRooms.AutoScroll = true;
            flRooms.FlowDirection = FlowDirection.TopDown;
            flRooms.WrapContents = false;

            var rooms = Project_PBO_baru.Services.RoomService.GetAllRooms();
            foreach (var r in rooms)
            {
                var p = new Panel();
                p.Width = flRooms.ClientSize.Width - 25;
                p.Height = 60;
                p.BorderStyle = BorderStyle.FixedSingle;

                var lblNum = new Label() { Left = 8, Top = 8, Width = 200, Text = r.Number };
                var lblPrice = new Label() { Left = 220, Top = 8, Width = 120, Text = r.Price.ToString("C") };
                var btnPesan = new Button() { Left = p.Width - 90, Top = 16, Width = 80, Text = "PESAN" };
                btnPesan.Click += (s, e) => {
                    var reservasiForm = new Project_PBO_baru.View.Customer.ReservasiForm();
                    reservasiForm.SelectedRoomNumber = r.Number;
                    reservasiForm.SelectedRoomPrice = r.Price.ToString();
                    reservasiForm.Show();
                    this.Hide();
                };

                p.Controls.Add(lblNum);
                p.Controls.Add(lblPrice);
                p.Controls.Add(btnPesan);
                flRooms.Controls.Add(p);
            }

            this.Controls.Add(flRooms);
        }

        private void BtnBerandaCst_Click(object sender, EventArgs e)
        {
            DashboardCustomer dashboardCustomer = new DashboardCustomer();

            dashboardCustomer.Show();

            this.Hide();
        }

        private void BtnRiwayatCst_Click(object sender, EventArgs e)
        {
            var hist = new ReservationHistoryForm();
            hist.Show();
            this.Hide();
        }

        private void BtnReservasiCst_Click(object sender, EventArgs e)
        {
            ReservasiForm reservasiForm = new ReservasiForm();

            reservasiForm.Show();

            this.Hide();
        }

        private void BtnLogoutCst_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        private void BtnPesan1_Click(object sender, EventArgs e)
        {
            // quick pre-diagnostics to force visibility when debugging
            try {
                MessageBox.Show($"Pre-check:\nIsAuth={Project_PBO_baru.Models.UserSession.IsAuthenticated}\nIsCustomer={Project_PBO_baru.Models.UserSession.IsCustomer}\nLbl='{LblNamaKamar1Cst.Text}'", "PreDiagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {}
            // Basic reservation flow: uses current logged-in user and room number shown
            if (!Project_PBO_baru.Models.UserSession.IsAuthenticated || !Project_PBO_baru.Models.UserSession.IsCustomer)
            {
                MessageBox.Show("Silakan login sebagai customer terlebih dahulu.", "Tidak terautentikasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // navigate to ReservasiForm with selected room
            string roomNumber = LblNamaKamar1Cst.Text ?? string.Empty;
            string roomPrice = LblHargaKamar1Cst.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reservasiForm = new ReservasiForm();
            reservasiForm.SelectedRoomNumber = roomNumber;
            reservasiForm.SelectedRoomPrice = roomPrice;
            reservasiForm.Show();
            this.Hide();
        }

        private void BtnPesan2_Click(object sender, EventArgs e)
        {
            // quick pre-diagnostics to force visibility when debugging
            try {
                MessageBox.Show($"Pre-check:\nIsAuth={Project_PBO_baru.Models.UserSession.IsAuthenticated}\nIsCustomer={Project_PBO_baru.Models.UserSession.IsCustomer}\nLbl='{LblNamaKamar2Cst.Text}'", "PreDiagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {}
            string roomNumber = LblNamaKamar2Cst.Text ?? string.Empty;
            string roomPrice = LblHargaKamar2Cst.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reservasiForm = new ReservasiForm();
            reservasiForm.SelectedRoomNumber = roomNumber;
            reservasiForm.SelectedRoomPrice = roomPrice;
            reservasiForm.Show();
            this.Hide();
        }

        private void BtnPesan3_Click(object sender, EventArgs e)
        {
            // quick pre-diagnostics to force visibility when debugging
            try {
                MessageBox.Show($"Pre-check:\nIsAuth={Project_PBO_baru.Models.UserSession.IsAuthenticated}\nIsCustomer={Project_PBO_baru.Models.UserSession.IsCustomer}\nLbl='{LblNamaKamar3Cst.Text}'", "PreDiagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {}
            string roomNumber = LblNamaKamar3Cst.Text ?? string.Empty;
            string roomPrice = LblHargaKamar3Cst.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reservasiForm = new ReservasiForm();
            reservasiForm.SelectedRoomNumber = roomNumber;
            reservasiForm.SelectedRoomPrice = roomPrice;
            reservasiForm.Show();
            this.Hide();
        }

        private void BtnPesan4_Click(object sender, EventArgs e)
        {
            // quick pre-diagnostics to force visibility when debugging
            try {
                MessageBox.Show($"Pre-check:\nIsAuth={Project_PBO_baru.Models.UserSession.IsAuthenticated}\nIsCustomer={Project_PBO_baru.Models.UserSession.IsCustomer}\nLbl='{LblNamaKamar4Cst.Text}'", "PreDiagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch {}
            string roomNumber = LblNamaKamar4Cst.Text ?? string.Empty;
            string roomPrice = LblHargaKamar4Cst.Text ?? string.Empty;
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                MessageBox.Show("Nomor kamar tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var reservasiForm = new ReservasiForm();
            reservasiForm.SelectedRoomNumber = roomNumber;
            reservasiForm.SelectedRoomPrice = roomPrice;
            reservasiForm.Show();
            this.Hide();
        }

        private void DtpCheckin_ValueChanged(object sender, EventArgs e)
        {
            // ensure checkout is at least one day after checkin
            try
            {
                var min = this.DtpCheckin.Value.Date.AddDays(1);
                this.DtpCheckout.MinDate = min;
                if (this.DtpCheckout.Value.Date < min)
                    this.DtpCheckout.Value = min;
            }
            catch
            {
                // ignore
            }
        }

        private void ShowDiagnostics(string roomName, DateTime checkin, DateTime checkout, int userId)
        {
            try
            {
                int? roomId = null;
                try { roomId = Project_PBO_baru.Services.ReservationService.GetRoomIdByNumber(roomName); } catch { }
                decimal? price = null;
                try { price = Project_PBO_baru.Services.ReservationService.GetRoomPriceByNumber(roomName); } catch { }
                bool available = false;
                try { available = roomId.HasValue && Project_PBO_baru.Services.ReservationService.IsRoomAvailable(roomId.Value, checkin, checkout); } catch { }

                string diag = $"Diagnostics:\nroomLabel='{roomName}'\nroomId={(roomId?.ToString() ?? "null")}\nprice={(price.HasValue ? price.Value.ToString("C") : "null")}\navailable={available}\nuserId={userId}\ncheckin={checkin:d}\ncheckout={checkout:d}";
                MessageBox.Show(diag, "Diagnostics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                // ignore diagnostics failures
            }
        }

        private void LblNamaKamar1Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblNamaKamar2Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblNamaKamar3Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblNamaKamar4Cst_Click(object sender, EventArgs e)
        {

        }

        private void OnRoomNameChanged(int index, string newName)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRoomNameChanged(index, newName)));
                return;
            }

            switch (index)
            {
                case 1: LblNamaKamar1Cst.Text = newName; break;
                case 2: LblNamaKamar2Cst.Text = newName; break;
                case 3: LblNamaKamar3Cst.Text = newName; break;
                case 4: LblNamaKamar4Cst.Text = newName; break;
            }
        }

        private void LblHargaKamar1Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblHargaKamar2Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblHargaKamar3Cst_Click(object sender, EventArgs e)
        {

        }

        private void LblHargaKamar4Cst_Click(object sender, EventArgs e)
        {

        }

        private void OnRoomPriceChanged(int index, string newPrice)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => OnRoomPriceChanged(index, newPrice)));
                return;
            }

            switch (index)
            {
                case 1: LblHargaKamar1Cst.Text = newPrice; break;
                case 2: LblHargaKamar2Cst.Text = newPrice; break;
                case 3: LblHargaKamar3Cst.Text = newPrice; break;
                case 4: LblHargaKamar4Cst.Text = newPrice; break;
            }
        }
    }
}
