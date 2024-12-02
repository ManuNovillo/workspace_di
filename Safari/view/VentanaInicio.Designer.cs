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
            errorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)filasNumField).BeginInit();
            ((System.ComponentModel.ISupportInitialize)columnasNumField).BeginInit();
            SuspendLayout();
            // 
            // confirmarButton
            // 
            confirmarButton.Location = new Point(305, 284);
            confirmarButton.Margin = new Padding(3, 2, 3, 2);
            confirmarButton.Name = "confirmarButton";
            confirmarButton.Size = new Size(82, 22);
            confirmarButton.TabIndex = 2;
            confirmarButton.Text = "Confirmar";
            confirmarButton.UseVisualStyleBackColor = true;
            confirmarButton.Click += confirmarButton_Click;
            // 
            // filasNumField
            // 
            filasNumField.Location = new Point(284, 61);
            filasNumField.Margin = new Padding(3, 2, 3, 2);
            filasNumField.Name = "filasNumField";
            filasNumField.Size = new Size(131, 23);
            filasNumField.TabIndex = 3;
            // 
            // columnasNumField
            // 
            columnasNumField.Location = new Point(284, 159);
            columnasNumField.Margin = new Padding(3, 2, 3, 2);
            columnasNumField.Name = "columnasNumField";
            columnasNumField.Size = new Size(131, 23);
            columnasNumField.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(263, 21);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 5;
            label1.Text = "Introduce el número de filas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 121);
            label2.Name = "label2";
            label2.Size = new Size(186, 15);
            label2.TabIndex = 6;
            label2.Text = "Introduce el número de columnas";
            // 
            // errorLabel
            // 
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(57, 237);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(577, 15);
            errorLabel.TabIndex = 7;
            errorLabel.Text = "label3";
            errorLabel.TextAlign = ContentAlignment.MiddleCenter;
            errorLabel.Visible = false;
            // 
            // VentanaInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(errorLabel);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(columnasNumField);
            Controls.Add(filasNumField);
            Controls.Add(confirmarButton);
            Margin = new Padding(3, 2, 3, 2);
            Name = "VentanaInicio";
            StartPosition = FormStartPosition.CenterScreen;
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
        private Label errorLabel;
    }
}