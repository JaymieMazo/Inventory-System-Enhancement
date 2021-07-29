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
    public partial class frmESL : Form
    {
        string ESLId;
        string ESLDesc;
        public frmESL()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void frmESL_Load(object sender, EventArgs e)
        {
            func_Load_All_ESL();
            func_Reset();
        }

        private void func_Reset()
        {
            txtESLDesc.Text = "";

            txtESLDesc.Focus();

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void func_Load_All_ESL()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllESL = "Select * from tbl_Estimated_Useful_Life";

            SqlDataAdapter AllESLAdapter = new SqlDataAdapter(AllESL, SysCon.SystemConnect);

            string srctbl = "tbl_Estimated_Useful_Life";

            DataSet ESLData = new DataSet();

            AllESLAdapter.Fill(ESLData, srctbl);

            dgvESL.DataSource = ESLData.Tables["tbl_Estimated_Useful_Life"];

            dgvESL.RowHeadersWidth = 5;

            dgvESL.Columns[0].Visible = false;

            dgvESL.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

        }

        private void txtSearchESL_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvESL.DataSource).DefaultView.RowFilter = "EUL_Name LIKE '%" + txtSearchESL.Text + "%'";

            if (dgvESL.RowCount <= 0)
            {
                MessageBox.Show("Item not exists.");
                txtSearchESL.Text = "";

            }

            if (txtSearchESL.Text != "")
            {
                btnClear.Enabled = true;
            }

            if (txtSearchESL.Text == "")
            {
                btnClear.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtESLDesc.Text == "")
            {

                MessageBox.Show("Cannot continue saving! Please input EUL Description.", "Adding New EUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtESLDesc.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Adding New EUL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_AddEUL();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Adding New EUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_AddEUL()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select EUL_Name from tbl_Estimated_Useful_Life where EUL_Name ='" + txtESLDesc.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("EUL already exists!", "New EUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtESLDesc.Focus();
                return;
            }
            else
            {
                func_Add_ESL();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_ESL()
        {

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewESL = "Insert into tbl_Estimated_Useful_Life (EUL_Name) Values('" + txtESLDesc.Text + "')";

            SqlCommand AddNewESL = new SqlCommand(NewESL, SysCon.SystemConnect);
            AddNewESL.ExecuteNonQuery();

            MessageBox.Show("New EUL has been successfully added!", "Add ESL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New ESL = ' + '" + txtESLDesc.Text + "'+ ' ; Id = '+ '" + ESLId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();

            func_Load_All_ESL();
        }

        private void dgvESL_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            func_Click_Item();
        }

        private void func_Click_Item()
        {
            ESLId = dgvESL.CurrentRow.Cells[0].Value.ToString();
            txtESLDesc.Text = dgvESL.CurrentRow.Cells[1].Value.ToString();

            ESLDesc = txtESLDesc.Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtESLDesc.Text == "")
            {
                MessageBox.Show("Please select EUL to update.");
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update EUL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_UpdEUL();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating EUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_UpdEUL()
        {
            if (ESLDesc != txtESLDesc.Text)
            {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();

                string CheckDuplication_ESL = "Select EUL_Name from tbl_Estimated_Useful_Life where EUL_Name ='" + txtESLDesc.Text + "'";
                SqlCommand CheckDuplicateESLCommand = new SqlCommand(CheckDuplication_ESL, SysCon.SystemConnect);

                SqlDataReader ESLReader = CheckDuplicateESLCommand.ExecuteReader();
                if (ESLReader.Read())
                {
                    MessageBox.Show("EUL already exists!", "EUL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtESLDesc.Focus();
                    return;
                }
                else
                {
                    func_Update_EUL();
                }
                ESLReader.Close();
                ESLReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();

            }
        }

        private void func_Update_EUL()
        {
            string UpdateRecord = "Update tbl_Estimated_Useful_Life Set EUL_Name = '" + txtESLDesc.Text + "' where pk_EUL_Id = '" + ESLId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateItems = new SqlCommand();
            UpdateItems.CommandType = CommandType.Text;
            UpdateItems.CommandText = UpdateRecord;
            UpdateItems.Connection = SysCon.SystemConnect;
            UpdateItems.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update EUL description = ' + '" + txtESLDesc.Text + "'+ ' ; ID = '+ '" + ESLId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            func_Reset();
            func_Load_All_ESL();
        }


        private void dgvESL_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

        private void dgvESL_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete EUL", MessageBoxButtons.YesNo);
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
        }
        private void func_Check_Existence_in_Inventory_Details()
        {

            string Check_ID = "Select fk_EUL_Id from tbl_Inventory_Details where fk_EUL_Id = ' " + ESLId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand IDFinder = new SqlCommand(Check_ID, SysCon.SystemConnect);
            SqlDataReader IDReader = IDFinder.ExecuteReader();

            if (IDReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete EUL Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_EUL();

            }

            IDReader.Close();
            IDReader.Dispose();

        }
        private void func_Delete_EUL()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteEUL = new SqlCommand();
                DeleteEUL.CommandText = "Delete from tbl_Estimated_Useful_Life where pk_EUL_Id = '" + ESLId + "'";
                DeleteEUL.CommandType = CommandType.Text;
                DeleteEUL.Connection = SysCon.SystemConnect;
                DeleteEUL.ExecuteNonQuery();

                MessageBox.Show("EUL has been successfully deleted!", "Delete EUL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete EUL description = ' + '" + txtESLDesc.Text + "'+ ' ; ESL Id = '+ '" + ESLId + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                func_Load_All_ESL();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete EUL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchESL.Text="";
            txtSearchESL.Focus();
        }

        private void dgvESL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtESLDesc_Leave(object sender, EventArgs e)
        {
            txtESLDesc.BackColor = Color.White;
        }

        private void txtESLDesc_MouseClick(object sender, MouseEventArgs e)
        {
            txtESLDesc.BackColor = Color.Aquamarine;
        }

        private void txtSearchESL_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchESL.BackColor = Color.Aquamarine;
        }

        private void txtSearchESL_Leave(object sender, EventArgs e)
        {
            txtSearchESL.BackColor = Color.Aquamarine;
        }
    }
}
