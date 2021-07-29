using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.Sql;
using System.Data.SqlClient;

namespace BOI_Inventory_System.File_Maintenance
{
    public partial class frmReceivingItem : Form
    {
        string EUL_Id, RecId, IARNo, DR, SI, SupId, varAId, VarDateAcq, APRNo,Supplier;
        string UACS_Code, Article_Code, lastTwoDigitsOfYear, Code, Property_No,Division_Id, CenterCode; double Acc_Depreciation, Book_Value;


        public frmReceivingItem()
        {
            InitializeComponent();
        }

        private void frmReceivingItem_Load(object sender, EventArgs e)
        {
            func_Load_MOA();
            func_LoadEULData();
            //func_Load_Units();
            func_Reset_All();

        }

        private void func_Load_MOA()
        {
            string MOA = "Select pk_MOA_Id,Mode_of_Acquisition from tbl_Mode_of_Acquisition";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadMOA = new SqlCommand(MOA, SysCon.SystemConnect);
            SqlDataReader MOAReader = LoadMOA.ExecuteReader();

            while (MOAReader.Read())
            {
                cboMOA.Items.Add(MOAReader.GetValue(1));
            }

            MOAReader.Close();
            MOAReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }
        private void func_Load_Units()
        {
            string Units = "Select pk_Division_Id,Unit from tbl_Divisions";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadUnits = new SqlCommand(Units, SysCon.SystemConnect);
            SqlDataReader UnitsReader = LoadUnits.ExecuteReader();

            while (UnitsReader.Read())
            {
                cboUnits.Items.Add(UnitsReader.GetValue(1));
            }

            UnitsReader.Close();
            UnitsReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
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

        private void func_Reset_Details()
        {
            //Details only
           // txtPRNo.Text = "";

            txtArticle.Text = "";
            txtCategory.Text = "";
            txtSubcat.Text = "";
            txtItemDesc.Text = "";
            txtSerialNo.Text = "";

            txtQuantity.Text = "";
            txtUOM.Text = "";
            txtTotalCost.Text = "";
            cboEUL.Text = "";
            cboEUL.SelectedIndex = -1;
            mtxtUnitCost.Text = "";
            txtUnitCost.Text = "";

            txtStockNo.Text = "";
            txtWarrantyVaildity.Text = "";
            txtRemarks.Text = "";


            txtPRNo.Focus();

            chkIsSubscribed.CheckState = CheckState.Unchecked;

           


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
            { txtItemDesc.Text = ""; txtUOM.Text = ""; btnFindItemDesc.Focus(); }
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

        private void btnFindSupplier_Click(object sender, EventArgs e)
        {
            frmSupplierList frm_SupplierList = new frmSupplierList();
            frm_SupplierList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalSupplierId))
            {
                func_Retrieve_Supplier();
                txtCenterCode.Focus();
            }
            else
            {
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
        }

        private void func_AddtoDataGrid()
        {
            int CurrentRow = dgvItems.Rows.Add();

               {
                //additems to datagrid
                dgvItems.Rows[CurrentRow].Cells[1].Value = GlobalClass.GlobalArticleId;
                dgvItems.Rows[CurrentRow].Cells[2].Value = GlobalClass.GlobalItemId;
                dgvItems.Rows[CurrentRow].Cells[3].Value = GlobalClass.GlobalSupplierId;
                dgvItems.Rows[CurrentRow].Cells[4].Value = EUL_Id;
                dgvItems.Rows[CurrentRow].Cells[5].Value = txtPRNo.Text;
                dgvItems.Rows[CurrentRow].Cells[6].Value = txtCategory.Text;
                dgvItems.Rows[CurrentRow].Cells[7].Value = txtSubcat.Text;
                dgvItems.Rows[CurrentRow].Cells[8].Value = txtArticle.Text;
                dgvItems.Rows[CurrentRow].Cells[9].Value = txtItemDesc.Text;
                dgvItems.Rows[CurrentRow].Cells[10].Value = txtUOM.Text;
                dgvItems.Rows[CurrentRow].Cells[11].Value = txtSerialNo.Text;
                dgvItems.Rows[CurrentRow].Cells[12].Value = txtQuantity.Text;
                dgvItems.Rows[CurrentRow].Cells[13].Value = txtUnitCost.Text;
                dgvItems.Rows[CurrentRow].Cells[14].Value = txtTotalCost.Text;
                dgvItems.Rows[CurrentRow].Cells[15].Value = cboEUL.Text;
                dgvItems.Rows[CurrentRow].Cells[16].Value = dtDateAcquired.Text;
                dgvItems.Rows[CurrentRow].Cells[17].Value = txtWarrantyVaildity.Text;
                dgvItems.Rows[CurrentRow].Cells[18].Value = txtRemarks.Text;
                dgvItems.Rows[CurrentRow].Cells[19].Value = txtStockNo.Text;

                //Additional Field to determine if the item is subscribed/leased
                //Save 1 if Subscribed , 0 if not
                if (chkIsSubscribed.Checked == true)
                { dgvItems.Rows[CurrentRow].Cells[20].Value = "1"; }
                else
                { dgvItems.Rows[CurrentRow].Cells[20].Value = "0"; }
            
                //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
                    //*Get End Of Service value
                    //**get no. only from eul value
                    var EULife = cboEUL.Text;
                    var E_UL = String.Join("", EULife.Where(Char.IsDigit));
                    // Add EUL to Year of Acquisition
                    DateTime AquisitionDate = dtDateAcquired.Value;
                    DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

                //Add value to datagrid
                dgvItems.Rows[CurrentRow].Cells[21].Value = EOS_Date;

            }

            //Clear Details Text Fields
            func_Reset_Details();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int num;
            bool isNumeric = int.TryParse(txtQuantity.Text, out num);
            if (isNumeric)
            {
                //
            }
            else if (txtQuantity.Text == "")
            {
                //
            }
            else
            {
                MessageBox.Show("Not a valid value for quantity.", "Wrong Input");
                txtQuantity.Text = "";
            }

            if (txtQuantity.Text != "")
            {
                mtxtUnitCost.Enabled = true;
            }

            if (txtQuantity.Text == "")
            {
                mtxtUnitCost.Enabled = false;
            }

            try
            {
                txtTotalCost.Text = (Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }

        }

        private void btnAddtoGrid_Click(object sender, EventArgs e)
        {
            if (txtPRNo.Text == "" || txtArticle.Text == "" || txtItemDesc.Text == "" || txtQuantity.Text == "" || txtUnitCost.Text == "" || cboEUL.Text == "")
            {

                MessageBox.Show("Cannot add to list! Some fields are required.", "Receiving Item Details ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cboMOA.Text=="")
            {
                MessageBox.Show("Please supply the Mode of Acquisition field in the Receiving Report Head section. ", "Receiving Item Details ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else 
            {
           
                if (txtSerialNo.Text == "")
                { func_AddtoDataGrid(); }
                else
                { //Check Serial # Duplication
                    func_Check_Serial_Dup();
                }
            }

            btnFindArticle.Focus();
        }
        private void func_Check_Serial_Dup()
        {
            string CheckSerialNo = "Select * from tbl_Inventory_Details where Serial_No = '"+txtSerialNo.Text + "'";
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
                func_AddtoDataGrid();
            }
            SerialNoReader.Close();
            SerialNoReader.Dispose();

            SysCon.SystemConnect.Close();
        }

        private void txtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            int num;
            bool isNumeric = int.TryParse(txtQuantity.Text, out num);
            if (isNumeric)
            {
                //
            }
            else if (txtQuantity.Text == "")
            {
                //
            }
            else
            {
                MessageBox.Show("Not a valid value for quantity.", "Wrong Input");
                txtQuantity.Text = "";
            }
        }
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtDRNo.Text == "" || txtSINo.Text == "" || txtAPRNo.Text == "" || txtReqOffice.Text == "" || txtSupplier.Text == "" || txtReceivedBy.Text == "" || txtAcceptedBy.Text == "" || cboMOA.Text == "" || dgvItems.Rows.Count == 0 || cboStatusOfDel.Text == "")
            {

                MessageBox.Show("Cannot continue saving! Some fields are required.", "Receiving New Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add Receiving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_Add();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Add Receiving Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset_All();
                                break;
                            }
                    }
            }
        }

        private void func_Check_Duplication_Add()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select * from tbl_Receiving_Items_Head where DR_No ='" + txtDRNo.Text + "' and SI_No = '"+ txtSINo.Text +"' and fk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "' and APR_No = '"+ txtAPRNo.Text +"'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Same DR and SI under this supplier has been already used. Please check your data.", "New Receiving Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDRNo.Focus();
                return;
            }
            else
            {
                func_Save_Data();
                func_GenerateRR();
                func_Reset_All();
            }

