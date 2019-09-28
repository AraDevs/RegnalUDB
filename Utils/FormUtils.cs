using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RegnalUDB.Utils
{
    static class FormUtils
    {

        public static List<CmbItem> getDataSourceForCmb<T>(List<T> records,  string valueProperty, string idProperty)
        {
            List<CmbItem> items = new List<CmbItem>();
            foreach (T record in records)
            {
                int id = (int)record.GetType().GetProperty(idProperty).GetValue(record);
                string value = (string)record.GetType().GetProperty(valueProperty).GetValue(record);
                items.Add(new CmbItem(value, id));
            }
            return items;
        }

        public static void hideColumnsForDgv(int[] columnsToHide, DataGridView dgv)
        {
             foreach(int column in columnsToHide)
                dgv.Columns[column].Visible = false;
        }

        public static void changeTitlesForDgv(string[] titles, int[] columnsToChange, DataGridView dgv)
        {
            if (!(titles.Length == columnsToChange.Length))
                throw new Exception("The size of titles and columnsToChange not are equals");

            for (int i = 0; i < titles.Length; i++)
                dgv.Columns[columnsToChange[i]].HeaderText = titles[i];
        }
    }
}
