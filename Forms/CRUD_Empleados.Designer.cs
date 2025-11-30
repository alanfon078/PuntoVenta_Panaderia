namespace Panaderia
{
    partial class CRUD_Empleados
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
            tabControl1 = new TabControl();
            tbCrearUsuario = new TabPage();
            chBoxShowPass = new CheckBox();
            label2 = new Label();
            btnAgregar = new Button();
            dtpFechaNacimiento = new DateTimePicker();
            label1 = new Label();
            cmbRol = new ComboBox();
            lblRol = new Label();
            txtConfirContrasenia = new TextBox();
            lblConfirContrasenia = new Label();
            txtContrasena = new TextBox();
            lblContrasenia = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtApellidos = new TextBox();
            txtNombre = new TextBox();
            lblApellidos = new Label();
            lblNombre = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            tbEliminar = new TabPage();
            tbModificar = new TabPage();
            tabControl1.SuspendLayout();
            tbCrearUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tbCrearUsuario);
            tabControl1.Controls.Add(tbEliminar);
            tabControl1.Controls.Add(tbModificar);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1764, 860);
            tabControl1.TabIndex = 0;
            // 
            // tbCrearUsuario
            // 
            tbCrearUsuario.BackColor = Color.Transparent;
            tbCrearUsuario.Controls.Add(chBoxShowPass);
            tbCrearUsuario.Controls.Add(label2);
            tbCrearUsuario.Controls.Add(btnAgregar);
            tbCrearUsuario.Controls.Add(dtpFechaNacimiento);
            tbCrearUsuario.Controls.Add(label1);
            tbCrearUsuario.Controls.Add(cmbRol);
            tbCrearUsuario.Controls.Add(lblRol);
            tbCrearUsuario.Controls.Add(txtConfirContrasenia);
            tbCrearUsuario.Controls.Add(lblConfirContrasenia);
            tbCrearUsuario.Controls.Add(txtContrasena);
            tbCrearUsuario.Controls.Add(lblContrasenia);
            tbCrearUsuario.Controls.Add(txtTelefono);
            tbCrearUsuario.Controls.Add(lblTelefono);
            tbCrearUsuario.Controls.Add(txtEmail);
            tbCrearUsuario.Controls.Add(lblEmail);
            tbCrearUsuario.Controls.Add(txtApellidos);
            tbCrearUsuario.Controls.Add(txtNombre);
            tbCrearUsuario.Controls.Add(lblApellidos);
            tbCrearUsuario.Controls.Add(lblNombre);
            tbCrearUsuario.Controls.Add(txtUsuario);
            tbCrearUsuario.Controls.Add(lblUsuario);
            tbCrearUsuario.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbCrearUsuario.ForeColor = Color.Black;
            tbCrearUsuario.Location = new Point(4, 29);
            tbCrearUsuario.Name = "tbCrearUsuario";
            tbCrearUsuario.Padding = new Padding(3);
            tbCrearUsuario.Size = new Size(1756, 827);
            tbCrearUsuario.TabIndex = 0;
            tbCrearUsuario.Text = "Registrar Usuario";
            // 
            // chBoxShowPass
            // 
            chBoxShowPass.AutoSize = true;
            chBoxShowPass.Location = new Point(1350, 109);
            chBoxShowPass.Name = "chBoxShowPass";
            chBoxShowPass.Size = new Size(195, 28);
            chBoxShowPass.TabIndex = 41;
            chBoxShowPass.Text = "MostrarContraseña";
            chBoxShowPass.UseVisualStyleBackColor = true;
            chBoxShowPass.CheckedChanged += chBoxShowPass_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(665, 3);
            label2.Name = "label2";
            label2.Size = new Size(376, 34);
            label2.TabIndex = 40;
            label2.Text = "Registrar Nuevo Usuario";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(813, 527);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(142, 80);
            btnAgregar.TabIndex = 39;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            btnAgregar.KeyDown += btnAgregar_KeyDown;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(1075, 367);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(159, 32);
            dtpFechaNacimiento.TabIndex = 38;
            // 
            // label1
            // 
            label1.Location = new Point(944, 347);
            label1.Name = "label1";
            label1.Size = new Size(125, 67);
            label1.TabIndex = 37;
            label1.Text = "Fecha de\r\nnacimiento";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Empleado" });
            cmbRol.Location = new Point(1075, 274);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(159, 32);
            cmbRol.TabIndex = 36;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(955, 278);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(114, 28);
            lblRol.TabIndex = 35;
            lblRol.Text = "Rol";
            // 
            // txtConfirContrasenia
            // 
            txtConfirContrasenia.Location = new Point(1075, 187);
            txtConfirContrasenia.Name = "txtConfirContrasenia";
            txtConfirContrasenia.Size = new Size(269, 32);
            txtConfirContrasenia.TabIndex = 34;
            txtConfirContrasenia.UseSystemPasswordChar = true;
            txtConfirContrasenia.KeyDown += txtConfirContrasenia_KeyDown;
            // 
            // lblConfirContrasenia
            // 
            lblConfirContrasenia.Location = new Point(955, 177);
            lblConfirContrasenia.Name = "lblConfirContrasenia";
            lblConfirContrasenia.Size = new Size(114, 47);
            lblConfirContrasenia.TabIndex = 33;
            lblConfirContrasenia.Text = "Confirmar\r\ncontraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(1075, 106);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(269, 32);
            txtContrasena.TabIndex = 32;
            txtContrasena.UseSystemPasswordChar = true;
            txtContrasena.KeyDown += txtContrasena_KeyDown;
            // 
            // lblContrasenia
            // 
            lblContrasenia.Location = new Point(955, 109);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(114, 34);
            lblContrasenia.TabIndex = 31;
            lblContrasenia.Text = "Contraseña";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(510, 442);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(194, 32);
            txtTelefono.TabIndex = 30;
            txtTelefono.KeyDown += txtTelefono_KeyDown;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(404, 442);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(88, 26);
            lblTelefono.TabIndex = 29;
            lblTelefono.Text = "Telefono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(510, 367);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(338, 32);
            txtEmail.TabIndex = 28;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(404, 370);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(88, 44);
            lblEmail.TabIndex = 27;
            lblEmail.Text = "Email \r\n(opcional)";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(510, 274);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(338, 32);
            txtApellidos.TabIndex = 26;
            txtApellidos.KeyDown += txtApellidos_KeyDown;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(510, 187);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(338, 32);
            txtNombre.TabIndex = 25;
            txtNombre.KeyDown += txtNombre_KeyDown;
            // 
            // lblApellidos
            // 
            lblApellidos.Location = new Point(404, 277);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(88, 34);
            lblApellidos.TabIndex = 24;
            lblApellidos.Text = "Apellidos";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(404, 190);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(88, 34);
            lblNombre.TabIndex = 23;
            lblNombre.Text = "Nombre";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(510, 103);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(194, 32);
            txtUsuario.TabIndex = 22;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(404, 106);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(88, 34);
            lblUsuario.TabIndex = 21;
            lblUsuario.Text = "Usuario";
            // 
            // tbEliminar
            // 
            tbEliminar.Font = new Font("Calibri", 12F);
            tbEliminar.Location = new Point(4, 29);
            tbEliminar.Name = "tbEliminar";
            tbEliminar.Padding = new Padding(3);
            tbEliminar.Size = new Size(1756, 827);
            tbEliminar.TabIndex = 1;
            tbEliminar.Text = "Eliminar Usuario";
            tbEliminar.UseVisualStyleBackColor = true;
            // 
            // tbModificar
            // 
            tbModificar.Font = new Font("Calibri", 12F);
            tbModificar.Location = new Point(4, 29);
            tbModificar.Name = "tbModificar";
            tbModificar.Size = new Size(1756, 827);
            tbModificar.TabIndex = 2;
            tbModificar.Text = "Modificar Usuario";
            tbModificar.UseVisualStyleBackColor = true;
            // 
            // CRUD_Empleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1788, 884);
            Controls.Add(tabControl1);
            Name = "CRUD_Empleados";
            Text = "CRUD_Empleados";
            tabControl1.ResumeLayout(false);
            tbCrearUsuario.ResumeLayout(false);
            tbCrearUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tbCrearUsuario;
        private TabPage tbEliminar;
        private TabPage tbModificar;
        private Label label2;
        private Button btnAgregar;
        private DateTimePicker dtpFechaNacimiento;
        private Label label1;
        private ComboBox cmbRol;
        private Label lblRol;
        private TextBox txtConfirContrasenia;
        private Label lblConfirContrasenia;
        private TextBox txtContrasena;
        private Label lblContrasenia;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtApellidos;
        private TextBox txtNombre;
        private Label lblApellidos;
        private Label lblNombre;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private CheckBox chBoxShowPass;
    }
}