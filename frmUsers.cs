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
    public partial class frmUsers : Form
    {
        private static UserController userController = new UserController();
        private static ProfileController profileController = new ProfileController();
        private static MemberController memberController = new MemberController();
        private List<Usuario> users = new List<Usuario>();
        private List<Perfile> perfiles = new List<Perfile>();

        private Usuario selectedUser = null;

        // data for custom DataGridView
        private int[] columnsToChange = { 0, 3,4, 5 };
        private int[] columnsToHide = { 1,2, };
        private string[] titlesforColumns = { "ID", "Activo", "Miembro","Perfil" };
        public frmUsers()
        {
            InitializeComponent();
        }
        private void loadCmb()
        {
            Operation<Perfile> getProfileOperation = profileController.getActiveRecords();
            if (getProfileOperation.State)
            {
                perfiles = getProfileOperation.Data;
                cmbProfile.DataSource = perfiles;
            }
            else
            {
                MessageBox.Show("Error al cargar la lista de perfiles. Por favor reinicie el módulo.", "Error al obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillSelectedData(Usuario currentUser)
        {
            /*
            txt.Text = currentPerfile.nombre;
            */
            txtCUM.Text = currentUser.Miembro.cum;
            txtCUM.Enabled = false;
            cmbProfile.SelectedItem = currentUser.Perfile;
            chbStatus.Checked = currentUser.baja;
        }

        private void loadTable()
        {
            Operation<Usuario> getUserOperation = userController.getRecords();
            if (getUserOperation.State)
            {
                users = getUserOperation.Data;
                dgvUsers.DataSource = users;

                FormUtils.changeTitlesForDgv(titlesforColumns, columnsToChange, dgvUsers);
                FormUtils.hideColumnsForDgv(columnsToHide, dgvUsers);
                return;
            }
            MessageBox.Show("Error al cargas datos de usuarios");
        }

        private void saveData(Miembro miembro)
        {
            if(miembro == null)
            {
                MessageBox.Show("El miembro especificado no fue encontrado");
                txtCUM.Focus();
                return;
            }
            Usuario tempUser = new Usuario
            {
                idPerfil = ((Perfile)cmbProfile.SelectedItem).idPerfil,
                idMiembro = miembro.idMiembro,
                pass = EncriptionUtils.MD5Hash(txtPassword.Text),
                baja = chbStatus.Checked
            };
            Operation<Usuario> operation = userController.addRecord(tempUser);
            if (operation.State)
            {
                MessageBox.Show("Usuario agregado con exito");
                loadTable();
                cleanForm();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }

        private void updateData(Usuario currentSection)
        {
            Operation<Usuario> operation = userController.updateRecord(currentSection);
            if (operation.State)
            {
                MessageBox.Show("Usuario actualizado con exito");
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
                List<Usuario> tempProfile = new List<Usuario>();
                foreach (Usuario r in users)
                {
                    if (r.Perfile.nombre.Contains(value))
                    {
                        tempProfile.Add(r);
                    }
                }
                dgvUsers.DataSource = tempProfile;
            }
            else
            {
                loadTable();
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtCUM, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa un nombre" })
            };
            return validators;
        }

        private void cleanForm()
        {
            selectedUser = null;
            txtCUM.Enabled = true;
            FormUtils.clearTextbox(textControls());
            btnSaveModify.Text = "Guardar";
            chbStatus.Checked = true;
        }

        private Control[] textControls()
        {
            Control[] controls = { txtCUM, txtPassword,txtConfirmPassword };
            return controls;
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            loadTable();
            loadCmb();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {
            List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
            bool isValid = errorProvider == null;
            if (isValid)
            {
                if (selectedUser == null)
                {
                    Miembro member =(Miembro)memberController.getRecordbyCum(txtCUM.Text).Value;
                    if(member != null & txtPassword.Text.Trim() != "" )
                    {
                        if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                        {
                            saveData(member);
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas ingresadas no coinciden");
                            txtConfirmPassword.Clear();
                            txtConfirmPassword.Focus();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show(member==null?"El miembro con el cum ingresado no se encontro":"Ingrese una clave para el usuario");
                        txtPassword.Focus();
                    }
                    
                }
                else
                {
                    selectedUser.Perfile = (Perfile)cmbProfile.SelectedItem;
                    selectedUser.baja = chbStatus.Checked;
                    if(txtPassword.Text.Trim() != "")
                    {
                        if (txtPassword.Text.Equals(txtConfirmPassword.Text))
                        {
                            selectedUser.pass = EncriptionUtils.MD5Hash(txtPassword.Text);
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas ingresadas no coinciden");
                            txtConfirmPassword.Clear();
                            txtConfirmPassword.Focus();
                        }
                    }
                    updateData(selectedUser);
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

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedUser = users[index];
                if(selectedUser.Perfile.idPerfil == 1 && selectedUser.Miembro.nombre=="root")
                {
                    MessageBox.Show("El administrador principal no puede ser modificado");
                    return;
                }
                btnSaveModify.Text = "Modificar";
                fillSelectedData(selectedUser);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            filterData();
        }
    }
}
