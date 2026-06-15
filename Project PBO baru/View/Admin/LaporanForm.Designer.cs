namespace Project_PBO_baru.View.Admin
{
    partial class LaporanForm
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
            this.BtnDashboardAdm = new System.Windows.Forms.Button();
            this.BtnDataKamarAdm = new System.Windows.Forms.Button();
            this.BtnReservasiAdm = new System.Windows.Forms.Button();
            this.BtnTransaksiAdm = new System.Windows.Forms.Button();
            this.BtnLogoutAdm = new System.Windows.Forms.Button();
            this.LabelLaporanAdm = new System.Windows.Forms.Label();
            this.BtnDataUserAdm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDashboardAdm
            // 
            this.BtnDashboardAdm.Location = new System.Drawing.Point(45, 50);
            this.BtnDashboardAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDashboardAdm.Name = "BtnDashboardAdm";
            this.BtnDashboardAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnDashboardAdm.TabIndex = 0;
            this.BtnDashboardAdm.Text = "Dashboard";
            this.BtnDashboardAdm.UseVisualStyleBackColor = true;
            this.BtnDashboardAdm.Click += new System.EventHandler(this.BtnDashboardAdm_Click);
            // 
            // BtnDataKamarAdm
            // 
            this.BtnDataKamarAdm.Location = new System.Drawing.Point(45, 146);
            this.BtnDataKamarAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDataKamarAdm.Name = "BtnDataKamarAdm";
            this.BtnDataKamarAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnDataKamarAdm.TabIndex = 2;
            this.BtnDataKamarAdm.Text = "Data Kamar";
            this.BtnDataKamarAdm.UseVisualStyleBackColor = true;
            this.BtnDataKamarAdm.Click += new System.EventHandler(this.BtnDataKamarAdm_Click);
            // 
            // BtnReservasiAdm
            // 
            this.BtnReservasiAdm.Location = new System.Drawing.Point(45, 193);
            this.BtnReservasiAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReservasiAdm.Name = "BtnReservasiAdm";
            this.BtnReservasiAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnReservasiAdm.TabIndex = 4;
            this.BtnReservasiAdm.Text = "Reservasi";
            this.BtnReservasiAdm.UseVisualStyleBackColor = true;
            this.BtnReservasiAdm.Click += new System.EventHandler(this.BtnReservasiAdm_Click);
            // 
            // BtnTransaksiAdm
            // 
            this.BtnTransaksiAdm.Location = new System.Drawing.Point(45, 238);
            this.BtnTransaksiAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnTransaksiAdm.Name = "BtnTransaksiAdm";
            this.BtnTransaksiAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnTransaksiAdm.TabIndex = 5;
            this.BtnTransaksiAdm.Text = "Transaksi";
            this.BtnTransaksiAdm.UseVisualStyleBackColor = true;
            this.BtnTransaksiAdm.Click += new System.EventHandler(this.BtnTransaksiAdm_Click);
            // 
            // BtnLogoutAdm
            // 
            this.BtnLogoutAdm.Location = new System.Drawing.Point(45, 380);
            this.BtnLogoutAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLogoutAdm.Name = "BtnLogoutAdm";
            this.BtnLogoutAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnLogoutAdm.TabIndex = 6;
            this.BtnLogoutAdm.Text = "Logout";
            this.BtnLogoutAdm.UseVisualStyleBackColor = true;
            this.BtnLogoutAdm.Click += new System.EventHandler(this.BtnLogoutAdm_Click);
            // 
            // LabelLaporanAdm
            // 
            this.LabelLaporanAdm.AutoSize = true;
            this.LabelLaporanAdm.Location = new System.Drawing.Point(63, 338);
            this.LabelLaporanAdm.Name = "LabelLaporanAdm";
            this.LabelLaporanAdm.Size = new System.Drawing.Size(57, 16);
            this.LabelLaporanAdm.TabIndex = 7;
            this.LabelLaporanAdm.Text = "Laporan";
            // 
            // BtnDataUserAdm
            // 
            this.BtnDataUserAdm.Location = new System.Drawing.Point(45, 97);
            this.BtnDataUserAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDataUserAdm.Name = "BtnDataUserAdm";
            this.BtnDataUserAdm.Size = new System.Drawing.Size(75, 23);
            this.BtnDataUserAdm.TabIndex = 1;
            this.BtnDataUserAdm.Text = "Data User";
            this.BtnDataUserAdm.UseVisualStyleBackColor = true;
            this.BtnDataUserAdm.Click += new System.EventHandler(this.BtnDataUserAdm_Click);
            // 
            // LaporanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelLaporanAdm);
            this.Controls.Add(this.BtnLogoutAdm);
            this.Controls.Add(this.BtnTransaksiAdm);
            this.Controls.Add(this.BtnReservasiAdm);
            this.Controls.Add(this.BtnDataKamarAdm);
            this.Controls.Add(this.BtnDataUserAdm);
            this.Controls.Add(this.BtnDashboardAdm);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LaporanForm";
            this.Text = "LaporanForm";
            this.Load += new System.EventHandler(this.LaporanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDashboardAdm;
        private System.Windows.Forms.Button BtnDataKamarAdm;
        private System.Windows.Forms.Button BtnReservasiAdm;
        private System.Windows.Forms.Button BtnTransaksiAdm;
        private System.Windows.Forms.Button BtnLogoutAdm;
        private System.Windows.Forms.Label LabelLaporanAdm;
        private System.Windows.Forms.Button BtnDataUserAdm;
    }
}