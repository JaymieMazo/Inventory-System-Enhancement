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
    public partial class frmRepairHIstory : Form
    {
        public frmRepairHIstory()
        {
            InitializeComponent();
        }

        private void frmRepairHIstory_Load(object sender, EventArgs e)
        {
            func_Load_Repair_History();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
        }

        private void func_Load_Repair_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select * from view_RepairRecords";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_RepairRecords";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_RepairRecords"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboSearchCriteria.Text = "";
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
                    MessageBox.Show("Item Description does not exists! ");
                    txtSearch.Text = "";

                }
            }
            if (cboSearchCriteria.Text == "Property No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Old_Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property No. does not exists! ");
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

            if (cboSearchCriteria.Text == "End User")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[End User] LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Serial No. does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (txtSearch.Text == "")
            {
                func_Load_Repair_History();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
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
