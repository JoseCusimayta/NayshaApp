namespace ComponenteVistas
{
    partial class Login
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
            this.b_cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_clave = new System.Windows.Forms.TextBox();
            this.tb_usuario = new System.Windows.Forms.TextBox();
            this.b_ingresar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_cancelar
            // 
            this.b_cancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.b_cancelar.Location = new System.Drawing.Point(154, 137);
            this.b_cancelar.Name = "b_cancelar";
            this.b_cancelar.Size = new System.Drawing.Size(75, 23);
            this.b_cancelar.TabIndex = 4;
            this.b_cancelar.Text = "Cancelar";
            this.b_cancelar.UseVisualStyleBackColor = true;
            this.b_cancelar.Click += new System.EventHandler(this.b_cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Clave";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Usuario";
            // 
            // tb_clave
            // 
            this.tb_clave.Location = new System.Drawing.Point(129, 85);
            this.tb_clave.Name = "tb_clave";
            this.tb_clave.PasswordChar = '*';
            this.tb_clave.Size = new System.Drawing.Size(100, 20);
            this.tb_clave.TabIndex = 2;
            // 
            // tb_usuario
            // 
            this.tb_usuario.Location = new System.Drawing.Point(129, 38);
            this.tb_usuario.Name = "tb_usuario";
            this.tb_usuario.Size = new System.Drawing.Size(100, 20);
            this.tb_usuario.TabIndex = 1;
            // 
            // b_ingresar
            // 
            this.b_ingresar.Location = new System.Drawing.Point(25, 137);
            this.b_ingresar.Name = "b_ingresar";
            this.b_ingresar.Size = new System.Drawing.Size(75, 23);
            this.b_ingresar.TabIndex = 3;
            this.b_ingresar.Text = "Ingresar";
            this.b_ingresar.UseVisualStyleBackColor = true;
            this.b_ingresar.Click += new System.EventHandler(this.b_ingresar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.b_ingresar);
            this.panel1.Controls.Add(this.b_cancelar);
            this.panel1.Controls.Add(this.tb_usuario);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_clave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 192);
            this.panel1.TabIndex = 12;
            // 
            // Login
            // 
            this.AcceptButton = this.b_ingresar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cancelar;
            this.ClientSize = new System.Drawing.Size(271, 216);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(287, 254);
            this.MinimumSize = new System.Drawing.Size(287, 254);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_clave;
        private System.Windows.Forms.TextBox tb_usuario;
        private System.Windows.Forms.Button b_ingresar;
        private System.Windows.Forms.Panel panel1;
    }
}