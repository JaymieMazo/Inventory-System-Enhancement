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
    public partial class frmPullOutHistory : Form
    {
        string Doc_No;
        public frmPullOutHistory()
        {
            InitializeComponent();
        }

        private void frmPullOutHistory_Load(object sender, EventArgs e)
        {
            func_Load_PullOut_History();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";

            Doc_No = "";
        }

        private void func_Load_PullOut_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select Description,Serial_No,Old_Property_No,Status,Pull_Out_From,Date_Pull_Out,RRP_No from view_PullOutRecords";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_PullOutRecords";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_PullOutRecords"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (cboSearchCriteria.Text == "Document No.")
            {
                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "RRP_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Document No. does not exists!");
                    txtSearch.Text = "";

                }
            }

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

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Pull_Out_From LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Serial No. does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (txtSearch.Text == "")
            {
                func_Load_PullOut_History();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
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

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Print_Document()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Return_Slip", "SELECT * FROM view_PullOutRecords where RRP_No = '" + Doc_No + "' ");
            PreviewDialog.ShowDialog();

            cboSearchCriteria.SelectedIndex = 0;
            txtSearch.Text = "";
            cboSearchCriteria.Focus();
            Doc_No = "";
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

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Doc_No = dgvItems.CurrentRow.Cells[6].Value.ToString();
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          //  func_Print_Document();
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
