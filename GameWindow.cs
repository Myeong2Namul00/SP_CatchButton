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
        private System.Windows.Forms.Timer gameTimer;
        private int remainingTime = 0;
        private Random rnd = new Random();
        private Point lastButtonLocation = Point.Empty;

        public GameWindow()
        {
            InitializeComponent();

            // 버튼 숨김
            button1.Visible = false;

            // 라벨 초기화
            label1.Text = "";
            if (label2 != null) label2.Text = "남은 시간 : 00";
            if (label3 != null) label3.Text = "0";

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

        private void GameTimer_Tick(object? sender, EventArgs e)
        {
            remainingTime--;
            if (remainingTime < 0) remainingTime = 0;
            label2.Text = $"남은 시간 : {remainingTime:00}";

            if (remainingTime <= 0)
            {
                gameTimer.Stop();
                button1.Enabled = false;
                // 게임 종료 처리: 최고 점수 갱신
                    if (score > Program.HighScore)
                    {
                        Program.HighScore = score;
                        try
                        {
                            Properties.Settings.Default.HighScore = Program.HighScore;
                            Properties.Settings.Default.Save();
                        }
                        catch
                        {
                            // ignore save errors
                        }
                    }

                    // 종료 메시지 중앙표시 및 최종 점수 출력
                    if (finalScoreLabel != null)
                    {
                        finalScoreLabel.Text = $"점수 : {score:00}";
                        finalScoreLabel.Visible = true;
                        finalScoreLabel.BringToFront();
                    }

                    if (endLabel != null)
                    {
                        endLabel.Text = "창을 닫아 돌아가세요";
                        endLabel.Visible = true;
                        endLabel.BringToFront();
                    }
            }
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
            var rd = new Random();

            int margin = 10;
            int minX = margin;
            int minY = margin;
            int maxX = Math.Max(minX, this.ClientSize.Width - button1.Width - margin); // 최대 좌표
            int maxY = Math.Max(minY, this.ClientSize.Height - button1.Height - margin); // 최소 좌표

            // 최대 50번까지 시도해서 같은 위치 방지
            int attempts = 0;
            Point temploc;
            int minDistance = Math.Min(button1.Width, button1.Height);
            do
            {
                int nextX = rd.Next(minX, maxX + 1);
                int nextY = rd.Next(minY, maxY + 1);
                temploc = new Point(nextX, nextY);
                attempts++;
                
                if (attempts > 50) break;
            }
            while (!IsFarEnough(temploc, lastButtonLocation, minDistance));

            button1.Location = temploc;
            lastButtonLocation = temploc;

            Random rdscore = new Random();
            int add = rdscore.Next(5, 15);
            score = score + add;
            label3.Text = $"점수 : {score}";
        }

        private bool IsFarEnough(Point a, Point b, int minDistance)
        {
            if (b.IsEmpty) return true;
            int dx = a.X - b.X;
            int dy = a.Y - b.Y;
            return (dx * dx + dy * dy) >= (minDistance * minDistance);
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
                            // ensure UI elements are on top
                            if (label1 != null) label1.SendToBack();
                            if (button1 != null) button1.BringToFront();
                            if (label2 != null) label2.BringToFront();
                            if (label3 != null) label3.BringToFront();
                            // 게임 시작: 초기화 및 타이머 시작
                            score = 0;
                            if (label3 != null) label3.Text = $"점수 : {score}";
                            remainingTime = 99;
                            if (label2 != null) label2.Text = $"남은 시간 : {remainingTime:00}";
                            button1.Enabled = true;
                            if (gameTimer == null)
                            {
                                gameTimer = new System.Windows.Forms.Timer();
                                gameTimer.Interval = 200; // 0.2초
                                gameTimer.Tick += GameTimer_Tick;
                            }
                            gameTimer.Start();
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
