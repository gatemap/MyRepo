using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ThreadPractice
{
    public partial class Form1 : Form
    {
        enum playerName
        {
            럭스, 징크스, 룰루, 뽀삐, 잔나
        }
        int locationX, locationY;
        List<Play> players;

        public Form1()
        {
            InitializeComponent();

            players = new List<Play>();
        }

        private void Startbutton_Click(object sender, EventArgs e)
        {
            // 리스트 박스 비우고
            if (resultListBox.Items.Count > 0)
                resultListBox.Items.Clear();

            // Play 창 열려 있는거 있으면 닫고
            if(players.Count > 0)
            {
                foreach (Play pl in players)
                    pl.Close();

                players.Clear();
            }
                

            locationX = Location.X + Size.Width;
            locationY = Location.Y;

            for (int i = 0; i < numericCount.Value; i++)
            {
                // 플레이어 이름을 위에서 enum문에 적어놓은 대로 사용한다
                Play player = new Play(((playerName)i).ToString());
                player.Location = new Point(locationX, locationY + player.Height * i);
                player.eventMessage += ThreadResultAdd;

                player.Show();
                player.ThreadStart();
                players.Add(player);
            }
        }

        void ThreadResultAdd(object sender, string result)
        {
            Invoke(new Action(delegate ()
            {
                Play play = sender as Play;

                // 만약 null값이 들어오면 함수 강종
                if (play == null)
                    return;

                resultListBox.Items.Add($"Player : {play.playerName}, Result : {result}");
            }));
        }
    }
}