namespace Project_PBO_baru.View.Auth
{
    partial class LoginForm
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
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_SignUp = new System.Windows.Forms.Button();
            this.RdioBtnCust = new System.Windows.Forms.RadioButton();
            this.RadioBtnAdm = new System.Windows.Forms.RadioButton();
            this.PanelLogin = new System.Windows.Forms.Panel();
            this.PanelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBox1
            // 
            this.TextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.TextBox1.Location = new System.Drawing.Point(195, 117);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(334, 22);
            this.TextBox1.TabIndex = 0;
            this.TextBox1.Text = "Masukkan Username";
            this.TextBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // TextBox2
            // 
            this.TextBox2.BackColor = System.Drawing.SystemColors.Window;
            this.TextBox2.Location = new System.Drawing.Point(195, 193);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(334, 22);
            this.TextBox2.TabIndex = 1;
            this.TextBox2.Text = "Password";
            this.TextBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(137, 329);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(439, 46);
            this.Btn_Login.TabIndex = 2;
            this.Btn_Login.Text = "LOGIN";
            this.Btn_Login.UseVisualStyleBackColor = true;
            this.Btn_Login.Click += new System.EventHandler(this.BTNLOGIN_Click);
            // 
            // Btn_SignUp
            // 
            this.Btn_SignUp.BackColor = System.Drawing.Color.Transparent;
            this.Btn_SignUp.Location = new System.Drawing.Point(287, 402);
            this.Btn_SignUp.Name = "Btn_SignUp";
            this.Btn_SignUp.Size = new System.Drawing.Size(131, 27);
            this.Btn_SignUp.TabIndex = 3;
            this.Btn_SignUp.Text = "SIGN UP";
            this.Btn_SignUp.UseVisualStyleBackColor = false;
            this.Btn_SignUp.Click += new System.EventHandler(this.BNTSIGNUP_Click);
            // 
            // RdioBtnCust
            // 
            this.RdioBtnCust.AutoSize = true;
            this.RdioBtnCust.BackColor = System.Drawing.Color.Transparent;
            this.RdioBtnCust.Location = new System.Drawing.Point(241, 264);
            this.RdioBtnCust.Name = "RdioBtnCust";
            this.RdioBtnCust.Size = new System.Drawing.Size(85, 20);
            this.RdioBtnCust.TabIndex = 4;
            this.RdioBtnCust.TabStop = true;
            this.RdioBtnCust.Text = "Customer";
            this.RdioBtnCust.UseVisualStyleBackColor = false;
            // 
            // RadioBtnAdm
            // 
            this.RadioBtnAdm.AutoSize = true;
            this.RadioBtnAdm.BackColor = System.Drawing.Color.Transparent;
            this.RadioBtnAdm.Location = new System.Drawing.Point(368, 264);
            this.RadioBtnAdm.Name = "RadioBtnAdm";
            this.RadioBtnAdm.Size = new System.Drawing.Size(66, 20);
            this.RadioBtnAdm.TabIndex = 5;
            this.RadioBtnAdm.TabStop = true;
            this.RadioBtnAdm.Text = "Admin";
            this.RadioBtnAdm.UseVisualStyleBackColor = false;
            // 
            // PanelLogin
            // 
            this.PanelLogin.BackColor = System.Drawing.Color.White;
            this.PanelLogin.BackgroundImage = global::Project_PBO_baru.Properties.Resources.download__3_;
            this.PanelLogin.Controls.Add(this.TextBox1);
            this.PanelLogin.Controls.Add(this.Btn_SignUp);
            this.PanelLogin.Controls.Add(this.RdioBtnCust);
            this.PanelLogin.Controls.Add(this.Btn_Login);
            this.PanelLogin.Controls.Add(this.RadioBtnAdm);
            this.PanelLogin.Controls.Add(this.TextBox2);
            this.PanelLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PanelLogin.Location = new System.Drawing.Point(515, 248);
            this.PanelLogin.Name = "PanelLogin";
            this.PanelLogin.Size = new System.Drawing.Size(704, 523);
            this.PanelLogin.TabIndex = 6;
            this.PanelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Project_PBO_baru.Properties.Resources.The_New_York_EDITION_hotel_review___Urban_Pixxels;
            this.ClientSize = new System.Drawing.Size(1708, 1100);
            this.Controls.Add(this.PanelLogin);
            this.DoubleBuffered = true;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.PanelLogin.ResumeLayout(false);
            this.PanelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.TextBox TextBox2;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_SignUp;
        private System.Windows.Forms.RadioButton RdioBtnCust;
        private System.Windows.Forms.RadioButton RadioBtnAdm;
        private System.Windows.Forms.Panel PanelLogin;
    }
}