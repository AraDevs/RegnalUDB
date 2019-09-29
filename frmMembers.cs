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
    public partial class frmMembers : Form
    {
        public frmMembers()
        {

            InitializeComponent();
        }

        private void FrmMembers_Load(object sender, EventArgs e)
        {
            pnlButtons.BackColor = System.Drawing.Color.Transparent;
            pnlButtons.BringToFront();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            bunifuSeparator1.Visible = false;
            bunifuSeparator1.Left = ((Control)sender).Left;
            bunifuSeparator1.Width = ((Control)sender).Width;
            bunifuTransition1.ShowSync(bunifuSeparator1);
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            bunifuSeparator1.Visible = true;
            bunifuSeparator1.Left = ((Control)sender).Left;
            bunifuSeparator1.Width = ((Control)sender).Width;
            bunifuTransition1.ShowSync(bunifuSeparator1);
        }

        private void Label4_MouseUp(object sender, MouseEventArgs e)
        {
            pnlButtons.BringToFront();
            cardPersonalInfo.BringToFront();
        }

        private void Label5_MouseUp(object sender, MouseEventArgs e)
        {
            pnlButtons.BringToFront();
            cardDirection.BringToFront();
        }
    }
}
