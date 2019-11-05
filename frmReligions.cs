using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmReligions : Form
    {
        private static ReligionController religionController = new ReligionController();
        private List<Religion> religions = new List<Religion>();

        private Religion selectedReligion = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2 };
        private int[] columnsToHide = { 3 };
        private string[] titlesforColumns = { "ID", "Nombre", "Activo"};
        public frmReligions()
        {
            InitializeComponent();
        }

        private void fillSelectedData(Religion currentReligion)
        {
            txtName.Text = currentReligion.nombre;
            chbStatus.Checked = currentReligion.baja;
        }

        private void loadTable()
        {
            Operation<Religion> getReligionsOperation = religionController.getRecords();
            if (getReligionsOperation.State)
            {
                religions = getReligionsOperation.Data;
                dgvReligions.DataSource = religions;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvReligions);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvReligions);
                return;
            }
            MessageBox.Show("Error al cargas datos de religiones");
        }

        private void saveData()
        {
            Religion tempReligion = new Religion
            {
                nombre = txtName.Text,
                baja = chbStatus.Checked
            };
            Operation<Religion> operation = religionController.addRecord(tempReligion);
            if (operation.State)
            {
                MessageBox.Show("Religion agregada con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Religion currentSection)
        {
            Operation<Religion> operation = religionController.updateRecord(currentSection);
            if (operation.State)
            {
                MessageBox.Show("Religion actualizada con exito");
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
                List<Religion> tempReligiones = new List<Religion>();
                foreach (Religion r in religions)
                {
                    if (r.nombre.Contains(value))
                    {
                        tempReligiones.Add(r);
                    }
                }
                dgvReligions.DataSource = tempReligiones;
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
            selectedReligion = null;
            btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
        }

        private Control[] textControls()
        {
            Control[] controls = { txtName };
            return controls;
        }

        private void frmReligions_Load(object sender, EventArgs e)
        {
            try { 
                loadTable();
                chbStatus.Checked = true;
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try { 
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                if (isValid)
                {
                    if (selectedReligion == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedReligion.nombre = txtName.Text;
                        selectedReligion.baja = chbStatus.Checked;
                        updateData(selectedReligion);
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

        private void dgvReligions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedReligion = religions[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedReligion);
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
