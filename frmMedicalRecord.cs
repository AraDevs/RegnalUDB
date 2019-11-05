using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using static RegnalUDB.Utils.FormValidators;
using RegnalUDB.Utils;
using RegnalUDB.Controllers;
using Syncfusion.Windows.Forms.Tools;

namespace RegnalUDB
{
    public partial class frmMedicalRecord : UserControl
    {
        private Miembro selectedMember = null;
        public Miembro SelectedMember { get => selectedMember; set => selectedMember = value; }

        private static frmMedicalRecord _instance;
        public static frmMedicalRecord Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmMedicalRecord();
                }
                return _instance;
            }
        }

        private MedicalRecordController fmController = new MedicalRecordController();

        public frmMedicalRecord()
        {
            InitializeComponent();
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtContact1, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa al menos un nombre de contacto" }),

                 new ToValidate(txtRelationship1, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el parentesco del contacto 1" }),

                 new ToValidate(txtPhone1, new ControlValidator[] { FormValidators.isPhone },
                 new string[] { "El número de teléfono debe ser una cadena de 8 dígitos que inicie con 2, 6 o 7. Ej.: 22891022, 78101245" }),

                 new ToValidate(txtEmail, new ControlValidator[] { FormValidators.isEmail },
                 new string[] { "Ingresa un correo electrónico de contacto con un formato correcto" }),

                 new ToValidate(txtHeight, new ControlValidator[] { FormValidators.isCurrency },
                 new string[] { "La altura debe ser un valor numérico positivo de con máximo dos decimales" }),

                 new ToValidate(txtWeight, new ControlValidator[] { FormValidators.isCurrency },
                 new string[] { "El peso debe ser un valor numérico positivo de con máximo dos decimales" }),

                 new ToValidate(txtNum, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El número de afiliación debe ser un valor entero positivo" })

            };

            return validators;
        }

        private ToValidate[] getValidatorsContact2()
        {
            ToValidate[] validators =  {
                new ToValidate(txtContact1, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa al menos un nombre de contacto" }),

                 new ToValidate(txtRelationship1, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el parentesco del contacto 1" }),

                 new ToValidate(txtPhone1, new ControlValidator[] { FormValidators.isPhone },
                 new string[] { "El número de teléfono debe ser una cadena de 8 dígitos que inicie con 2, 6 o 7. Ej.: 22891022, 78101245" }),

                 new ToValidate(txtEmail, new ControlValidator[] { FormValidators.isEmail },
                 new string[] { "Ingresa un correo electrónico de contacto con un formato correcto" }),

                 new ToValidate(txtHeight, new ControlValidator[] { FormValidators.isCurrency },
                 new string[] { "La altura debe ser un valor numérico positivo de con máximo dos decimales" }),

                 new ToValidate(txtWeight, new ControlValidator[] { FormValidators.isCurrency },
                 new string[] { "El peso debe ser un valor numérico positivo de con máximo dos decimales" }),

                 new ToValidate(txtNum, new ControlValidator[] { FormValidators.isNumber },
                 new string[] { "El número de afiliación debe ser un valor entero positivo" }),

                 new ToValidate(txtContact2, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el nombre del contacto 2" }),

                 new ToValidate(txtRelationship2, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el parentesco del contacto 2" }),

                 new ToValidate(txtPhone2, new ControlValidator[] { FormValidators.isPhone },
                 new string[] { "El número de teléfono debe ser una cadena de 8 dígitos que inicie con 2, 6 o 7. Ej.: 22891022, 78101245" })

            };

            return validators;
        }

        public void cleanForm()
        {
            foreach (Control x in this.Controls)
            {
                if (x is TabControlAdv)
                {
                    foreach (Control y in x.Controls)
                    {
                        if (y is TabPageAdv)
                        {
                            foreach (Control z in y.Controls)
                            {
                                cleanControl(z);
                            }
                        }

                        cleanControl(y);
                    }
                }

                cleanControl(x);
            }
            
            errorProvider.Clear();

            lblPdf.Text = "Ninguno";
        }

        private void cleanControl(Control x)
        {
            if (x is TextBox)
            {
                ((TextBox)x).Clear();
            }
            else if (x is CheckBoxAdv)
            {
                ((CheckBoxAdv)x).Checked = false;
            }
            else if (x is ComboBoxAdv)
            {
                ((ComboBoxAdv)x).SelectedIndex = 0;
            }
        }

        public void fillSelectedData()
        {
            lblMember.Text = selectedMember.ToString();

            FichasMedica fm = selectedMember.FichasMedicas.FirstOrDefault();

            if (fm != null)
            {
                txtContact1.Text = fm.contacto1;
                txtContact2.Text = fm.contacto2;
                txtHeight.Text = fm.estatura.ToString();
                txtNum.Text = fm.noafilacion;
                txtPhone1.Text = fm.telefono1;
                txtPhone2.Text = fm.telefono2;
                txtRelationship1.Text = fm.parentesco1;
                txtRelationship2.Text = fm.parentesco2;
                txtSocial.Text = fm.ssOtro;
                txtWeight.Text = fm.peso.ToString();
                txtEmail.Text = fm.email;
                chbSocial.Checked = fm.ss;
                cmbBloodType.SelectedItem = fm.sangre;
                lblPdf.Text = frmMembers.pdfPath + fm.imagen;

                chbFlatfoot.Checked = fm.piePlano;
                chbOrtShoe.Checked = fm.ortopedico;
                chbOperation.Checked = fm.operacion;
                txtOperation.Text = fm.operacionObs;
                chbLimit.Checked = fm.limitacion;
                txtLimit.Text = fm.limitacionObs;
                chbTransfusion.Checked = fm.transfusion;
                txtTransfusion.Text = fm.transfunsionObs;
                chbAllergy.Checked = fm.alergia;
                txtAllergy.Text = fm.alergiaObs;
                chbCronic.Checked = fm.cronica;
                txtCronic.Text = fm.cronicaObs;
                chbTreatment.Checked = fm.tratamiento;
                txtTreatment.Text = fm.tratamientoObs;
                chbHear.Checked = fm.Oido;
                txtHear.Text = fm.OidoObs;
                chbProt.Checked = fm.protesis;
                txtProt.Text = fm.protesisObs;
                chbDiet.Checked = fm.dieta;
                txtDiet.Text = fm.dietaObs;
                chbDrug.Checked = fm.tabaco;
                txtDrug.Text = fm.varcharObs;
                chbVaccine.Checked = fm.vacunacion;
                chbPregnant.Checked = fm.mujer;
                cmbSwim.SelectedItem = fm.natacion;
            }
            else
            {
                cleanForm();
            }
        }

        private void saveData()
        {
            string pdfName = "";

            if (lblPdf.Text != "Ninguno")
            {
                pdfName = frmMembers.pdfPath + selectedMember.cum + ".pdf";

                System.IO.File.Copy(lblPdf.Text, pdfName, true);
            }

            FichasMedica tempFm = new FichasMedica
            {
                idMiembro = selectedMember.idMiembro,
                contacto1 = txtContact1.Text.Trim(),
                parentesco1 = txtRelationship1.Text.Trim(),
                telefono1 = txtPhone1.Text.Trim(),
                email = txtEmail.Text.Trim(),
                contacto2 = txtContact2.Text.Trim(),
                parentesco2 = txtRelationship2.Text.Trim(),
                telefono2 = txtPhone2.Text.Trim(),
                sangre = cmbBloodType.SelectedItem.ToString(),
                peso = Convert.ToDecimal(txtWeight.Text.Trim()),
                estatura = Convert.ToDecimal(txtHeight.Text.Trim()),
                noafilacion = txtNum.Text.Trim(),
                ss = chbSocial.Checked,
                ssOtro = txtSocial.Text.Trim(),
                piePlano = chbFlatfoot.Checked,
                ortopedico = chbOrtShoe.Checked,
                operacion = chbOperation.Checked,
                operacionObs = txtOperation.Text.Trim(),
                limitacion = chbLimit.Checked,
                limitacionObs = txtLimit.Text.Trim(),
                transfusion = chbTransfusion.Checked,
                transfunsionObs = txtTransfusion.Text.Trim(),
                alergia = chbAllergy.Checked,
                alergiaObs = txtAllergy.Text.Trim(),
                cronica = chbCronic.Checked,
                cronicaObs = txtCronic.Text.Trim(),
                tratamiento = chbTreatment.Checked,
                tratamientoObs = txtTreatment.Text.Trim(),
                Oido = chbHear.Checked,
                OidoObs = txtHear.Text.Trim(),
                protesis = chbProt.Checked,
                protesisObs = txtProt.Text.Trim(),
                dieta = chbDiet.Checked,
                dietaObs = txtDiet.Text.Trim(),
                tabaco = chbDrug.Checked,
                varcharObs = txtDrug.Text.Trim(),
                vacunacion = chbVaccine.Checked,
                mujer = chbPregnant.Checked,
                natacion = cmbSwim.SelectedIndex,
                fecha = System.DateTime.Today,
                imagen = selectedMember.cum + ".pdf"
            };

            Operation<FichasMedica> operation = fmController.addRecord(tempFm);
            if (operation.State)
            {
                MessageBox.Show("Ficha guardada con éxito.", "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanForm();

                selectedMember = null;
                lblMember.Text = "Ninguno";
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData()
        {
            FichasMedica fmTemp = selectedMember.FichasMedicas.First();

            fmTemp.contacto1 = txtContact1.Text.Trim();
            fmTemp.parentesco1 = txtRelationship1.Text.Trim();
            fmTemp.telefono1 = txtPhone1.Text.Trim();
            fmTemp.email = txtEmail.Text.Trim();
            fmTemp.contacto2 = txtContact2.Text.Trim();
            fmTemp.parentesco2 = txtRelationship2.Text.Trim();
            fmTemp.telefono2 = txtPhone2.Text.Trim();
            fmTemp.sangre = cmbBloodType.SelectedItem.ToString();
            fmTemp.peso = Convert.ToDecimal(txtWeight.Text.Trim());
            fmTemp.estatura = Convert.ToDecimal(txtHeight.Text.Trim());
            fmTemp.noafilacion = txtNum.Text.Trim();
            fmTemp.ss = chbSocial.Checked;
            fmTemp.ssOtro = txtSocial.Text.Trim();
            fmTemp.piePlano = chbFlatfoot.Checked;
            fmTemp.ortopedico = chbOrtShoe.Checked;
            fmTemp.operacion = chbOperation.Checked;
            fmTemp.operacionObs = txtOperation.Text.Trim();
            fmTemp.limitacion = chbLimit.Checked;
            fmTemp.limitacionObs = txtLimit.Text.Trim();
            fmTemp.transfusion = chbTransfusion.Checked;
            fmTemp.transfunsionObs = txtTransfusion.Text.Trim();
            fmTemp.alergia = chbAllergy.Checked;
            fmTemp.alergiaObs = txtAllergy.Text.Trim();
            fmTemp.cronica = chbCronic.Checked;
            fmTemp.cronicaObs = txtCronic.Text.Trim();
            fmTemp.tratamiento = chbTreatment.Checked;
            fmTemp.tratamientoObs = txtTreatment.Text.Trim();
            fmTemp.Oido = chbHear.Checked;
            fmTemp.OidoObs = txtHear.Text.Trim();
            fmTemp.protesis = chbProt.Checked;
            fmTemp.protesisObs = txtProt.Text.Trim();
            fmTemp.dieta = chbDiet.Checked;
            fmTemp.dietaObs = txtDiet.Text.Trim();
            fmTemp.tabaco = chbDrug.Checked;
            fmTemp.varcharObs = txtDrug.Text.Trim();
            fmTemp.vacunacion = chbVaccine.Checked;
            fmTemp.mujer = chbPregnant.Checked;
            fmTemp.natacion = cmbSwim.SelectedIndex;
            fmTemp.fecha = System.DateTime.Today;

            if (lblPdf.Text != fmTemp.imagen)
            {
                if (fmTemp.imagen == "")
                {
                    fmTemp.imagen = selectedMember.cum + ".pdf";
                }

                //Overwriting pdf file if it was changed
                System.IO.File.Copy(lblPdf.Text, frmMembers.pdfPath + selectedMember.cum + ".pdf", true);
            }


            Operation<FichasMedica> operation = fmController.updateRecord(fmTemp);
            if (operation.State)
            {
                MessageBox.Show("Ficha guardada con éxito.", "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleanForm();

                selectedMember = null;
                lblMember.Text = "Ninguno";
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void btnSaveRecord_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();

                if (selectedMember == null)
                {
                    MessageBox.Show("Por favor, seleccione un miembro", "OPERACIÓN DENEGADA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ToValidate[] validators = getValidators();

                //If one of the 'second contact' input has text, all of them must be validated
                if (FormValidators.oneHasText(new Control[] { txtContact2, txtRelationship2, txtPhone2 }))
                {
                    validators = getValidatorsContact2();
                }

                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(validators);
                bool isValid = errorProvider == null;

                if (isValid)
                {
                    FichasMedica fm = selectedMember.FichasMedicas.FirstOrDefault();

                    if (fm == null)
                    {
                        //If there's no record, a new one must be created
                        saveData();

                    }
                    else
                    {
                        //If there's already a record, it must be updated
                        updateData();
                    }
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                    foreach (ControlErrorProvider error in errorProvider)
                    {
                        this.errorProvider.SetError(error.ControlName, error.ErrorMessage);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Buscar archivo(*.pdf;)|*.pdf;";

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    lblPdf.Text = opf.FileName;
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void btnOpenPdf_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblPdf.Text != null && lblPdf.Text != "Ninguno")
                {
                    System.Diagnostics.Process.Start(lblPdf.Text);
                }
                else
                {
                    MessageBox.Show("No hay ningún archivo cargado a la ficha.", "ARCHIVO NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
