namespace ComponenteVistas
{
    partial class CalculoPrendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculoPrendas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_tela1 = new System.Windows.Forms.TextBox();
            this.tb_tela2 = new System.Windows.Forms.TextBox();
            this.tb_tela3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_app1 = new System.Windows.Forms.TextBox();
            this.tb_app2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_app3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_dec1 = new System.Windows.Forms.TextBox();
            this.tb_dec2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_dec3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_serv5 = new System.Windows.Forms.TextBox();
            this.tb_serv6 = new System.Windows.Forms.TextBox();
            this.tb_serv3 = new System.Windows.Forms.TextBox();
            this.tb_serv4 = new System.Windows.Forms.TextBox();
            this.tb_serv1 = new System.Windows.Forms.TextBox();
            this.tb_serv2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tb_serv7 = new System.Windows.Forms.TextBox();
            this.tb_igv = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_total = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tb_tela4 = new System.Windows.Forms.TextBox();
            this.tb_app4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tb_dec4 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_nuevo = new System.Windows.Forms.Button();
            this.b_modificar = new System.Windows.Forms.Button();
            this.b_historial = new System.Windows.Forms.Button();
            this.b_eliminar = new System.Windows.Forms.Button();
            this.b_cancelar = new System.Windows.Forms.Button();
            this.b_guardar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.b_imprimir = new System.Windows.Forms.Button();
            this.b_salir = new System.Windows.Forms.Button();
            this.b_final = new System.Windows.Forms.Button();
            this.b_siguiente = new System.Windows.Forms.Button();
            this.b_anterior = new System.Windows.Forms.Button();
            this.b_inicio = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.tb_tela1);
            this.groupBox1.Controls.Add(this.tb_tela2);
            this.groupBox1.Controls.Add(this.tb_tela3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATOS DE LA TELA";
            // 
            // tb_tela1
            // 
            this.tb_tela1.Location = new System.Drawing.Point(138, 19);
            this.tb_tela1.MaxLength = 8;
            this.tb_tela1.Name = "tb_tela1";
            this.tb_tela1.Size = new System.Drawing.Size(60, 20);
            this.tb_tela1.TabIndex = 1;
            this.tb_tela1.Tag = "Metros de Tela";
            this.tb_tela1.TextChanged += new System.EventHandler(this.Telas);
            this.tb_tela1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_tela2
            // 
            this.tb_tela2.Location = new System.Drawing.Point(138, 45);
            this.tb_tela2.MaxLength = 8;
            this.tb_tela2.Name = "tb_tela2";
            this.tb_tela2.Size = new System.Drawing.Size(60, 20);
            this.tb_tela2.TabIndex = 2;
            this.tb_tela2.Tag = "Precio de Tela";
            this.tb_tela2.TextChanged += new System.EventHandler(this.Telas);
            this.tb_tela2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_tela3
            // 
            this.tb_tela3.Enabled = false;
            this.tb_tela3.Location = new System.Drawing.Point(138, 71);
            this.tb_tela3.MaxLength = 8;
            this.tb_tela3.Name = "tb_tela3";
            this.tb_tela3.Size = new System.Drawing.Size(60, 20);
            this.tb_tela3.TabIndex = 3;
            this.tb_tela3.Tag = "Sub Total de Tela";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "SUB TOTAL DE TELA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "PRECIO DE TELA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "METROS DE TELA";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.tb_app1);
            this.groupBox2.Controls.Add(this.tb_app2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tb_app3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(225, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(235, 98);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DATOS DE APLICACIONES";
            // 
            // tb_app1
            // 
            this.tb_app1.Location = new System.Drawing.Point(164, 19);
            this.tb_app1.MaxLength = 8;
            this.tb_app1.Name = "tb_app1";
            this.tb_app1.Size = new System.Drawing.Size(60, 20);
            this.tb_app1.TabIndex = 1;
            this.tb_app1.TextChanged += new System.EventHandler(this.Aplicaciones);
            this.tb_app1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_app2
            // 
            this.tb_app2.Location = new System.Drawing.Point(164, 45);
            this.tb_app2.MaxLength = 8;
            this.tb_app2.Name = "tb_app2";
            this.tb_app2.Size = new System.Drawing.Size(60, 20);
            this.tb_app2.TabIndex = 2;
            this.tb_app2.TextChanged += new System.EventHandler(this.Aplicaciones);
            this.tb_app2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "SUB TOTAL DE APLICACION";
            // 
            // tb_app3
            // 
            this.tb_app3.Enabled = false;
            this.tb_app3.Location = new System.Drawing.Point(164, 71);
            this.tb_app3.MaxLength = 8;
            this.tb_app3.Name = "tb_app3";
            this.tb_app3.Size = new System.Drawing.Size(60, 20);
            this.tb_app3.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "PRECIO DE APLICACION";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "METROS DE APLICACION";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.tb_dec1);
            this.groupBox3.Controls.Add(this.tb_dec2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tb_dec3);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(466, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 98);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATOS DE LA DECORACION";
            // 
            // tb_dec1
            // 
            this.tb_dec1.Location = new System.Drawing.Point(190, 19);
            this.tb_dec1.MaxLength = 8;
            this.tb_dec1.Name = "tb_dec1";
            this.tb_dec1.Size = new System.Drawing.Size(60, 20);
            this.tb_dec1.TabIndex = 1;
            this.tb_dec1.TextChanged += new System.EventHandler(this.Decoraciones);
            this.tb_dec1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_dec2
            // 
            this.tb_dec2.Location = new System.Drawing.Point(190, 45);
            this.tb_dec2.MaxLength = 8;
            this.tb_dec2.Name = "tb_dec2";
            this.tb_dec2.Size = new System.Drawing.Size(60, 20);
            this.tb_dec2.TabIndex = 2;
            this.tb_dec2.TextChanged += new System.EventHandler(this.Decoraciones);
            this.tb_dec2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "SUB TOTAL DE LA DECORACION";
            // 
            // tb_dec3
            // 
            this.tb_dec3.Enabled = false;
            this.tb_dec3.Location = new System.Drawing.Point(190, 71);
            this.tb_dec3.MaxLength = 8;
            this.tb_dec3.Name = "tb_dec3";
            this.tb_dec3.Size = new System.Drawing.Size(60, 20);
            this.tb_dec3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "PRECIO DE LA DECORACION";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(170, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "CANTIDAD DE LA DECORACION";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox4.Controls.Add(this.tb_serv5);
            this.groupBox4.Controls.Add(this.tb_serv6);
            this.groupBox4.Controls.Add(this.tb_serv3);
            this.groupBox4.Controls.Add(this.tb_serv4);
            this.groupBox4.Controls.Add(this.tb_serv1);
            this.groupBox4.Controls.Add(this.tb_serv2);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(12, 116);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(716, 82);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "DATOS DE SERVICIO";
            // 
            // tb_serv5
            // 
            this.tb_serv5.Location = new System.Drawing.Point(644, 22);
            this.tb_serv5.MaxLength = 8;
            this.tb_serv5.Name = "tb_serv5";
            this.tb_serv5.Size = new System.Drawing.Size(60, 20);
            this.tb_serv5.TabIndex = 3;
            this.tb_serv5.TextChanged += new System.EventHandler(this.Servicios);
            this.tb_serv5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_serv6
            // 
            this.tb_serv6.Enabled = false;
            this.tb_serv6.Location = new System.Drawing.Point(644, 48);
            this.tb_serv6.MaxLength = 8;
            this.tb_serv6.Name = "tb_serv6";
            this.tb_serv6.Size = new System.Drawing.Size(60, 20);
            this.tb_serv6.TabIndex = 6;
            // 
            // tb_serv3
            // 
            this.tb_serv3.Location = new System.Drawing.Point(378, 22);
            this.tb_serv3.MaxLength = 8;
            this.tb_serv3.Name = "tb_serv3";
            this.tb_serv3.Size = new System.Drawing.Size(60, 20);
            this.tb_serv3.TabIndex = 2;
            this.tb_serv3.TextChanged += new System.EventHandler(this.Servicios);
            this.tb_serv3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_serv4
            // 
            this.tb_serv4.Location = new System.Drawing.Point(378, 48);
            this.tb_serv4.MaxLength = 8;
            this.tb_serv4.Name = "tb_serv4";
            this.tb_serv4.Size = new System.Drawing.Size(60, 20);
            this.tb_serv4.TabIndex = 5;
            this.tb_serv4.TextChanged += new System.EventHandler(this.Servicios);
            this.tb_serv4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_serv1
            // 
            this.tb_serv1.Location = new System.Drawing.Point(138, 22);
            this.tb_serv1.MaxLength = 8;
            this.tb_serv1.Name = "tb_serv1";
            this.tb_serv1.Size = new System.Drawing.Size(60, 20);
            this.tb_serv1.TabIndex = 1;
            this.tb_serv1.TextChanged += new System.EventHandler(this.Servicios);
            this.tb_serv1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // tb_serv2
            // 
            this.tb_serv2.Location = new System.Drawing.Point(138, 48);
            this.tb_serv2.MaxLength = 8;
            this.tb_serv2.Name = "tb_serv2";
            this.tb_serv2.Size = new System.Drawing.Size(60, 20);
            this.tb_serv2.TabIndex = 4;
            this.tb_serv2.TextChanged += new System.EventHandler(this.Servicios);
            this.tb_serv2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SoloDecimales);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(499, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "SUB TOTAL DE SERVICIO";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(499, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "GANANCIA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "PAGO DE PERSONAL Y TIENDA";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "PRECIO DE MANO DE OBRA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(81, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "TRANSPORTE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(118, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "PRECIO DE SERVICIO";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox5.Controls.Add(this.tb_serv7);
            this.groupBox5.Controls.Add(this.tb_igv);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.tb_total);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.tb_tela4);
            this.groupBox5.Controls.Add(this.tb_app4);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.tb_dec4);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Enabled = false;
            this.groupBox5.Location = new System.Drawing.Point(734, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 179);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "DATOS DE LA DECORACION";
            // 
            // tb_serv7
            // 
            this.tb_serv7.Enabled = false;
            this.tb_serv7.Location = new System.Drawing.Point(161, 97);
            this.tb_serv7.MaxLength = 8;
            this.tb_serv7.Name = "tb_serv7";
            this.tb_serv7.Size = new System.Drawing.Size(60, 20);
            this.tb_serv7.TabIndex = 17;
            this.tb_serv7.TextChanged += new System.EventHandler(this.CalculoTotal);
            // 
            // tb_igv
            // 
            this.tb_igv.Enabled = false;
            this.tb_igv.Location = new System.Drawing.Point(161, 123);
            this.tb_igv.MaxLength = 8;
            this.tb_igv.Name = "tb_igv";
            this.tb_igv.Size = new System.Drawing.Size(60, 20);
            this.tb_igv.TabIndex = 16;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(14, 152);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "TOTAL";
            // 
            // tb_total
            // 
            this.tb_total.Enabled = false;
            this.tb_total.Location = new System.Drawing.Point(161, 149);
            this.tb_total.MaxLength = 8;
            this.tb_total.Name = "tb_total";
            this.tb_total.Size = new System.Drawing.Size(60, 20);
            this.tb_total.TabIndex = 15;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(14, 126);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(66, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "I.G.V.   18 %";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(120, 13);
            this.label21.TabIndex = 12;
            this.label21.Text = "SUB TOTAL SERVICIO";
            // 
            // tb_tela4
            // 
            this.tb_tela4.Enabled = false;
            this.tb_tela4.Location = new System.Drawing.Point(161, 19);
            this.tb_tela4.MaxLength = 8;
            this.tb_tela4.Name = "tb_tela4";
            this.tb_tela4.Size = new System.Drawing.Size(60, 20);
            this.tb_tela4.TabIndex = 11;
            this.tb_tela4.TextChanged += new System.EventHandler(this.CalculoTotal);
            // 
            // tb_app4
            // 
            this.tb_app4.Enabled = false;
            this.tb_app4.Location = new System.Drawing.Point(161, 45);
            this.tb_app4.MaxLength = 8;
            this.tb_app4.Name = "tb_app4";
            this.tb_app4.Size = new System.Drawing.Size(60, 20);
            this.tb_app4.TabIndex = 10;
            this.tb_app4.TextChanged += new System.EventHandler(this.CalculoTotal);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(141, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "SUB TOTAL DECORACION";
            // 
            // tb_dec4
            // 
            this.tb_dec4.Enabled = false;
            this.tb_dec4.Location = new System.Drawing.Point(161, 71);
            this.tb_dec4.MaxLength = 8;
            this.tb_dec4.Name = "tb_dec4";
            this.tb_dec4.Size = new System.Drawing.Size(60, 20);
            this.tb_dec4.TabIndex = 9;
            this.tb_dec4.TextChanged += new System.EventHandler(this.CalculoTotal);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "SUB TOTAL APLICACION";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "SUB TOTAL TELA";
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
            this.panel2.Location = new System.Drawing.Point(29, 204);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(910, 33);
            this.panel2.TabIndex = 64;
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
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.Controls.Add(this.b_imprimir);
            this.panel3.Controls.Add(this.b_salir);
            this.panel3.Controls.Add(this.b_final);
            this.panel3.Controls.Add(this.b_siguiente);
            this.panel3.Controls.Add(this.b_anterior);
            this.panel3.Controls.Add(this.b_inicio);
            this.panel3.Location = new System.Drawing.Point(29, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(910, 30);
            this.panel3.TabIndex = 65;
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
            this.dataGridView1.Location = new System.Drawing.Point(19, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(930, 269);
            this.dataGridView1.TabIndex = 63;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            // CalculoPrendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 561);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(990, 600);
            this.Name = "CalculoPrendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CalculoPrendas";
            this.Shown += new System.EventHandler(this.Formulario_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Formulario_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_tela3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_tela1;
        private System.Windows.Forms.TextBox tb_tela2;
        private System.Windows.Forms.TextBox tb_app1;
        private System.Windows.Forms.TextBox tb_app2;
        private System.Windows.Forms.TextBox tb_app3;
        private System.Windows.Forms.TextBox tb_dec1;
        private System.Windows.Forms.TextBox tb_dec2;
        private System.Windows.Forms.TextBox tb_dec3;
        private System.Windows.Forms.TextBox tb_serv5;
        private System.Windows.Forms.TextBox tb_serv6;
        private System.Windows.Forms.TextBox tb_serv3;
        private System.Windows.Forms.TextBox tb_serv4;
        private System.Windows.Forms.TextBox tb_serv1;
        private System.Windows.Forms.TextBox tb_serv2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tb_serv7;
        private System.Windows.Forms.TextBox tb_igv;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_total;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox tb_tela4;
        private System.Windows.Forms.TextBox tb_app4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tb_dec4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button b_nuevo;
        private System.Windows.Forms.Button b_modificar;
        private System.Windows.Forms.Button b_historial;
        private System.Windows.Forms.Button b_eliminar;
        private System.Windows.Forms.Button b_cancelar;
        private System.Windows.Forms.Button b_guardar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button b_imprimir;
        private System.Windows.Forms.Button b_salir;
        private System.Windows.Forms.Button b_final;
        private System.Windows.Forms.Button b_siguiente;
        private System.Windows.Forms.Button b_anterior;
        private System.Windows.Forms.Button b_inicio;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}