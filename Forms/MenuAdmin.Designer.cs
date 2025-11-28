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
            txtRegistro = new TextBox();
            btnRegistrarUsuarios = new Button();
            button1 = new Button();
            btnRegistrarVenta = new Button();
            btnEliminarUsuarios = new Button();
            SuspendLayout();
            // 
            // txtRegistro
            // 
            txtRegistro.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegistro.Location = new Point(174, 21);
            txtRegistro.Name = "txtRegistro";
            txtRegistro.Size = new Size(367, 38);
            txtRegistro.TabIndex = 1;
            txtRegistro.Text = "Menu de Administrador";
            txtRegistro.TextAlign = HorizontalAlignment.Center;
            // 
            // btnRegistrarUsuarios
            // 
            btnRegistrarUsuarios.Location = new Point(67, 139);
            btnRegistrarUsuarios.Name = "btnRegistrarUsuarios";
            btnRegistrarUsuarios.Size = new Size(232, 85);
            btnRegistrarUsuarios.TabIndex = 2;
            btnRegistrarUsuarios.Text = "Registrar Usuarios";
            btnRegistrarUsuarios.UseVisualStyleBackColor = true;
            btnRegistrarUsuarios.Click += btnRegistrarUsuarios_Click;
            // 
            // button1
            // 
            button1.Location = new Point(437, 139);
            button1.Name = "button1";
            button1.Size = new Size(232, 85);
            button1.TabIndex = 3;
            button1.Text = "Registrar Productos";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(437, 271);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(232, 85);
            btnRegistrarVenta.TabIndex = 4;
            btnRegistrarVenta.Text = "Registrar Venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // btnEliminarUsuarios
            // 
            btnEliminarUsuarios.Location = new Point(67, 271);
            btnEliminarUsuarios.Name = "btnEliminarUsuarios";
            btnEliminarUsuarios.Size = new Size(232, 85);
            btnEliminarUsuarios.TabIndex = 5;
            btnEliminarUsuarios.Text = "Eliminarr Usuarios";
            btnEliminarUsuarios.UseVisualStyleBackColor = true;
            btnEliminarUsuarios.Click += btnEliminarUsuarios_Click;
            // 
            // MenuAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 424);
            Controls.Add(btnEliminarUsuarios);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(button1);
            Controls.Add(btnRegistrarUsuarios);
            Controls.Add(txtRegistro);
            Name = "MenuAdmin";
            Text = "MenuAdmin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtRegistro;
        private Button btnRegistrarUsuarios;
        private Button button1;
        private Button btnRegistrarVenta;
        private Button btnEliminarUsuarios;
    }
}