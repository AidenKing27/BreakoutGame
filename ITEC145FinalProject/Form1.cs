using System.Drawing.Text;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.XPath;

namespace ITEC145FinalProject
{
    public partial class Form1 : Form
    {
        //enum for paddle movement
        enum KPress { none = 0, right = 1, left = 2, up = 4 };
        KPress kPaddle = KPress.none;

        //lists of objects
        List<Ball> balls = new List<Ball>();
        List<Ball> tmpBalls = new List<Ball>();
        List<Block> blocks = new List<Block>();
        List<OneUp> oneUPs = new List<OneUp>();
        List<TempBall> tempBalls = new List<TempBall>();

        //paddle
        Paddle paddle = new Paddle(250, 600);
        TempBall tempBall;

        //blocks
        //-250 -> 60
        Block block01 = new Block(60, -250, 1, 1);
        Block block02 = new Block(150, -250, 1, 1);
        Block block03 = new Block(240, -250, 1, 1);
        Block block04 = new Block(330, -250, 1, 1);
        Block block05 = new Block(420, -250, 1, 1);
        Block block06 = new Block(510, -250, 1, 1);
        //-205 -> 105
        Block block07 = new Block(60, -205, 1, 2);
        Block block08 = new Block(150, -205, 1, 2);
        Block block09 = new Block(240, -205, 1, 2);
        Block block10 = new Block(330, -205, 1, 2);
        Block block11 = new Block(420, -205, 1, 2);
        Block block12 = new Block(510, -205, 1, 2);
        //-160 -> 150
        Block block13 = new Block(60, -160, 1, 3);
        Block block14 = new Block(150, -160, 1, 3);
        Block block15 = new Block(240, -160, 1, 3);
        Block block16 = new Block(330, -160, 1, 3);
        Block block17 = new Block(420, -160, 1, 3);
        Block block18 = new Block(510, -160, 1, 3);
        //-115 -> 195
        Block block19 = new Block(60, -115, 1, 4);
        Block block20 = new Block(150, -115, 1, 4);
        Block block21 = new Block(240, -115, 1, 4);
        Block block22 = new Block(330, -115, 1, 4);
        Block block23 = new Block(420, -115, 1, 4);
        Block block24 = new Block(510, -115, 1, 4);

        //field variables
        public static int score;
        int lives = 3;
        int level;
        bool hasCollided = false;
        bool mainBallSpawned = false;
        bool canShoot = false;
        bool spcBallSpawned = false;
        bool isMoving = true;
        bool tempBallSpawned = true;
        DateTime dt = DateTime.Now;

        //GameArea picturebox
        public PictureBox picLives = new PictureBox();

        Bitmap l0 = new Bitmap("../../../resources/lives0.png");
        Bitmap l1 = new Bitmap("../../../resources/lives1.png");
        Bitmap l2 = new Bitmap("../../../resources/lives2.png");
        Bitmap l3 = new Bitmap("../../../resources/lives3.png");


        //font object
        PrivateFontCollection pfcPressStart2P = new PrivateFontCollection(); //PressStart2P

