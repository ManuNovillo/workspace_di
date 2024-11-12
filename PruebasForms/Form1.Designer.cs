namespace PruebasForms
{
    partial class Form1
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
            DateTime time = DateTime.Now;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void MiFormulario_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            MouseButtons botones = e.Button;
            // Pueden estar múltiples botones presionados simultáneamente
            int numeroDeClics = e.Clicks;
            string mensaje = $"Posición: X = {x}, Y = {y}\nBotones: {botones}\nNúmero de clics: { numeroDeClics}";
            label1.Text = mensaje;
            // Supongamos que hay un control Label llamado lblInformacion
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
    }
}
