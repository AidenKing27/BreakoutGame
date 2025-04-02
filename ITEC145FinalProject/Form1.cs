using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
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
        Block block1 = new Block(60, 140, 2);
        Block block2 = new Block(170, 140, 2);
        Block block3 = new Block(280, 140, 2);
        Block block4 = new Block(390, 140, 2);
        Block block5 = new Block(500, 140, 2);

        Block block6 = new Block(60, 185, 2);
        Block block7 = new Block(170, 185, 2);
        Block block8 = new Block(280, 185, 2);
        Block block9 = new Block(390, 185, 2);
        Block block10 = new Block(500, 185, 2);

        Block block11 = new Block(60, 230, 2);
        Block block12 = new Block(170, 230, 2);
        Block block13 = new Block(280, 230, 2);
        Block block14 = new Block(390, 230, 2);
        Block block15 = new Block(500, 230, 2);

        Block block16 = new Block(60, 275, 2);
        Block block17 = new Block(170, 275, 2);
        Block block18 = new Block(280, 275, 2);
        Block block19 = new Block(390, 275, 2);
        Block block20 = new Block(500, 275, 2);

        //enum for paddle movement
        enum KPress { none, right, left, up };
        KPress kPaddle = KPress.none;

        //GameArea picturebox
        public PictureBox picGameArea = new PictureBox();
        public PictureBox picLives2 = new PictureBox();

        bool hasCollided = false;
        bool spawnBall = false;

        public Form1()
        {
            InitializeComponent();
            InitCustomLabelFont();


            //link the classes to Form1
            Ball.mainForm = this;
            Paddle.mainForm = this;

            //GameArea picturebox (invisible)
            picGameArea.Location = new Point(25, 107);
            picGameArea.Size = new Size(600, 650);


            //picLives2.Image = new Bitmap("lives3.png");
            picLives2.BringToFront();
            picLives2.Location = new Point(25, 25);
            picLives2.Size = new Size(138, 52);
            Controls.Add(picLives2);

            picLives2.BackColor = Color.Transparent;

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);



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

        void InitCustomLabelFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();

            int fontLength = Properties.Resources.Pixeboy.Length;

            byte[] fontdata = Properties.Resources.Pixeboy;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            Marshal.Copy(fontdata, 0, data, fontLength);

            pfc.AddMemoryFont(data, fontLength);

            lblScore.Font = new Font(pfc.Families[0], lblScore.Font.Size);
        }

        




        private void timer1_Tick(object sender, EventArgs e)
        {
            //steve said this will force the Paint event to fire
            this.Invalidate(false);

            //paddle movement
            if ((kPaddle & KPress.left) == KPress.left) paddle.MoveLeft();
            if ((kPaddle & KPress.right) == KPress.right) paddle.MoveRight();
            if ((kPaddle & KPress.up) == KPress.up)
            {
                if (!spawnBall)
                {
                    Ball ball = new Ball(paddle.Left + paddle.Width / 2 - 15, paddle.Top - 30);
                    balls.Add(ball);
                    spawnBall = true;
                }
            }

            if (paddle.Lives == 3)
            {
                picLives2.Image = new Bitmap("lives3.png");
            }
            if (paddle.Lives == 2)
            {
                picLives2.Image = new Bitmap("lives2.png");
            }
            if (paddle.Lives == 1)
            {
                picLives2.Image = new Bitmap("lives1.png");
            }
            if (paddle.Lives == 0)
            {
                picLives2.Image = new Bitmap("lives0.png");
                timer1.Enabled = false;
                MessageBox.Show("YOU LOSE!");
            }

            
            lblScore.Text = paddle.Score.ToString("d5");
            
            


            //detection checks for the ball
            foreach (Ball ball in balls)
            {
                //check if it has fallen off the bottom of the screen
                FallOffScreen(ball);

                //check if the ball has collided on either the top or bottom of the paddle
                if (TopBottomCollisionPaddle(ball, paddle))
                {
                    //calculates a slice value from 0 to 1 based on the position between very top to very bottom of paddle
                    double slice = (ball.Left + (ball.Width / 2)) - paddle.Left;
                    slice /= paddle.Width;

                    //if the slice is slightly above or below 1 or 0, set to exactly 1 or 0 respectively
                    if (slice < 0)
                    {
                        slice = 0;
                    }
                    if (slice > 1)
                    {
                        slice = 1;
                    }
                    //offset the slice from (0 <-> 1) to (-0.5 <-> 0.5) to account for positive and negative trajectories
                    slice -= .5;

                    //change direction based on the slice value
                    ball.ChangeDirectionBySlice(slice);
                }
                //check if the ball has collided on either the left or the right of the paddle
                if (LeftRightCollisionPaddle(ball, paddle))
                {
                    //ball.ChangeDirectionX();
                }

                //detection checks for blocks (nested in ball loop)
                foreach (Block block in blocks)
                {
                    //check if the ball has collided on either the top or bottom of the blocks
                    if (TopBottomCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionY();
                        if (!hasCollided)
                        {
                            hasCollided = true;
                            paddle.Score += 50;
                            block.TakeDamage();
                        }
                    }
                    //check if the ball has collided on either the left or the right of the blocks
                    if (LeftRightCollisionBlock(ball, block))
                    {
                        ball.ChangeDirectionX();
                        if (!hasCollided)
                        {
                            hasCollided = true;
                            paddle.Score += 50;
                            block.TakeDamage();
                        }
                    }
                }
                hasCollided = false;
            }

            //remove block from list if health is 0 or less
            //used ChatGPT to learn how the lambda expression and operator (=>) works
            //the RemoveAll function takes an argument, either true or false
            //whichever case evaluates to true, remove from list
            //this will parse over all blocks in the List<Block> and check if their health is less than or equal to 0
            blocks.RemoveAll(block => block.Health <= 0);
            balls.RemoveAll(ball => ball.IsAlive == false);


        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the paddle
            paddle.Draw(e.Graphics);

            //draw the blocks
            foreach (Block block in blocks)
                block.Draw(e.Graphics);

            //draw the ball
            if (spawnBall)
            {
                foreach (Ball ball in balls)
                    ball.Draw(e.Graphics);
            }
        }



        private void FallOffScreen(Ball b)
        {
            if (b.Top >= picGameArea.Bottom)
            {
                b.IsAlive = false;
                spawnBall = false;
                paddle.Lives -= 1;
            }
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
                case Keys.Up:
                    kPaddle |= KPress.up;
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
                case Keys.Up:
                    kPaddle &= ~KPress.up;
                    break;
            }
        }
    }
}
