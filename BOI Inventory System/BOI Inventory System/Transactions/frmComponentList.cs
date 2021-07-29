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

namespace BOI_Inventory_System.Transactions
   
{
    
    public partial class frmComponentList : Form
    {
        string EUL_Id, varAId, VarDateAcq;
        double Acc_Depreciation, Book_Value;
        string UACS_Code, Article_Code, lastTwoDigitsOfYear, Code, PropertyNo;
        //Division_Id, CenterCode;
        public frmComponentList()
        {
            InitializeComponent();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (dgvItems.RowCount == 0)
            {
                MessageBox.Show("No item to save!","Saving Component Items",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {

                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add Component Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Save_Data();
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

        private void func_Save_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //Saving Item Details :
            string NewComponent = "Insert into tbl_Sub_Items_Head Values (@fk_Inv_Id,@fk_Article_Id,@fk_Item_Code,@Serial_No,@Quantity,@Unit_Cost,@Total_Cost,@fk_EUL_Id,@Date_Acquired,@Remarks,@Stock_No,@IsSubscribed,@EOS)";

            int x = 0;
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(NewComponent, SysCon.SystemConnect))
                {
                    cmd.Parameters.AddWithValue("@fk_Inv_Id", row.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@fk_Article_Id", row.Cells[1].Value);
                    cmd.Parameters.AddWithValue("@fk_Item_Code", row.Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Serial_No", row.Cells[9].Value);
                    cmd.Parameters.AddWithValue("@Quantity", row.Cells[10].Value);
                    cmd.Parameters.AddWithValue("@Unit_Cost", row.Cells[11].Value);
                    cmd.Parameters.AddWithValue("@Total_Cost", row.Cells[12].Value);
                    cmd.Parameters.AddWithValue("@fk_EUL_Id", row.Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Date_Acquired", row.Cells[14].Value);
                    cmd.Parameters.AddWithValue("@Remarks", row.Cells[16].Value);
                    cmd.Parameters.AddWithValue("@Stock_No", row.Cells[15].Value);
                    cmd.Parameters.AddWithValue("@IsSubscribed", row.Cells[17].Value);
                    cmd.Parameters.AddWithValue("@EOS", row.Cells[18].Value);

                    string varId = dgvItems.Rows[x].Cells[0].Value.ToString();
                    varAId = dgvItems.Rows[x].Cells[1].Value.ToString();
                    string VarIid = dgvItems.Rows[x].Cells[2].Value.ToString();
                    string VarSerialNo = dgvItems.Rows[x].Cells[9].Value.ToString();
                    string VarUcost = dgvItems.Rows[x].Cells[11].Value.ToString();
                    string VarEULId = dgvItems.Rows[x].Cells[3].Value.ToString();
                    string EULife = dgvItems.Rows[x].Cells[13].Value.ToString();
                    VarDateAcq = dgvItems.Rows[x].Cells[14].Value.ToString();
                    string VarIsSubscribed = dgvItems.Rows[x].Cells[17].Value.ToString();
                    string VarEOS = dgvItems.Rows[x].Cells[18].Value.ToString();

                    //Compute Depreciation and Book Value 
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
                    string qty = dgvItems.Rows[x].Cells[10].Value.ToString();

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

                        Code = UACS_Code + '-' + Article_Code + lastTwoDigitsOfYear;

                        //Get Serial #
                        string strCount = "Select count(*) FROM view_Inventory_Details WHERE Old_Property_No like '%" + Article_Code + "%'";

                        //Close existing connection
                        SysCon.CloseConnection();

                        SqlCommand comd = new SqlCommand(strCount, SysCon.SystemConnect);
                        SysCon.SystemConnect.Open();

                        int count = Convert.ToInt32(comd.ExecuteScalar());

                        count = (Convert.ToInt32(count) + 1);

                        PropertyNo = Code + '-' + count.ToString("0000");
                        //End of code for generating Property No.
                        //MessageBox.Show("Property" +Property_No);

                 
                        //Save to tbl_Inventory_Details
                        string NewInvItem = "Insert into tbl_Inventory_SubDetails (fk_Record_Id,fk_Article_Id,fk_Item_Code,Serial_No,Unit_Cost,fk_EUL_Id,Date_Acquired,Old_Property_No,fk_Accountable_Employee_Id,fk_End_User_Id,Depreciated_Cost,Book_Value,IsSubscribed,EOS,Status) Values('" + varId +
                                 "', '" + varAId +
                                 "', '" + VarIid +
                                 "', '" + VarSerialNo +
                                 "', '" + VarUcost +
                                 "', '" + VarEULId +
                                 "', '" + VarDateAcq +
                                 "', '" + PropertyNo +
                                 "', '" + GlobalClass.GlobalOICId +
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
            MessageBox.Show("New record has been successfully added!", "Add New Component record ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset_All();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            func_Reset_All();
        }

        private void txtSerialNo_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerialNo_Leave(object sender, EventArgs e)
        {

        }

        private void btnAddtoGrid_Click(object sender, EventArgs e)
        {

        }

        private void btnFindArticle_Click(object sender, EventArgs e)
        {

        }

        private void btnFindItemDesc_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalInvItemId = "";

            frmParentItems frmParentItems = new frmParentItems();
            frmParentItems.ShowDialog();


            if (!String.IsNullOrEmpty(GlobalClass.GlobalInvItemId))
            {
                func_Retrieve_ParentItem();
                btnFindSubArticle.Focus();
            }
            else
            { txtItemDesc.Text = ""; txtOldPropertyNo.Text = ""; txtCost.Text = ""; btnFindItemDesc.Focus(); }

        }
        private void func_Retrieve_ParentItem()
        {
            string RetrieveItem = "Select Description,Unit_Cost,Old_Property_No from view_Inventory_Details where pk_Id = ' " + GlobalClass.GlobalInvItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItem, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtItemDesc.Text = ItemReader[0].ToString();
                txtCost.Text = ItemReader[1].ToString();
                txtOldPropertyNo.Text = ItemReader[2].ToString();
                

            }
        }


        private void cboEUL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboEUL_Click(object sender, EventArgs e)
        {

        }

        private void txtWarrantyVaildity_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void txtWarrantyVaildity_Leave_1(object sender, EventArgs e)
        {

        }

        private void txtRemarks_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void txtRemarks_Leave_1(object sender, EventArgs e)
        {

        }

        private void txtUnitCost_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalCost.Text = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }
        }

        private void txtUnitCost_Leave_1(object sender, EventArgs e)
        {

        }

        private void txtQuantity_MouseClick_1(object sender, MouseEventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_Leave_1(object sender, EventArgs e)
        {

        }

        private void btnFindItemDesc_Click_1(object sender, EventArgs e)
        {

        }

        private void btnFindSubArticle_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalArticleId = "";
            frmArticleList frm_ArticleList = new frmArticleList();
            frm_ArticleList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalArticleId))
            {
                func_Retrieve_Article_Details();
                btnFindSubItem.Focus();
            }
            else
            {
                txtArticle.Text = "";
                btnFindSubArticle.Focus();
            }
        }

        private void func_Retrieve_Article_Details()
        {
            string RetrieveArticle = "Select Article_Name from view_ArticleSubcat where pk_Article_Id = ' " + GlobalClass.GlobalArticleId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ArticleFinder = new SqlCommand(RetrieveArticle, SysCon.SystemConnect);
            SqlDataReader ArticleReader = ArticleFinder.ExecuteReader();

            if (ArticleReader.Read())
            {

                txtArticle.Text = ArticleReader[0].ToString();

                btnFindSubItem.Focus();

            }
            btnFindSubArticle.Focus();
        }

        private void btnFindSubItem_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalItemId = "";
            frmItemsList frmSubItems = new frmItemsList();
            frmSubItems.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalItemId))
            {
                func_Retrieve_SubItemDesc();
                txtSerialNo.Focus();
            }
            else
            { txtItemDesc.Text = ""; txtUOM.Text = ""; btnFindSubItem.Focus(); }
        }

        private void func_Retrieve_SubItemDesc()
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
                txtSubItemDesc.Text = ItemReader[1].ToString();
                txtUOM.Text = ItemReader[2].ToString();
            }
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

        private void frmComponentList_Load(object sender, EventArgs e)
        {
            func_LoadEULData();
        }

        private void btnAddtoGrid_Click_1(object sender, EventArgs e)
        {
            if (txtItemDesc.Text == "" || txtArticle.Text == "" || txtSubItemDesc.Text == "" || txtQuantity.Text == "" || txtUnitCost.Text == "" || cboEUL.Text == "")
            {

                MessageBox.Show("Cannot add to list! Some fields are required.", "Receiving Item Details ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                func_AddtoDataGrid();

                //Clear text fields

                func_Reset_Details();

                //if (txtSerialNo.Text == "")
                //{ func_AddtoDataGrid(); }
                //else
                //{ //Check Serial # Duplication
                //    //func_Check_Serial_Dup();
                //}
            }

        }


        private void func_Reset_All()
        {
            txtItemDesc.Text = "";
            txtCost.Text = "";
            txtOldPropertyNo.Text = "";

            txtSubItemDesc.Text = "";
            txtArticle.Text = "";
            txtUOM.Text = "";
            txtSerialNo.Text = "";

            chkIsSubscribed.CheckState = CheckState.Unchecked;

            txtQuantity.Text = "";
            txtUnitCost.Text = "";
            txtTotalCost.Text = "";

            cboEUL.Text = "";
            cboEUL.SelectedIndex = -1;

            dtDateAcquired.Value = DateTime.Today;

            txtStockNo.Text = "";
            txtRemarks.Text = "";

            GlobalClass.GlobalInvItemId = "";
            GlobalClass.GlobalItemId = "";
            GlobalClass.GlobalArticleId = "";

            EUL_Id = "";

            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();
            }

        }
        private void func_AddtoDataGrid()
        {
            int CurrentRow = dgvItems.Rows.Add();

            {
                //additems to datagrid
                dgvItems.Rows[CurrentRow].Cells[0].Value = GlobalClass.GlobalInvItemId;
                dgvItems.Rows[CurrentRow].Cells[1].Value = GlobalClass.GlobalArticleId;
                dgvItems.Rows[CurrentRow].Cells[2].Value = GlobalClass.GlobalItemId;
                dgvItems.Rows[CurrentRow].Cells[3].Value = EUL_Id;
                dgvItems.Rows[CurrentRow].Cells[4].Value = txtItemDesc.Text;
                dgvItems.Rows[CurrentRow].Cells[5].Value = txtOldPropertyNo.Text;
                dgvItems.Rows[CurrentRow].Cells[6].Value = txtArticle.Text;
                dgvItems.Rows[CurrentRow].Cells[7].Value = txtSubItemDesc.Text;
                dgvItems.Rows[CurrentRow].Cells[8].Value = txtUOM.Text;
                dgvItems.Rows[CurrentRow].Cells[9].Value = txtSerialNo.Text;
                dgvItems.Rows[CurrentRow].Cells[10].Value = txtQuantity.Text;
                dgvItems.Rows[CurrentRow].Cells[11].Value = txtUnitCost.Text;
                dgvItems.Rows[CurrentRow].Cells[12].Value = txtTotalCost.Text;
                dgvItems.Rows[CurrentRow].Cells[13].Value = cboEUL.Text;
                dgvItems.Rows[CurrentRow].Cells[14].Value = dtDateAcquired.Text;
                dgvItems.Rows[CurrentRow].Cells[15].Value = txtStockNo.Text;
                dgvItems.Rows[CurrentRow].Cells[16].Value = txtRemarks.Text;

                //Additional Field to determine if the item is subscribed/leased
                //Save 1 if Subscribed , 0 if not
                if (chkIsSubscribed.Checked == true)
                { dgvItems.Rows[CurrentRow].Cells[17].Value = "1"; }
                else
                { dgvItems.Rows[CurrentRow].Cells[17].Value = "0"; }

                //Additional field to determine subscription end date , applicable for software subscribed only - value = Date of Acquisition + Estimated Useful Life
                //*Get End Of Service value
                //**get no. only from eul value
                var EULife = cboEUL.Text;
                var E_UL = String.Join("", EULife.Where(Char.IsDigit));
                // Add EUL to Year of Acquisition
                DateTime AquisitionDate = dtDateAcquired.Value;
                DateTime EOS_Date = AquisitionDate.AddYears(Convert.ToInt32(E_UL));

                //Add value to datagrid
                dgvItems.Rows[CurrentRow].Cells[18].Value = EOS_Date;

            }
        }

        private void cboEUL_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboEUL.SelectedIndex != -1)
            { func_Get_EUL_Id(); }
        }
        private void func_Reset_Details()
        {


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

        private void txtTotalCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalCost.Text = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }
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

            try
            {
                txtTotalCost.Text = (Convert.ToInt32(txtQuantity.Text) * Convert.ToInt32(txtUnitCost.Text)).ToString();
            }
            catch (System.FormatException)
            { }

        }
    }
}
