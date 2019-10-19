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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
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

        private void PcbCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PcbMinimizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PcbMaximizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pcbMaximizeWindow.Visible = false;
            pcbRestoreWindow.Visible = true;
        }

        private void PcbRestoreWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pcbRestoreWindow.Visible = false;
            pcbMaximizeWindow.Visible = true;
        }

        public void ShowChildForm(object frm)
        {
            if(this.pnlContent.Controls.Count > 0)
            {
                this.pnlContent.Controls.RemoveAt(0);
            }
            Form form = frm as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.pnlContent.Controls.Add(form);
            this.pnlContent.Tag = form;
            form.Show();
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            ShowChildForm(new frmMembers());
        }

        private void PcbInfo_Click(object sender, EventArgs e)
        {
            frmCredits credits = new frmCredits();
            credits.Show();
        }

        private void btnFormMembers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMembers());
        }

        private void btnFormGroups_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmGroups());
        }

        private void btnFormSections_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSections());
        }
    }
}
