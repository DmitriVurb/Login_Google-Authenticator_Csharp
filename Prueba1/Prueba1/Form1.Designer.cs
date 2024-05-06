namespace Prueba1
{
    partial class VentanaPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoginButton = new Button();
            RegistroButton = new Button();
            PruebaButton = new Button();
            SuspendLayout();
            // 
            // LoginButton
            // 
            LoginButton.AccessibleName = "Iniciar Sesión";
            LoginButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LoginButton.Location = new Point(281, 30);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(171, 68);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Iniciar Sesión";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += button1_Click;
            // 
            // RegistroButton
            // 
            RegistroButton.AccessibleName = "Registrar Usuario";
            RegistroButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            RegistroButton.Location = new Point(281, 163);
            RegistroButton.Name = "RegistroButton";
            RegistroButton.Size = new Size(171, 79);
            RegistroButton.TabIndex = 1;
            RegistroButton.Text = "Registrar Usuario";
            RegistroButton.UseVisualStyleBackColor = true;
            RegistroButton.Click += button2_Click;
            // 
            // PruebaButton
            // 
            PruebaButton.AccessibleName = "Probar Autenticador";
            PruebaButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PruebaButton.Location = new Point(281, 306);
            PruebaButton.Name = "PruebaButton";
            PruebaButton.Size = new Size(171, 80);
            PruebaButton.TabIndex = 2;
            PruebaButton.Text = "Probar Autenticador";
            PruebaButton.UseVisualStyleBackColor = true;
            PruebaButton.Click += button3_Click;
            // 
            // VentanaPrincipal
            // 
            AccessibleName = "Inicio";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PruebaButton);
            Controls.Add(RegistroButton);
            Controls.Add(LoginButton);
            Name = "VentanaPrincipal";
            Text = "Ventana de Inicio";
            ResumeLayout(false);
        }

        #endregion

        private Button LoginButton;
        private Button RegistroButton;
        private Button PruebaButton;
    }
}
