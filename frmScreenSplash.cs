using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegnalUDB
{
    public partial class frmScreenSplash : Form
    {
        int move = 2;
        public frmScreenSplash()
        {
            InitializeComponent();
        }

        private void FrmScreenSplash_Load(object sender, EventArgs e)
        {
            label3.Text = "-Leonor López, José Moisés\n" +
                "-Mena Reyes, José Samuel\n" +
                "-Méndez Argueta, Oscar Ernesto\n";
            label9.Text = "-Mendoza Ruano, Tatiana Vanessa\n" +
                "-Morán García, Kevin Roberto\n" +
                "-Vásquez Cruz, Deysi Noemi ";
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                panel3.Left += 2;
                if (panel3.Left > 420)
                {
                    panel3.Left = 0;
                }
                if (panel3.Left < 0)
                {
                    move = 2;
                }
            }
            catch
            {
                MessageBox.Show("Ocurrió un error inesperado. Por favor, reinicie la aplicación.");
            }
        }
    }
}
