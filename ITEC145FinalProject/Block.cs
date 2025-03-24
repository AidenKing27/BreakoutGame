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
        private PictureBox picBlock = new PictureBox();

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
            picBlock.Image = new Bitmap("pineapple.png");
            _width = 100;
            _height = 35;
            _x = x;
            _y = y;
        }

        public void Draw(Graphics gr)
        {
            gr.DrawImage(picBlock.Image, _x, _y, _width, _height);
        }
    }
}
