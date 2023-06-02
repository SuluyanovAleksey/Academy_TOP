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
            Text = "����� " + left_mouse_click_num + " ���, ������ " + right_mouse_click_num + " ���, ������� " + middl_mouse_click_num + " ���";
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) left_mouse_click_num++;
            else if (e.Button == MouseButtons.Right) right_mouse_click_num++;
            else middl_mouse_click_num++;
            Text = "����� " + left_mouse_click_num + " ���, ������ " + right_mouse_click_num + " ���, ������� " + middl_mouse_click_num + " ���";
        }
    }
}