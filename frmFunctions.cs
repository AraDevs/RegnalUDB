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
    public partial class frmFunctions : Form
    {
        private static FunctionController functionController = new FunctionController();
        private List<Funcione> functions = new List<Funcione>();

        private Funcione selectedFunction = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2 };
        private int[] columnsToHide = { 3, 4, 5 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo" };
        

        public frmFunctions()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Funcione currentFunction)
        {
            txtName.Text = currentFunction.nombre;
            chbStatus.Checked = currentFunction.baja;
        }

        private void loadTable()
        {
            Operation<Funcione> getFunctionsOperation = functionController.getRecords();
            if (getFunctionsOperation.State)
            {
                functions = getFunctionsOperation.Data;
                dgvFunctions.DataSource = functions;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvFunctions);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvFunctions);
                return;
            }
            MessageBox.Show("Error al cargar datos de funciones");
        }

        private void saveData()
        {
            Funcione tempFunc = new Funcione
            {
                nombre = txtName.Text,
                baja = chbStatus.Checked,
                idNivel = 0
            };
            Operation<Funcione> operation = functionController.addRecord(tempFunc);
            if (operation.State)
            {
                MessageBox.Show("Función registrada con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al registrar la función: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData(Funcione currentFunction)
        {
            Operation<Funcione> operation = functionController.updateRecord(currentFunction);
            if (operation.State)
            {
                MessageBox.Show("Función actualizada con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar la función: " + operation.Error,
                    "ERROR AL ACTUALIZAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Funcione> tempFunctions = new List<Funcione>();
                foreach (Funcione f in functions)
                {
                    if (f.nombre.Contains(value))
                    {
                        tempFunctions.Add(f);
                    }
                }
                dgvFunctions.DataSource = tempFunctions;
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
                 new string[] { "Ingresa un nombre para la función" })
            };
            return validators;
        }

        private void cleanForm()
        {
            txtName.Clear();
            btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
            selectedFunction = null;
            errorProvider.Clear();
        }

        private void frmFunctions_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                if (isValid)
                {
                    if (selectedFunction == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedFunction.nombre = txtName.Text;
                        selectedFunction.baja = chbStatus.Checked;
                        updateData(selectedFunction);
                    }
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    foreach (ControlErrorProvider error in errorProvider)
                    {
                        this.errorProvider.SetError(error.ControlName, error.ErrorMessage);
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

        private void dgvFunctions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedFunction = functions[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedFunction);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try { 
                filterData();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
