namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Point STEVE_LOCATION = new Point(0, 0);
        const int VELOCITY = 8;

        public Form1()
        {
            InitializeComponent();
            STEVE_LOCATION = new Point(Sztivi.Left, Sztivi.Right);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Move(EDirection.TOP);
                    break;
                case Keys.Right:
                    Move(EDirection.RIGHT);
                    break;
                case Keys.Left:
                    Move(EDirection.LEFT);
                    break;
                case Keys.Down:
                    Move(EDirection.DOWN);
                    break;
            }
            Control c = this.GetChildAtPoint(Sztivi.Location);
            Console.WriteLine("");
        }

        public void Move(EDirection direction)
        {
            int top = Sztivi.Top;
            int left = Sztivi.Left;

            switch (direction)
            {
                case EDirection.TOP:
                    top -= VELOCITY;
                    break;
                case EDirection.RIGHT:
                    left += VELOCITY;
                    break;
                case EDirection.LEFT:
                    left -= VELOCITY;
                    break;
                case EDirection.DOWN:
                    top += VELOCITY;
                    break;
            }
            Sztivi.Top = top;
            Sztivi.Left = left;

            Point TopRight = new Point(left + Sztivi.Width, top);
            Point BottomLeft = new Point(left, Sztivi.Top + Sztivi.Height);
            Point BottomRight = new Point(left + Sztivi.Width, Sztivi.Top + Sztivi.Height);

            Control c = this.GetChildAtPoint(new Point(left, top));
            if (c.Name == "goldenApple")
            {
                MessageBox.Show("Gratulálok!");
            }
            if (c != null && c.Name != "Sztivi")
            {
                MessageBox.Show("Találat bal fellül");
                Sztivi.Location = STEVE_LOCATION;
            }

            c = this.GetChildAtPoint(TopRight);
            if (c != null && c.Name != "Sztivi")
            {
                MessageBox.Show("Találat jobb fellül");
                Sztivi.Location = STEVE_LOCATION;
            }

            c = this.GetChildAtPoint(BottomLeft);
            if (c != null && c.Name != "Sztivi")
            {
                MessageBox.Show("Találat allúl a bal oldalon");
                Sztivi.Location = STEVE_LOCATION;
            }

            c = this.GetChildAtPoint(BottomRight);
            if (c != null && c.Name != "Sztivi")
            {
                MessageBox.Show("Találat allúl a jobb oldalon");
                Sztivi.Location = STEVE_LOCATION;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}