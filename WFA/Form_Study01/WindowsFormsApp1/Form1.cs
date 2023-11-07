using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<int> numList = new List<int>();
        public Form1()
        {
            InitializeComponent();

            //MessageBox.Show("Hellow, world!");

            //textBox_print.Text = "멀티\r\n라인\r\n텍스트박스\r\n입니다.";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;

            if (int.TryParse(numBox2.Text, out n))
                textBox_print.Text = (n + 100).ToString();
            else
                MessageBox.Show("숫자를 입력하세요.");

            //textBox_print.Text = textInputBox.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        void Calculation(string fom)
        {
            int num = 0;

            if(int.TryParse(fom, out num))
            {
                textBox_print.Text = num.ToString() + "\r\n";
                numList.Add(num);
            }
            else
            {
                // 숫자보다 연산자가 먼저 들어온 경우
                if(numList.Count < 1)
                {
                    MessageBox.Show("Error! 입력된 숫자가 없습니다");
                    return;
                }

                switch (fom)
                {
                    case "+":
                        textBox_print.Text += fom + "\r\n";
                        break;
                    case "-":
                        textBox_print.Text += fom + "\r\n";
                        break;
                    case "*":
                        textBox_print.Text += fom + "\r\n";
                        break;
                    case "/":
                        textBox_print.Text += fom + "\r\n";
                        break;
                    case "=":

                        break;
                    default:
                        MessageBox.Show("Error! 연산자 에러");
                        break;
                }
            }


            if(fom.Contains('+') || fom.Contains('-') || fom.Contains('*') || fom.Contains('/'))
            {
                string oper = fom.Contains('+') ? "+" : fom.Contains('-') ? "-" : fom.Contains('*') ? "*" : fom.Contains('/') ? "/" : string.Empty;
                
                // 사칙연산 이외의 연산자는 반환 처리
                if(string.IsNullOrEmpty(oper))
                {
                    
                    return;
                }
            }
            else
            {
                MessageBox.Show("Error! 연산자가 입력되지 않았습니다.");
                numBox2.Text = string.Empty;
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void subButton_Click(object sender, EventArgs e)
        {

        }

        private void multiButton_Click(object sender, EventArgs e)
        {

        }

        private void divideButton_Click(object sender, EventArgs e)
        {

        }
    }
}