            CReader.Close();
            CReader.Dispose();

            SysCon.SystemConnect.Close(); ;
        }

        private void func_Save_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //Generate Inspection and Acceptance Report No
            func_Generate_IARNo();

            //Add record to Receiving Item Head
            string NewReceivingRecord = "Insert into tbl_Receiving_Items_Head (fk_Supplier_Id,DR_No,SI_No,APR_No,Requisitioning_Office,Responsibility_Code,Received_By,Received_Date,Inspected_By,Inspected_Date,Accepted_By,Status_of_Delivery,IAR_No,Remarks,Mode_of_Acquisition,Invoice_Date) Values('" + GlobalClass.GlobalSupplierId +
               "', '" + txtDRNo.Text +
               "', '" + txtSINo.Text +
               "', '" + txtAPRNo.Text +
               "', '" + txtReqOffice.Text +
               "', '" + txtCenterCode.Text +
               "', '" + txtReceivedBy.Text +
               "', '" + dtReceivedDate.Text +
               //     "', '" + dtReceivedDate.Value.ToString("MM/dd//yyyy") +
               "', '" + txtInspector.Text +
               //    "', '" + dtInspectionDate.Value.ToString("MM/dd//yyyy") +
               "', '" + dtInspectionDate.Text +
               "', '" + txtAcceptedBy.Text +
                "', '" + cboStatusOfDel.Text +
               "','" + IARNo.ToString() +
               "','" + txtRemarksHead.Text +
               "','" + cboMOA.Text +
                "', '" + dtInvoiceDate.Text + "')";

