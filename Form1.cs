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
            dgvData.DataSource = sc.getRecords().Data;
            dgvData.Columns[0].Visible = false;
            dgvData.Columns[3].Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obtenerEscolaridades();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Escolaridad tempEs = new Escolaridad();
            tempEs.grado = txtGrade.Text;
            byte baja = Convert.ToByte(checkBox1.Checked ? 1 : 0);
            tempEs.baja = baja;
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
