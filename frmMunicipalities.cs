using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmMunicipalities : Form
    {
        private static MunicipalityContraller municipalityContraller = new MunicipalityContraller();
        private List<Municipio> municipalities = new List<Municipio>();

        private static DepartmentController departmentController = new DepartmentController();
        private List<Departamento> departments = new List<Departamento>();

        private Municipio selectedMunicipality = null;

        private int[] columnsToChange = { 0, 1, 2, 3 };
        private int[] columnsToHide = { 3, 5 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo", "Departamento" };
        public frmMunicipalities()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Municipio currentMunicipality)
        {
            txtName.Text = currentMunicipality.nombre;
            cmbDepartments.SelectedItem = currentMunicipality.Departamento;
            chbStatus.Checked = currentMunicipality.baja;
        }

        private void loadTable()
        {
            Operation<Municipio> getMunicipalitiesOperation = municipalityContraller.getRecords();
            if (getMunicipalitiesOperation.State)
            {
                municipalities = getMunicipalitiesOperation.Data;
                dgvMunicipalities.DataSource = municipalities;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvMunicipalities);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvMunicipalities);
                return;
            }
            MessageBox.Show("Error al cargar los datos de Municipios", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void loadDepartments()
        {
            Operation<Departamento> getDepartmentsOperation =
                departmentController.getActiveRecords();
            if (getDepartmentsOperation.State)
            {
                departments = getDepartmentsOperation.Data;
                cmbDepartments.DataSource = departments;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de departamentos. Por favor reinicie el módulo.", 
                    "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveData()
        {
            Municipio tempMuni = new Municipio
            {
                nombre = txtName.Text,
                idDepartamento = ((Departamento)cmbDepartments.SelectedValue).idDepartamento,
                baja = chbStatus.Checked
            };
            Operation<Municipio> operation = municipalityContraller.addRecord(tempMuni);
            if (operation.State)
            {
                MessageBox.Show("Municipio agregado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        private void updateData(Municipio currentMunicipality)
        {
            Operation<Municipio> operation = municipalityContraller.updateRecord(currentMunicipality);
            if (operation.State)
            {
                MessageBox.Show("Departamento actualizado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Municipio> tempMunicipalities = new List<Municipio>();
                foreach (Municipio d in municipalities)
                {
                    if (d.nombre.Contains(value))
                    {
                        tempMunicipalities.Add(d);
                    }
                }
                dgvMunicipalities.DataSource = tempMunicipalities;
            }
            else
            {
                loadTable();
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =
            {
                new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre de Municipio" })
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedMunicipality = null;
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls =
            {
                txtName
            };
            return controls;
        }

        private void frmMunicipalities_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
                loadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorProvider == null;
            if (isValid)
            {
                if (selectedMunicipality == null)
                {
                    saveData();
                }
                else
                {
                    selectedMunicipality.nombre = txtName.Text;
                    selectedMunicipality.Departamento = (Departamento)cmbDepartments.SelectedItem;
                    selectedMunicipality.baja = chbStatus.Checked;
                    updateData(selectedMunicipality);
                }
            }
            else
            {
                this.errorProvider.Clear();
                MessageBox.Show("Algunos datos ingresados son inválidos.\n" +
                    "Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "Error al ingresar datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (ControlErrorProvider controlErrorProvider in errorProvider)
                {
                    this.errorProvider.SetError(controlErrorProvider.ControlName,
                        controlErrorProvider.ErrorMessage);
                }
            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            filterData();
        }

        private void dgvMunicipalities_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                
                selectedMunicipality = municipalities[index];
                cmbDepartments.SelectedItem = 
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedMunicipality);
            }
        }
    }
}
