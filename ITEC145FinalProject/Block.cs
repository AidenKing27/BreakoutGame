using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class Block
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _health;
        private int _bColor;
        private PictureBox picBlock = new PictureBox();
        private Bitmap b1 = new Bitmap("block1.png");
        private Bitmap b2 = new Bitmap("block2.png");
        private Bitmap b3 = new Bitmap("block3.png");
        private Bitmap b4 = new Bitmap("block4.png");
        DateTime dt = DateTime.Now;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int X
        {
            get { return _x; }
            set { _x = value; }
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
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }
        public int Colour
        {
            get { return _bColor; }
        }

        public Block(int x, int y, int health, int bColour)
        {
            
            _width = 80;
            _height = 35;
            _x = x;
            _y = y;
            _health = health;
            _bColor = bColour;

            if (bColour == 1) picBlock.Image = b1;
            else if (bColour == 2) picBlock.Image = b2;
            else if (bColour == 3) picBlock.Image = b3;
            else if (bColour == 4) picBlock.Image = b4;
        }

        public void TakeDamage()
        {
            TimeSpan ts = DateTime.Now - dt;
            if (ts.TotalMilliseconds > 100)
            {
                dt = DateTime.Now;
                _health -= 1;
                Form1.score += 50;
            }
        }

        public void Draw(Graphics gr)
        {
            //draw the block(s)
            gr.DrawImage(picBlock.Image, _x, _y, _width, _height);
        }
    }
}
