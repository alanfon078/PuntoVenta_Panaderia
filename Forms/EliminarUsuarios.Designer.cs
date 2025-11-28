namespace Panaderia.Forms
{
    partial class EliminarUsuarios
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
            dgvUsuarios = new DataGridView();
            btnEliminar = new Button();
            txtRegistro = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.GridColor = SystemColors.HighlightText;
            dgvUsuarios.Location = new Point(12, 96);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(1000, 398);
            dgvUsuarios.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1023, 505);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(102, 29);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // txtRegistro
            // 
            txtRegistro.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRegistro.Location = new Point(254, 12);
            txtRegistro.Name = "txtRegistro";
            txtRegistro.ReadOnly = true;
            txtRegistro.Size = new Size(367, 38);
            txtRegistro.TabIndex = 2;
            txtRegistro.Text = "Eliminar Usuarios";
            txtRegistro.TextAlign = HorizontalAlignment.Center;
            // 
            // EliminarUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1162, 546);
            Controls.Add(txtRegistro);
            Controls.Add(btnEliminar);
            Controls.Add(dgvUsuarios);
            Name = "EliminarUsuarios";
            Text = "EliminarUsuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvUsuarios;
        private Button btnEliminar;
        private TextBox txtRegistro;
    }
}