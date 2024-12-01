namespace Safari
{
    partial class VentanaSafari
    {
        /// <summary>
        ///  Required designer variable.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            funcionesPrincipalesToolStripMenuItem = new ToolStripMenuItem();
            stepToolStripMenuItem = new ToolStripMenuItem();
            resetToolStripMenuItem = new ToolStripMenuItem();
            playToolStripMenuItem = new ToolStripMenuItem();
            pauseToolStripMenuItem = new ToolStripMenuItem();
            stopToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem1 = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelBotones = new FlowLayoutPanel();
            autoplayButton = new Button();
            stopButton = new Button();
            stepButton = new Button();
            pauseButton = new Button();
            resetButton = new Button();
            panelInfo = new Panel();
            diasLabel = new Label();
            totalLabel = new Label();
            gacelasLabel = new Label();
            leonesLabel = new Label();
            plantasLabel = new Label();
            panelSafari = new Panel();
            menuStrip1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelBotones.SuspendLayout();
            panelInfo.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { funcionesPrincipalesToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1082, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // funcionesPrincipalesToolStripMenuItem
            // 
            funcionesPrincipalesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stepToolStripMenuItem, resetToolStripMenuItem, playToolStripMenuItem, pauseToolStripMenuItem, stopToolStripMenuItem, exitToolStripMenuItem });
            funcionesPrincipalesToolStripMenuItem.Name = "funcionesPrincipalesToolStripMenuItem";
            funcionesPrincipalesToolStripMenuItem.Size = new Size(133, 20);
            funcionesPrincipalesToolStripMenuItem.Text = "Funciones Principales";
            // 
            // stepToolStripMenuItem
            // 
            stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            stepToolStripMenuItem.Size = new Size(105, 22);
            stepToolStripMenuItem.Text = "Step";
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(105, 22);
            resetToolStripMenuItem.Text = "Reset";
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(105, 22);
            playToolStripMenuItem.Text = "Play";
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(105, 22);
            pauseToolStripMenuItem.Text = "Pause";
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(105, 22);
            stopToolStripMenuItem.Text = "Stop";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(105, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ayudaToolStripMenuItem1, acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            ayudaToolStripMenuItem1.Size = new Size(126, 22);
            ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(126, 22);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(panelBotones);
            flowLayoutPanel1.Controls.Add(panelInfo);
            flowLayoutPanel1.Location = new Point(10, 20);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1061, 86);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(autoplayButton);
            panelBotones.Controls.Add(stopButton);
            panelBotones.Controls.Add(stepButton);
            panelBotones.Controls.Add(pauseButton);
            panelBotones.Controls.Add(resetButton);
            flowLayoutPanel1.SetFlowBreak(panelBotones, true);
            panelBotones.Location = new Point(3, 3);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(0, 5, 0, 0);
            panelBotones.Size = new Size(498, 42);
            panelBotones.TabIndex = 0;
            // 
            // autoplayButton
            // 
            autoplayButton.Location = new Point(3, 7);
            autoplayButton.Margin = new Padding(3, 2, 3, 2);
            autoplayButton.Name = "autoplayButton";
            autoplayButton.Size = new Size(82, 22);
            autoplayButton.TabIndex = 0;
            autoplayButton.Text = "AUTOPLAY";
            autoplayButton.UseVisualStyleBackColor = true;
            autoplayButton.Click += autoPlayButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(91, 7);
            stopButton.Margin = new Padding(3, 2, 3, 2);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(82, 22);
            stopButton.TabIndex = 1;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // stepButton
            // 
            stepButton.Location = new Point(179, 7);
            stepButton.Margin = new Padding(3, 2, 3, 2);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(82, 22);
            stepButton.TabIndex = 2;
            stepButton.Text = "STEP";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(267, 7);
            pauseButton.Margin = new Padding(3, 2, 3, 2);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(82, 22);
            pauseButton.TabIndex = 3;
            pauseButton.Text = "PAUSE";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(355, 7);
            resetButton.Margin = new Padding(3, 2, 3, 2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(82, 22);
            resetButton.TabIndex = 4;
            resetButton.Text = "RESET";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(diasLabel);
            panelInfo.Controls.Add(totalLabel);
            panelInfo.Controls.Add(gacelasLabel);
            panelInfo.Controls.Add(leonesLabel);
            panelInfo.Controls.Add(plantasLabel);
            panelInfo.Location = new Point(3, 50);
            panelInfo.Margin = new Padding(3, 2, 3, 2);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(1000, 22);
            panelInfo.TabIndex = 1;
            // 
            // diasLabel
            // 
            diasLabel.Location = new Point(738, 0);
            diasLabel.Name = "diasLabel";
            diasLabel.Size = new Size(208, 22);
            diasLabel.TabIndex = 4;
            diasLabel.Text = "label1";
            // 
            // totalLabel
            // 
            totalLabel.Location = new Point(549, 0);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(208, 22);
            totalLabel.TabIndex = 3;
            totalLabel.Text = "label1";
            // 
            // gacelasLabel
            // 
            gacelasLabel.Location = new Point(365, 0);
            gacelasLabel.Name = "gacelasLabel";
            gacelasLabel.Size = new Size(208, 22);
            gacelasLabel.TabIndex = 2;
            gacelasLabel.Text = "label1";
            // 
            // leonesLabel
            // 
            leonesLabel.Location = new Point(178, 0);
            leonesLabel.Name = "leonesLabel";
            leonesLabel.Size = new Size(208, 22);
            leonesLabel.TabIndex = 1;
            leonesLabel.Text = "label1";
            // 
            // plantasLabel
            // 
            plantasLabel.Location = new Point(3, 0);
            plantasLabel.Name = "plantasLabel";
            plantasLabel.Size = new Size(208, 22);
            plantasLabel.TabIndex = 0;
            plantasLabel.Text = "label1";
            // 
            // panelSafari
            // 
            panelSafari.BackColor = Color.White;
            panelSafari.Location = new Point(10, 110);
            panelSafari.Margin = new Padding(3, 2, 3, 2);
            panelSafari.Name = "panelSafari";
            panelSafari.Size = new Size(1061, 468);
            panelSafari.TabIndex = 2;
            panelSafari.Paint += panelSfari_Paint;
            // 
            // VentanaSafari
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1082, 587);
            Controls.Add(panelSafari);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "VentanaSafari";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Safari";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem funcionesPrincipalesToolStripMenuItem;
        private ToolStripMenuItem stepToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem pauseToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem1;
        private ToolStripMenuItem acercaDeToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelSafari;
        private Button resetButton;
        private Button stopButton;
        private Button pauseButton;
        private Button stepButton;
        private FlowLayoutPanel panelBotones;
        private Button autoplayButton;
        private Panel panelInfo;
        private Label plantasLabel;
        private Label totalLabel;
        private Label gacelasLabel;
        private Label leonesLabel;
        private Label diasLabel;
    }
}
                      
                            
                              
                           
                                
                             
                               
                          