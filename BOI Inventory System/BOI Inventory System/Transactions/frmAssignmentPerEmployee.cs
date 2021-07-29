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
    public partial class frmAssignmentPerEmployee : Form
    {
        string Document_No, Location_Id, Doc_Type,OIC_Id, Sub_Code, Acq_Date, Art_Code, New_Prop_Code, New_Property_No;
        public frmAssignmentPerEmployee()
        {
            InitializeComponent();
        }
        private void chkDocNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDocNo.Checked == true)
            {
                txtDocNo.Enabled = true;
            }
            else
            {
                txtDocNo.Text = "";
                txtDocNo.Enabled = false;
            }
        }

        private void func_Retrieve_AOfficer()
        {
            string RetrieveOfficer = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalOfficerId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OfficerFinder = new SqlCommand(RetrieveOfficer, SysCon.SystemConnect);
            SqlDataReader OfficerReader = OfficerFinder.ExecuteReader();

            if (OfficerReader.Read())
            {
                txtAccountable.Text = OfficerReader[2].ToString();
            }
            OfficerReader.Close(); OfficerReader.Dispose();
        }
        private void func_Reset()
        {
            //head
            txtAccountable.Text = "";
            txtIssuedBy.Text = "";
           // txtFundCluster.Text = "";
            chkDocNo.CheckState = 0;
            txtDocNo.Text = "";

            cboOffice.Text = "";
            cboOffice.SelectedIndex = -1;

            cboDocType.Text = "";
            cboDocType.SelectedIndex = -1;

            dtReceivedDate.Value = DateTime.Now;
            dtIssuanceDate.Value = DateTime.Now;

            //details
            func_Reset_Details();
            txtEndUser.Text = "";
            btnFindAcc.Focus();

            //Clear gridview contents
            dgvItems.Rows.Clear();

            dgvItems.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void frmAssignmentPerEmployee_Load(object sender, EventArgs e)
        {
            func_Reset();
            func_LoadLocationData();
        }
        private void func_LoadLocationData()
        {
            string LocationData = "Select * from tbl_Locations";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connection
            SysCon.SystemConnect.Open();

            //Loading all EUL Data
            SqlCommand LoadLocData = new SqlCommand(LocationData, SysCon.SystemConnect);
            SqlDataReader LocationReader = LoadLocData.ExecuteReader();

            while (LocationReader.Read())
            {
                cboLocation.Items.Add(LocationReader.GetValue(1));
            }

            LocationReader.Close();
            LocationReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }
        private void btnFindIssuer_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalOICId = "";
            frmOIC frm_OIC = new frmOIC();
            frm_OIC.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOICId))
            { func_Retrieve_OIC(); dtIssuanceDate.Focus(); }
            else { btnFindIssuer.Focus();txtIssuedBy.Text = ""; }
        }
        private void func_Retrieve_OIC()
        {
            OIC_Id = GlobalClass.GlobalOICId;
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalOICId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                txtIssuedBy.Text = OICReader[2].ToString();
            }
            OICReader.Close();
            OICReader.Dispose();
        }
        private void func_Retrieve_Item()
        {
            string RetrieveItems = "Select Description,Unit_Cost,Old_Property_No,Location_Name,Serial_No,Date_Acquired,Subcategory_Code,Article_Code,New_Property_No from view_Existing_Items_Details where pk_Id = ' " + GlobalClass.GlobalInvItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtItemDesc.Text = ItemReader[0].ToString();
                txtUnitCost.Text = ItemReader[1].ToString();

                txtPropertyNo.Text = ItemReader[2].ToString();
                txtSerialNo.Text = ItemReader[4].ToString();
                Acq_Date = ItemReader[5].ToString();
                Sub_Code = ItemReader[6].ToString();
                Art_Code = ItemReader[7].ToString();
                txtnewpn.Text = ItemReader[8].ToString();
                cboLocation.Text = ItemReader[3].ToString();
              

            }
            ItemReader.Close();
            ItemReader.Dispose();
        }

        private void btnFindUser_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalEmployeeId = "";
            frmEmployeesList frm_Employees = new frmEmployeesList();
            frm_Employees.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalEmployeeId))
            { func_Retrieve_User();cboLocation.Focus(); }
            else { txtEndUser.Text = ""; btnFindUser.Focus(); }
        }

        private void func_Retrieve_User()
        {
            string RetrieveUser = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalEmployeeId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand UserFinder = new SqlCommand(RetrieveUser, SysCon.SystemConnect);
            SqlDataReader UserReader = UserFinder.ExecuteReader();

            if (UserReader.Read())
            {
                txtEndUser.Text = UserReader[2].ToString();
            }
            UserReader.Close();
            UserReader.Dispose();
        }
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtAccountable.Text == "" || txtIssuedBy.Text == "" || dgvItems.Rows.Count == 0 || cboDocType.Text=="" ||cboOffice.Text=="")
            {
                MessageBox.Show("Cannot continue saving! Some fields are required.", "Item Assignment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtDocNo.Text == "")
            {
                DialogResult mes = MessageBox.Show("You did not provide a document number , do you want the system to automatically generate the  Document Number?", "Item Assignment Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Generate_Document_No();
                            func_Save_Data();
                            func_GenerateReport();
                            func_Print_Tag();
                            func_Print_Tag_Small();
                            func_Reset();
                            func_Reset_Details();
                            break;
                        }
                    case DialogResult.No:
                        {
                            chkDocNo.Checked = true;
                            txtDocNo.Focus();
                            break;
                        }
                }
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Item Assignment Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Save_Data();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Item Assignment Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
            }
        }

        private void func_Generate_Document_No()
        {
            int count = 0;
            string YearToday = DateTime.Now.Year.ToString();
            string MonthToday = DateTime.Now.ToString("MM");

            string YearMonth = YearToday + "-" + MonthToday;


            string strCount = "Select Series FROM tbl_Serial where Doc_Type = '"+ cboDocType.Text +"'";

            //Close existing connection
            SysCon.CloseConnection();

            SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
            SysCon.SystemConnect.Open();

            count = Convert.ToInt32(comd.ExecuteScalar());

            count = (Convert.ToInt32(count) + 1);

            Document_No = cboDocType.Text + "-" + YearMonth + "-" + count.ToString("0000");
            txtDocNo.Text = Document_No;

            //Update tbl_Serial
            string UpdateSerial = "Update tbl_Serial Set Series = '" + count + "' where Doc_Type = '"+ cboDocType.Text +"'";

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

        private void func_Save_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set fk_Accountable_Employee_Id = @fk_Accountable_Employee_Id,fk_End_User_Id = @fk_End_User_Id, fk_OIC  = @fk_OIC , Date_Issued  ='" + dtIssuanceDate.Text + "',Date_Received = '" + dtReceivedDate.Text + "',Document_No = '" + txtDocNo.Text + "',Office = '" + cboOffice.Text + "',Status ='ASSIGNED', fk_Location_Id=@fk_Location_Id,Tag_Size =@Tag_Size, New_Property_No = @New_Property_No where pk_Id = @pk_Id";

            int x = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                // for generation of New Property No. //Get UACS, Article Code, Date of Acquisition
                    string Date = dgvItems.Rows[x].Cells[12].Value.ToString();
                    string lastTwoDigitsOfYear = Date.Substring(8, 2);
                  //string UACS = dgvItems.Rows[x].Cells[13].Value.ToString();
                    string ArtCode = dgvItems.Rows[x].Cells[14].Value.ToString();
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

                        New_Property_No = cboOffice.Text + '-' + ArtCode + lastTwoDigitsOfYear + '-' + count.ToString("0000");

                        //New_Property_No = UACS + '-' + cboOffice.Text + '-' + ArtCode + lastTwoDigitsOfYear + '-' + count.ToString("0000");
                        //MessageBox.Show(new_code + '-'+ count.ToString("0000"));
                        //End of code for generating Property No.
                    }
                }
                else
                {
                    New_Property_No = New_Prop_Code;
                }

                SysCon.CloseConnection();
                
                // Open new connection
                SysCon.SystemConnect.Open();

                //Update tbl_Inventory
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@fk_Accountable_Employee_Id", row.Cells[1].Value);
                    cmdUpdate.Parameters.AddWithValue("@fk_End_User_Id", row.Cells[3].Value);
                    cmdUpdate.Parameters.AddWithValue("@fk_OIC", row.Cells[2].Value);
                    cmdUpdate.Parameters.AddWithValue("@fk_Location_Id", row.Cells[4].Value);
                    cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                    cmdUpdate.Parameters.AddWithValue("@Tag_Size", row.Cells[11].Value);
                    cmdUpdate.Parameters.AddWithValue("@New_Property_No", New_Property_No);
                    cmdUpdate.ExecuteNonQuery();


                    //Audit trail
                    //Insert  Activity to audit trail
                    string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                           "', '" + GlobalClass.GlobalUser +
                           "', '" + DateTime.Now.ToString() +
                           "', 'Assign Item : ' + '" + row.Cells[5].Value + "' + ' ; Property No. : ' + '" + row.Cells[6].Value + "' + ' ; New Property No. :' + '" + New_Property_No + "' + '; Serial No. : ' + '" + row.Cells[7].Value + "' + ' ; End User :' + '" + row.Cells[10].Value + "' + ' ; Accountable Officer : ' + '" + txtAccountable.Text + "' + '; Tag Size :' + '" + cboTagClass.Text +"')";


                    SqlCommand AuditTrail1 = new SqlCommand(user, SysCon.SystemConnect);
                    AuditTrail1.ExecuteNonQuery();

                }
                x++;
            }

            //Item History
            string ItemHistory = "Insert into tbl_Item_History Values (@fk_Inv_Id,@Date,@Document_No,@fk_End_User_Id,@Status,@Remarks)";
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(ItemHistory, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@fk_Inv_Id", row.Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Date", dtIssuanceDate.Text);
                        cmd.Parameters.AddWithValue("@Document_No", txtDocNo.Text);
                        cmd.Parameters.AddWithValue("@fk_End_User_Id", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@Status", "Issued");
                        cmd.Parameters.AddWithValue("@Remarks", "");
                        cmd.ExecuteNonQuery();
                    }
                }
            }


            //Insert  Activity to audit trail
            string user1 = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Accountable Employee = ' + '" + txtAccountable.Text + "'+ ' ; Doc No. = '+ '" + txtDocNo.Text + "' + ' ; Id = '+ '" + GlobalClass.GlobalOfficerId + "' + '; Date Received  = ' + '" + dtReceivedDate.Text + "' + ' ; Issued by = ' + '" + txtIssuedBy.Text + "' + ' ; Date Issued = ' + '" + dtIssuanceDate.Text + "' )";

            SqlCommand AuditTrail = new SqlCommand(user1, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();


            MessageBox.Show("Item/s has been successfully assigned!", "Item Assignment", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Doc_Type = cboDocType.Text;
            Document_No = txtDocNo.Text;
            
            //close connection
            SysCon.SystemConnect.Close();
        }

        private void btnAddtoGrid_Click(object sender, EventArgs e)
        {
            if (txtAccountable.Text == "")
            {
                MessageBox.Show("Choose accountable officer for the items to be assigned.", "Item Assignment ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnFindAcc.Focus();
            }
            else if (txtIssuedBy.Text == "")
            {
                MessageBox.Show("Choose issuing officer for the items to be assigned.", "Item Assignment ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnFindIssuer.Focus();
            }

            else if (txtItemDesc.Text == "" || txtEndUser.Text == "")
            {
                MessageBox.Show("Cannot add to list! Please select items and/or End User data.", "Item Assignment ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboTagClass.Text == "")
            {
                MessageBox.Show("Cannot add to list! Please select tag size to generate.", "Item Assignment ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                func_AddtoDataGrid();
            }
        }

        private void func_AddtoDataGrid()
        {
            dgvItems.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Location_Id = "0";

            //additems to datagrid
            int CurrentRow = dgvItems.Rows.Add();

            dgvItems.Rows[CurrentRow].Cells[0].Value = GlobalClass.GlobalInvItemId;
            dgvItems.Rows[CurrentRow].Cells[1].Value = GlobalClass.GlobalOfficerId;
            dgvItems.Rows[CurrentRow].Cells[2].Value = OIC_Id;
            dgvItems.Rows[CurrentRow].Cells[3].Value = GlobalClass.GlobalEmployeeId;
            dgvItems.Rows[CurrentRow].Cells[4].Value = Location_Id;
            dgvItems.Rows[CurrentRow].Cells[5].Value = txtItemDesc.Text;
            dgvItems.Rows[CurrentRow].Cells[6].Value = txtPropertyNo.Text;
            dgvItems.Rows[CurrentRow].Cells[7].Value =  txtSerialNo.Text; 
            dgvItems.Rows[CurrentRow].Cells[8].Value = txtUnitCost.Text;
            dgvItems.Rows[CurrentRow].Cells[9].Value = cboLocation.Text;
            dgvItems.Rows[CurrentRow].Cells[10].Value = txtEndUser.Text;
            dgvItems.Rows[CurrentRow].Cells[11].Value = cboTagClass.Text;
            dgvItems.Rows[CurrentRow].Cells[12].Value = Acq_Date;
            dgvItems.Rows[CurrentRow].Cells[13].Value = Sub_Code;
            dgvItems.Rows[CurrentRow].Cells[14].Value = Art_Code;
            dgvItems.Rows[CurrentRow].Cells[15].Value = txtnewpn.Text ;


            func_Reset_Details();
        }

        private void func_Reset_Details()
        {
            txtItemDesc.Text = "";
            txtPropertyNo.Text = "";
            txtUnitCost.Text = "";
            cboLocation.Text = "";
            cboLocation.SelectedIndex = -1;
            //txtEndUser.Text = "";
            txtSerialNo.Text = "";
            txtnewpn.Text = "";

            cboTagClass.Text = "";
            cboTagClass.SelectedIndex = -1;
            

            btnFindItemdesc.Focus();
        }

        private void btnFindAcc_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalOfficerId = "";
            frmAcccountableOfficers frm_AccountableOfficers = new frmAcccountableOfficers();
            frm_AccountableOfficers.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOfficerId))
            { func_Retrieve_AOfficer(); dtReceivedDate.Focus(); }
            else
            { txtAccountable.Text = ""; btnFindAcc.Focus(); }
        }

        private void btnFindItemdesc_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalInvItemId = "";
            frmInventoryItems frm_ItemsList = new frmInventoryItems();
            frm_ItemsList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalInvItemId))
            { func_Retrieve_Item(); btnFindUser.Focus(); }
            else
            {
                txtItemDesc.Text = "";
                txtSerialNo.Text = "";
                txtPropertyNo.Text = "";
                txtUnitCost.Text = "";
                txtnewpn.Text = "";
                cboLocation.Text = "";
                btnFindItemdesc.Focus(); }
        }

        private void func_GenerateReport()
        {
            if (Doc_Type == "PAR")
            {
                frmReportViewer PreviewDialog = new frmReportViewer("PAR_Report", "SELECT * FROM view_Inventory_Details where Document_No = '" + Document_No + "'");
                PreviewDialog.ShowDialog();
            }

            if (Doc_Type == "ICS")
            {
                frmReportViewer PreviewDialog = new frmReportViewer("ICS_Report", "SELECT * FROM view_Inventory_Details where Document_No = '" + Document_No + "'");
                PreviewDialog.ShowDialog();
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear text fields?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset();
                        break;
                    }
            }
        }

        private void func_Print_Tag()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Property_Tag", "SELECT * FROM view_Inventory_Details where Document_No = '" + Document_No + "' and Tag_Size = 'BIG TAG'  ");
            PreviewDialog.ShowDialog();

        }

        private void func_Print_Tag_Small()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Property_Tag_Small", "SELECT * FROM view_Inventory_Details where Document_No = '" + Document_No + "' and Tag_Size = 'SMALL TAG' ");
            PreviewDialog.ShowDialog();

        }

        private void txtDocNo_Leave(object sender, EventArgs e)
        {
            txtDocNo.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Date = dgvItems.CurrentRow.Cells[12].Value.ToString();
            string lastTwoDigitsOfYear = Date.Substring(8, 2);
            string UACS = dgvItems.CurrentRow.Cells[13].Value.ToString();
            string ArtCode = dgvItems.CurrentRow.Cells[14].Value.ToString();

            //Get Serial #
            string strCount = "Select count(*) FROM tbl_Inventory_Details WHERE New_Property_No like '%" + ArtCode + "%'";

            //Close existing connection
            SysCon.CloseConnection();

            SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
            SysCon.SystemConnect.Open();

            int count = Convert.ToInt32(comd.ExecuteScalar());
            
            count = (Convert.ToInt32(count) + 1);

            string New_Property_No = UACS + '-' + cboOffice.Text + '-' + ArtCode + lastTwoDigitsOfYear + '-' + count.ToString("0000");
            MessageBox.Show(New_Property_No);
            //MessageBox.Show(new_code + '-'+ count.ToString("0000"));
            //sProperty_No = Code + '-' + count.ToString("0000");
            //End of code for generating Property No.

            SysCon.CloseConnection();



        }

        private void txtDocNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtDocNo.BackColor = Color.Aquamarine;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboLocation_MouseClick(object sender, MouseEventArgs e)
        {
            cboLocation.Items.Clear();
            func_LoadLocationData();
        }

        private void cboDocType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLocation.SelectedIndex != -1)
            { func_Get_Location_Id(); }
        }

        private void func_Get_Location_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string LocationName = "Select pk_Location_Id from tbl_Locations where Location_Name =  '" + cboLocation.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from EUL table
            SqlCommand SelectLoc_Id = new SqlCommand(LocationName, SysCon.SystemConnect);

            SqlDataReader LocIdReader = SelectLoc_Id.ExecuteReader();

            LocIdReader.Read();

            Location_Id = LocIdReader[0].ToString();

            LocIdReader.Close();
            LocIdReader.Dispose();
            //Close connection
            SysCon.SystemConnect.Close();
            // MessageBox.Show(Location_Id);
        }
    }
}
