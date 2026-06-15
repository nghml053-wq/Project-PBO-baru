namespace Project_PBO_baru.View.Admin
{
    partial class KelolaCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KelolaCustomer));
            this.BtnDashboardBtn = new System.Windows.Forms.Button();
            this.BtnReservasiAdm = new System.Windows.Forms.Button();
            this.BtnLaporanAdm = new System.Windows.Forms.Button();
            this.BtnLogoutAdm = new System.Windows.Forms.Button();
            this.BtnDataKamarAdm = new System.Windows.Forms.Button();
            this.LabelDataUserAdm = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnDashboardBtn
            // 
            this.BtnDashboardBtn.Location = new System.Drawing.Point(77, 153);
            this.BtnDashboardBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDashboardBtn.Name = "BtnDashboardBtn";
            this.BtnDashboardBtn.Size = new System.Drawing.Size(127, 56);
            this.BtnDashboardBtn.TabIndex = 0;
            this.BtnDashboardBtn.Text = "Dashboard";
            this.BtnDashboardBtn.UseVisualStyleBackColor = true;
            this.BtnDashboardBtn.Click += new System.EventHandler(this.BtnDashboardBtn_Click);
            // 
            // BtnReservasiAdm
            // 
            this.BtnReservasiAdm.Location = new System.Drawing.Point(77, 337);
            this.BtnReservasiAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnReservasiAdm.Name = "BtnReservasiAdm";
            this.BtnReservasiAdm.Size = new System.Drawing.Size(127, 56);
            this.BtnReservasiAdm.TabIndex = 3;
            this.BtnReservasiAdm.Text = "Reservasi";
            this.BtnReservasiAdm.UseVisualStyleBackColor = true;
            this.BtnReservasiAdm.Click += new System.EventHandler(this.BtnReservasiAdm_Click);
            // 
            // BtnLaporanAdm
            // 
            this.BtnLaporanAdm.Location = new System.Drawing.Point(77, 397);
            this.BtnLaporanAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLaporanAdm.Name = "BtnLaporanAdm";
            this.BtnLaporanAdm.Size = new System.Drawing.Size(127, 56);
            this.BtnLaporanAdm.TabIndex = 5;
            this.BtnLaporanAdm.Text = "Laporan";
            this.BtnLaporanAdm.UseVisualStyleBackColor = true;
            this.BtnLaporanAdm.Click += new System.EventHandler(this.BtnLaporanAdm_Click);
            // 
            // BtnLogoutAdm
            // 
            this.BtnLogoutAdm.Location = new System.Drawing.Point(77, 457);
            this.BtnLogoutAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnLogoutAdm.Name = "BtnLogoutAdm";
            this.BtnLogoutAdm.Size = new System.Drawing.Size(127, 56);
            this.BtnLogoutAdm.TabIndex = 6;
            this.BtnLogoutAdm.Text = "Logout";
            this.BtnLogoutAdm.UseVisualStyleBackColor = true;
            this.BtnLogoutAdm.Click += new System.EventHandler(this.BtnLogoutAdm_Click);
            // 
            // BtnDataKamarAdm
            // 
            this.BtnDataKamarAdm.Location = new System.Drawing.Point(77, 277);
            this.BtnDataKamarAdm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnDataKamarAdm.Name = "BtnDataKamarAdm";
            this.BtnDataKamarAdm.Size = new System.Drawing.Size(127, 56);
            this.BtnDataKamarAdm.TabIndex = 7;
            this.BtnDataKamarAdm.Text = "Data Kamar";
            this.BtnDataKamarAdm.UseVisualStyleBackColor = true;
            this.BtnDataKamarAdm.Click += new System.EventHandler(this.BtnDataKamarAdm_Click);
            // 
            // LabelDataUserAdm
            // 
            this.LabelDataUserAdm.AutoSize = true;
            this.LabelDataUserAdm.BackColor = System.Drawing.Color.Transparent;
            this.LabelDataUserAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDataUserAdm.Location = new System.Drawing.Point(12, 9);
            this.LabelDataUserAdm.Name = "LabelDataUserAdm";
            this.LabelDataUserAdm.Size = new System.Drawing.Size(228, 52);
            this.LabelDataUserAdm.TabIndex = 8;
            this.LabelDataUserAdm.Text = "Data User";
            this.LabelDataUserAdm.Click += new System.EventHandler(this.LabelDataUserAdm_Click);
            // 
            // KelolaCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.LabelDataUserAdm);
            this.Controls.Add(this.BtnDataKamarAdm);
            this.Controls.Add(this.BtnLogoutAdm);
            this.Controls.Add(this.BtnLaporanAdm);
            this.Controls.Add(this.BtnReservasiAdm);
            this.Controls.Add(this.BtnDashboardBtn);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KelolaCustomer";
            this.Text = "Kelola Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDashboardBtn;
        private System.Windows.Forms.Button BtnReservasiAdm;
        private System.Windows.Forms.Button BtnLaporanAdm;
        private System.Windows.Forms.Button BtnLogoutAdm;
        private System.Windows.Forms.Button BtnDataKamarAdm;
        private System.Windows.Forms.Label LabelDataUserAdm;
    }
}