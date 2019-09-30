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
    public partial class frmCredits : Form
    {
        public frmCredits()
        {
            InitializeComponent();
        }

        private void FrmCredits_Load(object sender, EventArgs e)
        {
            label4.Text = "-Leonor López, José Moisés\n" +
                "-Mena Reyes, José Samuel\n" +
                "-Méndez Argueta, Oscar Ernesto\n";
            label9.Text = "-Mendoza Ruano, Tatiana Vanessa\n" +
                "-Morán García, Kevin Roberto\n" +
                "-Vásquez Cruz, Deysi Noemi ";
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
