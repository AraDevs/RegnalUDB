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
    public partial class frmAnnouncements : Form
    {
        private static AdvertisementsController advertisementsController = new AdvertisementsController();
        private static ProvinceController provinceController = new ProvinceController();
        private List<Anuncio> advertisements = new List<Anuncio>();
        private List<Provincia> provinces = new List<Provincia>();

        private Anuncio selectedAdvertisement = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2, 3, 5 };
        private int[] columnsToHide = { 4 };
        private string[] titlesforColumns = { "ID", "Mensaje", "Vigencia", "Estado", "Provincia" };
        
        private void fillSelectedData(Anuncio currentAdvertisement)
        {
            txtMessage.Text = currentAdvertisement.mensaje;
            cmbProvincess.SelectedItem = currentAdvertisement.Provincia;
            dtpLife.Value = currentAdvertisement.vigencia;
            chbStatus.Checked = currentAdvertisement.baja;
        }

        private void loadcmb()
        {
            dtpLife.MinValue = DateTime.Now;
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
            Operation<Anuncio> getSectionsOperation = advertisementsController.getRecords();
            if (getSectionsOperation.State)
            {
                advertisements = getSectionsOperation.Data;
                dgvAdvertisements.DataSource = advertisements;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvAdvertisements);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvAdvertisements);
                return;
            }
            MessageBox.Show("Error al cargas datos de secciones");
        }

        private void saveData()
        {
            Provincia p = cmbProvincess.SelectedItem as Provincia;
            Anuncio tempAnu = new Anuncio
            {
                mensaje = txtMessage.Text,
                vigencia = dtpLife.Value,
                idProvincia = p.idProvincia,
                baja = chbStatus.Checked
            };
            Operation<Anuncio> operation = advertisementsController.addRecord(tempAnu);
            if (operation.State)
            {
                MessageBox.Show("Anuncio agregado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Anuncio currentAdvertisement)
        {
            Operation<Anuncio> operation = advertisementsController.updateRecord(currentAdvertisement);
            if (operation.State)
            {
                MessageBox.Show("Anuncio actualizado con exito");
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
                List<Anuncio> tempAnuncio = new List<Anuncio>();
                foreach (Anuncio s in advertisements)
                {
                    
                    if (s.mensaje.Contains(value))
                    {
                        tempAnuncio.Add(s);
                    }
                }
                dgvAdvertisements.DataSource = tempAnuncio;
            }
            else
            {
                loadTable();
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtMessage, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa un mensaje" }),
            };
            return validators;
        }

        private void cleanForm()
        {
            
            FormUtils.clearTextbox(textControls());
            dtpLife.Value = DateTime.Now;
            btnSaveModify.Text = "Guardar";
            errorProvider.Clear();
        }

        private Control[] textControls()
        {
            Control[] controls = { txtMessage };
            return controls;
        }

        public frmAnnouncements()
        {
            InitializeComponent();
        }

        private void frmAnnouncements_Load(object sender, EventArgs e)
        {
            try { 
                loadTable();
                loadcmb();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try { 
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                if (isValid)
                {
                    if (selectedAdvertisement == null)
                    {
                        saveData();
                    }
                    else
                    {
                        Provincia p = cmbProvincess.SelectedItem as Provincia;
                        selectedAdvertisement.mensaje = txtMessage.Text;
                        selectedAdvertisement.idProvincia = p.idProvincia;
                        selectedAdvertisement.vigencia = dtpLife.Value;
                        selectedAdvertisement.baja = chbStatus.Checked;
                        updateData(selectedAdvertisement);
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
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            try { 
                cleanForm();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try { 
                filterData();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dgvAdvertisements_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedAdvertisement = advertisements[index];
                    btnSaveModify.Text = "Modificar";
                    if (!(selectedAdvertisement.vigencia < DateTime.Today))
                    {
                        fillSelectedData(selectedAdvertisement);
                    }
                    else
                    {
                        MessageBox.Show("No puede modificar anuncios ya vencidos, por favor cree uno nuevo");
                    }
                
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
