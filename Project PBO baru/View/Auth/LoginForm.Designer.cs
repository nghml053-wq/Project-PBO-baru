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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_SignUp = new System.Windows.Forms.Button();
            this.BTNOWNER = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(277, 358);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(334, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Masukkan Username";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(277, 521);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(250, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Password";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Location = new System.Drawing.Point(504, 815);
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
            this.Btn_SignUp.Location = new System.Drawing.Point(837, 898);
            this.Btn_SignUp.Name = "Btn_SignUp";
            this.Btn_SignUp.Size = new System.Drawing.Size(131, 27);
            this.Btn_SignUp.TabIndex = 3;
            this.Btn_SignUp.Text = "SIGN UP";
            this.Btn_SignUp.UseVisualStyleBackColor = false;
            this.Btn_SignUp.Click += new System.EventHandler(this.BNTSIGNUP_Click);
            // 
            // BTNOWNER
            // 
            this.BTNOWNER.AutoSize = true;
            this.BTNOWNER.Location = new System.Drawing.Point(257, 668);
            this.BTNOWNER.Name = "BTNOWNER";
            this.BTNOWNER.Size = new System.Drawing.Size(66, 20);
            this.BTNOWNER.TabIndex = 4;
            this.BTNOWNER.TabStop = true;
            this.BTNOWNER.Text = "Owner";
            this.BTNOWNER.UseVisualStyleBackColor = true;
            this.BTNOWNER.CheckedChanged += new System.EventHandler(this.BTNOWNER_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(526, 668);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(66, 20);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Admin";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1422, 981);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.BTNOWNER);
            this.Controls.Add(this.Btn_SignUp);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_SignUp;
        private System.Windows.Forms.RadioButton BTNOWNER;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}