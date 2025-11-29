namespace Panaderia
{
    partial class frmProductos
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
            Label lblPrecio;
            tbCtrlProductos = new TabControl();
            tbEliminar = new TabPage();
            btnEliminar = new Button();
            dgvLista = new DataGridView();
            btnRight = new Button();
            btnLeft = new Button();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox11 = new PictureBox();
            pictureBox12 = new PictureBox();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            tbAgregar = new TabPage();
            nudStock = new NumericUpDown();
            btnAgregarProducto = new Button();
            lblStockvp = new Label();
            lblPreciovp = new Label();
            lblNombrevp = new Label();
            picBoxvp = new PictureBox();
            label13 = new Label();
            btnSelectImg = new Button();
            lblStock = new Label();
            txtPrecio = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            tbModificar = new TabPage();
            ofdArchivo = new OpenFileDialog();
            lblPrecio = new Label();
            tbCtrlProductos.SuspendLayout();
            tbEliminar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tbAgregar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picBoxvp).BeginInit();
            SuspendLayout();
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Calibri", 12F);
            lblPrecio.Location = new Point(20, 172);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(61, 24);
            lblPrecio.TabIndex = 8;
            lblPrecio.Text = "Precio";
            // 
            // tbCtrlProductos
            // 
            tbCtrlProductos.Controls.Add(tbEliminar);
            tbCtrlProductos.Controls.Add(tbAgregar);
            tbCtrlProductos.Controls.Add(tbModificar);
            tbCtrlProductos.Location = new Point(1, 12);
            tbCtrlProductos.Name = "tbCtrlProductos";
            tbCtrlProductos.SelectedIndex = 0;
            tbCtrlProductos.Size = new Size(1761, 837);
            tbCtrlProductos.TabIndex = 0;
            // 
            // tbEliminar
            // 
            tbEliminar.Controls.Add(btnEliminar);
            tbEliminar.Controls.Add(dgvLista);
            tbEliminar.Controls.Add(btnRight);
            tbEliminar.Controls.Add(btnLeft);
            tbEliminar.Controls.Add(label12);
            tbEliminar.Controls.Add(label11);
            tbEliminar.Controls.Add(label10);
            tbEliminar.Controls.Add(label9);
            tbEliminar.Controls.Add(label8);
            tbEliminar.Controls.Add(label7);
            tbEliminar.Controls.Add(label6);
            tbEliminar.Controls.Add(label5);
            tbEliminar.Controls.Add(label4);
            tbEliminar.Controls.Add(label3);
            tbEliminar.Controls.Add(label2);
            tbEliminar.Controls.Add(label1);
            tbEliminar.Controls.Add(pictureBox5);
            tbEliminar.Controls.Add(pictureBox6);
            tbEliminar.Controls.Add(pictureBox11);
            tbEliminar.Controls.Add(pictureBox12);
            tbEliminar.Controls.Add(pictureBox10);
            tbEliminar.Controls.Add(pictureBox9);
            tbEliminar.Controls.Add(pictureBox8);
            tbEliminar.Controls.Add(pictureBox7);
            tbEliminar.Controls.Add(pictureBox4);
            tbEliminar.Controls.Add(pictureBox3);
            tbEliminar.Controls.Add(pictureBox2);
            tbEliminar.Controls.Add(pictureBox1);
            tbEliminar.Location = new Point(4, 29);
            tbEliminar.Name = "tbEliminar";
            tbEliminar.Padding = new Padding(3);
            tbEliminar.Size = new Size(1753, 804);
            tbEliminar.TabIndex = 1;
            tbEliminar.Text = "Eliminar";
            tbEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnEliminar.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminar.ForeColor = Color.Red;
            btnEliminar.Location = new Point(1046, 645);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(203, 52);
            btnEliminar.TabIndex = 59;
            btnEliminar.Text = "Eliminar Productos";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvLista
            // 
            dgvLista.AllowUserToAddRows = false;
            dgvLista.AllowUserToDeleteRows = false;
            dgvLista.AllowUserToResizeColumns = false;
            dgvLista.AllowUserToResizeRows = false;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgvLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLista.Location = new Point(1046, 5);
            dgvLista.Name = "dgvLista";
            dgvLista.RowHeadersWidth = 51;
            dgvLista.Size = new Size(701, 635);
            dgvLista.TabIndex = 58;
            // 
            // btnRight
            // 
            btnRight.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold);
            btnRight.Location = new Point(907, 360);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(75, 68);
            btnRight.TabIndex = 57;
            btnRight.Text = ">";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // btnLeft
            // 
            btnLeft.Font = new Font("Showcard Gothic", 19.8000011F, FontStyle.Bold);
            btnLeft.Location = new Point(7, 347);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(75, 68);
            btnLeft.TabIndex = 56;
            btnLeft.Text = "<";
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(743, 701);
            label12.Name = "label12";
            label12.Size = new Size(58, 20);
            label12.TabIndex = 55;
            label12.Text = "label12";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(505, 701);
            label11.Name = "label11";
            label11.Size = new Size(58, 20);
            label11.TabIndex = 54;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(299, 701);
            label10.Name = "label10";
            label10.Size = new Size(58, 20);
            label10.TabIndex = 53;
            label10.Text = "label10";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(139, 701);
            label9.Name = "label9";
            label9.Size = new Size(50, 20);
            label9.TabIndex = 52;
            label9.Text = "label9";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(743, 469);
            label8.Name = "label8";
            label8.Size = new Size(50, 20);
            label8.TabIndex = 51;
            label8.Text = "label8";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(505, 469);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 50;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(299, 469);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 49;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(151, 469);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 48;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(743, 227);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 47;
            label4.Text = "label4";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(505, 227);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 46;
            label3.Text = "label3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 227);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 45;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(139, 227);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 44;
            label1.Text = "label1";
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Gainsboro;
            pictureBox5.Location = new Point(743, 543);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(159, 155);
            pictureBox5.TabIndex = 43;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Gainsboro;
            pictureBox6.Location = new Point(505, 543);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(159, 155);
            pictureBox6.TabIndex = 42;
            pictureBox6.TabStop = false;
            // 
            // pictureBox11
            // 
            pictureBox11.BackColor = Color.Gainsboro;
            pictureBox11.Location = new Point(299, 543);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(163, 155);
            pictureBox11.TabIndex = 41;
            pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            pictureBox12.BackColor = Color.Gainsboro;
            pictureBox12.Location = new Point(89, 543);
            pictureBox12.Name = "pictureBox12";
            pictureBox12.Size = new Size(162, 155);
            pictureBox12.TabIndex = 40;
            pictureBox12.TabStop = false;
            // 
            // pictureBox10
            // 
            pictureBox10.BackColor = Color.Gainsboro;
            pictureBox10.Location = new Point(743, 312);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(159, 155);
            pictureBox10.TabIndex = 39;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackColor = Color.Gainsboro;
            pictureBox9.Location = new Point(505, 312);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(159, 155);
            pictureBox9.TabIndex = 38;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackColor = Color.Gainsboro;
            pictureBox8.Location = new Point(299, 312);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(163, 155);
            pictureBox8.TabIndex = 37;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackColor = Color.Gainsboro;
            pictureBox7.Location = new Point(89, 312);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(162, 155);
            pictureBox7.TabIndex = 36;
            pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Gainsboro;
            pictureBox4.Location = new Point(743, 69);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(159, 155);
            pictureBox4.TabIndex = 35;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Gainsboro;
            pictureBox3.Location = new Point(505, 69);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(159, 155);
            pictureBox3.TabIndex = 34;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Gainsboro;
            pictureBox2.Location = new Point(299, 69);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(163, 155);
            pictureBox2.TabIndex = 33;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Gainsboro;
            pictureBox1.Location = new Point(89, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(162, 155);
            pictureBox1.TabIndex = 32;
            pictureBox1.TabStop = false;
            // 
            // tbAgregar
            // 
            tbAgregar.Controls.Add(nudStock);
            tbAgregar.Controls.Add(btnAgregarProducto);
            tbAgregar.Controls.Add(lblStockvp);
            tbAgregar.Controls.Add(lblPreciovp);
            tbAgregar.Controls.Add(lblNombrevp);
            tbAgregar.Controls.Add(picBoxvp);
            tbAgregar.Controls.Add(label13);
            tbAgregar.Controls.Add(btnSelectImg);
            tbAgregar.Controls.Add(lblStock);
            tbAgregar.Controls.Add(lblPrecio);
            tbAgregar.Controls.Add(txtPrecio);
            tbAgregar.Controls.Add(lblNombre);
            tbAgregar.Controls.Add(txtNombre);
            tbAgregar.Location = new Point(4, 29);
            tbAgregar.Name = "tbAgregar";
            tbAgregar.Padding = new Padding(3);
            tbAgregar.Size = new Size(1753, 804);
            tbAgregar.TabIndex = 2;
            tbAgregar.Text = "Agregar";
            tbAgregar.UseVisualStyleBackColor = true;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(18, 318);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(193, 27);
            nudStock.TabIndex = 21;
            nudStock.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudStock.ValueChanged += nudPrecio_ValueChanged;
            nudStock.TabIndexChanged += nudStock_TabIndexChanged;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregarProducto.Location = new Point(330, 502);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(191, 50);
            btnAgregarProducto.TabIndex = 20;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // lblStockvp
            // 
            lblStockvp.AutoSize = true;
            lblStockvp.Font = new Font("Calibri", 12F);
            lblStockvp.Location = new Point(1049, 382);
            lblStockvp.Name = "lblStockvp";
            lblStockvp.Size = new Size(74, 24);
            lblStockvp.TabIndex = 16;
            lblStockvp.Text = "Stock: 1";
            // 
            // lblPreciovp
            // 
            lblPreciovp.AutoSize = true;
            lblPreciovp.Font = new Font("Calibri", 12F);
            lblPreciovp.Location = new Point(1049, 342);
            lblPreciovp.Name = "lblPreciovp";
            lblPreciovp.Size = new Size(81, 24);
            lblPreciovp.TabIndex = 15;
            lblPreciovp.Text = "Precio: $";
            // 
            // lblNombrevp
            // 
            lblNombrevp.AutoSize = true;
            lblNombrevp.Font = new Font("Calibri", 12F);
            lblNombrevp.Location = new Point(1049, 304);
            lblNombrevp.Name = "lblNombrevp";
            lblNombrevp.Size = new Size(83, 24);
            lblNombrevp.TabIndex = 14;
            lblNombrevp.Text = "Nombre ";
            // 
            // picBoxvp
            // 
            picBoxvp.Location = new Point(1049, 91);
            picBoxvp.Name = "picBoxvp";
            picBoxvp.Size = new Size(238, 210);
            picBoxvp.TabIndex = 13;
            picBoxvp.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Calibri", 12F);
            label13.Location = new Point(1049, 53);
            label13.Name = "label13";
            label13.Size = new Size(107, 24);
            label13.TabIndex = 12;
            label13.Text = "Vista Previa";
            // 
            // btnSelectImg
            // 
            btnSelectImg.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSelectImg.Location = new Point(20, 405);
            btnSelectImg.Name = "btnSelectImg";
            btnSelectImg.Size = new Size(191, 50);
            btnSelectImg.TabIndex = 11;
            btnSelectImg.Text = "Seleccionar imagen";
            btnSelectImg.UseVisualStyleBackColor = true;
            btnSelectImg.Click += btnSelectImg_Click;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Font = new Font("Calibri", 12F);
            lblStock.Location = new Point(20, 291);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(148, 24);
            lblStock.TabIndex = 10;
            lblStock.Text = "Stock Disponible";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(20, 195);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(763, 27);
            txtPrecio.TabIndex = 7;
            txtPrecio.TextChanged += txtPrecio_TextChanged;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Calibri", 12F);
            lblNombre.Location = new Point(20, 53);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(191, 24);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre del producto";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(20, 76);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(763, 27);
            txtNombre.TabIndex = 1;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // tbModificar
            // 
            tbModificar.Location = new Point(4, 29);
            tbModificar.Name = "tbModificar";
            tbModificar.Size = new Size(1753, 804);
            tbModificar.TabIndex = 3;
            tbModificar.Text = "Modificar";
            tbModificar.UseVisualStyleBackColor = true;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1809, 898);
            Controls.Add(tbCtrlProductos);
            Name = "frmProductos";
            Text = "Administrar Productos";
            tbCtrlProductos.ResumeLayout(false);
            tbEliminar.ResumeLayout(false);
            tbEliminar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox12).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tbAgregar.ResumeLayout(false);
            tbAgregar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picBoxvp).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbCtrlProductos;
        private TabPage tabPage1;
        private TabPage tbEliminar;
        private TabPage tbAgregar;
        private TabPage tbModificar;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox11;
        private PictureBox pictureBox12;
        private PictureBox pictureBox10;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnLeft;
        private Button btnRight;
        private Button btnEliminar;
        private DataGridView dgvLista;
        private OpenFileDialog ofdArchivo;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblPrecio;
        private TextBox txtPrecio;
        private Label lblStock;
        private Button btnSelectImg;
        private Label label13;
        private Label lblNombrevp;
        private PictureBox picBoxvp;
        private Label lblPreciovp;
        private Label lblStockvp;
        private Button btnAgregarProducto;
        private NumericUpDown nudStock;
    }
}