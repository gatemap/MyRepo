using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Reference_study
{
    internal class ReferenceStudy
    {
        int[] num1;
        int[] num2;

        public ReferenceStudy() 
        {
            num1 = new int[10];
            FillArray(ref num1);
            FillOutArray(out num2);
        }

        void FillArray(ref int[] array) 
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = i + 1;
        }

        void FillOutArray(out int[] array)
        {
            array = new int[10];

            FillArray(ref array);
        }
    }
}
