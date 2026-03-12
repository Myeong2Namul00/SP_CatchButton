namespace CS_Week02_22017011_CatchButton
{
    public partial class GameWindow : Form
    {
        private int score = 0;
        private System.Windows.Forms.Timer fadeTimer;
        private string[] sequence = new[] { "3", "2", "1", "START" };
        private int seqIndex = 0;
        private int alpha = 0; // 0..255
        private float scale = 1.0f;

        public GameWindow()
        {
            InitializeComponent();

            // 버튼 숨김
            button1.Visible = false;

            // 라벨 초기화
            label1.Text = "";

            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 25;
            fadeTimer.Tick += FadeTimer_Tick;

            // 초기화 및 시작
            seqIndex = 0;
            alpha = 255;
            label1.ForeColor = Color.FromArgb(0, 0, 0);
            label1.Text = sequence[seqIndex];
            fadeTimer.Start();

            this.DoubleBuffered = true;
        }

        private void label1_Paint(object? sender, PaintEventArgs e)
        {
            // 라벨 생성
            if (string.IsNullOrEmpty(label1.Text)) return;

            using (var bg = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillRectangle(bg, label1.ClientRectangle);
            }
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

            float baseSize = 48f;
            float fontSize = baseSize * scale;
            using var font = new Font("궁서", fontSize, FontStyle.Bold, GraphicsUnit.Point);

            var text = label1.Text;
            SizeF textSize = e.Graphics.MeasureString(text, font);

            float x = (label1.ClientSize.Width - textSize.Width) / 2f;
            float y = (label1.ClientSize.Height - textSize.Height) / 2f;

            using var brush = new SolidBrush(Color.FromArgb(alpha, 0, 0, 0));
            e.Graphics.DrawString(text, font, brush, x, y);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(255, 255, 192);
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Random rd = new Random();

            int maxX = this.ClientSize.Width - button1.Width;
            int maxY = this.ClientSize.Height - button1.Height;

            int nextX = rd.Next(0, Math.Max(1, maxX));
            int nextY = rd.Next(0, Math.Max(1, maxY));

            button1.Location = new Point(nextX, nextY);
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }

        private void FadeTimer_Tick(object? sender, EventArgs e)
        {
            // 페이드
            int step = 255 / (1000 / fadeTimer.Interval);
            if (step <= 0) step = 13;

            // 불투명도를 0에서 255로 조정
            alpha -= step;
            if (alpha < 0) alpha = 0;

            // 투명도 조절하며 크기 증가
            scale = 1.0f + (255 - alpha) / 255f * 2; // 1 -> 3

            label1.Invalidate();

            if (alpha <= 0)
            {
                // 50틱 딜레이
                fadeTimer.Stop();
                Task.Delay(50).ContinueWith(_ =>
                {
                    // 숨기기
                    this.Invoke(() =>
                    {
                        label1.ForeColor = Color.FromArgb(0, 0, 0, 0);
                        seqIndex++;
                        if (seqIndex >= sequence.Length)
                        {
                            // 타이머 종료 시 버튼 출력
                            label1.Text = "";
                            button1.Visible = true;
                        }
                        else
                        {
                            label1.Text = sequence[seqIndex];
                            // 초기화
                            alpha = 255;
                            scale = 1.0f;
                            fadeTimer.Start();
                        }
                    });
                });
            }
        }
    }
}