        public Form1()
        {
            InitializeComponent();

            tempBall = new TempBall(paddle.Left + paddle.Width / 2 - 15, paddle.Top - paddle.Height - 15);
            tempBalls.Add(tempBall);

            //set GameArea backcolour
            picGameArea.BackColor = Color.FromArgb(38, 38, 38);

            //fixed form size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //import and set font
            InitPressStart2PFont();
            lblScore.Font = new Font(pfcPressStart2P.Families[0], lblScore.Font.Size);
            lblLevel.Font = new Font(pfcPressStart2P.Families[0], lblLevel.Font.Size);

            //link the classes to Form1
            Ball.mainForm = this;
            Paddle.mainForm = this;

            //Lives picturebox (transparent)
            picLives.Location = new Point(25, 25);
            picLives.Size = new Size(140, 50);
            picLives.BackColor = Color.Transparent;
            picLives.BringToFront();
            Controls.Add(picLives);

            //Steve said to add these for optimizations
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


        private void picGameArea_Paint(object sender, PaintEventArgs e)
        {
            //draw the paddle
            paddle.Draw(e.Graphics);

            if (tempBallSpawned)
                tempBall.Draw(e.Graphics);

            //draw the blocks
            foreach (Block block in blocks)
                block.Draw(e.Graphics);

            //draw the ball if its alive
            foreach (Ball ball in balls)
                if (ball.IsAlive)
                    ball.Draw(e.Graphics);

            //draw the oneUp as well as do collision detection w/ the paddle
            foreach (OneUp oneUp in oneUPs)
            {
                oneUp.Draw(e.Graphics);
                oneUp.Fall();
                if (CollisionPaddle1UP(oneUp, paddle))
                {
                    lives++;
                    oneUp.IsUsed = true;
                }
            }

        }

        //found how to import fonts from: stackoverflow.com/questions/1297264/using-custom-fonts-on-a-label-on-winforms
        void InitPressStart2PFont()
        {
            //get length of file in bytes and create an array of the byte data
            int fontLength = Properties.Resources.PressStart2P.Length;
            byte[] fontData = Properties.Resources.PressStart2P;

            //does something with memory allocation
            System.IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontData, 0, data, fontLength);
            pfcPressStart2P.AddMemoryFont(data, fontLength);
        }

        //private void ReadHighScore()
        //{
        //    //Open a StreamReader for dynamicScores.txt and add every number to a list, then close it
        //    StreamReader scoreInput = new StreamReader("../../../resources/highscores.txt");
        //    while (scoreInput.EndOfStream == false)
        //    {
        //        string s = scoreInput.ReadLine();
        //        dynamicScores.Add(double.Parse(s));
        //    }
        //    scoreInput.Close();
        //    //foreach item in the list, check which number is the highest and set the variable
        //    foreach (double x in dynamicScores)
        //    {
        //        if (x > dynamicHighScore)
        //        {
        //            dynamicHighScore = x;
        //        }
        //    }
        //    //Display High Score
        //    lblHighScore.Text = "High Score: " + dynamicHighScore.ToString("n2");
        //}

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //steve said this will force the Paint event to fire
            picGameArea.Invalidate(false);

            //paddle movement
            if ((kPaddle & KPress.left) == KPress.left)
            {
                paddle.MoveLeft();
                tempBall.MoveLeft();
            }

            if ((kPaddle & KPress.right) == KPress.right)
            {
                paddle.MoveRight();
                tempBall.MoveRight();
            }
            if ((kPaddle & KPress.up) == KPress.up)
            {
                if (!mainBallSpawned && canShoot)
                {
                    balls.Add(new Ball(paddle.Left + paddle.Width / 2 - 15, paddle.Top - 35));
                    mainBallSpawned = true;
                    canShoot = false;
                    tempBallSpawned = false;
                }
                
            }

            //update the lives pictures & check if the game should end
            if (lives == 3) picLives.Image = l3;
            if (lives == 2) picLives.Image = l2;
            if (lives == 1) picLives.Image = l1;
            if (lives == 0)
            {
                tempBallSpawned = false;
                picLives.Image = l0;
                gameTimer.Enabled = false;
                MessageBox.Show("YOU LOSE!");
                Application.Restart();
            }

            //update the score
            lblScore.Text = score.ToString("d5");

