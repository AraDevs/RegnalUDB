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
    public partial class frmScholarship : Form
    {
        SchoolarshipController scholarshipController = new SchoolarshipController();
        List<Escolaridad> scholarships = new List<Escolaridad>();
        Escolaridad selectedScholarship = null;

        List<Escolaridad> filterSchoolarships = new List<Escolaridad>();

        private int[] columnsToHideForScholarship = { 3 };
        private int[] columnsToChangeForScholarship = { 0, 1, 2 };
        private string[] titlesforScholarship = { "ID", "Grado", "Activo" };

        public frmScholarship()
        {
            InitializeComponent();
            chbStatus.Checked = true;
            loadTable(getScholarship());
        }

        private void frmScholarship_Load(object sender, EventArgs e)
        {

        }


        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            String value = txtSearch.Text.Trim().ToUpper();
            if (value.Trim().Length > 0)
            {
                filterSchoolarships = FormUtils.filterData<Escolaridad>(scholarships, (g) =>
                  g.grado.ToUpper().Contains(value)
                );
                loadTable(filterSchoolarships);
                return;
            }
            filterSchoolarships = new List<Escolaridad>();
            loadTable(scholarships);
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            this.errorProvider.Clear();
            List<ControlErrorProvider> errorsProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorsProvider == null;
            if (isValid)
            {
                bool isNew = selectedScholarship == null;
                Escolaridad scholarship = new Escolaridad()
                {
                    idEscolaridad = isNew ? 0 : selectedScholarship.idEscolaridad,
                    grado = txtGrade.Text,
                    baja = isNew ? true : chbStatus.Checked
                };

                Operation<Escolaridad> operation = isNew ? scholarshipController.addRecord(scholarship) :
                        scholarshipController.updateRecord(scholarship);
                if (operation.State)
                {
                    loadTable(getScholarship());
                    clearForm();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                foreach (ControlErrorProvider errorProvider in errorsProvider)
                    this.errorProvider.SetError(errorProvider.ControlName, errorProvider.ErrorMessage);
            }
        }

        private void dgvScholarships_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                List<Escolaridad> list = filterSchoolarships.Count == 0 ? scholarships : filterSchoolarships;
                selectedScholarship = list[index];

                chbStatus.Checked = selectedScholarship.baja;
                txtGrade.Text = selectedScholarship.grado;
                btnSaveModify.Text = "Modificar";
            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        private void loadTable(List<Escolaridad> scholarships)
        {
            dgvScholarships.DataSource = null;
            dgvScholarships.DataSource = scholarships;
            FormUtils.hideColumnsForDgv(columnsToHideForScholarship, dgvScholarships);
            FormUtils.changeTitlesForDgv(titlesforScholarship, columnsToChangeForScholarship, dgvScholarships);
            /*dgvScholarships.AutoResizeColumns();
            dgvScholarships.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;*/
            return;
        }

        public List<Escolaridad> getScholarship()
        {
            Operation<Escolaridad> operation = scholarshipController.getRecords();
            if (operation.State)
            {
                scholarships = operation.Data;
                return operation.Data;
            }
            MessageBox.Show("Error al cargas datos de escolaridad");
            return new List<Escolaridad>();
        }

  

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtGrade, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el movitovo" }),

            };
            return validators;
        }
        private void clearForm()
        {
            FormUtils.clearTextbox(new Control[] { txtGrade, txtSearch });
            chbStatus.Checked = true;
            btnSaveModify.Text = "Guardar";
            selectedScholarship = null;
            filterSchoolarships = new List<Escolaridad>();
            loadTable(scholarships);
        }

       
    }
}
