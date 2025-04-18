﻿namespace ITEC145FinalProject
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            gameTimer = new System.Windows.Forms.Timer(components);
            lblScore = new Label();
            lblLevel = new Label();
            picGameArea = new PictureBox();
            picClose = new PictureBox();
            picInfo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picGameArea).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picInfo).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // lblScore
            // 
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 24F);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(225, 30);
            lblScore.Margin = new Padding(0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(249, 50);
            lblScore.TabIndex = 0;
            lblScore.Text = "00000";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
            lblScore.UseCompatibleTextRendering = true;
            // 
            // lblLevel
            // 
            lblLevel.BackColor = Color.Transparent;
            lblLevel.Font = new Font("Segoe UI", 15F);
            lblLevel.ForeColor = Color.White;
            lblLevel.Location = new Point(537, 27);
            lblLevel.Margin = new Padding(0);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(137, 50);
            lblLevel.TabIndex = 1;
            lblLevel.Text = "LVL:0";
            lblLevel.TextAlign = ContentAlignment.MiddleCenter;
            lblLevel.UseCompatibleTextRendering = true;
            // 
            // picGameArea
            // 
            picGameArea.Location = new Point(25, 105);
            picGameArea.Margin = new Padding(0);
            picGameArea.Name = "picGameArea";
            picGameArea.Size = new Size(650, 650);
            picGameArea.TabIndex = 3;
            picGameArea.TabStop = false;
            picGameArea.Paint += picGameArea_Paint;
            // 
            // picClose
            // 
            picClose.BackgroundImage = (Image)resources.GetObject("picClose.BackgroundImage");
            picClose.Location = new Point(682, 0);
            picClose.Margin = new Padding(0);
            picClose.Name = "picClose";
            picClose.Size = new Size(18, 18);
            picClose.TabIndex = 5;
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // picInfo
            // 
            picInfo.BackColor = SystemColors.Control;
            picInfo.Image = (Image)resources.GetObject("picInfo.Image");
            picInfo.Location = new Point(0, 0);
            picInfo.Name = "picInfo";
            picInfo.Size = new Size(18, 18);
            picInfo.TabIndex = 6;
            picInfo.TabStop = false;
            picInfo.Click += picInfo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(700, 780);
            Controls.Add(picInfo);
            Controls.Add(picClose);
            Controls.Add(picGameArea);
            Controls.Add(lblLevel);
            Controls.Add(lblScore);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Breakout King";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)picGameArea).EndInit();
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)picInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private Label lblScore;
        private Label lblLevel;
        public PictureBox picGameArea;
        private PictureBox picClose;
        private PictureBox picInfo;
    }
}
