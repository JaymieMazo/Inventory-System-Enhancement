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
    public partial class frmItemsForDisposal : Form
    {
        public frmItemsForDisposal()
        {
            InitializeComponent();
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

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Old_Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";

                }
            }
            if (cboSearchCriteria.Text == "New Property Number")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "New_Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Serial No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Serial_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Serial Number does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (txtSearch.Text == "")
            {
                func_Load_Items_ForDisposal();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void frmItemsForDisposal_Load(object sender, EventArgs e)
        {
            func_Load_Items_ForDisposal();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Load_Items_ForDisposal()
        {

            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string ForDisposal = "Select pk_Id,Description,New_Property_No,Serial_No,Date_Acquired,Unit_Cost,EUL_Name from view_Inventory_Details where Status = 'For Disposal'";

            SqlDataAdapter ForDisposalAdapter = new SqlDataAdapter(ForDisposal, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            ForDisposalAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;

            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                GlobalClass.GlobalInvItemId = dgvItems.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(GlobalClass.GlobalInvItemId);
                this.Close();

            }
        }

        private void txtSearch_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
