using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Lib_88
{
    public static class VisualArraay
    {
        public static DataTable ToDataTable(int[] mas)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Индекс", typeof(int));
            dt.Columns.Add("Значение", typeof(int));

            for (int i = 0; i < mas.Length; i++)
            {
                dt.Rows.Add(i, mas[i]);
            }
            return dt;
        }
    }
}
