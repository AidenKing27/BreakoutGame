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
    public partial class InfoBox : Form
    {
        private Form1 _form1;

        public InfoBox(Form1 form1)
        {
            InitializeComponent();

            //fixed form size and loading info box in front of screen
            this.MaximizeBox = false;
            this.Owner = form1;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;

            //font stuff
            _form1 = form1;
            _form1.InitPressStart2PFont();
            lblInfoBox.Font = new Font(Form1.pfcPressStart2P.Families[0], lblInfoBox.Font.Size);
            lblGithub.Font = new Font(Form1.pfcPressStart2P.Families[0], lblGithub.Font.Size);
            lblLinkedin.Font = new Font(Form1.pfcPressStart2P.Families[0], lblLinkedin.Font.Size);
        }

        private void InfoBox_Load(object sender, EventArgs e)
        {
            //undo topmost once loaded
            this.TopMost = false;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblGithub_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/AidenKing27",
                UseShellExecute = true // This tells Windows to use the default browser
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void lblLinkedin_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://www.linkedin.com/in/aiden-king-15b1841bb/",
                UseShellExecute = true // This tells Windows to use the default browser
            };
            System.Diagnostics.Process.Start(psi);
        }
    }
}
