using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class TempBall
    {
        //fields
        private Bitmap tempBall = new Bitmap("../../../resources/ball0.png");
        private PictureBox picTempBall = new PictureBox();

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private bool _isAlive = true;

        //properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
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
        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        //constructor
        public TempBall(int x, int y)
        {
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;

            picTempBall.Image = tempBall;
        }

        //methods
        public void MoveLeft()
        {
            _x -= 15;
        }
        public void MoveRight()
        {
            _x += 15;
        }
        public void Draw(Graphics gr)
        {
            gr.DrawImage(picTempBall.Image, _x, _y, _width, _height);
        }
    }
}
