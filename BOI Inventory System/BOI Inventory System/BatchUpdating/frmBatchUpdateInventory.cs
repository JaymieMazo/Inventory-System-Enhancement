using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BOI_Inventory_System.BatchUpdating
{
    public partial class frmBatchUpdateInventory : Form
    {
        public frmBatchUpdateInventory()
        {
            InitializeComponent();
        }

        private void frmBatchUpdateInventory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bIS_DBENGInventoryDataSet.view_Inventory_Details' table. You can move, or remove it, as needed.
            this.view_Inventory_DetailsTableAdapter.Fill(this.bIS_DBENGInventoryDataSet.view_Inventory_Details);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
