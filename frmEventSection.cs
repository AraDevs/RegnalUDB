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
    public partial class frmEventSection : UserControl
    {
        private Evento selectedEvent = null;
        public Evento SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

        private static frmEventSection _instance;
        public static frmEventSection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmEventSection();
                }
                return _instance;
            }
        }

        EventSectionController esController = new EventSectionController();

        public frmEventSection()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblEventSection.Text = "Ninguno";
            selectedEvent = null;
            lstSection.SelectedItems.Clear();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try { 
                if (selectedEvent == null)
                {
                    MessageBox.Show("Por favor seleccione un evento.", "EVENTO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                List<Seccione> originalList = selectedEvent.EventoSeccions.Select(x => x.Seccione).ToList();
                List<Seccione> newList = new List<Seccione>();

                foreach (Seccione sec in lstSection.SelectedItems)
                {
                    newList.Add(sec);
                }


                List<Seccione> toAdd = newList.Except(originalList).ToList();
                List<Seccione> toDelete = originalList.Except(newList).ToList();

                foreach (Seccione sec in toAdd)
                {
                    EventoSeccion tempEs = new EventoSeccion
                    {
                        idEvento = selectedEvent.idEvento,
                        idSeccion = sec.idSeccion
                    };

                    Operation<EventoSeccion> operation = esController.addRecord(tempEs);

                    if (!operation.State)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al asociar al evento a la sección '" + sec.Nombre + "': " + operation.Error,
                        "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

                foreach (Seccione sec in toDelete)
                {
                    EventoSeccion tempEs = selectedEvent.EventoSeccions.Where(x => x.Seccione == sec).FirstOrDefault();

                    Operation<EventoSeccion> operation = esController.deleteRecord(tempEs);

                    if (!operation.State)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al desasociar al evento de la sección '" + sec.Nombre + "': " + operation.Error,
                        "ERROR AL ELIMINAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                MessageBox.Show("Los cambios fueron aplicados con éxito.",
                        "SECCIONES ASOCIADAS", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clean();
            }
            catch (Exception ex)
            {
                FormUtils.defaultErrorMessage(ex);
            }
        }
    }
}
