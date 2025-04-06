using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITEC145FinalProject
{
    public partial class Stats : Form
    {
        private Form1 _form1;

        public Stats(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
            _form1.InitPressStart2PFont();
            lblFinalScore.Font = new Font(Form1.pfcPressStart2P.Families[0], lblFinalScore.Font.Size);
            lblHighScore.Font = new Font(Form1.pfcPressStart2P.Families[0], lblHighScore.Font.Size);
            label1.Font = new Font(Form1.pfcPressStart2P.Families[0], label1.Font.Size);
            label2.Font = new Font(Form1.pfcPressStart2P.Families[0], label2.Font.Size);
            label3.Font = new Font(Form1.pfcPressStart2P.Families[0], label3.Font.Size);

            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(38, 38, 38);
        }

        private void Stats_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            if (Form1.score != 0)
            {
                lblFinalScore.Text = Form1.score.ToString("d5");
                lblHighScore.Text = Form1.highScore.ToString("d5");
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }
    }
}
