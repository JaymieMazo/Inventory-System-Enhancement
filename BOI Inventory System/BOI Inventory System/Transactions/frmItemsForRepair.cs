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
using System.Web.UI.WebControls;

namespace BOI_Inventory_System
{
    public partial class frmItemsForRepair : Form
    {
        string Inv_Id, UpdateRecord, OIC_Id,EmpId, DocNo,ItemStatus;
        public frmItemsForRepair()
        {
            InitializeComponent();
        }

        private void frmItemsForRepair_Load(object sender, EventArgs e)
        {
            func_Load_Items_For_Repair();
            func_Reset();
        }

        private void func_Load_Items_For_Repair()
        {
            dgvItems.DataSource = null;

            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select fk_Inv_Id,fk_OIC,fk_End_User_Id,Description,Serial_No,New_Property_No,Status,Date_Pull_Out,RRP_No from view_PullOutRecords where Status = 'FOR REPAIR' or Status = 'Return to Supplier'";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_PullOutRecords";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_PullOutRecords"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;

            dgvItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

        }

        private void dgvItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            func_Click_Items();
        }

        private void func_Click_Items()
        {
            Inv_Id = dgvItems.CurrentRow.Cells[0].Value.ToString();
            OIC_Id = dgvItems.CurrentRow.Cells[1].Value.ToString();
            EmpId = dgvItems.CurrentRow.Cells[2].Value.ToString();
            txtItemDesc.Text = dgvItems.CurrentRow.Cells[3].Value.ToString();
            txtSerial.Text = dgvItems.CurrentRow.Cells[4].Value.ToString();
            txtPropertyNo.Text = dgvItems.CurrentRow.Cells[5].Value.ToString();
            ItemStatus = dgvItems.CurrentRow.Cells[6].Value.ToString();
            DocNo = dgvItems.CurrentRow.Cells[8].Value.ToString();

            cboStatus.Text = "";
            cboStatus.SelectedIndex = -1;
            btnSave.Enabled = true;
            cboStatus.Text = "";

            cboStatus.Items.Clear();

            if (ItemStatus == "RETURN TO SUPPLIER")
            {
                
                cboStatus.Items.Add("REPAIRED");
                cboStatus.Items.Add("FOR DISPOSAL");
                cboStatus.Items.Add("REPLACED BY SUPPLIER");
            }
            else if (ItemStatus == "FOR REPAIR")
            {
                cboStatus.Items.Add("REPAIRED");
                cboStatus.Items.Add("FOR DISPOSAL");
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            func_Click_Items();
            cboStatus.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("Item does not exists.");
                txtSearch.Text = "";

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to refresh this form?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset();
                        break;
                    }
            }
        }

        private void func_Reset()
        {
            txtItemDesc.Text = "";
            txtPropertyNo.Text = "";
            txtSerial.Text = "";
            txtRemarks.Text = "";
            cboStatus.Text = "";
            cboStatus.SelectedIndex = -1;
            txtRefNo.Text = "";
            cboStatus.Items.Clear();

            Inv_Id = "";
            OIC_Id = "";
            EmpId = "";

            btnSave.Enabled = false;

            dtDateReturn.Value = DateTime.Now;

            txtSearch.Focus();

            func_Load_Items_For_Repair();
        }

        private void txtRefNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtRefNo.BackColor = Color.Aquamarine;
        }

        private void txtRefNo_Leave(object sender, EventArgs e)
        {
            txtRefNo.BackColor = Color.White;
        }

        private void txtRemarks_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarks.BackColor = Color.Aquamarine;
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtItemDesc.Text == "")
            {
                MessageBox.Show("Please select item to update.");
            }
            else if (cboStatus.Text == "")
            {
                MessageBox.Show("Please select status of item.");
            }
            else if (txtRefNo.Text == "")
            {
                MessageBox.Show("Please indicate Reference No. of the transaction.");
            }
            else if (txtRemarks.Text == "")
            {
                MessageBox.Show("Please indicate description of repair made.");
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Update();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }

            }
        }

        private void dgvItems_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void func_Update()
        {
            if (cboStatus.Text == "REPAIRED")
            {
                if (ItemStatus == "RETURN TO SUPPLIER")
                {
                    UpdateRecord = "Update tbl_Inventory_Details Set Status = 'FOR REASSIGNMENT',fk_Accountable_Employee_Id = '"+ OIC_Id + "',Remarks ='" + txtRemarks.Text + "',fk_End_User_Id='',Document_No ='' where pk_Id = '" + Inv_Id + "'";
                }
                else if (ItemStatus == "FOR REPAIR")
                {
                    UpdateRecord = "Update tbl_Inventory_Details Set Status = 'ASSIGNED',Remarks ='" + txtRemarks.Text + "' where pk_Id = '" + Inv_Id + "'";
                }
            }
            if (cboStatus.Text == "FOR DISPOSAL")
            {
                 UpdateRecord = "Update tbl_Inventory_Details Set Status = 'FOR DISPOSAL', fk_End_User_Id ='', fk_Accountable_Employee_Id = '" + OIC_Id + "',Remarks ='"+ txtRemarks.Text + "',Document_No ='" + DocNo + "'  where pk_Id = '" + Inv_Id + "'";
            }

            if (cboStatus.Text == "REPLACED BY SUPPLIER")
            {
                UpdateRecord = "Update tbl_Inventory_Details Set Status = 'REPLACED BY SUPPLIER', fk_End_User_Id ='', fk_Accountable_Employee_Id = '',Remarks ='"+ txtRemarks.Text + "',Document_No ='" + DocNo + "' where pk_Id = '" + Inv_Id + "'";
            }

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateItems = new SqlCommand();
            UpdateItems.CommandType = CommandType.Text;
            UpdateItems.CommandText = UpdateRecord;
            UpdateItems.Connection = SysCon.SystemConnect;
            UpdateItems.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Item Repair Status = ' + '" + txtItemDesc.Text + "'+ ' ; Old Property No = '+ '" + txtPropertyNo.Text + "' + ' ; Status = ' + '" + cboStatus.Text + "' + ' ; Ref No : = ' + '" + txtRefNo.Text + "' + ' ; Remarks = ' + '" + txtRemarks.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            //Save transaction to tbl_Repair_History
            func_Save_Repair_Record();

            MessageBox.Show("Item Status has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
            txtItemDesc.Focus();
            func_Load_Items_For_Repair();
    }

        private void func_Save_Repair_Record()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewRecord = "Insert into tbl_Repair_Record (fk_Inv_Id,Date_Repaired,Status_Of_Item,Reference_No,Remarks) Values('" + Inv_Id +
               "', '" + dtDateReturn.Text +
               "', '" + cboStatus.Text +
               "', '" + txtRefNo.Text +
               "', '" + txtRemarks.Text + "')";

            SqlCommand AddNewItem = new SqlCommand(NewRecord, SysCon.SystemConnect);
            AddNewItem.ExecuteNonQuery();

            //Save to Item History Table
            string ItemHistory = "Insert into tbl_Item_History (fk_Inv_Id,Date,Document_No,fk_End_User_Id,Status,Remarks) Values ('" + Inv_Id +
             "', '" + dtDateReturn.Text +
             "', '" + txtRefNo.Text +
             "', '" + EmpId +
             "', '" + cboStatus.Text +
             "', '" + txtRemarks.Text + "')";

            SqlCommand AddToHistory = new SqlCommand(ItemHistory, SysCon.SystemConnect);
            AddToHistory.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'New Repair Record = ' + '" + txtItemDesc.Text + "'+ ' ; Property No = '+ '" + txtPropertyNo.Text + "' + ' ; Date Returned = '+ '" + dtDateReturn.Text + "' + ' ; Status = '+ '" + cboStatus.Text + "'+ ' ; Reference No. = '+ '" + txtRefNo.Text + "' + ' ; Remarks = '+ '" + txtRemarks.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();
     }
   }
}
