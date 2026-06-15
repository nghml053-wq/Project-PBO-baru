namespace Project_PBO_baru.View.Customer
{
    partial class PembayaranCustomer
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.LblRoom = new System.Windows.Forms.Label();
            this.LblCheckin = new System.Windows.Forms.Label();
            this.LblCheckout = new System.Windows.Forms.Label();
            this.LblNights = new System.Windows.Forms.Label();
            this.LblPriceNight = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.BtnBayarCash = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LblRoom
            // 
            this.LblRoom.AutoSize = true;
            this.LblRoom.Location = new System.Drawing.Point(20, 20);
            this.LblRoom.Name = "LblRoom";
            this.LblRoom.Size = new System.Drawing.Size(0, 16);
            this.LblRoom.TabIndex = 0;
            // 
            // LblCheckin
            // 
            this.LblCheckin.AutoSize = true;
            this.LblCheckin.Location = new System.Drawing.Point(20, 50);
            this.LblCheckin.Name = "LblCheckin";
            this.LblCheckin.Size = new System.Drawing.Size(0, 16);
            this.LblCheckin.TabIndex = 1;
            // 
            // LblCheckout
            // 
            this.LblCheckout.AutoSize = true;
            this.LblCheckout.Location = new System.Drawing.Point(20, 80);
            this.LblCheckout.Name = "LblCheckout";
            this.LblCheckout.Size = new System.Drawing.Size(0, 16);
            this.LblCheckout.TabIndex = 2;
            // 
            // LblNights
            // 
            this.LblNights.AutoSize = true;
            this.LblNights.Location = new System.Drawing.Point(20, 110);
            this.LblNights.Name = "LblNights";
            this.LblNights.Size = new System.Drawing.Size(0, 16);
            this.LblNights.TabIndex = 3;
            // 
            // LblPriceNight
            // 
            this.LblPriceNight.AutoSize = true;
            this.LblPriceNight.Location = new System.Drawing.Point(20, 140);
            this.LblPriceNight.Name = "LblPriceNight";
            this.LblPriceNight.Size = new System.Drawing.Size(0, 16);
            this.LblPriceNight.TabIndex = 4;
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Location = new System.Drawing.Point(20, 170);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(0, 16);
            this.LblTotal.TabIndex = 5;
            // 
            // BtnBayarCash
            // 
            this.BtnBayarCash.Location = new System.Drawing.Point(20, 210);
            this.BtnBayarCash.Name = "BtnBayarCash";
            this.BtnBayarCash.Size = new System.Drawing.Size(75, 23);
            this.BtnBayarCash.TabIndex = 6;
            this.BtnBayarCash.Text = "Bayar (Cash)";
            this.BtnBayarCash.Click += new System.EventHandler(this.BtnBayarCash_Click);
            // 
            // PembayaranCustomer
            // 
            this.ClientSize = new System.Drawing.Size(1924, 1175);
            this.Controls.Add(this.LblRoom);
            this.Controls.Add(this.LblCheckin);
            this.Controls.Add(this.LblCheckout);
            this.Controls.Add(this.LblNights);
            this.Controls.Add(this.LblPriceNight);
            this.Controls.Add(this.LblTotal);
            this.Controls.Add(this.BtnBayarCash);
            this.Name = "PembayaranCustomer";
            this.Text = "Pembayaran";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label LblRoom;
        private System.Windows.Forms.Label LblCheckin;
        private System.Windows.Forms.Label LblCheckout;
        private System.Windows.Forms.Label LblNights;
        private System.Windows.Forms.Label LblPriceNight;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.Button BtnBayarCash;
    }
}
