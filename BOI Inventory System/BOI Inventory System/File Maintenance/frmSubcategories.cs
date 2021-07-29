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

namespace BOI_Inventory_System
{
    public partial class frmSubcategories : Form
    {
        string Category_Id;
        string SubcategoryCode;
        string SubcategoryName;
        string CategoryName;
        public frmSubcategories()
        {
            InitializeComponent();
        }

        private void frmSubcategories_Load(object sender, EventArgs e)
        {
            func_Load_Categories();

            func_Reset();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (cboCategory.Text == "" || txtSubCatName.Text == "" || txtUACSCode.Text == "")
            {

                MessageBox.Show("Cannot continue saving! All fields are required.", "New Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddSubCat();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Adding Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                        DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        switch (mes)
                        {
                            case DialogResult.Yes:
                                {
                                 func_Check_Duplication_UpdSubcat();
                                break;
                                }

                            case DialogResult.No:
                                {
                                    MessageBox.Show("No changes will be made", "Updating Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                    }

                }
            }
        }


        private void func_Load_Categories()
        {
            string Categories = "Select pk_Category_Id, Category_Name from tbl_Category";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connection
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadCategories = new SqlCommand(Categories, SysCon.SystemConnect);
            SqlDataReader CategoriesReader = LoadCategories.ExecuteReader();

            while (CategoriesReader.Read())
            {
                cboCategory.Items.Add(CategoriesReader.GetValue(1));
            }

            CategoriesReader.Close();
            CategoriesReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void func_Reset()
        {
            cboCategory.SelectedIndex = -1;
            txtSubCatName.Text = "";
            txtUACSCode.Text = "";

            cboCategory.Focus();

            btnSaveUpdate.Text = "Save";
            btnDelete.Enabled = false;

            GlobalClass.GlobalSubcategoryId = "";

            SubcategoryCode = "";
            SubcategoryCode = "";

        }

        private void func_Check_Duplication_AddSubCat()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Subcategory_Code, Subcategory_Name,fk_Category_Id from tbl_Subcategory where Subcategory_Name ='"+ txtSubCatName.Text +"' and (Subcategory_Code = '" + txtUACSCode.Text + "' or fk_Category_Id = '"+ Category_Id +"')";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Subcategory with the same data already exists!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSubCatName.Focus();
                return;
            }
            else
            {
                func_Add_Subcategory();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Subcategory()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewSubCategory = "Insert into tbl_Subcategory (Subcategory_Code,Subcategory_Name,fk_Category_Id) Values('" + txtUACSCode.Text +
               "', '" + txtSubCatName.Text + "','"+ Category_Id +"')";

            SqlCommand AddNewSubCategory = new SqlCommand(NewSubCategory, SysCon.SystemConnect);
            AddNewSubCategory.ExecuteNonQuery();

            MessageBox.Show("New Subcategory has been successfully added!", "Add Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Subcategory Name = ' + '" + txtSubCatName.Text + "'+ ' ; UACS Code = '+ '" + txtUACSCode.Text + "' + 'SubcatId = ' + '" + GlobalClass.GlobalSubcategoryId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex != -1)
            { func_Get_Category_Id(); }
        }

        private void func_Get_Category_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string Categories = "Select pk_Category_Id from tbl_Category where Category_Name =  '" + cboCategory.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectCategory_Id = new SqlCommand(Categories, SysCon.SystemConnect);

            SqlDataReader CategoryIdReader = SelectCategory_Id.ExecuteReader();

            CategoryIdReader.Read();

            Category_Id = CategoryIdReader[0].ToString();

            CategoryIdReader.Close();

            //Close connection
            SysCon.SystemConnect.Close();

           // MessageBox.Show(Category_Id);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSubcategoryList frm_SubcategoryList = new frmSubcategoryList();
            frm_SubcategoryList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalSubcategoryId))
            {
                func_Retrieve_Subcategory_Details();
                func_Get_Category_Id();
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

            cboCategory.Focus();
           
        }

        private void func_Retrieve_Subcategory_Details()
        {
            string RetrieveSubcategory = "Select Category_Name,Subcategory_Name,Subcategory_Code from view_CatSubcat where pk_Subcategory_Id = ' " + GlobalClass.GlobalSubcategoryId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand SubcategoryFinder = new SqlCommand(RetrieveSubcategory, SysCon.SystemConnect);
            SqlDataReader SubcategoryReader = SubcategoryFinder.ExecuteReader();

            if (SubcategoryReader.Read())
            {

                //copy to variable for the purpose of updating comparison
                SubcategoryName = SubcategoryReader[1].ToString();
                SubcategoryCode = SubcategoryReader[2].ToString();
               
                txtSubCatName.Text = SubcategoryReader[1].ToString();
                txtUACSCode.Text = SubcategoryReader[2].ToString();
                cboCategory.Text = SubcategoryReader[0].ToString();

                CategoryName = cboCategory.Text;

                txtSubCatName.Focus();

            }
            cboCategory.Focus();
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void func_Check_Duplication_UpdSubcat()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (SubcategoryCode != txtUACSCode.Text)
            {
                string CheckDuplication_Code = "Select Subcategory_Code from tbl_Subcategory where Subcategory_Code = '" + txtUACSCode.Text + "'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Code, SysCon.SystemConnect);

                SqlDataReader CodeReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (CodeReader.Read())
                {
                    MessageBox.Show("Subcategory of the same code already exists!", "Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUACSCode.Focus();
                    return;
                }
                else
                {
                    func_Update_Subcategory();
                }
                CodeReader.Close();
                CodeReader.Dispose();
            }
            else if (SubcategoryName != txtSubCatName.Text)
            {
                string CheckDuplication_Name = "Select Subcategory_Name from tbl_Subcategory where Subcategory_Name = '" + txtSubCatName.Text + "' and fk_Category_Id = '" + Category_Id + "'";
                SqlCommand CheckDuplicateNameCommand = new SqlCommand(CheckDuplication_Name, SysCon.SystemConnect);

                SqlDataReader NameReader = CheckDuplicateNameCommand.ExecuteReader();
                if (NameReader.Read())
                {
                    MessageBox.Show("Subcategory Name already exists!", "Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSubCatName.Focus();
                    return;
                }
                else
                {
                    func_Update_Subcategory();
                }
                NameReader.Close();
                NameReader.Dispose();
            }
            else if (cboCategory.Text!= CategoryName)
                {
                string CheckDuplication_Category = "Select fk_Category_Id from tbl_Subcategory where fk_Category_Id ='" + Category_Id + "' and Subcategory_Name = '" + txtSubCatName.Text + "' ";
                // string CheckDuplication_Category = "Select Subcategory_Name , Subcategory_Code from tbl_Subcategory where fk_Category_Id = '" + GlobalClass.GlobalCategoryId + "'";
                SqlCommand CheckDuplicateCatCommand = new SqlCommand(CheckDuplication_Category, SysCon.SystemConnect);

                SqlDataReader CategoryReader = CheckDuplicateCatCommand.ExecuteReader();
                if (CategoryReader.Read())
                {
                    MessageBox.Show("Subcategory Name already exists under this category!", "Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCategory.Focus();
                    return;
                }
                else
                {
                    func_Update_Subcategory();
                }
                CategoryReader.Close();
                CategoryReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();
            }


        }

        private void func_Update_Subcategory()
        {
            string UpdateRecord = "Update tbl_Subcategory Set Subcategory_Code = '" + txtUACSCode.Text +
                   "',Subcategory_Name = '" + txtSubCatName.Text + "', fk_Category_Id ='"+ Category_Id+ "' where pk_Subcategory_Id = '" + GlobalClass.GlobalSubcategoryId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateSubcategory = new SqlCommand();
            UpdateSubcategory.CommandType = CommandType.Text;
            UpdateSubcategory.CommandText = UpdateRecord;
            UpdateSubcategory.Connection = SysCon.SystemConnect;
            UpdateSubcategory.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Subcategory Name = ' + '" + txtSubCatName.Text + "'+ ' ; Code = '+ '" + txtUACSCode.Text + "' + ' ; SubcatId = ' + '"+ GlobalClass.GlobalSubcategoryId+"')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Subcategory has been successfully updated!", "Update Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Subcategory", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_Subcategory();
                        break;
                    }

            }

            func_Reset();
        }

        private void func_Delete_Subcategory()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteSubCategory = new SqlCommand();
                DeleteSubCategory.CommandText = "Delete from tbl_Subcategory where pk_Subcategory_Id = '" + GlobalClass.GlobalSubcategoryId + "'";
                DeleteSubCategory.CommandType = CommandType.Text;
                DeleteSubCategory.Connection = SysCon.SystemConnect;
                DeleteSubCategory.ExecuteNonQuery();

                MessageBox.Show("Category has been successfully deleted!", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Subcategory Name = ' + '" + txtSubCatName.Text + "' + ' ; Code = '+ '" + txtUACSCode.Text + "' + ' ; Category Type = ' + '" + cboCategory.Text + "' + ' ;SubCatId = ' + '"+GlobalClass.GlobalSubcategoryId+"')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Subcategory", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCategory_MouseClick(object sender, MouseEventArgs e)
        {
            cboCategory.BackColor = Color.Aquamarine;
        }

        private void cboCategory_Leave(object sender, EventArgs e)
        {
            cboCategory.BackColor = Color.White;
        }

        private void txtSubCatName_MouseClick(object sender, MouseEventArgs e)
        {
            txtSubCatName.BackColor = Color.Aquamarine;
        }

        private void txtSubCatName_Leave(object sender, EventArgs e)
        {
            txtSubCatName.BackColor = Color.White;
        }

        private void txtUACSCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtUACSCode.BackColor = Color.Aquamarine;
        }

        private void txtUACSCode_Leave(object sender, EventArgs e)
        {
            txtUACSCode.BackColor = Color.White;
        }
    }
}
