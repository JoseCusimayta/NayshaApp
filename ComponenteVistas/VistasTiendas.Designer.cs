namespace ComponenteVistas
{
    partial class VistasTiendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistasTiendas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tb_alquiler = new System.Windows.Forms.TextBox();
            this.tb_fecha = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_orden = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.cb_estado = new System.Windows.Forms.ComboBox();
            this.tb_tienda = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_vendedor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_nuevo = new System.Windows.Forms.Button();
            this.b_modificar = new System.Windows.Forms.Button();
            this.b_historial = new System.Windows.Forms.Button();
            this.b_eliminar = new System.Windows.Forms.Button();
            this.b_cancelar = new System.Windows.Forms.Button();
            this.b_guardar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.b_imprimir = new System.Windows.Forms.Button();
            this.b_salir = new System.Windows.Forms.Button();
            this.b_final = new System.Windows.Forms.Button();
            this.b_siguiente = new System.Windows.Forms.Button();
            this.b_anterior = new System.Windows.Forms.Button();
            this.b_inicio = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.tb_alquiler);
            this.panel1.Controls.Add(this.tb_fecha);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Fecha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tb_orden);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tb_codigo);
            this.panel1.Controls.Add(this.cb_estado);
            this.panel1.Controls.Add(this.tb_tienda);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tb_vendedor);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(910, 173);
            this.panel1.TabIndex = 54;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(599, 137);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 20;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(227, 137);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 19;
            // 
            // tb_alquiler
            // 
            this.tb_alquiler.Enabled = false;
            this.tb_alquiler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_alquiler.Location = new System.Drawing.Point(599, 102);
            this.tb_alquiler.MaxLength = 8;
            this.tb_alquiler.Name = "tb_alquiler";
            this.tb_alquiler.Size = new System.Drawing.Size(125, 23);
            this.tb_alquiler.TabIndex = 18;
            this.tb_alquiler.Tag = "Precio al por menor";
            this.tb_alquiler.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_alquiler_KeyPress);
            // 
            // tb_fecha
            // 
            this.tb_fecha.Enabled = false;
            this.tb_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_fecha.Location = new System.Drawing.Point(599, 13);
            this.tb_fecha.Name = "tb_fecha";
            this.tb_fecha.Size = new System.Drawing.Size(125, 23);
            this.tb_fecha.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(540, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Alquiler";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fecha.Location = new System.Drawing.Point(540, 19);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(47, 17);
            this.Fecha.TabIndex = 16;
            this.Fecha.Text = "Fecha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // tb_orden
            // 
            this.tb_orden.Enabled = false;
            this.tb_orden.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_orden.Location = new System.Drawing.Point(227, 19);
            this.tb_orden.Name = "tb_orden";
            this.tb_orden.Size = new System.Drawing.Size(100, 23);
            this.tb_orden.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(120, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tienda";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(120, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Orden";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(120, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Vendedor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(118, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Inicio";
            // 
            // tb_codigo
            // 
            this.tb_codigo.Enabled = false;
            this.tb_codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_codigo.Location = new System.Drawing.Point(227, 48);
            this.tb_codigo.MaxLength = 6;
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(100, 23);
            this.tb_codigo.TabIndex = 4;
            this.tb_codigo.Tag = "Codigo";
            this.tb_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_codigo_KeyPress);
            // 
            // cb_estado
            // 
            this.cb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estado.Enabled = false;
            this.cb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.Items.AddRange(new object[] {
            "Activo",
            "En Espera",
            "Anulado"});
            this.cb_estado.Location = new System.Drawing.Point(599, 46);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(125, 24);
            this.cb_estado.TabIndex = 11;
            this.cb_estado.TabStop = false;
            // 
            // tb_tienda
            // 
            this.tb_tienda.Enabled = false;
            this.tb_tienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tienda.Location = new System.Drawing.Point(227, 76);
            this.tb_tienda.MaxLength = 50;
            this.tb_tienda.Name = "tb_tienda";
            this.tb_tienda.Size = new System.Drawing.Size(497, 23);
            this.tb_tienda.TabIndex = 5;
            this.tb_tienda.Tag = "Nombre de Prenda";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(484, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Fecha de Cierre";
            // 
            // tb_vendedor
            // 
            this.tb_vendedor.Enabled = false;
            this.tb_vendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_vendedor.Location = new System.Drawing.Point(227, 105);
            this.tb_vendedor.MaxLength = 20;
            this.tb_vendedor.Name = "tb_vendedor";
            this.tb_vendedor.Size = new System.Drawing.Size(100, 23);
            this.tb_vendedor.TabIndex = 6;
            this.tb_vendedor.Tag = "Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(540, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Estado";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.Controls.Add(this.b_nuevo);
            this.panel2.Controls.Add(this.b_modificar);
            this.panel2.Controls.Add(this.b_historial);
            this.panel2.Controls.Add(this.b_eliminar);
            this.panel2.Controls.Add(this.b_cancelar);
            this.panel2.Controls.Add(this.b_guardar);
            this.panel2.Location = new System.Drawing.Point(22, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 33);
            this.panel2.TabIndex = 55;
            // 
            // b_nuevo
            // 
            this.b_nuevo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_nuevo.Location = new System.Drawing.Point(81, 5);
            this.b_nuevo.Name = "b_nuevo";
            this.b_nuevo.Size = new System.Drawing.Size(120, 25);
            this.b_nuevo.TabIndex = 19;
            this.b_nuevo.TabStop = false;
            this.b_nuevo.Text = "Nuevo";
            this.b_nuevo.UseVisualStyleBackColor = true;
            this.b_nuevo.Click += new System.EventHandler(this.b_nuevo_Click);
            // 
            // b_modificar
            // 
            this.b_modificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_modificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_modificar.Location = new System.Drawing.Point(207, 5);
            this.b_modificar.Name = "b_modificar";
            this.b_modificar.Size = new System.Drawing.Size(120, 25);
            this.b_modificar.TabIndex = 16;
            this.b_modificar.TabStop = false;
            this.b_modificar.Text = "Modificar";
            this.b_modificar.UseVisualStyleBackColor = true;
            this.b_modificar.Click += new System.EventHandler(this.b_modificar_Click);
            // 
            // b_historial
            // 
            this.b_historial.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_historial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_historial.Location = new System.Drawing.Point(711, 5);
            this.b_historial.Name = "b_historial";
            this.b_historial.Size = new System.Drawing.Size(120, 25);
            this.b_historial.TabIndex = 21;
            this.b_historial.TabStop = false;
            this.b_historial.Text = "Historial";
            this.b_historial.UseVisualStyleBackColor = true;
            this.b_historial.Click += new System.EventHandler(this.b_historial_Click);
            // 
            // b_eliminar
            // 
            this.b_eliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_eliminar.Enabled = false;
            this.b_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_eliminar.Location = new System.Drawing.Point(333, 5);
            this.b_eliminar.Name = "b_eliminar";
            this.b_eliminar.Size = new System.Drawing.Size(120, 25);
            this.b_eliminar.TabIndex = 17;
            this.b_eliminar.TabStop = false;
            this.b_eliminar.Text = "Eliminar";
            this.b_eliminar.UseVisualStyleBackColor = true;
            this.b_eliminar.Click += new System.EventHandler(this.b_eliminar_Click);
            // 
            // b_cancelar
            // 
            this.b_cancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_cancelar.Enabled = false;
            this.b_cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_cancelar.Location = new System.Drawing.Point(585, 5);
            this.b_cancelar.Name = "b_cancelar";
            this.b_cancelar.Size = new System.Drawing.Size(120, 25);
            this.b_cancelar.TabIndex = 20;
            this.b_cancelar.TabStop = false;
            this.b_cancelar.Text = "Cancelar";
            this.b_cancelar.UseVisualStyleBackColor = true;
            this.b_cancelar.Click += new System.EventHandler(this.b_cancelar_Click);
            // 
            // b_guardar
            // 
            this.b_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.b_guardar.Enabled = false;
            this.b_guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_guardar.Location = new System.Drawing.Point(459, 5);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(120, 25);
            this.b_guardar.TabIndex = 18;
            this.b_guardar.TabStop = false;
            this.b_guardar.Text = "Guardar";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(950, 283);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.Controls.Add(this.b_imprimir);
            this.panel3.Controls.Add(this.b_salir);
            this.panel3.Controls.Add(this.b_final);
            this.panel3.Controls.Add(this.b_siguiente);
            this.panel3.Controls.Add(this.b_anterior);
            this.panel3.Controls.Add(this.b_inicio);
            this.panel3.Location = new System.Drawing.Point(22, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(910, 30);
            this.panel3.TabIndex = 58;
            // 
            // b_imprimir
            // 
            this.b_imprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.b_imprimir.Location = new System.Drawing.Point(711, 3);
            this.b_imprimir.Name = "b_imprimir";
            this.b_imprimir.Size = new System.Drawing.Size(120, 25);
            this.b_imprimir.TabIndex = 23;
            this.b_imprimir.TabStop = false;
            this.b_imprimir.Text = "Vista Previa";
            this.b_imprimir.UseVisualStyleBackColor = true;
            this.b_imprimir.Click += new System.EventHandler(this.b_imprimir_Click);
            // 
            // b_salir
            // 
            this.b_salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_salir.Location = new System.Drawing.Point(585, 3);
            this.b_salir.Name = "b_salir";
            this.b_salir.Size = new System.Drawing.Size(120, 25);
            this.b_salir.TabIndex = 64;
            this.b_salir.TabStop = false;
            this.b_salir.Text = "Salir";
            this.b_salir.UseVisualStyleBackColor = true;
            this.b_salir.Click += new System.EventHandler(this.b_salir_Click);
            // 
            // b_final
            // 
            this.b_final.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_final.Location = new System.Drawing.Point(459, 3);
            this.b_final.Name = "b_final";
            this.b_final.Size = new System.Drawing.Size(120, 25);
            this.b_final.TabIndex = 63;
            this.b_final.TabStop = false;
            this.b_final.Text = ">>";
            this.b_final.UseVisualStyleBackColor = true;
            this.b_final.Click += new System.EventHandler(this.b_final_Click);
            // 
            // b_siguiente
            // 
            this.b_siguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_siguiente.Location = new System.Drawing.Point(333, 3);
            this.b_siguiente.Name = "b_siguiente";
            this.b_siguiente.Size = new System.Drawing.Size(120, 25);
            this.b_siguiente.TabIndex = 62;
            this.b_siguiente.TabStop = false;
            this.b_siguiente.Text = ">";
            this.b_siguiente.UseVisualStyleBackColor = true;
            this.b_siguiente.Click += new System.EventHandler(this.b_siguiente_Click);
            // 
            // b_anterior
            // 
            this.b_anterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_anterior.Location = new System.Drawing.Point(207, 3);
            this.b_anterior.Name = "b_anterior";
            this.b_anterior.Size = new System.Drawing.Size(120, 25);
            this.b_anterior.TabIndex = 61;
            this.b_anterior.TabStop = false;
            this.b_anterior.Text = "<";
            this.b_anterior.UseVisualStyleBackColor = true;
            this.b_anterior.Click += new System.EventHandler(this.b_anterior_Click);
            // 
            // b_inicio
            // 
            this.b_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_inicio.Location = new System.Drawing.Point(81, 3);
            this.b_inicio.Name = "b_inicio";
            this.b_inicio.Size = new System.Drawing.Size(120, 25);
            this.b_inicio.TabIndex = 60;
            this.b_inicio.TabStop = false;
            this.b_inicio.Text = "<<";
            this.b_inicio.UseVisualStyleBackColor = true;
            this.b_inicio.Click += new System.EventHandler(this.b_inicio_Click);
            // 
            // VistasTiendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 561);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(970, 600);
            this.Name = "VistasTiendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiendas";
            this.Shown += new System.EventHandler(this.VistasTiendas_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_fecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_orden;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_codigo;
        private System.Windows.Forms.ComboBox cb_estado;
        private System.Windows.Forms.TextBox tb_tienda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_vendedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.Button b_modificar;
        private System.Windows.Forms.Button b_historial;
        private System.Windows.Forms.Button b_eliminar;
        private System.Windows.Forms.Button b_cancelar;
        private System.Windows.Forms.Button b_guardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_alquiler;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button b_imprimir;
        private System.Windows.Forms.Button b_salir;
        private System.Windows.Forms.Button b_final;
        private System.Windows.Forms.Button b_siguiente;
        private System.Windows.Forms.Button b_anterior;
        private System.Windows.Forms.Button b_inicio;

    }
}