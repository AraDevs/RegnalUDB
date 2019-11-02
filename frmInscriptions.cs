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

        public void cleanForm()
        {
            dtpStart.Value = DateTime.Today;
            dtpFinish.Value = DateTime.Today;
            chbStatus.Checked = true;
            //lblMemberI.Text = "Por asignar";
            //selectedMember = null;
            errorProvider.Clear();
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

                selectedMember = null;
                lblMemberI.Text = "Ninguno";
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData()
        {
            Inscripcione tempIns = selectedMember.Inscripciones.First();

            tempIns.fechaInicio = dtpStart.Value;
            tempIns.fechaFin = dtpFinish.Value;
            tempIns.baja = chbStatus.Checked;

            Operation<Inscripcione> operation = inscriptionController.updateRecord(tempIns);
            if (operation.State)
            {
                MessageBox.Show("Inscripción Modificada con éxito", "OPERACIÓN EXITOSA",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanForm();

                selectedMember = null;
                lblMemberI.Text = "Ninguno";
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
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
                        updateData();
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
            }
        }
    }
}
