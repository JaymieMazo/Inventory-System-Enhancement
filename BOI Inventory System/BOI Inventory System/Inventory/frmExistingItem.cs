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
    public partial class frmExistingItem : Form
    {
        string EUL_Id, PropertyNo, ItemStatus, Location_Id,Supplier_Id, EULName,LocationName,Item_Status;
        string Article_Id, Item_Id,SerialNo,OICId, Date_Acquired,EUL, IsSubs;
        string Unit_Cost; double Acc_Depreciation, Book_Value; 
        public frmExistingItem()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

        }

        private void btnFindArticle_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalArticleId = "";
            frmArticleList frm_ArticleList = new frmArticleList();
            frm_ArticleList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalArticleId))
            {
                func_Retrieve_Article_Details();
                btnFindItemDesc.Focus();
            }
            else
            {
                txtArticle.Text = "";
                txtCategory.Text = "";
                txtSubcat.Text = "";
                btnFindArticle.Focus();
            }
        }

        private void func_Retrieve_Article_Details()
        {
            string RetrieveArticle = "Select * from view_ArticleSubcat where pk_Article_Id = ' " + GlobalClass.GlobalArticleId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ArticleFinder = new SqlCommand(RetrieveArticle, SysCon.SystemConnect);
            SqlDataReader ArticleReader = ArticleFinder.ExecuteReader();

            if (ArticleReader.Read())
            {

                txtCategory.Text = ArticleReader[2].ToString();
                txtSubcat.Text = ArticleReader[3].ToString();
                txtArticle.Text = ArticleReader[5].ToString();

                btnFindItemDesc.Focus();

            }
            btnFindArticle.Focus();
        }

        private void btnFindItemDesc_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalItemId = "";
            frmItemsList frm_ItemsList = new frmItemsList();
            frm_ItemsList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalItemId))
            {
                func_Retrieve_ItemDesc();
                txtSerialNo.Focus();
            }
            else
            {
                txtItemDesc.Text = "";
                txtUOM.Text = "";
                btnFindItemDesc.Focus();
            }

        }

        private void func_Retrieve_ItemDesc()
        {
            string RetrieveItem = "Select * from tbl_Items_Head where pk_Item_Code = ' " + GlobalClass.GlobalItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItem, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtItemDesc.Text = ItemReader[1].ToString();
                txtUOM.Text = ItemReader[2].ToString();
            }
        }

        private void frmExistingItem_Load(object sender, EventArgs e)
        {
            func_LoadLocationData();
            func_LoadEULData();
            func_Reset_All();

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

            txtOIC.Text = "";

            EUL_Id = "";
            Location_Id = "";

            txtWarrantyVaildity.Text = "";

            dtDateAcquired.Value = DateTime.Now;

            btnFindArticle.Focus();

            btnSaveUpdate.Text = "Save";
            btnDelete.Enabled = false;

            chkIsSubscribed.Checked = false;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(Item_Status);
            if (txtArticle.Text == "" || txtItemDesc.Text == "" || txtUnitCost.Text == "" || txtPropertyNo.Text == "" || txtOIC.Text == "" || cboEUL.Text=="")
            {
                MessageBox.Show("Cannot continue saving! Fields with (*) are required.", "Adding Existing Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                if (txtSerialNo.Text == "")
                                { func_Check_Duplication_PropertyNo(); }
                                else
                                { //Check Serial # Duplication
                                    func_Check_Serial_Dup();
                                }
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset_All();
                                break;
                            }
                    }
                }
                else
                {
                    {
                        DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Item Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (mes)
                        {
                            case DialogResult.Yes:
                                {
                                    if (txtSerialNo.Text == "")
                                    {
                                        if (txtPropertyNo.Text != PropertyNo)
                                        { func_Check_Duplication_PropertyNo(); }
                                        else
                                        { //Compute Depreciation Cost and Book Value
                                            func_Compute_Accumulated_Depreciation();
                                            //update Data
                                            func_Update_Data();
                                        }
                                    }
                                    else if (txtSerialNo.Text != SerialNo)
                                    {    //Check Serial # Duplication
                                        func_Check_Serial_Dup();
                                    }
                                    else
                                    {
                                        if (txtPropertyNo.Text != PropertyNo)
                                        { func_Check_Duplication_PropertyNo(); }
                                        else
                                        {
                                            //Compute Depreciation Cost and Book Value
                                            func_Compute_Accumulated_Depreciation();
                                            //update Data
                                            func_Update_Data();
                                        }
                                    }
                                    break;
                                }

                            case DialogResult.No:
                                {
                                    MessageBox.Show("No changes will be made", "Update Item Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                        }

                    }
                }
            }
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
                if (btnSaveUpdate.Text == "Save")
                { func_Check_Duplication_PropertyNo(); }
                else if (btnSaveUpdate.Text == "Update")
                {
                    if (txtPropertyNo.Text != PropertyNo)
                    { func_Check_Duplication_PropertyNo(); }
                    else
                    {
                        //Compute Depreciation Cost and Book Value
                        func_Compute_Accumulated_Depreciation();
                        //Update data
                        func_Update_Data();
                    }
                }
            }
            SerialNoReader.Close();
            SerialNoReader.Dispose();

            SysCon.SystemConnect.Close();
        }
        private void func_Update_Data()
        {
            //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
            //* Get End Of Service value
            //**get no. only from eul value
            var EULife = cboEUL.Text;
            var E_UL = String.Join("", EULife.Where(Char.IsDigit));
            // Add EUL to Year of Acquisition
            DateTime AquisitionDate = dtDateAcquired.Value;
            DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

            string UpdateRecord;
            if (Item_Status == "ASSIGNED")
            {
                 UpdateRecord = "Update tbl_Inventory_Details Set fk_Article_Id = '" + GlobalClass.GlobalArticleId +
                       "',fk_Item_Code = '" + GlobalClass.GlobalItemId + "', fk_EUL_Id  ='" + EUL_Id + "' , Unit_Cost  ='" + txtUnitCost.Text + "', Date_Acquired  ='" + dtDateAcquired.Text + "' , Warranty_Validity  ='" + txtWarrantyVaildity.Text + "' , Old_Property_No  ='" + txtPropertyNo.Text + "', fk_Location_Id ='" + Location_Id + "',fk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "', Remarks = '" + txtRemarks.Text + "',Serial_No = '" + txtSerialNo.Text + "',Depreciated_Cost = '" + Acc_Depreciation + "', Book_Value='" + Book_Value + "' ,IsSubscribed = '"+IsSubs+"', EOS = '"+EOS_Date+"' where pk_Id = '" + GlobalClass.GlobalExItemId + "'";
            }
            else
            {
                 UpdateRecord = "Update tbl_Inventory_Details Set fk_Article_Id = '" + GlobalClass.GlobalArticleId +
                       "',fk_Item_Code = '" + GlobalClass.GlobalItemId + "', fk_EUL_Id  ='" + EUL_Id + "' , Unit_Cost  ='" + txtUnitCost.Text + "', Date_Acquired  ='" + dtDateAcquired.Text + "' , Warranty_Validity  ='" + txtWarrantyVaildity.Text + "' , Old_Property_No  ='" + txtPropertyNo.Text + "', fk_Location_Id ='" + Location_Id + "',fk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "', Remarks = '" + txtRemarks.Text + "',Serial_No = '" + txtSerialNo.Text + "',fk_Accountable_Employee_Id = '" + OICId + "',Depreciated_Cost = '" + Acc_Depreciation + "', Book_Value='" + Book_Value + "',IsSubscribed = '" + IsSubs + "', EOS = '" + EOS_Date + "' where pk_Id = '" + GlobalClass.GlobalExItemId + "'";
            }
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
                   "', 'Update Item Record; Item Desc : = ' + '" + txtItemDesc.Text + "'+ ' ; ArticleId = '+ '" + GlobalClass.GlobalArticleId + "' + ' ; Id = '+ '" + GlobalClass.GlobalExItemId + "' + '; Property No = ' + '" + txtPropertyNo.Text + "'  +' ; Serial No. = ' + '" + txtSerialNo.Text + "' + ' ;EUL = ' + '" + cboEUL.Text + "' + ' ;Date Acquired = ' + '" + dtDateAcquired.Text + "' + ' ; Location = ' + '" + cboLocation.Text + "' +' ; Warranty Validity = ' + '" + txtWarrantyVaildity.Text + "' )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item Record has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset_All();
        }

        private void func_Check_Duplication_PropertyNo()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Old_Property_No from tbl_Inventory_Details where Old_Property_No = '" + txtPropertyNo.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read()) //if Property# was found
            {
                MessageBox.Show("Property Number already exists!", "Adding Existing Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPropertyNo.Focus();
                return;
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    //Compute Depreciation Cost and Book Value
                    func_Compute_Accumulated_Depreciation();
                    //Save data
                    func_Save_Data();
                }
                else
                {
                    //Compute Depreciation Cost and Book Value
                    func_Compute_Accumulated_Depreciation();
                    //Update Data
                    func_Update_Data();
                }
            }

            CReader.Close();
            CReader.Dispose();
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


        private void func_Save_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
            //* Get End Of Service value
            //**get no. only from eul value
            var EULife = cboEUL.Text;
            var E_UL = String.Join("", EULife.Where(Char.IsDigit));
            // Add EUL to Year of Acquisition
            DateTime AquisitionDate = dtDateAcquired.Value;
            DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

            //Add record to Existing Items Table  /tbl_Inventory_Details
            string NewExistingRecord = "Insert into tbl_Inventory_Details (fk_Record_Id,fk_Article_Id,fk_Item_Code,Serial_No,Unit_Cost,fk_EUL_Id,Date_Acquired,Warranty_Validity,Old_Property_No,fk_Location_Id,fk_Supplier_Id,Remarks,fk_Accountable_Employee_Id,Depreciated_Cost,Book_Value,IsSubscribed,EOS,Status) Values('0', '" + GlobalClass.GlobalArticleId +
               "', '" + GlobalClass.GlobalItemId +
               "', '" + txtSerialNo.Text +
               "', '" + txtUnitCost.Text +
               "', '" + EUL_Id +
               "', '" + dtDateAcquired.Text +
               //    "', '" + dtDateAcquired.Value.ToString("MM/dd//yyyy") +
               "', '" + txtWarrantyVaildity.Text +
                "', '"+ txtPropertyNo.Text +
               "', '" + Location_Id +
               "', '" + GlobalClass.GlobalSupplierId +
               "', '" + txtRemarks.Text +
               "', '" + OICId +
               "', '" + Acc_Depreciation +
               "', '" + Book_Value +
               "', '" + IsSubs +
               "', '" + EOS_Date +
               "','FOR ASSIGNMENT')";

            SqlCommand AddNewRecord = new SqlCommand(NewExistingRecord, SysCon.SystemConnect);
            AddNewRecord.ExecuteNonQuery();
            // New receiving record has been successfully added!"

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Record  ' + ' ; Article ID :' + '" + GlobalClass.GlobalArticleId + "' + ' ; Item Id = '+ '" + GlobalClass.GlobalItemId + "' + ' ;Item Desc = ' + '" + txtItemDesc.Text + "' + ' ;Property No = ' + '" + txtPropertyNo.Text + "' + ' ;Serial No. = ' + '" + txtSerialNo.Text + "'  + ' ;Subscribed? = ' + '" + IsSubs + "' + ' ;EOS = ' + '" + EOS_Date + "')";
            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("New record has been successfully added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Clear all fields
            func_Reset_All();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Item", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_Item_Record();
                        break;
                    }

            }

            func_Reset_All();
        }
        private void func_Delete_Item_Record()
        {

            string CheckStatus = "Select Status from tbl_Inventory_Details where pk_Id = ' " + GlobalClass.GlobalExItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand StatusFinder = new SqlCommand(CheckStatus, SysCon.SystemConnect);
            SqlDataReader StatusReader = StatusFinder.ExecuteReader();

            if (StatusReader.Read())
            {
                ItemStatus = StatusReader[0].ToString();
            }

            StatusReader.Close();

            if (ItemStatus != "FOR ASSIGNMENT")
            {
                MessageBox.Show("This item could not be deleted since it has already transactions associated with it!", "Delete Existing Item Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //close connection
                    SysCon.CloseConnection();

                    //open connection
                    SysCon.SystemConnect.Open();

                    //execute deletion
                    SqlCommand DeleteItemRecord = new SqlCommand();
                    DeleteItemRecord.CommandText = "Delete from tbl_Inventory_Details where pk_Id = '" + GlobalClass.GlobalExItemId + "'";
                    DeleteItemRecord.CommandType = CommandType.Text;
                    DeleteItemRecord.Connection = SysCon.SystemConnect;
                    DeleteItemRecord.ExecuteNonQuery();

                    MessageBox.Show("Item records has been successfully deleted!", "Delete Item Record", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //Insert  Activity to audit trail

                    string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                           "', '" + GlobalClass.GlobalUser +
                           "', '" + DateTime.Now.ToString() +
                           "', 'Delete Item Id = ' + '" + GlobalClass.GlobalExItemId + "' + ' ; Description = '+ '" + txtItemDesc.Text + "' + ' ; Articled Id = ' + '" + GlobalClass.GlobalArticleId + "'  + ' ; Article Name = ' + '" + txtArticle.Text + "'+ ' ; PropertyNo = ' + '" + txtPropertyNo.Text + "')";


                    SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                    AuditTrail.ExecuteNonQuery();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Existing Item Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFindOIC_Click(object sender, EventArgs e)
        {
            frmOIC frm_OIC = new frmOIC();
            frm_OIC.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalOICId))
            {
                func_Retrieve_OIC();
                btnSaveUpdate.Focus();
            }
        }

        private void txtSerialNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerialNo.BackColor = Color.Aquamarine;
        }

        private void txtSerialNo_Leave(object sender, EventArgs e)
        {
            txtSerialNo.BackColor = Color.White;
        }

        private void txtUnitCost_MouseClick(object sender, MouseEventArgs e)
        {
            txtUnitCost.BackColor = Color.Aquamarine;
        }

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            txtUnitCost.BackColor = Color.White;
        }

        private void txtWarrantyVaildity_MouseClick(object sender, MouseEventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.Aquamarine;
        }

        private void txtWarrantyVaildity_Leave(object sender, EventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.White;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void chkIsSubscribed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsSubscribed.CheckState == CheckState.Checked)
            {
                IsSubs = "1";
            }
            else
            { IsSubs = "0"; }
        }

        private void txtPropertyNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtPropertyNo.BackColor = Color.Aquamarine;
        }

        private void txtPropertyNo_Leave(object sender, EventArgs e)
        {
            txtPropertyNo.BackColor = Color.White;
        }

        private void txtRemarks_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarks.BackColor = Color.Aquamarine;
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
        }

        private void func_Retrieve_OIC()
        {
            string RetrieveOIC = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalOICId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OICFinder = new SqlCommand(RetrieveOIC, SysCon.SystemConnect);
            SqlDataReader OICReader = OICFinder.ExecuteReader();

            if (OICReader.Read())
            {
                OICId = GlobalClass.GlobalOICId;
                txtOIC.Text = OICReader[2].ToString();
            }

            OICReader.Close();
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

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalSupplierId = "";
            GlobalClass.GlobalSupplierId = "";
            frmSupplierList frm_SupplierList = new frmSupplierList();
            frm_SupplierList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalSupplierId))
            {
                func_Retrieve_Supplier();
                cboEUL.Focus();
            }
            else
            {
                txtSupplier.Text = "";
                btnFindSupplier.Focus();
            }
        }

        private void func_Retrieve_Supplier()
        {
            string RetrieveSupplier = "Select * from view_CatSupplier where pk_Supplier_Id = ' " + GlobalClass.GlobalSupplierId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand SupplierFinder = new SqlCommand(RetrieveSupplier, SysCon.SystemConnect);
            SqlDataReader SupplierReader = SupplierFinder.ExecuteReader();

            if (SupplierReader.Read())
            {
                txtSupplier.Text = SupplierReader[3].ToString();
            }
            btnFindSupplier.Focus();
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


        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmAssignmentPerEmployee frm_Assignment = new frmAssignmentPerEmployee();
            frm_Assignment.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalExItemId = "";

            frmExistingItemsList frm_ExistingItemsList = new frmExistingItemsList();
            frm_ExistingItemsList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalExItemId))
            {
                func_Retrieve_Items_Details();
            }
            else
            {
                func_Reset_All();
            }
        }

        private void func_Retrieve_Items_Details()
        {
            string RetrieveItems = "Select fk_Article_Id,fk_Item_Code,fk_Supplier_Id,Category_Name,Subcategory_Name,Article_Name, Description,UOM,Serial_No,Unit_Cost,Supplier_Name,EUL_Name,Date_Acquired,Warranty_Validity,Old_Property_No,Location_Name,Remarks,Status from view_Existing_Items_Details where pk_Id = ' " + GlobalClass.GlobalExItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                Article_Id = ItemReader[0].ToString();
                Item_Id = ItemReader[1].ToString();
                Supplier_Id = ItemReader[2].ToString();

                txtCategory.Text = ItemReader[3].ToString();
                txtSubcat.Text = ItemReader[4].ToString();
                txtArticle.Text = ItemReader[5].ToString();
                txtItemDesc.Text = ItemReader[6].ToString();
                txtUOM.Text = ItemReader[7].ToString();
                txtSerialNo.Text = ItemReader[8].ToString();
                txtUnitCost.Text = ItemReader[9].ToString();
                txtSupplier.Text = ItemReader[10].ToString();
                dtDateAcquired.Text = ItemReader[12].ToString();
                txtWarrantyVaildity.Text = ItemReader[13].ToString();
                txtPropertyNo.Text = ItemReader[14].ToString();
                txtRemarks.Text = ItemReader[16].ToString();
                Item_Status = ItemReader[17].ToString();

                EULName = ItemReader[11].ToString();
                LocationName= ItemReader[15].ToString();

                cboEUL.Text = EULName;
                cboLocation.Text = LocationName;

                PropertyNo = txtPropertyNo.Text;
                SerialNo = txtSerialNo.Text;

                GlobalClass.GlobalArticleId = Article_Id;
                GlobalClass.GlobalItemId = Item_Id;
                GlobalClass.GlobalSupplierId = Supplier_Id;

              //  MessageBox.Show(Item_Status);
            }
            txtArticle.Focus();
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;

        }

    }
}