            SqlCommand AddNewRecord = new SqlCommand(NewReceivingRecord, SysCon.SystemConnect);
            AddNewRecord.ExecuteNonQuery();
            // New receiving record has been successfully added!"

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Receiving Record IAR No. = ' + '" + IARNo + "'+ ' ; DR No. :' + '" + txtDRNo.Text + "' + ' ; SI No = '+ '" + txtSINo.Text + "'+ ' ;APR/P.O No. = ' + '" + txtAPRNo.Text + "' + ' ;Supplier Id = ' + '" + GlobalClass.GlobalSupplierId + "' + ' ;Supplier Name = ' + '" + txtSupplier.Text + "')";

            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Get Record Id
            string RetrieveRecordId = "Select pk_Record_Id from tbl_Receiving_Items_Head where fk_Supplier_Id = ' " + GlobalClass.GlobalSupplierId + "' and DR_No ='" + txtDRNo.Text + "' and SI_No = '" + txtSINo.Text + "' and APR_No = '" + txtAPRNo.Text +"'";
            SqlCommand RecordIdFinder = new SqlCommand(RetrieveRecordId, SysCon.SystemConnect);
            SqlDataReader RecordIdReader = RecordIdFinder.ExecuteReader();
            if (RecordIdReader.Read())
            {
                RecId = RecordIdReader[0].ToString();
            }
            RecordIdReader.Close();

            //Saving Item Details :
            string NewReceivingRecordDetails = "Insert into tbl_Receving_Items_Details Values (@fk_Record_Id,@fk_Article_Id,@fk_Item_Code,@PR_No,@Serial_No,@Quantity,@Unit_Cost,@Total_Cost,@fk_EUL_Id,@Date_Acquired,@Warranty_Validity,@Remarks,@Stock_No,@IsSubscribed,@EOS)";

