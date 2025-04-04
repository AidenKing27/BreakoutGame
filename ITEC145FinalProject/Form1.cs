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
        Block block01 = new Block(60, 140, 1, 1);
        Block block02 = new Block(150, 140, 1, 1);
        Block block03 = new Block(240, 140, 1, 1);
        Block block04 = new Block(330, 140, 1, 1);
        Block block05 = new Block(420, 140, 1, 1);
        Block block06 = new Block(510, 140, 1, 1);

        Block block07 = new Block(60, 185, 1, 2);
        Block block08 = new Block(150, 185, 1, 2);
        Block block09 = new Block(240, 185, 1, 2);
        Block block10 = new Block(330, 185, 1, 2);
        Block block11 = new Block(420, 185, 1, 2);
        Block block12 = new Block(510, 185, 1, 2);

        Block block13 = new Block(60, 230, 1, 3);
        Block block14 = new Block(150, 230, 1, 3);
        Block block15 = new Block(240, 230, 1, 3);
        Block block16 = new Block(330, 230, 1, 3);
        Block block17 = new Block(420, 230, 1, 3);
        Block block18 = new Block(510, 230, 1, 3);

        Block block19 = new Block(60, 275, 1, 4);
        Block block20 = new Block(150, 275, 1, 4);
        Block block21 = new Block(240, 275, 1, 4);
        Block block22 = new Block(330, 275, 1, 4);
        Block block23 = new Block(420, 275, 1, 4);
        Block block24 = new Block(510, 275, 1, 4);

        //enum for paddle movement
        enum KPress { none = 0, right = 1, left = 2, up = 4 };
        KPress kPaddle = KPress.none;

        //GameArea picturebox
        public PictureBox picGameArea = new PictureBox();
        public PictureBox picLives2 = new PictureBox();

        bool hasCollided = false;
        bool spawnBall = false;

        //font object
        PrivateFontCollection pfcPressStart2P = new PrivateFontCollection(); //PressStart2P
        PrivateFontCollection pfcPixeboy = new PrivateFontCollection(); //Pixeboy

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //import and set fonts
            InitPixeboyFont();
            InitPressStart2PFont();
            lblScore.Font = new Font(pfcPressStart2P.Families[0], lblScore.Font.Size); //PressStart2P
            //lblScore.Font = new Font(pfcPixeboy.Families[0], lblScore.Font.Size); //Pixeboy


            //link the classes to Form1
            Ball.mainForm = this;
            Paddle.mainForm = this;

            //GameArea picturebox (invisible)
            picGameArea.Location = new Point(25, 107);
            picGameArea.Size = new Size(600, 650);

            //picLives2.Image = new Bitmap("lives3.png");
            picLives2.BringToFront();
            picLives2.Location = new Point(25, 25);
            picLives2.Size = new Size(140, 50);
            Controls.Add(picLives2);

            picLives2.BackColor = Color.Transparent;

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //add blocks to list
            blocks.Add(block01);
            blocks.Add(block02);
            blocks.Add(block03);
            blocks.Add(block04);
            blocks.Add(block05);
            blocks.Add(block06);

            blocks.Add(block07);
            blocks.Add(block08);
            blocks.Add(block09);
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
            blocks.Add(block21);
            blocks.Add(block22);
            blocks.Add(block23);
            blocks.Add(block24);
        }


        //found how to import fonts from: stackoverflow.com/questions/1297264/using-custom-fonts-on-a-label-on-winforms
        void InitPressStart2PFont()
        {
            int fontLength = Properties.Resources.PressStart2P.Length;
            byte[] fontData = Properties.Resources.PressStart2P;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfcPressStart2P.AddMemoryFont(data, fontLength);
        }
        void InitPixeboyFont()
        {
            int fontLength = Properties.Resources.Pixeboy.Length;
            byte[] fontData = Properties.Resources.Pixeboy;

            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfcPixeboy.AddMemoryFont(data, fontLength);
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
                    Ball ball = new Ball(paddle.Left + paddle.Width / 2 - 15, paddle.Top - 35);
                    balls.Add(ball);
                    spawnBall = true;
                }
            }

            if (paddle.Lives == 3)
            {
                picLives2.Image = new Bitmap("lives3_2.png");
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
            label1.Text = "";
            


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
