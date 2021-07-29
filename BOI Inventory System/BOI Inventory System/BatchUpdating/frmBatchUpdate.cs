using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace BOI_Inventory_System.BatchUpdating
{
    public partial class frmBatchUpdate : Form
    {
        string New_Property_No, New_Prop_Code;

        public frmBatchUpdate()
        {
            InitializeComponent();
        }

        private void frmBatchUpdate_Load(object sender, EventArgs e)
        {
            func_Load_Services();
            func_Load_All_Items();
          //  func_Load_All_Items_WithPN();


            lblcount.Text = dgvItems.RowCount.ToString();
        }
        private void func_Load_Services()
        {
            string Services = "Select pk_Division_Id,Unit from tbl_Divisions";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadServices = new SqlCommand(Services, SysCon.SystemConnect);
            SqlDataReader ServicesReader = LoadServices.ExecuteReader();

            while (ServicesReader.Read())
            {
                cboServices.Items.Add(ServicesReader.GetValue(1));
            }

            ServicesReader.Close();
            ServicesReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();


        }


        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Category_Name,Subcategory_Name,Subcategory_Code,Article_Code,Article_Name,Description,UOM,Serial_No,Unit_Cost,EUL_Name,Date_Acquired,Depreciated_Cost,Book_Value,Old_Property_No,New_Property_No,Status,Document_No,[Accountable Officer],Designation,[End User],Unit,Inventory_Date,Remarks,EOS from view_Inventory_Details where STATUS = 'FOR DISPOSAL'";
            
            //where (New_Property_No IS NULL)";
            // AND (STATUS != 'FOR ASSIGNMENT' AND STATUS != 'EXPIRED'))";
            //(Status != 'FOR ASSIGNMENT' AND Status!= 'EXPIRED'
            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.RowHeadersWidth = 5;

            SysCon.SystemConnect.Close();


            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Load_All_Items_WithPN()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Category_Name,Subcategory_Name,Subcategory_Code,Article_Code,Article_Name,Description,UOM,Serial_No,Unit_Cost,EUL_Name,Date_Acquired,Depreciated_Cost,Book_Value,Old_Property_No,New_Property_No,Status,Document_No,[Accountable Officer],Designation,[End User],Unit,Inventory_Date,Remarks,EOS from view_Inventory_Details where New_Property_No like '%0%'";
            //(Status != 'FOR ASSIGNMENT' AND Status!= 'EXPIRED'
            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.RowHeadersWidth = 5;

            SysCon.SystemConnect.Close();


            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboServices.SelectedIndex == -1)
            {
                func_Load_All_Items();
            }

            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit =  '" + cboServices.Text + "'";

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No available items under this service!");
                cboServices.Text = "";
                cboServices.SelectedIndex = -1;

            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboOffice.Text == "")
            {
                MessageBox.Show("Kindly indicate the Service or End User and Office data.", "Batch Property No. Generation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this batch of record? This process is irreversible.", "Batch Property No. Generation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Update_Data();
                            break;
                        }

                    case DialogResult.No:
                        {
                            break;
                        }
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            func_Reset();
            func_Load_All_Items();
        }
        private void func_Reset()
        {
            //Clear gridview contents
            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();
            }

            cboServices.Text = "";
            cboServices.SelectedIndex = -1;

            cboOffice.Text = "";
            cboOffice.SelectedIndex = -1;

            txtEndUser.Text = "";
        }

        private void txtEndUser_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[End User] LIKE '%" + txtEndUser.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No available items under this end user!");
                txtEndUser.Text = "";
            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void btnClearPN_Click(object sender, EventArgs e)
        {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();
                string UpdateRecord = "Update tbl_Inventory_Details set New_Property_No = @NewPN , Office = @Office where pk_Id = @pk_Id";
                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                    {
                        cmdUpdate.Parameters.Clear();
                        cmdUpdate.Parameters.AddWithValue("@NewPN", "");
                        cmdUpdate.Parameters.AddWithValue("@Office", "");
                        cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);

                        cmdUpdate.ExecuteNonQuery();
                    }
                }

            MessageBox.Show("Done!");
            }

        private void func_Update_Data()
        {

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set New_Property_No = @New_Property_No, Office = '" + cboOffice.Text +"' where pk_Id = @pk_Id";

            int x=0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                // for generation of New Property No. //Get UACS, Article Code, Date of Acquisition
                string Date = dgvItems.Rows[x].Cells[11].Value.ToString();
                string lastTwoDigitsOfYear = Date.Substring(8, 2);
               //string UACS = dgvItems.Rows[x].Cells[3].Value.ToString();
                string ArtCode = dgvItems.Rows[x].Cells[4].Value.ToString();
                New_Prop_Code = dgvItems.Rows[x].Cells[15].Value.ToString();


                if (New_Prop_Code == "")      //Check if there's already new property Code; skip generation of new property no. if True
                {
                    {
                        //Get Serial #
                        string strCount = "Select count(*) FROM tbl_Inventory_Details WHERE New_Property_No like '%" + ArtCode + "%'";

                        //Close existing connection
                        SysCon.CloseConnection();

                        SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
                        SysCon.SystemConnect.Open();

                        int count = Convert.ToInt32(comd.ExecuteScalar());

                        count = (Convert.ToInt32(count) + 1);

                        // New_Property_No = UACS + '-' + cboOffice.Text + '-' + ArtCode + lastTwoDigitsOfYear + '-' + count.ToString("0000");
                        New_Property_No = cboOffice.Text + '-' + ArtCode + lastTwoDigitsOfYear + '-' + count.ToString("0000");
                        //MessageBox.Show(new_code + '-' + count.ToString("0000"));
                        //End of code for generating Property No.
                    }

                    SysCon.CloseConnection();

                    // Open new connection
                    SysCon.SystemConnect.Open();

                    //Update tbl_Inventory
                    using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                    {
                        cmdUpdate.Parameters.Clear();
                        cmdUpdate.Parameters.AddWithValue("@New_Property_No", New_Property_No);
                        cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                        cmdUpdate.ExecuteNonQuery();


                        //Audit trail
                        //Insert  Activity to audit trail
                        string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                               "', '" + GlobalClass.GlobalUser +
                               "', '" + DateTime.Now.ToString() +
                               "', 'Update Item : ' + '" + row.Cells[6].Value + "' + ' ; Property No. : ' + '" + row.Cells[14].Value + "' + ' ; New Property No. :' + '" + New_Property_No + "' + '; Serial No. : ' + '" + row.Cells[8].Value + "')";


                        SqlCommand AuditTrail1 = new SqlCommand(user, SysCon.SystemConnect);
                        AuditTrail1.ExecuteNonQuery();

                    }
                    x++;
                }
            }

            MessageBox.Show("New property no. has been successfully generated!", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            func_Load_All_Items();
            func_Reset();
          
        }
    }
}

