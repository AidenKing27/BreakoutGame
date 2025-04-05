using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class Block
    {
        private Bitmap b1 = new Bitmap("block1.png");
        private Bitmap b1s = new Bitmap("block1special.png");
        private Bitmap b2 = new Bitmap("block2.png");
        private Bitmap b2s = new Bitmap("block2special.png");
        private Bitmap b3 = new Bitmap("block3.png");
        private Bitmap b3s = new Bitmap("block3special.png");
        private Bitmap b4 = new Bitmap("block4.png");
        private Bitmap b4s = new Bitmap("block4special.png");

        private PictureBox picBlock = new PictureBox();

        private Random _rnd = new Random();
        DateTime dt = DateTime.Now;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _health;
        private bool _isSpecialBlock;
        private int _bColor;



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
        public bool IsSpecialBlock
        {
            get { return _isSpecialBlock; }
        }

        public Block(int x, int y, int health, int blockColour)
        {
            if (_rnd.Next(10) == 0)
            {
                _isSpecialBlock = true;
            }
            
            _width = 80;
            _height = 35;
            _x = x;
            _y = y;
            _health = health;
            _bColor = blockColour;

            if (blockColour == 1)
            {
                picBlock.Image = b1;
                if (_isSpecialBlock) picBlock.Image = b1s;
            }
            else if (blockColour == 2) 
            {
                picBlock.Image = b2;
                if (_isSpecialBlock) picBlock.Image = b2s;
            }
            else if (blockColour == 3) 
            {
                picBlock.Image = b3;
                if (_isSpecialBlock) picBlock.Image = b3s;
            }
            else if (blockColour == 4) 
            {
                picBlock.Image = b4;
                if (_isSpecialBlock) picBlock.Image = b4s;
            }
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
