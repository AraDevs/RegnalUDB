using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;

namespace RegnalUDB
{
    public partial class frmEventMember : UserControl
    {

        private static GroupController groupController = new GroupController();
        private List<Grupos> groups = new List<Grupos>();
        private static MemberController memberController = new MemberController();
        private List<Miembro> members = new List<Miembro>();

        private MemberEventController meController = new MemberEventController();
        private List<MiembroEvento> memberEvents = new List<MiembroEvento>();

        private Evento selectedEvent = null;
        private MiembroEvento selectedMember = null;
        public Evento SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

        private static frmEventMember _instance;
        public static frmEventMember Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmEventMember();
                }
                return _instance;
            }
        }

        // data for custom DataGridView
        private int[] columnsToChange = { 3 };
        private int[] columnsToHide = { 0, 1, 2, 4 };
        private string[] titlesforColumns = { "Pago pendiente" };

        public frmEventMember()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblEventMember1.Text = "Ninguno";
            lblEventMember2.Text = "Ninguno";
            lblMember.Text = "Ninguno";
            lblCount.Text = "0";
            selectedEvent = null;
            selectedMember = null;
            lstMember.SelectedItems.Clear();
            cmbGroup.SelectedIndex = -1;
            dgvMembers.DataSource = null;
            chbPayment.Checked = false;
        }

        public void selectGroup()
        {
            if (selectedEvent != null)
            {

                Operation<Miembro> getMembersOperation = memberController.getActiveRecordsByGroupAndEventAvailability((Grupos)cmbGroup.SelectedItem, selectedEvent);
                if (getMembersOperation.State)
                {
                    members = getMembersOperation.Data;
                    lstMember.DataSource = members;

                    foreach (MiembroEvento me in selectedEvent.MiembroEventoes)
                    {
                        lstMember.SelectedItems.Add(me.Miembro);
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar la lista de miembros del grupo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void loadTable()
        {
            if (selectedEvent != null)
            {
                Operation<MiembroEvento> getMeOperation = meController.getRecordsByEvent(selectedEvent);
                if (getMeOperation.State)
                {
                    memberEvents = getMeOperation.Data;
                    dgvMembers.DataSource = memberEvents;

                    FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvMembers);
                    FormUtils.hideColumnsForDgv(columnsToHide, dgvMembers);

                    lblCount.Text = getMeOperation.Data.Count.ToString();

                    return;
                }
                MessageBox.Show("Error al cargar los miembros registrados al evento");
            }
        }

        private void frmEventMember_Load(object sender, EventArgs e)
        {
            Operation<Grupos> getGroupsOperation = groupController.getActiveRecords();
            if (getGroupsOperation.State)
            {
                groups = getGroupsOperation.Data;
                cmbGroup.DataSource = groups;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de grupos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (selectedEvent == null)
            {
                MessageBox.Show("Por favor seleccione un evento.", "EVENTO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbGroup.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor seleccione un grupo.", "GRUPO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            List<Miembro> allMembers = selectedEvent.MiembroEventoes.Select(x => x.Miembro).ToList();
            List<Miembro> originalList = new List<Miembro>();

            //Members from groups other than the selected one must not be considered in current operation
            foreach (Miembro mem in allMembers) 
            {
                if (mem.Grupos == (Grupos)cmbGroup.SelectedItem)
                {
                    originalList.Add(mem);
                }
            }
            

            List<Miembro> newList = new List<Miembro>();

            foreach (Miembro mem in lstMember.SelectedItems)
            {
                newList.Add(mem);
            }

            List<Miembro> toAdd = newList.Except(originalList).ToList();
            List<Miembro> toDelete = originalList.Except(newList).ToList();

            foreach (Miembro mem in toAdd)
            {
                MiembroEvento tempMe = new MiembroEvento
                {
                    idEvento = selectedEvent.idEvento,
                    idMiembro = mem.idMiembro,
                    pagoPendiente = true
                };

                Operation<MiembroEvento> operation = meController.addRecord(tempMe);

                if (!operation.State)
                {
                    MessageBox.Show("Ocurrió un error inesperado al registrar a " + mem.ToString() + " al evento: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            foreach (Miembro mem in toDelete)
            {
                MiembroEvento tempMe = selectedEvent.MiembroEventoes.Where(x => x.Miembro == mem).FirstOrDefault();

                Operation<MiembroEvento> operation = meController.deleteRecord(tempMe);

                if (!operation.State)
                {
                    MessageBox.Show("Ocurrió un error inesperado al desasociar a " + mem.ToString() + " del evento: " + operation.Error,
                    "ERROR AL ELIMINAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            MessageBox.Show("Los miembros fueron registrados con éxito.",
                    "MIEMBROS REGISTRADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clean();
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectGroup();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<MiembroEvento> tempMe = new List<MiembroEvento>();
                foreach (MiembroEvento me in memberEvents)
                {
                    if (me.Miembro.ToString().ToLower().Contains(value))
                    {
                        tempMe.Add(me);
                    }
                }
                dgvMembers.DataSource = tempMe;
            }
            else
            {
                loadTable();
            }
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedMember = memberEvents[index];
                lblMember.Text = selectedMember.Miembro.ToString();
                chbPayment.Checked = selectedMember.pagoPendiente;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (selectedMember == null)
            {
                MessageBox.Show("Por favor, seleccione un registro a modificar", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedMember.pagoPendiente = chbPayment.Checked;

            Operation<MiembroEvento> operation = meController.updateRecord(selectedMember);
            if (operation.State)
            {
                MessageBox.Show("Registro actualizado con éxito", "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                clean();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMember == null)
            {
                MessageBox.Show("Por favor, seleccione un registro a eliminar", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Operation<MiembroEvento> operation = meController.deleteRecord(selectedMember);
            if (operation.State)
            {
                MessageBox.Show("Registro eliminado con éxito", "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                clean();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }
    }
}
