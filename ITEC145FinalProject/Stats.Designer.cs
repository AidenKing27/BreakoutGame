namespace ITEC145FinalProject
{
    partial class Stats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stats));
            label1 = new Label();
            label2 = new Label();
            lblFinalScore = new Label();
            lblHighScore = new Label();
            label3 = new Label();
            picClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 24F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(93, 170);
            label1.Name = "label1";
            label1.Size = new Size(99, 50);
            label1.TabIndex = 0;
            label1.Text = "Score:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.UseCompatibleTextRendering = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 24F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(61, 239);
            label2.Name = "label2";
            label2.Size = new Size(121, 50);
            label2.TabIndex = 2;
            label2.Text = "Record:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.UseCompatibleTextRendering = true;
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.BackColor = Color.Transparent;
            lblFinalScore.Font = new Font("Segoe UI", 24F);
            lblFinalScore.ForeColor = Color.White;
            lblFinalScore.Location = new Point(317, 170);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(100, 50);
            lblFinalScore.TabIndex = 3;
            lblFinalScore.Text = "00000";
            lblFinalScore.TextAlign = ContentAlignment.MiddleLeft;
            lblFinalScore.UseCompatibleTextRendering = true;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.BackColor = Color.Transparent;
            lblHighScore.Font = new Font("Segoe UI", 24F);
            lblHighScore.ForeColor = Color.White;
            lblHighScore.Location = new Point(317, 239);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(100, 50);
            lblHighScore.TabIndex = 4;
            lblHighScore.Text = "00000";
            lblHighScore.TextAlign = ContentAlignment.MiddleLeft;
            lblHighScore.UseCompatibleTextRendering = true;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 30F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 28);
            label3.Name = "label3";
            label3.Size = new Size(501, 66);
            label3.TabIndex = 5;
            label3.Text = "YOU LOSE!";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.UseCompatibleTextRendering = true;
            // 
            // picClose
            // 
            picClose.BackColor = Color.Transparent;
            picClose.BackgroundImage = (Image)resources.GetObject("picClose.BackgroundImage");
            picClose.Location = new Point(532, 0);
            picClose.Margin = new Padding(0);
            picClose.Name = "picClose";
            picClose.Size = new Size(18, 18);
            picClose.TabIndex = 6;
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // Stats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(550, 350);
            Controls.Add(picClose);
            Controls.Add(label3);
            Controls.Add(lblHighScore);
            Controls.Add(lblFinalScore);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Stats";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stats";
            Load += Stats_Load;
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label lblFinalScore;
        private Label lblHighScore;
        private Label label3;
        private PictureBox picClose;
    }
}