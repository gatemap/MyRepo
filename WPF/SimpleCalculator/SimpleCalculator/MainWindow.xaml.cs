using System.Windows;


namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        enum Operator
        {
            None, Plus, Minus, Mult, Div, Mod, ResultAfter
        }

        Operator oper = Operator.None;
        decimal num1, num2 = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        void InputNumbericText(string num)
        {
            if(oper == Operator.ResultAfter && string.IsNullOrEmpty(textInput.Text))
            {
                textInput.Clear();
                oper = Operator.None;
            }

            textInput.Text += num;

            if (decimal.TryParse(textInput.Text, out decimal n))
                textInput.Text = $"{n}";
        }

        void OperateSetting(string op, Operator _oper)
        {
            num1 = decimal.Parse(textInput.Text);

            textInput.Text += op;
            oper = _oper;
        }

        private void Button_Click_Sign_Conversion(object sender, RoutedEventArgs e)
        {
            if (textInput.Text.Length < 1)
                return;
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            InputNumbericText("0");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InputNumbericText("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            InputNumbericText("2");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            InputNumbericText("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            InputNumbericText("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            InputNumbericText("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            InputNumbericText("6");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            InputNumbericText("7");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            InputNumbericText("8");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            InputNumbericText("9");
        }

        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            OperateSetting("+", Operator.Plus);
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            OperateSetting("-", Operator.Minus);
        }

        private void Button_Click_Mult(object sender, RoutedEventArgs e)
        {
            OperateSetting("*", Operator.Mult);
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            OperateSetting("/", Operator.Div);
        }

        private void Button_Click_Mod(object sender, RoutedEventArgs e)
        {
            OperateSetting("%", Operator.Mod);
        }

        private void Button_Click_All_Clear(object sender, RoutedEventArgs e)
        {
            textInput.Clear();
            oper = Operator.None;
        }

        private void Button_Click_CalcResult(object sender, RoutedEventArgs e)
        {
            if(textInput.Text.Contains("+"))
                num2 = decimal.Parse(textInput.Text.Remove(0, textInput.Text.IndexOf("+")));
            else if (textInput.Text.Contains("-"))
                num2 = decimal.Parse(textInput.Text.Remove(0, textInput.Text.IndexOf("-")));
            else if (textInput.Text.Contains("*"))
                num2 = decimal.Parse(textInput.Text.Remove(0, textInput.Text.IndexOf("*")));
            else if (textInput.Text.Contains("/"))
                num2 = decimal.Parse(textInput.Text.Remove(0, textInput.Text.IndexOf("/")));
            else if (textInput.Text.Contains("%"))
                num2 = decimal.Parse(textInput.Text.Remove(0, textInput.Text.IndexOf("%")));

            if(oper == Operator.Div || oper== Operator.Mod)
            {
                MessageBox.Show("Error! 0으로는 나눌 수 없습니다!");
                return;
            }

            switch (oper) 
            {
                case Operator.Plus:
                    textInput.Text = $"{num1}+{num2}={num1 + num2}";
                    break;
                case Operator.Minus:
                    textInput.Text = $"{num1}-{num2}={num1 - num2}";
                    break;
                case Operator.Mult:
                    textInput.Text = $"{num1}*{num2}={num1 * num2}";
                    break;
                case Operator.Div:
                    textInput.Text = $"{num1}/{num2}={num1 / num2}";
                    break;
                case Operator.Mod:
                    textInput.Text = $"{num1}%{num2}={num1 % num2}";
                    break;
                default:
                    break;
            }

            calcResultTextbox.Text += textInput.Text + "\r\n";
            oper = Operator.ResultAfter;
        }


        private void Button_Click_Remove_record(object sender, RoutedEventArgs e)
        {
            calcResultTextbox.Clear();
        }

        private void Button_Click_Backspace(object sender, RoutedEventArgs e)
        {
            // 아무것도 없으면 안지움
            if (textInput.Text.Length < 1)
                return;

            // 마지막 문자열이 연산자이면 삭제 안함
            if (textInput.Text[textInput.Text.Length - 1].Equals('+') ||
                textInput.Text[textInput.Text.Length - 1].Equals('-') ||
                textInput.Text[textInput.Text.Length - 1].Equals('*') ||
                textInput.Text[textInput.Text.Length - 1].Equals('/') ||
                textInput.Text[textInput.Text.Length - 1].Equals('%'))
                return;

            // 마지막꺼 하나 지움
            textInput.Text.Remove(textInput.Text.Length - 1, 1);
        }
    }
}