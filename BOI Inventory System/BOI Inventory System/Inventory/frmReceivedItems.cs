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
    public partial class frmReceivedItems : Form
    {
        string PropertyNo, Location_Id, EULName, LocationName, SerialNo, Date_Acquired, EUL, Unit_Cost, EUL_Id,IsSubs;
        double Acc_Depreciation, Book_Value;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalRecItemId = "";
            frmReceivedItemsList frm_ReceivedItemsList = new frmReceivedItemsList();
            frm_ReceivedItemsList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalRecItemId))
            {
                func_Retrieve_Items_Details();
                btnUpdate.Enabled = true;
            }
            else
            {
                func_Reset_All();
            }
        }

        private void func_Retrieve_Items_Details()
        {
            string RetrieveItems = "Select pk_Id,Category_Name,Subcategory_Name,Article_Name, Description,UOM,Serial_No,Unit_Cost,Supplier_Name,EUL_Name,Date_Acquired,Warranty_Validity,Old_Property_No,Location_Name,Remarks,fk_EUL_Id,IsSubscribed from view_Received_Items where pk_Id = ' " + GlobalClass.GlobalRecItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtCategory.Text = ItemReader[1].ToString();
                txtSubcat.Text = ItemReader[2].ToString();
                txtArticle.Text = ItemReader[3].ToString();
                txtItemDesc.Text = ItemReader[4].ToString();
                txtUOM.Text = ItemReader[5].ToString();
                txtSerialNo.Text = ItemReader[6].ToString();
                txtUnitCost.Text = ItemReader[7].ToString();
                txtSupplier.Text = ItemReader[8].ToString();
                dtDateAcquired.Text = ItemReader[10].ToString();
                txtWarrantyVaildity.Text = ItemReader[11].ToString();
                txtPropertyNo.Text = ItemReader[12].ToString();
                txtRemarks.Text = ItemReader[14].ToString();
                EUL_Id = ItemReader[15].ToString();

                if (ItemReader[16].ToString() == "1")
                { chkIsSubscribed.CheckState = CheckState.Checked; }

                EULName = ItemReader[9].ToString();
                LocationName = ItemReader[13].ToString();

                cboEUL.Text = EULName;
                cboLocation.Text = LocationName;

                PropertyNo = txtPropertyNo.Text;
                SerialNo = txtSerialNo.Text;

            }
            txtSerialNo.Focus();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear text fields?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset_All();
                        break;
                    }
            }
        }

        public frmReceivedItems()
        {
            InitializeComponent();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Item Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        if (txtSerialNo.Text == "")
                        {
                            func_Update_Data();
                        }
                        else if (txtSerialNo.Text != SerialNo)
                        {
                            //Check Serial # Duplication
                            func_Check_Serial_Dup();
                        }
                        else { func_Update_Data(); }
                        break;
                    }

                case DialogResult.No:
                    {
                        MessageBox.Show("No changes will be made", "Update Item Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        func_Reset_All();
                        break;
                    }
            }
        }
        private void func_Compute_Accumulated_Depreciation()
        {
            Date_Acquired = dtDateAcquired.Text;
            EUL = cboEUL.Text;
            Unit_Cost = txtUnitCost.Text;

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

            // Acc_Depreciation = Acc_Depreciation.ToString();

            //Compute Book Value . Acquisition Cost - Accumulated Depreciation
            Book_Value = ((Convert.ToDouble(Unit_Cost) - Acc_Depreciation));
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


        private void frmReceivedItems_Load(object sender, EventArgs e)
        {
            func_LoadLocationData();
            func_Reset_All();
            func_LoadEULData();

        }
        private void func_LoadEULData()
        {
            string EULData = "Select pk_EUL_Id,EUL_Name from tbl_Estimated_Useful_Life";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connection
            SysCon.SystemConnect.Open();

            //Loading all EUL Data
            SqlCommand LoadEULData = new SqlCommand(EULData, SysCon.SystemConnect);
            SqlDataReader EULReader = LoadEULData.ExecuteReader();

            while (EULReader.Read())
            {
                cboEUL.Items.Add(EULReader.GetValue(1));
            }

            EULReader.Close();
            EULReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void cboEUL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEUL.SelectedIndex != -1)
            { func_Get_EUL_Id(); }
        }

        private void func_Get_EUL_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string EUL = "Select pk_EUL_Id from tbl_Estimated_Useful_Life where EUL_Name =  '" + cboEUL.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from EUL table
            SqlCommand SelectEUL_Id = new SqlCommand(EUL, SysCon.SystemConnect);

            SqlDataReader EULIdReader = SelectEUL_Id.ExecuteReader();

            EULIdReader.Read();

            EUL_Id = EULIdReader[0].ToString();

            EULIdReader.Close();
            EULIdReader.Dispose();
            //Close connection
            SysCon.SystemConnect.Close();

            // MessageBox.Show(EUL_Id);

        }

        private void chkIsSubscribed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSubscribed.CheckState == CheckState.Checked)
            { IsSubs = "1";
            }
            else
            { IsSubs = "0"; }
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void txtSerialNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerialNo.BackColor = Color.Aquamarine;
        }

        private void txtSerialNo_Leave(object sender, EventArgs e)
        {
            txtSerialNo.BackColor = Color.White;
        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarks_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarks.BackColor = Color.Aquamarine;
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
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

        private void func_Reset_All()
        {
            //Details
            txtArticle.Text = "";
            txtCategory.Text = "";
            txtSubcat.Text = "";
            txtSupplier.Text = "";
            txtItemDesc.Text = "";
            txtSerialNo.Text = "";

            txtPropertyNo.Text = "";
            txtUOM.Text = "";
            cboEUL.Text = "";
            cboEUL.SelectedIndex = -1;
            cboLocation.Text = "";
            cboLocation.SelectedIndex = -1;
            txtUnitCost.Text = "";
            txtRemarks.Text = "";

            Location_Id = "";

            txtWarrantyVaildity.Text = "";

            dtDateAcquired.Value = DateTime.Now;
            btnUpdate.Enabled = false;

            btnSearch.Focus();

            chkIsSubscribed.CheckState = CheckState.Unchecked;

        }
        private void func_Check_Serial_Dup()
        {
            string CheckSerialNo = "Select * from tbl_Inventory_Details where Serial_No = '" + txtSerialNo.Text + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand SerialNoFinder = new SqlCommand(CheckSerialNo, SysCon.SystemConnect);
            SqlDataReader SerialNoReader = SerialNoFinder.ExecuteReader();

            if (SerialNoReader.Read())
            {
                MessageBox.Show("Serial No. has already been used. Please check your data. ");
                txtSerialNo.Focus();
            }
            else
            {
                func_Update_Data();
            }
            SerialNoReader.Close();
            SerialNoReader.Dispose();

            SysCon.SystemConnect.Close();
        }
        private void func_Update_Data()
        {
            //Compute Depreciation Cost and Book Value
            func_Compute_Accumulated_Depreciation();

            //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
            //* Get End Of Service value
            //**get no. only from eul value
            var EULife = cboEUL.Text;
            var E_UL = String.Join("", EULife.Where(Char.IsDigit));
            // Add EUL to Year of Acquisition
            DateTime AquisitionDate = dtDateAcquired.Value;
            DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

            string UpdateRecord = "Update tbl_Inventory_Details Set fk_EUL_Id= "+ EUL_Id +" ,fk_Location_Id ='" + Location_Id + "', Unit_Cost = '" + txtUnitCost.Text + "', Remarks = '" + txtRemarks.Text + "',Serial_No = '" + txtSerialNo.Text + "',Depreciated_Cost='"+ Acc_Depreciation + "',Book_Value='"+ Book_Value +"', IsSubscribed = '"+IsSubs+"', EOS = '"+EOS_Date+"'  where pk_Id = '" + GlobalClass.GlobalRecItemId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateItemRecord = new SqlCommand();
            UpdateItemRecord.CommandType = CommandType.Text;
            UpdateItemRecord.CommandText = UpdateRecord;
            UpdateItemRecord.Connection = SysCon.SystemConnect;
            UpdateItemRecord.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Item Record; Item Desc : = ' + '" + txtItemDesc.Text + "'+ ' ; ArticleId = '+ '" + GlobalClass.GlobalArticleId + "' + ' ; Id = '+ '" + GlobalClass.GlobalRecItemId + "' + '; Unit Cost = ' + '" + txtUnitCost.Text + "'  + '; Property No = ' + '" + txtPropertyNo.Text + "'  +' ; Serial No. = ' + '" + txtSerialNo.Text + "' + ' ;EUL = ' + '" + cboEUL.Text + "' + ' ;Date Acquired = ' + '" + dtDateAcquired.Text + "' + ' ; Location = ' + '" + cboLocation.Text + "' +' ; Warranty Validity = ' + '" + txtWarrantyVaildity.Text + "' + '; Subscribed = ' + '" + IsSubs + "' + '; EOS = ' + '" + EOS_Date+"'  )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item Record has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset_All();
        }

        private void func_compute_EOS()
        {
          
        }
    }
}
