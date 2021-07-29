using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOI_Inventory_System
{
    public partial class frmGetIARNo : Form
    {
        public frmGetIARNo()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalIARNo = txtIARNo.Text.ToString();
            this.Close();
        }

        private void btnOk_Enter(object sender, EventArgs e)
        {
            GlobalClass.GlobalIARNo = txtIARNo.Text.ToString();
            this.Close();
        }

        private void txtIARNo_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtIARNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOk_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtIARNo_Leave(object sender, EventArgs e)
        {

        }
    }
}
