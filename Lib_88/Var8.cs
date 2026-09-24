using System;

namespace Lib_88
{
    public class Var8
    {
        public static int SumLessThan3(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 3)
                {
                    sum = sum + mas[i];
                }
            }
            return sum;
        }

        public static double CosSumLessThan3(int[] mas)
        {
            int sum = SumLessThan3(mas);
            return Math.Cos(sum);
        }
    }

}
