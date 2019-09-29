using RegnalUDB.Controllers;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Models;
using RegnalUDB.Utils;
using static RegnalUDB.Utils.FormValidators;

namespace RegnalUDB
{
    public partial class GroupTest : Form
    {
        private GroupController groupController = new GroupController();

        private List<Distrito> districts = new List<Distrito>();
        private List<Localidade> localities = new List<Localidade>();
        private List<Grupos> groups = new List<Grupos>();

        private Grupos selectedGroup = null;

        // data for custom DataGridView
        private int[] columnsToHideForGroups = { 6, 7, 12, 13 };
        private int[] columnsToChangeForGroups = { 0, 1, 2, 3, 4, 5, 8, 9, 10, 11 };
        private string[] titlesforGroups = { "ID", "Nombre", "Fecha fundación","Numero de grupo", "Horario",
              "Baja", "Fecha registro", "Registro", "Distrito", "Localidad"  };

        public GroupTest()
        {
            InitializeComponent();

            DistricController districController = new DistricController();
            LocalityController localityController = new LocalityController();

            Operation<Distrito> getDistrictOperation = districController.getRecords();
            Operation<Localidade> getLocalitiesOperation = localityController.getRecords();
            bool dataIsRetrieved = getLocalitiesOperation.State && getDistrictOperation.State;

            if (dataIsRetrieved)
            {
                // set data
                districts = getDistrictOperation.Data;
                localities = getLocalitiesOperation.Data;
                // load data
                comboBox1.DataSource = districts;
                comboBox2.DataSource = localities;
                loadTable();

                comboBox1.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show(getDistrictOperation.Error);
            }

        }

        private void GroupTest_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string errorMessage = FormValidators.validForm(getValidators());
            bool isValid = errorMessage == null;
            if (isValid)
            {
                MessageBox.Show("Save value");
            }else{
                MessageBox.Show(errorMessage);
            }
        }

        private void loadTable()
        {
            Operation<Grupos> getGroupsOperation = groupController.getRecords();
            if (getGroupsOperation.State)
            {
                groups = getGroupsOperation.Data;
                dataGridView1.DataSource = groups;
                FormUtils.hideColumnsForDgv(columnsToHideForGroups, dataGridView1);
                FormUtils.changeTitlesForDgv(titlesforGroups, columnsToChangeForGroups, dataGridView1);
                return;
            }
            MessageBox.Show("Error al cargas datos de grupos");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                selectedGroup = groups[index];
                comboBox1.SelectedItem = selectedGroup.Distrito;
                comboBox2.SelectedItem = selectedGroup.Localidade;
            }
        }

        private ToValidate[] getValidators()
        {
            ToValidate[] validators =  {
                 new ToValidate(comboBox1, new ControlValidator[] { FormValidators.isSelected },
                 new string[] { "Selecciona un distrito" }),
                new ToValidate(textBox1, new ControlValidator[] { FormValidators.IsNumber },
                 new string[] { "El valor ingresado en registro debe ser un numero" })
            };
            return validators;
        }

        

    }
}
