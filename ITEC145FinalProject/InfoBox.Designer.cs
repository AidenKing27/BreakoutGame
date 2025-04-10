namespace ITEC145FinalProject
{
    partial class InfoBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoBox));
            picClose = new PictureBox();
            lblInfoBox = new Label();
            lblGithub = new Label();
            lblLinkedin = new Label();
            ((System.ComponentModel.ISupportInitialize)picClose).BeginInit();
            SuspendLayout();
            // 
            // picClose
            // 
            picClose.BackColor = Color.Transparent;
            picClose.BackgroundImage = (Image)resources.GetObject("picClose.BackgroundImage");
            picClose.Location = new Point(532, 0);
            picClose.Margin = new Padding(0);
            picClose.Name = "picClose";
            picClose.Size = new Size(18, 18);
            picClose.TabIndex = 7;
            picClose.TabStop = false;
            picClose.Click += picClose_Click;
            // 
            // lblInfoBox
            // 
            lblInfoBox.BackColor = Color.Transparent;
            lblInfoBox.ForeColor = Color.White;
            lblInfoBox.Location = new Point(27, 27);
            lblInfoBox.Margin = new Padding(0);
            lblInfoBox.Name = "lblInfoBox";
            lblInfoBox.Size = new Size(498, 205);
            lblInfoBox.TabIndex = 8;
            lblInfoBox.Text = resources.GetString("lblInfoBox.Text");
            lblInfoBox.TextAlign = ContentAlignment.MiddleCenter;
            lblInfoBox.UseCompatibleTextRendering = true;
            // 
            // lblGithub
            // 
            lblGithub.BackColor = Color.Transparent;
            lblGithub.Image = (Image)resources.GetObject("lblGithub.Image");
            lblGithub.Location = new Point(30, 265);
            lblGithub.Margin = new Padding(0);
            lblGithub.Name = "lblGithub";
            lblGithub.Size = new Size(225, 55);
            lblGithub.TabIndex = 11;
            lblGithub.Text = "GitHub";
            lblGithub.TextAlign = ContentAlignment.MiddleCenter;
            lblGithub.UseCompatibleTextRendering = true;
            lblGithub.Click += lblGithub_Click;
            // 
            // lblLinkedin
            // 
            lblLinkedin.BackColor = Color.Transparent;
            lblLinkedin.Image = (Image)resources.GetObject("lblLinkedin.Image");
            lblLinkedin.Location = new Point(295, 265);
            lblLinkedin.Margin = new Padding(0);
            lblLinkedin.Name = "lblLinkedin";
            lblLinkedin.Size = new Size(225, 55);
            lblLinkedin.TabIndex = 12;
            lblLinkedin.Text = "LinkedIn";
            lblLinkedin.TextAlign = ContentAlignment.MiddleCenter;
            lblLinkedin.UseCompatibleTextRendering = true;
            lblLinkedin.Click += lblLinkedin_Click;
            // 
            // InfoBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(550, 350);
            Controls.Add(lblLinkedin);
            Controls.Add(lblGithub);
            Controls.Add(lblInfoBox);
            Controls.Add(picClose);
            FormBorderStyle = FormBorderStyle.None;
            Name = "InfoBox";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InfoBox";
            Load += InfoBox_Load;
            ((System.ComponentModel.ISupportInitialize)picClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox picClose;
        private Label lblInfoBox;
        private Label lblGithub;
        private Label lblLinkedin;
    }
}