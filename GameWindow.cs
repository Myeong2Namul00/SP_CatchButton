namespace CS_Week02_22017011_CatchButton
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
