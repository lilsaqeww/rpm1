using System;
using System.Collections.Generic;
namespace Lib_8
{
    public class Calculations
    {
        /// <summary>
        /// Косинус суммы чисел, меньших 3
        /// </summary>
        /// <param name="mas">Исходный массив</param>
        /// <returns>cos(сумма элементов &lt; 3)</returns>
        public static double CosOfSumLessThan3(int[] mas)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < 3)
                    sum += mas[i];
            }
            return Math.Cos(sum);
        }
    }
}