using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace ITEC145FinalProject
{
    public class Ball
    {
        static public Form1 mainForm;

        private Bitmap ball0 = new Bitmap("ball0.png");
        private Bitmap ball1 = new Bitmap("ball1.png");
        private Bitmap ball2 = new Bitmap("ball2.png");
        private Bitmap ball3 = new Bitmap("ball3.png");
        private Bitmap ball4 = new Bitmap("ball4.png");

        private PictureBox picBall = new PictureBox();
        
        private Random _rnd = new Random();
        private System.Windows.Forms.Timer _ballTimer;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private int _xSpeed;
        private int _ySpeed;
        private bool _isAlive = true;
        private bool _isSpecialBall;
        private const int XBASESPEED = 30;



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
        public int XSpeed
        {
            get { return _xSpeed; }
        }
        public int YSpeed
        {
            get { return _ySpeed; }
        }
        public bool IsSpecialBall
        {
            get { return _isSpecialBall; }
        }

        public Ball(int x, int y)
        {
            int tmpSpeed = _rnd.Next(-10, 11);

            if (tmpSpeed == 0)
            {
                tmpSpeed = _rnd.Next(0, 2) == 0 ? -1 : 1;
            }
            _xSpeed = tmpSpeed;
            _ySpeed = -10;
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _isSpecialBall = false;

            picBall.Image = ball0;

            _ballTimer = new System.Windows.Forms.Timer();
            _ballTimer.Tick += _ballTimer_Tick;
            _ballTimer.Enabled = true;
            _ballTimer.Interval = 20;
        }

        public Ball(int x, int y, int ballColour)
        {
            int tmpSpeed = _rnd.Next(-10, 11);
            if (tmpSpeed == 0)
            {
                tmpSpeed = _rnd.Next(0, 2) == 0 ? -1 : 1;
            }
            _xSpeed = tmpSpeed;
            _ySpeed = 10;

            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _isSpecialBall = true;

            picBall.Image = ball0;
            if (ballColour == 1) picBall.Image = ball1;
            if (ballColour == 2) picBall.Image = ball2;
            if (ballColour == 3) picBall.Image = ball3;
            if (ballColour == 4) picBall.Image = ball4;

            _ballTimer = new System.Windows.Forms.Timer();
            _ballTimer.Tick += _ballTimer_Tick;
            _ballTimer.Enabled = true;
            _ballTimer.Interval = 20;
        }

        private void _ballTimer_Tick(object? sender, EventArgs e)
        {
            _x += _xSpeed;
            _y += _ySpeed;

            //left wall
            if (_x <= mainForm.picGameArea.Left - 25)
                _xSpeed *= -1;
            //right wall
            if (_x + _width > mainForm.picGameArea.Width)
                _xSpeed *= -1;
            //top wall
            if (_y <= mainForm.picGameArea.Top - 105)
                _ySpeed *= -1;
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
            gr.DrawImage(picBall.Image, _x, _y, _width, _height);
        }
    }
}
