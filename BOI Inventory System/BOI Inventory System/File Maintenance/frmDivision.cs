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

namespace BOI_Inventory_System.File_Maintenance
{
    public partial class frmDivision : Form
    {
        string Service_Id,Unit;
        public frmDivision()
        {
            InitializeComponent();
        }

        private void frmDivision_Load(object sender, EventArgs e)
        {
            func_Load_Services();

            func_Reset();
        }

        private void func_Load_Services()
        {
            string Services = "Select pk_Service_Id,Service_Code from tbl_Services";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadServices = new SqlCommand(Services, SysCon.SystemConnect);
            SqlDataReader ServicesReader = LoadServices.ExecuteReader();

            while (ServicesReader.Read())
            {
                cboServices.Items.Add(ServicesReader.GetValue(1));
            }

            ServicesReader.Close();
            ServicesReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void func_Reset()
        {
            cboServices.SelectedIndex = -1;
            txtDivisionName.Text = "";
            txtDivisionCode.Text = "";
            txtUnit.Text = "";

            cboServices.Focus();

            btnSaveUpdate.Text = "Save";
            btnDelete.Enabled = false;

            Service_Id = "";

           // GlobalClass.GlobalSubcategoryId = "";

           // SubcategoryCode = "";
           // SubcategoryCode = "";

           

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (cboServices.Text == "")
            {

                MessageBox.Show("Cannot continue saving! All fields are required.", "New Division", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Division", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddDivision();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Adding Division", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Division", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdDivision();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made", "Updating Division", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                    }

                }
            }


        }

        private void func_Check_Duplication_AddDivision()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Unit from tbl_Divisions where Unit ='" + txtUnit.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Division under the same service already exists!", "Division", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDivisionName.Focus();
                return;
            }
            else
            {
                if (txtDivisionCode.Text == "")
                {
                    txtUnit.Text = "";
                    txtUnit.Text = cboServices.Text;
                }
                else
                {
                    txtUnit.Text = "";
                    txtUnit.Text = cboServices.Text + '-' + txtDivisionCode.Text;
                }
                func_Add_Division();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Division()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewDivision= "Insert into tbl_Divisions (fk_Service_Id,Division_Name,Division_Code,Unit) Values('" + Service_Id +
               "', '" + txtDivisionName.Text + "','" + txtDivisionCode.Text + "', '"+ txtUnit.Text +"')";

            SqlCommand AddNewDivision = new SqlCommand(NewDivision, SysCon.SystemConnect);
            AddNewDivision.ExecuteNonQuery();

            MessageBox.Show("New Division has been successfully added!", "Add Division", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Division Name = ' + '" + txtDivisionName.Text + "'+ ' ;  Code = '+ '" + txtDivisionCode.Text + "' + ' ; Unit ' + '"+txtUnit.Text +"' + 'Service_Id = ' + '" + Service_Id + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
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

            cboServices.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Division", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_Division();
                        break;
                    }

            }

