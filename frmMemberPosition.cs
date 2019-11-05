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
    public partial class frmMemberPosition : UserControl
    {
        private Miembro selectedMember = null;
        public Miembro SelectedMember { get => selectedMember; set => selectedMember = value; }

        private static frmMemberPosition _instance;
        public static frmMemberPosition Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmMemberPosition();
                }
                return _instance;
            }
        }


        MemberPositionController mcController = new MemberPositionController();

        public frmMemberPosition()
        {
            InitializeComponent();
        }

        public void clean()
        {
            lblMember.Text = "Ninguno";
            selectedMember = null;
            lstPosition.SelectedItems.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try { 
                if (selectedMember == null)
                {
                    MessageBox.Show("Por favor seleccione un miembro.", "MIEMBRO NO SELECCIONADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                List<Cargo> originalList = SelectedMember.MiembroCargoes.Select(x => x.Cargo).ToList();
                List<Cargo> newList = new List<Cargo>();

                foreach(Cargo pos in lstPosition.SelectedItems)
                {
                    newList.Add(pos);
                }


                List<Cargo> toAdd = newList.Except(originalList).ToList();
                List<Cargo> toDelete = originalList.Except(newList).ToList();

                foreach (Cargo pos in toAdd)
                {
                    if (pos.MiembroCargoes.Count >= pos.total)
                    {
                        MessageBox.Show("No se pudo asociar al miembro al cargo '" + pos.nombre + "', porque dicho cargo ya ha alcanzado su máximo de miembros asociados.",
                        "MÁXIMO DE CARGO ALCANZADO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {
                        MiembroCargo tempMc = new MiembroCargo
                        {
                            idMembro = SelectedMember.idMiembro,
                            idCargo = pos.idCargo,
                            fecha = System.DateTime.Today
                        };

                        Operation<MiembroCargo> operation = mcController.addRecord(tempMc);

                        if (!operation.State)
                        {
                            MessageBox.Show("Ocurrió un error inesperado al asociar al miembro al cargo '" + pos.nombre + "': " + operation.Error,
                            "ERROR AL INGRESAR DATOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                foreach (Cargo pos in toDelete)
                {
                    MiembroCargo tempMc = SelectedMember.MiembroCargoes.Where(x => x.Cargo == pos).FirstOrDefault();

                    Operation<MiembroCargo> operation = mcController.deleteRecord(tempMc);

                    if (!operation.State)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al desasociar al miembro del cargo '" + pos.nombre + "': " + operation.Error,
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

        private void lblMember_Click(object sender, EventArgs e)
        {

        }

        private void autoLabel18_Click(object sender, EventArgs e)
        {

        }
    }
}
