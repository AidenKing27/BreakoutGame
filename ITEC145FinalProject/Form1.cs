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
        Paddle paddle = new Paddle(225, 700);

        

        //blocks
        Block block1 = new Block(60, 120, 2);
        Block block2 = new Block(170, 120, 2);
        Block block3 = new Block(280, 120, 2);
        Block block4 = new Block(390, 120, 2);
        Block block5 = new Block(500, 120, 2);

        Block block6 = new Block(60, 165, 2);
        Block block7 = new Block(170, 165, 2);
        Block block8 = new Block(280, 165, 2);
        Block block9 = new Block(390, 165, 2);
        Block block10 = new Block(500, 165, 2);

        Block block11 = new Block(60, 210, 2);
        Block block12 = new Block(170, 210, 2);
        Block block13 = new Block(280, 210, 2);
        Block block14 = new Block(390, 210, 2);
        Block block15 = new Block(500, 210, 2);

        Block block16 = new Block(60, 255, 2);
        Block block17 = new Block(170, 255, 2);
        Block block18 = new Block(280, 255, 2);
        Block block19 = new Block(390, 255, 2);
        Block block20 = new Block(500, 255, 2);

        //enum for paddle movement
        enum KPress { none = 0, right = 1, left = 2 };
        KPress kPaddle = KPress.none;

        //GameArea picturebox
        public PictureBox picGameArea = new PictureBox();

        bool hasCollided = false;

        public Form1()
        {
            InitializeComponent();
            Ball ball = new Ball(paddle.Left + 50, paddle.Top - 25);
            //link the classes to Form1
            Ball.mainForm = this;
            Paddle.mainForm = this;

            int x;

            //GameArea picturebox (invisible)
            picGameArea.Location = new Point(25, 107);
            picGameArea.Size = new Size(600, 650);

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //add ball to list
            balls.Add(ball);

            //add blocks to list
            blocks.Add(block1);
            blocks.Add(block2);
            blocks.Add(block3);
            blocks.Add(block4);
            blocks.Add(block5);

            blocks.Add(block6);
            blocks.Add(block7);
            blocks.Add(block8);
            blocks.Add(block9);
            blocks.Add(block10);

            blocks.Add(block11);
            blocks.Add(block12);
            blocks.Add(block13);
            blocks.Add(block14);
            blocks.Add(block15);

            blocks.Add(block16);
            blocks.Add(block17);
            blocks.Add(block18);
            blocks.Add(block19);
            blocks.Add(block20);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the paddle, ball, and block(s)
            paddle.Draw(e.Graphics);

            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);
               
            foreach (Block block in blocks)
                block.Draw(e.Graphics);

            //collision detection checks
            foreach (Ball ball in balls)
            {
                if (TopBottomCollisionPaddle(ball, paddle))
                {
                    double slice = (ball.Left + (ball.Width / 2)) - paddle.Left;
                    slice /= paddle.Width;
                    // the above calculates a value from 0 to 1 based on the position between very top to very bottom of paddle
                    if (slice < 0) slice = 0;
                    if (slice > 1) slice = 1;
                    slice -= .5;    // because value will always be between 0-1, -.5 will scale it
                                    // to -.5 to +.5, regardless of paddle size

                    ball.ChangeDirectionBySlice(slice);

                }
                if (LeftRightCollisionPaddle(ball, paddle))
                {
                    //ball.ChangeDirectionX();
                }


                foreach (Block block in blocks)
                {
                    if (TopBottomCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionY();
                        if (!hasCollided)
                        {
                            hasCollided = true;
                            block.TakeDamage();
                        }
                    }
                    if (LeftRightCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionX();
                        if (!hasCollided)
                        {
                            hasCollided = true;
                            block.TakeDamage();
                        }
                    }
                    hasCollided = false;
                }
            }

            //remove block from list if health is 0 or less
            //used ChatGPT to learn how the lambda expression and operator (=>) works
            //the RemoveAll function takes an argument, either true or false
            //whichever case evaluates to true, remove from list
            //this will parse over all blocks in the List<Block> and check if their health is less than or equal to 0
            blocks.RemoveAll(block => block.Health <= 0);
        }

        private bool TopBottomCollisionPaddle(Ball b, Paddle p)
        {
            if (b.Right > p.Left && b.Left < p.Right)
            {
                if (b.Bottom > p.Top && b.Top < p.Bottom)
                {
                    if (b.Bottom > p.Top && b.Top < p.Top || b.Top < p.Bottom && b.Bottom > p.Bottom)
                    {
                        return true;
                    }   
                }
            }
            return false;
        }

        private bool LeftRightCollisionPaddle(Ball b, Paddle p)
        {
            if (b.Bottom > p.Top && b.Top < p.Bottom)
            {
                if (b.Right > p.Left && b.Left < p.Right)
                {
                    if (b.Right > p.Left && b.Left < p.Left || b.Left < p.Right && b.Right > p.Right)
                    {
                        return true;
                    }  
                }
            }
            return false;
        }

        private bool TopBottomCollisionBlock(Ball b, Block k)
        {
            if (b.Right > k.Left && b.Left < k.Right)
            {
                if (b.Bottom > k.Top && b.Top < k.Bottom)
                {
                    if (b.Bottom > k.Top && b.Top < k.Top || b.Top < k.Bottom && b.Bottom > k.Bottom)
                    {
                        return true;
                    }    
                }
            }
            return false;
        }

        private bool LeftRightCollisionBlock(Ball b, Block k)
        {
            if (b.Bottom > k.Top && b.Top < k.Bottom)
            {
                if (b.Right > k.Left && b.Left < k.Right)
                {
                    if (b.Right > k.Left && b.Left < k.Left || b.Left < k.Right && b.Right > k.Right)
                    {
                        return true;
                    }    
                }
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //steve said this will force the Paint event to fire
            this.Invalidate(false);   

            //paddle movement
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
