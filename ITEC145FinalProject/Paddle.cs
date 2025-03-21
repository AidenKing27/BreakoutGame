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
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private Color _color = Color.Red;
        private Brush _brush;

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

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

        public Paddle(int x, int y)
        {
            _width = 135;
            _height = 15;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);
        }

        public void MoveLeft()
        {
            _x -= 8;
        }
        public void MoveRight()
        {
            _x += 8;
        }

        public void Draw(Graphics gr)
        {
            gr.FillRectangle(_brush, _x, _y, _width, _height);
        }
    }
}
