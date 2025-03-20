using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class Player
    {
        private PictureBox _picPlayer = new PictureBox();

        public PictureBox picPlayer { get { return _picPlayer; } }

        public Player()
        {
            _picPlayer.BackColor = Color.Purple;
            _picPlayer.SizeMode = PictureBoxSizeMode.StretchImage;
            _picPlayer.Width = 125;
            _picPlayer.Height = 20;
            _picPlayer.Top = 550;
            _picPlayer.Left = 225;
        }

        public void MoveLeft()
        {
            picPlayer.Left -= 5;
        }
        public void MoveRight()
        {
            picPlayer.Left += 5;
        }
    }
}
