using System;
using System.IO;
using System.Windows.Forms;

namespace WinformGeneric
{
    public partial class GenericStudy : Form
    {
        UserData data;

        public GenericStudy()
        {
            InitializeComponent();

            data = new UserData();
        }

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