            func_Reset();
        }

        private void func_Check_Duplication_UpdDivision()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (Unit != txtUnit.Text)
            {
                string CheckDuplication_Code = "Select Unit from tbl_Divisions where Unit = '" + txtUnit.Text + "'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Code, SysCon.SystemConnect);

                SqlDataReader CodeReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (CodeReader.Read())
                {
                    MessageBox.Show("Division under the same service already exists!", "Division", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDivisionCode.Focus();
                    return;
                }
                else
                {
                    if (txtDivisionCode.Text == "")
                    {
                        txtUnit.Text = "";
                        txtUnit.Text = cboServices.Text;
                    }
                    else
                    {
                        txtUnit.Text = "";
                        txtUnit.Text = cboServices.Text + '-' + txtDivisionCode.Text;
                    }
                    func_Update_Division();
                }
                CodeReader.Close();
                CodeReader.Dispose();
            }
            else
            {
                if (txtUnit.Text == "")
                {
                    txtUnit.Text = "";
                    txtUnit.Text = cboServices.Text;
                }
                else
                {
                  //  txtUnit.Text = "";
                    txtUnit.Text = cboServices.Text + '-' + txtDivisionCode.Text;
                }
                func_Update_Division();
                func_Reset();
            }


        }

        private void func_Update_Division()
        {
            string UpdateRecord = "Update tbl_Divisions Set fk_Service_Id = '" + Service_Id +
                   "',Division_Name = '" + txtDivisionName.Text + "', Division_Code ='" + txtDivisionCode.Text + "', Unit ='"+ txtUnit.Text + "' where pk_Division_Id = '" + GlobalClass.GlobalDivisionId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateDivision = new SqlCommand();
            UpdateDivision.CommandType = CommandType.Text;
            UpdateDivision.CommandText = UpdateRecord;
            UpdateDivision.Connection = SysCon.SystemConnect;
            UpdateDivision.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Division Name = ' + '" + txtDivisionName.Text + "'+ ' ; Code = '+ '" + txtDivisionCode.Text + "' +' ; Service Id: ' + '"+Service_Id+"'+ ' ;Unit :' + '"+ txtUnit.Text +"' + ' ; Id = ' + '" + GlobalClass.GlobalDivisionId + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Division has been successfully updated!", "Update Division", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

        private void func_Delete_Division()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteDivision = new SqlCommand();
                DeleteDivision.CommandText = "Delete from tbl_Divisions where pk_Division_Id = '" + GlobalClass.GlobalDivisionId + "'";
                DeleteDivision.CommandType = CommandType.Text;
                DeleteDivision.Connection = SysCon.SystemConnect;
                DeleteDivision.ExecuteNonQuery();

                MessageBox.Show("Division has been successfully deleted!", "Delete Division", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Division Name = ' + '" + txtDivisionName.Text + "' + ' ; Code = '+ '" + txtDivisionCode.Text + "' + ' ; Service = ' + '" + cboServices.Text + "' + ' ; Unit : ' + '"+txtUnit.Text +"' + ' ;Division Id = ' + '" + GlobalClass.GlobalDivisionId + "' )";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Division", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmDivisionList frm_DivisionList = new frmDivisionList();
            frm_DivisionList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalDivisionId))
            {
                func_Retrieve_Division_Details();
                func_Get_Service_Id();
            }
        }

        private void func_Retrieve_Division_Details()
        {
            string RetrieveDivision = "Select Service_Code,Division_Name,Division_Code, Unit from view_ServicesDivision where pk_Division_Id = ' " + GlobalClass.GlobalDivisionId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand DivisionFinder = new SqlCommand(RetrieveDivision, SysCon.SystemConnect);
            SqlDataReader DivisionReader = DivisionFinder.ExecuteReader();

            if (DivisionReader.Read())
            {

                //copy to variable for the purpose of updating comparison
                //SubcategoryName = DivisionReader[1].ToString();
                //SubcategoryCode = DivisionReader[2].ToString();

                txtDivisionName.Text = DivisionReader[1].ToString();
                txtDivisionCode.Text = DivisionReader[2].ToString();
                txtUnit.Text = DivisionReader[3].ToString();
                cboServices.Text = DivisionReader[0].ToString();

                Unit = txtUnit.Text;

                txtDivisionName.Focus();

            }
            cboServices.Focus();
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }


        private void cboServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboServices.SelectedIndex != -1)
            { func_Get_Service_Id();
              //  txtUnit.Text = cboServices.Text; //+ '-' + txtDivisionCode.Text;
            }
        }

        private void txtDivisionCode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtDivisionCode_Leave(object sender, EventArgs e)
        {
            //    if (txtUnit.Text == "")
            //    {
            //        txtUnit.Text = "";
            //        txtUnit.Text = cboServices.Text;
            //    }
            //    else
            //    {
            //      //  txtUnit.Text = "";
            //        txtUnit.Text = cboServices.Text + '-' + txtDivisionCode.Text;
            //    }

            txtDivisionCode.BackColor = Color.White;
        }

        private void txtUnit_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDivisionName_MouseClick(object sender, MouseEventArgs e)
        {
            txtDivisionName.BackColor = Color.Aquamarine;
        }

        private void txtDivisionName_Leave(object sender, EventArgs e)
        {
            txtDivisionName.BackColor = Color.White;
        }

        private void txtDivisionCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtDivisionCode.BackColor = Color.Aquamarine;
        }

        private void cboServices_Click(object sender, EventArgs e)
        {
            cboServices.Items.Clear();
            func_Load_Services();
        }

        private void func_Get_Service_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string Services = "Select pk_Service_Id from tbl_Services where Service_Code =  '" + cboServices.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectServices_Id = new SqlCommand(Services, SysCon.SystemConnect);

            SqlDataReader ServiceIdReader = SelectServices_Id.ExecuteReader();

            ServiceIdReader.Read();

            Service_Id = ServiceIdReader[0].ToString();

            ServiceIdReader.Close();

            //Close connection
            SysCon.SystemConnect.Close();

            //MessageBox.Show(Service_Id);

        }
    }
}
