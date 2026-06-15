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
    public partial class DashboardCustomer : Form
    {
        public DashboardCustomer()
        {
            InitializeComponent();
            // subscribe to room store updates so dashboard shows latest names/prices
            Project_PBO_baru.Models.RoomStore.RoomNameChanged += OnRoomNameChanged;
            Project_PBO_baru.Models.RoomStore.RoomPriceChanged += OnRoomPriceChanged;

            this.Load += (s, e) => {
                NamaKmrCst1.Text = Project_PBO_baru.Models.RoomStore.GetName(1);
                NamaKmrCst2.Text = Project_PBO_baru.Models.RoomStore.GetName(2);
                NamaKmrCst3.Text = Project_PBO_baru.Models.RoomStore.GetName(3);
                NamaKmrCst4.Text = Project_PBO_baru.Models.RoomStore.GetName(4);
                HargaKmrCst1.Text = Project_PBO_baru.Models.RoomStore.GetPrice(1);
                HargaKmrCst2.Text = Project_PBO_baru.Models.RoomStore.GetPrice(2);
                HargaKmrCst3.Text = Project_PBO_baru.Models.RoomStore.GetPrice(3);
                HargaKmrCst4.Text = Project_PBO_baru.Models.RoomStore.GetPrice(4);
            };

            this.FormClosed += (s, e) => {
                Project_PBO_baru.Models.RoomStore.RoomNameChanged -= OnRoomNameChanged;
                Project_PBO_baru.Models.RoomStore.RoomPriceChanged -= OnRoomPriceChanged;
            };
        }


        private void BtnDaftarKmrCst_Click(object sender, EventArgs e)
        {
            DaftarKamarCustomer daftarKamarForm = new DaftarKamarCustomer();

            daftarKamarForm.Show();

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

        private void Btn_logoutcst_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();

            this.Hide();
        }

        private void BtnPesan1_Click(object sender, EventArgs e)
        {
            var reservasi = new ReservasiForm();
            reservasi.SelectedRoomNumber = NamaKmrCst1.Text;
            reservasi.SelectedRoomPrice = HargaKmrCst1.Text;
            reservasi.Show();
            this.Hide();
        }

        private void BtnPesan3_Click(object sender, EventArgs e)
        {
            var reservasi = new ReservasiForm();
            reservasi.SelectedRoomNumber = NamaKmrCst3.Text;
            reservasi.SelectedRoomPrice = HargaKmrCst3.Text;
            reservasi.Show();
            this.Hide();
        }

        private void BtnPesan2_Click(object sender, EventArgs e)
        {
            var reservasi = new ReservasiForm();
            reservasi.SelectedRoomNumber = NamaKmrCst2.Text;
            reservasi.SelectedRoomPrice = HargaKmrCst2.Text;
            reservasi.Show();
            this.Hide();
        }

        private void BtnPesan4_Click(object sender, EventArgs e)
        {
            var reservasi = new ReservasiForm();
            reservasi.SelectedRoomNumber = NamaKmrCst4.Text;
            reservasi.SelectedRoomPrice = HargaKmrCst4.Text;
            reservasi.Show();
            this.Hide();
        }

        private void LabelBerandaCst_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
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
                case 1: NamaKmrCst1.Text = newName; break;
                case 2: NamaKmrCst2.Text = newName; break;
                case 3: NamaKmrCst3.Text = newName; break;
                case 4: NamaKmrCst4.Text = newName; break;
            }
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
                case 1: HargaKmrCst1.Text = newPrice; break;
                case 2: HargaKmrCst2.Text = newPrice; break;
                case 3: HargaKmrCst3.Text = newPrice; break;
                case 4: HargaKmrCst4.Text = newPrice; break;
            }
        }
    }
}