            //block movement
            //shout my guy chatgpt for reworking my original logic
            //essentially moves the blocks down from off the screen
            //once they hit the spot they need to, stop moving and update booleans to allow for shooting
            //chatgpt added the "shouldStop" boolean and seems to work nicely
            if (isMoving)
            {
                foreach (Block block in blocks)
                {
                    block.MoveDown();

                    bool shouldStop =
                        (block.Colour == 1 && block.Top >= 60) ||
                        (block.Colour == 2 && block.Top >= 105) ||
                        (block.Colour == 3 && block.Top >= 150) ||
                        (block.Colour == 4 && block.Top >= 195);

                    if (shouldStop)
                    {
                        block.StopMoving();
                        block.Moving = false;

                        if (block.Colour == 1)
                        {
                            isMoving = false;
                            canShoot = true;
                        }
                    }
                }
            }


            //if all the blocks have been removed
            if (blocks.Count == 0)
            {
                //add them all back
                //blue
                blocks.Add(block01);
                blocks.Add(block02);
                blocks.Add(block03);
                blocks.Add(block04);
                blocks.Add(block05);
                blocks.Add(block06);
                //red
                blocks.Add(block07);
                blocks.Add(block08);
                blocks.Add(block09);
                blocks.Add(block10);
                blocks.Add(block11);
                blocks.Add(block12);
                //yellow
                blocks.Add(block13);
                blocks.Add(block14);
                blocks.Add(block15);
                blocks.Add(block16);
                blocks.Add(block17);
                blocks.Add(block18);
                //green
                blocks.Add(block19);
                blocks.Add(block20);
                blocks.Add(block21);
                blocks.Add(block22);
                blocks.Add(block23);
                blocks.Add(block24);

                //regenerate property
                foreach (Block block in blocks)
                {
                    block.SetBlocks(block.Colour);
                }

                //reset the moving property
                isMoving = true;

                //increase and display the level
                level += 1;
                lblLevel.Text = $"LVL:{level:d2}";

                //health and position resets
                foreach (Block block in blocks)
                {
                    block.Moving = true;
                    block.Speed = 5;
                    //reset the health
                    block.Health = 1;
                    //reset the Y position based on its colour
                    block.ResetLocation();
                }
            }

            //detection checks for the all balls
            foreach (Ball ball in balls)
            {
                //check if it has fallen off the bottom of the screen
                FallOffScreen(ball);

                //check if the ball has collided on either the top or bottom of the paddle
                if (CollisionPaddleBall(ball, paddle))
                {
                    //calculates a slice value from 0 to 1 based on the position between very top to very bottom of paddle
                    double slice = (ball.Left + (ball.Width / 2)) - paddle.Left;
                    slice /= paddle.Width;

                    //if the slice is slightly above or below 1 or 0, set to exactly 1 or 0 respectively
                    if (slice < 0) slice = 0;
                    if (slice > 1) slice = 1;
                    //offset the slice from (0 <-> 1) to (-0.5 <-> 0.5) to account for positive and negative trajectories
                    slice -= .5;

                    //change direction based on the slice value
                    ball.ChangeDirectionBySlice(slice);
                }

                //detection checks for all blocks (nested in ball loop)
                foreach (Block block in blocks)
                {
                    //check if the ball has collided on either the top or bottom of the blocks
                    if (TopBottomCollisionBlock(ball, block))
                    {
                        //change Y direction
                        ball.ChangeDirectionY();

                        //no idea if this is working but if i touch it the world might explode
                        if (!hasCollided)
                        {
                            //no idea if this is working but if i touch it the world might explode
                            hasCollided = true;
                            block.TakeDamage();

                            //is it a spawner block
                            if (block.IsSpawner)
                            {
                                TimeSpan ts = DateTime.Now - dt;
                                if (ts.TotalMilliseconds > 100)
                                {
                                    dt = DateTime.Now;
                                    switch (block.Colour)
                                    {
                                        case 1:
                                        case 2:
                                        case 3:
                                        case 4:
                                            tmpBalls.Add(new Ball(block.Left + block.Width / 2, block.Top + block.Height, block.Colour));
                                            spcBallSpawned = true;
                                            break;
                                    }
                                }
                            }
                            //is it a grower block
                            if (block.IsGrower) paddle.Grow();
                            //is it a life block
                            if (block.Is1UP) oneUPs.Add(new OneUp(block.Left + block.Width / 2, block.Top + block.Height));
                            //is it a strong block
                            if (block.IsStrong) block.Break();
                        }

                    }
                    //check if the ball has collided on either the left or the right of the blocks
                    if (LeftRightCollisionBlock(ball, block))
                    {
                        //change X direction
                        ball.ChangeDirectionX();

                        //no idea if this is working but if i touch it the world might explode
                        if (!hasCollided)
                        {
                            //no idea if this is working but if i touch it the world might explode
                            hasCollided = true;
                            block.TakeDamage();

                            //is it a spawner block
                            if (block.IsSpawner)
                            {
                                //no idea if this is working but if i touch it the world might explode
                                TimeSpan ts = DateTime.Now - dt;
                                if (ts.TotalMilliseconds > 100)
                                {
                                    dt = DateTime.Now;
                                    switch (block.Colour)
                                    {
                                        case 1:
                                        case 2:
                                        case 3:
                                        case 4:
                                            tmpBalls.Add(new Ball(block.Left + block.Width / 2, block.Top + block.Height, block.Colour));
                                            spcBallSpawned = true;
                                            break;
                                    }
                                }
                            }
                            //is it a grower block
                            if (block.IsGrower) paddle.Grow();
                            //is it a life block
                            if (block.Is1UP) oneUPs.Add(new OneUp(block.Left + block.Width / 2, block.Top + block.Height));
                            //is it a strong block
                            if (block.IsStrong) block.Break();
                        }
                    }
                }
                //no idea if this is working but if i touch it the world might explode
                hasCollided = false;
            }
            //add any special balls from the tmpBalls list to the main list and clear the tmpBalls list
            balls.AddRange(tmpBalls);
            tmpBalls.Clear();


