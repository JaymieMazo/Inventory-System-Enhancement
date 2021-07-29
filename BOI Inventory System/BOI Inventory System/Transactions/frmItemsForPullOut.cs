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
    public partial class frmItemsForPullOut : Form
    {
        public frmItemsForPullOut()
        {
            InitializeComponent();
        }


        int CountLoad = 0;
        private void frmItemsForPullOut_Load(object sender, EventArgs e)
        {

            func_Load_All_Items();
            func_Load_AllStatus();
            func_Load_All_ITReceivedBy();
            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;
            lblcount.Text = dgvItems.RowCount.ToString();
            cboSearchCriteria.SelectedIndex = 0;
        }

        private void func_Load_All_Items()
        {
            //Close current connection
           
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems;
            if (GlobalClass.GlobalIsLicense == false)
            {
                //MessageBox.Show("Pull out from End user");

                AllExItems = "Select * from view_Inventory_Details" +
                                  " where Status = 'Assigned' and  " +
                                  "fk_End_User_Id = '" + GlobalClass.GlobalEmployeeId + "'";
            }
            else
            {
                //MessageBox.Show("Pull out License");
                AllExItems = "Select * from view_Inventory_Details" +
                                " where Status IN('Assigned', 'FOR REASSIGNMENT' , 'FOR ASSIGNMENT' ) and  " +
                                "Category_Name='EXPENSE' ";
            }

            SqlCommand cmdInv = new SqlCommand(AllExItems, SysCon.SystemConnect);
            cmdInv.CommandTimeout = 0;
            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(cmdInv);


            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.Columns[22].Visible = false;
            dgvItems.Columns[26].Visible = false;
            dgvItems.Columns[29].Visible = false;
            dgvItems.Columns[30].Visible = false;
            dgvItems.Columns[32].Visible = false;
            dgvItems.Columns[35].Visible = false;
            dgvItems.Columns[36].Visible = false;
            dgvItems.Columns[37].Visible = false;


            if (CountLoad == 0)
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Select";
                chk.Width = 40;
                chk.Name = "chkSelect";
                dgvItems.Columns.Insert(0, chk);
                CountLoad++;
            }
            //dgvItems.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SysCon.SystemConnect.Close();
        }

        private void func_Load_AllStatus()
        {
            if (GlobalClass.GlobalIsLicense)
            {
                cboSearchCriteria.SelectedIndex = 0;
                cboSearchCriteria.Enabled = false;
            } else
            { 
                cboSearchCriteria.Enabled = true;
            }
        }

        private void func_Load_All_ITReceivedBy()
        {
            string strReceived = "Select full_name from tbl_BOI_Employees where ResignedDate is null AND  fk_Division_Id=39";
            SysCon.CloseConnection();
            SysCon.OpenConnection();
            SqlCommand cmdReceived = new SqlCommand(strReceived, SysCon.SystemConnect);
            SqlDataReader readITD = cmdReceived.ExecuteReader();
        
            while (readITD.Read())
            {
                cboReceivedBy.Items.Add(readITD.GetValue(0).ToString());
            }
            readITD.Close();
            SysCon.CloseConnection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (GlobalClass.GlobalIsLicense == false)
            {

                if (cboSearchCriteria.Text == "Item Description")
                {

                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

                    if (dgvItems.RowCount <= 0)
                    {
                        //MessageBox.Show("Item description does not exists!");
                        txtSearch.Text = "";
                    }
                }


                if (cboSearchCriteria.Text == "Property Number")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Old_Property_No LIKE '%" + txtSearch.Text + "%'";

                    if (dgvItems.RowCount <= 0)
                    {
                        //MessageBox.Show("Property Number does not exists! ");
                        txtSearch.Text = "";
                    }
                }

                if (cboSearchCriteria.Text == "New Property Number")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "New_Property_No LIKE '%" + txtSearch.Text + "%'";
                    if (dgvItems.RowCount <= 0)
                    {
                        //MessageBox.Show("Property Number does not exists! ");
                        txtSearch.Text = "";
                    }
                }

                if (cboSearchCriteria.Text == "Serial No.")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Serial_No LIKE '%" + txtSearch.Text + "%'";

                    if (dgvItems.RowCount <= 0)
                    {
                        //MessageBox.Show("Serial No. does not exists! ");
                        txtSearch.Text = "";
                    }
                }
            }
            else
            {
                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description Like '%" + txtSearch.Text + "%'";
            }
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else if (cboReceivedBy.Text.Trim() == "")
            { 
                MessageBox.Show("Received By is REQUIRED!", "WARNING" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                GlobalClass.GlobalPullOut_ID = dgvItems.CurrentRow.Cells[1].Value.ToString();
                //MessageBox.Show(GlobalClass.GlobalInvItemId);
                this.Close();
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }


        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text.Trim() == "")
            {
                MessageBox.Show("status only");
                if (cboStatus.SelectedIndex != 0)
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Status='" + cboStatus.Text + "'";
                }
            }
            else
            {
                MessageBox.Show("status and desc");

                if (cboStatus.SelectedIndex != 0)
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Status='" + cboStatus.Text + "'" +
                                    " and description like  '%" + txtSearch.Text + "%'";
                }
            }
            lblcount.Text = dgvItems.RowCount.ToString();
        }


        void Checking_IsSelect()
        {
            int i = 0;

            foreach (DataGridViewRow rec in dgvItems.Rows)
            {
                bool isCheck = Convert.ToBoolean(rec.Cells["chkSelect"].Value);
                string pk_id = Convert.ToString(rec.Cells["pk_id"].Value);
                   
                if (isCheck)
                {
                    if (i == 0)
                    {
                        GlobalClass.GlobalPullOut_ID += pk_id;
                        i++;
                    }
                    else
                    {   
                        GlobalClass.GlobalPullOut_ID += " , " + pk_id;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalPullOut_ID = "";
            GlobalClass.Global_ReceivedBy = "";
            GlobalClass.Global_Remarks = "";
            if (cboReceivedBy.Text == "")
            {
                MessageBox.Show("Received By is REQUIRED!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else {
                GlobalClass.Global_ReceivedBy = cboReceivedBy.Text;
                frmPullOut.PullOut_Remarks = txtRemarks.Text;
                Checking_IsSelect();
                this.Close();
            }
        }
    }
}
