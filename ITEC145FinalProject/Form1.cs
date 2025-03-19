namespace ITEC145FinalProject
{
    public partial class Form1 : Form
    {
        List<Ball> balls = new List<Ball>();

        public Form1()
        {
            InitializeComponent();
            Ball.mainForm = this;

            //Steve said to add these
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            Ball ball = new Ball(100, 100);
            balls.Add(ball);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Ball ball in balls)
                ball.Draw(e.Graphics);

            for (int i = 0; i < balls.Count - 1; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    if (BallCollisionTest(balls[i], balls[j]))
                    {
                        balls[i].ChangeDirection();
                        balls[j].ChangeDirection();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate(false);   // this will force the Paint event to fire
        }

        private bool BallCollisionTest(Ball ball1, Ball ball2)
        {
            if (ball1.X + ball1.Width < ball2.X)
                return false;
            if (ball2.X + ball2.Width < ball1.X)
                return false;
            if (ball1.Y + ball1.Height < ball2.Y)
                return false;
            if (ball2.Y + ball2.Height < ball1.Y)
                return false;

            return true;
        }
    }
}
