namespace Panaderia.Forms
{
    partial class MenuAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuAdmin));
            btnRegistrarUsuarios = new Button();
            btnAdministrarProductos = new Button();
            btnRegistrarVenta = new Button();
            btnEliminarUsuarios = new Button();
            label1 = new Label();
            btnSalir = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // btnRegistrarUsuarios
            // 
            btnRegistrarUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarUsuarios.Location = new Point(132, 143);
            btnRegistrarUsuarios.Name = "btnRegistrarUsuarios";
            btnRegistrarUsuarios.Size = new Size(232, 85);
            btnRegistrarUsuarios.TabIndex = 2;
            btnRegistrarUsuarios.Text = "Administrar Usuarios";
            btnRegistrarUsuarios.UseVisualStyleBackColor = true;
            btnRegistrarUsuarios.Click += btnRegistrarUsuarios_Click;
            btnRegistrarUsuarios.KeyDown += btnRegistrarUsuarios_KeyDown;
            btnRegistrarUsuarios.PreviewKeyDown += btnRegistrarUsuarios_PreviewKeyDown;
            // 
            // btnAdministrarProductos
            // 
            btnAdministrarProductos.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdministrarProductos.Location = new Point(502, 143);
            btnAdministrarProductos.Name = "btnAdministrarProductos";
            btnAdministrarProductos.Size = new Size(232, 85);
            btnAdministrarProductos.TabIndex = 3;
            btnAdministrarProductos.Text = "Administrar Productos";
            btnAdministrarProductos.UseVisualStyleBackColor = true;
            btnAdministrarProductos.Click += btnRegistrarProductos_Click;
            btnAdministrarProductos.KeyDown += btnRegistrarProductos_KeyDown;
            btnAdministrarProductos.PreviewKeyDown += btnRegistrarProductos_PreviewKeyDown;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegistrarVenta.Location = new Point(502, 275);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(232, 85);
            btnRegistrarVenta.TabIndex = 4;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            btnRegistrarVenta.KeyDown += btnRegistrarVenta_KeyDown;
            btnRegistrarVenta.PreviewKeyDown += btnRegistrarVenta_PreviewKeyDown;
            // 
            // btnEliminarUsuarios
            // 
            btnEliminarUsuarios.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarUsuarios.Location = new Point(132, 275);
            btnEliminarUsuarios.Name = "btnEliminarUsuarios";
            btnEliminarUsuarios.Size = new Size(232, 85);
            btnEliminarUsuarios.TabIndex = 5;
            btnEliminarUsuarios.Text = "Reporte de Ventas";
            btnEliminarUsuarios.UseVisualStyleBackColor = true;
            btnEliminarUsuarios.Click += btnEliminarUsuarios_Click;
            btnEliminarUsuarios.KeyDown += btnEliminarUsuarios_KeyDown;
            btnEliminarUsuarios.PreviewKeyDown += btnEliminarUsuarios_PreviewKeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Image = Properties.Resources.beige;
            label1.Location = new Point(245, 48);
            label1.Name = "label1";
            label1.Size = new Size(357, 34);
            label1.TabIndex = 6;
            label1.Text = "Menu de Administrador";
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Image = Properties.Resources.rojo;
            btnSalir.Location = new Point(760, 436);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.beige;
            pictureBox1.Image = Properties.Resources.beige;
            pictureBox1.Location = new Point(-9, -22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(894, 231);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(1, 194);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(898, 322);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 477);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            Controls.Add(btnEliminarUsuarios);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(btnAdministrarProductos);
            Controls.Add(btnRegistrarUsuarios);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuAdmin";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnRegistrarUsuarios;
        private Button btnAdministrarProductos;
        private Button btnRegistrarVenta;
        private Button btnEliminarUsuarios;
        private Label label1;
        private Button btnSalir;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
    }
}