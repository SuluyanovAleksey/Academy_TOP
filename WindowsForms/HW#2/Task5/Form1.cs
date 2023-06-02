namespace Task5
{
    public partial class Form1 : Form
    {
        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private void ShowTime(object obj, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
        }
        public Form1()
        {
            InitializeComponent();

            labelTime.Text = DateTime.Now.ToLongTimeString();
            timer.Tick += new EventHandler(ShowTime);
            timer.Interval = 500;
            timer.Start();
        }
    }
}