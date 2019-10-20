using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegnalUDB
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Licensing
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31372e332e30BnnYpiCp7U/SsuBIAqqOCtJ3U05RMv3Y8/xliy1PM84=");
            SkinManager.ApplicationVisualTheme = "VioletTheme";

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLocations());
        }
    }
}
