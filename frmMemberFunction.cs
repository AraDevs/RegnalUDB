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
using RegnalUDB.Controllers;
using RegnalUDB.Models;
using RegnalUDB.Utils;

namespace RegnalUDB
{
    public partial class frmMemberFunction : UserControl
    {
        private Miembro selectedMember = null;
        public Miembro SelectedMember { get => selectedMember; set => selectedMember = value; }

        private static frmMemberFunction _instance;
        public static frmMemberFunction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmMemberFunction();
                }
                return _instance;
            }
        }

        private static FunctionController functionController = new FunctionController();
        private List<Funcione> functions = new List<Funcione>();

        private static MemberFunctionController mfController = new MemberFunctionController();
        private List<MiembroFuncion> memberFunctions = new List<MiembroFuncion>();

        MiembroFuncion selectedMf = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 3, 4, 5 };
        private int[] columnsToHide = { 0, 1, 2, 6 };
        private string[] titlesforColumns = { "Fecha inicio", "Fecha fin", "Función" };

        public frmMemberFunction()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblMember.Text = "Ninguno";
            selectedMember = null;
            dgvFunctions.DataSource = null;
            cleanForm();
        }

        public void cleanForm()
        {
            cmbFunction.SelectedIndex = 0;
            dtpStart.Value = System.DateTime.Today;
            dtpFinish.Value = System.DateTime.Today;
            selectedMf = null;
            btnSaveModify.Text = "Guardar";
        }

        public void loadTable()
        {
            if (selectedMember != null)
            {
                lblMember.Text = selectedMember.ToString();

                Operation<MiembroFuncion> getMfOperation = mfController.getRecordsByMember(selectedMember);
                if (getMfOperation.State)
                {
                    memberFunctions = getMfOperation.Data;
                    dgvFunctions.DataSource = memberFunctions;

                    FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvFunctions);
                    FormUtils.hideColumnsForDgv(columnsToHide, dgvFunctions);

                    return;
                }
                MessageBox.Show("Error al cargar las funciones del miembro");
            }
        }

        public void loadCmb()
        {
            try
            {
                Operation<Funcione> getFunctionsOperation = functionController.getActiveRecords();
                if (getFunctionsOperation.State)
                {
                    functions = getFunctionsOperation.Data;
                    cmbFunction.DataSource = functions;
                }
                else
                {
                    MessageBox.Show("Error al cargar la lista de funciones. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void saveData()
        {
            MiembroFuncion tempMf = new MiembroFuncion
            {
                idMiembro = selectedMember.idMiembro,
                idFuncion = ((Funcione)(cmbFunction.SelectedItem)).idFuncion,
                fechaInicio = dtpStart.Value,
                fechaFin = dtpFinish.Value
            };
            Operation<MiembroFuncion> operation = mfController.addRecord(tempMf);
            if (operation.State)
            {
                MessageBox.Show("Función asociada con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al asociar la función: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData(MiembroFuncion currentMf)
        {
            Operation<MiembroFuncion> operation = mfController.updateRecord(currentMf);
            if (operation.State)
            {
                MessageBox.Show("Función asociada actualizada con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar la asociación con la función: " + operation.Error,
                    "ERROR AL ACTUALIZAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMemberFunction_Load(object sender, EventArgs e)
        {
            loadCmb();
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

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {

                this.errorProvider.Clear();

                if (selectedMember != null)
                {
                    if (dtpStart.Value > dtpFinish.Value)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor a la de fin", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (MiembroFuncion mf in memberFunctions) {

                        if ((Funcione)cmbFunction.SelectedItem == mf.Funcione)
                        {
                            //Checking if the selected date range doesn't overlap with another date range
                            //from the same function
                            if (dtpStart.Value < mf.fechaFin && mf.fechaInicio < dtpFinish.Value && selectedMf != mf)
                            {
                                MessageBox.Show("El rango de fechas seleccionado interfiere con el rango de fechas de otro registro que posee la misma función para este miembro.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            
                        }

                    }

                    if (selectedMf == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedMf.idFuncion = ((Funcione)cmbFunction.SelectedItem).idFuncion;
                        selectedMf.fechaInicio = dtpStart.Value;
                        selectedMf.fechaFin = dtpFinish.Value;
                        updateData(selectedMf);
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

        private void dgvFunctions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedMf = memberFunctions[index];

                    cmbFunction.SelectedItem = selectedMf.Funcione;
                    dtpStart.Value = selectedMf.fechaInicio;
                    dtpFinish.Value = (DateTime)selectedMf.fechaFin;

                    btnSaveModify.Text = "Modificar";
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
