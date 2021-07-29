using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;

namespace BOI_Inventory_System
{
    public partial class frmItemsList : Form
    {
        public frmItemsList()
        {
            InitializeComponent();
        }

        private void frmItemsList_Load(object sender, EventArgs e)
        {

            func_Load_All_Items();
            txtSearchItem.Focus();
        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllItems = "Select * from tbl_Items_Head";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllItems, SysCon.SystemConnect);

            string srctbl = "tbl_Items_Head";

            DataSet AllItemsData = new DataSet();

            AllItemsAdapter.Fill(AllItemsData, srctbl);

            dgvItems.DataSource = AllItemsData.Tables["tbl_Items_Head"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            // dgvItems.Columns[1].Visible = false;

            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearchItem.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
                //MessageBox.Show("Item not exists.");
                txtSearchItem.Text = "";

            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalItemId = dgvItems.CurrentRow.Cells[0].Value.ToString();
             //   MessageBox.Show(GlobalClass.GlobalItemId);

              //  GlobalClass.GlobalSubcategoryId = dgvItems.CurrentRow.Cells[1].Value.ToString();

                this.Close();

            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchItem_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchItem.BackColor = Color.Aquamarine;
        }

        private void txtSearchItem_MouseLeave(object sender, EventArgs e)
        {
            txtSearchItem.BackColor = Color.White;
        }

        private void txtSearchItem_Leave(object sender, EventArgs e)
        {
            txtSearchItem.BackColor = Color.White;
        }
    }
}
