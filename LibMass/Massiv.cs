using System;
using System.IO;

namespace LibMass
{
    public class Massiv
    {
        public static void InitMass(out int[] mas, int column, int randMax)
        {
            Random rnd = new Random();
            mas = new int[column];
            for (int i = 0; i < column; i++)
            {
                mas[i] = rnd.Next(-randMax, randMax+1);
            }
        }

        public static void SaveMass(int[] mas, string fileName)
        {
            using (StreamWriter file = new StreamWriter(fileName))
            {
                file.WriteLine(mas.Length);
                for (int i = 0; i < mas.Length; i++)
                {
                    file.WriteLine(mas[i]);
                }
            }
        }

        public static void OpenMass(out int[] mas, string fileName)
        {
            using (StreamReader file = new StreamReader(fileName))
            {
                int len = Convert.ToInt32(file.ReadLine());
                mas = new int[len];
                for (int i = 0; i < len; i++)
                {
                    mas[i] = Convert.ToInt32(file.ReadLine());
                }
            }
        }

        public static void ClearMass(int[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = 0;
            }
        }
    }

}
