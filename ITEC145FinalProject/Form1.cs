using System.Reflection.Metadata.Ecma335;
using System.Xml.XPath;

namespace ITEC145FinalProject
{
    public partial class Form1 : Form
    {
        //lists of objects
        List<Ball> balls = new List<Ball>();
        List<Block> blocks = new List<Block>();

        //object instances
        Ball ball = new Ball(100, 300);
        Paddle paddle = new Paddle(225, 700);


        Block block1 = new Block(60, 120);
        Block block2 = new Block(170, 120);
        Block block3 = new Block(280, 120);
        Block block4 = new Block(390, 120);
        Block block5 = new Block(500, 120);

        //enum for paddle movement
        enum KPress { none = 0, right = 1, left = 2 };
        KPress kPaddle = KPress.none;

        public PictureBox picGameArea = new PictureBox();




        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;
            Paddle.mainForm = this;

            picGameArea.Location = new Point(25, 107);
            picGameArea.Size = new Size(600, 650);


            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //add objects to lists
            balls.Add(ball);
            blocks.Add(block1);
            blocks.Add(block2);
            blocks.Add(block3);
            blocks.Add(block4);
            blocks.Add(block5);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the ball, paddle, and block(s)

            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);
               
            foreach (Block block in blocks)
                block.Draw(e.Graphics);

            paddle.Draw(e.Graphics);

            //collision detection
            foreach (Ball ball in balls)
            {
                if (TopBottomCollisionPaddle(ball, paddle))
                {
                    ball.ChangeDirectionY();
                }
                if (LeftRightCollisionPaddle(ball, paddle))
                {
                    ball.ChangeDirectionX();
                }
                foreach (Block block in blocks)
                {
                    if (TopBottomCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionY();
                    }
                    if (LeftRightCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionX();
                    }
                }
            }
        }

        private bool TopBottomCollisionPaddle(Ball tmpBall, Paddle tmpPaddle)
        {
            if (tmpBall.Right > tmpPaddle.Left && tmpBall.Left < tmpPaddle.Right) // Ball within block's width
            {
                if (tmpBall.Bottom > tmpPaddle.Top && tmpBall.Top < tmpPaddle.Bottom)
                {
                    if (tmpBall.Bottom > tmpPaddle.Top && tmpBall.Top < tmpPaddle.Top ||
                        tmpBall.Top < tmpPaddle.Bottom && tmpBall.Bottom > tmpPaddle.Bottom)
                        return true;
                }
            }
            return false;
        }

        private bool LeftRightCollisionPaddle(Ball tmpBall, Paddle tmpPaddle)
        {
            if (tmpBall.Bottom > tmpPaddle.Top && tmpBall.Top < tmpPaddle.Bottom) // Ball within block's height
            {
                if (tmpBall.Right > tmpPaddle.Left && tmpBall.Left < tmpPaddle.Right)
                {
                    if (tmpBall.Right > tmpPaddle.Left && tmpBall.Left < tmpPaddle.Left ||
                        tmpBall.Left < tmpPaddle.Right && tmpBall.Right > tmpPaddle.Right)
                        return true;
                }
            }
            return false;
        }

        private bool TopBottomCollisionBlock(Ball tmpBall, Block tmpBlock)
        {
            if (tmpBall.Right > tmpBlock.Left && tmpBall.Left < tmpBlock.Right) // Ball within block's width
            {
                if (tmpBall.Bottom > tmpBlock.Top && tmpBall.Top < tmpBlock.Bottom)
                {
                    if (tmpBall.Bottom > tmpBlock.Top && tmpBall.Top < tmpBlock.Top || 
                        tmpBall.Top < tmpBlock.Bottom && tmpBall.Bottom > tmpBlock.Bottom)
                        return true;
                }
            }
            return false;
        }

        private bool LeftRightCollisionBlock(Ball tmpBall, Block tmpBlock)
        {
            if (tmpBall.Bottom > tmpBlock.Top && tmpBall.Top < tmpBlock.Bottom) // Ball within block's height
            {
                if (tmpBall.Right > tmpBlock.Left && tmpBall.Left < tmpBlock.Right)
                {
                    if (tmpBall.Right > tmpBlock.Left && tmpBall.Left < tmpBlock.Left || 
                        tmpBall.Left < tmpBlock.Right && tmpBall.Right > tmpBlock.Right)
                        return true;
                }
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);   // this will force the Paint event to fire

            if ((kPaddle & KPress.left) == KPress.left) paddle.MoveLeft();
            if ((kPaddle & KPress.right) == KPress.right) paddle.MoveRight();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    kPaddle |= KPress.left;
                    break;
                case Keys.Right:
                    kPaddle |= KPress.right;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    kPaddle &= ~KPress.left;
                    break;
                case Keys.Right:
                    kPaddle &= ~KPress.right;
                    break;
            }
        }
    }
}
