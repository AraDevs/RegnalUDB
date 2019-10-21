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
    public partial class frmMembers : Form
    {
        private static ReligionController religionController = new ReligionController();
        private List<Religion> religions = new List<Religion>();
        private static SchoolarshipController schoolarshipController = new SchoolarshipController();
        private List<Escolaridad> scholarships = new List<Escolaridad>();
        private static CivilStatusController civilStatusController = new CivilStatusController();
        private List<EstadoCivil> civilStatuses = new List<EstadoCivil>();
        private static SectionController sectionController = new SectionController();
        private List<Seccione> sections = new List<Seccione>();
        private static GroupController groupController = new GroupController();
        private List<Grupos> groups = new List<Grupos>();
        private static DepartmentController departmentController = new DepartmentController();
        private List<Departamento> departments = new List<Departamento>();
        private static MunicipalityContraller municipalityContraller = new MunicipalityContraller();
        private List<Municipio> municipalities = new List<Municipio>();

        private static DomicileController domicileController = new DomicileController();
        private static MemberController memberController = new MemberController();
        private List<Miembro> members = new List<Miembro>();

        private static PositionController positionController = new PositionController();
        private List<Cargo> positions = new List<Cargo>();

        private Miembro selectedMember = null;
        private Domicilio searchedDomicile = null;

        private string imagePath = "C:\\Users\\kevin\\Desktop\\photos\\";


        // data for custom DataGridView
        private int[] columnsToChange = { 0, 1, 2, 3, 4, 5, 9, 11, 12, 13, 14, 15, 16, 22, 23, 24, 26, 33, 34 };
        private int[] columnsToHide = { 6, 7, 8, 10, 17, 18, 19, 20, 21, 25, 27, 28, 29, 30, 31, 32, 35 };
        private string[] titlesforColumns = { "ID", "CUM", "Nombre", "Apellido paterno", "Apellido materno", "Activo", 
            "Fecha de nacimiento", "Teléfono particular", "Teléfono oficina", "Teléfono móvil", "Email", "Ocupación", 
            "Observaciones", "Dirección", "Escolaridad", "Estado Civil", "Grupo", "Religión", "Sección"};

        public frmMembers()
        {

            InitializeComponent();
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtName, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa el nombre del miembro" }),

                 new ToValidate(dtpBirthday, new ControlValidator[] { FormValidators.isValidDate },
                 new string[] { "La fecha ingresada sobrepasa el día actual" }),

                 new ToValidate(cmbCivilStatus, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un estado civil" }),

                 new ToValidate(cmbDepartment, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un departamento" }),

                 new ToValidate(cmbGroup, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un grupo" }),

                 new ToValidate(cmbMunicipality, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un municipio" }),

                 new ToValidate(cmbReligion, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona una religión" }),

                 new ToValidate(cmbScholarship, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona una escolaridad" }),

                 new ToValidate(cmbSection, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona una sección" }),

                 new ToValidate(txtOcupation, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese la ocupación del miembro" }),

                 new ToValidate(txtMobile, new ControlValidator[] { FormValidators.isMobilePhoneOrNull },
                 new string[] { "El teléfono móvil debe ser una cadena de 8 dígitos que inicie con 6 o 7. Ejemplos: 68901123, 79819912" }),

                 new ToValidate(txtOffice, new ControlValidator[] { FormValidators.isPhoneWithExtensionOrNull },
                 new string[] { "El teléfono de oficina debe ser una cadena de 8 dígitos que inicie con 2, y puede ir acompañada de una extensión de 4 dígitos. Ejemplos: 22329012, 22910014 1457" }),

                 new ToValidate(txtParticular, new ControlValidator[] { FormValidators.isParticularPhone },
                 new string[] { "El teléfono particular debe ser una cadena de 8 dígitos que inicie con 2. Ejemplo: 22329012" }),

                 new ToValidate(txtEmail, new ControlValidator[] { FormValidators.isEmail },
                 new string[] { "El email proporcionado no es válido" }),

                 new ToValidate(pcbPhoto, new ControlValidator[] { FormValidators.hasImageLocation },
                 new string[] { "Seleccione una foto para el miembro" }),

                 new ToValidate(txtStreetNo, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese el número de casa de la dirección" }),

                 new ToValidate(txtStreet, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese al menos una calle aledaña a la dirección" }),

                 new ToValidate(txtColony, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese la colonia de la dirección" }),

                 new ToValidate(txtReference, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese al menos una referencia para la dirección" }),

                 new ToValidate(txtPostalCode, new ControlValidator[] { FormValidators.isPostalCode },
                 new string[] { "El código postal debe constar de cuatro dígitos" }),

                 new ToValidate(txtContact, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingrese el nombre de un contacto para el miembro" }),

                 new ToValidate(txtPhone, new ControlValidator[] { FormValidators.isParticularPhone },
                 new string[] { "El teléfono de contacto debe ser una cadena de 8 dígitos que inicie con 2. Ejemplo: 22329012" })
            };
            return validators;
        }

        private void loadMunicipalities()
        {
            Operation<Municipio> getMunicipalitiesOperation = 
                municipalityContraller.getRecordsByDepartment((Departamento)cmbDepartment.SelectedValue);
            if (getMunicipalitiesOperation.State)
            {
                municipalities = getMunicipalitiesOperation.Data;
                cmbMunicipality.DataSource = municipalities;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de municipios. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSections()
        {
            string gender = rdbMale.Checked ? "m" : "f";
            DateTime now = DateTime.Today;
            int age = now.Year - dtpBirthday.Value.Year;
            if (age == 0)
            {
                //Adjusting age since there's no section that covers an age of zero.
                //Anyways, this case should never happen, but this is necessary since
                //the birthday datepicker displays the current date by default, resulting
                //in a calculation of an age of zero when the form loads.
                age = 1;
            }
            if (dtpBirthday.Value > now.AddYears(-age) && age > 1) //If the birthday hasn't happened this year
            {
                age--;
            }

            Operation <Seccione> getSectionsOperation =
                sectionController.getRecordsByMemberInfo(gender, age);
            if (getSectionsOperation.State)
            {
                sections = getSectionsOperation.Data;
                cmbSection.DataSource = sections;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de secciones. Por favor, asegúrese de que las secciones ingresadas en el sistema sean coherentes en cuanto a edad y género, y luego reinicie el módulo reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCmbs()
        {
            Operation<Religion> getReligionsOperation = religionController.getActiveRecords();
            if (getReligionsOperation.State)
            {
                religions = getReligionsOperation.Data;
                cmbReligion.DataSource = religions;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de religiones. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Operation<Escolaridad> getScholarshipsOperation = schoolarshipController.getActiveRecords();
            if (getScholarshipsOperation.State)
            {
                scholarships = getScholarshipsOperation.Data;
                cmbScholarship.DataSource = scholarships;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de escolaridades. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Operation<EstadoCivil> getCivilStatusesOperation = civilStatusController.getActiveRecords();
            if (getCivilStatusesOperation.State)
            {
                civilStatuses = getCivilStatusesOperation.Data;
                cmbCivilStatus.DataSource = civilStatuses;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de estados civiles. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Operation<Grupos> getGroupsOperation = groupController.getActiveRecords();
            if (getGroupsOperation.State)
            {
                groups = getGroupsOperation.Data;
                cmbGroup.DataSource = groups;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de grupos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Operation<Departamento> getDepartmentsOperation = departmentController.getActiveRecords();
            if (getDepartmentsOperation.State)
            {
                departments = getDepartmentsOperation.Data;
                cmbDepartment.DataSource = departments;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de departamentos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMunicipalities();
            loadSections();
                
        }

        private void loadDomicileCmbs()
        {
            Operation<Departamento> getDepartmentsOperation = departmentController.getRecords();
            if (getDepartmentsOperation.State)
            {
                departments = getDepartmentsOperation.Data;
                cmbDepartment.DataSource = departments;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de departamentos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            loadMunicipalities();
        }

        private void loadPositions()
        {
            Operation<Cargo> getPositionOperation = positionController.getActiveRecords();
            if (getPositionOperation.State)
            {
                positions = getPositionOperation.Data;
                frmMemberPosition.Instance.lstPosition.DataSource = positions;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de cargos. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Control[] textControls()
        {
            Control[] controls = { txtColony, txtContact, txtEmail, txtMaternal, txtMobile, txtName, txtObservation, txtOcupation, txtOffice, txtParticular, txtPaternal, txtPhone, 
                                    txtPostalCode, txtReference, txtStreet, txtStreetNo};
            return controls;
        }
        private Control[] domicileControls()
        {
            Control[] controls = { txtColony, txtContact, txtPhone, txtPostalCode, txtReference, txtStreet, txtStreetNo};
            return controls;
        }

        private void loadTable()
        {
            Operation<Miembro> getMembersOperation = memberController.getRecords();
            if (getMembersOperation.State)
            {
                members = getMembersOperation.Data;
                dgvMembers.DataSource = members;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvMembers);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvMembers);

                return;
            }
            MessageBox.Show("Error al cargar la lista de miembros. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void fillSelectedData(Miembro currentMember)
        {
            lblCum.Text = currentMember.cum;
            txtName.Text = currentMember.nombre;
            txtPaternal.Text = currentMember.paterno;
            txtMaternal.Text = currentMember.materno;
            dtpBirthday.Value = currentMember.fechaNacimiento;
            rdbFemale.Checked = currentMember.sexo.ToUpper() == "F";
            rdbMale.Checked = currentMember.sexo.ToUpper() == "M";
            cmbScholarship.SelectedItem = currentMember.Escolaridad;
            cmbReligion.SelectedItem = currentMember.Religion;
            cmbCivilStatus.SelectedItem = currentMember.EstadoCivil;
            cmbSection.SelectedItem = currentMember.Seccione;
            cmbGroup.SelectedItem = currentMember.Grupos;
            txtObservation.Text = currentMember.observación;
            txtOcupation.Text = currentMember.ocupación;
            txtParticular.Text = currentMember.particular;
            txtOffice.Text = currentMember.oficina;
            txtMobile.Text = currentMember.movil;
            txtEmail.Text = currentMember.email;
            chbStatus.Checked = currentMember.baja;
            pcbPhoto.ImageLocation = currentMember.fotoFileName;

            txtStreetNo.Text = currentMember.Domicilio.calleNumero;
            txtStreet.Text = currentMember.Domicilio.entreCalles;
            txtColony.Text = currentMember.Domicilio.colonia;
            txtReference.Text = currentMember.Domicilio.referencia;
            txtPostalCode.Text = currentMember.Domicilio.codigoPostal;
            txtContact.Text = currentMember.Domicilio.contacto;
            txtPhone.Text = currentMember.Domicilio.telefono;
            chbStatusHome.Checked  = currentMember.Domicilio.baja;
            cmbDepartment.SelectedItem = currentMember.Domicilio.Municipio.Departamento;
            cmbMunicipality.SelectedItem = currentMember.Domicilio.Municipio;

            frmMemberPosition.Instance.lblMember.Text = currentMember.nombre + " " + currentMember.paterno +
                " " + currentMember.materno + " (CUM: " + currentMember.cum + ")";

            frmMemberPosition.Instance.lstPosition.SelectedItems.Clear();

            foreach (MiembroCargo mc in currentMember.MiembroCargoes) {
                frmMemberPosition.Instance.lstPosition.SelectedItems.Add(mc.Cargo);
            }

        }

        private void filterData()
        {
            string value = txtSearch.Text;
            if (!value.Equals(""))
            {
                List<Miembro> tempMembers = new List<Miembro>();
                foreach (Miembro m in members)
                {
                    if (m.nombre.Contains(value)
                        || m.paterno.Contains(value)
                        || m.materno.Contains(value)
                        || m.fechaNacimiento.ToString().Contains(value)
                        || m.sexo.Contains(value)
                        || m.Escolaridad.ToString().Contains(value)
                        || m.Religion.ToString().Contains(value)
                        || m.observación.Contains(value)
                        || m.ocupación.Contains(value)
                        || m.movil.Contains(value)
                        || m.oficina.Contains(value)
                        || m.particular.Contains(value)
                        || m.email.Contains(value)
                        || m.Seccione.ToString().Contains(value)
                        || m.Grupos.ToString().Contains(value)
                        || m.Domicilio.ToString().Contains(value))
                    {
                        tempMembers.Add(m);
                    }
                }
                dgvMembers.DataSource = tempMembers;
            }
            else
            {
                loadTable();
            }
        }

        private void cleanForm()
        {
            FormUtils.clearTextbox(textControls());
            rdbFemale.Checked = true;
            rdbMale.Checked = false;
            rdbAssociated.Checked = true;
            rdbNoAssociated.Checked = false;
            chbStatus.Checked = true;
            chbStatusHome.Checked = true;
            lblCum.Text = "Por asignar";
            dtpBirthday.Value = DateTime.Today;
            loadCmbs();
            pcbPhoto.Image = pcbPhoto.InitialImage;
            btnSaveModify.Text = "Guardar";
            selectedMember = null;
            searchedDomicile = null;

            lblDomicileDuplicity.Text = "La dirección de este miembro ya está en el sistema (Otro miembro ya registrado vive con él/ella)";
            chbDuplicity.Checked = false;

            frmMemberPosition.Instance.clean();
        }

        private void cleanDomiciles()
        {
            FormUtils.clearTextbox(domicileControls());
            chbStatusHome.Checked = true;
            loadDomicileCmbs();
        }

        private void saveMember(Domicilio domicile)
        {
            Operation<Miembro> operation = memberController.getLastRecord();
            if (operation.State)
            {
                Miembro lastMem = (Miembro)operation.Value;
                string cum;
                if (lastMem == null)
                {
                    cum = "000001";
                }
                else
                {
                    cum = (Convert.ToInt32(lastMem.cum) + 1).ToString("000000");
                }

                string fileName = imagePath + cum + ".png";

                System.IO.File.Copy(pcbPhoto.ImageLocation, fileName, true);

                Miembro tempMem = new Miembro
                {
                    cum = cum,
                    nombre = txtName.Text.Trim(),
                    paterno = txtPaternal.Text.Trim(),
                    materno = txtMaternal.Text.Trim(),
                    baja = chbStatus.Checked,
                    idSeccion = ((Seccione)cmbSection.SelectedValue).idSeccion,
                    idGrupo = ((Grupos)cmbGroup.SelectedValue).idGrupo,
                    fotoFileName = fileName,
                    fechaNacimiento = dtpBirthday.Value,
                    sexo = rdbMale.Checked ? "m" : "f",
                    particular = txtParticular.Text.Trim(),
                    oficina = txtOffice.Text.Trim(),
                    movil = txtMobile.Text.Trim(),
                    email = txtEmail.Text.Trim(),
                    ocupación = txtOcupation.Text.Trim(),
                    observación = txtObservation.Text.Trim(),
                    idDomicilio = domicile.idDomicilio,
                    idReligion = ((Religion)cmbReligion.SelectedValue).idReligion,
                    idEscolaridad = ((Escolaridad)cmbScholarship.SelectedValue).idEscolaridad,
                    idEstadoCivil = ((EstadoCivil)cmbCivilStatus.SelectedValue).idEstadoCivil
                };

                operation = memberController.addRecord(tempMem);
                if (operation.State)
                {
                    loadTable();
                    cleanForm();

                    MessageBox.Show("Miembro registrado con éxito",
                    "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error inesperado al registrar el miembro: " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al calcular el CUM: " + operation.Error,
                "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveData()
        {
            if (chbDuplicity.Checked)
            {
                saveMember(searchedDomicile);
            }
            else
            {
                Domicilio tempDom = new Domicilio
                {
                    calleNumero = txtStreetNo.Text.Trim(),
                    colonia = txtColony.Text.Trim(),
                    codigoPostal = txtPostalCode.Text.Trim(),
                    baja = chbStatusHome.Checked,
                    idMunicipio = ((Municipio)cmbMunicipality.SelectedValue).idMunicipio,
                    entreCalles = txtStreet.Text.Trim(),
                    referencia = txtReference.Text.Trim(),
                    contacto = txtContact.Text.Trim(),
                    telefono = txtPhone.Text.Trim()
                };
                Operation<Domicilio> operation = domicileController.addRecord(tempDom);
                if (operation.State)
                {
                    operation = domicileController.getLastRecord();
                    if (operation.State)
                    {
                        saveMember((Domicilio)operation.Value);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error inesperado al procesar el domicilio recién ingresado: " + operation.Error,
                        "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error inesperado al registrar el domicilio: " + operation.Error,
                        "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void updateMember()
        {
            try
            {
                System.IO.File.Copy(pcbPhoto.ImageLocation, selectedMember.fotoFileName, true);
            }
            catch
            {
                //The profile photo hasn't been changed, do nothing
            }

            selectedMember.nombre = txtName.Text.Trim();
            selectedMember.paterno = txtPaternal.Text.Trim();
            selectedMember.materno = txtMaternal.Text.Trim();
            selectedMember.baja = chbStatus.Checked;
            selectedMember.idSeccion = ((Seccione)cmbSection.SelectedValue).idSeccion;
            selectedMember.idGrupo = ((Grupos)cmbGroup.SelectedValue).idGrupo;
            selectedMember.fechaNacimiento = dtpBirthday.Value;
            selectedMember.sexo = rdbMale.Checked ? "m" : "f";
            selectedMember.particular = txtParticular.Text.Trim();
            selectedMember.oficina = txtOffice.Text.Trim();
            selectedMember.movil = txtMobile.Text.Trim();
            selectedMember.email = txtEmail.Text.Trim();
            selectedMember.ocupación = txtOcupation.Text.Trim();
            selectedMember.observación = txtObservation.Text.Trim();
            selectedMember.idReligion = ((Religion)cmbReligion.SelectedValue).idReligion;
            selectedMember.idEscolaridad = ((Escolaridad)cmbScholarship.SelectedValue).idEscolaridad;
            selectedMember.idEstadoCivil = ((EstadoCivil)cmbCivilStatus.SelectedValue).idEstadoCivil;


            Operation<Miembro> operation = memberController.updateRecord(selectedMember);
            if (operation.State)
            {

                loadTable();
                cleanForm();

                MessageBox.Show("Miembro modificado con éxito",
                "OPERACIÓN EXITOSA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ocurrió un error inesperado al modificar el miembro: " + operation.Error,
                "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateData()
        {

            if (chbDuplicity.Checked)
            {
                if (MessageBox.Show("Al realizar esta operación, se creará un nuevo registro " +
                    "de domicilio para el miembro a modificar, y todos los demás miembros registrados con" +
                    "el domicilio anterior (si los hay) se mantendran en el mismo. ¿Desea continuar?",
                    "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    Domicilio tempDom = new Domicilio
                    {
                        calleNumero = txtStreetNo.Text.Trim(),
                        colonia = txtColony.Text.Trim(),
                        codigoPostal = txtPostalCode.Text.Trim(),
                        baja = chbStatusHome.Checked,
                        idMunicipio = ((Municipio)cmbMunicipality.SelectedValue).idMunicipio,
                        entreCalles = txtStreet.Text.Trim(),
                        referencia = txtReference.Text.Trim(),
                        contacto = txtContact.Text.Trim(),
                        telefono = txtPhone.Text.Trim()
                    };
                    Operation<Domicilio> operation = domicileController.addRecord(tempDom);
                    if (operation.State)
                    {
                        operation = domicileController.getLastRecord();
                        if (operation.State)
                        {
                            selectedMember.Domicilio = (Domicilio)operation.Value;
                            updateMember();
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error inesperado al procesar el domicilio recién ingresado: " + operation.Error,
                            "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error inesperado al registrar el domicilio: " + operation.Error,
                            "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            else
            {
                if (MessageBox.Show("Al realizar esta operación, se cambiarán los datos de domicilio para todos" +
                    " los miembros que estén registrados en el mismo (si los hay) ¿Desea continuar?",
                    "CONFIRMACIÓN", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    selectedMember.Domicilio.calleNumero = txtStreetNo.Text.Trim();
                    selectedMember.Domicilio.colonia = txtColony.Text.Trim();
                    selectedMember.Domicilio.codigoPostal = txtPostalCode.Text.Trim();
                    selectedMember.Domicilio.baja = chbStatusHome.Checked;
                    selectedMember.Domicilio.idMunicipio = ((Municipio)cmbMunicipality.SelectedValue).idMunicipio;
                    selectedMember.Domicilio.entreCalles = txtStreet.Text.Trim();
                    selectedMember.Domicilio.referencia = txtReference.Text.Trim();
                    selectedMember.Domicilio.contacto = txtContact.Text.Trim();
                    selectedMember.Domicilio.telefono = txtPhone.Text.Trim();

                    updateMember();
                }
            }


            

            
                    
        }


        private void refreshSections()
        {
            try
            {
                loadSections();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }


        private void FrmMembers_Load(object sender, EventArgs e)
        {
            //lblDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(127, 41, 181);
            try {
                loadCmbs();
                loadTable();
                loadPositions();
                /*pnlButtons.BackColor = System.Drawing.Color.Transparent;
                pnlButtons.BringToFront();*/

                //Not the ideal practice, but I don't want to waste time researching 
                //how to change initialImage in design mode right now
                pcbPhoto.InitialImage = pcbPhoto.Image;
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            if (!pnlFormMembers.Controls.Contains(frmMemberPosition.Instance))
            {
                pnlFormMembers.Controls.Add(frmMemberPosition.Instance);
                frmMemberPosition.Instance.Dock = DockStyle.Fill;
                frmMemberPosition.Instance.BringToFront();
            }
            else
            {
                frmPosition.Instance.BringToFront();
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            /*lblDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(127,41,181);
            lblPosition.ForeColor = System.Drawing.Color.FromArgb(110, 117, 125);*/
            if (this.pnlFormMembers.Controls.Count > 0)
            {
                this.pnlFormMembers.Controls.RemoveAt(0);
            }
            tabControlMember.Show();
        }

        private void Label4_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void Label5_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        /*private void btnSaveModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.errorProvider.Clear();
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                bool hasLastName = FormValidators.oneHasText(new Control[] { txtPaternal, txtMaternal });
                if (isValid && hasLastName)
                {
                    if (selectedMember == null)
                    {
                        saveData();
                    }
                    else
                    {
                        updateData();
                    }
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (!hasLastName)
                    {
                        errorProvider.Add(new ControlErrorProvider("Debe proporcionarse al menos un apellido, ya sea paterno o materno", txtPaternal));
                    }
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
        }*/

       /* private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                loadMunicipalities();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }*/

        /*private void rdbMale_Click(object sender, EventArgs e)
        {
            try {  
                loadSections();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void rdbFemale_Click(object sender, EventArgs e)
        {
            try { 
                loadSections();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void dtpBirthday_onValueChanged(object sender, EventArgs e)
        {
            try { 
                loadSections();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }*/

        /*private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void dgvMembers_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }*/

        /*private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedMember = members[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedMember);

                    lblDomicileDuplicity.Text = "Este miembro ha cambiado de domicilio, pero los demás miembros que comparten el domicilio no";
                    chbDuplicity.Checked = false;
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }*/

        /*private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }

        private void bunifuCustomLabel37_Click(object sender, EventArgs e)
        {

        }*/

        /*private void bunifuToggleSwitch1_OnValuechange(object sender, EventArgs e)
        {
            try { 
                //'Save' mode
                if (selectedMember == null)
                {
                    if (chbDuplicity.Checked)
                    {
                        string partnerCum = "";
                        if (FormUtils.InputBox("Buscar domicilio", "Ingrese el CUM de la persona con la que comparte domicilio:", ref partnerCum) == DialogResult.OK)
                        {
                            Operation<Miembro> getMemberOperation = memberController.getRecordbyCum(partnerCum);
                            if (getMemberOperation.State && getMemberOperation.Value != null)
                            {
                                searchedDomicile = ((Miembro)getMemberOperation.Value).Domicilio;

                                txtStreetNo.Text = searchedDomicile.calleNumero;
                                txtStreet.Text = searchedDomicile.entreCalles;
                                txtColony.Text = searchedDomicile.colonia;
                                txtReference.Text = searchedDomicile.referencia;
                                txtPostalCode.Text = searchedDomicile.codigoPostal;
                                txtContact.Text = searchedDomicile.contacto;
                                txtPhone.Text = searchedDomicile.telefono;
                                chbStatus.Checked = searchedDomicile.baja;
                                cmbDepartment.SelectedItem = searchedDomicile.Municipio.Departamento;
                                cmbMunicipality.SelectedItem = searchedDomicile.Municipio;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún miembro con el CUM proporcionado.", "MIEMBRO NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                chbDuplicity.Checked = false;
                                searchedDomicile = null;
                            }
                        }
                        else
                        {
                            chbDuplicity.Checked = false;
                            searchedDomicile = null;
                        }
                    }
                    else
                    {
                        cleanDomiciles();
                        searchedDomicile = null;
                    }
                }
                //'Update' mode
                else
                {
                    if (chbDuplicity.Checked)
                    {
                        cleanDomiciles();
                    }
                    else
                    {
                        txtStreetNo.Text = selectedMember.Domicilio.calleNumero;
                        txtStreet.Text = selectedMember.Domicilio.entreCalles;
                        txtColony.Text = selectedMember.Domicilio.colonia;
                        txtReference.Text = selectedMember.Domicilio.referencia;
                        txtPostalCode.Text = selectedMember.Domicilio.codigoPostal;
                        txtContact.Text = selectedMember.Domicilio.contacto;
                        txtPhone.Text = selectedMember.Domicilio.telefono;
                        chbStatusHome.Checked = selectedMember.Domicilio.baja;
                        cmbDepartment.SelectedItem = selectedMember.Domicilio.Municipio.Departamento;
                        cmbMunicipality.SelectedItem = selectedMember.Domicilio.Municipio;
                    }
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }*/

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Choose Image(*.jpg;*.png;)|*.jpg;*.png;";

                if (opf.ShowDialog() == DialogResult.OK)
                {
                    pcbPhoto.ImageLocation = opf.FileName;
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
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                bool hasLastName = FormValidators.oneHasText(new Control[] { txtPaternal, txtMaternal });
                if (isValid && hasLastName)
                {
                    if (selectedMember == null)
                    {
                        saveData();
                    }
                    else
                    {
                        updateData();
                    }
                }
                else
                {
                    MessageBox.Show("Algunos datos proporcionados son inválidos. Pase el puntero sobre los íconos de error para ver los detalles de cada campo.", "ERROR DE VALIDACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (!hasLastName)
                    {
                        errorProvider.Add(new ControlErrorProvider("Debe proporcionarse al menos un apellido, ya sea paterno o materno", txtPaternal));
                    }
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

        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                loadMunicipalities();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void rdbMale_Click(object sender, EventArgs e)
        {
            refreshSections();
        }

        private void rdbFemale_Click(object sender, EventArgs e)
        {
            refreshSections();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            refreshSections();
        }

        private void btnNewClean_Click(object sender, EventArgs e)
        {
            cleanForm();
        }

        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    selectedMember = members[index];
                    btnSaveModify.Text = "Modificar";
                    fillSelectedData(selectedMember);

                    lblDomicileDuplicity.Text = "Este miembro ha cambiado de domicilio, pero los demás miembros que comparten el domicilio no";
                    chbDuplicity.Checked = false;

                    frmMemberPosition.Instance.SelectedMember = selectedMember;
                }
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }

        private void chbDuplicity_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //'Save' mode
                if (selectedMember == null)
                {
                    if (chbDuplicity.Checked)
                    {
                        string partnerCum = "";
                        if (FormUtils.InputBox("Buscar domicilio", "Ingrese el CUM de la persona con la que comparte domicilio:", ref partnerCum) == DialogResult.OK)
                        {
                            Operation<Miembro> getMemberOperation = memberController.getRecordbyCum(partnerCum);
                            if (getMemberOperation.State && getMemberOperation.Value != null)
                            {
                                searchedDomicile = ((Miembro)getMemberOperation.Value).Domicilio;

                                txtStreetNo.Text = searchedDomicile.calleNumero;
                                txtStreet.Text = searchedDomicile.entreCalles;
                                txtColony.Text = searchedDomicile.colonia;
                                txtReference.Text = searchedDomicile.referencia;
                                txtPostalCode.Text = searchedDomicile.codigoPostal;
                                txtContact.Text = searchedDomicile.contacto;
                                txtPhone.Text = searchedDomicile.telefono;
                                chbStatus.Checked = searchedDomicile.baja;
                                cmbDepartment.SelectedItem = searchedDomicile.Municipio.Departamento;
                                cmbMunicipality.SelectedItem = searchedDomicile.Municipio;
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún miembro con el CUM proporcionado.", "MIEMBRO NO ENCONTRADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                chbDuplicity.Checked = false;
                                searchedDomicile = null;
                            }
                        }
                        else
                        {
                            chbDuplicity.Checked = false;
                            searchedDomicile = null;
                        }
                    }
                    else
                    {
                        cleanDomiciles();
                        searchedDomicile = null;
                    }
                }
                //'Update' mode
                else
                {
                    if (chbDuplicity.Checked)
                    {
                        cleanDomiciles();
                    }
                    else
                    {
                        txtStreetNo.Text = selectedMember.Domicilio.calleNumero;
                        txtStreet.Text = selectedMember.Domicilio.entreCalles;
                        txtColony.Text = selectedMember.Domicilio.colonia;
                        txtReference.Text = selectedMember.Domicilio.referencia;
                        txtPostalCode.Text = selectedMember.Domicilio.codigoPostal;
                        txtContact.Text = selectedMember.Domicilio.contacto;
                        txtPhone.Text = selectedMember.Domicilio.telefono;
                        chbStatusHome.Checked = selectedMember.Domicilio.baja;
                        cmbDepartment.SelectedItem = selectedMember.Domicilio.Municipio.Departamento;
                        cmbMunicipality.SelectedItem = selectedMember.Domicilio.Municipio;
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
