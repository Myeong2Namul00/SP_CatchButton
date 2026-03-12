namespace CS_Week02_22017011_CatchButton
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("궁서체", 36F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.Location = new Point(187, 97);
            label1.Name = "label1";
            label1.Size = new Size(413, 48);
            label1.TabIndex = 0;
            label1.Text = "버튼 을 눌러보소";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 255, 192);
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 5;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("궁서", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button1.Location = new Point(301, 266);
            button1.Name = "button1";
            button1.Size = new Size(175, 64);
            button1.TabIndex = 1;
            button1.Text = "시작하기";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("궁서", 12F, FontStyle.Regular, GraphicsUnit.Point, 129);
            label2.Location = new Point(340, 160);
            label2.Name = "label2";
            label2.Size = new Size(101, 16);
            label2.TabIndex = 2;
            label2.Text = "최고 기록 : 0";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MainWindow";
            Text = "버튼 을 누르기 게임";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
    }
}