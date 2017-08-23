namespace UserInterface
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTOLE = new System.Windows.Forms.TextBox();
            this.textBoxITER = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MetodoSeleccionado = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Continuar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MetodoSeleccionado);
            this.groupBox1.Controls.Add(this.textBoxTOLE);
            this.groupBox1.Controls.Add(this.textBoxITER);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 297);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos para el calculo";
            // 
            // textBoxTOLE
            // 
            this.textBoxTOLE.Location = new System.Drawing.Point(363, 160);
            this.textBoxTOLE.Name = "textBoxTOLE";
            this.textBoxTOLE.Size = new System.Drawing.Size(100, 26);
            this.textBoxTOLE.TabIndex = 4;
            // 
            // textBoxITER
            // 
            this.textBoxITER.Location = new System.Drawing.Point(363, 102);
            this.textBoxITER.Name = "textBoxITER";
            this.textBoxITER.Size = new System.Drawing.Size(100, 26);
            this.textBoxITER.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tolerancia";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad maxima de iteraciones";
            // 
            // MetodoSeleccionado
            // 
            this.MetodoSeleccionado.FormattingEnabled = true;
            this.MetodoSeleccionado.Items.AddRange(new object[] {
            "Biseccion",
            "Regla falsa",
            "Newton (tangente)",
            "Secante"});
            this.MetodoSeleccionado.Location = new System.Drawing.Point(75, 49);
            this.MetodoSeleccionado.Name = "MetodoSeleccionado";
            this.MetodoSeleccionado.Size = new System.Drawing.Size(230, 28);
            this.MetodoSeleccionado.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 331);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxTOLE;
        private System.Windows.Forms.TextBox textBoxITER;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox MetodoSeleccionado;
    }
}

