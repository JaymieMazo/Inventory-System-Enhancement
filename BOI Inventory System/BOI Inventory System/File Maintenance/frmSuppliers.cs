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

    public partial class frmSuppliers : Form
    {
        string SupCategory_Id;
        string SupCategory_Id2;
        string SupplierName;
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (cboSupCat.Text == "" || txtSupplierName.Text == "" || txtAddress.Text == "" || txtContactNo.Text == "" || txtContactPerson.Text == "" || txtTIN.Text == "")
            {
                MessageBox.Show("Cannot continue saving! Fields are required.", "New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddSupplier();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Add New Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Supplier", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdSupplier();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made", "Updating Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                    }

                }
            }
        }
        private void func_Check_Duplication_AddSupplier()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Supplier_Name from tbl_Supplier where Supplier_Name ='" + txtSupplierName.Text + "' and fk_Sup_Category_Id = '" + SupCategory_Id + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Supplier under the same category already exists!", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return;
            }
            else
            {
                func_Add_Supplier();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Supplier()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewSupplier = "Insert into tbl_Supplier (fk_Sup_Category_Id,Supplier_Name,Address,Contact_No,Contact_Person,TIN,PHILGEPS_Reg_No) Values('" + SupCategory_Id +
               "', '" + txtSupplierName.Text + "','" + txtAddress.Text + "','" + txtContactNo.Text + "','" + txtContactPerson.Text + "','" + txtTIN.Text + "','" + txtRegNo.Text + "')";

            SqlCommand AddNewSupplier = new SqlCommand(NewSupplier, SysCon.SystemConnect);
            AddNewSupplier.ExecuteNonQuery();

            MessageBox.Show("New supplier has been successfully added!", "Add Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Supplier Name = ' + '" + txtSupplierName.Text + "'+ ' ; Category = '+ '" + cboSupCat.Text + "' + '; Address = ' + '" + txtAddress.Text + "' + ' ;Contact No = ' + '" + txtContactNo.Text + "' + ' ;Contact Person = ' + '" + txtContactPerson.Text + "' + ' ; TIN = ' + '" + txtTIN.Text + "' + ' ; RegNo = ' + '" + txtRegNo.Text + "' )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
        }

        private void func_Check_Duplication_UpdSupplier()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (SupCategory_Id != SupCategory_Id2)
            {
                string CheckDuplication = "Select Supplier_Name from tbl_Supplier where Supplier_Name = '" + txtSupplierName.Text + "' and fk_Sup_Category_Id = '"+ SupCategory_Id +"'";
                SqlCommand CheckDuplicateCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

                SqlDataReader SupplierReader = CheckDuplicateCommand.ExecuteReader();
                if (SupplierReader.Read())
                {
                    MessageBox.Show("Supplier name  of the same category already exists!", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;
                }
                else
                {
                    func_Update_Supplier();
                }
                SupplierReader.Close();
                SupplierReader.Dispose();
            }
            else if (SupplierName != txtSupplierName.Text)
            {
                string CheckDuplication = "Select Supplier_Name from tbl_Supplier where Supplier_Name = '" + txtSupplierName.Text + "' and fk_Sup_Category_Id = '" + SupCategory_Id + "'";
                SqlCommand CheckDuplicateCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

                SqlDataReader SupplierReader = CheckDuplicateCommand.ExecuteReader();
                if (SupplierReader.Read())
                {
                    MessageBox.Show("Supplier name  of the same category already exists!", "Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;
                }
                else
                {
                    func_Update_Supplier();
                }
                SupplierReader.Close();
                SupplierReader.Dispose();
            }
         
            else
            {
                func_Update_Supplier();
            }


        }

        private void func_Update_Supplier()
        {
            string UpdateRecord = "Update tbl_Supplier Set Supplier_Name = '" + txtSupplierName.Text +
                   "',fk_Sup_Category_Id = '" + SupCategory_Id + "', Address  ='" + txtAddress.Text + "' , Contact_No  ='" + txtContactNo.Text + "', Contact_Person  ='" + txtContactPerson.Text + "' , TIN  ='" + txtTIN.Text + "' , PHILGEPS_Reg_No  ='" + txtRegNo.Text + "'where pk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateSupplier = new SqlCommand();
            UpdateSupplier.CommandType = CommandType.Text;
            UpdateSupplier.CommandText = UpdateRecord;
            UpdateSupplier.Connection = SysCon.SystemConnect;
            UpdateSupplier.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Supplier Name = ' + '" + txtSupplierName.Text + "'+ ' ; Category = '+ '" + cboSupCat.Text + "' + ' ; Id = '+ '" + GlobalClass.GlobalSupplierId + "' + '; Address = ' + '" + txtAddress.Text + "' + ' ;Contact No = ' + '" + txtContactNo.Text + "' + ' ;Contact Person = ' + '" + txtContactPerson.Text + "' + ' ; TIN = ' + '" + txtTIN.Text + "' +' ; RegNo = ' + '" + txtRegNo.Text + "' )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Supplier has been successfully updated!", "Update Supplier", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            func_Load_Supplier_Categories();

            func_Reset();
        }

        private void func_Load_Supplier_Categories()
        {
            string SupCategories = "Select pk_Sup_Category_Id,Category_Name from tbl_Supplier_Category";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadCategories = new SqlCommand(SupCategories, SysCon.SystemConnect);
            SqlDataReader CategoriesReader = LoadCategories.ExecuteReader();

            while (CategoriesReader.Read())
            {
                cboSupCat.Items.Add(CategoriesReader.GetValue(1));
            }

            CategoriesReader.Close();
            CategoriesReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void func_Reset()
        {
            cboSupCat.Focus();

            cboSupCat.Text = "";
            txtSupplierName.Text = "";
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtContactPerson.Text = "";
            txtTIN.Text = "";
            txtRegNo.Text = "";

            cboSupCat.SelectedIndex = -1;

            btnSaveUpdate.Text = "Save";
            btnDelete.Enabled = false;

            SupCategory_Id = "";
            SupCategory_Id2 = "";

        }

        private void cboSupCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSupCat.SelectedIndex != -1)
            { func_Get_SupCategory_Id(); }
        }

        private void func_Get_SupCategory_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string SupCategories = "Select pk_Sup_Category_Id from tbl_Supplier_Category where Category_Name =  '" + cboSupCat.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectSupCategory_Id = new SqlCommand(SupCategories, SysCon.SystemConnect);

            SqlDataReader CategoryIdReader = SelectSupCategory_Id.ExecuteReader();

            CategoryIdReader.Read();

            SupCategory_Id = CategoryIdReader[0].ToString();

            CategoryIdReader.Close();

            //Close connection
            SysCon.SystemConnect.Close();

            // MessageBox.Show(Category_Id);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Supplier", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_Supplier();
                        break;
                    }

            }

            func_Reset();
        }

        private void func_Check_Existence_in_tbl_Inventory_Details()
        {

            string Check_Data = "Select fk_Supplier_Id from tbl_Inventory_Details where fk_Supplier_Id = ' " + GlobalClass.GlobalSupplierId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand DataFinder = new SqlCommand(Check_Data, SysCon.SystemConnect);
            SqlDataReader DataReader = DataFinder.ExecuteReader();

            if (DataReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_Supplier();

            }

            DataReader.Close();
            DataReader.Dispose();

        }

        private void func_Delete_Supplier()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteSupplier = new SqlCommand();
                DeleteSupplier.CommandText = "Delete from tbl_Supplier where pk_Supplier_Id = '" + GlobalClass.GlobalSupplierId + "'";
                DeleteSupplier.CommandType = CommandType.Text;
                DeleteSupplier.Connection = SysCon.SystemConnect;
                DeleteSupplier.ExecuteNonQuery();

                MessageBox.Show("Supplier has been successfully deleted!", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //Insert  Activity to audit trail
                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Supplier Name = ' + '" + txtSupplierName.Text + "'+ ' ; Category = '+ '" + cboSupCat.Text + "' + ' ; Id = '+ '" + GlobalClass.GlobalSupplierId + "' + '; Address = ' + '" + txtAddress.Text + "' + ' ;Contact No = ' + '" + txtContactNo.Text + "' + ' ;Contact Person = ' + '" + txtContactPerson.Text + "' + ' ; TIN = ' + '" + txtTIN.Text + "' +' ; RegNo = ' + '" + txtRegNo.Text + "' )";

                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmSupplierList frm_SupplierList = new frmSupplierList();
            frm_SupplierList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalSupplierId))
            {
                func_Retrieve_Supplier_Details();
             //   func_Get_Category_Id();
            }
        }

        private void func_Retrieve_Supplier_Details()
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

                SupCategory_Id2 = SupplierReader[1].ToString();
                txtSupplierName.Text = SupplierReader[3].ToString();
                txtAddress.Text = SupplierReader[4].ToString();
                txtContactNo.Text = SupplierReader[5].ToString();
                txtContactPerson.Text = SupplierReader[6].ToString();
                txtTIN.Text = SupplierReader[7].ToString();
                txtRegNo.Text = SupplierReader[8].ToString();

                cboSupCat.Text = SupplierReader[2].ToString();
                
                //copy to variable for comparison in updating
                SupCategory_Id = SupCategory_Id2;
                SupplierName = txtSupplierName.Text;

                cboSupCat.Focus();

            }
            cboSupCat.Focus();
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void cboSupCat_MouseClick(object sender, MouseEventArgs e)
        {
            cboSupCat.BackColor = Color.Aquamarine;
        }

        private void cboSupCat_Leave(object sender, EventArgs e)
        {
            cboSupCat.BackColor = Color.White;
        }

        private void txtSupplierName_MouseClick(object sender, MouseEventArgs e)
        {
            txtSupplierName.BackColor = Color.Aquamarine;
        }

        private void txtSupplierName_Leave(object sender, EventArgs e)
        {
            txtSupplierName.BackColor = Color.White;
        }

        private void txtAddress_MouseClick(object sender, MouseEventArgs e)
        {
            txtAddress.BackColor = Color.Aquamarine;
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtAddress.BackColor = Color.White;
        }

        private void txtContactNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtContactNo.BackColor = Color.Aquamarine;
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            txtContactNo.BackColor = Color.White;
        }

        private void txtContactPerson_MouseClick(object sender, MouseEventArgs e)
        {
            txtContactPerson.BackColor = Color.Aquamarine;
        }

        private void txtContactPerson_Leave(object sender, EventArgs e)
        {
            txtContactPerson.BackColor = Color.White;
        }

        private void txtTIN_MouseClick(object sender, MouseEventArgs e)
        {
            txtTIN.BackColor = Color.Aquamarine;
        }

        private void txtTIN_Leave(object sender, EventArgs e)
        {
            txtTIN.BackColor = Color.White;
        }

        private void txtRegNo_MouseClick(object sender, MouseEventArgs e)
        {
            txtRegNo.BackColor = Color.Aquamarine;
        }

        private void txtRegNo_Leave(object sender, EventArgs e)
        {
            txtRegNo.BackColor = Color.White;
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
