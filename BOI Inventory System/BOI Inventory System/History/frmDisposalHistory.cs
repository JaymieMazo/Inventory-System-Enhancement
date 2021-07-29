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
    public partial class frmDisposalHistory : Form
    {
        string Doc_No;
        public frmDisposalHistory()
        {
            InitializeComponent();
        }

        private void frmDisposalHistory_Load(object sender, EventArgs e)
        {

           // func_Load_Disposal_History();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";

            Doc_No = "";
        }

        private void func_Load_Disposal_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select Description,Unit_Cost,Property_No,Serial_No,Date_Acquired,Mode_of_Disposal,Reason_For_Transfer,Date_Transferred,Recipient,Document_No from view_Disposal_Record";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Disposal_Record";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Disposal_Record"];

            dgvItems.RowHeadersWidth = 5;

            //dgvItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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

            //}
            //    }

            //if (cboSearchCriteria.Text == "Item Description")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Item Description does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}
            //if (cboSearchCriteria.Text == "Property No.")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Property_No LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Property No. does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}
            //if (cboSearchCriteria.Text == "Serial No.")
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Serial_No LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Serial No. does not exists! ");
            //        txtSearch.Text = "";

            //    }
            //}


            //if (txtSearch.Text == "")
            //{
            //    func_Load_Disposal_History();

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
                func_Print_PTR();
                func_Print_IRP();
                func_Print_IRRUP();

                cboSearchCriteria.SelectedIndex = 0;
                txtSearch.Text = "";
                cboSearchCriteria.Focus();
                Doc_No = "";
            }
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            Doc_No = "";

            //Clear gridview contents
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

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Doc_No = dgvItems.CurrentRow.Cells[9].Value.ToString();
        }

        private void func_Print_PTR()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Transfer_Report", "SELECT * FROM view_Disposal_Record where Document_No = '" + Doc_No + "'");
            PreviewDialog.ShowDialog();
        }

        private void func_Print_IRP()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("IRP_Report", "SELECT * FROM view_Disposal_Record where Document_No = '" + Doc_No + "'");
            PreviewDialog.ShowDialog();
        }

        private void func_Print_IRRUP()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("IRRUP", "SELECT * FROM view_Disposal_Record where Document_No = '" + Doc_No + "'");
            PreviewDialog.ShowDialog();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //func_Print_PTR();
            //func_Print_IRP();
            //func_Print_IRRUP();

            //cboSearchCriteria.SelectedIndex = 0;
            //txtSearch.Text = "";
            //cboSearchCriteria.Focus();
            //Doc_No = "";
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please indicate " + cboSearchCriteria.Text);
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

            if (cboSearchCriteria.Text == "Document No.")
            {
                RetrieveData = "Select Description,Unit_Cost,Old_Property_No,Serial_No,Date_Acquired,Mode_of_Disposal,Reason_For_Transfer,Date_Transferred,Recipient,Document_No from view_Disposal_Record where Document_No LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Disposal_Record";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Disposal_Record"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "Item Description")
            {
                RetrieveData = "Select Description,Unit_Cost,Old_Property_No,Serial_No,Date_Acquired,Mode_of_Disposal,Reason_For_Transfer,Date_Transferred,Recipient,Document_No from view_Disposal_Record where Description LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Disposal_Record";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Disposal_Record"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


            if (cboSearchCriteria.Text == "Property No.")
            {
                RetrieveData = "Select Description,Unit_Cost,Old_Property_No,Serial_No,Date_Acquired,Mode_of_Disposal,Reason_For_Transfer,Date_Transferred,Recipient,Document_No from view_Disposal_Record where Old_Property_No LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Disposal_Record";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Disposal_Record"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (cboSearchCriteria.Text == "Serial No.")
            {
                RetrieveData = "Select Description,Unit_Cost,Old_Property_No,Serial_No,Date_Acquired,Mode_of_Disposal,Reason_For_Transfer,Date_Transferred,Recipient,Document_No from view_Disposal_Record where Serial_No LIKE '%" + txtSearch.Text + "%'";

                SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(RetrieveData, SysCon.SystemConnect);
                string srctbl = "view_Disposal_Record";
                DataSet ItemsData = new DataSet();
                AllItemsAdapter.Fill(ItemsData, srctbl);
                dgvItems.DataSource = ItemsData.Tables["view_Disposal_Record"];
                dgvItems.RowHeadersWidth = 5;
                dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }


            lblcount.Text = dgvItems.RowCount.ToString();
        }

    }
}
