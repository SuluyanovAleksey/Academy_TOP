namespace Task1
{
    public partial class Form1 : Form
    {
        private int left_mouse_click_num = 0;
        private int right_mouse_click_num = 0;
        private int middl_mouse_click_num = 0;
        public Form1()
        {
            InitializeComponent();
            Text = "лева€ " + left_mouse_click_num + " раз, права€ " + right_mouse_click_num + " раз, средн€€ " + middl_mouse_click_num + " раз";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) left_mouse_click_num++;
            else if (e.Button == MouseButtons.Right) right_mouse_click_num++;
            else middl_mouse_click_num++;
            Text = "лева€ " + left_mouse_click_num + " раз, права€ " + right_mouse_click_num + " раз, средн€€ " + middl_mouse_click_num + " раз";
        }
    }
}