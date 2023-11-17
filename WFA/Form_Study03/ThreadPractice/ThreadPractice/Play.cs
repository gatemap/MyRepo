using System;
using System.Threading;
using System.Windows.Forms;

namespace ThreadPractice
{
    public partial class Play : Form
    {
        public delegate void delMessage(object sender, string result);
        public event delMessage eventMessage;

        public string playerName { get; private set; } = string.Empty;

        Thread thread = null;
        static int rank = 1;

        public Play(string name)
        {
            InitializeComponent();

            playerNameLabel.Text = playerName = name;
            rank = rank > 1 ? 1 : rank;
            giveUpButton.Enabled = true;
        }

        public void ThreadStart()
        {
            thread = new Thread(Run);
            thread.IsBackground = true;

            thread.Start();
        }

        void Run()
        {
            Random rand = new Random();
            int randProgress = 0;

            while(progressBar.Value < 100) 
            {
                // thread 도는 동안 UI부분에 대해 뭔가 건들면 필요한 조건문
                if (InvokeRequired)
                {
                    Invoke(new Action(delegate ()
                    {
                        randProgress = rand.Next(1, 11);

                        // progressBar.Value가 100이 넘어가면 오류가 발생하므로 예외를 걸어준다
                        if (progressBar.Value + randProgress > 100)
                            progressBar.Value = 100;
                        else
                            progressBar.Value += randProgress;

                        progressLabel.Text = $"진행 상황 표시 : {progressBar.Value}%";
                        Refresh();
                    }));
                }

                Thread.Sleep(300);
            }

            eventMessage(this, $"{rank}등으로 완주! (Thread complete)");
            rank++;
        }

        private void giveUpButton_Click(object sender, EventArgs e)
        {
            // 스레드가 살아있지 않거나, 이미 바가 100인 경우 암것도 안함
            if (!thread.IsAlive || progressBar.Value >= 100)
                return;

            Invoke(new Action(delegate ()
            {
                thread.Abort();
                eventMessage(this, "포기함! (Thread Stop)");
                giveUpButton.Enabled = false;
            }));
        }
    }
}
