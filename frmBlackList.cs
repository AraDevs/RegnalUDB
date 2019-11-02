using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using Syncfusion.WinForms.ListView;
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
    public partial class frmBlackList : Form
    {
        private  MemberController memberController = new MemberController();
        private List<Miembro> members = new List<Miembro>();

        private BlackListController blackListController = new BlackListController();
        private ListaNegra selectedBan = null;
        private List<ListaNegra> bans = new List<ListaNegra>();
        private List<ListaNegra> filterBans = new List<ListaNegra>();

        private int[] columnsToHideForBlackList = { 2,4 };
        private int[] columnsToChangeForBlackList = { 0, 1, 3, 5, 6 };
        private string[] titlesforBlackList = { "ID", "Motivo","Activo", "Miembro", "Responsable"};

        public frmBlackList()
        {
            InitializeComponent();
            chbStatus.Checked = true;

            loadTable(getBans());

            getUnbannedMembers();
            loadDataCmb(members);

            // setup filters
            cmbMembers.DropDownListView.View.Filter = filterMembers;
            cmbMembers.DropDownListView.View.RefreshFilter();
            cmbMembers.TextBox.KeyUp += txtCmbMembers_KeyUp;

            cmbResponsable.DropDownListView.View.Filter = filterResponsables;
            cmbResponsable.DropDownListView.View.RefreshFilter();
            cmbResponsable.TextBox.KeyUp += txtCmbResponsable_KeyUp;

        }

        private void frmBlackList_Load(object sender, EventArgs e)
        {

        }

     

        private void btnNewClean_Click(object sender, EventArgs e)
        {
           
            clearForm();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorsProvider == null;
            if (isValid)
            {
                int member = int.Parse(cmbMembers.SelectedValue.ToString());
                int responsable = int.Parse(cmbResponsable.SelectedValue.ToString());
                bool saveValue = true;
                bool isNew = selectedBan == null;

                if (!isNew)
                {
                    Operation<ListaNegra> existingRecordOperation = blackListController.getBansByResponsableAndMember(responsable, member);
                    saveValue = existingRecordOperation.Data.Count == 0
                        || selectedBan.idMiembro == member && selectedBan.responsable == responsable;

                    if (!saveValue)
                    {
                        MessageBox.Show("Ya existe un registro activo con los datos que estan ingresando.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (member == responsable)
                {
                    MessageBox.Show("El responsable debe ser diferente del miembro.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListaNegra ban = new ListaNegra()
                {
                    idListaNegra = isNew ? 0 : selectedBan.idListaNegra,
                    responsable = responsable,
                    idMiembro = member ,
                    motivo = txtDescription.Text,
                    baja = isNew ? true : chbStatus.Checked
                };

                Operation<ListaNegra> operation = isNew ? blackListController.addRecord(ban) :
                        blackListController.updateRecord(ban);
                if (operation.State)
                {
                    loadTable(getBans());
                    getUnbannedMembers();
                    loadDataCmb(members);
                    clearForm();
                    return;
                }

            }else
            {
                MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (ControlErrorProvider errorProvider in errorsProvider)
                    this.errorProvider.SetError(errorProvider.ControlName, errorProvider.ErrorMessage);
            }

        }

        private void dgvBlackList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                List<ListaNegra> list = filterBans.Count == 0 ? bans : filterBans;
                selectedBan = list[index];

                setTemporarilyAllMembers();

                cmbMembers.SelectedValue = selectedBan.Miembro.idMiembro;
                cmbResponsable.SelectedValue = selectedBan.Miembro1.idMiembro;
                chbStatus.Checked = selectedBan.baja;
                txtDescription.Text = selectedBan.motivo;
                btnSaveModify.Text = "Modificar";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String value = txtSearch.Text.Trim().ToUpper();
            if (value.Trim().Length > 0)
            {
                filterBans = FormUtils.filterData<ListaNegra>(bans, (g) =>
                   g.Miembro.cum.ToUpper().Contains(value) || g.Miembro1.cum.ToString().Contains(value) ||
                   g.Miembro.ToString().ToUpper().Contains(value) || g.Miembro1.ToString().ToUpper().Contains(value) 
                );
                loadTable(filterBans);
                return;
            }
            filterBans = new List<ListaNegra>();
            loadTable(bans);
        }

        private void txtCmbMembers_KeyUp(object sender, KeyEventArgs e)
        {
            cmbMembers.DropDownListView.View.Refresh();
        }

        private void txtCmbResponsable_KeyUp(object sender, KeyEventArgs e)
        {
            cmbResponsable.DropDownListView.View.Refresh();
        }

        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtDescription, txtSearch });
            cmbMembers.SelectedIndex = -1;
            cmbResponsable.SelectedIndex = -1;
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedBan = null;
            filterBans = new List<ListaNegra>();
            loadTable(bans);
            getUnbannedMembers();
            loadDataCmb(members);
        }

        private bool filterMembers(object data)
        {
            return (data as Miembro).nombre.ToUpper().Contains(cmbMembers.TextBox.Text.ToUpper());
        }

        private bool filterResponsables(object data)
        {
            return (data as Miembro).nombre.ToUpper().Contains(cmbResponsable.TextBox.Text.ToUpper());
        }

        private void loadTable(List<ListaNegra> bans)
        {
         
            dgvBlackList.DataSource = null;
            dgvBlackList.DataSource = bans;
            FormUtils.hideColumnsForDgv(columnsToHideForBlackList, dgvBlackList);
            FormUtils.changeTitlesForDgv(titlesforBlackList, columnsToChangeForBlackList, dgvBlackList);
            dgvBlackList.AutoResizeColumns();
            dgvBlackList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            return;
        }

        private List<ListaNegra> getBans()
        {
            Operation<ListaNegra> operation = blackListController.getRecords();
            if (operation.State)
            {
                bans = operation.Data;
                return operation.Data;
            }
            MessageBox.Show("Error al cargas lista negra");
            return new List<ListaNegra>();
        }

        private void loadDataCmb(List<Miembro> members)
        {
         
            cmbMembers.DataSource = members;
            cmbMembers.ValueMember = "idMiembro";
            cmbMembers.DropDownListView.View.RefreshFilter();

            cmbResponsable.DataSource = members;
            cmbResponsable.ValueMember = "idMiembro";
            cmbMembers.DropDownListView.View.RefreshFilter();

        }
        private List<Miembro> getUnbannedMembers()
        {
   
            Operation<Miembro> memberOperation = memberController.getUnbannedMembers();
            if (!memberOperation.State)
            {
                MessageBox.Show("Error al cargar los datos de miembros");
                return new List<Miembro>();
            }
            members = memberOperation.Data;
            return memberOperation.Data;
        }

        private void setTemporarilyAllMembers()
        {
            Operation<Miembro> memberOperation = memberController.getActiveRecords();
            if (!memberOperation.State)
            {
                MessageBox.Show("Error al cargar los datos de miembros");
                return;
            }
            loadDataCmb(memberOperation.Data);
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtDescription, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el movitovo" }),

                 new ToValidate(cmbResponsable, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un responsable" }),

                 new ToValidate(cmbMembers, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un miembro" }),
            };
            return validators;
        }
    }
}
