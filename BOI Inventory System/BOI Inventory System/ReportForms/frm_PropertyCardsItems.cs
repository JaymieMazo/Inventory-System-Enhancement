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
    public partial class frm_PropertyCardsItems : Form
    {
        public frm_PropertyCardsItems()
        {
            InitializeComponent();
        }

        private void frm_PropertyCardsItems_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select * from view_Existing_Items_Details where Status != 'CANCELLED PROPERTY NO.' ";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Existing_Items_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Existing_Items_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.Columns[5].Visible = false;
            dgvItems.Columns[6].Visible = false;
            dgvItems.Columns[7].Visible = false;
            dgvItems.Columns[8].Visible = false;
            //dgvItems.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

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
                func_Load_All_Items();

            }

            lblcount.Text = dgvItems.RowCount.ToString();

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

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
