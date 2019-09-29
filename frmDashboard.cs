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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
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

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMembers());
        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            ShowChildForm(new frmMembers());
        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmGroups());
        }

        private void BunifuFlatButton3_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSections());
        }
    }
}
