using Project_PBO_baru.Models;
using Project_PBO_baru.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_PBO_baru.View.Admin
{
    public class ReservationDetailForm : Form
    {
        private readonly Reservation _reservation;
        private readonly bool _isEditable;

        private TextBox TxtReservationId;
        private TextBox TxtUsername;
        private TextBox TxtUserId;
        private TextBox TxtRoom;
        private TextBox TxtRoomStatus;
        private TextBox TxtCheckIn;
        private TextBox TxtCheckOut;
        private TextBox TxtNights;
        private TextBox TxtTotal;
        private TextBox TxtStatus;

        public ReservationDetailForm(Reservation reservation, bool isEditable = false)
        {
            _reservation = reservation;
            _isEditable = isEditable;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = _isEditable ? "Edit Reservation" : "Reservation Detail";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(420, 380);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            int leftLabel = 12;
            int leftValue = 140;
            int top = 12;
            int vspace = 34;

            void AddField(ref TextBox box, string labelText, string valueText, bool readOnly = true)
            {
                var lbl = new Label() { Left = leftLabel, Top = top + 6, Width = 120, Text = labelText };
                box = new TextBox() { Left = leftValue, Top = top, Width = 240, ReadOnly = readOnly, Text = valueText };
                this.Controls.Add(lbl);
                this.Controls.Add(box);
                top += vspace;
            }

            if (_reservation != null)
            {
                AddField(ref TxtReservationId, "Reservation ID:", _reservation.Id.ToString(), true);
                AddField(ref TxtUsername, "Username:", _reservation.Username ?? "", true);
                AddField(ref TxtUserId, "User ID:", _reservation.UserId.ToString(), true);
                AddField(ref TxtRoom, "Room:", _reservation.RoomName ?? "", true);
                AddField(ref TxtRoomStatus, "Room Status:", _reservation.RoomStatus ?? "", true);
                AddField(ref TxtCheckIn, "Check-In (yyyy-MM-dd):", _reservation.CheckIn == DateTime.MinValue ? "" : _reservation.CheckIn.ToString("yyyy-MM-dd"), !_isEditable);
                AddField(ref TxtCheckOut, "Check-Out (yyyy-MM-dd):", _reservation.CheckOut == DateTime.MinValue ? "" : _reservation.CheckOut.ToString("yyyy-MM-dd"), !_isEditable);
                AddField(ref TxtNights, "Nights:", _reservation.Nights.ToString(), true);
                AddField(ref TxtTotal, "Total:", _reservation.Price.ToString("C"), true);
                AddField(ref TxtStatus, "Status:", _reservation.Status ?? "", true);
            }

            Button btnSave = null;
            if (_isEditable)
            {
                btnSave = new Button() { Text = "Save", Width = 80, Height = 28, Left = leftValue, Top = top + 8 };
                btnSave.Click += BtnSave_Click;
                this.Controls.Add(btnSave);
            }

            var btnClose = new Button() { Text = _isEditable ? "Close" : "Close", Width = 80, Height = 28, Left = _isEditable ? leftValue + 100 : (this.ClientSize.Width - 80) / 2, Top = top + 8, Anchor = AnchorStyles.Bottom };
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate and save changes (only dates are editable)
            DateTime ci, co;
            if (!DateTime.TryParse(TxtCheckIn.Text, out ci) || !DateTime.TryParse(TxtCheckOut.Text, out co))
            {
                MessageBox.Show("Invalid date format. Use yyyy-MM-dd.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (co <= ci)
            {
                MessageBox.Show("Check-out must be after check-in.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Attempt update via service
            if (ReservationService.UpdateReservationDates(_reservation.Id, ci, co))
            {
                MessageBox.Show("Reservation updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update reservation. Room may not be available for the selected dates.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
