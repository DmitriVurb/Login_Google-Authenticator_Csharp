namespace Prueba1
{
    partial class VentanaRegistro
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
            textBox1 = new TextBox();
            label2 = new Label();
            textBox2 = new TextBox();
            buttonClave = new Button();
            buttonMostrarQR = new Button();
            buttonREGISTRO = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(318, 27);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Usuario:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(295, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 27);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(344, 111);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 2;
            label2.Text = "Contraseña:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(295, 158);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(186, 27);
            textBox2.TabIndex = 3;
            // 
            // buttonClave
            // 
            buttonClave.Location = new Point(58, 244);
            buttonClave.Name = "buttonClave";
            buttonClave.Size = new Size(129, 81);
            buttonClave.TabIndex = 4;
            buttonClave.Text = "Mostrar Clave (32)";
            buttonClave.UseVisualStyleBackColor = true;
            buttonClave.Click += buttonClave_Click;
            // 
            // buttonMostrarQR
            // 
            buttonMostrarQR.Location = new Point(318, 244);
            buttonMostrarQR.Name = "buttonMostrarQR";
            buttonMostrarQR.Size = new Size(129, 81);
            buttonMostrarQR.TabIndex = 5;
            buttonMostrarQR.Text = "Mostrar QR";
            buttonMostrarQR.UseVisualStyleBackColor = true;
            buttonMostrarQR.Click += buttonMostrarQR_Click;
            // 
            // buttonREGISTRO
            // 
            buttonREGISTRO.Location = new Point(606, 244);
            buttonREGISTRO.Name = "buttonREGISTRO";
            buttonREGISTRO.Size = new Size(129, 81);
            buttonREGISTRO.TabIndex = 6;
            buttonREGISTRO.Text = "Registrar Usuario";
            buttonREGISTRO.UseVisualStyleBackColor = true;
            buttonREGISTRO.Click += buttonREGISTRO_Click;
            // 
            // VentanaRegistro
            // 
            AccessibleName = "Ventana de Registro de Usuario";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonREGISTRO);
            Controls.Add(buttonMostrarQR);
            Controls.Add(buttonClave);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "VentanaRegistro";
            Text = "Ventana de Registro";
            Load += VentanaRegistro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox2;
        private Button buttonClave;
        private Button buttonMostrarQR;
        private Button buttonREGISTRO;
    }
}