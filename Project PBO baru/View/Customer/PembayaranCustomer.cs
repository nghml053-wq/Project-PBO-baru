using System;
using System.Linq;
using System.Windows.Forms;
using Project_PBO_baru.Models;
using Project_PBO_baru.Services;

namespace Project_PBO_baru.View.Customer
{
    public partial class PembayaranCustomer : Form
    {
        private readonly string _roomNumber;
        private readonly DateTime _checkin;
        private readonly DateTime _checkout;
        private readonly int _jumlahTamu;
        private readonly decimal? _pricePerNight;
        private int _metodeId = 1; // default to 1 (cash)

        public PembayaranCustomer(string roomNumber, DateTime checkin, DateTime checkout, int jumlahTamu)
        {
            InitializeComponent();
            _roomNumber = roomNumber;
            _checkin = checkin;
            _checkout = checkout;
            _jumlahTamu = jumlahTamu;

            this.Load += PembayaranCustomer_Load;
        }

        private void PembayaranCustomer_Load(object sender, EventArgs e)
        {
            LblRoom.Text = _roomNumber;
            LblCheckin.Text = _checkin.ToShortDateString();
            LblCheckout.Text = _checkout.ToShortDateString();
            int nights = Math.Max(1, (int)(_checkout - _checkin).TotalDays);
            LblNights.Text = nights.ToString();

            decimal? price = ReservationService.GetRoomPriceByNumber(_roomNumber);
            if (price.HasValue)
            {
                LblPriceNight.Text = price.Value.ToString("C");
                LblTotal.Text = (price.Value * nights).ToString("C");
            }
            else
            {
                LblPriceNight.Text = "N/A";
                LblTotal.Text = "N/A";
            }

            // find cash method id if exists
            try
            {
                var methods = PaymentService.GetAll();
                var cash = methods?.FirstOrDefault(m => m.Name != null && m.Name.ToLower().Contains("cash"));
                if (cash != null) _metodeId = cash.Id;
            }
            catch { }
        }

        private void BtnBayarCash_Click(object sender, EventArgs e)
        {
            var user = UserSession.CurrentUser;
            if (user == null)
            {
                MessageBox.Show("Silakan login terlebih dahulu.");
                return;
            }

            bool ok = ReservationService.CreateReservationByRoomNumber(user.IdUser, _roomNumber, _checkin, _checkout, _jumlahTamu, _metodeId);
            if (ok)
            {
                MessageBox.Show("Pembayaran diterima dan reservasi dibuat.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var hist = new ReservationHistoryForm();
                hist.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Gagal membuat reservasi. Periksa log Debug untuk detail.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
