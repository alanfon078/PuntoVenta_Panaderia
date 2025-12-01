namespace Panaderia
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label2 = new Label();
            label1 = new Label();
            btnLogin = new Button();
            txtPassword = new TextBox();
            txtUser = new TextBox();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(290, 236);
            label2.Name = "label2";
            label2.Size = new Size(99, 23);
            label2.TabIndex = 9;
            label2.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(290, 164);
            label1.Name = "label1";
            label1.Size = new Size(70, 23);
            label1.TabIndex = 8;
            label1.Text = "Usuario";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.Font = new Font("Lucida Sans Unicode", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ActiveCaptionText;
            btnLogin.Location = new Point(394, 303);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Ingresar";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.KeyDown += btnLogin_KeyDown;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.Silver;
            txtPassword.Location = new Point(290, 259);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(309, 30);
            txtPassword.TabIndex = 6;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            txtPassword.KeyDown += txtPassword_KeyDown;
            // 
            // txtUser
            // 
            txtUser.BackColor = Color.White;
            txtUser.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUser.ForeColor = Color.DimGray;
            txtUser.Location = new Point(290, 187);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(309, 30);
            txtUser.TabIndex = 5;
            txtUser.TextAlign = HorizontalAlignment.Center;
            txtUser.KeyDown += txtUser_KeyDown;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.cafe;
            pictureBox1.Location = new Point(-13, -22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(934, 127);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Calibri", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Transparent;
            label3.Image = Properties.Resources.cafe1;
            label3.Location = new Point(346, 37);
            label3.Name = "label3";
            label3.Size = new Size(203, 41);
            label3.TabIndex = 11;
            label3.Text = "Iniciar Sesion";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Image = Properties.Resources.rojo;
            btnSalir.Location = new Point(12, 434);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 12;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 475);
            Controls.Add(btnSalir);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(pictureBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesion";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Button btnLogin;
        private TextBox txtPassword;
        private TextBox txtUser;
        private PictureBox pictureBox1;
        private Label label3;
        private Button btnSalir;
    }
}
