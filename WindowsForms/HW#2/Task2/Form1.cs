using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left) {
                if ((e.X < 20 | e.X > ClientSize.Width - 20) | (e.Y < 20 | e.Y > ClientSize.Height- 20)) Text = "������ ��� ��������������";                
                if ((e.X > 20 & e.X < ClientSize.Width- 20) & (e.Y > 20 & e.Y < ClientSize.Height - 20)) Text = "������ ������ ��������������";
                if ((e.X == 20 | e.X == ClientSize.Width - 20) | (e.Y == 20 | e.Y == ClientSize.Height - 20)) Text = "������ �� ������� ��������������";
            }
            if (e.Button == MouseButtons.Right) {
                Text = "��������� �������: ������- " + ClientSize.Height.ToString() + " ������- " + ClientSize.Width.ToString();
            }
        }
    }
}