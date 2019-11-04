using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegnalUDB
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            Thread thread = new Thread(new ThreadStart(StartForm));
            thread.Start();
            Thread.Sleep(1000);
            InitializeComponent();
            thread.Abort();
        }

        public void StartForm()
        {
            Application.Run(new frmScreenSplash());
        }

        private void pcbCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            new frmDashboard().Show();
            this.Hide();
        }
    }
}
