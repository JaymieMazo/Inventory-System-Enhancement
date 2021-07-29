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
    public partial class frmArticles : Form
    {

        string Subcategory_Id_Org;
        string ArticleName;
        string ArticleCode;

        public frmArticles()


        {
            InitializeComponent();
        }

        private void frmArticles_Load(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmSubcategoryList frm_Subcategories = new frmSubcategoryList();
            frm_Subcategories.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalSubcategoryId))
            {
                func_Retrieve_Subcategory_Details();
            }
            else
            {
                txtSubCatName.Text = "";
                txtCategoryName.Text = "";
            }
        }

        private void func_Reset()
        {
            txtSubCatName.Text = "";
            txtCategoryName.Text = "";
            txtArticleName.Text = "";
            txtArticleCode.Text = "";

            btnDelete.Enabled = false;
            btnSaveUpdate.Text = "Save";

            btnFind.Focus();

           // GlobalClass.GlobalSubcategoryId = "";
            GlobalClass.GlobalArticleId = "";
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (GlobalClass.GlobalSubcategoryId == "")
            {
                MessageBox.Show("Please reselect subcategory detail!", "New Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnFind.Focus();
            }
            else if (txtSubCatName.Text == "" || txtCategoryName.Text == "" || txtArticleName.Text == "" || txtArticleCode.Text == "")
            {

                MessageBox.Show("Cannot continue saving! All fields are required.", "New Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnFind.Focus();
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Article", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddArticle();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Adding Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Article", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdArticle();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made.", "Updating Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                    }
                }
            }

        }

        private void func_Check_Duplication_AddArticle()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Article_Name from tbl_Article where Article_Name ='" + txtArticleName.Text + "' and fk_Subcategory_Id = '" + GlobalClass.GlobalSubcategoryId + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Article with the same data already exists!", "Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnFind.Focus();
                return;
            }
            else
            {
                func_Add_Article();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Check_Duplication_UpdArticle()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (Subcategory_Id_Org != GlobalClass.GlobalSubcategoryId)
            {
                string CheckDuplication_Subcat = "Select fk_Subcategory_Id from tbl_Article where Article_Name = '" + txtArticleName.Text + "' and fk_Subcategory_Id = '" + GlobalClass.GlobalSubcategoryId +"'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Subcat, SysCon.SystemConnect);

                SqlDataReader SubcatReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (SubcatReader.Read())
                {
                    MessageBox.Show("Article under the same subcategory already exists!", "Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnFind.Focus();
                    return;
                }
                else
                {
                    func_Update_Article();
                }
                SubcatReader.Close();
                SubcatReader.Dispose();
            }
            else if (ArticleName != txtArticleName.Text)
            {
                string CheckDuplication_Name = "Select Article_Name from tbl_Article where Article_Name = '" + txtArticleName.Text + "' and fk_Subcategory_Id = '" + GlobalClass.GlobalSubcategoryId + "'";
                SqlCommand CheckDuplicateNameCommand = new SqlCommand(CheckDuplication_Name, SysCon.SystemConnect);

                SqlDataReader NameReader = CheckDuplicateNameCommand.ExecuteReader();
                if (NameReader.Read())
                {
                    MessageBox.Show("Article Name already exists!", "Article", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSubCatName.Focus();
                    return;
                }
                else
                {
                    func_Update_Article();
                }
                NameReader.Close();
                NameReader.Dispose();
            }
       
            else
            {
                func_Update_Article();
                func_Reset();
            }

        }

        private void func_Update_Article()
        {
            string UpdateRecord = "Update tbl_Article Set Article_Code = '" + txtArticleCode.Text +
                   "',Article_Name = '" + txtArticleName.Text + "', fk_Subcategory_Id ='" + GlobalClass.GlobalSubcategoryId + "' where pk_Article_Id = '" + GlobalClass.GlobalArticleId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateArticle = new SqlCommand();
            UpdateArticle.CommandType = CommandType.Text;
            UpdateArticle.CommandText = UpdateRecord;
            UpdateArticle.Connection = SysCon.SystemConnect;
            UpdateArticle.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Artcile Name = ' + '" + txtArticleName.Text + "'+ ' ; Code = '+ '" + txtArticleCode.Text + "' + ' ; ArticleId = ' + '" + GlobalClass.GlobalArticleId + "' + ' ; SubCatID = ' + '" + GlobalClass.GlobalSubcategoryId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Article has been successfully updated!", "Update Article", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

        private void func_Add_Article()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewArticle = "Insert into tbl_Article (Article_Code,Article_Name,fk_Subcategory_Id) Values('" + txtArticleCode.Text +
               "', '" + txtArticleName.Text + "','" + GlobalClass.GlobalSubcategoryId + "')";

            SqlCommand AddNewArticle = new SqlCommand(NewArticle, SysCon.SystemConnect);
            AddNewArticle.ExecuteNonQuery();

            MessageBox.Show("New article has been successfully added!", "Add Article", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Article Name = ' + '" + txtArticleName.Text + "'+ ' ; Article Code = '+ '" + txtArticleCode.Text + "' + ' ;Subcategory Id = ' + '" + GlobalClass.GlobalSubcategoryId + "' + ' ; Subcategory = ' + '"+txtSubCatName.Text +"')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmArticleList frm_ArticleList = new frmArticleList();
            frm_ArticleList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalArticleId))
            {
                func_Retrieve_Article_Details();
                Subcategory_Id_Org = GlobalClass.GlobalSubcategoryId;
                ArticleName = txtArticleName.Text;
                ArticleCode = txtArticleCode.Text;

            }
        }

        private void func_Retrieve_Article_Details()
        {

            string RetrieveArticle = "Select Category_Name,Subcategory_Name,Article_Name, Article_Code from view_ArticleSubcat where pk_Article_Id = ' " + GlobalClass.GlobalArticleId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ArticleFinder = new SqlCommand(RetrieveArticle, SysCon.SystemConnect);
            SqlDataReader ArticleReader = ArticleFinder.ExecuteReader();

            if (ArticleReader.Read())
            {
                txtCategoryName.Text = ArticleReader[0].ToString();
                txtSubCatName.Text = ArticleReader[1].ToString();
                txtArticleName.Text = ArticleReader[2].ToString();
                txtArticleCode.Text = ArticleReader[3].ToString();

                
            }

             txtArticleName.Focus();
             btnSaveUpdate.Text = "Update";
             btnDelete.Enabled = true;


        }

        private void func_Retrieve_Subcategory_Details()
        {
            string RetrieveSubcategory = "Select Category_Name,Subcategory_Name from view_CatSubcat where pk_Subcategory_Id = ' " + GlobalClass.GlobalSubcategoryId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand SubcategoryFinder = new SqlCommand(RetrieveSubcategory, SysCon.SystemConnect);
            SqlDataReader SubcategoryReader = SubcategoryFinder.ExecuteReader();

            if (SubcategoryReader.Read())
            {

                txtSubCatName.Text = SubcategoryReader[1].ToString();
                txtCategoryName.Text = SubcategoryReader[0].ToString();

                txtArticleName.Focus();

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
            btnFind.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Article", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Check_Existence_in_Inventory_Details();
                        break;
                    }

            }

            func_Reset();
        }

        private void func_Check_Existence_in_Inventory_Details()
        {

            string Check_ID = "Select fk_Article_Id from tbl_Inventory_Details where fk_Article_Id = ' " + GlobalClass.GlobalArticleId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand IDFinder = new SqlCommand(Check_ID, SysCon.SystemConnect);
            SqlDataReader IDReader = IDFinder.ExecuteReader();

            if (IDReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_Article();

            }

            IDReader.Close();
            IDReader.Dispose();

        }

        private void func_Delete_Article()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteArticle = new SqlCommand();
                DeleteArticle.CommandText = "Delete from tbl_Article where pk_Article_Id = '" + GlobalClass.GlobalArticleId + "'";
                DeleteArticle.CommandType = CommandType.Text;
                DeleteArticle.Connection = SysCon.SystemConnect;
                DeleteArticle.ExecuteNonQuery();

                MessageBox.Show("Article has been successfully deleted!", "Delete Article", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Article Name = ' + '" + txtArticleName.Text + "' + ' ; Code = '+ '" + txtArticleCode.Text + "' + ' ; Category Type = ' + '" + txtCategoryName.Text + "'  + ' ; Subcategory = ' + '" + txtSubCatName.Text + "'+ ' ;ArticleCatId = ' + '" + GlobalClass.GlobalArticleId + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Article", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtCategoryName_MouseClick(object sender, MouseEventArgs e)
        {
            txtCategoryName.BackColor = Color.Aquamarine;
        }

        private void txtCategoryName_Leave(object sender, EventArgs e)
        {
            txtCategoryName.BackColor = Color.White;
        }

        private void txtArticleName_MouseClick(object sender, MouseEventArgs e)
        {
            txtArticleName.BackColor = Color.Aquamarine;
        }

        private void txtArticleName_Leave(object sender, EventArgs e)
        {
            txtCategoryName.BackColor = Color.White;
        }

        private void txtArticleName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtArticleCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtArticleCode.BackColor = Color.Aquamarine;
        }

        private void txtArticleCode_Leave(object sender, EventArgs e)
        {
            txtArticleCode.BackColor = Color.White;
        }

        private void txtArticleCode_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
