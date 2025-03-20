namespace ITEC145FinalProject
{
    public partial class Form1 : Form
    {
        //Random rnd = new Random();
        List<Ball> balls = new List<Ball>();
        List<Paddle> paddles = new List<Paddle>();
        //Player paddle = new Player();
        Ball ball = new Ball(100, 100);
        Ball ball2 = new Ball(250, 10);
        Paddle paddle = new Paddle(225, 550);

        enum KPress { none = 0, right = 1, left = 2 };
        KPress kPaddle = KPress.none;

        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);


            balls.Add(ball);
            balls.Add(ball2);
            paddles.Add(paddle);
            //Controls.Add(paddle.picPlayer);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);
            foreach (Paddle paddle in paddles)
                paddle.Draw(e.Graphics);
            foreach (Ball ball in balls)
            {
                if (CollisionTest(ball, paddle))
                {
                    ball.ChangeDirection();
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);   // this will force the Paint event to fire

            if ((kPaddle & KPress.left) == KPress.left) paddle.MoveLeft();
            if ((kPaddle & KPress.right) == KPress.right) paddle.MoveRight();
        }

        private bool CollisionTest(Ball tmpBall, Paddle tmpPaddle)
        {
            if (tmpBall.X + tmpBall.Width < tmpPaddle.X)
                return false;
            if (tmpPaddle.X + tmpPaddle.Width < tmpBall.X)
                return false;
            if (tmpBall.Y + tmpBall.Height < tmpPaddle.Y)
                return false;
            if (tmpPaddle.Y + tmpPaddle.Height < tmpBall.Y)
                return false;

            return true;
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
