using RegnalUDB.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;

namespace RegnalUDB
{
    public partial class GroupTest : Form
    {
        private List<Distrito> districts = new DistricController().getRecords().Data;
        private List<Localidade> localities = new LocalityController().getRecords().Data;
        public GroupTest()
        {
            InitializeComponent();

            // load data
            DistricController districController = new DistricController();
            LocalityController localityController = new LocalityController();

            Operation<Distrito> getDistrictOperation = districController.getRecords();
            Operation<Localidade> getLocalitiesOperation = localityController.getRecords();
            bool dataIsRetrieved = getLocalitiesOperation.State && getDistrictOperation.State;

            if (dataIsRetrieved)
            {
                this.districts = getDistrictOperation.Data;
                this.localities = getLocalitiesOperation.Data;

                // load data
                FormUtils.loadCmbData<Distrito>(this.districts, comboBox1, "nombre", "idDistrito");
                FormUtils.loadCmbData<Localidade>(this.localities, comboBox2, "nombre", "idLocalidad");

            }
            else
            {
                MessageBox.Show("Error al cargor los datos del formulario");
            }
                
    }

        private void GroupTest_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(((CmbItem)comboBox1.SelectedItem).Value);
        }
    }
}
