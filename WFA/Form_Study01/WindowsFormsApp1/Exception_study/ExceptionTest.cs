using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Exception_study
{
    internal class ExceptionTest
    {
        string filePath = @"C:\Users\space\Downloads\sample.txt";

        public string file { get; private set; }
        public string[] textContent { get; private set; }
        public string textMessage {  get; private set; }

        public ExceptionTest() 
        {
            file = File.ReadAllText(@"C:\Users\space\Downloads\sample.txt");

            if (file.Contains('/'))
                throw new Exception("파일 경로 오류");
        }

        public void ConvertNum()
        {
            textContent = file.Split('\n');
            int n = 0;

            for (int i = 0; i < textContent.Length; i++)
            {
                try
                {
                    n = int.Parse(textContent[i]);
                    textMessage += $"{n}\r\n";
                }
                catch (Exception e)
                {
                    textMessage += $"{e.Message}, 숫자가 아님\r\n";
                }
            }
        }
    }
}