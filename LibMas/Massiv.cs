using System;
using System.IO;
namespace LibMas
{
    public class Massiv
    {
        /// <summary>
        /// Заполнение массива случайными значениями
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <param name="column">Количество ячеек</param>
        /// <param name="randMax">Диапазон значений -randMax..randMax</param>
        public static void InitMas(out int[] mas, int column, int randMax)
        {
            Random rnd = new Random();
            mas = new int[column];
            for (int i = 0; i < column; i++)
                mas[i] = rnd.Next(-randMax, randMax + 1);
        }

        /// <summary>
        /// Сумма элементов массива, меньших заданного порога
        /// </summary>
        /// <param name="mas">Массив</param>
        /// <param name="threshold">Пороговое значение</param>
        /// <returns>Сумма элементов меньше порога</returns>
        public static int SumLessThan(int[] mas, int threshold)
        {
            int sum = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] < threshold)
                    sum += mas[i];
            }
            return sum;
        }

        /// <summary>
        /// Очистка массива
        /// </summary>
        public static void ClearMas(ref int[] mas)
        {
            mas = Array.Empty<int>();
        }

        /// <summary>
        /// Сохранение массива в файл
        /// </summary>
        public static void SaveMas(int[] mas, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                    file.WriteLine(mas[i]);
            }
        }

        /// <summary>
        /// Чтение массива из файла
        /// </summary>
        public static void OpenMas(out int[] mas, string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                int len = Convert.ToInt32(file.ReadLine());
                mas = new int[len];
                for (int i = 0; i < len; i++)
                    mas[i] = Convert.ToInt32(file.ReadLine());
            }
        }
    }
}
