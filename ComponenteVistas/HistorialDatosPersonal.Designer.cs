namespace ComponenteVistas
{
    partial class HistorialDatosPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialDatosPersonal));
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_imprimir = new System.Windows.Forms.Button();
            this.b_salir = new System.Windows.Forms.Button();
            this.b_final = new System.Windows.Forms.Button();
            this.b_siguiente = new System.Windows.Forms.Button();
            this.b_anterior = new System.Windows.Forms.Button();
            this.b_inicio = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.b_limpiar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_prenda = new System.Windows.Forms.Button();
            this.tb_prenda = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_codigo = new System.Windows.Forms.Button();
            this.tb_codigo = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.b_fecha = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.b_imprimir);
            this.panel2.Controls.Add(this.b_salir);
            this.panel2.Controls.Add(this.b_final);
            this.panel2.Controls.Add(this.b_siguiente);
            this.panel2.Controls.Add(this.b_anterior);
            this.panel2.Controls.Add(this.b_inicio);
            this.panel2.Location = new System.Drawing.Point(12, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(929, 30);
            this.panel2.TabIndex = 66;
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
            this.b_salir.Text = "SALIR";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(930, 306);
            this.dataGridView1.TabIndex = 65;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.b_limpiar);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(929, 118);
            this.panel1.TabIndex = 64;
            // 
            // b_limpiar
            // 
            this.b_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.b_limpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_limpiar.Location = new System.Drawing.Point(798, 74);
            this.b_limpiar.Name = "b_limpiar";
            this.b_limpiar.Size = new System.Drawing.Size(120, 25);
            this.b_limpiar.TabIndex = 60;
            this.b_limpiar.TabStop = false;
            this.b_limpiar.Text = "Refrescar";
            this.b_limpiar.UseVisualStyleBackColor = true;
            this.b_limpiar.Click += new System.EventHandler(this.b_limpiar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.b_prenda);
            this.groupBox3.Controls.Add(this.tb_prenda);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(619, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 65);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar por Tienda";
            // 
            // b_prenda
            // 
            this.b_prenda.Location = new System.Drawing.Point(179, 30);
            this.b_prenda.Name = "b_prenda";
            this.b_prenda.Size = new System.Drawing.Size(120, 25);
            this.b_prenda.TabIndex = 2;
            this.b_prenda.TabStop = false;
            this.b_prenda.Text = "Buscar";
            this.b_prenda.UseVisualStyleBackColor = true;
            this.b_prenda.Click += new System.EventHandler(this.b_prenda_Click);
            // 
            // tb_prenda
            // 
            this.tb_prenda.Location = new System.Drawing.Point(15, 30);
            this.tb_prenda.MaxLength = 20;
            this.tb_prenda.Name = "tb_prenda";
            this.tb_prenda.Size = new System.Drawing.Size(149, 23);
            this.tb_prenda.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.b_codigo);
            this.groupBox2.Controls.Add(this.tb_codigo);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(238, 65);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por Código";
            // 
            // b_codigo
            // 
            this.b_codigo.Location = new System.Drawing.Point(112, 30);
            this.b_codigo.Name = "b_codigo";
            this.b_codigo.Size = new System.Drawing.Size(120, 25);
            this.b_codigo.TabIndex = 2;
            this.b_codigo.TabStop = false;
            this.b_codigo.Text = "Buscar";
            this.b_codigo.UseVisualStyleBackColor = true;
            this.b_codigo.Click += new System.EventHandler(this.b_codigo_Click);
            // 
            // tb_codigo
            // 
            this.tb_codigo.Location = new System.Drawing.Point(6, 30);
            this.tb_codigo.MaxLength = 6;
            this.tb_codigo.Name = "tb_codigo";
            this.tb_codigo.Size = new System.Drawing.Size(100, 23);
            this.tb_codigo.TabIndex = 0;
            this.tb_codigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_codigo_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.b_fecha);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(272, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 65);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por Fechas";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(7, 35);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // b_fecha
            // 
            this.b_fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_fecha.Location = new System.Drawing.Point(215, 31);
            this.b_fecha.Name = "b_fecha";
            this.b_fecha.Size = new System.Drawing.Size(120, 25);
            this.b_fecha.TabIndex = 4;
            this.b_fecha.TabStop = false;
            this.b_fecha.Text = "Buscar";
            this.b_fecha.UseVisualStyleBackColor = true;
            this.b_fecha.Click += new System.EventHandler(this.b_fecha_Click);
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
            // HistorialDatosPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 492);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(970, 530);
            this.Name = "HistorialDatosPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HistorialDatosPersonal";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button b_imprimir;
        private System.Windows.Forms.Button b_salir;
        private System.Windows.Forms.Button b_final;
        private System.Windows.Forms.Button b_siguiente;
        private System.Windows.Forms.Button b_anterior;
        private System.Windows.Forms.Button b_inicio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button b_limpiar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_prenda;
        private System.Windows.Forms.TextBox tb_prenda;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_codigo;
        private System.Windows.Forms.TextBox tb_codigo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button b_fecha;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}