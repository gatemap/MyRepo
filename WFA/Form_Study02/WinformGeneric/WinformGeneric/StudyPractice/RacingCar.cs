using System;
using System.Threading;
using System.Windows.Forms;

namespace WinformGeneric.StudyPractice
{
    internal class RacingCar
    {
        Thread thread;
        decimal delaySecond = 0;
        string participant = string.Empty;

        static object lockObject = new object();

        public decimal totalTime { get; private set; } = 0;
        public bool racingEnd { get; private set; } = false;

        public RacingCar(string name) 
        { 
            participant = name;
        }

        public void RacingStart(TextBox box)
        {
            // 랜덤 시드값이 cpu 클락값에 따라 들어가서 한번 씩 쉬어준다
            //Thread.Sleep(150);
            // 이렇게 작성하면 매번 다른 값을 받아올 수 있다고 함
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            // 한 단위 움직이는 간격
            delaySecond = (decimal)(rand.Next(1, 11) * 0.1);

            thread = new Thread(() => RacingBuffer(box));
            thread.IsBackground = true;
            thread.Start();
        }

        void RacingBuffer(TextBox box)
        {
            for (int i = 0; i < 10; i++)
            {
                box.Text += $"{participant}, {i + 1}으로 이동\r\n";
                Thread.Sleep((int)(delaySecond * 1000));
                totalTime += delaySecond;
            }
            lock (lockObject)
            {
                racingEnd = true;
                box.Text += $"이름 : {participant}, 시간 : {totalTime}초에 도착!\r\n";
            }
        }
    }
}