            int x = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(NewReceivingRecordDetails, SysCon.SystemConnect))
                {
                    cmd.Parameters.AddWithValue("@fk_Record_Id", RecId);
                    cmd.Parameters.AddWithValue("@fk_Article_Id", row.Cells[1].Value);
                    cmd.Parameters.AddWithValue("@fk_Item_Code", row.Cells[2].Value);
                    cmd.Parameters.AddWithValue("@PR_No", row.Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Serial_No", row.Cells[11].Value);
                    cmd.Parameters.AddWithValue("@Quantity", row.Cells[12].Value);
                    cmd.Parameters.AddWithValue("@Unit_Cost", row.Cells[13].Value);
                    cmd.Parameters.AddWithValue("@Total_Cost", row.Cells[14].Value);
                    cmd.Parameters.AddWithValue("@fk_EUL_Id", row.Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Date_Acquired", row.Cells[16].Value);
                    cmd.Parameters.AddWithValue("@Warranty_Validity", row.Cells[17].Value);
                    cmd.Parameters.AddWithValue("@Remarks", row.Cells[18].Value);
                    cmd.Parameters.AddWithValue("@Stock_No", row.Cells[19].Value);
                    cmd.Parameters.AddWithValue("@IsSubscribed", row.Cells[20].Value);
                    cmd.Parameters.AddWithValue("@EOS", row.Cells[21].Value);

                    string varId = RecId;
                    varAId = dgvItems.Rows[x].Cells[1].Value.ToString();
                    string VarIid = dgvItems.Rows[x].Cells[2].Value.ToString();
                    string VarSerialNo = dgvItems.Rows[x].Cells[11].Value.ToString();
                    string VarUcost = dgvItems.Rows[x].Cells[13].Value.ToString();
                    string VarEULId = dgvItems.Rows[x].Cells[4].Value.ToString();
                    string EULife = dgvItems.Rows[x].Cells[15].Value.ToString();
                    VarDateAcq = dgvItems.Rows[x].Cells[16].Value.ToString();
                    string VarWarVal = dgvItems.Rows[x].Cells[17].Value.ToString();
                    string VarIsSubscribed = dgvItems.Rows[x].Cells[20].Value.ToString();
                    string VarEOS = dgvItems.Rows[x].Cells[21].Value.ToString();

                    // Compute Depreciation and Book Value 
                    //Convert date of acquisition 
                    DateTime dt_Acq = Convert.ToDateTime(VarDateAcq);

                    //Get the difference from date today and date acquired
                    int MonthsUsed = (DateTime.Now.Year - dt_Acq.Year) * 12 + DateTime.Now.Month - dt_Acq.Month;

                    //get no. only from eul value
                    var E_UL = String.Join("", EULife.Where(Char.IsDigit));

                    //multiply to 12 to get value in months
                    double ESL = (Convert.ToDouble(E_UL) * 12);

                    //compute salvage cost / 5% of the unit cost
                    double Salvage_Value = (Convert.ToDouble(VarUcost) * .05);

                    //compute depreciation expense
                    double Depreciation_Exp = ((Convert.ToDouble(VarUcost) - Salvage_Value) / ESL);

                    //convert from date to month
                    double YearUsed = (Convert.ToDouble(MonthsUsed) / 12);

                    //Compute accumulated depreciation 
                    Acc_Depreciation = System.Math.Round((Convert.ToDouble(Depreciation_Exp) * YearUsed), 2);

                    // Acc_Depreciation = Acc_Depreciation.ToString();

                    //Compute Book Value . Acquisition Cost - Accumulated Depreciation
                    Book_Value = ((Convert.ToDouble(VarUcost) - Acc_Depreciation));

                    //Saving to Inventory Details
                    string qty = dgvItems.Rows[x].Cells[12].Value.ToString();

                    int rowcnt = Convert.ToInt32(qty);
                    //MessageBox.Show("Quantity "+rowcnt.ToString());
                    int ctr = 0;

                    x++;
                    //MessageBox.Show(x.ToString());
                    do
                    {
                        //MessageBox.Show("Counter "+ctr.ToString());
                        //Generate Property No
                        //Get equivalent UACS Code
                        string GetUACS = "Select Subcategory_Code from view_ArticleSubcat where pk_Article_Id = ' " + varAId + "'";
                        //close current connection
                        SysCon.CloseConnection();
                        //Open connection
                        SysCon.SystemConnect.Open();

                        SqlCommand CodeFinder = new SqlCommand(GetUACS, SysCon.SystemConnect);
                        SqlDataReader CodeReader = CodeFinder.ExecuteReader();

                        if (CodeReader.Read())
                        {
                            UACS_Code = CodeReader[0].ToString();
                        }

                        CodeReader.Close();

                        //Get Article Code
                        string GetArticleCode = "Select Article_Code from view_ArticleSubcat where pk_Article_Id = ' " + varAId + "'";
                        //close current connection
                        SysCon.CloseConnection();
                        //Open connection
                        SysCon.SystemConnect.Open();

                        SqlCommand ArticleCodeFinder = new SqlCommand(GetArticleCode, SysCon.SystemConnect);
                        SqlDataReader ArticleCodeReader = ArticleCodeFinder.ExecuteReader();

                        if (ArticleCodeReader.Read())
                        {
                            Article_Code = ArticleCodeReader[0].ToString();
                        }

                        CodeReader.Close();

                        //Get Year Acquired
                        lastTwoDigitsOfYear = VarDateAcq.Substring(8, 2);
                        //Old Format 
                        //Code = UACS_Code + '-' + Article_Code + lastTwoDigitsOfYear;
                        //New Format : removed UACS Code 
                         Code = Article_Code + lastTwoDigitsOfYear;
                        //Get Serial #
                        string strCount = "Select count(*) FROM view_Inventory_Details WHERE Old_Property_No like '%" + Article_Code + "%'";

                        //Close existing connection
                        SysCon.CloseConnection();

                        SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
                        SysCon.SystemConnect.Open();

                        int count = Convert.ToInt32(comd.ExecuteScalar());

                        count = (Convert.ToInt32(count) + 1);

                        Property_No = Code + '-' + count.ToString("0000");
                        //End of code for generating Property No.
                        //MessageBox.Show("Property" +Property_No);

                        //Save to tbl_Inventory_Details
                        string NewInvItem = "Insert into tbl_Inventory_Details (fk_Record_Id,fk_Article_Id,fk_Item_Code,fk_Supplier_Id,Serial_No,Unit_Cost,fk_EUL_Id,Date_Acquired,Warranty_Validity,Mode_of_Acquisition,Old_Property_No,fk_Accountable_Employee_Id,Depreciated_Cost,Book_Value,IsSubscribed,EOS,Status) Values('" + varId +
                                 "', '" + varAId +
                                 "', '" + VarIid +
                                 "', '" + GlobalClass.GlobalSupplierId +
                                 "', '" + VarSerialNo +
                                 "', '" + VarUcost +
                                 "', '" + VarEULId +
                                 "', '" + VarDateAcq +
                                 "', '" + VarWarVal +
                                 "', '" + cboMOA.Text + 
                                 "', '" + Property_No +
                                 "', '" + GlobalClass.GlobalOICId +
                                 "', '" + Acc_Depreciation +
                                 "', '" + Book_Value +
                                 "', '" + VarIsSubscribed +
                                 "', '" + VarEOS +
                                 "', 'FOR ASSIGNMENT')";

                        SqlCommand AddNewInvItem = new SqlCommand(NewInvItem, SysCon.SystemConnect);
                        AddNewInvItem.ExecuteNonQuery();

                        ctr++;
                    }
                    while (ctr != rowcnt);
                    cmd.ExecuteNonQuery();
                }

            }
            //Close Connection
            SysCon.SystemConnect.Close();
                MessageBox.Show("New record has been successfully added!", "Add New Receiving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear all text fields including the head of this report? ", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset_All();
                        break;
                    }
            }
        }

        private void func_Reset_All()
        {
            //Head
            txtDRNo.Text = ""; txtDRNo.Focus();
            txtSINo.Text = "";
            txtAPRNo.Text = "";
            cboMOA.Text = "";
            cboMOA.SelectedIndex = -1;

            txtSupplier.Text = "";
            txtCenterCode.Text = "";
            txtReceivedBy.Text = "";
            txtInspector.Text = "";
            txtAcceptedBy.Text = "";
            txtRemarksHead.Text = "";

            cboStatusOfDel.SelectedIndex = -1;
            cboStatusOfDel.Text = "";

            txtReqOffice.Text = "";
            cboUnits.Text = "";
            cboUnits.SelectedIndex = -1;

            //Details
            txtPRNo.Text = "";

            txtArticle.Text = "";
            txtCategory.Text = "";
            txtSubcat.Text = "";
            txtItemDesc.Text = "";
            txtSerialNo.Text = "";

            txtQuantity.Text = "";
            txtUOM.Text = "";
            txtTotalCost.Text = "";
            cboEUL.Text = "";
            cboEUL.SelectedIndex = -1;
            mtxtUnitCost.Text = "";
            txtUnitCost.Text = "";

            txtStockNo.Text = "";
            txtWarrantyVaildity.Text = "";
            txtRemarks.Text = "";

            dgvItems.Rows.Clear();

            dtDateAcquired.Value = DateTime.Now;
            dtInspectionDate.Value = DateTime.Now;
            dtReceivedDate.Value = DateTime.Now;

            txtDRNo.Focus();

            if (dgvItems2.DataSource != null)
            {
                dgvItems2.DataSource = null;
            }
            else
            {
                dgvItems2.Rows.Clear();
            }

            btnUpdate.Visible = false;
            btnSaveUpdate.Visible = true;

            dgvItems2.Visible = false;

            btnAddtoGrid.Enabled = true;

            GlobalClass.GlobalOICId = "";
            GlobalClass.GlobalArticleId = "";
            GlobalClass.GlobalItemId = "";

            tabControl1.SelectedIndex = 0;

        }

        private void func_Generate_IARNo()
        {
            string YearToday = DateTime.Now.Year.ToString();
            string MonthToday = DateTime.Now.ToString("MM");

            string YearMonth = YearToday +"-"+ MonthToday;

         
            string strCount = "Select count(*) FROM tbl_Receiving_Items_Head WHERE IAR_No like '%" + YearToday +"%'";

            //Close existing connection
            SysCon.CloseConnection();

            SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
            SysCon.SystemConnect.Open();

            int count = Convert.ToInt32(comd.ExecuteScalar());

            count = (Convert.ToInt32(count) + 1);

            IARNo = YearMonth + "-" + count.ToString("0000");
        }

        private void mtxtUnitCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalCost.Text = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(mtxtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
        //    int num;
        //    bool isNumeric = int.TryParse(txtUnitCost.Text, out num);
        //    if (isNumeric)
        //    {
        //        //
        //    }
        //    else if (txtUnitCost.Text == "")
        //    {
        //        //
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not a valid value for unit cost.", "Wrong Input");
        //        txtUnitCost.Text = "";
        //    }


            try
            {
                txtTotalCost.Text = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }
        }
     

        private void func_GenerateRR()
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Receiving_Report", "SELECT * FROM view_Receiving_Report where IAR_No = '" + IARNo + "' ");
            PreviewDialog.ShowDialog();
        }


        private void txtDRNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtDRNo.BackColor = Color.Aquamarine;
        }

        private void txtSINo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSINo_MouseClick(object sender, MouseEventArgs e)
        {
            txtSINo.BackColor = Color.Aquamarine;
        }

        private void txtDRNo_Leave(object sender, EventArgs e)
        {
            txtDRNo.BackColor = Color.White;
        }

        private void txtSINo_Leave(object sender, EventArgs e)
        {
            txtSINo.BackColor = Color.White;
        }

        private void txtDRNo_TabStopChanged(object sender, EventArgs e)
        {
            
        }

        private void txtAPRNo_TabStopChanged(object sender, EventArgs e)
        {
        }
        private void txtDRNo_TextChanged(object sender, EventArgs e)
        {
        }
        private void txtAPRNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtAPRNo.BackColor = Color.Aquamarine;
        }

        private void txtAPRNo_Leave(object sender, EventArgs e)
        {
            txtAPRNo.BackColor = Color.White;
        }


        private void txtCenterCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCenterCode.BackColor = Color.Aquamarine;
        }

        private void txtCenterCode_Leave(object sender, EventArgs e)
        {
            txtCenterCode.BackColor = Color.White;
        }

        private void txtReceivedBy_MouseClick(object sender, MouseEventArgs e)
        {
            txtReceivedBy.BackColor = Color.Aquamarine;
        }

        private void txtReceivedBy_Leave(object sender, EventArgs e)
        {
            txtReceivedBy.BackColor = Color.White;
        }

        private void dtReceivedDate_DropDown(object sender, EventArgs e)
        {
           dtReceivedDate.BackColor = Color.Aquamarine;
        }

        private void dtReceivedDate_Leave(object sender, EventArgs e)
        {
            dtReceivedDate.BackColor = Color.White;
        }

        private void txtInspector_MouseClick(object sender, MouseEventArgs e)
        {
            txtInspector.BackColor = Color.Aquamarine;
        }

        private void txtInspector_Leave(object sender, EventArgs e)
        {
            txtInspector.BackColor = Color.White;
        }

        private void dtInspectionDate_DropDown(object sender, EventArgs e)
        {
            dtInspectionDate.BackColor = Color.Aquamarine;
        }

        private void dtInspectionDate_Leave(object sender, EventArgs e)
        {
            dtInspectionDate.BackColor = Color.White;
        }

        private void txtAcceptedBy_MouseClick(object sender, MouseEventArgs e)
        {
            txtAcceptedBy.BackColor = Color.Aquamarine;
        }

        private void txtAcceptedBy_Leave(object sender, EventArgs e)
        {
            txtAcceptedBy.BackColor = Color.White;

        }

        private void txtRemarksHead_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarksHead.BackColor = Color.Aquamarine;
        }

        private void txtRemarksHead_Leave(object sender, EventArgs e)
        {
            txtRemarksHead.BackColor = Color.White;
        }

        private void txtPRNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtPRNo.BackColor = Color.Aquamarine;
        }

        private void txtPRNo_Leave(object sender, EventArgs e)
        {
            txtPRNo.BackColor = Color.White;
        }


        private void txtQuantity_MouseClick(object sender, MouseEventArgs e)
        {
            txtQuantity.BackColor = Color.Aquamarine;
        }

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            txtQuantity.BackColor = Color.White;
        }

        private void txtUnitCost_Leave(object sender, EventArgs e)
        {
            txtUnitCost.BackColor = Color.White;
        }

        private void txtUnitCost_MouseClick(object sender, MouseEventArgs e)
        {
            txtUnitCost.BackColor = Color.Aquamarine;
        }

        private void cboEUL_MouseClick(object sender, MouseEventArgs e)
        {
            cboEUL.BackColor = Color.Aquamarine;
        }

        private void cboEUL_Leave(object sender, EventArgs e)
        {
            cboEUL.BackColor = Color.White;
        }

        private void dtDateAcquired_DropDown(object sender, EventArgs e)
        {
        }

        private void txtWarrantyVaildity_MouseClick(object sender, MouseEventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.Aquamarine;
        }

        private void txtWarrantyVaildity_Leave(object sender, EventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.White;

        }

        private void txtRemarks_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarks.BackColor = Color.Aquamarine;
        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            if (txtSerialNo.Text != "")
            {
                txtQuantity.Text = "1";
                txtQuantity.Enabled = false;
            }
            else
            {
                txtQuantity.Text = "";
                txtQuantity.Enabled = true;
            }
        }
        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
        }

        private void newReceivingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = true;
            groupBox3.Visible = true;

            btnClear.Visible = true;
            btnSaveUpdate.Visible = true;

            tabControl1.Visible = true;

            tabControl1.SelectedIndex = 0;

            btnSaveUpdate.Text = "Save";

            dgvItems.Visible = true;
            dgvItems2.Visible = false;

            btnAddtoGrid.Enabled = true;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }

        private void cboUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnits.SelectedIndex != -1)
            { func_Get_Division_Id();
                func_Get_Service_Center_Code();
            }
        }

        private void dtReceivedDate_ValueChanged(object sender, EventArgs e)
        {
            dtDateAcquired.Value = dtReceivedDate.Value;
        }

        private void txtSerialNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerialNo.BackColor = Color.Aquamarine;
        }

        private void txtSerialNo_Leave(object sender, EventArgs e)
        {
            txtSerialNo.BackColor = Color.White;
        }

        private void txtQuantity_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtQuantity.BackColor = Color.Aquamarine;
        }

        private void txtQuantity_Leave_1(object sender, EventArgs e)
        {
            txtQuantity.BackColor = Color.White;
        }

        private void txtUnitCost_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtUnitCost.BackColor = Color.Aquamarine;
        }

        private void txtUnitCost_Leave_1(object sender, EventArgs e)
        {
            txtUnitCost.BackColor = Color.White;
        }

        private void txtWarrantyVaildity_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.Aquamarine;
        }

        private void txtWarrantyVaildity_Leave_1(object sender, EventArgs e)
        {
            txtWarrantyVaildity.BackColor = Color.White;
        }

        private void txtRemarks_MouseClick_1(object sender, MouseEventArgs e)
        {
            txtReceivedBy.BackColor = Color.Aquamarine;
        }

        private void txtRemarks_Leave_1(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
        }

        private void receiviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            tabControl1.Visible = false;

            GlobalClass.GlobalIARNo = "";

            frmGetIARNo frm_GetIARNo = new frmGetIARNo();
            frm_GetIARNo.ShowDialog();


            if (!String.IsNullOrEmpty(GlobalClass.GlobalIARNo))
            {
                func_Retrieve_IAR_Details();
            }
        }

        private void cboEUL_Click(object sender, EventArgs e)
        {
            cboEUL.Items.Clear();
            func_LoadEULData();
        }

        private void cboUnits_Click(object sender, EventArgs e)
        {
            cboUnits.Items.Clear();
            func_Load_Units();
        }

        private void cboMOA_Click(object sender, EventArgs e)
        {
            cboMOA.Items.Clear();
            func_Load_MOA();
        }

        private void txtReqOffice_MouseClick(object sender, MouseEventArgs e)
        {
            txtReqOffice.BackColor = Color.Aquamarine;
        }

        private void txtReqOffice_Leave(object sender, EventArgs e)
        {
            txtReqOffice.BackColor = Color.White;
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_Save_to_Inventory_Details();
        }

        private void txtInspector_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkIsSubscribed_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //*Get End Of Service value
        //    //**get no. only from eul value
        //    var EULife = cboEUL.Text;
        //    var E_UL = String.Join("", EULife.Where(Char.IsDigit));
        //    // Add EUL to Year of Acquisition
        //    DateTime AquisitionDate = dtDateAcquired.Value;
        //    DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));
        //    dtEndofService.Value = EOS_Date;
        //}

        //private void btnTest_Click(object sender, EventArgs e)
        //{
        //    if (chkIsSubscribed.Checked == true)
        //    {
        //        MessageBox.Show("1");
        //    }
        //    else
        //    { MessageBox.Show("0"); }

        //    chkIsSubscribed.CheckState = CheckState.Unchecked;
        //}

        private void receivedItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            tabControl1.Visible = false;

            frmReceivedItems frm_Received_Items = new frmReceivedItems();
            frm_Received_Items.ShowDialog();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvItems.SelectedRows)
            {
                dgvItems.Rows.RemoveAt(item.Index);
            }
        }
        private void func_Save_to_Inventory_Details()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //Get Record Id
            string RetrieveRecordId = "Select pk_Record_Id from tbl_Receiving_Items_Head where IAR_No = ' " + GlobalClass.GlobalIARNo + "'";
            SqlCommand RecordIdFinder = new SqlCommand(RetrieveRecordId, SysCon.SystemConnect);
            SqlDataReader RecordIdReader = RecordIdFinder.ExecuteReader();
            if (RecordIdReader.Read())
            {
                RecId = RecordIdReader[0].ToString();
            }
            RecordIdReader.Close();
        }
        private void func_Get_Division_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string Division = "Select pk_Division_Id from tbl_Divisions where Unit =  '" + cboUnits.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectDivision_Id = new SqlCommand(Division, SysCon.SystemConnect);
            SqlDataReader DivisionIdReader = SelectDivision_Id.ExecuteReader();

            DivisionIdReader.Read();

            Division_Id = DivisionIdReader[0].ToString();

            DivisionIdReader.Close();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void func_Get_Service_Center_Code()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string Center_Code = "Select Center_Code from view_ServicesDivision where Unit =  '" + cboUnits.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectCenter_Code = new SqlCommand(Center_Code, SysCon.SystemConnect);

            SqlDataReader CenterCodeReader = SelectCenter_Code.ExecuteReader();

            CenterCodeReader.Read();

            CenterCode = CenterCodeReader[0].ToString();

            CenterCodeReader.Close();

            txtCenterCode.Text = CenterCode;
            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void txtPONo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFindOIC_Click(object sender, EventArgs e)
        {
            frmOIC frm_OIC = new frmOIC();
            frm_OIC.ShowDialog();
            if (!String.IsNullOrEmpty(GlobalClass.GlobalOICId))
            {
                func_Retrieve_OIC();
                txtRemarks.Focus();
            }
            else
            { btnFindOIC.Focus(); }
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
                txtAcceptedBy.Text = OICReader[2].ToString();
            }
        }
        private void updateReceivingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
        }

        private void func_Retrieve_IAR_Details()
        {
            string RetrieveIARDetails = "Select * from view_Receiving_Report where IAR_No = '"+ GlobalClass.GlobalIARNo +"'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand IARFinder = new SqlCommand(RetrieveIARDetails, SysCon.SystemConnect);
            SqlDataReader IARReader = IARFinder.ExecuteReader();

            if (IARReader.Read())
            {
                //Retrieve data for Receiving Items Header
                txtSupplier.Text = IARReader[0].ToString();
                txtDRNo.Text = IARReader[1].ToString();
                txtSINo.Text = IARReader[2].ToString();
                txtAPRNo.Text = IARReader[3].ToString();
               
                txtCenterCode.Text = IARReader[5].ToString();
                IARNo = IARReader[6].ToString();
                txtReceivedBy.Text = IARReader[7].ToString();
                dtReceivedDate.Text = IARReader[8].ToString();
                txtInspector.Text = IARReader[9].ToString();
                dtInspectionDate.Text = IARReader[10].ToString();
                txtAcceptedBy.Text = IARReader[11].ToString();
                cboMOA.Text = IARReader[32].ToString();
                txtRemarksHead.Text = IARReader[12].ToString();
                SupId = IARReader[16].ToString();
                txtReqOffice.Text = IARReader[4].ToString();
                cboStatusOfDel.Text = IARReader[34].ToString();
                dtInvoiceDate.Text = IARReader[35].ToString();

                APRNo = txtAPRNo.Text;
                Supplier = txtSupplier.Text;

                GlobalClass.GlobalSupplierId = SupId;

                //Copy Original DR,SI and Supplier Id for comparison purpose in update transaction
                DR = txtDRNo.Text;
                SI = txtSINo.Text;
                APRNo = txtAPRNo.Text;
                Supplier = txtSupplier.Text;

                btnUpdate.Visible = true;
                btnClear.Visible = true;

                btnSaveUpdate.Visible = false;

                IARNo = GlobalClass.GlobalIARNo;

                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                tabControl1.Visible = true;

                btnAddtoGrid.Enabled = false;

                //Retrive data for Receiving Item Details and load to datagrid
                func_Load_Receiving_Items_Details();
            }
            else
            {
                MessageBox.Show("Receiving Report No. doesn't exist");
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                tabControl1.Visible = false;
            }

            IARReader.Close();
        }

    
        private void func_Load_Receiving_Items_Details()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string RetrieveIARDetails2 = "Select * from view_Receiving_Report where IAR_No = '" + GlobalClass.GlobalIARNo + "'";

            SqlDataAdapter AllDetailsAdapter = new SqlDataAdapter(RetrieveIARDetails2, SysCon.SystemConnect);

            string srctbl = "view_Receiving_Report";

            DataSet RRDetailsData = new DataSet();

            AllDetailsAdapter.Fill(RRDetailsData, srctbl);

            dgvItems.Visible = false;
            dgvItems2.Visible = true;

            dgvItems2.DataSource = RRDetailsData.Tables["view_Receiving_Report"];

            dgvItems2.RowHeadersWidth = 5;

            dgvItems2.Columns[0].Visible = false;
            dgvItems2.Columns[1].Visible = false;
            dgvItems2.Columns[2].Visible = false;
            dgvItems2.Columns[3].Visible = false;
            dgvItems2.Columns[4].Visible = false;
            dgvItems2.Columns[5].Visible = false;
            dgvItems2.Columns[6].Visible = false;
            dgvItems2.Columns[7].Visible = false;
            dgvItems2.Columns[8].Visible = false;
            dgvItems2.Columns[9].Visible = false;
            dgvItems2.Columns[10].Visible = false;
            dgvItems2.Columns[11].Visible = false;
            dgvItems2.Columns[12].Visible = false;
            dgvItems2.Columns[13].Visible = false;
            dgvItems2.Columns[14].Visible = false;
            dgvItems2.Columns[15].Visible = false;
            dgvItems2.Columns[16].Visible = false;
            dgvItems2.Columns[17].Visible = false;
            dgvItems2.Columns[18].Visible = false;

            dgvItems2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        //private void generateReceivingReportToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    groupBox1.Visible = false;
        //    groupBox2.Visible = false;
        //    groupBox3.Visible = false;
        //    tabControl1.Visible = false;

        //    GlobalClass.GlobalIARNo = "";

        //    frmGetIARNo frm_GetIARNo = new frmGetIARNo();
        //    frm_GetIARNo.ShowDialog();

        //    if (!String.IsNullOrEmpty(GlobalClass.GlobalIARNo))
        //    {
        //        string RetrieveIARDetails = "Select * from view_Receiving_Report where IAR_No = '" + GlobalClass.GlobalIARNo + "'";
               
        //        //close current connection
        //        SysCon.CloseConnection();
        //        //Open connection
        //        SysCon.SystemConnect.Open();

        //        SqlCommand IARFinder = new SqlCommand(RetrieveIARDetails, SysCon.SystemConnect);
        //        SqlDataReader IARReader = IARFinder.ExecuteReader();

        //        if (IARReader.Read())
        //        {
        //            IARReader.Close();
        //            frmReportViewer PreviewDialog = new frmReportViewer("Receiving_Report", "SELECT * FROM view_Receiving_Report where IAR_No = '" + GlobalClass.GlobalIARNo + "' ");
        //            PreviewDialog.ShowDialog();
                   
        //        }
        //        else
        //        {
        //            MessageBox.Show("Receiving Report No. doesn't exist");
                
        //        }
        //        //close reader
        //        IARReader.Close();

        //        groupBox1.Visible = false;
        //        groupBox2.Visible = false;
        //        groupBox3.Visible = false;
        //        tabControl1.Visible = false;
        //    }
        //}

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDRNo.Text == "" || txtSINo.Text == "" || txtAPRNo.Text == "" || txtReqOffice.Text == "" || txtSupplier.Text == "" || txtReceivedBy.Text == "" || txtAcceptedBy.Text == "" || cboMOA.Text == "" || cboStatusOfDel.Text=="")
            {

                MessageBox.Show("Cannot continue saving! Some fields are required.", "Updating New Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Receiving Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            if (txtDRNo.Text != DR || txtSINo.Text != SI || SupId != GlobalClass.GlobalSupplierId || txtAPRNo.Text != APRNo)
                            {
                                func_Check_Duplication_Update();
                            }
                            else
                            {
                                func_Update_RR();
                                func_GenerateRR();
                                func_Reset_All();
                            }
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information displayed will be cleared.", "Update Receiving Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset_All();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_Update()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select * from tbl_Receiving_Items_Head where DR_No ='" + txtDRNo.Text + "' and SI_No = '" + txtSINo.Text + "' and fk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "' and APR_No = '"+ txtAPRNo.Text +"'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Same DR and SI under this supplier has been already used. Please check your data.", "Update Receiving Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDRNo.Focus();
                return;
            }
            else
            {
                func_Update_RR();
                func_GenerateRR();
                func_Reset_All();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Update_RR()
        {
            
            string UpdateRecord = "Update tbl_Receiving_Items_Head Set DR_No = '" + txtDRNo.Text +
                   "',SI_No = '" + txtSINo.Text +
                   "',APR_No ='" + txtAPRNo.Text+
                   "',Requisitioning_Office = '" + txtReqOffice.Text +
                   "',Responsibility_Code = '" + txtCenterCode.Text +
                   "',fk_Supplier_Id = '" + GlobalClass.GlobalSupplierId +
                   "',Received_By = '" + txtReceivedBy.Text +
                   "',Received_Date = '" + dtReceivedDate.Text +
                   "',Inspected_By = '" + txtInspector.Text +
                   "',Inspected_Date = '" + dtInspectionDate.Text +
                   "',Accepted_By = '" + txtAcceptedBy.Text +
                   "',Remarks = '" + txtRemarksHead.Text +
                   "',Status_of_Delivery = '" + cboStatusOfDel.Text +
                   "',Invoice_Date = '" + dtInvoiceDate.Text +
                   "',Mode_of_Acquisition = '" + cboMOA.Text + "' where IAR_No = '" + GlobalClass.GlobalIARNo + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateRR = new SqlCommand();
            UpdateRR.CommandType = CommandType.Text;
            UpdateRR.CommandText = UpdateRecord;
            UpdateRR.Connection = SysCon.SystemConnect;
            UpdateRR.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
               "', '" + GlobalClass.GlobalUser +
               "', '" + DateTime.Now.ToString() +
               "', 'Update Receiving Record ,IAR No. = ' + '" + GlobalClass.GlobalIARNo + "'+ ' ; DR No. :' + '" + txtDRNo.Text + "' + ' ; SI No = '+ '" + txtSINo.Text + "' + ' ;Supplier Id = ' + '" + GlobalClass.GlobalSupplierId + "')";

            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Receiving Report record has been successfully updated!", "Update Receiving Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }

    }

}
