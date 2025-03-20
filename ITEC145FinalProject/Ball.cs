using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ITEC145FinalProject
{
    public class Ball
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

        private Random rnd = new Random();

        bool _xPositive;
        bool _yPositive;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public bool XPositive { get { return _xPositive; } }
        public bool YPositive { get { return _yPositive; } }

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


        public Ball(int x, int y)
        {
            _xSpeed = 12;
            _ySpeed = 12;
            _xPositive = true;
            _yPositive = true;
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);

        }

        public void ChangeDirectionY()
        {
            _ySpeed *= -1;
            _yPositive = !_yPositive;
        }

        public void ChangeDirectionX()
        {
            _xSpeed *= -1;
            _xPositive = !_xPositive;
        }

        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            if (_x + _width > mainForm.ClientSize.Width)
            {
                _xSpeed *= -1;
                _xPositive = !_xPositive;
            }
                

            if (_x <= 0)
            {
                _xSpeed *= -1;
                _xPositive = !_xPositive;
            }
                

            if (_y + _height > mainForm.ClientSize.Height)
            {
                _y = 5;
            }
                

            if (_y <= 0)
            {
                _ySpeed *= -1;
                _yPositive = !_yPositive;
            }
                

            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
    }
}
