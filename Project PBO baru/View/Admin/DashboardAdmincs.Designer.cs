namespace Project_PBO_baru.View.Admin
{
    partial class DashboardAdmincs
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardAdmincs));
            this.BtnDataUserAdm = new System.Windows.Forms.Button();
            this.BtnDataKamarAdm = new System.Windows.Forms.Button();
            this.ReservasiAdm = new System.Windows.Forms.Button();
            this.BtnLaporanAdm = new System.Windows.Forms.Button();
            this.BtnLogoutAdm = new System.Windows.Forms.Button();
            this.BtnDashboardAdm = new System.Windows.Forms.Label();
            this.GrafikTotalReservasi = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.GrafikTotalReservasi)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnDataUserAdm
            // 
            this.BtnDataUserAdm.Location = new System.Drawing.Point(51, 212);
            this.BtnDataUserAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDataUserAdm.Name = "BtnDataUserAdm";
            this.BtnDataUserAdm.Size = new System.Drawing.Size(135, 55);
            this.BtnDataUserAdm.TabIndex = 0;
            this.BtnDataUserAdm.Text = "Data User";
            this.BtnDataUserAdm.UseVisualStyleBackColor = true;
            this.BtnDataUserAdm.Click += new System.EventHandler(this.BtnDataUserAdm_Click);
            // 
            // BtnDataKamarAdm
            // 
            this.BtnDataKamarAdm.Location = new System.Drawing.Point(51, 288);
            this.BtnDataKamarAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDataKamarAdm.Name = "BtnDataKamarAdm";
            this.BtnDataKamarAdm.Size = new System.Drawing.Size(135, 55);
            this.BtnDataKamarAdm.TabIndex = 1;
            this.BtnDataKamarAdm.Text = "Data Kamar";
            this.BtnDataKamarAdm.UseVisualStyleBackColor = true;
            this.BtnDataKamarAdm.Click += new System.EventHandler(this.BtnDataKamarAdm_Click);
            // 
            // ReservasiAdm
            // 
            this.ReservasiAdm.Location = new System.Drawing.Point(51, 357);
            this.ReservasiAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReservasiAdm.Name = "ReservasiAdm";
            this.ReservasiAdm.Size = new System.Drawing.Size(135, 55);
            this.ReservasiAdm.TabIndex = 3;
            this.ReservasiAdm.Text = "Reservasi";
            this.ReservasiAdm.UseVisualStyleBackColor = true;
            this.ReservasiAdm.Click += new System.EventHandler(this.ReservasiAdm_Click);
            // 
            // BtnLaporanAdm
            // 
            this.BtnLaporanAdm.Location = new System.Drawing.Point(51, 426);
            this.BtnLaporanAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLaporanAdm.Name = "BtnLaporanAdm";
            this.BtnLaporanAdm.Size = new System.Drawing.Size(135, 55);
            this.BtnLaporanAdm.TabIndex = 5;
            this.BtnLaporanAdm.Text = "Laporan";
            this.BtnLaporanAdm.UseVisualStyleBackColor = true;
            this.BtnLaporanAdm.Click += new System.EventHandler(this.BtnLaporanAdm_Click);
            // 
            // BtnLogoutAdm
            // 
            this.BtnLogoutAdm.Location = new System.Drawing.Point(51, 499);
            this.BtnLogoutAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLogoutAdm.Name = "BtnLogoutAdm";
            this.BtnLogoutAdm.Size = new System.Drawing.Size(135, 55);
            this.BtnLogoutAdm.TabIndex = 6;
            this.BtnLogoutAdm.Text = "Logout";
            this.BtnLogoutAdm.UseVisualStyleBackColor = true;
            this.BtnLogoutAdm.Click += new System.EventHandler(this.BtnLogoutAdm_Click);
            // 
            // BtnDashboardAdm
            // 
            this.BtnDashboardAdm.AutoSize = true;
            this.BtnDashboardAdm.BackColor = System.Drawing.Color.Transparent;
            this.BtnDashboardAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDashboardAdm.Location = new System.Drawing.Point(59, 25);
            this.BtnDashboardAdm.Name = "BtnDashboardAdm";
            this.BtnDashboardAdm.Size = new System.Drawing.Size(224, 46);
            this.BtnDashboardAdm.TabIndex = 7;
            this.BtnDashboardAdm.Text = "Dashboard";
            this.BtnDashboardAdm.Click += new System.EventHandler(this.BtnDashboardAdm_Click);
            // 
            // GrafikTotalReservasi
            // 
            chartArea1.Name = "ChartArea1";
            this.GrafikTotalReservasi.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.GrafikTotalReservasi.Legends.Add(legend1);
            this.GrafikTotalReservasi.Location = new System.Drawing.Point(328, 119);
            this.GrafikTotalReservasi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GrafikTotalReservasi.Name = "GrafikTotalReservasi";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.GrafikTotalReservasi.Series.Add(series1);
            this.GrafikTotalReservasi.Size = new System.Drawing.Size(1232, 520);
            this.GrafikTotalReservasi.TabIndex = 8;
            this.GrafikTotalReservasi.Text = "GrafikTotalReservasi";
            this.GrafikTotalReservasi.Click += new System.EventHandler(this.GrafikTotalReservasi_Click);
            // 
            // DashboardAdmincs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.GrafikTotalReservasi);
            this.Controls.Add(this.BtnDashboardAdm);
            this.Controls.Add(this.BtnLogoutAdm);
            this.Controls.Add(this.BtnLaporanAdm);
            this.Controls.Add(this.ReservasiAdm);
            this.Controls.Add(this.BtnDataKamarAdm);
            this.Controls.Add(this.BtnDataUserAdm);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardAdmincs";
            this.Text = "DashboardAdmincs";
            ((System.ComponentModel.ISupportInitialize)(this.GrafikTotalReservasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDataUserAdm;
        private System.Windows.Forms.Button BtnDataKamarAdm;
        private System.Windows.Forms.Button ReservasiAdm;
        private System.Windows.Forms.Button BtnLaporanAdm;
        private System.Windows.Forms.Button BtnLogoutAdm;
        private System.Windows.Forms.Label BtnDashboardAdm;
        private System.Windows.Forms.DataVisualization.Charting.Chart GrafikTotalReservasi;
    }
}