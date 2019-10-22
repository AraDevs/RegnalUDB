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
    public partial class frmPosition : Form
    {
        private static PositionController positionController = new PositionController();
        private List<Cargo> positions = new List<Cargo>();

        private Cargo selectedPosition = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2, 3, 4 };
        private int[] columnsToHide = {5, 6, 7, 8 };
        private string[] titlesforColumns = { "ID", "Nombre", "Siglas", "Max. Integrantes", "Activo" };
        
        public frmPosition()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Cargo currentPosition)
        {
            txtName.Text = currentPosition.nombre;
            txtKey.Text = currentPosition.siglas;
            txtTotal.Text = currentPosition.total.ToString();
            chbStatus.Checked = currentPosition.baja == 1;
        }

        private void loadTable()
        {
            Operation<Cargo> getPositionsOperation = positionController.getRecords();
            if (getPositionsOperation.State)
            {
                positions = getPositionsOperation.Data;
                dgvPositions.DataSource = positions;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvPositions);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvPositions);
                return;
            }
            MessageBox.Show("Error al cargar datos de cargos");
        }

        private void saveData()
        {
            Cargo tempPos = new Cargo
            {
                nombre = txtName.Text,
                siglas = txtKey.Text,
                baja = (short) (chbStatus.Checked ? 1 : 0),
                total = short.Parse(txtTotal.Text)
            };
            Operation<Cargo> operation = positionController.addRecord(tempPos);
            if (operation.State)
            {
                MessageBox.Show("Cargo registrado con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al registrar el cargo: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData(Cargo currentPosition)
        {
            Operation<Cargo> operation = positionController.updateRecord(currentPosition);
            if (operation.State)
            {
                MessageBox.Show("Cargo actualizado con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar el cargo: " + operation.Error,
                    "ERROR AL ACTUALIZAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Cargo> tempPositions = new List<Cargo>();
                foreach (Cargo p in positions)
                {
                    if (p.nombre.Contains(value) ||
                        p.siglas.Contains(value) ||
                        p.total.ToString().Contains(value))
                    {
                        tempPositions.Add(p);
                    }
                }
                dgvPositions.DataSource = tempPositions;
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
                 new string[] { "Ingresa un nombre" }),
                 new ToValidate(txtKey, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa las siglas" }),
                 new ToValidate(txtTotal, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El valor total de integrantes permitidos debe ser un número positivo" })
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
            selectedPosition = null;
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls = { txtName, txtKey, txtTotal };
            return controls;
        }

        private void frmPosition_Load(object sender, EventArgs e)
        {
            loadTable();
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
                    if (selectedPosition == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedPosition.nombre = txtName.Text;
                        selectedPosition.siglas = txtKey.Text;
                        selectedPosition.total = short.Parse(txtTotal.Text);
                        selectedPosition.baja = (short)(chbStatus.Checked ? 1 : 0);
                        updateData(selectedPosition);
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
            cleanForm();
        }

        private void dgvPositions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedPosition = positions[index];
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedPosition);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }
    }
}
