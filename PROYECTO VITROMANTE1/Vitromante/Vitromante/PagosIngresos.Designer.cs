namespace Vitromante
{
    partial class PagosIngresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagosIngresos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.DPagos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BFechaPag = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.DescripcionPag = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MontoPag = new System.Windows.Forms.TextBox();
            this.FechaPag = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BEliminarPag = new System.Windows.Forms.Button();
            this.BGuardarPag = new System.Windows.Forms.Button();
            this.BGuardarIng = new System.Windows.Forms.Button();
            this.BEliminarIng = new System.Windows.Forms.Button();
            this.FechaIng = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MontoIng = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DescripcionIng = new System.Windows.Forms.TextBox();
            this.BFechaIng = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DIngresos = new System.Windows.Forms.DataGridView();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DPagos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(916, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // DPagos
            // 
            this.DPagos.AllowUserToAddRows = false;
            this.DPagos.AllowUserToDeleteRows = false;
            this.DPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DPagos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DPagos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.DPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DPagos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DPagos.ColumnHeadersHeight = 30;
            this.DPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.Monto,
            this.Fecha});
            this.DPagos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DPagos.EnableHeadersVisualStyles = false;
            this.DPagos.Location = new System.Drawing.Point(25, 83);
            this.DPagos.Name = "DPagos";
            this.DPagos.ReadOnly = true;
            this.DPagos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DPagos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DPagos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.DPagos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DPagos.RowTemplate.Height = 30;
            this.DPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DPagos.Size = new System.Drawing.Size(422, 344);
            this.DPagos.TabIndex = 61;
            this.DPagos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Pagos_CellContentClick);
            this.DPagos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Pagos_CellContentDoubleClick);
            this.DPagos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Pagos_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 44;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 106;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Monto";
            this.Monto.HeaderText = "$Monto";
            this.Monto.Name = "Monto";
            this.Monto.ReadOnly = true;
            this.Monto.Width = 80;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 70;
            // 
            // BFechaPag
            // 
            this.BFechaPag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BFechaPag.Location = new System.Drawing.Point(125, 58);
            this.BFechaPag.Name = "BFechaPag";
            this.BFechaPag.Size = new System.Drawing.Size(209, 20);
            this.BFechaPag.TabIndex = 93;
            this.BFechaPag.ValueChanged += new System.EventHandler(this.fpp_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label10.Location = new System.Drawing.Point(28, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 19);
            this.label10.TabIndex = 92;
            this.label10.Text = "Pagos:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(94, 57);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 91;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label13.Location = new System.Drawing.Point(21, 437);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 19);
            this.label13.TabIndex = 95;
            this.label13.Text = "Descripcion:";
            // 
            // DescripcionPag
            // 
            this.DescripcionPag.Location = new System.Drawing.Point(171, 436);
            this.DescripcionPag.MaxLength = 10;
            this.DescripcionPag.Name = "DescripcionPag";
            this.DescripcionPag.Size = new System.Drawing.Size(276, 20);
            this.DescripcionPag.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(21, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 19);
            this.label1.TabIndex = 97;
            this.label1.Text = "Monto:                    $";
            // 
            // MontoPag
            // 
            this.MontoPag.Location = new System.Drawing.Point(171, 465);
            this.MontoPag.MaxLength = 8;
            this.MontoPag.Name = "MontoPag";
            this.MontoPag.Size = new System.Drawing.Size(276, 20);
            this.MontoPag.TabIndex = 96;
            this.MontoPag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // FechaPag
            // 
            this.FechaPag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FechaPag.Location = new System.Drawing.Point(171, 495);
            this.FechaPag.Name = "FechaPag";
            this.FechaPag.Size = new System.Drawing.Size(276, 20);
            this.FechaPag.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(21, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 19);
            this.label2.TabIndex = 98;
            this.label2.Text = "Fecha:";
            // 
            // BEliminarPag
            // 
            this.BEliminarPag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BEliminarPag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarPag.FlatAppearance.BorderSize = 0;
            this.BEliminarPag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BEliminarPag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarPag.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarPag.ForeColor = System.Drawing.Color.White;
            this.BEliminarPag.Location = new System.Drawing.Point(25, 538);
            this.BEliminarPag.Name = "BEliminarPag";
            this.BEliminarPag.Size = new System.Drawing.Size(195, 34);
            this.BEliminarPag.TabIndex = 100;
            this.BEliminarPag.Text = "Eliminar";
            this.BEliminarPag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BEliminarPag.UseVisualStyleBackColor = false;
            this.BEliminarPag.Click += new System.EventHandler(this.button1_Click);
            // 
            // BGuardarPag
            // 
            this.BGuardarPag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BGuardarPag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardarPag.FlatAppearance.BorderSize = 0;
            this.BGuardarPag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BGuardarPag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarPag.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarPag.ForeColor = System.Drawing.Color.White;
            this.BGuardarPag.Location = new System.Drawing.Point(252, 538);
            this.BGuardarPag.Name = "BGuardarPag";
            this.BGuardarPag.Size = new System.Drawing.Size(195, 34);
            this.BGuardarPag.TabIndex = 101;
            this.BGuardarPag.Text = "Guardar";
            this.BGuardarPag.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BGuardarPag.UseVisualStyleBackColor = false;
            this.BGuardarPag.Click += new System.EventHandler(this.button2_Click);
            // 
            // BGuardarIng
            // 
            this.BGuardarIng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BGuardarIng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BGuardarIng.FlatAppearance.BorderSize = 0;
            this.BGuardarIng.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BGuardarIng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BGuardarIng.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BGuardarIng.ForeColor = System.Drawing.Color.White;
            this.BGuardarIng.Location = new System.Drawing.Point(743, 538);
            this.BGuardarIng.Name = "BGuardarIng";
            this.BGuardarIng.Size = new System.Drawing.Size(195, 34);
            this.BGuardarIng.TabIndex = 113;
            this.BGuardarIng.Text = "Guardar";
            this.BGuardarIng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BGuardarIng.UseVisualStyleBackColor = false;
            this.BGuardarIng.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // BEliminarIng
            // 
            this.BEliminarIng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.BEliminarIng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BEliminarIng.FlatAppearance.BorderSize = 0;
            this.BEliminarIng.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BEliminarIng.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BEliminarIng.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BEliminarIng.ForeColor = System.Drawing.Color.White;
            this.BEliminarIng.Location = new System.Drawing.Point(516, 538);
            this.BEliminarIng.Name = "BEliminarIng";
            this.BEliminarIng.Size = new System.Drawing.Size(195, 34);
            this.BEliminarIng.TabIndex = 112;
            this.BEliminarIng.Text = "Eliminar";
            this.BEliminarIng.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.BEliminarIng.UseVisualStyleBackColor = false;
            this.BEliminarIng.Click += new System.EventHandler(this.BEliminarIng_Click);
            // 
            // FechaIng
            // 
            this.FechaIng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FechaIng.Location = new System.Drawing.Point(662, 495);
            this.FechaIng.Name = "FechaIng";
            this.FechaIng.Size = new System.Drawing.Size(276, 20);
            this.FechaIng.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label3.Location = new System.Drawing.Point(512, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 19);
            this.label3.TabIndex = 110;
            this.label3.Text = "Fecha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label4.Location = new System.Drawing.Point(512, 466);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 19);
            this.label4.TabIndex = 109;
            this.label4.Text = "Monto:                    $";
            // 
            // MontoIng
            // 
            this.MontoIng.Location = new System.Drawing.Point(662, 465);
            this.MontoIng.MaxLength = 8;
            this.MontoIng.Name = "MontoIng";
            this.MontoIng.Size = new System.Drawing.Size(276, 20);
            this.MontoIng.TabIndex = 108;
            this.MontoIng.TextChanged += new System.EventHandler(this.MontoIng_TextChanged);
            this.MontoIng.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MontoIng_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label5.Location = new System.Drawing.Point(512, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 19);
            this.label5.TabIndex = 107;
            this.label5.Text = "Descripcion:";
            // 
            // DescripcionIng
            // 
            this.DescripcionIng.Location = new System.Drawing.Point(662, 436);
            this.DescripcionIng.MaxLength = 100;
            this.DescripcionIng.Name = "DescripcionIng";
            this.DescripcionIng.Size = new System.Drawing.Size(276, 20);
            this.DescripcionIng.TabIndex = 106;
            // 
            // BFechaIng
            // 
            this.BFechaIng.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BFechaIng.Location = new System.Drawing.Point(626, 58);
            this.BFechaIng.Name = "BFechaIng";
            this.BFechaIng.Size = new System.Drawing.Size(209, 20);
            this.BFechaIng.TabIndex = 105;
            this.BFechaIng.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.label6.Location = new System.Drawing.Point(519, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 19);
            this.label6.TabIndex = 104;
            this.label6.Text = "Ingresos:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(595, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // DIngresos
            // 
            this.DIngresos.AllowUserToAddRows = false;
            this.DIngresos.AllowUserToDeleteRows = false;
            this.DIngresos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DIngresos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DIngresos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.DIngresos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DIngresos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DIngresos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DIngresos.ColumnHeadersHeight = 30;
            this.DIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID1,
            this.Descripcion1,
            this.Monto1,
            this.Fecha1});
            this.DIngresos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DIngresos.EnableHeadersVisualStyles = false;
            this.DIngresos.Location = new System.Drawing.Point(516, 83);
            this.DIngresos.Name = "DIngresos";
            this.DIngresos.ReadOnly = true;
            this.DIngresos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DIngresos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.DIngresos.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.DIngresos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DIngresos.RowTemplate.Height = 30;
            this.DIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DIngresos.Size = new System.Drawing.Size(422, 344);
            this.DIngresos.TabIndex = 102;
            this.DIngresos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DIngresos_CellContentClick);
            this.DIngresos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DIngresos_CellContentDoubleClick);
            // 
            // ID1
            // 
            this.ID1.DataPropertyName = "ID";
            this.ID1.HeaderText = "ID";
            this.ID1.Name = "ID1";
            this.ID1.ReadOnly = true;
            this.ID1.Width = 44;
            // 
            // Descripcion1
            // 
            this.Descripcion1.DataPropertyName = "Descripcion";
            this.Descripcion1.HeaderText = "Descripcion";
            this.Descripcion1.Name = "Descripcion1";
            this.Descripcion1.ReadOnly = true;
            this.Descripcion1.Width = 106;
            // 
            // Monto1
            // 
            this.Monto1.DataPropertyName = "Monto";
            this.Monto1.HeaderText = "$Monto";
            this.Monto1.Name = "Monto1";
            this.Monto1.ReadOnly = true;
            this.Monto1.Width = 80;
            // 
            // Fecha1
            // 
            this.Fecha1.DataPropertyName = "Fecha";
            this.Fecha1.HeaderText = "Fecha";
            this.Fecha1.Name = "Fecha1";
            this.Fecha1.ReadOnly = true;
            this.Fecha1.Width = 70;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(861, 57);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 23);
            this.button4.TabIndex = 114;
            this.button4.Text = "Imprimir";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(370, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 23);
            this.button1.TabIndex = 115;
            this.button1.Text = "Imprimir";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // PagosIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(960, 714);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.BGuardarIng);
            this.Controls.Add(this.BEliminarIng);
            this.Controls.Add(this.FechaIng);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MontoIng);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DescripcionIng);
            this.Controls.Add(this.BFechaIng);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DIngresos);
            this.Controls.Add(this.BGuardarPag);
            this.Controls.Add(this.BEliminarPag);
            this.Controls.Add(this.FechaPag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MontoPag);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.DescripcionPag);
            this.Controls.Add(this.BFechaPag);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.DPagos);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 36);
            this.Name = "PagosIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PagosIngresos";
            this.Load += new System.EventHandler(this.PagosIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DPagos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridView DPagos;
        private System.Windows.Forms.DateTimePicker BFechaPag;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox DescripcionPag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MontoPag;
        private System.Windows.Forms.DateTimePicker FechaPag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BEliminarPag;
        private System.Windows.Forms.Button BGuardarPag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.Button BGuardarIng;
        private System.Windows.Forms.Button BEliminarIng;
        private System.Windows.Forms.DateTimePicker FechaIng;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MontoIng;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DescripcionIng;
        private System.Windows.Forms.DateTimePicker BFechaIng;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView DIngresos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
    }
}