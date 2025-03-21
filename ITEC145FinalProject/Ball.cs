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

        public int Width
        { 
            get { return _width; } 
        }
        public int Height 
        { 
            get { return _height; } 
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

        public Ball(int x, int y)
        {
            _xSpeed = 12;
            _ySpeed = 12;
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);
        }

        public void ChangeDirectionY()
        {
            _ySpeed *= -1;
        }

        public void ChangeDirectionX()
        {
            _xSpeed *= -1;
        }

        public void Draw(Graphics gr)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            //original
            if (_x + _width > mainForm.ClientSize.Width)
            {
                _xSpeed *= -1;
            }
            if (_x <= 0)
            {
                _xSpeed *= -1;
            }
            if (_y + _height >  mainForm.ClientSize.Height)
            {
                _y = 10;
            }
            if (_y <= 0)
            {
                _ySpeed *= -1;
            }

            //test
            if (_x + _width > mainForm.picGameArea.Width)
            {
                _xSpeed *= -1;
            }
            if (_x <= mainForm.picGameArea.Left)
            {
                _xSpeed *= -1;
            }
            if (_y + _height > mainForm.picGameArea.Height)
            {
                _y = mainForm.picGameArea.Top + 10;
            }
            if (_y <= mainForm.picGameArea.Top)
            {
                _ySpeed *= -1;
            }

            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
    }
}
