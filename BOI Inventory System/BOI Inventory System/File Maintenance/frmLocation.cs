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
    public partial class frmLocation : Form
    {
        string LocationDesc, Location_Code;
        public frmLocation()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void func_Reset()
        {
            txtLocation.Text = "";

            txtLocation.Focus();

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchLocation.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtLocation.Text == "")
            {

                MessageBox.Show("Cannot continue saving! Please indicate Location.", "Adding Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSearchLocation.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Adding Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_AddLocation();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Adding Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_AddLocation()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Location_Name from tbl_Locations where Location_Name ='" + txtLocation.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Location with the same data already exists!", "New Location", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }
            else
            {
                func_Add_Location();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Location()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewLocation = "Insert into tbl_Locations (Location_Name) Values('" + txtLocation.Text+ "')";

            SqlCommand AddNewLocation = new SqlCommand(NewLocation, SysCon.SystemConnect);
            AddNewLocation.ExecuteNonQuery();

            MessageBox.Show("New location has been successfully added!", "Add Location", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Location = ' + '" + txtLocation.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            txtLocation.Text = "";

            func_Load_All_Items();
        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllItems = "Select * from tbl_Locations";

            SqlDataAdapter AllLocationsAdapter = new SqlDataAdapter(AllItems, SysCon.SystemConnect);

            string srctbl = "tbl_Locations";

            DataSet ItemsData = new DataSet();

            AllLocationsAdapter.Fill(ItemsData, srctbl);

            dgvLocation.DataSource = ItemsData.Tables["tbl_Locations"];

            dgvLocation.RowHeadersWidth = 5;

           dgvLocation.Columns[0].Visible = false;

            dgvLocation.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            func_Reset();
            func_Load_All_Items();
        }

        private void txtSearchLocation_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvLocation.DataSource).DefaultView.RowFilter = "Location_Name LIKE '%" + txtSearchLocation.Text + "%'";

            if (dgvLocation.RowCount <= 0)
            {
                MessageBox.Show("Location does not exists.");
                txtSearchLocation.Text = "";

            }

            if (txtSearchLocation.Text != "")
            {
                btnClear.Enabled = true;
            }

            if (txtSearchLocation.Text == "")
            {
                btnClear.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtLocation.Text == "")
            {
                MessageBox.Show("Please select location to update.");
            }

            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_UpdLocation();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_UpdLocation()
        {
            if (LocationDesc != txtLocation.Text)
            {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();

                string CheckDuplication_LocationDesc = "Select Location_Name from tbl_Locations where Location_Name ='" + txtLocation.Text + "'";
                SqlCommand CheckDuplicateLocationCommand = new SqlCommand(CheckDuplication_LocationDesc, SysCon.SystemConnect);

                SqlDataReader LocationReader = CheckDuplicateLocationCommand.ExecuteReader();
                if (LocationReader.Read())
                {
                    MessageBox.Show("Location already exists!", "Location Updating", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLocation.Focus();
                    return;
                }
                else
                {
                    func_Update_Item();
                }
                LocationReader.Close();
                LocationReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();
            }

        }

        private void dgvLocation_Click(object sender, EventArgs e)
        {
            func_Click_Items();
        }

        private void func_Click_Items()
        {
            Location_Code = dgvLocation.CurrentRow.Cells[0].Value.ToString();
            txtLocation.Text = dgvLocation.CurrentRow.Cells[1].Value.ToString();

            LocationDesc = txtLocation.Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Location", MessageBoxButtons.YesNo);
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

            string Check_ID = "Select fk_Location_Id from tbl_Inventory_Details where fk_Location_Id = ' " + Location_Code + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand IDFinder = new SqlCommand(Check_ID, SysCon.SystemConnect);
            SqlDataReader IDReader = IDFinder.ExecuteReader();

            if (IDReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Location Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_Location();

            }

            IDReader.Close();
            IDReader.Dispose();

        }

        private void func_Delete_Location()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteLocation = new SqlCommand();
                DeleteLocation.CommandText = "Delete from tbl_Locations where pk_Location_Id   = '" + Location_Code + "'";
                DeleteLocation.CommandType = CommandType.Text;
                DeleteLocation.Connection = SysCon.SystemConnect;
                DeleteLocation.ExecuteNonQuery();

                MessageBox.Show("Location has been successfully deleted!", "Delete Location", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Location description = ' + '" + txtLocation.Text + "'+ ' ; ID = '+ '" + Location_Code + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                func_Load_All_Items();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Location", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLocation_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void dgvLocation_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void dgvLocation_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtLocation_MouseClick(object sender, MouseEventArgs e)
        {
            txtLocation.BackColor = Color.Aquamarine;
        }

        private void txtLocation_Leave(object sender, EventArgs e)
        {
            txtLocation.BackColor = Color.White;
        }

        private void txtSearchLocation_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchLocation.BackColor = Color.Aquamarine;
        }

        private void txtSearchLocation_Leave(object sender, EventArgs e)
        {
            txtSearchLocation.BackColor = Color.White;
        }

        private void func_Update_Item()
        {
            string UpdateRecord = "Update tbl_Locations Set Location_Name = '" + txtLocation.Text +
                   "' where pk_Location_Id = '" + Location_Code + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateLocation = new SqlCommand();
            UpdateLocation.CommandType = CommandType.Text;
            UpdateLocation.CommandText = UpdateRecord;
            UpdateLocation.Connection = SysCon.SystemConnect;
            UpdateLocation.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Location description = ' + '" + txtLocation.Text + "'+ ' ; Location Code = ' + '" + Location_Code + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
            txtLocation.Focus();
            func_Load_All_Items();
        }

    }
}
