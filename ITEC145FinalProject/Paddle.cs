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
        //fields
        static public Form1 mainForm;

        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private bool isGrown = false;
        private PictureBox picPaddle = new PictureBox();
        private Bitmap paddle = new Bitmap("../../../resources/paddle.png");
        private CancellationTokenSource? _growCts;

        //properties
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

        //constructor
        public Paddle(int x, int y)
        {
            _width = 150;
            _height = 15;
            _x = x;
            _y = y;
            picPaddle.Image = paddle; 
        }

        //methods
        public void MoveLeft()
        {
            _x -= 15;
        }
        public void MoveRight()
        {
            _x += 15;
        }
        public async void Grow()
        {
            //canceles any prior tokens, then creates a new cancellation token source
            _growCts?.Cancel();
            _growCts = new CancellationTokenSource();

            //try catch to handle thrown exceptions
            try
            {
                //grow 100 pixels
                await Task.Delay(0, _growCts.Token);
                if (_width != 250)
                {
                    _width += 20;
                    _x -= 10;
                }
                await Task.Delay(25, _growCts.Token);
                if (_width != 250)
                {
                    _width += 20;
                    _x -= 10;
                }
                await Task.Delay(25, _growCts.Token);
                if (_width != 250)
                {
                    _width += 20;
                    _x -= 10;
                }
                await Task.Delay(25, _growCts.Token);
                if (_width != 250)
                {
                    _width += 20;
                    _x -= 10;
                }
                await Task.Delay(25, _growCts.Token);
                if (_width != 250)
                {
                    _width += 20;
                    _x -= 10;
                }

                //shrink back those 100 pixels
                await Task.Delay(5000, _growCts.Token);
                _width -= 20;
                _x += 10;
                await Task.Delay(25, _growCts.Token);
                _width -= 20;
                _x += 10;
                await Task.Delay(25, _growCts.Token);
                _width -= 20;
                _x += 10;
                await Task.Delay(25, _growCts.Token);
                _width -= 20;
                _x += 10;
                await Task.Delay(25, _growCts.Token);
                _width -= 20;
                _x += 10;

            }
            catch (TaskCanceledException) { /*swallow*/ }
        }
        public void Draw(Graphics gr)
        {
            //left side
            if (_x <= mainForm.picGameArea.Left - 25)
                _x = mainForm.picGameArea.Left - 25;
            //right side
            if (_x + _width >= mainForm.picGameArea.Width)
                _x = mainForm.picGameArea.Width - _width;

            gr.DrawImage(picPaddle.Image, _x, _y, _width, _height);
        }
    }
}
