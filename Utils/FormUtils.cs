using RegnalUDB.Models;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.ListView;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RegnalUDB.Utils
{
    static class FormUtils
    {
        public delegate Boolean Func<in T, out Boolean>(T arg);
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

        public static void changeTitlesForSDgv(string[] titles, int[] columnsToChange, SfDataGrid dgv)
        {
            if (!(titles.Length == columnsToChange.Length))
                throw new Exception("The size of titles and columnsToChange not are equals");

            for (int i = 0; i < titles.Length; i++)
                dgv.Columns[columnsToChange[i]].HeaderText = titles[i];
        }

        public static void clearTextbox(Control[] controls)
        {
            foreach(Control c in controls)
            {
                if(c is TextBoxExt || c is IntegerTextBox)
                {
                    c.Text = "";
                }
            }
        }


        //Taken from http://www.csharp-examples.net/inputbox/
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        } 

        public static void deselect(ComboBox[] controls)
        {
            foreach (ComboBox c in controls)
                c.SelectedIndex = -1;
        }

        public static List<T> filterData<T>(List<T> data, Func<T,bool> func)
        {
            List<T> filterData = new List<T>();
            foreach(T record in data)
            {
                if (func(record))
                    filterData.Add(record);
            }
           
            return filterData;
        }


        public static DialogResult defaultErrorMessage(Exception ex)
        {
            return MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
