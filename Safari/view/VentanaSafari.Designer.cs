﻿namespace Safari
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
            pasosToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem1 = new ToolStripMenuItem();
            acercaDeToolStripMenuItem = new ToolStripMenuItem();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelBotones = new FlowLayoutPanel();
            autoplayButton = new Button();
            stopButton = new Button();
            stepButton = new Button();
            pauseButton = new Button();
            diezPasosButton = new Button();
            resetButton = new Button();
            panelInfo = new Panel();
            elefantesLabel = new Label();
            pasosLabel = new Label();
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
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(1168, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // funcionesPrincipalesToolStripMenuItem
            // 
            funcionesPrincipalesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { stepToolStripMenuItem, resetToolStripMenuItem, playToolStripMenuItem, pauseToolStripMenuItem, stopToolStripMenuItem, pasosToolStripMenuItem });
            funcionesPrincipalesToolStripMenuItem.Name = "funcionesPrincipalesToolStripMenuItem";
            funcionesPrincipalesToolStripMenuItem.Size = new Size(163, 24);
            funcionesPrincipalesToolStripMenuItem.Text = "Funciones Principales";
            // 
            // stepToolStripMenuItem
            // 
            stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            stepToolStripMenuItem.Size = new Size(150, 26);
            stepToolStripMenuItem.Text = "Step";
            stepToolStripMenuItem.Click += stepToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Size = new Size(150, 26);
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
            // 
            // playToolStripMenuItem
            // 
            playToolStripMenuItem.Name = "playToolStripMenuItem";
            playToolStripMenuItem.Size = new Size(150, 26);
            playToolStripMenuItem.Text = "Play";
            playToolStripMenuItem.Click += playToolStripMenuItem_Click;
            // 
            // pauseToolStripMenuItem
            // 
            pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            pauseToolStripMenuItem.Size = new Size(150, 26);
            pauseToolStripMenuItem.Text = "Pause";
            pauseToolStripMenuItem.Click += pauseToolStripMenuItem_Click;
            // 
            // stopToolStripMenuItem
            // 
            stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            stopToolStripMenuItem.Size = new Size(150, 26);
            stopToolStripMenuItem.Text = "Stop";
            stopToolStripMenuItem.Click += stopToolStripMenuItem_Click;
            // 
            // pasosToolStripMenuItem
            // 
            pasosToolStripMenuItem.Name = "pasosToolStripMenuItem";
            pasosToolStripMenuItem.Size = new Size(150, 26);
            pasosToolStripMenuItem.Text = "10 pasos";
            pasosToolStripMenuItem.Click += pasosToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ayudaToolStripMenuItem1, acercaDeToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ayudaToolStripMenuItem1
            // 
            ayudaToolStripMenuItem1.Name = "ayudaToolStripMenuItem1";
            ayudaToolStripMenuItem1.Size = new Size(158, 26);
            ayudaToolStripMenuItem1.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            acercaDeToolStripMenuItem.Size = new Size(158, 26);
            acercaDeToolStripMenuItem.Text = "Acerca de";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanel1.Controls.Add(panelBotones);
            flowLayoutPanel1.Controls.Add(panelInfo);
            flowLayoutPanel1.Location = new Point(11, 27);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1146, 115);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panelBotones
            // 
            panelBotones.Controls.Add(autoplayButton);
            panelBotones.Controls.Add(stopButton);
            panelBotones.Controls.Add(stepButton);
            panelBotones.Controls.Add(pauseButton);
            panelBotones.Controls.Add(diezPasosButton);
            panelBotones.Controls.Add(resetButton);
            flowLayoutPanel1.SetFlowBreak(panelBotones, true);
            panelBotones.Location = new Point(3, 4);
            panelBotones.Margin = new Padding(3, 4, 3, 4);
            panelBotones.Name = "panelBotones";
            panelBotones.Padding = new Padding(0, 7, 0, 0);
            panelBotones.Size = new Size(626, 56);
            panelBotones.TabIndex = 0;
            // 
            // autoplayButton
            // 
            autoplayButton.Location = new Point(3, 10);
            autoplayButton.Name = "autoplayButton";
            autoplayButton.Size = new Size(94, 29);
            autoplayButton.TabIndex = 0;
            autoplayButton.Text = "AUTOPLAY";
            autoplayButton.UseVisualStyleBackColor = true;
            autoplayButton.Click += autoPlayButton_Click;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(103, 10);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(94, 29);
            stopButton.TabIndex = 1;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // stepButton
            // 
            stepButton.Location = new Point(203, 10);
            stepButton.Name = "stepButton";
            stepButton.Size = new Size(94, 29);
            stepButton.TabIndex = 2;
            stepButton.Text = "STEP";
            stepButton.UseVisualStyleBackColor = true;
            stepButton.Click += stepButton_Click;
            // 
            // pauseButton
            // 
            pauseButton.Location = new Point(303, 10);
            pauseButton.Name = "pauseButton";
            pauseButton.Size = new Size(94, 29);
            pauseButton.TabIndex = 3;
            pauseButton.Text = "PAUSE";
            pauseButton.UseVisualStyleBackColor = true;
            pauseButton.Click += pauseButton_Click;
            // 
            // diezPasosButton
            // 
            diezPasosButton.Location = new Point(403, 10);
            diezPasosButton.Name = "diezPasosButton";
            diezPasosButton.Size = new Size(94, 29);
            diezPasosButton.TabIndex = 5;
            diezPasosButton.Text = "10 STEPS";
            diezPasosButton.UseVisualStyleBackColor = true;
            diezPasosButton.Click += diezPasosButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(503, 10);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(94, 29);
            resetButton.TabIndex = 4;
            resetButton.Text = "RESET";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // panelInfo
            // 
            panelInfo.Controls.Add(elefantesLabel);
            panelInfo.Controls.Add(pasosLabel);
            panelInfo.Controls.Add(totalLabel);
            panelInfo.Controls.Add(gacelasLabel);
            panelInfo.Controls.Add(leonesLabel);
            panelInfo.Controls.Add(plantasLabel);
            panelInfo.Location = new Point(3, 67);
            panelInfo.Name = "panelInfo";
            panelInfo.Size = new Size(1143, 29);
            panelInfo.TabIndex = 1;
            // 
            // elefantesLabel
            // 
            elefantesLabel.Location = new Point(470, 0);
            elefantesLabel.Name = "elefantesLabel";
            elefantesLabel.Size = new Size(176, 29);
            elefantesLabel.TabIndex = 5;
            elefantesLabel.Text = "label1";
            // 
            // pasosLabel
            // 
            pasosLabel.Location = new Point(887, 0);
            pasosLabel.Name = "pasosLabel";
            pasosLabel.Size = new Size(192, 29);
            pasosLabel.TabIndex = 4;
            pasosLabel.Text = "label1";
            // 
            // totalLabel
            // 
            totalLabel.Location = new Point(686, 0);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new Size(238, 29);
            totalLabel.TabIndex = 3;
            totalLabel.Text = "label1";
            // 
            // gacelasLabel
            // 
            gacelasLabel.Location = new Point(303, 0);
            gacelasLabel.Name = "gacelasLabel";
            gacelasLabel.Size = new Size(238, 29);
            gacelasLabel.TabIndex = 2;
            gacelasLabel.Text = "label1";
            // 
            // leonesLabel
            // 
            leonesLabel.Location = new Point(159, 0);
            leonesLabel.Name = "leonesLabel";
            leonesLabel.Size = new Size(238, 29);
            leonesLabel.TabIndex = 1;
            leonesLabel.Text = "label1";
            // 
            // plantasLabel
            // 
            plantasLabel.Location = new Point(3, 0);
            plantasLabel.Name = "plantasLabel";
            plantasLabel.Size = new Size(238, 29);
            plantasLabel.TabIndex = 0;
            plantasLabel.Text = "label1";
            // 
            // panelSafari
            // 
            panelSafari.BackColor = Color.White;
            panelSafari.Location = new Point(11, 147);
            panelSafari.Name = "panelSafari";
            panelSafari.Size = new Size(1146, 655);
            panelSafari.TabIndex = 2;
            panelSafari.Paint += panelSfari_Paint;
            // 
            // VentanaSafari
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1168, 816);
            Controls.Add(panelSafari);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
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
        private Label pasosLabel;
        private Label elefantesLabel;
        private ToolStripMenuItem pasosToolStripMenuItem;
        private Button diezPasosButton;
    }
}
                      
                            
                              
                           
                                
                             
                               
                          