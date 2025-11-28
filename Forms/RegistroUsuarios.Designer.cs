namespace Panaderia.Forms
{
    partial class RegistroUsuarios
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
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblNombre = new Label();
            lblApellidos = new Label();
            txtNombre = new TextBox();
            txtApellidos = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblContrasenia = new Label();
            txtContrasena = new TextBox();
            lblConfirContrasenia = new Label();
            txtConfirContrasenia = new TextBox();
            lblRol = new Label();
            cmbRol = new ComboBox();
            label1 = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            btnAgregar = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(22, 87);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(88, 34);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(128, 84);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(159, 27);
            txtUsuario.TabIndex = 2;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(22, 141);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(88, 34);
            lblNombre.TabIndex = 3;
            lblNombre.Text = "Nombre";
            // 
            // lblApellidos
            // 
            lblApellidos.Location = new Point(22, 196);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(88, 34);
            lblApellidos.TabIndex = 4;
            lblApellidos.Text = "Apellidos";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(128, 138);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(159, 27);
            txtNombre.TabIndex = 5;
            txtNombre.KeyDown += txtNombre_KeyDown;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(128, 193);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(159, 27);
            txtApellidos.TabIndex = 6;
            txtApellidos.KeyDown += txtApellidos_KeyDown;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(22, 230);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(88, 44);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email \r\n(opcional)";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(128, 245);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(159, 27);
            txtEmail.TabIndex = 8;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(22, 298);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(88, 26);
            lblTelefono.TabIndex = 9;
            lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(128, 298);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(159, 27);
            txtTelefono.TabIndex = 10;
            txtTelefono.KeyDown += txtTelefono_KeyDown;
            // 
            // lblContrasenia
            // 
            lblContrasenia.Location = new Point(357, 87);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(88, 34);
            lblContrasenia.TabIndex = 11;
            lblContrasenia.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(477, 84);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(159, 27);
            txtContrasena.TabIndex = 12;
            txtContrasena.KeyDown += txtContrasena_KeyDown;
            // 
            // lblConfirContrasenia
            // 
            lblConfirContrasenia.Location = new Point(357, 131);
            lblConfirContrasenia.Name = "lblConfirContrasenia";
            lblConfirContrasenia.Size = new Size(88, 44);
            lblConfirContrasenia.TabIndex = 13;
            lblConfirContrasenia.Text = "Confirmar\r\ncontraseña";
            // 
            // txtConfirContrasenia
            // 
            txtConfirContrasenia.Location = new Point(477, 141);
            txtConfirContrasenia.Name = "txtConfirContrasenia";
            txtConfirContrasenia.Size = new Size(159, 27);
            txtConfirContrasenia.TabIndex = 14;
            txtConfirContrasenia.KeyDown += txtConfirContrasenia_KeyDown;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(357, 196);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(88, 44);
            lblRol.TabIndex = 15;
            lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Empleado" });
            cmbRol.Location = new Point(477, 192);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(159, 28);
            cmbRol.TabIndex = 16;
            // 
            // label1
            // 
            label1.Location = new Point(357, 240);
            label1.Name = "label1";
            label1.Size = new Size(88, 44);
            label1.TabIndex = 17;
            label1.Text = "Fecha de\r\nnacimiento";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(477, 243);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(159, 27);
            dtpFechaNacimiento.TabIndex = 18;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(275, 372);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 19;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            btnAgregar.KeyDown += btnAgregar_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(215, 9);
            label2.Name = "label2";
            label2.Size = new Size(250, 23);
            label2.TabIndex = 20;
            label2.Text = "Registrar Nuevo Usuario";
            // 
            // RegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(685, 450);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(label1);
            Controls.Add(cmbRol);
            Controls.Add(lblRol);
            Controls.Add(txtConfirContrasenia);
            Controls.Add(lblConfirContrasenia);
            Controls.Add(txtContrasena);
            Controls.Add(lblContrasenia);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombre);
            Controls.Add(lblApellidos);
            Controls.Add(lblNombre);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Name = "RegistroUsuarios";
            Text = "RegistroUsuarios";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblNombre;
        private Label lblApellidos;
        private TextBox txtNombre;
        private TextBox txtApellidos;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblContrasenia;
        private TextBox txtContrasena;
        private Label lblConfirContrasenia;
        private TextBox txtConfirContrasenia;
        private Label lblRol;
        private ComboBox cmbRol;
        private Label label1;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnAgregar;
        private Label label2;
    }
}