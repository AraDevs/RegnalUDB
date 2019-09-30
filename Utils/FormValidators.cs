using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuTextbox;
using RegnalUDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsControlLibrary1;

namespace RegnalUDB.Utils
{
    static class FormValidators
    {
        public delegate bool ControlValidator (Control value);

        /// <summary>
        ///  Return an error message if any control is invalid
        /// </summary>
        /// <param name="validators"></param>
        /// <returns>string</returns>
        public static ControlErrorProvider validForm(ToValidate[] validators)
        {
            string errorMessage = null;
            Control control = null;
            foreach (ToValidate validator in validators)
            {
                errorMessage = FormValidators.validControl(validator.Control, validator.ControlValidators, validator.ErrorMessages);
                control = validator.Control;
                if (!(errorMessage == null)) break;
            }
            return errorMessage == null ? null : new ControlErrorProvider(errorMessage, control);
        }

        public static string validControl(Control control, ControlValidator[] validators, string[] errorMessages )
        {
            if(validators.Length == errorMessages.Length)
            {
                for (int i = 0; i < validators.Length; i++)
                {
                    bool isValid = validators[i](control);
                    if (!isValid) return errorMessages[i];
                }
            }
            return null;
        }

        // Validators

        public static bool hasText(Control control)
        {   
            if(control is TextBox || control is BunifuMetroTextbox || control is BunifuCustomTextbox)
                return control.Text.Trim().Length > 0;
            throw new Exception("Invalid control for isEmpty Method");
        }

        public static bool isSelected(Control control)
        {
            if (control is ComboBox)
                return ((ComboBox)control).SelectedIndex >= 0;
            throw new Exception("Invalid control for isSelected Method");
        }

        public static bool isNumber(Control control)
        {
            if (FormValidators.hasText(control))
                return Validators.isNumber(control.Text);
            return false;
        }

        /// <summary>
        /// The date is valid if is less or equals than now 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static bool isValidDate(Control control)
        {
            if (control is DateTimePicker || control is BunifuDatepicker)
                return DateTime.Compare(((BunifuDatepicker)control).Value, DateTime.Now) == -1;
            throw new Exception("Invalid control for isValidDate Method");
        }

        public static bool isGreaterThan(Control higher, Control minor)
        {
            if(isNumber(higher) && isNumber(minor))
            {
                return Int32.Parse(higher.Text) > Int32.Parse(minor.Text);
            }
            else
            {
                return false;
            }
        }

    }
}
