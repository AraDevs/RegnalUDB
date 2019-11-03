using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using static RegnalUDB.Utils.FormValidators;
using RegnalUDB.Utils;
using RegnalUDB.Controllers;

namespace RegnalUDB
{
    public partial class frmInscriptions : UserControl
    {
        private Miembro selectedMember = null;
        public Miembro SelectedMember { get => selectedMember; set => selectedMember = value; }

        private static frmInscriptions _instance;
        public static frmInscriptions Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmInscriptions();
                }
                return _instance;
            }
        }

        private InscriptionController inscriptionController = new InscriptionController();
        private List<Inscripcione> inscriptions = new List<Inscripcione>();

        Inscripcione selectedInscription = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 1, 2, 3 };
        private int[] columnsToHide = { 0, 4, 5 };
        private string[] titlesforColumns = { "Fecha inicio", "Fecha fin", "Estado" };

        public frmInscriptions()
        {
            InitializeComponent();
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(dtpStart, new ControlValidator[] { FormValidators.isValidDate },
                 new string[] { "La fecha ingresada sobrepasa el día actual" })
            };

            return validators;
        }

        public void clean()
        {
            lblMemberI.Text = "Ninguno";
            selectedMember = null;
            dgvInscriptions.DataSource = null;
            cleanForm();
        }

        public void cleanForm()
        {
            dtpStart.Value = System.DateTime.Today;
            dtpFinish.Value = System.DateTime.Today;
            selectedInscription = null;
            chbStatus.Checked = true;
            errorProvider.Clear();
            btnSaveModify.Text = "Guardar";
        }

        public void loadTable()
        {
            if (selectedMember != null)
            {
                lblMemberI.Text = selectedMember.ToString();

                Operation<Inscripcione> getInscriptionOperation = inscriptionController.getRecordsByMember(selectedMember);
                if (getInscriptionOperation.State)
                {
                    inscriptions = getInscriptionOperation.Data;
                    dgvInscriptions.DataSource = inscriptions;

                    /*FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvInscriptions);
                    FormUtils.hideColumnsForDgv(columnsToHide, dgvInscriptions);*/

                    return;
                }
                MessageBox.Show("Error al cargar las inscripciones del miembro");
            }
        }

        public void fillSelectedData()
        {
            lblMemberI.Text = selectedMember.ToString();

            Inscripcione i = selectedMember.Inscripciones.FirstOrDefault();

            if (i != null)
            {
                dtpStart.Value = i.fechaInicio;
                dtpFinish.Value = (DateTime)i.fechaFin;
                chbStatus.Checked = i.baja;
            }
            else
            {
                cleanForm();
            }
        }

        private void saveData()
        {
            Inscripcione tempIns = new Inscripcione
            {
                idMiembro = selectedMember.idMiembro,
                fechaInicio = dtpStart.Value,
                fechaFin = dtpFinish.Value,
                baja = chbStatus.Checked
            };

            Operation<Inscripcione> operation = inscriptionController.addRecord(tempIns);
            if (operation.State)
            {
                MessageBox.Show("Inscripción realizada con éxito","OPERACIÓN EXITOSA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanForm();
                loadTable();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al realizar la inscripción: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData(Inscripcione currentInscription)
        {

            Operation<Inscripcione> operation = inscriptionController.updateRecord(currentInscription);
            if (operation.State)
            {
                MessageBox.Show("Inscripción Modificada con éxito", "OPERACIÓN EXITOSA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanForm();
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al modificar la inscripción: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            /*try
            {
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                this.errorProvider.Clear();
                DateTime fromDate = Convert.ToDateTime(dtpStart.Value);
                DateTime toDate = Convert.ToDateTime(dtpFinish.Value);
                bool isDateGreater = (fromDate <= toDate) ? true : false;

                if (selectedMember == null)
                {
                    MessageBox.Show("Por favor, seleccione un miembro", "OPERACIÓN DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!isDateGreater)
                {
                    MessageBox.Show("Por favor, ingrese una fecha de vigencia mayor a la fecha de inicio", "ERROR AL INGRESAR FECHAS",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (isValid)
                {
                    Inscripcione i = selectedMember.Inscripciones.FirstOrDefault();
                    if(i == null)
                    {
                        saveData();
                    }
                    else
                    {
                        updateData(selectedInscription);
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
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {

                this.errorProvider.Clear();

                if (selectedMember != null)
                {
                    if (dtpStart.Value > dtpFinish.Value)
                    {
                        MessageBox.Show("Ingrese una fecha de vigencia mayor a la fecha de inicio", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (Inscripcione ins in inscriptions)
                    {
                        //Checking if the selected date range doesn't overlap with another date range
                        if (dtpStart.Value <= ins.fechaFin && ins.fechaInicio <= dtpFinish.Value && selectedInscription != ins)
                        {
                            MessageBox.Show("El rango de fechas seleccionado interfiere con el de otra inscripción.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }

                    if (selectedInscription == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedInscription.baja = chbStatus.Checked;
                        selectedInscription.fechaInicio = dtpStart.Value;
                        selectedInscription.fechaFin = dtpFinish.Value;
                        updateData(selectedInscription);
                    }

                }

                else
                {
                    MessageBox.Show("Por favor, seleccione un miembro.", "MIEMBRO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvInscriptions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedInscription = inscriptions[index];

                chbStatus.Checked = selectedInscription.baja;
                dtpStart.Value = selectedInscription.fechaInicio;
                dtpFinish.Value = (DateTime)selectedInscription.fechaFin;

                btnSaveModify.Text = "Modificar";
            }
        }
    }
}
