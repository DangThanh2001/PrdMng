namespace ManagerCustomer
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
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            tbUserName = new TextBox();
            tbPassword = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(109, 96);
            label1.Name = "label1";
            label1.Size = new Size(136, 32);
            label1.TabIndex = 0;
            label1.Text = "Tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(109, 197);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 1;
            label2.Text = "Mật khẩu";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(314, 330);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(139, 57);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // tbUserName
            // 
            tbUserName.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbUserName.Location = new Point(267, 90);
            tbUserName.Name = "tbUserName";
            tbUserName.Size = new Size(432, 38);
            tbUserName.TabIndex = 3;
            // 
            // tbPassword
            // 
            tbPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            tbPassword.Location = new Point(267, 191);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(432, 38);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tbPassword);
            Controls.Add(tbUserName);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnLogin;
        private TextBox tbUserName;
        private TextBox tbPassword;
    }
}