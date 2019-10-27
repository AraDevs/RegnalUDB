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
    public partial class frmMovements : Form
    {
        private static MovementController movementController = new MovementController();
        private List<Movimiento> movements = new List<Movimiento>();

        private Movimiento selectedMovement = null;

        private int[] columnsToChange = { 0, 1, 2 };
        private int[] columnsToHide = { 3 };
        private string[] titlesforColumns = { "ID", "Descripción", "Activo" };

        public frmMovements()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Movimiento currentMovement)
        {
            txtDescription.Text = currentMovement.descripcion;
            chbStatus.Checked = currentMovement.baja;
        }

        private void loadTable()
        {
            Operation<Movimiento> getMovementOperation = movementController.getRecords();
            if(getMovementOperation.State)
            {
                movements = getMovementOperation.Data;
                dgvMovements.DataSource = movements;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvMovements);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvMovements);
                return;
            }
            MessageBox.Show("Error al cargar los datos de movimientos", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void saveData()
        {
            Movimiento tempMov = new Movimiento
            {
                descripcion = txtDescription.Text,
                baja = chbStatus.Checked
            };
            Operation<Movimiento> operation = movementController.addRecord(tempMov);
            if(operation.State)
            {
                MessageBox.Show("Tipo de Movimiento agregado con éxito", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
        }

        private void updateData(Movimiento currentMovement)
        {
            Operation<Movimiento> operation = movementController.updateRecord(currentMovement);
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
                List<Movimiento> tempDepartments = new List<Movimiento>();
                foreach (Movimiento d in movements)
                {
                    if (d.descripcion.Contains(value))
                    {
                        tempDepartments.Add(d);
                    }
                }
                dgvMovements.DataSource = tempDepartments;
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
                new ToValidate(txtDescription, new ControlValidator[] { FormValidators.hasText },
                new string[] { "Ingresa un nombre de departamento" }),
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedMovement = null;
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls =
            {
                txtDescription
            };
            return controls;
        }

        private void frmMovements_Load(object sender, EventArgs e)
        {
            try
            {
                loadTable();
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
            if(isValid)
            {
                if (selectedMovement == null)
                {
                    saveData();
                }
                else
                {
                    selectedMovement.descripcion = txtDescription.Text;
                    selectedMovement.baja = chbStatus.Checked;
                    updateData(selectedMovement);
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

        private void dgvMovements_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedMovement = movements[index];
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedMovement);
            }
        }
    }
}
