using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegnalUDB.Utils
{
    static class FormUtils
    {

        public static void loadCmbData<T>(List<T> records, ComboBox cmb, string valueProperty, string idProperty)
        {
            foreach (T record in records)
            {
                int id = (int)record.GetType().GetProperty(idProperty).GetValue(record);
                string value = (string)record.GetType().GetProperty(valueProperty).GetValue(record);
                cmb.Items.Add(new CmbItem(value, id));
            }
        }
    }
}
