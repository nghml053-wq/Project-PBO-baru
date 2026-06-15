using Project_PBO_baru.View.Auth;
using Project_PBO_baru.Services;
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
    public partial class KelolaReservasiForm: Form
    {
        public KelolaReservasiForm()
        {
            InitializeComponent();
            this.Load += KelolaReservasiForm_Load;
            ReservationService.ReservationsChanged += () => { LoadReservations(); };
        }

        private void KelolaReservasiForm_Load(object sender, EventArgs e)
        {
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                var rows = ReservationService.GetAllReservations();
                // prepare grid
                var dgv = this.DgvReservations;
                dgv.Columns.Clear();
                dgv.Rows.Clear();
                dgv.Columns.Add("Id", "ID");
                dgv.Columns.Add("Username", "Username");
                dgv.Columns.Add("Room", "Room");
                dgv.Columns.Add("RoomStatus", "Room Status");
                dgv.Columns.Add("CheckIn", "Check-In");
                dgv.Columns.Add("CheckOut", "Check-Out");
                dgv.Columns.Add("Nights", "Nights");
                dgv.Columns.Add("Price", "Total");
                dgv.Columns.Add("Status", "Reservation Status");

                var cancelBtnColumn = new DataGridViewButtonColumn();
                cancelBtnColumn.Name = "CancelBtn";
                cancelBtnColumn.HeaderText = "Action";
                cancelBtnColumn.Text = "Cancel";
                cancelBtnColumn.UseColumnTextForButtonValue = true;
                // Add Edit button column before Cancel
                var editBtnColumn = new DataGridViewButtonColumn();
                editBtnColumn.Name = "EditBtn";
                editBtnColumn.HeaderText = "Edit";
                editBtnColumn.Text = "Edit";
                editBtnColumn.UseColumnTextForButtonValue = true;
                dgv.Columns.Add(editBtnColumn);
                dgv.Columns.Add(cancelBtnColumn);

                foreach (var r in rows)
                {
                    string roomStatusDisplay = string.IsNullOrEmpty(r.RoomStatus) ? (r.RoomId == 0 ? "Tersedia" : "Booked") : (r.RoomStatus == "dipesan" ? "Booked" : "Tersedia");
                    // Note: include placeholder values for button columns (Edit, Cancel)
                    dgv.Rows.Add(r.Id, r.Username, r.RoomName, roomStatusDisplay, r.CheckIn.ToShortDateString(), r.CheckOut.ToShortDateString(), r.Nights, r.Price.ToString("C"), r.Status, "Edit", "Cancel");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("KelolaReservasiForm.LoadReservations error: " + ex);
            }
        }

        private void BtnDashboardAdm_Click(object sender, EventArgs e)
        {
            DashboardAdmincs dashboardAdmincs = new DashboardAdmincs();
            dashboardAdmincs.Show();
            this.Hide();
        }

        private void BtnDataUserAdm_Click(object sender, EventArgs e)
        {
            KelolaCustomer kelolaCustomer = new KelolaCustomer();
            kelolaCustomer.Show();
            this.Hide();
        }

        private void BtnDataKamarAdm_Click(object sender, EventArgs e)
        {
            KelolaKamarForm kelolaKamarForm = new KelolaKamarForm ();
            kelolaKamarForm.Show();
            this.Hide();
        }

        private void BtnJenisKamarAdm_Click(object sender, EventArgs e)
        {

        }

        private void LabelReservasiAdm_Click(object sender, EventArgs e)
        {

        }



        private void BtnLaporanAdm_Click(object sender, EventArgs e)
        {
            LaporanForm laporanForm = new LaporanForm ();
            laporanForm.Show();
            this.Hide();
        }

        private void BtnLogoutAdm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void BtnSimpanPerubahanAdm_Click(object sender, EventArgs e)
        {

        }

        private void DgvReservations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var dgv = this.DgvReservations;
                var row = dgv.Rows[e.RowIndex];

                // Get data from row
                int reservationId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "0");
                string username = row.Cells["Username"].Value?.ToString() ?? "";

                // Determine which column was double-clicked. If Username column -> open customer detail,
                // otherwise open reservation detail.
                var clickedColumnName = dgv.Columns[e.ColumnIndex].Name;

                if (clickedColumnName == "Username")
                {
                    // Open customer detail form if we have a username
                    if (!string.IsNullOrEmpty(username))
                    {
                        var customer = UserService.GetUserByUsername(username);
                        if (customer != null)
                        {
                            var customerDetailForm = new CustomerDetailForm(customer);
                            customerDetailForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Customer not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    // Open reservation detail for other columns
                    var reservation = ReservationService.GetReservationById(reservationId);
                    if (reservation != null)
                    {
                        var reservationDetailForm = new ReservationDetailForm(reservation);
                        reservationDetailForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DgvReservations_CellDoubleClick error: " + ex);
                MessageBox.Show("Error loading customer details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if Cancel button column clicked
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            try
            {
                var dgv = this.DgvReservations;
                string columnName = dgv.Columns[e.ColumnIndex].Name;

                if (columnName == "CancelBtn")
                {
                    var row = dgv.Rows[e.RowIndex];
                    int reservationId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "0");
                    string status = row.Cells["Status"].Value?.ToString() ?? "";

                    // Prevent canceling already completed or canceled reservations
                    if (status == "dibatalkan" || status == "selesai")
                    {
                        MessageBox.Show($"Cannot cancel a {status} reservation.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    var result = MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        // Note: Admin cancel doesn't require userId ownership check, but we need the reservation owner's user_id
                        // Get it from the database
                        int userId = GetReservationOwnerId(reservationId);
                        if (userId > 0)
                        {
                            if (ReservationService.CancelReservation(reservationId, userId))
                            {
                                MessageBox.Show("Reservation canceled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadReservations();
                            }
                            else
                            {
                                MessageBox.Show("Failed to cancel reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else if (columnName == "EditBtn")
                {
                    var row = dgv.Rows[e.RowIndex];
                    int reservationId = int.Parse(row.Cells["Id"].Value?.ToString() ?? "0");
                    var reservation = ReservationService.GetReservationById(reservationId);
                    if (reservation != null)
                    {
                        var editForm = new ReservationDetailForm(reservation, true);
                        editForm.ShowDialog();
                        // After edit, refresh list
                        LoadReservations();
                    }
                    else
                    {
                        MessageBox.Show("Reservation not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DgvReservations_CellContentClick error: " + ex);
                MessageBox.Show("Error processing action.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetReservationOwnerId(int reservationId)
        {
            try
            {
                var db = new Project_PBO_baru.Database.DBConnection();
                using (var conn = db.GetConnection())
                {
                    conn.Open();
                    using (var cmd = new Npgsql.NpgsqlCommand("SELECT user_id_user FROM reservasi WHERE id_reservasi = @id LIMIT 1", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", reservationId);
                        var obj = cmd.ExecuteScalar();
                        if (obj != null && obj != System.DBNull.Value)
                            return Convert.ToInt32(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetReservationOwnerId error: " + ex);
            }
            return 0;
        }
    }
}
