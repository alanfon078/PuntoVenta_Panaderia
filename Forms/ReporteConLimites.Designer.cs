namespace Panaderia.Forms
{
    partial class ReporteConLimites
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
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dgvVentas = new DataGridView();
            btnGenerarGrafica = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(699, 9);
            label1.Name = "label1";
            label1.Size = new Size(474, 34);
            label1.TabIndex = 7;
            label1.Text = "Reporte de Venta por Producto";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(157, 609);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(123, 27);
            dtpFechaInicio.TabIndex = 8;
            dtpFechaInicio.ValueChanged += dtpFechaInicio_ValueChanged;
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(157, 666);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(123, 27);
            dtpFechaFin.TabIndex = 9;
            dtpFechaFin.ValueChanged += dtpFechaFin_ValueChanged;
            // 
            // label2
            // 
            label2.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 609);
            label2.Name = "label2";
            label2.Size = new Size(123, 27);
            label2.TabIndex = 10;
            label2.Text = "Fecha inicio:";
            // 
            // label3
            // 
            label3.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 666);
            label3.Name = "label3";
            label3.Size = new Size(123, 27);
            label3.TabIndex = 11;
            label3.Text = "Fecha fin:";
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 46);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1797, 557);
            dgvVentas.TabIndex = 12;
            // 
            // btnGenerarGrafica
            // 
            btnGenerarGrafica.Location = new Point(20, 796);
            btnGenerarGrafica.Name = "btnGenerarGrafica";
            btnGenerarGrafica.Size = new Size(330, 56);
            btnGenerarGrafica.TabIndex = 13;
            btnGenerarGrafica.Text = "Generar Grafica";
            btnGenerarGrafica.UseVisualStyleBackColor = true;
            // 
            // ReporteConLimites
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1837, 976);
            Controls.Add(btnGenerarGrafica);
            Controls.Add(dgvVentas);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label1);
            Name = "ReporteConLimites";
            Text = "ReporteConLimites";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dtpFechaInicio;
        private DateTimePicker dtpFechaFin;
        private Label label2;
        private Label label3;
        private DataGridView dgvVentas;
        private Button btnGenerarGrafica;
    }
}