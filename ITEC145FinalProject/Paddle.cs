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
        private int _lives;
        private int _score;
        private PictureBox picPaddle = new PictureBox();

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
        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public Paddle(int x, int y)
        {
            picPaddle.Image = new Bitmap("paddle.png");
            _width = 135;
            _height = 15;
            _x = x;
            _y = y;
            _lives = 3;
            _score = 0;
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
            if (_x <= mainForm.picGameArea.Left + 15)
                _x = mainForm.picGameArea.Left + 15;
            //right side
            if (_x + _width >= mainForm.picGameArea.Width + 10)
                _x = mainForm.picGameArea.Width - _width + 10;

            //draw the paddle
            gr.DrawImage(picPaddle.Image, _x, _y, _width, _height);
        }
    }
}
