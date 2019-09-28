using System;
using System.Windows.Forms;
using RegnalUDB.Entity_Framework;
using RegnalUDB.Controllers;
using RegnalUDB.Models;

namespace RegnalUDB
{
    public partial class Form1 : Form
    {
        //declaramos variable  de controlador

        SchoolarshipController sc;
        public Form1()
        {
            InitializeComponent();

            sc = new SchoolarshipController();
        }

        private void obtenerEscolaridades()
        {
            dgvData.DataSource = null;
            if(sc.getRecords().Error != null)
            {
                MessageBox.Show("Ocurrio un error " + sc.getRecords().Error);
            }
            else
            {
                dgvData.DataSource = sc.getRecords().Data;
                dgvData.Columns[0].Visible = false;
                dgvData.Columns[3].Visible = false;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerEscolaridades();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Escolaridad tempEs = new Escolaridad();
            tempEs.grado = txtGrade.Text;
            tempEs.baja = checkBox1.Checked;
            Operation<Escolaridad> operation = sc.addRecord(tempEs);
            if (operation.State)
            {
                obtenerEscolaridades();
            }
            else
            {
                MessageBox.Show(operation.Error);
            }
        }
    }
}
