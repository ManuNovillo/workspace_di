namespace Safari.view
{
    partial class VentanaInicio
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
            confirmarButton = new Button();
            filasNumField = new NumericUpDown();
            columnasNumField = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)filasNumField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnasNumField).BeginInit();
            SuspendLayout();
            // 
            // confirmarButton
            // 
            confirmarButton.Location = new Point(349, 379);
            confirmarButton.Name = "confirmarButton";
            confirmarButton.Size = new Size(94, 29);
            confirmarButton.TabIndex = 2;
            confirmarButton.Text = "Confirmar";
            confirmarButton.UseVisualStyleBackColor = true;
            // 
            // filasNumField
            // 
            filasNumField.Location = new Point(324, 81);
            filasNumField.Name = "filasNumField";
            filasNumField.Size = new Size(150, 27);
            filasNumField.TabIndex = 3;
            // 
            // columnasNumField
            // 
            columnasNumField.Location = new Point(325, 212);
            columnasNumField.Name = "columnasNumField";
            columnasNumField.Size = new Size(150, 27);
            columnasNumField.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(301, 28);
            label1.Name = "label1";
            label1.Size = new Size(195, 20);
            label1.TabIndex = 5;
            label1.Text = "Introduce el número de filas";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 161);
            label2.Name = "label2";
            label2.Size = new Size(231, 20);
            label2.TabIndex = 6;
            label2.Text = "Introduce el número de columnas";
            label2.Click += label2_Click;
            // 
            // VentanaInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(columnasNumField);
            Controls.Add(filasNumField);
            Controls.Add(confirmarButton);
            Name = "VentanaInicio";
            Text = "VentanaInicio";
            ((System.ComponentModel.ISupportInitialize)filasNumField).EndInit();
            ((System.ComponentModel.ISupportInitialize)columnasNumField).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button confirmarButton;
        private NumericUpDown filasNumField;
        private NumericUpDown columnasNumField;
        private Label label1;
        private Label label2;
    }
}