using System.Xml.XPath;

namespace ITEC145FinalProject
{
    public partial class Form1 : Form
    {
        //lists of objects
        List<Ball> balls = new List<Ball>();
        List<Paddle> paddles = new List<Paddle>();
        List<Block> blocks = new List<Block>();

        //object instances
        Ball ball = new Ball(100, 100);
        Paddle paddle = new Paddle(225, 550);
        Block block = new Block(225, 100);

        //enum for paddle movement
        enum KPress { none = 0, right = 1, left = 2 };
        KPress kPaddle = KPress.none;

        //enum for side
        public enum CollisionSide
        {
            None,
            Top,
            Bottom,
            Left,
            Right
        }

        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //add objects to lists
            balls.Add(ball);
            paddles.Add(paddle);
            blocks.Add(block);
        }







        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw the ball, paddle, and block(s)
            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);
            foreach (Paddle paddle in paddles)
                paddle.Draw(e.Graphics);
            foreach (Block block in blocks)
                block.Draw(e.Graphics);

            //collision detection
            foreach (Ball ball in balls)
            {
                label1.Text = $"X: {ball.XPositive}";
                label2.Text = $"Y: {ball.YPositive}";

                BlockCollisionTest(ball);

                //if (PaddleCollision(ball, paddle))
                //{
                //    ball.ChangeDirectionY();
                //}
            }   
        }

        private bool PaddleCollision(Ball tmpBall, Paddle tmpPaddle)
        {
            if (tmpBall.X + tmpBall.Width < tmpPaddle.X)
                return false;
            if (tmpPaddle.X + tmpPaddle.Width < tmpBall.X)
                return false;
            if (tmpBall.Y + tmpBall.Height < tmpPaddle.Y)
                return false;
            if (tmpPaddle.Y + tmpPaddle.Height < tmpBall.Y)
                return false;

            return true; //if true, there HAS been a collision
        }

        private void BlockCollisionTest(Ball b)
        {
            CollisionSide ppp = GetCollisionSide(ball, block);
            switch (ppp)
            {
                case CollisionSide.Left:
                    label3.Text = "Collision on the Left";
                    b.ChangeDirectionX();
                    break;

                case CollisionSide.Right:
                    label3.Text = "Collision on the Right";
                    b.ChangeDirectionX();
                    break;

                case CollisionSide.Top:
                    label3.Text = "Collision on the Top";
                    b.ChangeDirectionY();
                    break;

                case CollisionSide.Bottom:
                    label3.Text = "Collision on the Bottom";
                    b.ChangeDirectionY();
                    break;

                case CollisionSide.None:
                default:
                    label3.Text = "No collision detected";
                    break;
            }
        }

        public CollisionSide GetCollisionSide(Ball gBall, Block gBlock)
        {
            // Calculate the distances from rect1's edges to rect2
            int deltaLeft = gBlock.Right - gBall.Left;
            int deltaRight = gBall.Right - gBlock.Left;
            int deltaTop = gBlock.Bottom - gBall.Top;
            int deltaBottom = gBall.Bottom - gBlock.Top;

            // Get the smallest penetration depth
            int minHorizontal = Math.Min(deltaLeft, deltaRight);
            int minVertical = Math.Min(deltaTop, deltaBottom);

            // Determine if horizontal or vertical collision is stronger
            if (minHorizontal < minVertical)
            {
                return (deltaLeft < deltaRight) ? CollisionSide.Left : CollisionSide.Right;
            }
            else
            {
                return (deltaTop < deltaBottom) ? CollisionSide.Top : CollisionSide.Bottom;
            }
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
