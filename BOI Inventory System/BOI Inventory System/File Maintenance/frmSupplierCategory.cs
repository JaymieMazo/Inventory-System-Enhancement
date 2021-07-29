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
    public partial class frmSupplierCategory : Form
    {
        string SupCatId;
        string SupCatDesc;

        public frmSupplierCategory()
        {
            InitializeComponent();
        }

        private void frmSupplierCategory_Load(object sender, EventArgs e)
        {
            func_Load_All_SupCat();
            func_Reset();
            txtSupCat.Focus();

        }

        private void func_Reset()
        {
            txtSupCat.Text = "";

            txtSupCat.Focus();

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void func_Load_All_SupCat()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllSupCat = "Select * from tbl_Supplier_Category";

            SqlDataAdapter AllSCAdapter = new SqlDataAdapter(AllSupCat, SysCon.SystemConnect);

            string srctbl = "tbl_Supplier_Category";

            DataSet SupCatData = new DataSet();

            AllSCAdapter.Fill(SupCatData, srctbl);

            dgvSupCat.DataSource = SupCatData.Tables["tbl_Supplier_Category"];

            dgvSupCat.RowHeadersWidth = 5;

            dgvSupCat.Columns[0].Visible = false;

            dgvSupCat.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSupCat.Text == "")
            {

                MessageBox.Show("Cannot continue saving! Please input Supplier Category", "Adding New Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupCat.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Adding New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_AddSupCat();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Adding New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_AddSupCat()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Category_Name from tbl_Supplier_Category where Category_Name ='" + txtSupCat.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Status already exists!", "New Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupCat.Focus();
                return;
            }
            else
            {
                func_Add_SupCat();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_SupCat()
        {

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewSupCat = "Insert into tbl_Supplier_Category (Category_Name) Values('" + txtSupCat.Text + "')";

            SqlCommand AddNewSupCat = new SqlCommand(NewSupCat, SysCon.SystemConnect);
            AddNewSupCat.ExecuteNonQuery();

            MessageBox.Show("New category has been successfully added!", "Add New Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Supplier Category = ' + '" + txtSupCat.Text + "'+ ' ; Id = '+ '" + SupCatId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();

            func_Load_All_SupCat();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtSupCat.Text == "")
            {
                MessageBox.Show("Please select Supplier Category to update.");
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Supplier Category", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_UpdSupCat();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_UpdSupCat()
        {
            if (SupCatId != txtSupCat.Text)
            {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();

                string CheckDuplication_SupCat = "Select Category_Name from tbl_Supplier_Category where Category_Name ='" + txtSupCat.Text + "'";
                SqlCommand CheckDuplicateSCCommand = new SqlCommand(CheckDuplication_SupCat, SysCon.SystemConnect);

                SqlDataReader SupCatReader = CheckDuplicateSCCommand.ExecuteReader();
                if (SupCatReader.Read())
                {
                    MessageBox.Show("Supplier Category already exists!", "Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupCat.Focus();
                    return;
                }
                else
                {
                    func_Update_SOE();
                }
                SupCatReader.Close();
                SupCatReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();

            }
        }

        private void func_Update_SOE()
        {
            string UpdateRecord = "Update tbl_Supplier_Category Set Category_Name = '" + txtSupCat.Text + "' where pk_Sup_Category_Id = '" + SupCatId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateSupcat = new SqlCommand();
            UpdateSupcat.CommandType = CommandType.Text;
            UpdateSupcat.CommandText = UpdateRecord;
            UpdateSupcat.Connection = SysCon.SystemConnect;
            UpdateSupcat.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Supplier Category = ' + '" + txtSupCat.Text + "'+ ' ; ID = '+ '" + SupCatId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item has been successfully updated!", "Update Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSearchSupCat.Text = "";
            func_Reset();
            func_Load_All_SupCat();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Supplier Category", MessageBoxButtons.YesNo);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Existence_in_tbl_Supplier();
                            break;
                        }

                }

                func_Reset();
            }
        }

        private void func_Check_Existence_in_tbl_Supplier()
        {

            string Check_Data = "Select fk_Sup_Category_Id from tbl_Supplier where fk_Sup_Category_Id = ' " + SupCatId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand DataFinder = new SqlCommand(Check_Data, SysCon.SystemConnect);
            SqlDataReader DataReader = DataFinder.ExecuteReader();

            if (DataReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_SupCat();

            }

            DataReader.Close();
            DataReader.Dispose();

        }

        private void func_Delete_SupCat()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteSupCat = new SqlCommand();
                DeleteSupCat.CommandText = "Delete from tbl_Supplier_Category where pk_Sup_Category_Id = '" + SupCatId + "'";
                DeleteSupCat.CommandType = CommandType.Text;
                DeleteSupCat.Connection = SysCon.SystemConnect;
                DeleteSupCat.ExecuteNonQuery();

                MessageBox.Show("Supplier Category has been successfully deleted!", "Delete Supplier Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSearchSupCat.Text = "";
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Supplier Category = ' + '" + txtSupCat.Text + "'+ ' ; Supplier Category Id = '+ '" + SupCatId + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                func_Load_All_SupCat();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Status Equipment", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchSupCat.Text = "";
            txtSearchSupCat.Focus();
        }

        private void txtSearchSupCat_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvSupCat.DataSource).DefaultView.RowFilter = "Category_Name LIKE '%" + txtSearchSupCat.Text + "%'";

            if (dgvSupCat.RowCount <= 0)
            {
                MessageBox.Show("Record not exists.");
                txtSearchSupCat.Text = "";

            }

            if (txtSearchSupCat.Text != "")
            {
                btnClear.Enabled = true;
            }

            if (txtSearchSupCat.Text == "")
            {
                btnClear.Enabled = false;
            }
        }

        private void func_Click_Item()
        {
            SupCatId = dgvSupCat.CurrentRow.Cells[0].Value.ToString();
            txtSupCat.Text = dgvSupCat.CurrentRow.Cells[1].Value.ToString();

            SupCatDesc = txtSupCat.Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void dgvSupCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSupCat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            func_Click_Item();
        }

        private void dgvSupCat_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

        private void dgvSupCat_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

        private void txtSupCat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSupCat_MouseClick(object sender, MouseEventArgs e)
        {
            txtSupCat.BackColor = Color.Aquamarine;
        }

        private void txtSupCat_Leave(object sender, EventArgs e)
        {
            txtSupCat.BackColor = Color.White;
        }

        private void txtSearchSupCat_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchSupCat.BackColor = Color.Aquamarine;
        }

        private void txtSearchSupCat_Leave(object sender, EventArgs e)
        {
            txtSearchSupCat.BackColor = Color.White;
        }
    }
}
