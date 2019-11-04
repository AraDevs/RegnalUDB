using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmDistricts : Form
    {
        private static DistricController districController = new DistricController();
        private static ProvinceController provinceController = new ProvinceController();
        private List<Distrito> districts = new List<Distrito>();
        private List<Provincia> provinces = new List<Provincia>();

        private Distrito selectedDistrict = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2, 3, 4 };
        private int[] columnsToHide = { 5,6 };
        private string[] titlesforColumns = { "ID", "Nombre", "Numero", "Estado", "Provincia" };

        private void fillSelectedData(Distrito currentDistrict)
        {
            txtName.Text = currentDistrict.nombre;
            cmbProvincess.SelectedItem = currentDistrict.Provincia;
            chbStatus.Checked = currentDistrict.baja;
        }

        private void loadcmb()
        {
            Operation<Provincia> getProvinceOperation = provinceController.getActiveRecords();
            if (getProvinceOperation.State)
            {
                provinces = getProvinceOperation.Data;
                cmbProvincess.DataSource = provinces;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de provincias. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadTable()
        {
            Operation<Distrito> getDistrictOperation = districController.getRecords();
            if (getDistrictOperation.State)
            {
                districts = getDistrictOperation.Data;
                dgvDistricts.DataSource = districts;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvDistricts);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvDistricts);
                return;
            }
            MessageBox.Show("Error al cargas datos de Distritos");
        }

        private void saveData()
        {
            Provincia p = cmbProvincess.SelectedItem as Provincia;
            Distrito tempDistrito = new Distrito
            {
                nombre = txtName.Text,
                numero = short.Parse((districts.Count + 1).ToString()),
                idProvincia = ((Provincia)cmbProvincess.SelectedItem).idProvincia,
                baja = chbStatus.Checked

            };
            Operation<Distrito> operation = districController.addRecord(tempDistrito);
            if (operation.State)
            {
                MessageBox.Show("Distrito agregado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Distrito currentDistrict)
        {
            Operation<Distrito> operation = districController.updateRecord(currentDistrict);
            if (operation.State)
            {
                MessageBox.Show("Distrito actualizado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!this.Equals(""))
            {
                List<Distrito> tempDistrito = new List<Distrito>();
                foreach (Distrito s in districts)
                {

                    if (s.nombre.Contains(value) || s.Provincia.nombre.Contains(value))
                    {
                        tempDistrito.Add(s);
                    }
                }
                dgvDistricts.DataSource = tempDistrito;
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
                 new string[] { "Ingresa un nombre" }),
            };
            return validators;
        }

        private void cleanForm()
        {

            FormUtils.clearTextbox(textControls());
            btnSaveModify.Text = "Guardar";
            selectedDistrict = null;
            chbStatus.Checked = true;
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls = { txtName };
            return controls;
        }

        public frmDistricts()
        {
            InitializeComponent();
        }

        private void frmDistricts_Load(object sender, EventArgs e)
        {
            loadTable();
            loadcmb();
            chbStatus.Checked = true;
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorProvider == null;
            if (isValid)
            {
                if (selectedDistrict == null)
                {
                    saveData();
                }
                else
                {
                    Provincia p = cmbProvincess.SelectedItem as Provincia;
                    selectedDistrict.nombre = txtName.Text;
                    selectedDistrict.idProvincia = ((Provincia)cmbProvincess.SelectedItem).idProvincia;
                    selectedDistrict.baja = chbStatus.Checked;
                    updateData(selectedDistrict);
                }
            }
            else
            {
                this.errorProvider.Clear();
                MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (ControlErrorProvider error in errorProvider)
                {
                    this.errorProvider.SetError(error.ControlName, error.ErrorMessage);
                }


            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }

        private void dgvDistricts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedDistrict = districts[index];
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedDistrict);

            }
        }
    }
}
