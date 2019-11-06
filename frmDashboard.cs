using RegnalUDB.Entity_Framework;
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
        private Usuario currentUser = new Usuario();
        public frmDashboard()
        {
            //Thread thread = new Thread(new ThreadStart(StartForm));
            //thread.Start();
            //Thread.Sleep(1000);
            InitializeComponent();
            //thread.Abort();
        }
        public frmDashboard(Usuario u)
        {
            //Thread thread = new Thread(new ThreadStart(StartForm));
            //thread.Start();
            //Thread.Sleep(1000);
            InitializeComponent();
            //thread.Abort();
            currentUser = u;
            MessageBox.Show("Bienvenido " + u.Miembro.nombre);
            hideMenuItems(u.Perfile.idPerfil);
        }
        private void hideMenuItems(int userProfile)
        {
            switch (userProfile)
            {
                case 1:
                    //nada jaja asies es el administrador
                    break;
                case 2:
                    btnFormUsers.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormDepartments.Hide();
                    btnFormAdvertisements.Hide();

                    btnFormMembers.Location = new Point(12, 144);
                    btnFormEvents.Location = new Point(12, 198);
                    btnFormDistrictis.Location = new Point(12, 252);
                    btnFormGroups.Location = new Point(12, 306);

                    button1.Location = new Point(12, 734);
                    ShowChildForm(new frmMembers(currentUser));
                    break;
                case 3:
                    btnFormEvents.Hide();
                    btnFormUsers.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormDepartments.Hide();
                    btnFormAdvertisements.Hide();

                    btnFormMembers.Location = new Point(12, 144);
                    btnFormDistrictis.Location = new Point(12, 198);
                    btnFormGroups.Location = new Point(12, 252);

                    button1.Location = new Point(12, 734);
                    ShowChildForm(new frmMembers(currentUser));
                    break;
                case 4:
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormDepartments.Hide();

                    btnFormMembers.Location = new Point(12, 144);
                    btnFormEvents.Location = new Point(12, 198);
                    btnFormUsers.Location = new Point(12, 252);
                    btnFormDistrictis.Location = new Point(12, 306);
                    btnFormGroups.Location = new Point(12, 360);
                    btnFormAdvertisements.Location = new Point(12, 414);

                    button1.Location = new Point(12, 734);

                    ShowChildForm(new frmMembers(currentUser));
                    break;
                case 5:
                    btnFormMembers.Hide();
                    btnFormEvents.Hide();
                    btnFormUsers.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormDepartments.Hide();
                    btnFormAdvertisements.Hide();

                    btnFormDistrictis.Location = new Point(12, 144);
                    btnFormGroups.Location = new Point(12, 198);

                    button1.Location = new Point(12, 734);

                    ShowChildForm(new frmDistricts(currentUser));
                    break;
                case 6:
                    btnFormUsers.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormDepartments.Hide();
                    btnFormAdvertisements.Hide();

                    btnFormMembers.Location = new Point(12, 144);
                    btnFormEvents.Location = new Point(12, 198);
                    btnFormDistrictis.Location = new Point(12, 252);
                    btnFormGroups.Location = new Point(12, 306);

                    button1.Location = new Point(12, 734);

                    ShowChildForm(new frmMembers(currentUser));
                    break;
                case 7:
                    btnFormUsers.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormMunicipalities.Hide();
                    btnFormLocations.Hide();
                    btnFormSections.Hide();
                    btnFormProvinces.Hide();
                    btnFormReligions.Hide();
                    btnFormCivilStatus.Hide();
                    btnFormBlackList.Hide();
                    btnFormBitacora.Hide();
                    btnFormPositions.Hide();
                    btnFormTypeMovements.Hide();
                    btnFormTypeUsers.Hide();
                    btnFormFunctions.Hide();
                    btnFormSchoolarship.Hide();
                    btnFormDepartments.Hide();
                    btnFormAdvertisements.Hide();

                    btnFormMembers.Location = new Point(12, 144);
                    btnFormEvents.Location = new Point(12, 198);
                    btnFormDistrictis.Location = new Point(12, 252);
                    btnFormGroups.Location = new Point(12, 306);

                    button1.Location = new Point(12, 734);

                    ShowChildForm(new frmMembers(currentUser));
                    break;
            }
        }
        //public void StartForm()
        //{
        //    Application.Run(new frmScreenSplash());
        //}

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
            

            //this.Size = new Size(1400,800);
        }

        private void PcbInfo_Click(object sender, EventArgs e)
        {
            frmCredits credits = new frmCredits();
            credits.Show();
        }

        private void btnFormMembers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMembers(currentUser));
        }

        private void btnFormGroups_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmGroups(currentUser));
        }

        private void btnFormSections_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmSections());
        }

        private void btnFormEvents_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmEvents(currentUser));
        }

        private void btnFormPositions_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmPosition());
        }

        private void btnFormDistrictis_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmDistricts(currentUser));
        }

        private void btnFormSchoolarship_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmScholarship());
        }

        private void btnFormDepartments_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmDepartments());
        }

        private void btnFormMunicipalities_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMunicipalities());
        }

        private void btnFormLocations_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmLocations());
        }

        private void btnFormProvinces_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmProvinces());
        }

        private void btnFormReligions_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmReligions());
        }

        private void btnFormTypeMovements_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmMovements());
        }

        private void btnFormUsers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmUsers());
        }

        private void btnFormCivilStatus_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmCivilStatus());
        }

        private void btnFormBlackList_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmBlackList());
        }

        private void btnFormTypeUsers_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmProfiles());
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void btnFormFunctions_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmFunctions());
        }

        private void btnFormAdvertisements_Click(object sender, EventArgs e)
        {
            ShowChildForm(new frmAnnouncements());
        }
    }
}
