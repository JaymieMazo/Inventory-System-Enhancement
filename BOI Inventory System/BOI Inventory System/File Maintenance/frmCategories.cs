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
    public partial class frmCategories : Form
    {
        string CategoryCode;
        string CategoryName;
        public frmCategories()
        {
            InitializeComponent();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "" || txtCode.Text == "")
            {
                MessageBox.Show("Category Name and Code are required!");
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Category", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddCat();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost", "Adding Category",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Category", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdCat();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made", "Updating Category",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                break;
                            }
                    }
                }
            }
            func_Reset();

        }

        private void func_Add_Category()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewCategory = "Insert into tbl_Category (Category_Code,Category_Name) Values('" + txtCode.Text +
               "', '" + txtCategoryName.Text + "')";

            SqlCommand AddNewCategory = new SqlCommand(NewCategory, SysCon.SystemConnect);
            AddNewCategory.ExecuteNonQuery();

            MessageBox.Show("New category has been successfully added!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Category Name = ' + '" + txtCategoryName.Text +"'+ ' ; Code = '+ '" + txtCode.Text +"')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();

        }

        private void func_Update_Category()
        {
            string UpdateRecord = "Update tbl_Category Set Category_Code = '" + txtCode.Text +
                    "',Category_Name = '" + txtCategoryName.Text + "' where pk_Category_Id = '" + GlobalClass.GlobalCategoryId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateCategory = new SqlCommand();
            UpdateCategory.CommandType = CommandType.Text;
            UpdateCategory.CommandText = UpdateRecord;
            UpdateCategory.Connection = SysCon.SystemConnect;
            UpdateCategory.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Category Name = ' + '" + txtCategoryName.Text + "'+ ' ; Code = '+ '" + txtCode.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Category has been successfully updated!", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

        private void func_Check_Duplication_AddCat()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Category_Code, Category_Name from tbl_Category where Category_Name = '" + txtCategoryName.Text + "'or Category_Code = '" + txtCode.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Category already exists!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }
            else
            {
                func_Add_Category();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Check_Duplication_UpdCat()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (CategoryCode != txtCode.Text)
            {
                string CheckDuplication_Code = "Select Category_Code from tbl_Category where Category_Code = '" + txtCode.Text + "'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Code, SysCon.SystemConnect);

                SqlDataReader CodeReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (CodeReader.Read())
                {
                    MessageBox.Show("Category Code already exists!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }
                else
                {
                    func_Update_Category();
                }
                CodeReader.Close();
                CodeReader.Dispose();
            }
            else if (CategoryName != txtCategoryName.Text)
            {
                string CheckDuplication_Name = "Select Category_Name from tbl_Category where Category_Name = '" + txtCategoryName.Text + "'";
                SqlCommand CheckDuplicateNameCommand = new SqlCommand(CheckDuplication_Name, SysCon.SystemConnect);

                SqlDataReader NameReader = CheckDuplicateNameCommand.ExecuteReader();
                if (NameReader.Read())
                {
                    MessageBox.Show("Category Name already exists!", "Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategoryName.Focus();
                    return;
                }
                else
                {
                    func_Update_Category();
                }
                NameReader.Close();
                NameReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();
            }
           

        }
    

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Category", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_Category();
                        break;
                    }
                
            }

            func_Reset();
        }

        private void func_Delete_Category()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteCategory = new SqlCommand();
                DeleteCategory.CommandText = "Delete from tbl_Category where pk_Category_Id = '" + GlobalClass.GlobalCategoryId + "'";
                DeleteCategory.CommandType = CommandType.Text;
                DeleteCategory.Connection = SysCon.SystemConnect;
                DeleteCategory.ExecuteNonQuery();

                MessageBox.Show("Category has been successfully deleted!", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Category Name = ' + '" + txtCategoryName.Text + "'+ ' ; Code = '+ '" + txtCode.Text + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            //Clear Fields
            func_Reset();
        }

        private void func_Reset()
        {
            //Clear Text Fields
            txtCategoryName.Text="";
            txtCode.Text = "";

            btnDelete.Enabled = false;

            btnSaveUpdate.Text = "Save";

            txtCategoryName.Focus();

            GlobalClass.GlobalCategoryId = "";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmCategoryList frm_CategorieList = new frmCategoryList();
            frm_CategorieList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalCategoryId))
            {
                func_Retrieve_Category_Details ();
            }

        }

        private void func_Retrieve_Category_Details()
        {
            string RetrieveCategory = "Select Category_Code,Category_Name from tbl_Category where pk_Category_Id = ' " + GlobalClass.GlobalCategoryId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand CategoryFinder = new SqlCommand(RetrieveCategory, SysCon.SystemConnect);
            SqlDataReader CategoryReader = CategoryFinder.ExecuteReader();

            if (CategoryReader.Read())
            {

                CategoryCode = CategoryReader[0].ToString();
                CategoryName = CategoryReader[1].ToString();

                txtCode.Text= CategoryReader[0].ToString();
                txtCategoryName.Text = CategoryReader[1].ToString();

                txtCategoryName.Focus();
               
            }
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear text fields?", "Reset", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset(); 
                        break;
                    }

            }

            txtCategoryName.Focus();
        }

        private void txtCategoryName_MouseClick(object sender, MouseEventArgs e)
        {
            txtCategoryName.BackColor = Color.Aquamarine;
        }

        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            txtCategoryName.BackColor = Color.White;
        }

        private void txtCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCode.BackColor = Color.Aquamarine;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            txtCode.BackColor = Color.White;
        }
    }
}
