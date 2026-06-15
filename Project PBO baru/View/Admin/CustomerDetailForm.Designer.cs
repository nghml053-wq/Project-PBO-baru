namespace Project_PBO_baru.View.Admin
{
    partial class CustomerDetailForm
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

        private void InitializeComponent()
        {
            // User ID removed from UI to avoid showing sensitive/internal identifiers
            this.LblUsername = new System.Windows.Forms.Label();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.LblNamaUser = new System.Windows.Forms.Label();
            this.TxtNamaUser = new System.Windows.Forms.TextBox();
            this.LblNoHp = new System.Windows.Forms.Label();
            this.TxtNoHp = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // (UserId controls removed)

            // LblUsername
            this.LblUsername.AutoSize = true;
            this.LblUsername.Location = new System.Drawing.Point(20, 60);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(68, 16);
            this.LblUsername.TabIndex = 2;
            this.LblUsername.Text = "Username:";

            // TxtUsername
            this.TxtUsername.Location = new System.Drawing.Point(150, 60);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.ReadOnly = true;
            this.TxtUsername.Size = new System.Drawing.Size(200, 20);
            this.TxtUsername.TabIndex = 3;

            // LblNamaUser
            this.LblNamaUser.AutoSize = true;
            this.LblNamaUser.Location = new System.Drawing.Point(20, 100);
            this.LblNamaUser.Name = "LblNamaUser";
            this.LblNamaUser.Size = new System.Drawing.Size(68, 16);
            this.LblNamaUser.TabIndex = 4;
            this.LblNamaUser.Text = "Nama User:";

            // TxtNamaUser
            this.TxtNamaUser.Location = new System.Drawing.Point(150, 100);
            this.TxtNamaUser.Name = "TxtNamaUser";
            this.TxtNamaUser.ReadOnly = true;
            this.TxtNamaUser.Size = new System.Drawing.Size(200, 20);
            this.TxtNamaUser.TabIndex = 5;

            // LblNoHp
            this.LblNoHp.AutoSize = true;
            this.LblNoHp.Location = new System.Drawing.Point(20, 140);
            this.LblNoHp.Name = "LblNoHp";
            this.LblNoHp.Size = new System.Drawing.Size(43, 16);
            this.LblNoHp.TabIndex = 6;
            this.LblNoHp.Text = "No HP:";

            // TxtNoHp
            this.TxtNoHp.Location = new System.Drawing.Point(150, 140);
            this.TxtNoHp.Name = "TxtNoHp";
            this.TxtNoHp.ReadOnly = true;
            this.TxtNoHp.Size = new System.Drawing.Size(200, 20);
            this.TxtNoHp.TabIndex = 7;

            // BtnClose
            this.BtnClose.Location = new System.Drawing.Point(150, 180);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(75, 23);
            this.BtnClose.TabIndex = 8;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);

            // CustomerDetailForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 230);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.TxtNoHp);
            this.Controls.Add(this.LblNoHp);
            this.Controls.Add(this.TxtNamaUser);
            this.Controls.Add(this.LblNamaUser);
            this.Controls.Add(this.TxtUsername);
            this.Controls.Add(this.LblUsername);
            // UserId controls intentionally omitted from Controls
            this.Name = "CustomerDetailForm";
            this.Text = "Customer Detail";
            this.Load += new System.EventHandler(this.CustomerDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label LblUserId;
        private System.Windows.Forms.TextBox TxtUserId;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label LblNamaUser;
        private System.Windows.Forms.TextBox TxtNamaUser;
        private System.Windows.Forms.Label LblNoHp;
        private System.Windows.Forms.TextBox TxtNoHp;
        private System.Windows.Forms.Button BtnClose;
    }
}
