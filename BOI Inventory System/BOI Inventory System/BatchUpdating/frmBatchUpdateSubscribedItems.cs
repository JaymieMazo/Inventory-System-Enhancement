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

    public partial class frmBatchUpdateSubscribedItems : Form
    {
        String SubsValue;
        public frmBatchUpdateSubscribedItems()
        {
            InitializeComponent();
        }

        private void frmBatchUpdateSubscribedItems_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (chkIsSubscribed.CheckState == CheckState.Checked)
            { SubsValue = "1"; }
            else { SubsValue = "0"; }

            DialogResult mes = MessageBox.Show("Do you really want to update this batch of record? This process is irreversible.", "Batch Updating of Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void func_Update_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set IsSubscribed = @IsSubscribed, EOS = @EOS where pk_Id = @pk_Id";

            int x = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                //for generation of EOS Date
                //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
                //* Get End Of Service value
                //**get no. only from eul value
                var EULife = dgvItems.Rows[x].Cells[10].Value.ToString();
                var E_UL = String.Join("", EULife.Where(Char.IsDigit));
                // Add EUL to Year of Acquisition
                var DateOfAcq = dgvItems.Rows[x].Cells[11].Value.ToString();
                DateTime AquisitionDate = DateTime.Parse(DateOfAcq);
                DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

                //Update tbl_Inventory
                //Update IsSubscribed and EOS_Date (Date of Acquisition + Estimated Useful Life) Values

                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@IsSubscribed", SubsValue);
                    cmdUpdate.Parameters.AddWithValue("@EOS", EOS_Date);
                    cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                    cmdUpdate.ExecuteNonQuery();

                    //Audit trail
                    //Insert  Activity to audit trail
                    string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                           "', '" + GlobalClass.GlobalUser +
                           "', '" + DateTime.Now.ToString() +
                           "', 'Update Item : ' + '" + row.Cells[6].Value + "' + ' ; Property No. : ' + '" + row.Cells[14].Value + "' + ' ; EOS :' + '" + EOS_Date + "' + '; Is Subscribed : ' + '" + SubsValue + "')";


                    SqlCommand AuditTrail1 = new SqlCommand(user, SysCon.SystemConnect);
                    AuditTrail1.ExecuteNonQuery();

                }
                x++;
            }
            MessageBox.Show("Data has been successfully updated!", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
            func_Load_All_Items();
         }
        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Category_Name,Subcategory_Name,Subcategory_Code,Article_Code,Article_Name,Description,UOM,Serial_No,Unit_Cost,EUL_Name,Date_Acquired,Depreciated_Cost,Book_Value,Old_Property_No,New_Property_No,Status,Document_No,[Accountable Officer],Designation,[End User],[End User Unit],Inventory_Date,Remarks,EOS from view_Inventory_Details where STATUS != 'EXPIRED'";
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                //
            }
            else
            {
                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Item not exists.");
                    txtSearch.Text = "";

                }
            }

            lblcount.Text = dgvItems.RowCount.ToString();
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

            txtSearch.Text = "";
            chkIsSubscribed.Checked = false;

            func_Load_All_Items();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chkIsSubscribed_CheckedChanged(object sender, EventArgs e)
        {
          
        }
    }
}
