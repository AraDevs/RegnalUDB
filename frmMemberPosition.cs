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
    public partial class frmMemberPosition : UserControl
    {

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
        public frmMemberPosition()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
