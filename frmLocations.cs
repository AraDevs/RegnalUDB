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
    public partial class frmLocations : Form
    {
        LocalityController localityController = new LocalityController();
        private List<Localidade> locations = new List<Localidade>();
        private List<Localidade> filterLocations = new List<Localidade>();

        private Localidade selectedLocality = null;

        // data for custom DataGridView
        private int[] columnsToHideForLocations = { 4 };
        private int[] columnsToChangeForLocation = { 0, 1, 2, 3};
        private string[] titlesforLocations = { "Id", "Nombre", "Descripción domicilio", "Activo"};

        public frmLocations()
        {
            InitializeComponent();

            loadTable(this.getLocations());

            chbStatus.Checked = true;
        }

        private void frmLocations_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
                bool isNew = selectedLocality == null;
                bool isValid = errorsProvider == null;

                if (isValid)
                {
                    Localidade localidade = new Localidade
                    {
                        idLocalidad = isNew ? 0 : selectedLocality.idLocalidad,
                        nombre = txtName.Text,
                        domicilioCorrespondencia = txtDescription.Text,
                        baja = isNew ? true : chbStatus.Checked,
                    };

                    LocalityController controller = new LocalityController();
                    Operation<Localidade> operation = isNew ? controller.addRecord(localidade) : controller.updateRecord(localidade);
                    if (operation.State)
                    {
                        loadTable(this.getLocations());
                        clearForm();
                        MessageBox.Show(isNew ? "Nuevo localidad registrada" : "Localidad modificada");
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
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

     
        private void dgvLocations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                List<Localidade> list = filterLocations.Count == 0 ? locations : filterLocations;
                selectedLocality = list[index];
                txtName.Text = selectedLocality.nombre;
                txtDescription.Text = selectedLocality.domicilioCorrespondencia;
                chbStatus.Checked = selectedLocality.baja;
                btnSaveModify.Text = "Modificar";
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String value = txtSearch.Text.Trim().ToUpper();
            if (value.Trim().Length > 0)
            {
                filterLocations = FormUtils.filterData<Localidade>(locations, (g) =>
                   g.nombre.ToUpper().Contains(value) || g.domicilioCorrespondencia.ToString().Contains(value)
                );
                loadTable(filterLocations);
                return;
            }
            filterLocations = new List<Localidade>();
            loadTable(locations);
        }


        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el nombre de la localidad" }),

             new ToValidate(txtDescription, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese descripción sobre el domicilio de correspondencia" }),
            };
            return validators;
        }

        public List<Localidade> getLocations()
        {
            Operation<Localidade> getLocalidadeOperation = localityController.getRecords();
            if (getLocalidadeOperation.State)
            {
                locations = getLocalidadeOperation.Data;
                return getLocalidadeOperation.Data;
            }
            MessageBox.Show("Error al cargas datos de localidades");
            return new List<Localidade>();
        }
        private void loadTable(List<Localidade> locations)
        {
            dgvLocations.DataSource = null;
            dgvLocations.DataSource = locations;
            FormUtils.hideColumnsForDgv(columnsToHideForLocations, dgvLocations);
            FormUtils.changeTitlesForDgv(titlesforLocations, columnsToChangeForLocation, dgvLocations);
            /*dgvLocations.AutoResizeColumns();
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
            return;
        }

        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtName, txtDescription, txtSearch });
            chbStatus.Checked = true;
            errorProvider.Clear();
            btnSaveModify.Text = "Guardar";
            selectedLocality = null;
            filterLocations = new List<Localidade>();
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            clearForm();
            loadTable(getLocations());
        }
    }
}
