namespace Project_PBO_baru.View.Customer
{
    partial class ReservationHistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderRoom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCheckIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCheckOut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BtnBatalkan = new System.Windows.Forms.Button();
            this.BtnKembali = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderRoom,
            this.columnHeaderCheckIn,
            this.columnHeaderCheckOut,
            this.columnHeaderPrice,
            this.columnHeaderStatus});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, -1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1923, 782);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 50;
            // 
            // columnHeaderRoom
            // 
            this.columnHeaderRoom.Text = "Kamar";
            this.columnHeaderRoom.Width = 120;
            // 
            // columnHeaderCheckIn
            // 
            this.columnHeaderCheckIn.Text = "Check In";
            this.columnHeaderCheckIn.Width = 120;
            // 
            // columnHeaderCheckOut
            // 
            this.columnHeaderCheckOut.Text = "Check Out";
            this.columnHeaderCheckOut.Width = 120;
            // 
            // columnHeaderPrice
            // 
            this.columnHeaderPrice.Text = "Harga";
            this.columnHeaderPrice.Width = 120;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 120;
            // 
            // BtnBatalkan
            // 
            this.BtnBatalkan.Location = new System.Drawing.Point(81, 827);
            this.BtnBatalkan.Name = "BtnBatalkan";
            this.BtnBatalkan.Size = new System.Drawing.Size(120, 30);
            this.BtnBatalkan.TabIndex = 1;
            this.BtnBatalkan.Text = "Batalkan Reservasi";
            this.BtnBatalkan.UseVisualStyleBackColor = true;
            this.BtnBatalkan.Click += new System.EventHandler(this.BtnBatalkan_Click);
            // 
            // BtnKembali
            // 
            this.BtnKembali.Location = new System.Drawing.Point(418, 827);
            this.BtnKembali.Name = "BtnKembali";
            this.BtnKembali.Size = new System.Drawing.Size(120, 30);
            this.BtnKembali.TabIndex = 2;
            this.BtnKembali.Text = "Kembali";
            this.BtnKembali.UseVisualStyleBackColor = true;
            this.BtnKembali.Click += new System.EventHandler(this.BtnKembali_Click);
            // 
            // ReservationHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.BtnKembali);
            this.Controls.Add(this.BtnBatalkan);
            this.Controls.Add(this.listView1);
            this.Name = "ReservationHistoryForm";
            this.Text = "Riwayat Reservasi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderRoom;
        private System.Windows.Forms.ColumnHeader columnHeaderCheckIn;
        private System.Windows.Forms.ColumnHeader columnHeaderCheckOut;
        private System.Windows.Forms.ColumnHeader columnHeaderPrice;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button BtnBatalkan;
        private System.Windows.Forms.Button BtnKembali;
    }
}
