using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;

namespace BOI_Inventory_System
{
    public partial class frmReceivedItemsList : Form
    {
        public frmReceivedItemsList()
        {
            InitializeComponent();
        }

        private void frmReceived_Items_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text == "Item Description")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Item description does not exists!");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Property Number")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";
                }
            }

            if (cboSearchCriteria.Text == "DR No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "DR_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("DR Number does not exists! ");
                    txtSearch.Text = "";
                }
            }
            if (cboSearchCriteria.Text == "APR/PO No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "APR_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("APR/PO Number does not exists! ");
                    txtSearch.Text = "";
                }
            }
            if (cboSearchCriteria.Text == "Supplier")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Supplier_Name LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Supplier_Name does not exists! ");
                    txtSearch.Text = "";
                }
            }

            if (cboSearchCriteria.Text == "Serial No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Serial_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Serial No. does not exists! ");
                    txtSearch.Text = "";
                }
            }

            if (txtSearch.Text == "")
            {
                func_Load_All_Items();

            }

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllReItems = "Select * from view_Received_Items where Status != 'EXPIRED'";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllReItems, SysCon.SystemConnect);

            string srctbl = "view_Received_Items";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Received_Items"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[23].Visible = false;

            SysCon.SystemConnect.Close();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {

                GlobalClass.GlobalRecItemId = dgvItems.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(GlobalClass.GlobalRecItemId);
                this.Close();
            }
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }
    }
}
