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
        private Bitmap b1s = new Bitmap("block1spawn.png");
        private Bitmap b1g = new Bitmap("block1grow.png");
        private Bitmap b2 = new Bitmap("block2.png");
        private Bitmap b2s = new Bitmap("block2spawn.png");
        private Bitmap b3 = new Bitmap("block3.png");
        private Bitmap b3s = new Bitmap("block3spawn.png");
        private Bitmap b4 = new Bitmap("block4.png");
        private Bitmap b4s = new Bitmap("block4spawn.png");

        private PictureBox picBlock = new PictureBox();

        private Random _rnd = new Random();
        DateTime dt = DateTime.Now;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _ySpeed;
        private bool _moving;
        private int _health;
        private bool _isSpawner;
        private bool _isGrower;
        private int _bColor;

        public bool Moving
        {
            get { return _moving; }
            set { _moving = value; }
        }
        public int YSpeed
        {
            get { return _ySpeed; }
            set { _ySpeed = value; }
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
        public bool IsSpawner
        {
            get { return _isSpawner; }
        }
        public bool IsGrower
        {
            get { return _isGrower; }
        }

        public Block(int x, int y, int health, int blockColour)
        {
            switch (_rnd.Next(10)) {
                case 1:
                    _isSpawner = true;
                    break;
                case 2:
                    _isGrower = true;
                    break;
            }
            _width = 80;
            _height = 35;
            _x = x;
            _y = y;
            _ySpeed = 5;
            _health = health;
            _bColor = blockColour;

            if (blockColour == 1)
            {
                picBlock.Image = b1;
                if (_isSpawner) picBlock.Image = b1s;
                if (_isGrower) picBlock.Image = b1g;
            }
            else if (blockColour == 2) 
            {
                picBlock.Image = b2;
                if (_isSpawner) picBlock.Image = b2s;
                if (_isGrower) picBlock.Image = b1g;
            }
            else if (blockColour == 3) 
            {
                picBlock.Image = b3;
                if (_isSpawner) picBlock.Image = b3s;
                if (_isGrower) picBlock.Image = b1g;
            }
            else if (blockColour == 4) 
            {
                picBlock.Image = b4;
                if (_isSpawner) picBlock.Image = b4s;
                if (_isGrower) picBlock.Image = b1g;
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

        public void MoveDown()
        {
            _y += _ySpeed;
        }

        public void StopMoving()
        {
            _ySpeed = 0;
        }
        public void ResetLocation(int block)
        {
            if (block == 1) _y = -250;
            if (block == 2) _y = -205;
            if (block == 3) _y = -160;
            if (block == 4) _y = -115;
        }

        public void Draw(Graphics gr)
        {
            //draw the block(s)
            gr.DrawImage(picBlock.Image, _x, _y, _width, _height);
        }
    }
}
