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
        private Color _color = Color.Purple;
        private Brush _brush;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
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



        public Block(int x, int y)
        {
            _width = 100;
            _height = 50;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);
        }

        public void Draw(Graphics gr)
        {
            gr.FillRectangle(_brush, _x, _y, _width, _height);
        }
    }
}
