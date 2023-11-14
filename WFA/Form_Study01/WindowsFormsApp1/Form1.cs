using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

using MyMath;
using WindowsFormsApp1.Exception_study;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        enum Operateor
        {
            Add, Sub, Mult, Divide
        }
        decimal num1 = 0, num2 = 0;

        Calculate.calcData calcData;
        Calculate calc;

        Rifle gun;
        Knife knife;

        ExceptionTest test;

        public Form1()
        {
            InitializeComponent();
            // 초기화
            num1 = 0;
            num2 = 0;
            textBox_print.Clear();
            /*
            calc = new Calculate();
            calcData = new Calculate.calcData();
            */

            /*
            gun = new Rifle(30);
            knife = new Knife(100);
            gun.CombatPoint(30, 100);
            knife.CombatPoint(300, 10);
            */

            test = new ExceptionTest();
            test.ConvertNum();

            textBox_print.Text = test.textMessage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        private void addButton_Click(object sender, EventArgs e)
        {
            if (CalcBeforeParsing())
                PrintCalcResut(Operateor.Add);
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            if (CalcBeforeParsing())
                PrintCalcResut(Operateor.Sub);
        }

        private void multiButton_Click(object sender, EventArgs e)
        {
            if (CalcBeforeParsing())
                PrintCalcResut(Operateor.Mult);
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            if (CalcBeforeParsing())
            {
                if(num2 == 0)
                {
                    MessageBox.Show("Error!0으로는 나눌 수 없습니다.");
                    numBox2.Clear();
                    return;
                }

                PrintCalcResut(Operateor.Divide);
            }
        }

        /// <summary>
        /// 계산 전 숫자 파싱체크하려는 함수
        /// </summary>
        /// <returns></returns>
        bool CalcBeforeParsing()
        {
            if (decimal.TryParse(numBox1.Text, out num1) && decimal.TryParse(numBox2.Text, out num2))   
                return true;
            else
            {
                MessageBox.Show("Error! 숫자가 아닙니다.");
                numBox1.Clear();
                numBox2.Clear();
                return false;
            }
        }

        private void button_hello_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Olla");
        }

        private void button_input_Click(object sender, EventArgs e)
        {
            //
            //textBox_print.Text += textBox_input.Text + "\r\n";
            //textBox_input.Clear();
            
            // 구조체를 쓰려는 강제적인 변환. 식을 한번에 받기 때문에 필요한 작업
            List<decimal> nums = new List<decimal>();
            nums = calc.CalcFormInNum(textBox_input.Text, calc.FindOperator(textBox_input.Text));
            calcData.num1 = nums[0];
            calcData.num2 = nums[1];

            // 연산자가 +,-,/,*,% 이외의 것이 들어오면 \0이 들어가도록 했으므로 연산자 오류 메시지 박스를 띄우도록 한다
            if (calc.FindOperator(textBox_input.Text).Equals('\0'))
                MessageBox.Show("연산자 오류!");
            else
                calcData.operate = calc.FindOperator(textBox_input.Text);

            // 반환 값에 Error가 포함되어 있으면 오류 메시지 박스를 띄우도록 한다
            if(calc.CalculateComplete(calcData).Contains("Error"))
                MessageBox.Show($"{calc.CalculateComplete(calcData)}");
            else
                textBox_print.Text = calc.CalculateComplete(calcData);

            textBox_input.Clear();
        }


        /// <summary>
        /// 사칙연산 결과를 output 하는 함수
        /// </summary>
        /// <param name="oper"></param>
        void PrintCalcResut(Operateor oper)
        {
            string operation = string.Empty;
            decimal result = 0;

            switch (oper)
            {
                case Operateor.Add:
                    operation = "+";
                    result = num1 + num2;
                    break;
                case Operateor.Sub:
                    operation = "-";
                    result = num1 - num2;
                    break;
                case Operateor.Mult:
                    operation = "*";
                    result = num1 * num2;
                    break;
                case Operateor.Divide:
                    operation = "/";
                    result = num1 / num2;
                    break;
            }
            
            textBox_print.Text = string.Format("{0} {1} {2} = {3}\r\n계산 완료", num1, operation, num2, result);
        }
    }
}
