using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using WinformGeneric.StudyPractice;

namespace WinformGeneric
{
    public partial class GenericStudy : Form
    {
        UserData data;

        static int sharedData = 0;
        static object lockObject = new object();

        List<RacingCar> cars;

        public GenericStudy()
        {
            InitializeComponent();

            data = new UserData();

            /*
            userData.Text += "1번 스레드 시작\r\n";

            var newThread = new Thread(new ThreadStart(MyThread));
            newThread.Start();


            userData.Text += "1번 스레드 끝\r\n";
            */

            /*
            Thread thread1 = new Thread(UpdateData1);
            Thread thread2 = new Thread(UpdateData2);

            thread1.Start();
            thread2.Start();


            // join : 메인 스레드는 이 스레드가 끝날 때까지 대기
            thread1.Join();
            thread2.Join();
            */

            cars = new List<RacingCar>();

            for (int i = 0; i < 5; i++)
                cars.Add(new RacingCar((i + 1).ToString()));

            
            for (int i = 0; i < cars.Count; i++)
                cars[i].RacingStart(userData);

            bool racingEnd = false;

            while(true)
            {
                Thread.Sleep(500);
                foreach(RacingCar car in cars)
                {
                    if (!car.racingEnd)
                    {
                        racingEnd = false;
                        break;
                    }
                    else
                        racingEnd = true;
                }

                if (racingEnd)
                {
                    userData.Text += "레이싱 종료!";
                    break;
                }
            }
        }

        /*
        void MyThread()
        {
            userData.Text += "2번 스레드 시작\r\n";
            Thread.Sleep(100);
            userData.Text += "2번 스레드 끝\r\n";
        }
        */

        /*
        void UpdateData1()
        {
            for (int i = 0; i < 10; i++)
            {
                lock(lockObject) 
                { 
                    sharedData++;
                    userData.Text += $"1 : {sharedData} \r\n";
                }
            }
        }

        void UpdateData2()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (lockObject)
                {
                    sharedData++;
                    userData.Text += $"2 : {sharedData} \r\n";
                }
            }
        }
        */
        private void FileOpen_Click(object sender, EventArgs e)
        {
            // 파일 열기 시작경로 설정
            openFileDialog1.InitialDirectory = "C:\\Users\\space\\Downloads";
            openFileDialog1.Filter = "*.csv|";

            // ShowDialog()를 실행해야 파일 오픈창이 열림
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                userData.Text = File.ReadAllText(openFileDialog1.FileName);
                // 파일의 유저 정보를 분류한다
                data.SortOutUserData(userData.Text);
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(data.CheckLoginSuccess(idTextBox.Text, passwordTextBox.Text)))
            {
                MessageBox.Show("아이디 혹은 비밀번호가 잘못되었습니다.");
                passwordTextBox.Clear();
            }
            else
            {
                MessageBox.Show($"로그인 성공!\r\n{idTextBox.Text}, {data.CheckLoginSuccess(idTextBox.Text, passwordTextBox.Text)}");
            }
        }
    }
}
