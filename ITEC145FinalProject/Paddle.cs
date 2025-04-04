using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class Paddle
    {
        static public Form1 mainForm;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private PictureBox picPaddle = new PictureBox();
        private Bitmap paddle = new Bitmap("paddle.png");

        public int Left
        {
            get { return _x; }
        }
        public int Right
        {
            get { return _x + _width; }
        }
        public int Top
        {
            get { return _y; }
        }
        public int Bottom
        {
            get { return _y + _height; }
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }

        public Paddle(int x, int y)
        {
            _width = 135;
            _height = 15;
            _x = x;
            _y = y;
            picPaddle.Image = paddle; 
        }

        public void MoveLeft()
        {
            _x -= 10;
        }
        public void MoveRight()
        {
            _x += 10;
        }

        public void Draw(Graphics gr)
        {
            //left side
            if (_x <= mainForm.picGameArea.Left - 25)
                _x = mainForm.picGameArea.Left - 25;
            //right side
            if (_x + _width >= mainForm.picGameArea.Width)
                _x = mainForm.picGameArea.Width - _width;

            //draw the paddle
            gr.DrawImage(picPaddle.Image, _x, _y, _width, _height);
        }
    }
}
