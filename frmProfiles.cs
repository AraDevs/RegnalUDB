using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmProfiles : Form
    {
        private static ProfileController profileController = new ProfileController();
        private List<Perfile> profiles = new List<Perfile>();

        private Perfile selectedProfile = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2 };
        private int[] columnsToHide = { 3 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo" };

        private void fillSelectedData(Perfile currentPerfile)
        {
            txtName.Text = currentPerfile.nombre;
            chbStatus.Checked = currentPerfile.baja;
        }

        private void loadTable()
        {
            Operation<Perfile> getProfileOperation = profileController.getRecords();
            if (getProfileOperation.State)
            {
                profiles = getProfileOperation.Data;
                dgvProfiles.DataSource = profiles;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvProfiles);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvProfiles);
                return;
            }
            MessageBox.Show("Error al cargas datos de religiones");
        }

        private void saveData()
        {
            Perfile tempProfile = new Perfile
            {
                nombre = txtName.Text,
                baja = chbStatus.Checked
            };
            Operation<Perfile> operation = profileController.addRecord(tempProfile);
            if (operation.State)
            {
                MessageBox.Show("Perfil agregado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Perfile currentSection)
        {
            Operation<Perfile> operation = profileController.updateRecord(currentSection);
            if (operation.State)
            {
                MessageBox.Show("Perfil actualizado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Perfile> tempProfile = new List<Perfile>();
                foreach (Perfile r in profiles)
                {
                    if (r.nombre.Contains(value))
                    {
                        tempProfile.Add(r);
                    }
                }
                dgvProfiles.DataSource = tempProfile;
            }
            else
            {
                loadTable();
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa un nombre" })
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            selectedProfile = null;
            //btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
        }

        private Control[] textControls()
        {
            Control[] controls = { txtName };
            return controls;
        }
        public frmProfiles()
        {
            InitializeComponent();
        }

        private void frmProfiles_Load(object sender, EventArgs e)
        {
            loadTable();
            chbStatus.Checked = true;
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorProvider == null;
            if (isValid)
            {
                if (selectedProfile == null)
                {
                    MessageBox.Show("Seleccione un registro para modificar");   
                   // saveData();
                }
                else
                {
                    selectedProfile.nombre = txtName.Text;
                    selectedProfile.baja = chbStatus.Checked;
                    updateData(selectedProfile);
                }
            }
            else
            {
                this.errorProvider.Clear();
                MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (ControlErrorProvider error in errorProvider)
                {
                    this.errorProvider.SetError(error.ControlName, error.ErrorMessage);
                }


            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void dgvProfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedProfile = profiles[index];
                if (selectedProfile.nombre.Equals("Administrador"))
                {
                    MessageBox.Show("El perfil de administrador no puede ser modificado");
                    return;
                }
               // btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedProfile);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }
    }
}
