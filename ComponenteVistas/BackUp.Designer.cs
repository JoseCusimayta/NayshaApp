namespace ComponenteVistas
{
    partial class BackUp
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.b_restaurar = new System.Windows.Forms.Button();
            this.b_buscar2 = new System.Windows.Forms.Button();
            this.tb_restaurar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.b_guardar = new System.Windows.Forms.Button();
            this.b_buscar1 = new System.Windows.Forms.Button();
            this.tb_guardar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_restaurar);
            this.groupBox2.Controls.Add(this.b_buscar2);
            this.groupBox2.Controls.Add(this.tb_restaurar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(44, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 135);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Restaurar Copia de Seguridad de la Base de Datos";
            // 
            // b_restaurar
            // 
            this.b_restaurar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.b_restaurar.Location = new System.Drawing.Point(181, 78);
            this.b_restaurar.Name = "b_restaurar";
            this.b_restaurar.Size = new System.Drawing.Size(111, 23);
            this.b_restaurar.TabIndex = 3;
            this.b_restaurar.Text = "Restaurar";
            this.b_restaurar.UseVisualStyleBackColor = true;
            this.b_restaurar.Click += new System.EventHandler(this.b_restaurar_Click);
            // 
            // b_buscar2
            // 
            this.b_buscar2.Location = new System.Drawing.Point(431, 33);
            this.b_buscar2.Name = "b_buscar2";
            this.b_buscar2.Size = new System.Drawing.Size(75, 23);
            this.b_buscar2.TabIndex = 2;
            this.b_buscar2.Text = "Buscar";
            this.b_buscar2.UseVisualStyleBackColor = true;
            this.b_buscar2.Click += new System.EventHandler(this.b_buscar2_Click);
            // 
            // tb_restaurar
            // 
            this.tb_restaurar.Location = new System.Drawing.Point(95, 36);
            this.tb_restaurar.Name = "tb_restaurar";
            this.tb_restaurar.Size = new System.Drawing.Size(297, 20);
            this.tb_restaurar.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Localización";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_guardar);
            this.groupBox1.Controls.Add(this.b_buscar1);
            this.groupBox1.Controls.Add(this.tb_guardar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(44, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 135);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Copia de Seguridad de la Base de Datos";
            // 
            // b_guardar
            // 
            this.b_guardar.Location = new System.Drawing.Point(181, 78);
            this.b_guardar.Name = "b_guardar";
            this.b_guardar.Size = new System.Drawing.Size(111, 23);
            this.b_guardar.TabIndex = 3;
            this.b_guardar.Text = "Copia de Seguridad";
            this.b_guardar.UseVisualStyleBackColor = true;
            this.b_guardar.Click += new System.EventHandler(this.b_guardar_Click);
            // 
            // b_buscar1
            // 
            this.b_buscar1.Location = new System.Drawing.Point(431, 33);
            this.b_buscar1.Name = "b_buscar1";
            this.b_buscar1.Size = new System.Drawing.Size(75, 23);
            this.b_buscar1.TabIndex = 2;
            this.b_buscar1.Text = "Buscar";
            this.b_buscar1.UseVisualStyleBackColor = true;
            this.b_buscar1.Click += new System.EventHandler(this.b_buscar1_Click);
            // 
            // tb_guardar
            // 
            this.tb_guardar.Location = new System.Drawing.Point(95, 36);
            this.tb_guardar.Name = "tb_guardar";
            this.tb_guardar.Size = new System.Drawing.Size(297, 20);
            this.tb_guardar.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localización";
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(661, 447);
            this.Name = "BackUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackUp";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button b_restaurar;
        private System.Windows.Forms.Button b_buscar2;
        private System.Windows.Forms.TextBox tb_restaurar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_guardar;
        private System.Windows.Forms.Button b_buscar1;
        private System.Windows.Forms.TextBox tb_guardar;
        private System.Windows.Forms.Label label1;

    }
}