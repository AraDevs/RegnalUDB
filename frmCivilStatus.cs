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
    public partial class frmCivilStatus : Form
    {
        CivilStatusController civilStatusController = new CivilStatusController();
        List<EstadoCivil> civilStatus = new List<EstadoCivil>();
        EstadoCivil selectedCivilStatus = null;

        List<EstadoCivil> filterCivilStatus = new List<EstadoCivil>();

        private int[] columnsToHideForCivilStatus = { 3 };
        private int[] columnsToChangeForCivilStatus = { 0, 1, 2 };
        private string[] titlesforCivilStatus = { "ID", "Estado civil", "Activo" };
        public frmCivilStatus()
        {
            InitializeComponent();
            
        }

        private void frmCivilStatus_Load(object sender, EventArgs e)
        {
            try
            {
                chbStatus.Checked = true;
                loadTable(getCivilStatus());
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try { 
                String value = txtSearch.Text.Trim().ToUpper();
                if (value.Trim().Length > 0)
                {
                    filterCivilStatus = FormUtils.filterData<EstadoCivil>(civilStatus, (g) =>
                      g.ToString().ToUpper().Contains(value)
                    );
                    loadTable(filterCivilStatus);
                    return;
                }
                filterCivilStatus = new List<EstadoCivil>();
                loadTable(civilStatus);
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvCivilStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    List<EstadoCivil> list = filterCivilStatus.Count == 0 ? civilStatus : filterCivilStatus;
                    selectedCivilStatus = list[index];

                    chbStatus.Checked = selectedCivilStatus.baja;
                    txtCivilStatus.Text = selectedCivilStatus.estadoCivil1;
                    btnSaveModify.Text = "Modificar";
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
                clearForm();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try { 
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorsProvider == null;
                if (isValid)
                {
                    bool isNew = selectedCivilStatus == null;
                    EstadoCivil civilStatus = new EstadoCivil()
                    {
                        idEstadoCivil = isNew ? 0 : selectedCivilStatus.idEstadoCivil,
                        estadoCivil1 = txtCivilStatus.Text,
                        baja = isNew ? true : chbStatus.Checked
                    };

                    Operation<EstadoCivil> operation = isNew ? civilStatusController.addRecord(civilStatus) :
                            civilStatusController.updateRecord(civilStatus);
                    if (operation.State)
                    {
                        loadTable(getCivilStatus());
                        MessageBox.Show("Operación exitosa");
                        clearForm();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    foreach (ControlErrorProvider errorProvider in errorsProvider)
                        this.errorProvider.SetError(errorProvider.ControlName, errorProvider.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void loadTable(List<EstadoCivil> civilStatus)
        {
            dgvCivilStatus.DataSource = null;
            dgvCivilStatus.DataSource = civilStatus;
            FormUtils.hideColumnsForDgv(columnsToHideForCivilStatus, dgvCivilStatus);
            FormUtils.changeTitlesForDgv(titlesforCivilStatus, columnsToChangeForCivilStatus, dgvCivilStatus);
            /*dgvCivilStatus.AutoResizeColumns();
            dgvCivilStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
            return;
        }

        public List<EstadoCivil> getCivilStatus()
        {
            Operation<EstadoCivil> operation = civilStatusController.getRecords();
            if (operation.State)
            {
                civilStatus = operation.Data;
                return operation.Data;
            }
            MessageBox.Show("Error al cargas datos de estado civil");
            return new List<EstadoCivil>();
        }



        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtCivilStatus, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el movitovo" }),

            };
            return validators;
        }
        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtCivilStatus, txtSearch });
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedCivilStatus = null;
            filterCivilStatus = new List<EstadoCivil>();
            loadTable(civilStatus);
        }

 
    }
}
