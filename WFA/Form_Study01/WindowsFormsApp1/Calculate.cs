using System.Collections.Generic;
using System.Linq;

namespace MyMath
{
    internal class Calculate
    {
        public struct calcData
        {
            public decimal num1;
            public decimal num2;
            public char operate;
        }

        decimal Add(decimal a, decimal b) => a + b;
        decimal Sub(decimal a, decimal b) => a - b;
        decimal Mult(decimal a, decimal b) => a * b;
        decimal Div(decimal a, decimal b) => a / b;
        decimal Mod(decimal a, decimal b) => a % b;

        /// <summary>
        /// 계산식에서 숫자 2개를 찾아서 반환하는 함수
        /// </summary>
        /// <param name="calcForm"></param>
        /// <param name="oper"></param>
        /// <returns></returns>
        public List<decimal> CalcFormInNum(string calcForm, char oper)
        {
            List<decimal> result = new List<decimal>();
            string[] str = new string[2];
            str = calcForm.Split(oper);
            decimal num = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (decimal.TryParse(str[i], out num))
                    result.Add(num);
            }

            return result;
        }

        /// <summary>
        /// 계산식에서 연산자를 찾는 함수
        /// </summary>
        /// <param name="calcForm"></param>
        /// <returns></returns>
        public char FindOperator(string calcForm)
        {
            if (calcForm.Contains('+'))
                return '+';
            else if (calcForm.Contains("-"))
                return '-';
            else if (calcForm.Contains('*'))
                return '*';
            else if (calcForm.Contains('/'))
                return '/';
            else if (calcForm.Contains('%'))
                return '%';
            else
                return '\0';
        }

        /// <summary>
        /// 계산 완료된 총 텍스트
        /// </summary>
        /// <param name="cd"></param>
        /// <returns></returns>
        public string CalculateComplete(calcData cd)
        {
            switch (cd.operate)
            {
                case '+':
                    return CalcResult(cd, Add(cd.num1, cd.num2));
                case '-':
                    return CalcResult(cd, Sub(cd.num1, cd.num2));
                case '*':
                    return CalcResult(cd, Mult(cd.num1, cd.num2));
                case '/':
                    return cd.num2 != 0 ? CalcResult(cd, Div(cd.num1, cd.num2)) : "Error!0으로 못 나눔";
                case '%':
                    return cd.num2 != 0 ? CalcResult(cd, Mod(cd.num1, cd.num2)) : "Error!0으로 못 나눔";
            }

            return "Error!없는 연산자";

        }
        
        /// <summary>
        /// 계산 결과
        /// </summary>
        /// <param name="cd"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        string CalcResult(calcData cd, decimal result)
        {
            return $"{cd.num1} {cd.operate} {cd.num2} = {result}";
        }

    }
}
