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
    public partial class frmAssignmentHistory : Form
    {
        string Doc_No,Doc_Type;
        string DocType1 = "PAR";
        string DocType2 = "ICS";
        public frmAssignmentHistory()
        {
            InitializeComponent();
        }

        private void frmAssignmentHistory_Load(object sender, EventArgs e)
        {
           // func_Load_Assignment_History();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";

           Doc_No = "";
        }

        private void func_Load_Assignment_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            //string DocType1 = "PAR";
            //string DocType2 = "ICS";

            string AllExItems = "Select Document_No,[Accountable Officer],Date_Issued from view_Inventory_Details where Document_No LIKE '%" + DocType1 + "%' or Document_No LIKE '%" + DocType2 + "%' ";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            //if (cboSearchCriteria.Text == "Document No.")
            //{
            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Document_No LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Document No. does not exists!");
            //        txtSearch.Text = "";

            //    }
            //}

            //if (cboSearchCriteria.Text == "Accountable Officer")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[Accountable Officer] LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Name does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}

            //if (txtSearch.Text == "")
            //{
            //    func_Load_Assignment_History();

            //}
            //lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if (Doc_No == "")
            {
                MessageBox.Show("Please select document no. to print. ");
            }
            else
            {
                func_Print_Document();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void func_Reset()
        {
            //cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            Doc_No = "";

            lblcount.Text = dgvItems.RowCount.ToString();

           
        }
        private void func_Print_Document()
        {

            if (Doc_Type == "PAR")
            {
                frmReportViewer PreviewDialog = new frmReportViewer("PAR_Report", "SELECT * FROM view_Inventory_Details where Document_No = '" + Doc_No + "'");
                PreviewDialog.ShowDialog();
            }

            if (Doc_Type == "ICS")
            {
                frmReportViewer PreviewDialog = new frmReportViewer("ICS_Report", "SELECT * FROM view_Inventory_Details where Document_No = '" + Doc_No + "'");
                PreviewDialog.ShowDialog();
            }

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            Doc_No = "";
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Doc_No = dgvItems.CurrentRow.Cells[0].Value.ToString();

            Doc_Type = Doc_No.Substring(0,3);
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            func_Reset();

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
                MessageBox.Show("Please indicate Document No. or name of Accountable Officer.");
                txtSearch.Focus();
            }
            else
            {
                func_Retrieve_Query_Result();
            }
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        //    if (Doc_No == "")
        //    {
        //        MessageBox.Show("Please select an item to print. ");
        //    }
        //    else
        //    {
        //        func_Print_Document();
        //    }
        }

        private void func_Retrieve_Query_Result()
        {
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            string RetrieveData;

            if (cboSearchCriteria.Text == "Document No.")
            {
              RetrieveData = "Select Distinct Document_No,[Accountable Officer],Date_Issued from view_Inventory_Details where Document_No LIKE '%" + txtSearch.Text + "%'and (Document_No LIKE '%" + DocType1 + "%' or Document_No LIKE '%" + DocType2 + "%') ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Inventory_Details";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "Accountable Officer")
            {
              RetrieveData = "Select Distinct Document_No,[Accountable Officer],Date_Issued from view_Inventory_Details where [Accountable Officer] LIKE '%" + txtSearch.Text + "%'and (Document_No LIKE '%" + DocType1 + "%' or Document_No LIKE '%" + DocType2 + "%') ";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Inventory_Details";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();
        }
    }
}
