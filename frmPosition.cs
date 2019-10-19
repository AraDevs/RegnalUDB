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
    public partial class frmPosition : UserControl
    {
        private static frmPosition _instance;
        public static frmPosition Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new frmPosition();
                }
                return _instance;
            }
        }
        public frmPosition()
        {
            InitializeComponent();
        }
    }
}
