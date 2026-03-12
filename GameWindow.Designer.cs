namespace CS_Week02_22017011_CatchButton
{
    partial class GameWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button button1;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            endLabel = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 255, 192);
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 3;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("궁서", 14F, FontStyle.Bold, GraphicsUnit.Point, 129);
            button1.Location = new Point(350, 168);
            button1.Name = "button1";
            button1.Size = new Size(75, 75);
            button1.TabIndex = 0;
            button1.Text = "해로운 버튼";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.MouseDown += button1_MouseDown;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("궁서", 12F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(120, 16);
            label2.TabIndex = 2;
            label2.Text = "남은 시간 : 00";
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("궁서", 48F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label1.ForeColor = Color.FromArgb(0, 0, 0, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(800, 450);
            label1.TabIndex = 1;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Paint += label1_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("궁서", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 129);
            label3.Location = new Point(645, 9);
            label3.Name = "label3";
            label3.Size = new Size(46, 27);
            label3.TabIndex = 3;
            label3.Text = "00";
            // 
            // endLabel
            // 
            endLabel = new Label();
            endLabel.Dock = DockStyle.Fill;
            endLabel.Font = new Font("궁서", 24F, FontStyle.Bold, GraphicsUnit.Point, 129);
            endLabel.Location = new Point(0, 0);
            endLabel.Name = "endLabel";
            endLabel.Size = new Size(100, 23);
            endLabel.TabIndex = 0;
            endLabel.TextAlign = ContentAlignment.MiddleCenter;
            endLabel.Visible = false;
            endLabel.BackColor = Color.FromArgb(255, 224, 192);
            endLabel.ForeColor = Color.Black;
            endLabel.Text = "";

            // 
            // finalScoreLabel
            // 
            finalScoreLabel = new Label();
            finalScoreLabel.AutoSize = false;
            finalScoreLabel.Dock = DockStyle.Top;
            finalScoreLabel.Height = 60;
            finalScoreLabel.Font = new Font("궁서", 20F, FontStyle.Bold, GraphicsUnit.Point, 129);
            finalScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            finalScoreLabel.ForeColor = Color.Black;
            finalScoreLabel.BackColor = Color.FromArgb(255, 224, 192);
            finalScoreLabel.Visible = false;
            finalScoreLabel.Text = "점수 : 00";
            // 
            // GameWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 224, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(finalScoreLabel);
            Controls.Add(endLabel);
            Name = "GameWindow";
            Text = "버튼을 빠르게 클릭하소";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Label label3;
        private Label endLabel;
        private Label finalScoreLabel;
    }
}
