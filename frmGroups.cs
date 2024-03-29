﻿using System;
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

        private Usuario currentUser = new Usuario();
        
        // data for custom DataGridView
        private int[] columnsToHideForGroups = { 6, 7, 12, 13 };
        private int[] columnsToChangeForGroups = { 0, 1, 2, 3, 4, 5, 8, 9, 10, 11 };
        private string[] titlesforGroups = { "ID", "Nombre", "Fecha fundación","Numero de grupo", "Horario",
              "Baja", "Fecha registro", "Registro", "Distrito", "Localidad"  };

        private int[] columnsToHideForSections = {12, 15 };
        private int[] columnsToChangeForSections = { 0, 1, 2, 3, 4, 5,6,7, 8, 9, 10, 11,13,14 };
        private string[] titlesForSections = {"Id", "Lobeznas", "Scout femeninos", "Caminante femenino", "Rover femeninos", "Lobatos", "Scouts masculinos",
         "Caminante Masculino", "Rover masculino", "Scouter", "Dirigente", "Padre scount",  "Mes", "Año"};
        public frmGroups()
        {
            InitializeComponent();

              
            /*DistricController districController = new DistricController();
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

            chbStatus.Checked = true;
            chbRegistration.Checked = true;*/

        }
        public frmGroups(Usuario u)
        {
            InitializeComponent();
            currentUser = u;
        }

        private void setReadOnly()
        {
            switch (currentUser.Perfile.idPerfil)
            {
                case 2:
                    panel2.Enabled = false;
                    break;
                case 3:
                    panel2.Enabled = false;
                    break;
                case 5:
                    panel2.Enabled = false;
                    break;
                case 7:
                    panel2.Enabled = false;
                    break;
            }
        }

        private void frmGroups_Load(object sender, EventArgs e)
        {
            try { 
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

                chbStatus.Checked = true;
                chbRegistration.Checked = true;

                setReadOnly();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }


        private void dgvGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    List<Grupos> list = filterGroups.Count == 0 ? groups : filterGroups;
                    selectedGroup = list[index];
                
                    HashSet<TotalSeccion> sections = (HashSet<TotalSeccion>) selectedGroup.TotalSeccions;
                    TotalSeccion[] sectionsData =  new TotalSeccion[sections.Count];
                    sections.CopyTo(sectionsData);

                    loadSectionsTable(sectionsData);
 
               

                    cmbDistricts.SelectedItem = selectedGroup.Distrito;
                    cmbLocations.SelectedItem = selectedGroup.Localidade;
                    txtGroup.Text = selectedGroup.grupoNum.ToString();
                    txtName.Text = selectedGroup.nombre;
                    txtSchedule.Text = selectedGroup.horario;
                    chbStatus.Checked = selectedGroup.baja; 
                    dtpFundation.Value = selectedGroup.fundacion;
                    chbRegistration.Checked = selectedGroup.registrado;
                    dtpRegistration.Value = selectedGroup.fechaRegistro;

                    btnSaveModify.Text = "Modificar";
                }
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
                        baja = isNew ? true : chbStatus.Checked,
                        Distrito = (Distrito)cmbDistricts.SelectedItem,
                        Localidade = (Localidade)cmbLocations.SelectedItem,
                        fechaRegistro = dtpFundation.Value,
                        registrado = chbRegistration.Checked
                    };

                    GroupController controller = new GroupController();
                    Operation<Grupos> operation = isNew ? controller.addRecord(group) : controller.updateRecord(group);
                    if (operation.State)
                    {
                        loadTable(this.getGroups());
                        clearForm();
                        MessageBox.Show(isNew ? "Nuevo grupo registrado" : "Grupo modificado");
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

                 new ToValidate(dtpRegistration, new ControlValidator[] { FormValidators.isValidDate },
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
            /*FormUtils.hideColumnsForDgv(columnsToHideForGroups, dgvGroups);
            FormUtils.changeTitlesForDgv(titlesforGroups, columnsToChangeForGroups, dgvGroups);*/
            return;
        }

        private void loadSectionsTable(TotalSeccion[] sections)
        {
            dgvSections.DataSource = null;
            dgvSections.DataSource = sections;
            FormUtils.hideColumnsForDgv(columnsToHideForSections, dgvSections);
            FormUtils.changeTitlesForDgv(titlesForSections, columnsToChangeForSections, dgvSections);
            return;
        }

        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtName, txtGroup, txtSchedule, txtSearch });
            FormUtils.deselect(new ComboBoxAdv[] { cmbDistricts, cmbLocations });
            chbStatus.Checked = true;
            chbRegistration.Checked = true;
            dtpFundation.Value = DateTime.Now;
            dtpFundation.Value = DateTime.Now;
            selectedGroup = null;
            errorProvider.Clear();
            btnSaveModify.Text = "Guardar";
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
            try { 
                loadTable(groups);
                clearForm();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }


        private void applyingTheme()
        {
            SkinManager.ApplicationVisualTheme = "VioletTheme";
        }

        private void autoLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try { 
                if (e.TabPageIndex == 1 && selectedGroup == null)
                {
                    e.Cancel = true;
                    MessageBox.Show("Seleccione un grupo");
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
