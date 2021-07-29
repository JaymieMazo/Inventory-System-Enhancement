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
    public partial class frm_ModeofAcquisition : Form
    {
        string MOAId;
        string MOADesc;

        public frm_ModeofAcquisition()
        {
            InitializeComponent();
        }

        private void frm_StatusOfEquipment_Load(object sender, EventArgs e)
        {
            func_Load_All_MOA();
            func_Reset();

          
        }

        private void func_Reset()
        {
            txtMOA.Text = "";

            txtMOA.Focus();

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void func_Load_All_MOA()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllESL = "Select * from tbl_Mode_of_Acquisition";

            SqlDataAdapter AllESLAdapter = new SqlDataAdapter(AllESL, SysCon.SystemConnect);

            string srctbl = "tbl_Mode_of_Acquisition";

            DataSet ESLData = new DataSet();

            AllESLAdapter.Fill(ESLData, srctbl);

            dgvSOE.DataSource = ESLData.Tables["tbl_Mode_of_Acquisition"];

            dgvSOE.RowHeadersWidth = 5;

            dgvSOE.Columns[0].Visible = false;

            dgvSOE.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtMOA.Text == "")
            {

                MessageBox.Show("Cannot continue saving! Please input Mode of Acquisition Description", "Adding New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMOA.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Adding New Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_AddMOA();
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

        private void func_Check_Duplication_AddMOA()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Mode_of_Acquisition from tbl_Mode_of_Acquisition where Mode_of_Acquisition ='" + txtMOA.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Mode of Acquisition already exists!", "New Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMOA.Focus();
                return;
            }
            else
            {
                func_Add_MOA();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_MOA()
        {

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewMOA = "Insert into tbl_Mode_of_Acquisition (Mode_of_Acquisition) Values('" + txtMOA.Text + "')";

            SqlCommand AddNewMOA= new SqlCommand(NewMOA, SysCon.SystemConnect);
            AddNewMOA.ExecuteNonQuery();

            MessageBox.Show("New Mode of Acquisition has been successfully added!", "Add New Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Mode of Acquisition = ' + '" + txtMOA.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();

            func_Load_All_MOA();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMOA.Text == "")
            {
                MessageBox.Show("Please select Mode of Acquisition to update.");
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_UpdMOA();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_UpdMOA()
        {
            if (MOADesc != txtMOA.Text)
            {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();

                string CheckDuplication_MOA = "Select Mode_of_Acquisition from tbl_Mode_of_Acquisition where Mode_of_Acquisition ='" + txtMOA.Text + "'";
                SqlCommand CheckDuplicateMOACommand = new SqlCommand(CheckDuplication_MOA, SysCon.SystemConnect);

                SqlDataReader MOAReader = CheckDuplicateMOACommand.ExecuteReader();
                if (MOAReader.Read())
                {
                    MessageBox.Show("Record already exists!", "Mode of Acquisition", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMOA.Focus();
                    return;
                }
                else
                {
                    func_Update_MOA();
                }
                MOAReader.Close();
                MOAReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();

            }
        }

        private void func_Update_MOA()
        {
            string UpdateRecord = "Update tbl_Mode_of_Acquisition Set Mode_of_Acquisition = '" + txtMOA.Text + "' where pk_MOA_Id = '" + MOAId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateMOA = new SqlCommand();
            UpdateMOA.CommandType = CommandType.Text;
            UpdateMOA.CommandText = UpdateRecord;
            UpdateMOA.Connection = SysCon.SystemConnect;
            UpdateMOA.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Mode of Acquisition description = ' + '" + txtMOA.Text + "'+ ' ; ID = '+ '" + MOAId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Record has been successfully updated!", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtSearchMOA.Text = "";
            func_Reset();
            func_Load_All_MOA();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            {
                DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Existence_in_tblReceiving();
                            break;
                        }

                }

                func_Reset();
            }
        }
        private void func_Check_Existence_in_tblReceiving()
        {

            string Check_Data = "Select * from tbl_Receiving_Items_Head where Mode_Of_Acquisition = '" + MOADesc + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand DataFinder = new SqlCommand(Check_Data, SysCon.SystemConnect);
            SqlDataReader DataReader = DataFinder.ExecuteReader();

            if (DataReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Mode Of Procurement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_MOA();

            }

            DataReader.Close();
            DataReader.Dispose();

        }
        private void func_Delete_MOA()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteMOA = new SqlCommand();
                DeleteMOA.CommandText = "Delete from tbl_Mode_of_Acquisition where pk_MOA_Id = '" + MOAId + "'";
                DeleteMOA.CommandType = CommandType.Text;
                DeleteMOA.Connection = SysCon.SystemConnect;
                DeleteMOA.ExecuteNonQuery();

                MessageBox.Show("Record has been successfully deleted!", "Delete Mode of Acquisition", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtSearchMOA.Text = "";
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Mode of Acquisition = ' + '" + txtMOA.Text + "'+ ' ; Record Id = '+ '" + MOAId + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                func_Load_All_MOA();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Mode of Acquisition", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchMOA.Text = "";
            txtSearchMOA.Focus();
        }

        private void txtSearchSOE_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvSOE.DataSource).DefaultView.RowFilter = "Mode_of_Acquisition LIKE '%" + txtSearchMOA.Text + "%'";

            if (dgvSOE.RowCount <= 0)
            {
                MessageBox.Show("Record does not exists.");
                txtSearchMOA.Text = "";

            }

            if (txtSearchMOA.Text != "")
            {
                btnClear.Enabled = true;
            }

            if (txtSearchMOA.Text == "")
            {
                btnClear.Enabled = false;
            }
        }

        

        private void dgvSOE_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            func_Click_Item();
        }

        private void func_Click_Item()
        {
            MOAId = dgvSOE.CurrentRow.Cells[0].Value.ToString();
            txtMOA.Text = dgvSOE.CurrentRow.Cells[1].Value.ToString();

            MOADesc = txtMOA.Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void dgvSOE_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

      

        private void dgvSOE_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Item();
        }

     
        private void txtSOE_MouseClick(object sender, MouseEventArgs e)
        {
            txtMOA.BackColor = Color.Aquamarine;
        }

        private void txtSOE_Leave(object sender, EventArgs e)
        {
            txtMOA.BackColor = Color.White;
        }

        private void txtSearchSOE_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchMOA.BackColor = Color.Aquamarine;
        }

        private void txtSearchSOE_Leave(object sender, EventArgs e)
        {
            txtSearchMOA.BackColor = Color.White;
        }
    }
}
