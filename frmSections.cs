using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RegnalUDB.Controllers;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmSections : Form
    {
        private  static SectionController sectionController = new SectionController();
        private List<Seccione> sections = new List<Seccione>();

        private Seccione selectedSection = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 3, 4, 5, 6 }; 
        private int[] columnsToHide = { 7,8 };
        private string[] titlesforColumns = { "ID", "Activo", "Edad inicio","Edad fin", "Sexo"};
        public frmSections()
        {
            InitializeComponent();
        }
        private void fillSelectedData(Seccione currentSection)
        {
            txtName.Text = currentSection.Nombre;
            txtDescription.Text = currentSection.Descripcion;
            txtStartRange.Text = currentSection.rangoInicio.ToString();
            txtEndRange.Text = currentSection.rangoFin.ToString();
            btnStatus.Value = currentSection.baja;
            rdbFemale.Checked = currentSection.sexo.ToUpper() == "F";
            rdbMale.Checked = currentSection.sexo.ToUpper() == "M";
        }
        private void loadTable()
        {
            Operation<Seccione> getSectionsOperation = sectionController.getRecords();
            if (getSectionsOperation.State)
            {
                sections = getSectionsOperation.Data;
                dgvSections.DataSource = sections;
                
                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvSections);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvSections);
                return;
            }
            MessageBox.Show("Error al cargas datos de secciones");
        }

        private void saveData()
        {
            Seccione tempSec = new Seccione
            {
                Nombre = txtName.Text,
                Descripcion = txtDescription.Text,
                sexo = rdbFemale.Checked ? "F" : "M",
                baja = btnStatus.Value,
                rangoInicio = Int32.Parse(txtStartRange.Text),
                rangoFin = Int32.Parse(txtEndRange.Text)
            };
            Operation<Seccione> operation = sectionController.addRecord(tempSec);
            if (operation.State)
            {
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Seccione currentSection)
        {
            Operation<Seccione> operation = sectionController.updateRecord(currentSection);
            if (operation.State)
            {
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
                List<Seccione> tempSecciones = new List<Seccione>();
                foreach (Seccione s in sections)
                {
                    if (s.Nombre.Contains(value) ||
                        s.Descripcion.Contains(value) ||
                        s.sexo.Contains(value) ||
                        s.rangoFin.ToString().Contains(value) ||
                        s.rangoInicio.ToString().Contains(value))
                    {
                        tempSecciones.Add(s);
                    }
                }
                dgvSections.DataSource = tempSecciones;
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
                 new ToValidate(txtDescription, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa una descripcion" }),
                 new ToValidate(txtStartRange, new ControlValidator[] { FormValidators.IsNumber },
                 new string[] { "El valor ingresado en rango inicio debe ser un numero" }),
                 new ToValidate(txtEndRange, new ControlValidator[] { FormValidators.IsNumber },
                 new string[] { "El valor ingresado en rango fin debe ser un numero" })
            };
            return validators;
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            rdbFemale.Checked = true;
            rdbMale.Checked = false;
            btnSaveModify.Text = "Guardar";
            selectedSection = null;
        }

        private Control[] textControls()
        {
            Control[] controls = { txtDescription, txtEndRange, txtName, txtStartRange };
            return controls;
        }
        
        private void frmSections_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            string errorMessage = FormValidators.validForm(getValidators());
            bool isValid = errorMessage == null;
            bool isGreater = FormValidators.isGreaterThan(txtEndRange, txtStartRange);
            if (isValid && isGreater)
            {
                if(selectedSection == null)
                {
                    saveData();
                }
                else
                {
                    selectedSection.Nombre = txtName.Text;
                    selectedSection.Descripcion = txtDescription.Text;
                    selectedSection.rangoInicio = Int32.Parse(txtStartRange.Text);
                    selectedSection.rangoFin = Int32.Parse(txtEndRange.Text);
                    selectedSection.sexo = rdbFemale.Checked ? "F" : "M";
                    selectedSection.baja = btnStatus.Value;
                    updateData(selectedSection);
                }
            }
            else
            {
                MessageBox.Show(isGreater?errorMessage:errorMessage+" rango mayor no puede ser inferior a rango menor");
            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void dgvSections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedSection = sections[index];
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedSection);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }
    }
}
