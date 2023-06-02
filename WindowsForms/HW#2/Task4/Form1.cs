namespace Task4
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Size SizeScreen = Screen.PrimaryScreen.Bounds.Size;
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 55;
            timer.Tick += new EventHandler(FormMove);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                Location = new Point(0, 0);
                timer.Start();
            }
            if (e.KeyCode == Keys.Escape) timer.Stop();
        }

        private void FormMove(object sender, EventArgs e) {
            if (Location.X < SizeScreen.Width - ClientSize.Width & Location.Y == 0) {
                Location = new Point(Location.X + 20, 0);
                if (Location.X > SizeScreen.Width - ClientSize.Width) Location = new Point(SizeScreen.Width - ClientSize.Width,0);
            }

            if (Location.X == SizeScreen.Width - ClientSize.Width & Location.Y < SizeScreen.Height - ClientSize.Height) {
                Location = new Point(SizeScreen.Width - ClientSize.Width, Location.Y + 20);
                if(Location.Y > SizeScreen.Height - ClientSize.Height) Location = new Point(SizeScreen.Width - ClientSize.Width, SizeScreen.Height - ClientSize.Height);
            }
            if (Location.X > 0 & Location.Y == SizeScreen.Height - ClientSize.Height) {
                Location = new Point(Location.X - 20, SizeScreen.Height - ClientSize.Height);
                if (Location.X < 0) Location = new Point(0, SizeScreen.Height - ClientSize.Height);
            }
            if (Location.X == 0 & Location.Y > 0){
                Location = new Point(0, Location.Y - 20);
                if (Location.Y < 0) Location = new Point(0,0);
            }
        }
    }
}