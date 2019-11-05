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
using RegnalUDB.Controllers;
using RegnalUDB.Models;
using RegnalUDB.Utils;

namespace RegnalUDB
{
    public partial class frmEventPosition : UserControl
    {
        private Evento selectedEvent = null;
        public Evento SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

        private static frmEventPosition _instance;
        public static frmEventPosition Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmEventPosition();
                }
                return _instance;
            }
        }

        EventPositionController ecController = new EventPositionController();

        public frmEventPosition()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblEventPosition.Text = "Ninguno";
            selectedEvent = null;
            lstPosition.SelectedItems.Clear();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try { 
                if (selectedEvent == null)
                {
                    MessageBox.Show("Por favor seleccione un evento.", "EVENTO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                List<Cargo> originalList = selectedEvent.EventoCargoes.Select(x => x.Cargo).ToList();
                List<Cargo> newList = new List<Cargo>();

                foreach (Cargo pos in lstPosition.SelectedItems)
                {
                    newList.Add(pos);
                }


                List<Cargo> toAdd = newList.Except(originalList).ToList();
                List<Cargo> toDelete = originalList.Except(newList).ToList();

                foreach (Cargo pos in toAdd)
                {
                    EventoCargo tempEc = new EventoCargo
                    {
                        idEvento = selectedEvent.idEvento,
                        idCargo = pos.idCargo
                    };

                    Operation<EventoCargo> operation = ecController.addRecord(tempEc);

                    if (!operation.State)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al asociar al evento al cargo '" + pos.nombre + "': " + operation.Error,
                        "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                }

                foreach (Cargo pos in toDelete)
                {
                    EventoCargo tempEc = selectedEvent.EventoCargoes.Where(x => x.Cargo == pos).FirstOrDefault();

                    Operation<EventoCargo> operation = ecController.deleteRecord(tempEc);

                    if (!operation.State)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al desasociar al evento del cargo '" + pos.nombre + "': " + operation.Error,
                        "ERROR AL ELIMINAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                MessageBox.Show("Los cambios fueron aplicados con éxito.",
                        "CARGOS ASOCIADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clean();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }

        private void lstPosition_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblEventPosition_Click(object sender, EventArgs e)
        {

        }

        private void autoLabel18_Click(object sender, EventArgs e)
        {

        }
    }
}
