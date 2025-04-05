namespace ITEC145FinalProject
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)picGameArea).BeginInit();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 631);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 656);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 679);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 703);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 7;
            label4.Text = "label4";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 729);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 10;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(626, 703);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 11;
            label5.Text = "label5";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(628, 730);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 12;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(293, 107);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 13;
            label8.Text = "label8";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 606);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 14;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(485, 107);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 15;
            label10.Text = "label10";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(700, 780);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(picGameArea);
            Controls.Add(lblLevel);
            Controls.Add(lblScore);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Breakout King";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)picGameArea).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private Label lblScore;
        private Label lblLevel;
        public PictureBox picGameArea;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}
