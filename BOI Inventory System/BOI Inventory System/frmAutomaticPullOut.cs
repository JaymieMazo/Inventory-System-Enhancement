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
    public partial class frmAutomaticPullOut : Form
    {
        public frmAutomaticPullOut()
        {
            InitializeComponent();
        }


        int min = 0;
        int max = GlobalClass.GlobalExpiredLicense;


        private void tmTimer_Tick(object sender, EventArgs e)
        {
             
            min += 1;
            lblCount.Text = min.ToString() + " / " + max.ToString();
            progressBar1.Maximum = max;
            progressBar1.Value = min;
            if (progressBar1.Value == max)
            {
                tmTimer.Stop();
                this.Close();
            }
        }

        private void frmAutomaticPullOut_Load(object sender, EventArgs e)
        {

        }
    }
}
