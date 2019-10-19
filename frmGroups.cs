using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmGroups : Form
    {
        private GroupController groupController = new GroupController();

        private List<Distrito> districts = new List<Distrito>();
        private List<Localidade> localities = new List<Localidade>();

        private List<Grupos> groups = new List<Grupos>();
        private List<Grupos> filterGroups = new List<Grupos>();

        private Grupos selectedGroup = null;

        // data for custom DataGridView
        private int[] columnsToHideForGroups = { 6, 7, 12, 13 };
        private int[] columnsToChangeForGroups = { 0, 1, 2, 3, 4, 5, 8, 9, 10, 11 };
        private string[] titlesforGroups = { "ID", "Nombre", "Fecha fundación","Numero de grupo", "Horario",
              "Baja", "Fecha registro", "Registro", "Distrito", "Localidad"  };
        public frmGroups()
        {
            InitializeComponent();


            DistricController districController = new DistricController();
            LocalityController localityController = new LocalityController();

            Operation<Distrito> getDistrictOperation = districController.getRecords();
            Operation<Localidade> getLocalitiesOperation = localityController.getRecords();
            bool dataIsRetrieved = getLocalitiesOperation.State && getDistrictOperation.State;

            if (dataIsRetrieved)
            {
                // set data
                districts = getDistrictOperation.Data;
                localities = getLocalitiesOperation.Data;
                // load data
                cmbDistricts.DataSource = districts;
                cmbLocations.DataSource = localities;

                loadTable(this.getGroups());

                cmbDistricts.SelectedIndex = -1;
                cmbLocations.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(getDistrictOperation.Error);
            }
        }

        private void frmGroups_Load(object sender, EventArgs e)
        { }


        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                List<Grupos> list = filterGroups.Count == 0 ? groups : filterGroups;
                selectedGroup = list[index];
                cmbDistricts.SelectedItem = selectedGroup.Distrito;
                cmbLocations.SelectedItem = selectedGroup.Localidade;
                txtGroup.Text = selectedGroup.grupoNum.ToString();
                txtName.Text = selectedGroup.nombre;
                txtSchedule.Text = selectedGroup.horario;
                chbStatus.Checked = selectedGroup.baja; 
                dtpFundation.Value = selectedGroup.fundacion;

                btnSaveModify.Text = "Modificar";
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
                bool isNew = selectedGroup == null;
                bool isValid = errorsProvider == null;

                if (isValid)
                {
                    Grupos group = new Grupos
                    {
                        idGrupo = isNew ? 0 : selectedGroup.idGrupo,
                        nombre = txtName.Text,
                        fundacion = dtpFundation.Value,
                        grupoNum = short.Parse(txtGroup.Text),
                        horario = txtSchedule.Text,
                        baja = chbStatus.Checked,
                        Distrito = (Distrito)cmbDistricts.SelectedItem,
                        Localidade = (Localidade)cmbLocations.SelectedItem,
                        fechaRegistro = isNew ? DateTime.Now : selectedGroup.fechaRegistro,
                        registrado = true
                    };

                    GroupController controller = new GroupController();
                    Operation<Grupos> operation = isNew ? controller.addRecord(group) : controller.updateRecord(group);
                    if (operation.State)
                    {
                        loadTable(this.getGroups());
                        clearForm();
                        MessageBox.Show(isNew ? "Nuevo grupo registrado" : "Grupo Modificado");
                        return;
                    }

                    MessageBox.Show(operation.Error);
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    foreach (ControlErrorProvider errorProvider in errorsProvider)
                        this.errorProvider.SetError(errorProvider.ControlName, errorProvider.ErrorMessage);
                }
            }
            catch(Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el nombre del grupo" }),

                 new ToValidate(txtGroup, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El valor ingresado en registro debe ser un numero" }),

                 new ToValidate(cmbDistricts, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un distrito" }),

                 new ToValidate(dtpFundation, new ControlValidator[] { FormValidators.isValidDate },
                 new string[] { "La fecha ingresada sobrepasa el día actual" }),

                 new ToValidate(txtSchedule, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa un horario" }),

                 new ToValidate(cmbLocations, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona una localidad" }),
            };
            return validators;
        }

        private void loadTable(List<Grupos> groups)
        {
            dgvGroups.DataSource = null;
            dgvGroups.DataSource = groups;
            FormUtils.hideColumnsForDgv(columnsToHideForGroups, dgvGroups);
            FormUtils.changeTitlesForDgv(titlesforGroups, columnsToChangeForGroups, dgvGroups);
            return;
        }

        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtName, txtGroup, txtSchedule });
            //FormUtils.deselect(new ComboBox[] { cmbDistricts, cmbLocations });
            chbStatus.Checked = true;
            dtpFundation.Value = DateTime.Now;
            selectedGroup = null;
            errorProvider.Clear();
            btnSaveModify.Text = "Guardar";
            txtSearch.Text = "";
            filterGroups = new List<Grupos>();

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String value = txtSearch.Text.Trim().ToUpper();
            if (value.Trim().Length > 0)
            {
                 filterGroups = FormUtils.filterData<Grupos>(groups, (g) =>
                    g.nombre.ToUpper().Contains(value) || g.grupoNum.ToString().Contains(value) ||
                    g.Localidade.nombre.ToUpper().Contains(value) || g.Distrito.nombre.Contains(value) ||
                    g.horario.ToUpper().Contains(value) || g.fundacion.ToString().ToUpper().Contains(value)
                 );
                loadTable(filterGroups);
                return;
            }
            filterGroups = new List<Grupos>();
            loadTable(groups);
        }

        public List<Grupos> getGroups()
        {
            Operation<Grupos> getGroupsOperation = groupController.getRecords();
            if (getGroupsOperation.State)
            {
                groups = getGroupsOperation.Data;
                return getGroupsOperation.Data;
            }
            MessageBox.Show("Error al cargas datos de grupos");
            return new List<Grupos>();
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            loadTable(groups);
            clearForm();
        }


        private void applyingTheme()
        {
            SkinManager.ApplicationVisualTheme = "VioletTheme";
        }
    }
}
