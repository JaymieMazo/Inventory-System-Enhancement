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
    public partial class frmReceivingHistory : Form
    {
        string IAR_No;
        public frmReceivingHistory()
        {
            InitializeComponent();
        }

        private void frmReceivingHistory_Load(object sender, EventArgs e)
        {
          //  func_Load_Receiving_History();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";

            IAR_No = "";
        }

        private void func_Load_Receiving_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select * from view_Receiving_History";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Receiving_History";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Receiving_History"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (cboSearchCriteria.Text == "Item Description")
            //{
            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Item description does not exists!");
            //        txtSearch.Text = "";

            //    }
            //}

            //if (cboSearchCriteria.Text == "DR No.")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "DR_No LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("DR Number does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}

            //if (cboSearchCriteria.Text == "IAR No.")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "IAR_No LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("IAR No. does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}


            //if (cboSearchCriteria.Text == "Supplier")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Supplier_Name LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("IAR No. does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}

            //if (txtSearch.Text == "")
            //{
            //    func_Load_Receiving_History();

            //}
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    if (dgvItems.RowCount <= 0)
        //    {
        //        MessageBox.Show("No items to select..");
        //    }
        //    else
        //    {

        //        IAR_No = dgvItems.CurrentRow.Cells[7].Value.ToString();
        //        func_Print_IAR();
              
        //    }
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IAR_No = dgvItems.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (IAR_No == "")
            {
                MessageBox.Show("Please select an item to print. ");
            }
            else
            {
                func_Print_IAR();
            }
        }

        private void func_Print_IAR()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Receiving_Report", "SELECT * FROM view_Receiving_Report where IAR_No = '" + IAR_No + "' ");
            PreviewDialog.ShowDialog();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            IAR_No = "";
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();

            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();
            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            IAR_No = "";

            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();
            }

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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please indicate criteria for searching..");
                txtSearch.Focus();
            }
            else
            {
                func_Retrieve_Query_Result();
            }
        }
        private void func_Retrieve_Query_Result()
        {
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            string RetrieveData;

            if (cboSearchCriteria.Text == "Item Description")
            {
                RetrieveData = "Select IAR_No,Supplier_Name, Description, Quantity, Unit_Cost,DR_No,SI_No from view_Receiving_History where Description LIKE '%" + txtSearch.Text + "%' ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Receiving_History";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Receiving_History"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "Supplier")
            {
                RetrieveData = "Select IAR_No,Supplier_Name, Description, Quantity, Unit_Cost,DR_No,SI_No from view_Receiving_History where Supplier_Name LIKE '%" + txtSearch.Text + "%' ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Receiving_History";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Receiving_History"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "DR No.")
            {
                RetrieveData = "Select IAR_No,Supplier_Name, Description, Quantity, Unit_Cost,DR_No,SI_No from view_Receiving_History where DR_No LIKE '%" + txtSearch.Text + "%' ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Receiving_History";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Receiving_History"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "IAR No.")
            {
                RetrieveData = "Select IAR_No,Supplier_Name, Description, Quantity, Unit_Cost,DR_No,SI_No from view_Receiving_History where IAR_No LIKE '%" + txtSearch.Text + "%' ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Receiving_History";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Receiving_History"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();
        }
    }

}
