using System;
using System.Linq;
using System.Windows.Forms;
using Project_PBO_baru.Services;
using Project_PBO_baru.Models;

namespace Project_PBO_baru.View.Customer
{
    public partial class ReservationHistoryForm : Form
    {
        public ReservationHistoryForm()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadReservations();
            ReservationService.ReservationsChanged += LoadReservations;
            this.FormClosed += (s, e) => ReservationService.ReservationsChanged -= LoadReservations;
        }

        private void LoadReservations()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(LoadReservations));
                return;
            }

            listView1.Items.Clear();
            var user = Project_PBO_baru.Models.UserSession.CurrentUser;
            if (user == null) return;

            var items = ReservationService.GetReservationsByUser(user.IdUser);
            foreach (var r in items)
            {
                var li = new ListViewItem(r.Id.ToString());
                li.SubItems.Add(r.RoomName ?? "");
                li.SubItems.Add(r.CheckIn.ToShortDateString());
                li.SubItems.Add(r.CheckOut.ToShortDateString());
                li.SubItems.Add(r.Price.ToString());
                li.SubItems.Add(r.Status ?? "");
                listView1.Items.Add(li);
            }
        }

        private void BtnKembali_Click(object sender, EventArgs e)
        {
            var dash = new DashboardCustomer();
            dash.Show();
            this.Hide();
        }

        private void BtnBatalkan_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var id = int.Parse(listView1.SelectedItems[0].Text);
            var user = Project_PBO_baru.Models.UserSession.CurrentUser;
            if (user == null) return;
            var ok = ReservationService.CancelReservation(id, user.IdUser);
            if (ok)
            {
                MessageBox.Show("Reservasi dibatalkan");
                LoadReservations();
            }
            else
            {
                MessageBox.Show("Gagal membatalkan reservasi");
            }
        }
    }
}
