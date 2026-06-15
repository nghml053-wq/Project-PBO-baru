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
    public partial class KelolaKamarForm : Form
    {
        private System.Collections.Generic.Dictionary<int, (TextBox nameTxt, TextBox priceTxt, Button btnSave, Button btnCancel)> editors
            = new System.Collections.Generic.Dictionary<int, (TextBox, TextBox, Button, Button)>();

        public KelolaKamarForm()
        {
            InitializeComponent();
            // subscribe to room name and price updates so admin view stays in-sync
            Project_PBO_baru.Models.RoomStore.RoomNameChanged += OnRoomNameChanged;
            Project_PBO_baru.Models.RoomStore.RoomPriceChanged += OnRoomPriceChanged;
            this.Load += (s, e) => {
                NamaKamar1.Text = Project_PBO_baru.Models.RoomStore.GetName(1);
                NamaKamar2.Text = Project_PBO_baru.Models.RoomStore.GetName(2);
                NamaKamar3.Text = Project_PBO_baru.Models.RoomStore.GetName(3);
                NamaKamar4.Text = Project_PBO_baru.Models.RoomStore.GetName(4);
                HargaKamar1.Text = Project_PBO_baru.Models.RoomStore.GetPrice(1);
                HargaKamar2.Text = Project_PBO_baru.Models.RoomStore.GetPrice(2);
                HargaKamar3.Text = Project_PBO_baru.Models.RoomStore.GetPrice(3);
                HargaKamar4.Text = Project_PBO_baru.Models.RoomStore.GetPrice(4);
            };
            // make sure to unsubscribe when form closes to avoid leaking static event handlers
            this.FormClosed += (s, e) => {
                Project_PBO_baru.Models.RoomStore.RoomNameChanged -= OnRoomNameChanged;
                Project_PBO_baru.Models.RoomStore.RoomPriceChanged -= OnRoomPriceChanged;
            };
        }

        private Button BtnTambahKamar;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // add a button to allow adding rooms
            try
            {
                BtnTambahKamar = new Button();
                BtnTambahKamar.Text = "Tambah Kamar";
                BtnTambahKamar.Left = this.ClientSize.Width - 140;
                BtnTambahKamar.Top = 20;
                BtnTambahKamar.Width = 120;
                BtnTambahKamar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
                BtnTambahKamar.Click += BtnTambahKamar_Click;
                this.Controls.Add(BtnTambahKamar);
            }
            catch { }
        }

        private void BtnTambahKamar_Click(object sender, EventArgs e)
        {
            using (var dlg = new Form())
            {
                dlg.Text = "Tambah Kamar";
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
                dlg.Width = 400;
                dlg.Height = 180;

                var lblNomor = new Label() { Left = 12, Top = 18, Text = "Nama Kamar:", Width = 100 };
                var txtNomor = new TextBox() { Left = 120, Top = 16, Width = 240 };
                var lblHarga = new Label() { Left = 12, Top = 50, Text = "Harga:", Width = 100 };
                var txtHarga = new TextBox() { Left = 120, Top = 48, Width = 240 };

                var btnOk = new Button() { Text = "Tambah", Left = 120, Top = 84, Width = 80 };
                var btnCancel = new Button() { Text = "Batal", Left = 220, Top = 84, Width = 80 };
                btnCancel.Click += (s, ev) => dlg.Close();
                btnOk.Click += (s, ev) => {
                    var nomor = txtNomor.Text?.Trim() ?? string.Empty;
                    if (string.IsNullOrEmpty(nomor)) { MessageBox.Show("Nomor kamar diperlukan.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    if (!decimal.TryParse(txtHarga.Text?.Trim(), out var harga)) { MessageBox.Show("Harga tidak valid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
                    var ok = Project_PBO_baru.Services.RoomService.CreateRoom(nomor, harga);
                    if (ok)
                    {
                        MessageBox.Show("Kamar berhasil ditambahkan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // notify customers: attempt to update RoomStore if used; also reload UI if desired
                        dlg.Close();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menambahkan kamar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                dlg.Controls.Add(lblNomor);
                dlg.Controls.Add(txtNomor);
                dlg.Controls.Add(lblHarga);
                dlg.Controls.Add(txtHarga);
                dlg.Controls.Add(btnOk);
                dlg.Controls.Add(btnCancel);

                dlg.ShowDialog(this);
            }
        }

        private void BtnDashboardAdm_Click(object sender, EventArgs e)
        {
            var dash = new DashboardAdmincs();
            dash.Show();
            this.Hide();
        }

        private void BtnDataUserAdm_Click(object sender, EventArgs e)
        {
            var cust = new Project_PBO_baru.View.Admin.KelolaCustomer();
            cust.Show();
            this.Hide();
        }

        private void LabelDataKamarAdm_Click(object sender, EventArgs e)
        {

        }

        private void BtnJenisKamarAdm_Click(object sender, EventArgs e)
        {
            // already on KelolaKamar, no-op or refresh
            // could also open a dedicated JenisKamar form if available
        }

        private void BtnReservasiAdm_Click(object sender, EventArgs e)
        {
            var res = new Project_PBO_baru.View.Admin.KelolaReservasiForm();
            res.Show();
            this.Hide();
        }


        private void BtnLaporanAdm_Click(object sender, EventArgs e)
        {
            var lap = new Project_PBO_baru.View.Admin.LaporanForm();
            lap.Show();
            this.Hide();
        }

        private void BtnLogoutAdm_Click(object sender, EventArgs e)
        {
            var login = new Project_PBO_baru.View.Auth.LoginForm();
            login.Show();
            this.Hide();
        }

        private void NamaKamar1_Click(object sender, EventArgs e)
        {

        }

        private void HargaKamar1_Click(object sender, EventArgs e)
        {

        }

        private void NamaKamar2_Click(object sender, EventArgs e)
        {

        }

        private void HargaKamar2_Click(object sender, EventArgs e)
        {

        }

        private void NamaKamar3_Click(object sender, EventArgs e)
        {

        }

        private void HargaKamar3_Click(object sender, EventArgs e)
        {

        }

        private void NamaKamar4_Click(object sender, EventArgs e)
        {

        }

        private void HargaKamar4_Click(object sender, EventArgs e)
        {

        }

        private void BtnEditKamar1_Click(object sender, EventArgs e)
        {
            BeginEdit(1, NamaKamar1, HargaKamar1);
        }

        private void BtnEditKamar2_Click(object sender, EventArgs e)
        {
            BeginEdit(2, NamaKamar2, HargaKamar2);
        }

        private void BtnEditKamar3_Click(object sender, EventArgs e)
        {
            BeginEdit(3, NamaKamar3, HargaKamar3);
        }

        private void BtnEditKamar4_Click(object sender, EventArgs e)
        {
            BeginEdit(4, NamaKamar4, HargaKamar4);
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
                case 1: NamaKamar1.Text = newName; break;
                case 2: NamaKamar2.Text = newName; break;
                case 3: NamaKamar3.Text = newName; break;
                case 4: NamaKamar4.Text = newName; break;
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
                case 1: HargaKamar1.Text = newPrice; break;
                case 2: HargaKamar2.Text = newPrice; break;
                case 3: HargaKamar3.Text = newPrice; break;
                case 4: HargaKamar4.Text = newPrice; break;
            }
        }

        private void BeginEdit(int index, Label nameLabel, Label priceLabel)
        {
            if (editors.ContainsKey(index)) return; // already editing

            nameLabel.Visible = false;
            priceLabel.Visible = false;

            var txtName = new TextBox();
            txtName.Text = nameLabel.Text;
            txtName.Location = new System.Drawing.Point(nameLabel.Left, nameLabel.Top - 3);
            txtName.Width = 200;
            this.Controls.Add(txtName);

            var txtPrice = new TextBox();
            txtPrice.Text = priceLabel.Text;
            txtPrice.Location = new System.Drawing.Point(priceLabel.Left, priceLabel.Top - 3);
            txtPrice.Width = 120;
            this.Controls.Add(txtPrice);

            var btnSave = new Button();
            btnSave.Text = "Simpan";
            btnSave.Location = new System.Drawing.Point(txtPrice.Right + 8, txtPrice.Top - 1);
            btnSave.Click += (s, e) => {
                Project_PBO_baru.Models.RoomStore.SetName(index, txtName.Text);
                Project_PBO_baru.Models.RoomStore.SetPrice(index, txtPrice.Text);
                EndEdit(index);
            };
            this.Controls.Add(btnSave);

            var btnCancel = new Button();
            btnCancel.Text = "Batal";
            btnCancel.Location = new System.Drawing.Point(btnSave.Right + 6, txtPrice.Top - 1);
            btnCancel.Click += (s, e) => {
                EndEdit(index, restoreLabel:true);
            };
            this.Controls.Add(btnCancel);

            editors[index] = (txtName, txtPrice, btnSave, btnCancel);
        }

        private void EndEdit(int index, bool restoreLabel = false)
        {
            if (!editors.TryGetValue(index, out var tuple)) return;

            this.Controls.Remove(tuple.nameTxt);
            this.Controls.Remove(tuple.priceTxt);
            this.Controls.Remove(tuple.btnSave);
            this.Controls.Remove(tuple.btnCancel);
            tuple.nameTxt.Dispose();
            tuple.priceTxt.Dispose();
            tuple.btnSave.Dispose();
            tuple.btnCancel.Dispose();
            editors.Remove(index);

            switch (index)
            {
                case 1:
                    NamaKamar1.Visible = true;
                    HargaKamar1.Visible = true;
                    if (restoreLabel)
                    {
                        NamaKamar1.Text = Project_PBO_baru.Models.RoomStore.GetName(1);
                        HargaKamar1.Text = Project_PBO_baru.Models.RoomStore.GetPrice(1);
                    }
                    break;
                case 2:
                    NamaKamar2.Visible = true;
                    HargaKamar2.Visible = true;
                    if (restoreLabel)
                    {
                        NamaKamar2.Text = Project_PBO_baru.Models.RoomStore.GetName(2);
                        HargaKamar2.Text = Project_PBO_baru.Models.RoomStore.GetPrice(2);
                    }
                    break;
                case 3:
                    NamaKamar3.Visible = true;
                    HargaKamar3.Visible = true;
                    if (restoreLabel)
                    {
                        NamaKamar3.Text = Project_PBO_baru.Models.RoomStore.GetName(3);
                        HargaKamar3.Text = Project_PBO_baru.Models.RoomStore.GetPrice(3);
                    }
                    break;
                case 4:
                    NamaKamar4.Visible = true;
                    HargaKamar4.Visible = true;
                    if (restoreLabel)
                    {
                        NamaKamar4.Text = Project_PBO_baru.Models.RoomStore.GetName(4);
                        HargaKamar4.Text = Project_PBO_baru.Models.RoomStore.GetPrice(4);
                    }
                    break;
            }
        }
    }
}
