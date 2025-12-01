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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteConLimites));
            label1 = new Label();
            dtpFechaInicio = new DateTimePicker();
            dtpFechaFin = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dgvVentas = new DataGridView();
            btnGenerarGraficaMonto = new Button();
            clbProductos = new CheckedListBox();
            label4 = new Label();
            btnEliminarFiltros = new Button();
            btnGenerarGraficaCantidad = new Button();
            btnSalir = new Button();
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
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 46);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(993, 557);
            dgvVentas.TabIndex = 12;
            // 
            // btnGenerarGraficaMonto
            // 
            btnGenerarGraficaMonto.Location = new Point(20, 777);
            btnGenerarGraficaMonto.Name = "btnGenerarGraficaMonto";
            btnGenerarGraficaMonto.Size = new Size(330, 56);
            btnGenerarGraficaMonto.TabIndex = 13;
            btnGenerarGraficaMonto.Text = "Reporte por monto";
            btnGenerarGraficaMonto.UseVisualStyleBackColor = true;
            btnGenerarGraficaMonto.Click += btnGenerarGraficaMonto_Click;
            // 
            // clbProductos
            // 
            clbProductos.FormattingEnabled = true;
            clbProductos.Location = new Point(1454, 82);
            clbProductos.Name = "clbProductos";
            clbProductos.Size = new Size(253, 554);
            clbProductos.TabIndex = 14;
            clbProductos.ItemCheck += clbProductos_ItemCheck;
            clbProductos.KeyDown += clbProductos_KeyDown;
            // 
            // label4
            // 
            label4.Font = new Font("Arial Rounded MT Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(1454, 46);
            label4.Name = "label4";
            label4.Size = new Size(253, 27);
            label4.TabIndex = 15;
            label4.Text = "Filtrar por Productos";
            // 
            // btnEliminarFiltros
            // 
            btnEliminarFiltros.Location = new Point(1530, 648);
            btnEliminarFiltros.Name = "btnEliminarFiltros";
            btnEliminarFiltros.Size = new Size(118, 56);
            btnEliminarFiltros.TabIndex = 17;
            btnEliminarFiltros.Text = "Quitar Filtros";
            btnEliminarFiltros.UseVisualStyleBackColor = true;
            btnEliminarFiltros.Click += btnEliminarFiltros_Click;
            // 
            // btnGenerarGraficaCantidad
            // 
            btnGenerarGraficaCantidad.Location = new Point(356, 777);
            btnGenerarGraficaCantidad.Name = "btnGenerarGraficaCantidad";
            btnGenerarGraficaCantidad.Size = new Size(330, 56);
            btnGenerarGraficaCantidad.TabIndex = 18;
            btnGenerarGraficaCantidad.Text = "Reporte por cantidad";
            btnGenerarGraficaCantidad.UseVisualStyleBackColor = true;
            btnGenerarGraficaCantidad.Click += btnGenerarGraficaCantidad_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Transparent;
            btnSalir.Font = new Font("Calibri", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = Color.White;
            btnSalir.Image = Properties.Resources.rojo;
            btnSalir.Location = new Point(12, 935);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 39;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // ReporteConLimites
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1837, 976);
            Controls.Add(btnSalir);
            Controls.Add(btnGenerarGraficaCantidad);
            Controls.Add(btnEliminarFiltros);
            Controls.Add(label4);
            Controls.Add(clbProductos);
            Controls.Add(btnGenerarGraficaMonto);
            Controls.Add(dgvVentas);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dtpFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private Button btnGenerarGraficaMonto;
        private CheckedListBox clbProductos;
        private Label label4;
        private Button btnEliminarFiltros;
        private Button btnGenerarGraficaCantidad;
        private Button btnSalir;
    }
}