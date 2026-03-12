using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CS_Week02_22017011_CatchButton
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // 예외처리
            foreach (Form open in Application.OpenForms)
            {
                if (open is GameWindow)
                {
                    MessageBox.Show("이미 게임 시작됨", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    open.BringToFront();
                    return;
                }
            }

            var gw = new GameWindow();
            gw.FormClosed += (s, args) => this.Close();
            gw.Show();
            this.Hide();
        }
    }
}
