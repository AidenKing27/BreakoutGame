using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    internal class Ball
    {
        static public Form1 mainForm;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _xSpeed;
        private int _ySpeed;
        private Color _color = Color.Black;
        private Brush _brush;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public Ball(int x, int y)
        {
            _xSpeed = 20;
            _ySpeed = 20;
            _width = 50;
            _height = 50;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);

        }

        public void ChangeDirection()
        {
            _xSpeed *= -1;
            _ySpeed *= -1;
        }

        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            if (_x + _width > mainForm.ClientSize.Width)
                _xSpeed *= -1;

            if (_x <= 0)
                _xSpeed *= -1;

            if (_y + _height > mainForm.ClientSize.Height)
                _ySpeed *= -1;

            if (_y <= 0)
                _ySpeed *= -1;

            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
    }
}
