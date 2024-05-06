namespace Prueba1
{
    partial class VentanaPrueba
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
            buttonPrueba = new Button();
            buttonTOTP = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 55);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "Código Autenticador:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(265, 91);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(197, 27);
            textBox1.TabIndex = 1;
            // 
            // buttonPrueba
            // 
            buttonPrueba.Location = new Point(303, 151);
            buttonPrueba.Name = "buttonPrueba";
            buttonPrueba.Size = new Size(117, 81);
            buttonPrueba.TabIndex = 2;
            buttonPrueba.Text = "Verificar Código";
            buttonPrueba.UseVisualStyleBackColor = true;
            buttonPrueba.Click += buttonPrueba_Click;
            // 
            // buttonTOTP
            // 
            buttonTOTP.Location = new Point(303, 260);
            buttonTOTP.Name = "buttonTOTP";
            buttonTOTP.Size = new Size(117, 89);
            buttonTOTP.TabIndex = 3;
            buttonTOTP.Text = "Probar Código";
            buttonTOTP.UseVisualStyleBackColor = true;
            buttonTOTP.Click += buttonTOTP_Click;
            // 
            // VentanaPrueba
            // 
            AccessibleName = "Ventana de Prueba de Google Authenticator";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonTOTP);
            Controls.Add(buttonPrueba);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "VentanaPrueba";
            Text = "Ventana de Prueba";
            Load += VentanaPrueba_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button buttonPrueba;
        private Button buttonTOTP;
    }
}