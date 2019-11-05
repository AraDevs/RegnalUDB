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
    public partial class frmProvinces : Form
    {

        ProvinceController provinceController = new ProvinceController();
        private List<Provincia> provinces = new List<Provincia>();
        private List<Provincia> filterProvinces = new List<Provincia>();

        private Provincia selectedProvince = null;

        // data for custom DataGridView
        private int[] columnsToHideForProvinces = { 4, 5, 6 };
        private int[] columnsToChangeForProvinces = { 0, 1, 2, 3 };
        private string[] titlesforProvinces = { "Id", "Nombre",  "Activo", "Clave" };
        public frmProvinces()
        {
            InitializeComponent();


            loadTable(this.getProvinces());

            chbStatus.Checked = true;
        }

        private void frmProvinces_Load(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String value = txtSearch.Text.Trim().ToUpper();
            if (value.Trim().Length > 0)
            {
                filterProvinces = FormUtils.filterData<Provincia>(provinces, (g) =>
                   g.nombre.ToUpper().Contains(value) || g.clave.ToString().Contains(value)
                );
                loadTable(filterProvinces);
                return;
            }
            filterProvinces = new List<Provincia>();
            loadTable(provinces);
        }

        private void dgvProvinces_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                List<Provincia> list = filterProvinces.Count == 0 ? provinces : filterProvinces;
                selectedProvince = list[index];
                txtName.Text = selectedProvince.nombre;
                txtKey.Text = selectedProvince.clave;
                chbStatus.Checked = selectedProvince.baja;
                btnSaveModify.Text = "Modificar";
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
                bool isNew = selectedProvince == null;
                bool isValid = errorsProvider == null;

                if (isValid)
                {
                    Provincia province = new Provincia
                    {
                        idProvincia = isNew ? 0 : selectedProvince.idProvincia,
                        nombre = txtName.Text,
                        clave = txtKey.Text,
                        baja = isNew ? true : chbStatus.Checked
                    };

                    ProvinceController controller = new ProvinceController();
                    Operation<Provincia> operation = isNew ? controller.addRecord(province) : controller.updateRecord(province);
                    if (operation.State)
                    {
                        loadTable(this.getProvinces());
                        clearForm();
                        MessageBox.Show(isNew ? "Nuevo provincia registrada" : "Provincia modificada");
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

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            clearForm();
            loadTable(getProvinces());
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el nombre de la provincia" }),

             new ToValidate(txtKey, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa una clave" }),
            };
            return validators;
        }

        public List<Provincia> getProvinces()
        {
            Operation<Provincia> getLocalidadeOperation = provinceController.getRecords();
            if (getLocalidadeOperation.State)
            {
                provinces = getLocalidadeOperation.Data;
                return getLocalidadeOperation.Data;
            }
            MessageBox.Show("Error al cargas datos de provincias");
            return new List<Provincia>();
        }
        private void loadTable(List<Provincia> locations)
        {
            dgvProvinces.DataSource = null;
            dgvProvinces.DataSource = locations;
            FormUtils.hideColumnsForDgv(columnsToHideForProvinces, dgvProvinces);
            FormUtils.changeTitlesForDgv(titlesforProvinces, columnsToChangeForProvinces, dgvProvinces);
            /*dgvProvinces.AutoResizeColumns();
            dgvProvinces.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
            return;
        }

        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtName, txtKey, txtSearch });
            chbStatus.Checked = true;
            errorProvider.Clear();
            btnSaveModify.Text = "Guardar";
            selectedProvince = null;
            filterProvinces = new List<Provincia>();
        }

     

        
    }
}
