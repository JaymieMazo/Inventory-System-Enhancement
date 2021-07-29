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
    public partial class frmInventoryPerUser : Form
    {
        public frmInventoryPerUser()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalEmployeeId = "";
            GlobalClass.GlobalServiceId = "";
            GlobalClass.GlobalInvItemId = "";

            if (cboSearchCriteria.Text == "")
            {
                MessageBox.Show("Please select which criteria will be used");
                cboSearchCriteria.Focus();
            }
            else
            {
                if (cboSearchCriteria.Text == "Service")
                {
                    GlobalClass.GlobalServiceId = "";
                    txtSearch.Text = "";

                    frmServiceList frm_Services = new frmServiceList();
                    frm_Services.ShowDialog();

                    if (!String.IsNullOrEmpty(GlobalClass.GlobalServiceId))
                    {
                        func_Retrieve_Service_Details();
                        btnPrint.Focus();
                    }
                  }

                else if (cboSearchCriteria.Text == "Item Description")
                {
                    GlobalClass.GlobalInvItemId = "";
                    txtSearch.Text = "";

                    frmInventoryListforUpdating frm_Inventories = new frmInventoryListforUpdating();
                    frm_Inventories.ShowDialog();

                    if (!String.IsNullOrEmpty(GlobalClass.GlobalInvItemId))
                    {
                        func_Retrieve_Item_Desc();
                        btnPrint.Focus();
                    }

                }
                else if (cboSearchCriteria.Text == "End User")
                {
                    GlobalClass.GlobalEmployeeId = "";
                    txtSearch.Text = "";

                    frmEmployeesList frm_EmployeesList = new frmEmployeesList();
                    frm_EmployeesList.ShowDialog();
                   
                    if (!String.IsNullOrEmpty(GlobalClass.GlobalEmployeeId))
                    {
                        func_Retrieve_Employee_Details();
                        btnPrint.Focus();
                    }

                }
            }
        }
        private void func_Retrieve_Item_Desc()
        {
            string RetrieveItems = "Select pk_Id,Description from view_Inventory_Details where pk_Id = ' " + GlobalClass.GlobalInvItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtSearch.Text = ItemReader[1].ToString();
            }

            func_Load_Inv_Items_Per_Item();

            lblcount.Text = dgvItems.RowCount.ToString();

            ItemReader.Close();
            ItemReader.Dispose();
        }

        private void func_Retrieve_Service_Details()
        {
            string RetrieveService = "Select Service_Code from tbl_Services where pk_Service_Id = ' " + GlobalClass.GlobalServiceId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ServiceFinder = new SqlCommand(RetrieveService, SysCon.SystemConnect);
            SqlDataReader ServiceReader = ServiceFinder.ExecuteReader();

            if (ServiceReader.Read())
            {
                txtSearch.Text = ServiceReader[0].ToString();
                
            }

            func_Load_Inv_Items_Per_Service();
            lblcount.Text = dgvItems.RowCount.ToString();
        }



        private void func_Retrieve_Employee_Details()
        {
            string RetrieveEmployee = "Select Full_Name from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalEmployeeId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand EmployeeFinder = new SqlCommand(RetrieveEmployee, SysCon.SystemConnect);
            SqlDataReader EmployeeReader = EmployeeFinder.ExecuteReader();

            if (EmployeeReader.Read())
            {
                txtSearch.Text = EmployeeReader[0].ToString();
            }

            func_Load_Inv_Items_Per_User();
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Load_Inv_Items_Per_User()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Description,UOM,Old_Property_No,New_Property_No,Unit_Cost,Status,[End User],Unit,[Accountable Officer],Location_Name,Inventory_Date,Remarks from view_Inventory_Details where fk_End_User_Id = '" + GlobalClass.GlobalEmployeeId + "' and (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier')";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;

        //    dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void func_Load_Inv_Items_Per_Item()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Description,UOM,Old_Property_No,New_Property_No,Unit_Cost,Status,[End User],Unit,[Accountable Officer],Location_Name,Inventory_Date,Remarks from view_Inventory_Details where pk_Id = '" + GlobalClass.GlobalInvItemId + "' and (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier') ";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;

         //   dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void func_Load_Inv_Items_Per_Service()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,[Accountable Officer],[End User], Unit , Description, UOM, Old_Property_No,New_Property_No, Unit_Cost, Status, Location_Name, Inventory_Date, Remarks from view_Inventory_Details  where Service_Code = '" + txtSearch.Text + "' and (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier')";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;

          //  dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFind.Focus();

            txtSearch.Text = "";

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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please select End-User or Service!");
                btnFind.Focus();
            }
            else if (cboSearchCriteria.Text == "End User")
            {

                frmReportViewer PreviewDialog = new frmReportViewer("Inventory_Details", "SELECT * FROM view_Inventory_Details where fk_End_User_Id = '" + GlobalClass.GlobalEmployeeId + "' ");
                PreviewDialog.ShowDialog();

            }

            else if (cboSearchCriteria.Text == "Item Description")
            {

                frmReportViewer PreviewDialog = new frmReportViewer("Inventory_Details", "SELECT * FROM view_Inventory_Details where pk_Id = '" + GlobalClass.GlobalInvItemId + "' ");
                PreviewDialog.ShowDialog();

            }

            else
            {
                frmReportViewer PreviewDialog = new frmReportViewer("Inventory_Details", "SELECT * FROM view_Inventory_Details where Service_Code = '" + txtSearch.Text + "' ");
                PreviewDialog.ShowDialog();
            }
        }

        private void frmInventoryPerUser_Load(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboSearchCriteria.Text = "";
            cboSearchCriteria.SelectedIndex = -1;

            cboSearchCriteria.Focus();
            lblcount.Text = dgvItems.RowCount.ToString();

            dtInvDate.Value = DateTime.Now;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            txtSearch.Text = "";
            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();

            }

            txtSearch.Text = "";
            cboSearchCriteria.Text = "";
            cboSearchCriteria.SelectedIndex = -1;

            cboSearchCriteria.Focus();

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void btnPrintTags_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please indicate what items to print. ");
            }
            else if (cboSearchCriteria.Text == "End User")
            {
                func_Print_Tag_Per_User();
            }

            else if (cboSearchCriteria.Text == "Item Description")
            {
                func_Print_Tag_Per_Item();
            }

            else if (cboSearchCriteria.Text == "Service")
            {
                func_Print_Tag_Per_Service();
            }
        }

        private void func_Print_Tag_Per_User()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Property_Tag", "SELECT * FROM view_Inventory_Details where fk_End_User_Id = '" + GlobalClass.GlobalEmployeeId + "' and  (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier') and Tag_Size = 'BIG TAG' ");
            PreviewDialog.ShowDialog();

            frmReportViewer PreviewDialog2 = new frmReportViewer("Property_Tag_Small", "SELECT * FROM view_Inventory_Details where fk_End_User_Id = '" + GlobalClass.GlobalEmployeeId + "' and  (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier') and Tag_Size = 'SMALL TAG'");
            PreviewDialog2.ShowDialog();
        }

        private void func_Print_Tag_Per_Service()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Property_Tag", "SELECT * FROM view_Inventory_Details where Service_Code = '" + txtSearch.Text + "' and  (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier') and Tag_Size = 'BIG TAG'");
            PreviewDialog.ShowDialog();

            frmReportViewer PreviewDialog2 = new frmReportViewer("Property_Tag_Small", "SELECT * FROM view_Inventory_Details where Service_Code = '" + txtSearch.Text + "' and  (Status != 'Disposed' and Status != 'Cancelled Property No.'  and Status != 'Return to Supplier' and Status  != 'Replaced by Supplier') and Tag_Size = 'SMALL TAG'");
            PreviewDialog2.ShowDialog();
        }

        private void func_Print_Tag_Per_Item()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Property_Tag", "SELECT * FROM view_Inventory_Details where pk_Id = '" + GlobalClass.GlobalInvItemId + "' and Tag_Size = 'BIG TAG'");
            PreviewDialog.ShowDialog();

            frmReportViewer PreviewDialog2 = new frmReportViewer("Property_Tag_Small", "SELECT * FROM view_Inventory_Details where pk_Id = '" + GlobalClass.GlobalInvItemId + "'and Tag_Size = 'SMALL TAG'");
            PreviewDialog2.ShowDialog();
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            func_Update_Inventory_Date();
        }
        private void func_Update_Inventory_Date()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set Inventory_Date = @Inventory_Date,Tag = @Tag where pk_Id = @pk_Id";
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@Inventory_Date", dtInvDate.Text);
                    cmdUpdate.Parameters.AddWithValue("@Tag", "Verified");
                    cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);

                    cmdUpdate.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Inventory Date has been updated!", "Inventory", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //close connection
            SysCon.SystemConnect.Close();


            if (txtSearch.Text == "")
            {
                MessageBox.Show("Please indicate what items to print. ");
            }
            else if (cboSearchCriteria.Text == "End User")
            {
                func_Print_Tag_Per_User();
            }

            else if (cboSearchCriteria.Text == "Item Description")
            {
                func_Print_Tag_Per_Item();
            }

            else if (cboSearchCriteria.Text == "Service")
            {
                func_Print_Tag_Per_Service();
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
    }

}
