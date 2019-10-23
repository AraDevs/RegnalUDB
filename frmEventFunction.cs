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

namespace RegnalUDB
{
    public partial class frmEventFunction : UserControl
    {
        private Evento selectedEvent = null;
        public Evento SelectedEvent { get => selectedEvent; set => selectedEvent = value; }

        private static frmEventFunction _instance;
        public static frmEventFunction Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmEventFunction();
                }
                return _instance;
            }
        }

        EventFunctionController efController = new EventFunctionController();

        public frmEventFunction()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblEventPosition.Text = "Ninguno";
            selectedEvent = null;
            lstFunction.SelectedItems.Clear();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (selectedEvent == null)
            {
                MessageBox.Show("Por favor seleccione un evento.", "EVENTO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            List<Funcione> originalList = selectedEvent.EventosFunciones.Select(x => x.Funcione).ToList();
            List<Funcione> newList = new List<Funcione>();

            foreach (Funcione pos in lstFunction.SelectedItems)
            {
                newList.Add(pos);
            }


            List<Funcione> toAdd = newList.Except(originalList).ToList();
            List<Funcione> toDelete = originalList.Except(newList).ToList();

            foreach (Funcione fun in toAdd)
            {
                EventosFuncione tempEf = new EventosFuncione
                {
                    idEvento = selectedEvent.idEvento,
                    idFuncion = fun.idFuncion
                };

                Operation<EventosFuncione> operation = efController.addRecord(tempEf);

                if (!operation.State)
                {
                    MessageBox.Show("Ocurrió un error inesperado al asociar al evento a la función '" + fun.nombre + "': " + operation.Error,
                    "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            foreach (Funcione fun in toDelete)
            {
                EventosFuncione tempEf = selectedEvent.EventosFunciones.Where(x => x.Funcione == fun).FirstOrDefault();

                Operation<EventosFuncione> operation = efController.deleteRecord(tempEf);

                if (!operation.State)
                {
                    MessageBox.Show("Ocurrió un error inesperado al desasociar al evento de la función '" + fun.nombre + "': " + operation.Error,
                    "ERROR AL ELIMINAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            MessageBox.Show("Los cambios fueron aplicados con éxito.",
                    "CARGOS ASOCIADOS", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clean();
        }
    }
}
