using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ITEC145FinalProject
{
    public class Block
    {
        private Bitmap b1 = new Bitmap("../../../resources/block1.png");
        private Bitmap b1s = new Bitmap("../../../resources/block1spawn.png");
        private Bitmap b1g = new Bitmap("../../../resources/block1grow.png");
        private Bitmap b1l = new Bitmap("../../../resources/block1life.png");
        private Bitmap b1st = new Bitmap("../../../resources/block1strong.png");
        private Bitmap b1w = new Bitmap("../../../resources/block1weak.png");

        private Bitmap b2 = new Bitmap("../../../resources/block2.png");
        private Bitmap b2s = new Bitmap("../../../resources/block2spawn.png");
        private Bitmap b2g = new Bitmap("../../../resources/block2grow.png");
        private Bitmap b2l = new Bitmap("../../../resources/block2life.png");
        private Bitmap b2st = new Bitmap("../../../resources/block2strong.png");
        private Bitmap b2w = new Bitmap("../../../resources/block2weak.png");

        private Bitmap b3 = new Bitmap("../../../resources/block3.png");
        private Bitmap b3s = new Bitmap("../../../resources/block3spawn.png");
        private Bitmap b3g = new Bitmap("../../../resources/block3grow.png");
        private Bitmap b3l = new Bitmap("../../../resources/block3life.png");
        private Bitmap b3st = new Bitmap("../../../resources/block3strong.png");
        private Bitmap b3w = new Bitmap("../../../resources/block3weak.png");

        private Bitmap b4 = new Bitmap("../../../resources/block4.png");
        private Bitmap b4s = new Bitmap("../../../resources/block4spawn.png");
        private Bitmap b4g = new Bitmap("../../../resources/block4grow.png");
        private Bitmap b4l = new Bitmap("../../../resources/block4life.png");
        private Bitmap b4st = new Bitmap("../../../resources/block4strong.png");
        private Bitmap b4w = new Bitmap("../../../resources/block4weak.png");

        private PictureBox picBlock = new PictureBox();

        private Random _rnd = new Random();
        DateTime dt = DateTime.Now;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _speed;
        private int _health;
        private int _colour;
        private bool _moving;

        private bool _isSpawner;
        private bool _isGrower;
        private bool _is1UP;
        private bool _isStrong;
        private bool _isNormal;

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
        public bool Moving
        {
            get { return _moving; }
            set { _moving = value; }
        }
        public int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        public int Colour
        {
            get { return _colour; }
        }
        public bool IsSpawner
        {
            get { return _isSpawner; }
            set { _isSpawner = value; }
        }
        public bool IsGrower
        {
            get { return _isGrower; }
            set { _isGrower = value; }
        }
        public bool Is1UP
        {
            get { return _is1UP; }
            set { _is1UP = value; }
        }
        public bool IsStrong
        {
            get { return _isStrong; }
            set { _isStrong = value; }
        }
        public bool IsNormal
        {
            get { return _isNormal; }
            set { _isNormal = value; }
        }


        public Block(int x, int y, int blockColour)
        {
            _width = 80;
            _height = 35;
            _x = x;
            _y = y;
            _speed = 5;
            _health = 1;
            _colour = blockColour;

            SetBlocks(blockColour);
        }

        public void SetBlocks(int blockColour)
        {
            //image arrays
            Image[] spawnerImages = { null, b1s, b2s, b3s, b4s };
            Image[] growerImages = { null, b1g, b2g, b3g, b4g };
            Image[] lifeImages = { null, b1l, b2l, b3l, b4l };
            Image[] strongImages = { null, b1st, b2st, b3st, b4st };
            Image[] normalImages = { null, b1, b2, b3, b4 };

            //reset all properties
            _isSpawner = false;
            _isGrower = false;
            _is1UP = false;
            _isStrong = false;
            _isNormal = false;
            _health = 1;

            //set images and properties
            int rand = _rnd.Next(26);
            switch (rand)
            {
                case 1:
                    _isSpawner = true;
                    picBlock.Image = spawnerImages[blockColour];
                    break;
                case 2:
                    _isGrower = true;
                    picBlock.Image = growerImages[blockColour];
                    break;
                case 3:
                    _is1UP = true;
                    picBlock.Image = lifeImages[blockColour];
                    break;
                case 4:
                    _isStrong = true;
                    _health = 2;
                    picBlock.Image = strongImages[blockColour];
                    break;
                default:
                    _isNormal = true;
                    picBlock.Image = normalImages[blockColour];
                    break;
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
            _y += _speed;
        }

        public void StopMoving()
        {
            _speed = 0;
        }
        public void ResetLocation()
        {
            if (_colour == 1) _y = -250;
            if (_colour == 2) _y = -205;
            if (_colour == 3) _y = -160;
            if (_colour == 4) _y = -115;
        }

        public void Break()
        {
            if (_colour == 1) picBlock.Image = b1w;
            if (_colour == 2) picBlock.Image = b2w;
            if (_colour == 3) picBlock.Image = b3w;
            if (_colour == 4) picBlock.Image = b4w;
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(picBlock.Image, _x, _y, _width, _height);
        }
    }
}
