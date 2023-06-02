using System.Runtime.CompilerServices;

namespace Task3
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int random_button_index = 0;
        Random rnd = new Random();
        
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(HideButton);
            KeyPreview = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode == Keys.Enter) timer.Start();
            if (e.KeyCode == Keys.Escape)
            {
                timer.Stop();
                Controls[random_button_index].Enabled = true;
            }
        }

        private void HideButton(object vObject, EventArgs e)
        {
            Controls[random_button_index].Enabled = true;
            random_button_index = rnd.Next(0, 8);
            Controls[random_button_index].Enabled = false;         
        }       
    }
}