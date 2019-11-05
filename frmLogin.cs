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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class frmLogin : Form
    {
        UserController userController = new UserController();

        public frmLogin()
        {
            Thread thread = new Thread(new ThreadStart(StartForm));
            thread.Start();
            Thread.Sleep(1000);
            InitializeComponent();
            thread.Abort();
        }

        public void StartForm()
        {
                Application.Run(new frmScreenSplash());
            
        }



        private void pcbCloseWindow_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(txtUser, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa un nombre" }),
                 new ToValidate(txtPassword, new ControlValidator[] { FormValidators.hasText },
                 new string[] { "Ingresa una contraseña" })
            };
            return validators;
        }
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                List<ControlErrorProvider> errorProvider = FormValidators.validFormTest(getValidators());
                bool isValid = errorProvider == null;
                if (isValid)
                {
                    Usuario currentUser = (Usuario)userController.login(txtUser.Text, txtPassword.Text).Value;
                    //MessageBox.Show(userController.login(txtUser.Text, txtPassword.Text).Error);
                    if (currentUser != null)
                    {
                        new frmDashboard(currentUser).Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas");
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
    }
}