            //used ChatGPT to learn how the lambda expression and operator (=>) works
            //the RemoveAll function takes an argument, either true or false
            //this will parse over all items in the lists and check their condition and remove them from the list

            //remove block from list if health is 0 or less
            blocks.RemoveAll(block => block.Health <= 0);
            //remove oneups from list if it is used
            oneUPs.RemoveAll(oneUp => oneUp.IsUsed);
            //remove all dead balls
            balls.RemoveAll(ball => !ball.IsAlive);

            //if no main (non-special) balls exist after cleanup
            bool anyMainBallsLeft = balls.Any(ball => !ball.IsSpecial);

            //if the ball list has no entries,
            //and you currently cannot shoot,
            //and if there is no main balls left,
            //and if the blocks are not moving
            //then you can decrement the lives and reset your ability to shoot
            if (balls.Count == 0 && !canShoot && !anyMainBallsLeft && !isMoving)
            {
                tempBallSpawned = true;
                canShoot = true;
                lives--;
            }
        }


        //falling off screen checks to set the ball's alive property and to remove anything that needs to be removed
        private void FallOffScreen(Ball b)
        {
            if (b.Bottom >= picGameArea.Bottom)
            {
                b.IsAlive = false;

                if (b.IsSpecial)
                {
                    spcBallSpawned = false;
                    tmpBalls.Remove(b);
                }
                if (!b.IsSpecial)
                {
                    mainBallSpawned = false;
                }
            }
        }
        //top and bottom collision detection between block and ball
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
        //left and right collision detection between block and ball
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
        //collision detection between paddle and ball
        private bool CollisionPaddleBall(Ball b, Paddle p)
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
        //collision detection between paddle and 1UP
        private bool CollisionPaddle1UP(OneUp o, Paddle p)
        {
            if (o.Right < p.Left)
                return false;
            if (p.Right < o.Left)
                return false;
            if (o.Bottom < p.Top)
                return false;
            if (p.Bottom < o.Top)
                return false;

            return true;
        }

        //paddle movement
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
