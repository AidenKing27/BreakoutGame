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
        private PictureBox picBlock = new PictureBox();
        DateTime dt = DateTime.Now;

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
        }
        public int Width
        {
            get { return _width; }
        }
        public int Height
        {
            get { return _height; }
        }

        public Block(int x, int y, int health)
        {
            picBlock.Image = new Bitmap("block.png");
            _width = 100;
            _height = 35;
            _x = x;
            _y = y;
            _health = health;
        }

        public void TakeDamage()
        {
            TimeSpan ts = DateTime.Now - dt;
            if (ts.TotalMilliseconds > 500)
            {
                dt = DateTime.Now;
                _health -= 1;
            }
        }


        public void Draw(Graphics gr)
        {
            //draw the block(s)
            gr.DrawImage(picBlock.Image, _x, _y, _width, _height);
        }
    }
}
