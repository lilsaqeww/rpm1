using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib_88;
using LibMass;

namespace RPM1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] mas;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Fill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(txtCount.Text);
                int range = Convert.ToInt32(txtRange.Text);

                if (count <= 0 || range <= 0)
                {
                    MessageBox.Show("Значения должны быть положительными");
                    return;
                }

                Massiv.InitMass(out mas, count, range);
                dataGrid.ItemsSource = VisualArraay.ToDataTable(mas).DefaultView;
                txtResult.Text = "Нажмите «Рассчитать»";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка ввода: " + ex.Message);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            if (mas != null)
            {
                Massiv.ClearMass(mas);
                dataGrid.ItemsSource = VisualArraay.ToDataTable(mas).DefaultView;
                txtResult.Text = "Массив очищен";
            }
            else
            {
                MessageBox.Show("Массив пуст");
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null || mas.Length == 0)
            {
                MessageBox.Show("Сначала заполните массив");
                return;
            }

            int sum = Var8.SumLessThan3(mas);
            double result = Var8.CosSumLessThan3(mas);

            txtResult.Text = "Сумма чисел < 3: " + sum + " Значит cos(" + sum + ") = " + result.ToString("F6");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (mas == null) { MessageBox.Show("Массив пуст"); return; }

            var save = new Microsoft.Win32.SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            save.Title = "Сохранение массива";

            if (save.ShowDialog() == true)
            {
                Massiv.SaveMass(mas, save.FileName);
                MessageBox.Show("Массив сохранен");
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".txt";
            open.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            open.Title = "Открытие массива";

            if (open.ShowDialog() == true)
            {
                Massiv.OpenMass(out mas, open.FileName);
                dataGrid.ItemsSource = VisualArraay.ToDataTable(mas).DefaultView;
                txtResult.Text = "Нажмите «Рассчитать»";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Практическая работа №1. Вариант 8.\n\n" +
                "Задание: Ввести n целых чисел. Вычислить косинус (cos) " +
                "Сумма чисел < 3.\n\n" +
                "Потапова",
                "О программе");
        }
    }
}