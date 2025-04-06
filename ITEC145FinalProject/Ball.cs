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
        //fields
        static public Form1 mainForm;

        private Bitmap ball0 = new Bitmap("../../../resources/ball0.png");
        private Bitmap ball1 = new Bitmap("../../../resources/ball1.png");
        private Bitmap ball2 = new Bitmap("../../../resources/ball2.png");
        private Bitmap ball3 = new Bitmap("../../../resources/ball3.png");
        private Bitmap ball4 = new Bitmap("../../../resources/ball4.png");

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
        private bool _isSpecial;
        private const int XBASESPEED = 30;

        //properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
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
        public bool IsSpecial
        {
            get { return _isSpecial; }
        }

        //constructor
        public Ball(int x, int y, int ballColour)
        {
            //set basic properties
            _xSpeed = _rnd.Next(-4, 5);
            _ySpeed = 10;
            _width = 30;
            _height = 30;
            _x = x;
            _y = y;
            _isSpecial = true;

            //change certian properties based on ballColour
            //ex. mainBall has different speeds/properties
            switch (ballColour)
            {
                case 0:
                    picBall.Image = ball0;
                    _isSpecial = false;
                    _xSpeed = _rnd.Next(-10, 11);
                    if (_xSpeed == 0)
                        _xSpeed = _rnd.Next(0, 2) * 2 - 1; //sets either -1 or 1
                    _ySpeed = -10;
                    break;
                case 1:
                    picBall.Image = ball1;
                    break;
                case 2:
                    picBall.Image = ball2;
                    break;
                case 3:
                    picBall.Image = ball3;
                    break;
                case 4:
                    picBall.Image = ball4;
                    break;
            }

            //invidual timer for the ball to avoid invalidate firing too many times
            _ballTimer = new System.Windows.Forms.Timer();
            _ballTimer.Tick += _ballTimer_Tick;
            _ballTimer.Enabled = true;
            _ballTimer.Interval = 20;
        }

        //timer + movement
        private void _ballTimer_Tick(object? sender, EventArgs e)
        {
            //as timer ticks, move the ball at the X and Y speeds
            _x += _xSpeed;
            _y += _ySpeed;

            //left wall (flip xSpeed and ensure it doesnt get stuck in the wall)
            if (_x <= mainForm.picGameArea.Left - 25)
            {
                _xSpeed *= -1;
                _x = mainForm.picGameArea.Left - 25;
            }
            //right wall (flip xSpeed and ensure it doesnt get stuck in the wall)
            if (_x + _width >= mainForm.picGameArea.Width)
            { 
                _xSpeed *= -1;
                _x = mainForm.picGameArea.Width - _width;
            }
            //top wall (flip ySpeed and ensure it doesnt get stuck in the wall)
            if (_y <= mainForm.picGameArea.Top - 105)
            {
                _ySpeed *= -1;
                _y = mainForm.picGameArea.Top - 105;
            }
        }

        //methods
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
