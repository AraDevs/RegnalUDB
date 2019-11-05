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
    public partial class frmEvents : Form
    {
        private static EventController eventController = new EventController();
        private List<Evento> events = new List<Evento>();

        private static PositionController positionController = new PositionController();
        private List<Cargo> positions = new List<Cargo>();

        private static SectionController sectionController = new SectionController();
        private List<Seccione> sections = new List<Seccione>();

        private static FunctionController functionController = new FunctionController();
        private List<Funcione> functions = new List<Funcione>();
        Usuario currentUser = new Usuario();
        private Evento selectedEvent = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int[] columnsToHide = { 11, 12, 13, 14 };
        private string[] titlesforColumns = { "ID", "Fecha de inicio", "Fecha de fin", "Num. Responsables", "Num. Integrantes", "Min Integrantes", "Activo", "Nombre", "Es Dolar", "Importe", "Descripción"};
        

        public frmEvents()
        {
            InitializeComponent();
        }
        public frmEvents(Usuario u)
        {
            InitializeComponent();
            currentUser = u;
        }

        private void fillSelectedData(Evento currentEvent)
        {
            txtName.Text = currentEvent.nombre;
            txtPrice.Text = currentEvent.importe.ToString();
            chbDollar.Checked = currentEvent.esDolar;
            txtDescription.Text = currentEvent.descripcion;
            dtpStart.Value = currentEvent.fechaInicio;
            dtpEnd.Value = (DateTime)currentEvent.fechaFin;
            txtNumber.Text = currentEvent.numIntagrantes.ToString();
            txtMin.Text = currentEvent.minIntegrantes.ToString();
            txtResp.Text = currentEvent.numResponsables.ToString();
            chbStatus.Checked = currentEvent.baja;

            frmEventPosition.Instance.lblEventPosition.Text = currentEvent.nombre;

            frmEventPosition.Instance.lstPosition.SelectedItems.Clear();

            foreach (EventoCargo ec in currentEvent.EventoCargoes)
            {
                frmEventPosition.Instance.lstPosition.SelectedItems.Add(ec.Cargo);
            }



            frmEventSection.Instance.lblEventSection.Text = currentEvent.nombre;

            frmEventSection.Instance.lstSection.SelectedItems.Clear();

            foreach (EventoSeccion es in currentEvent.EventoSeccions)
            {
                frmEventSection.Instance.lstSection.SelectedItems.Add(es.Seccione);
            }



            frmEventFunction.Instance.lblEventPosition.Text = currentEvent.nombre;

            frmEventFunction.Instance.lstFunction.SelectedItems.Clear();

            foreach (EventosFuncione ef in currentEvent.EventosFunciones)
            {
                frmEventFunction.Instance.lstFunction.SelectedItems.Add(ef.Funcione);
            }



            frmEventMember.Instance.lblEventMember1.Text = currentEvent.nombre;
            frmEventMember.Instance.lblEventMember2.Text = currentEvent.nombre;

            frmEventMember.Instance.lstMember.SelectedItems.Clear();

            foreach (MiembroEvento me in currentEvent.MiembroEventoes)
            {
                if (me.Miembro.Grupos == (Grupos)frmEventMember.Instance.cmbGroup.SelectedItem)
                {
                    frmEventMember.Instance.lstMember.SelectedItems.Add(me.Miembro);
                }
            }
        }

        private void loadTable()
        {
            Operation<Evento> getEventsOperation = eventController.getRecords();
            if (getEventsOperation.State)
            {
                events = getEventsOperation.Data;
                dgvEvents.DataSource = events;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvEvents);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvEvents);
                return;
            }
            MessageBox.Show("Error al carga datos de eventos");
        }

        private void selectLabel(Label label)
        {
            lblDatosEventos.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);
            lblPosition.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);
            lblSection.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);
            lblFunction.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);
            lblMember.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);

            label.ForeColor = System.Drawing.Color.FromArgb(127, 41, 181);
        }

        private void showMissingInfo()
        {
            if (selectedEvent != null)
            {
                missingDataProvider.Clear();

                if (selectedEvent.EventoCargoes.Count == 0)
                {
                    missingDataProvider.SetError(lblPosition, "El evento seleccionado aún no tiene cargos asociados.");
                }
                if (selectedEvent.EventoSeccions.Count == 0)
                {
                    missingDataProvider.SetError(lblSection, "El evento seleccionado aún no tiene secciones asociadas.");
                }
                if (selectedEvent.EventosFunciones.Count == 0)
                {
                    missingDataProvider.SetError(lblFunction, "El evento seleccionado aún no tiene funciones asociadas.");
                }
                if (selectedEvent.MiembroEventoes.Count == 0)
                {
                    missingDataProvider.SetError(lblMember, "El evento seleccionado aún no tiene miembros registrados.");
                }
            }
        }

        private void saveData()
        {
            Evento temEvent = new Evento
            {
                nombre = txtName.Text,
                importe = Convert.ToDecimal(txtPrice.Text.Trim()),
                esDolar = chbDollar.Checked,
                descripcion = txtDescription.Text,
                fechaInicio = dtpStart.Value,
                fechaFin = dtpEnd.Value,
                numIntagrantes = Convert.ToInt16(txtNumber.Text.Trim()),
                minIntegrantes = Convert.ToInt16(txtMin.Text.Trim()),
                numResponsables = Convert.ToInt16(txtResp.Text.Trim()),
                baja = chbStatus.Checked
            };
            Operation<Evento> operation = eventController.addRecord(temEvent);
            if (operation.State)
            {
                MessageBox.Show("Evento registrado con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al registrar el evento: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData(Evento currentEvent)
        {
            Operation<Evento> operation = eventController.updateRecord(currentEvent);
            if (operation.State)
            {
                MessageBox.Show("Evento actualizado con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar el evento: " + operation.Error,
                    "ERROR AL ACTUALIZAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Evento> tempEvents = new List<Evento>();
                foreach (Evento e in events)
                {
                    if (e.nombre.Contains(value) ||
                        e.descripcion.Contains(value) ||
                        e.importe.ToString().Contains(value) ||
                        e.fechaFin.ToString().Contains(value) ||
                        e.fechaInicio.ToString().Contains(value) ||
                        e.numIntagrantes.ToString().Contains(value) ||
                        e.minIntegrantes.ToString().Contains(value) ||
                        e.numResponsables.ToString().Contains(value))
                    {
                        tempEvents.Add(e);
                    }
                }
                dgvEvents.DataSource = tempEvents;
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
                 new string[] { "Ingresa el  nombre del evento" }),
                 new ToValidate(txtPrice, new ControlValidator[] { FormValidators.isCurrency },
                 new string[] { "El importe debe ser un valor monetario" }),
                 new ToValidate(txtDescription, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese la descripción del evento" }),
                 new ToValidate(txtNumber, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El número de integrantes debe ser un valor numérico" }),
                 new ToValidate(txtMin, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El mínimo de integrantes debe ser un valor numérico" }),
                 new ToValidate(txtResp, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El número de responsables debe ser un valor numérico" })
            };
            return validators;
        }

        private void cleanForm()
        {

            errorProvider.Clear();
            missingDataProvider.Clear();

            FormUtils.clearTextbox(textControls());
            btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
            chbDollar.Checked = true;
            dtpEnd.Value = DateTime.Today;
            dtpStart.Value = DateTime.Today;
            selectedEvent = null;

            frmEventPosition.Instance.clean();
            frmEventSection.Instance.clean();
            frmEventFunction.Instance.clean();
            frmEventMember.Instance.clean();
        }

        private void loadPositions()
        {
            Operation<Cargo> getPositionOperation = positionController.getActiveRecords();
            if (getPositionOperation.State)
            {
                positions = getPositionOperation.Data;
                frmEventPosition.Instance.lstPosition.DataSource = positions;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de cargos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSections()
        {
            Operation<Seccione> getSectionsOperation = sectionController.getActiveRecords();
            if (getSectionsOperation.State)
            {
                sections = getSectionsOperation.Data;
                frmEventSection.Instance.lstSection.DataSource = sections;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de secciones. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadFunctions()
        {
            Operation<Funcione> getFunctionsOperation = functionController.getActiveRecords();
            if (getFunctionsOperation.State)
            {
                functions = getFunctionsOperation.Data;
                frmEventFunction.Instance.lstFunction.DataSource = functions;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de funciones. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Control[] textControls()
        {
            Control[] controls = { txtName, txtPrice, txtDescription, txtNumber, txtMin, txtResp };
            return controls;
        }
        private void setReadOnly()
        {
            switch (currentUser.Perfile.idPerfil)
            {
                case 4:
                    pnlEventData.Enabled = false;
                    lblPosition.Visible = false;
                    lblSection.Visible = false;
                    lblFunction.Visible = false;
                    lblMember.Visible = false;
                    break;
                case 6:
                    pnlEventData.Enabled = false;
                    lblPosition.Visible = false;
                    lblSection.Visible = false;
                    lblFunction.Visible = false;
                    lblMember.Visible = false;
                    break;
                case 7:
                    pnlEventData.Enabled = false;
                    lblPosition.Visible = false;
                    lblSection.Visible = false;
                    lblFunction.Visible = false;
                    lblMember.Visible = false;
                    break;
            }
        }
        private void frmEvents_Load(object sender, EventArgs e)
        {
            try
            {
                setReadOnly();
                loadTable();
                loadPositions();
                loadSections();
                loadFunctions();
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

                bool dateRangeValid = dtpEnd.Value >= dtpStart.Value;
                bool minValid = FormValidators.isGreaterOrEqualThan(txtNumber, txtMin);
                bool resValid = FormValidators.isGreaterOrEqualThan(txtNumber, txtResp);

                if (isValid && dateRangeValid && minValid && resValid)
                {
                    if (selectedEvent == null)
                    {
                        saveData();
                    }
                    else
                    {
                        selectedEvent.nombre = txtName.Text;
                        selectedEvent.importe = Convert.ToDecimal(txtPrice.Text.Trim());
                        selectedEvent.esDolar = chbDollar.Checked;
                        selectedEvent.descripcion = txtDescription.Text;
                        selectedEvent.fechaFin = dtpEnd.Value;
                        selectedEvent.fechaInicio = dtpStart.Value;
                        selectedEvent.numIntagrantes = Convert.ToInt16(txtNumber.Text.Trim());
                        selectedEvent.minIntegrantes = Convert.ToInt16(txtMin.Text.Trim());
                        selectedEvent.numResponsables = Convert.ToInt16(txtResp.Text.Trim());
                        selectedEvent.baja = chbStatus.Checked;
                        updateData(selectedEvent);
                    }
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    if (errorProvider != null)
                    {
                        foreach (ControlErrorProvider error in errorProvider)
                        {
                            this.errorProvider.SetError(error.ControlName, error.ErrorMessage);
                        }
                    }
                    if (!dateRangeValid)
                    {
                        this.errorProvider.SetError(dtpEnd, "La fecha de finalización debe ser igual o mayor a la de inicio");
                    }
                    if (!minValid)
                    {
                        this.errorProvider.SetError(txtMin, "El mínimo de integrantes debe ser menor o igual número de integrantes");
                    }
                    if (!resValid)
                    {
                        this.errorProvider.SetError(txtResp, "El número de responsables debe ser menor o igual número de integrantes");
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

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedEvent = events[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedEvent);

                    frmEventPosition.Instance.SelectedEvent = selectedEvent;
                    frmEventSection.Instance.SelectedEvent = selectedEvent;
                    frmEventFunction.Instance.SelectedEvent = selectedEvent;
                    frmEventMember.Instance.SelectedEvent = selectedEvent;
                    frmEventMember.Instance.selectGroup();
                    frmEventMember.Instance.loadTable();

                    showMissingInfo();
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }

        private void lblDatosPersonales_Click(object sender, EventArgs e)
        {
            selectLabel(lblDatosEventos);
            showMissingInfo();
            pnlEventData.BringToFront();
            label1.Focus();
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {
            selectLabel(lblPosition);
            showMissingInfo();
            if (!pnlParent.Controls.Contains(frmEventPosition.Instance))
            {
                pnlParent.Controls.Add(frmEventPosition.Instance);
                frmEventPosition.Instance.Dock = DockStyle.Fill;
                frmEventPosition.Instance.BringToFront();
            }
            else
            {
                frmEventPosition.Instance.BringToFront();
            }
        }

        private void lblSection_Click(object sender, EventArgs e)
        {
            selectLabel(lblSection);
            showMissingInfo();
            if (!pnlParent.Controls.Contains(frmEventSection.Instance))
            {
                pnlParent.Controls.Add(frmEventSection.Instance);
                frmEventSection.Instance.Dock = DockStyle.Fill;
                frmEventSection.Instance.BringToFront();
            }
            else
            {
                frmEventSection.Instance.BringToFront();
            }
        }

        private void lblFunction_Click(object sender, EventArgs e)
        {
            selectLabel(lblFunction);
            showMissingInfo();
            if (!pnlParent.Controls.Contains(frmEventFunction.Instance))
            {
                pnlParent.Controls.Add(frmEventFunction.Instance);
                frmEventFunction.Instance.Dock = DockStyle.Fill;
                frmEventFunction.Instance.BringToFront();
            }
            else
            {
                frmEventFunction.Instance.BringToFront();
            }
        }

        private void lblMember_Click(object sender, EventArgs e)
        {
            selectLabel(lblMember);
            showMissingInfo();
            if (!pnlParent.Controls.Contains(frmEventMember.Instance))
            {
                pnlParent.Controls.Add(frmEventMember.Instance);
                frmEventMember.Instance.Dock = DockStyle.Fill;
                frmEventMember.Instance.BringToFront();
            }
            else
            {
                frmEventMember.Instance.BringToFront();
            }

            frmEventMember.Instance.cmbGroup.SelectedIndex = -1;
        }
    }
}
