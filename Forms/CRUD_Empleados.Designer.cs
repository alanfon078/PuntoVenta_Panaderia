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
            label3 = new Label();
            btnEliminar = new Button();
            dgvUsuarios = new DataGridView();
            tbModificar = new TabPage();
            comboBox1 = new ComboBox();
            label10 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBox5 = new TextBox();
            label9 = new Label();
            btnConfirmarCambios = new Button();
            dgvModificar = new DataGridView();
            label4 = new Label();
            tabControl1.SuspendLayout();
            tbCrearUsuario.SuspendLayout();
            tbEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tbModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvModificar).BeginInit();
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
            tabControl1.Size = new Size(1900, 950);
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
            tbCrearUsuario.Size = new Size(1892, 917);
            tbCrearUsuario.TabIndex = 0;
            tbCrearUsuario.Text = "Registrar Usuario";
            // 
            // chBoxShowPass
            // 
            chBoxShowPass.AutoSize = true;
            chBoxShowPass.Location = new Point(1349, 205);
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
            label2.Font = new Font("Arial Rounded MT Bold", 25F);
            label2.Location = new Point(594, 3);
            label2.Name = "label2";
            label2.Size = new Size(524, 49);
            label2.TabIndex = 40;
            label2.Text = "Registrar Nuevo Usuario";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(812, 623);
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
            dtpFechaNacimiento.Location = new Point(1074, 463);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(159, 32);
            dtpFechaNacimiento.TabIndex = 38;
            // 
            // label1
            // 
            label1.Location = new Point(943, 443);
            label1.Name = "label1";
            label1.Size = new Size(125, 67);
            label1.TabIndex = 37;
            label1.Text = "Fecha de\r\nnacimiento";
            // 
            // cmbRol
            // 
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Administrador", "Empleado" });
            cmbRol.Location = new Point(1074, 370);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(159, 32);
            cmbRol.TabIndex = 36;
            // 
            // lblRol
            // 
            lblRol.Location = new Point(954, 374);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(114, 28);
            lblRol.TabIndex = 35;
            lblRol.Text = "Rol";
            // 
            // txtConfirContrasenia
            // 
            txtConfirContrasenia.Location = new Point(1074, 283);
            txtConfirContrasenia.Name = "txtConfirContrasenia";
            txtConfirContrasenia.Size = new Size(269, 32);
            txtConfirContrasenia.TabIndex = 34;
            txtConfirContrasenia.UseSystemPasswordChar = true;
            txtConfirContrasenia.KeyDown += txtConfirContrasenia_KeyDown;
            // 
            // lblConfirContrasenia
            // 
            lblConfirContrasenia.Location = new Point(954, 273);
            lblConfirContrasenia.Name = "lblConfirContrasenia";
            lblConfirContrasenia.Size = new Size(114, 47);
            lblConfirContrasenia.TabIndex = 33;
            lblConfirContrasenia.Text = "Confirmar\r\ncontraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(1074, 202);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(269, 32);
            txtContrasena.TabIndex = 32;
            txtContrasena.UseSystemPasswordChar = true;
            txtContrasena.KeyDown += txtContrasena_KeyDown;
            // 
            // lblContrasenia
            // 
            lblContrasenia.Location = new Point(954, 205);
            lblContrasenia.Name = "lblContrasenia";
            lblContrasenia.Size = new Size(114, 34);
            lblContrasenia.TabIndex = 31;
            lblContrasenia.Text = "Contraseña";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(509, 538);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(194, 32);
            txtTelefono.TabIndex = 30;
            txtTelefono.KeyDown += txtTelefono_KeyDown;
            // 
            // lblTelefono
            // 
            lblTelefono.Location = new Point(403, 538);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(88, 26);
            lblTelefono.TabIndex = 29;
            lblTelefono.Text = "Telefono";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(509, 463);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(338, 32);
            txtEmail.TabIndex = 28;
            txtEmail.KeyDown += txtEmail_KeyDown;
            // 
            // lblEmail
            // 
            lblEmail.Location = new Point(403, 466);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(88, 44);
            lblEmail.TabIndex = 27;
            lblEmail.Text = "Email \r\n(opcional)";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(509, 370);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(338, 32);
            txtApellidos.TabIndex = 26;
            txtApellidos.KeyDown += txtApellidos_KeyDown;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(509, 283);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(338, 32);
            txtNombre.TabIndex = 25;
            txtNombre.KeyDown += txtNombre_KeyDown;
            // 
            // lblApellidos
            // 
            lblApellidos.Location = new Point(403, 373);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(88, 34);
            lblApellidos.TabIndex = 24;
            lblApellidos.Text = "Apellidos";
            // 
            // lblNombre
            // 
            lblNombre.Location = new Point(403, 286);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(88, 34);
            lblNombre.TabIndex = 23;
            lblNombre.Text = "Nombre";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(509, 199);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(194, 32);
            txtUsuario.TabIndex = 22;
            txtUsuario.KeyDown += txtUsuario_KeyDown;
            // 
            // lblUsuario
            // 
            lblUsuario.Location = new Point(403, 202);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(88, 34);
            lblUsuario.TabIndex = 21;
            lblUsuario.Text = "Usuario";
            // 
            // tbEliminar
            // 
            tbEliminar.Controls.Add(label3);
            tbEliminar.Controls.Add(btnEliminar);
            tbEliminar.Controls.Add(dgvUsuarios);
            tbEliminar.Font = new Font("Calibri", 12F);
            tbEliminar.Location = new Point(4, 29);
            tbEliminar.Name = "tbEliminar";
            tbEliminar.Padding = new Padding(3);
            tbEliminar.Size = new Size(1892, 917);
            tbEliminar.TabIndex = 1;
            tbEliminar.Text = "Eliminar Usuario";
            tbEliminar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 25F);
            label3.Location = new Point(671, 3);
            label3.Name = "label3";
            label3.Size = new Size(381, 49);
            label3.TabIndex = 6;
            label3.Text = "Eliminar Usuarios";
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Calibri", 18F);
            btnEliminar.Location = new Point(750, 678);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(265, 59);
            btnEliminar.TabIndex = 5;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            btnEliminar.KeyDown += btnEliminar_KeyDown;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.GridColor = SystemColors.HighlightText;
            dgvUsuarios.Location = new Point(6, 66);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(1744, 606);
            dgvUsuarios.TabIndex = 4;
            // 
            // tbModificar
            // 
            tbModificar.Controls.Add(comboBox1);
            tbModificar.Controls.Add(label10);
            tbModificar.Controls.Add(textBox1);
            tbModificar.Controls.Add(label5);
            tbModificar.Controls.Add(textBox2);
            tbModificar.Controls.Add(label6);
            tbModificar.Controls.Add(textBox3);
            tbModificar.Controls.Add(textBox4);
            tbModificar.Controls.Add(label7);
            tbModificar.Controls.Add(label8);
            tbModificar.Controls.Add(textBox5);
            tbModificar.Controls.Add(label9);
            tbModificar.Controls.Add(btnConfirmarCambios);
            tbModificar.Controls.Add(dgvModificar);
            tbModificar.Controls.Add(label4);
            tbModificar.Font = new Font("Calibri", 12F);
            tbModificar.Location = new Point(4, 29);
            tbModificar.Name = "tbModificar";
            tbModificar.Size = new Size(1892, 917);
            tbModificar.TabIndex = 2;
            tbModificar.Text = "Modificar Usuario";
            tbModificar.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Administrador", "Empleado" });
            comboBox1.Location = new Point(1548, 482);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(159, 32);
            comboBox1.TabIndex = 38;
            // 
            // label10
            // 
            label10.Location = new Point(1442, 486);
            label10.Name = "label10";
            label10.Size = new Size(88, 28);
            label10.TabIndex = 37;
            label10.Text = "Rol";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(1548, 400);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(194, 32);
            textBox1.TabIndex = 40;
            // 
            // label5
            // 
            label5.Location = new Point(1442, 406);
            label5.Name = "label5";
            label5.Size = new Size(88, 26);
            label5.TabIndex = 39;
            label5.Text = "Telefono";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(1548, 329);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(338, 32);
            textBox2.TabIndex = 38;
            // 
            // label6
            // 
            label6.Location = new Point(1442, 332);
            label6.Name = "label6";
            label6.Size = new Size(88, 44);
            label6.TabIndex = 37;
            label6.Text = "Email \r\n(opcional)";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(1548, 247);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(338, 32);
            textBox3.TabIndex = 36;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(1548, 153);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(338, 32);
            textBox4.TabIndex = 35;
            // 
            // label7
            // 
            label7.Location = new Point(1442, 247);
            label7.Name = "label7";
            label7.Size = new Size(88, 34);
            label7.TabIndex = 34;
            label7.Text = "Apellidos";
            // 
            // label8
            // 
            label8.Location = new Point(1442, 156);
            label8.Name = "label8";
            label8.Size = new Size(88, 34);
            label8.TabIndex = 33;
            label8.Text = "Nombre";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(1548, 78);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(194, 32);
            textBox5.TabIndex = 32;
            // 
            // label9
            // 
            label9.Location = new Point(1442, 81);
            label9.Name = "label9";
            label9.Size = new Size(88, 34);
            label9.TabIndex = 31;
            label9.Text = "Usuario";
            // 
            // btnConfirmarCambios
            // 
            btnConfirmarCambios.Font = new Font("Calibri", 18F);
            btnConfirmarCambios.Location = new Point(870, 791);
            btnConfirmarCambios.Name = "btnConfirmarCambios";
            btnConfirmarCambios.Size = new Size(265, 59);
            btnConfirmarCambios.TabIndex = 9;
            btnConfirmarCambios.Text = "Confirmar Cambios";
            btnConfirmarCambios.UseVisualStyleBackColor = true;
            // 
            // dgvModificar
            // 
            dgvModificar.AllowUserToAddRows = false;
            dgvModificar.AllowUserToDeleteRows = false;
            dgvModificar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvModificar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvModificar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvModificar.GridColor = SystemColors.HighlightText;
            dgvModificar.Location = new Point(6, 78);
            dgvModificar.Name = "dgvModificar";
            dgvModificar.ReadOnly = true;
            dgvModificar.RowHeadersWidth = 51;
            dgvModificar.Size = new Size(1291, 543);
            dgvModificar.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 25F);
            label4.Location = new Point(668, 0);
            label4.Name = "label4";
            label4.Size = new Size(405, 49);
            label4.TabIndex = 7;
            label4.Text = "Modificar Usuarios";
            // 
            // CRUD_Empleados
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 944);
            Controls.Add(tabControl1);
            Name = "CRUD_Empleados";
            Text = "CRUD_Empleados";
            tabControl1.ResumeLayout(false);
            tbCrearUsuario.ResumeLayout(false);
            tbCrearUsuario.PerformLayout();
            tbEliminar.ResumeLayout(false);
            tbEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tbModificar.ResumeLayout(false);
            tbModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvModificar).EndInit();
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
        private Label label3;
        private Button btnEliminar;
        private DataGridView dgvUsuarios;
        private Label label4;
        private Button btnConfirmarCambios;
        private DataGridView dgvModificar;
        private ComboBox comboBox1;
        private Label label10;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox2;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label7;
        private Label label8;
        private TextBox textBox5;
        private Label label9;
    }
}