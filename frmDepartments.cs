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
    public partial class frmDepartments : Form
    {
        private static DepartmentController departmentController = new DepartmentController();
        private List<Departamento> departments = new List<Departamento>();

        private Departamento selectedDepartment = null;

        private int[] columnsToChange = { 0, 1, 2, 3 };
        private int[] columnsToHide = { 4};
        private string[] titlesforColumns = { "ID", "Nombre", "Clave", "Activo" };
        public frmDepartments()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Departamento currentDepartment)
        {
            txtName.Text = currentDepartment.nombre;
            txtKey.Text = currentDepartment.clave;
            chbStatus.Checked = currentDepartment.baja;
        }

        private void loadTable()
        {
            Operation<Departamento> getDepartmentOperation = departmentController.getRecords();
            if (getDepartmentOperation.State)
            {
                departments = getDepartmentOperation.Data;
                dgvDepartments.DataSource = departments;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvDepartments);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvDepartments);
                return;
            }
            MessageBox.Show("Error al cargar los datos de departamentos", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveData()
        {
            Departamento tempDep = new Departamento
            {
                nombre = txtName.Text,
                clave = txtKey.Text,
                baja = chbStatus.Checked
            };
            Operation<Departamento> operation = departmentController.addRecord(tempDep);
            if (operation.State)
            {
                MessageBox.Show("Departamento agregado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        private void updateData(Departamento currentDepartment)
        {
            Operation<Departamento> operation = departmentController.updateRecord(currentDepartment);
            if(operation.State)
            {
                MessageBox.Show("Departamento actualizado con éxito","Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error,"Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Departamento> tempDepartments = new List<Departamento>();
                foreach (Departamento d in departments)
                {
                    if (d.nombre.Contains(value) ||
                        d.clave.Contains(value))
                    {
                        tempDepartments.Add(d);
                    }
                }
                dgvDepartments.DataSource = tempDepartments;
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
                new string[] { "Ingresa un nombre de departamento" }),
                new ToValidate(txtKey, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa una clave para el nombre" })
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedDepartment = null;
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls =
            {
                txtName, txtKey
            };
            return controls;
        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                if (isValid)
                {
                    if (selectedDepartment == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedDepartment.nombre = txtName.Text;
                        selectedDepartment.clave = txtKey.Text;
                        selectedDepartment.baja = chbStatus.Checked;
                        updateData(selectedDepartment);
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
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            try { 
                cleanForm();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvDepartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            try { 
                filterData();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedDepartment = departments[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedDepartment);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
