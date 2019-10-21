using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegnalUDB
{
    public partial class frmPositionAAA : UserControl
    {
        private static frmPositionAAA _instance;
        public static frmPositionAAA Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmPositionAAA();
                }
                return _instance;
            }
        }
        public frmPositionAAA()
        {
            InitializeComponent();
        }

        private void btnSaveModify_Click(object sender, EventArgs e)
        {

        }
    }
}
