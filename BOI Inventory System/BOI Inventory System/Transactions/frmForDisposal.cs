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
    public partial class frmForDisposal : Form
    {
        string Id, Date_Acquired,DocNo, Approving_Id, Issuing_Id,EUL,Appraised_Value,Inspector_Id, Chairman_Id;
        string Unit_Cost,ReportType; double Acc_Depreciation,Book_Value;
        public frmForDisposal()
        {
            InitializeComponent();
        }

        private void frmForDisposal_Load(object sender, EventArgs e)
        {
            lblcount2.Text = dgvItems2.RowCount.ToString();
            btnFind.Focus();
            Reset();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
          //  dgvItems2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

          //  func_Add_To_Grid();

            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvItems2.SelectedRows)
            {
                dgvItems2.Rows.RemoveAt(item.Index);
            }

            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void btnFindA_Click(object sender, EventArgs e)
        {
            frmAcccountableOfficers frm_AccountableOfficers = new frmAcccountableOfficers();
            frm_AccountableOfficers.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOfficerId))
            {
                Approving_Id = "";
                Approving_Id = GlobalClass.GlobalOfficerId;
                func_Retrieve_Approving();
                btnFindR.Focus();
            }
            else { btnFindA.Focus(); }
        }

        private void func_Retrieve_Approving()
        {
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + Approving_Id + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                txtApproved.Text = OICReader[2].ToString();

                btnFindR.Focus();

            }
            btnFindR.Focus();
        }

        private void func_Retrieve_OIC()
        {
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + Issuing_Id + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                txtIssued.Text = OICReader[2].ToString();

                txtReceiving.Focus();
                
            }
            txtReceiving.Focus();
        }

        private void btnFindR_Click(object sender, EventArgs e)
        {
            frmOIC frm_OIC = new frmOIC();
            frm_OIC.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOICId))
            {
                Issuing_Id = "";
                Issuing_Id = GlobalClass.GlobalOICId;
                func_Retrieve_OIC();
                btnFindInspector.Focus();
            }
            else { btnFindR.Focus(); }

        }

        private void btnFindInspector_Click(object sender, EventArgs e)
        {
            frmAcccountableOfficers frm_AccountableOfficers = new frmAcccountableOfficers();
            frm_AccountableOfficers.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOfficerId))
            {
                Inspector_Id = "";
                Inspector_Id = GlobalClass.GlobalOfficerId;
                func_Retrieve_Inspector();
                btnFindChairman.Focus();
            }
            else { btnFindInspector.Focus(); }
        }
        private void func_Retrieve_Inspector()
        {
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + Inspector_Id + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                txtInpector.Text = OICReader[2].ToString();
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFindChairman_Click(object sender, EventArgs e)
        {
            frmOIC frm_OIC = new frmOIC();
            frm_OIC.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOICId))
            {
                Chairman_Id = "";
                Chairman_Id = GlobalClass.GlobalOICId;
                func_Retrieve_Witness();
                dtApproved.Focus();
            }
            else { btnFindChairman.Focus(); }
        }

        private void func_Retrieve_Witness()
        {
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + Chairman_Id + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                txtChairman.Text = OICReader[2].ToString();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmItemsForDisposal frm_ItemsForDisposal = new frmItemsForDisposal();
            frm_ItemsForDisposal.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalInvItemId))
            { func_Retrieve_Item(); 
                func_Compute_Accumulated_Depareciation();
                txtAppraiseVal.Focus();
            }
            else
            { btnFind.Focus(); }

        }
       
        private void func_Retrieve_Item()
        {
            string RetrieveItems = "Select pk_Id,Description,New_Property_No,Serial_No,Date_Acquired,Unit_Cost,EUL_Name from view_Inventory_Details where pk_Id = ' " + GlobalClass.GlobalInvItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                Id = ItemReader[0].ToString();
                txtItemDesc.Text = ItemReader[1].ToString();
                txtPropertyNo.Text = ItemReader[2].ToString();
                txtSerialNo.Text = ItemReader[3].ToString();
                txtDateAcq.Text = ItemReader[4].ToString();
                txtUnitCost.Text = ItemReader[5].ToString();
                txtEUL.Text = ItemReader[6].ToString();

                Date_Acquired = txtDateAcq.Text;
                EUL = txtEUL.Text;
                Unit_Cost = txtUnitCost.Text;

            }
            ItemReader.Close();
            ItemReader.Dispose();
        }

        private void func_Compute_Accumulated_Depareciation()
        {

            //Convert date of acquisition 
            DateTime dt_Acq = Convert.ToDateTime(Date_Acquired);

            //Get the difference from date today and date acquired
            int MonthsUsed = (DateTime.Now.Year - dt_Acq.Year) * 12 + DateTime.Now.Month - dt_Acq.Month;

            //get no. only from eul value
            var E_UL = String.Join("", EUL.Where(Char.IsDigit));

            //multiply to 12 to get value in months
            double ESL = (Convert.ToDouble(E_UL) * 12);

            //compute salvage cost / 5% of the unit cost
            double Salvage_Value = (Convert.ToDouble(Unit_Cost) * .05);

            //compute depreciation expense
            double Depreciation_Exp = ((Convert.ToDouble(Unit_Cost) - Salvage_Value) / ESL);

            //convert from date to month
            double YearUsed = (Convert.ToDouble(MonthsUsed) / 12);

            //Compute accumulated depreciation
            Acc_Depreciation = System.Math.Round((Convert.ToDouble(Depreciation_Exp) * YearUsed), 2);

            txtAccDep.Text = Acc_Depreciation.ToString();

            //Compute Book Value . Acquisition Cost - Accumulated Depreciation
            Book_Value = ((Convert.ToDouble(Unit_Cost) - Acc_Depreciation));
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemDesc.Text == "")
            {
                MessageBox.Show("Please select an item to dispose. ");
            }
            //else if (txtAppraiseVal.Text == "")
            //{
            //    MessageBox.Show("Please input appraised value of the item.");
            //    txtAppraiseVal.Focus();
            //}
            else
            {
                func_AddtoDataGrid();
            }
        }
        private void func_AddtoDataGrid()
        {
            dgvItems2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //additems to datagrid
            int CurrentRow = dgvItems2.Rows.Add();

            dgvItems2.Rows[CurrentRow].Cells[0].Value = Id;
            dgvItems2.Rows[CurrentRow].Cells[1].Value = txtItemDesc.Text;
            dgvItems2.Rows[CurrentRow].Cells[2].Value = txtPropertyNo.Text;
            dgvItems2.Rows[CurrentRow].Cells[3].Value = txtSerialNo.Text;
            dgvItems2.Rows[CurrentRow].Cells[4].Value = txtDateAcq.Text;
            dgvItems2.Rows[CurrentRow].Cells[5].Value = txtUnitCost.Text;
            dgvItems2.Rows[CurrentRow].Cells[6].Value = txtEUL.Text;
            dgvItems2.Rows[CurrentRow].Cells[7].Value = txtAccDep.Text;
            dgvItems2.Rows[CurrentRow].Cells[8].Value = txtAppraiseVal.Text;
            dgvItems2.Rows[CurrentRow].Cells[9].Value = txtAccImpLosses.Text;

            Appraised_Value = txtAppraiseVal.Text;

            func_Reset_Details();
            btnFind.Focus();

            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void func_Reset_Details()
        {
            Id="";
            txtItemDesc.Text = "";
            txtPropertyNo.Text = "";
            txtSerialNo.Text="";
            txtDateAcq.Text = "";
            txtUnitCost.Text = "";
            txtAccDep.Text = "";
            txtAppraiseVal.Text = "";
            txtAccImpLosses.Text = "";

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
            btnFind.Focus();
        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboModeofDisposal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtAppraiseVal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAppraiseVal_MouseClick(object sender, MouseEventArgs e)
        {
            txtAppraiseVal.BackColor = Color.Aquamarine;
        }

        private void txtAppraiseVal_Leave(object sender, EventArgs e)
        {
            txtAppraiseVal.BackColor = Color.White;
        }

        private void txtAccImpLosses_MouseClick(object sender, MouseEventArgs e)
        {
            txtAccImpLosses.BackColor = Color.Aquamarine;
        }

        private void txtAccImpLosses_Leave(object sender, EventArgs e)
        {
            txtAccImpLosses.BackColor = Color.White;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            func_Print_PTR();
            func_Print_IRP();
            func_Print_IRRUP();
            btnReport.Enabled = false;
        }

        private void func_Print_PTR()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Transfer_Report", "SELECT * FROM view_Disposal_Record where Document_No = '" + DocNo + "'");
            PreviewDialog.ShowDialog();
        }

        private void func_Print_IRP()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("IRP_Report", "SELECT * FROM view_Disposal_Record where Document_No = '" + DocNo + "'");
            PreviewDialog.ShowDialog();
        }

        private void func_Print_IRRUP()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("IRRUP", "SELECT * FROM view_Disposal_Record where Document_No = '" + DocNo + "'");
            PreviewDialog.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (cboCondition.Text == "")
            {
                MessageBox.Show("Please indicate condition of item. ", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCondition.Focus();
            }
            else if (dgvItems2.Rows.Count == 0)
            {
                MessageBox.Show("Please select item/s for disposal", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtReason.Text == "")
            {
                MessageBox.Show("Please indicate reason for transfer.", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
            }
            else if (cboModeofDisposal.Text == "")
            {
                MessageBox.Show("Please indicate mode of disposal.", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboModeofDisposal.Focus();
            }
            else if (txtApproved.Text == "" || txtIssued.Text == "" || txtInpector.Text == "" || txtChairman.Text == "" || txtReceiving.Text == "" || txtRecipient.Text == "")
            {
                MessageBox.Show("Please indicate approving authorities.", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtStation.Text == "")
            {
                MessageBox.Show("Please indicate station field.", "Disposal Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSave.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to dispose item/s selected?", "Disposal Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Generate_Document_No();
                                func_Save_Data();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you provide will be lost.", "Disposal Recordt", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Reset();
                                break;
                            }
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear text fields?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        Reset();
                        break;
                    }
            }
        }

        private void Reset()
        {
            if (dgvItems2.DataSource != null)
            {
                dgvItems2.DataSource = null;
            }
            else
            {
                dgvItems2.Rows.Clear();
            }

            func_Reset_Details();

            cboCondition.Text = "";
            cboCondition.SelectedIndex = -1;

            cboModeofDisposal.Text = "";
            cboModeofDisposal.SelectedIndex = -1;

            txtReason.Text = "";

            txtRecipient.Text = "";
            txtReceiving.Text = "";
            txtDesignation.Text = "";

            //Approving authorities
            txtApproved.Text = "";
            txtIssued.Text = "";
            txtChairman.Text = "";
            txtInpector.Text = "";

            dtApproved.Value = DateTime.Now;
            dtTransferred.Value = DateTime.Now;

            tabControl1.SelectedIndex = 0;
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void func_Save_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //Update Status of Item
                string UpdateRecord = "Update tbl_Inventory_Details Set Status=@Status, Remarks=@Remarks,Document_No='"+ DocNo + "',fk_Accountable_Employee_Id=@fk_Accountable_Employee_Id where pk_Id = @pk_Id";
                foreach (DataGridViewRow row in dgvItems2.Rows)
                {
                    using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                    {
                        cmdUpdate.Parameters.Clear();

                        cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                        cmdUpdate.Parameters.AddWithValue("@fk_Accountable_Employee_Id", "");
                        cmdUpdate.Parameters.AddWithValue("@Status", "UNSERVICEABLE");
                        cmdUpdate.Parameters.AddWithValue("@Remarks", cboCondition.Text + ',' + cboModeofDisposal.Text );

                    cmdUpdate.ExecuteNonQuery();
                    }
                }
           
            //Save record to Disposal record
            string NewDisposalRecord = "Insert into tbl_Disposal_Record Values (@fk_Inv_Id,@Unit_Cost,@Condition_of_Item,@Mode_of_Disposal,@Reason_For_Transfer,@Date_Transferred,@fk_App_Id,@fk_OIC_Id,@Recipient,@Received_By,@Designation,@Document_No,@Appraised_Value,@Accumulated_Depreciation,@Accumulated_Impairment_Losses,@Inspector,@Chairman,@DateWitnessed,@Station)";
            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(NewDisposalRecord, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@fk_Inv_Id", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Unit_Cost", row.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@Condition_of_Item", cboCondition.Text);
                        cmd.Parameters.AddWithValue("@Mode_of_Disposal", cboModeofDisposal.Text);
                        cmd.Parameters.AddWithValue("@Reason_For_Transfer", txtReason.Text);
                        cmd.Parameters.AddWithValue("@Date_Transferred", dtTransferred.Text);
                        cmd.Parameters.AddWithValue("@fk_App_Id", Approving_Id);
                        cmd.Parameters.AddWithValue("@fk_OIC_Id", Issuing_Id);
                        cmd.Parameters.AddWithValue("@Recipient", txtRecipient.Text);
                        cmd.Parameters.AddWithValue("@Received_By", txtReceiving.Text);
                        cmd.Parameters.AddWithValue("@Designation", txtDesignation.Text);
                        cmd.Parameters.AddWithValue("@Document_No", DocNo);
                        cmd.Parameters.AddWithValue("@Appraised_Value", row.Cells[8].Value);
                        cmd.Parameters.AddWithValue("@Accumulated_Depreciation", row.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@Accumulated_Impairment_Losses", row.Cells[9].Value);
                        cmd.Parameters.AddWithValue("@Inspector", txtInpector.Text);
                        cmd.Parameters.AddWithValue("@Chairman", txtChairman.Text);
                        cmd.Parameters.AddWithValue("@DateWitnessed", dtApproved.Text);
                        cmd.Parameters.AddWithValue("@Station", txtStation.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //Save transaction to History
            string ItemHistory = "Insert into tbl_Item_History Values (@fk_Inv_Id,@Date,@Document_No,@fk_End_User_Id,@Status,@Remarks)";
            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(ItemHistory, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@fk_Inv_Id", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Date",dtTransferred.Text);
                        cmd.Parameters.AddWithValue("@Document_No", DocNo);
                        cmd.Parameters.AddWithValue("@fk_End_User_Id", '0');
                        cmd.Parameters.AddWithValue("@Status", "Disposed");
                        cmd.Parameters.AddWithValue("@Remarks", cboCondition.Text + '-' + cboModeofDisposal.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            //Insert  Activity to audit trail Head information of Disposal
            string user1 = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Process Transfer of Items / Condition of PPE  = ' + '" + cboCondition.Text + "'+ ' ; Mode of Transfer = '+ '" + cboModeofDisposal.Text + "' + ' ; Reason for Disposal = '+ '" + txtReason.Text + "' + '; Date Transferred  = ' + '" + dtTransferred.Text + "' + ' ; Recepient  = ' + '" + txtRecipient.Text + "' + ' ; Received by = ' + '" + txtReceiving.Text + "' + ' ; Document No = ' + '" + DocNo + "' )";


            SqlCommand AuditTrail = new SqlCommand(user1, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Audit trail
            string user = "Insert into tbl_Audit_Trail Values (@Full_Name,@User_Name,@Date_Time,@Activity)";

            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(user, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@Full_Name", GlobalClass.GlobalName);
                        cmd.Parameters.AddWithValue("@User_Name", GlobalClass.GlobalUser);
                        cmd.Parameters.AddWithValue("@Date_Time", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@Activity", "Transfer Item : " + row.Cells[1].Value + " ; Property No. : " + row.Cells[2].Value + " ; Serial No. : " + row.Cells[3].Value + " ; Mode of Transfer : " + cboModeofDisposal.Text + " ; Reason for Transfer : " + txtReason.Text + " ; Date of transfer : " + dtTransferred.Text + " ; Doc. No: " + DocNo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item/s has been successfully disposed!", "Items Disposal", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReportType = cboModeofDisposal.Text;

            btnReport.Enabled = true;

            Reset();
        }

        private void func_Generate_Document_No()
        {
            int count = 0;
            string YearToday = DateTime.Now.Year.ToString();
            string MonthToday = DateTime.Now.ToString("MM");

            string YearMonth = YearToday + "-" + MonthToday;


            string strCount = "Select Series FROM tbl_Serial where Doc_Type = 'PTR'";

            //Close existing connection
            SysCon.CloseConnection();

            SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
            SysCon.SystemConnect.Open();

            count = Convert.ToInt32(comd.ExecuteScalar());

            count = (Convert.ToInt32(count) + 1);

            DocNo = "PTR" + "-" + YearMonth + "-" + count.ToString("0000");
            // txtDocNo.Text = Document_No;

            //Update tbl_Serial
            string UpdateSerial = "Update tbl_Serial Set Series = '" + count + "' where Doc_Type = 'PTR'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand cmdUpdateSerial = new SqlCommand();
            cmdUpdateSerial.CommandType = CommandType.Text;
            cmdUpdateSerial.CommandText = UpdateSerial;
            cmdUpdateSerial.Connection = SysCon.SystemConnect;
            cmdUpdateSerial.ExecuteNonQuery();

            //close connection
            SysCon.CloseConnection();
        }
      }
    }
