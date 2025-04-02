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

        private const int XBASESPEED = 30;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _xSpeed;
        private int _ySpeed;
        private System.Windows.Forms.Timer _timer;
        private bool _isAlive = true;
        private Color _color = Color.White;
        private Brush _brush;

        private Random _rnd = new Random();

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

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        public Ball(int x, int y)
        {
            _xSpeed = -10;
            _ySpeed = -10;
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _brush = new SolidBrush(_color);
            _timer = new System.Windows.Forms.Timer();
            _timer.Tick += _timer_Tick;
            _timer.Enabled = true;
            _timer.Interval = 20;
        }

        private void _timer_Tick(object? sender, EventArgs e)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            //left wall
            if (_x <= mainForm.picGameArea.Left)
                _xSpeed *= -1;
            //right wall
            if (_x + _width > mainForm.picGameArea.Width + 25)
                _xSpeed *= -1;
            //top wall
            if (_y <= mainForm.picGameArea.Top)
                _ySpeed *= -1;
            //bottom wall
            //if (_y + _height > mainForm.picGameArea.Height + 107)
            //{
            //    //_x = mainForm.picGameArea.Width / 2;
            //    //_y = 650;
            //    //_ySpeed *= -1;
            //    _lives -= 1;
            //}

            //draw the ball
        }


        public void ChangeDirectionY()
        {
            _ySpeed *= -1;
        }

        public void ChangeDirectionX()
        {
            _xSpeed *= -1;
        }

        public void ChangeDirectionBySlice(double slice)
        {
            _ySpeed *= -1;
            _xSpeed = Convert.ToInt32(XBASESPEED * slice);
        }

        public void Draw(Graphics gr)
        {
            gr.FillEllipse(_brush, _x, _y, _width, _height);
        }
    }
}
