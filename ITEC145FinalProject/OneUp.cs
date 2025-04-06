using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class OneUp
    {
        private Bitmap img1UP = new Bitmap("../../../resources/1UP.png");
        private PictureBox pic1UP = new PictureBox();

        private int _speed;
        private int _width;
        private int _height;
        private int _x;
        private int _y;
        private bool _isUsed = false;

        public OneUp(int x, int y)
        {
            _x = x;
            _y = y;
            _speed = 5;
            _width = 30;
            _height = 30;
            pic1UP.Image = img1UP;
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
        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; }
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(pic1UP.Image, _x, _y, _width, _height);
        }

        public void Fall()
        {
            _y += _speed;
        }
    }
}
