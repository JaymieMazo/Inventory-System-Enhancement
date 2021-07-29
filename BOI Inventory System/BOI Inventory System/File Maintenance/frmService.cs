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
    public partial class frmService : Form
    {
        string ServiceName, ServiceCode,Center_Code;
        public frmService()
        {
            InitializeComponent();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (txtServiceName.Text == "" || txtServiceCode.Text == "" || txtCenterCode.Text=="")
            {
                MessageBox.Show("All fields are required!");
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Service", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddSvc();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost", "Adding Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Service", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdSvc();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made", "Updating Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                    }
                }

                func_Reset();
            }
     
        }


        private void func_Reset()
        {
            //Clear Text Fields
            txtServiceName.Text = "";
            txtServiceCode.Text = "";
            txtCenterCode.Text = "";

            btnDelete.Enabled = false;

            btnSaveUpdate.Text = "Save";

            txtServiceName.Focus();

        }

        private void func_Check_Duplication_AddSvc()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Service_Name, Service_Code from tbl_Services where Service_Name = '" + txtServiceName.Text + "'or Service_Code = '" + txtServiceCode.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Service already exists!", "Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtServiceName.Focus();
                return;
            }
            else
            {
                func_Add_Service();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Service()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewService = "Insert into tbl_Services (Service_Name,Service_Code,Center_Code) Values('" + txtServiceName.Text +
               "', '" + txtServiceCode.Text + "' , '"+ txtCenterCode.Text +"')";

            SqlCommand AddNewService = new SqlCommand(NewService, SysCon.SystemConnect);
            AddNewService.ExecuteNonQuery();

            MessageBox.Show("New service has been successfully added!", "Add Service Details", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Service Name = ' + '" + txtServiceName.Text + "'+ ' ; Code = '+ '" + txtServiceCode.Text + "'+ ' ; Center Code = '+ '" + txtCenterCode.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();

        }




        private void func_Check_Duplication_UpdSvc()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (ServiceCode != txtServiceCode.Text)
            {
                string CheckDuplication_Code = "Select Service_Code from tbl_Services where Service_Code = '" + txtServiceCode.Text + "'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Code, SysCon.SystemConnect);

                SqlDataReader CodeReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (CodeReader.Read())
                {
                    MessageBox.Show("Service Code already exists!", "Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceCode.Focus();
                    return;
                }
                else
                {
                    func_Update_Service();
                }
                CodeReader.Close();
                CodeReader.Dispose();
            }
            else if (ServiceName != txtServiceName.Text)
            {
                string CheckDuplication_Name = "Select Service_Name from tbl_Services where Service_Name = '" + txtServiceName.Text + "'";
                SqlCommand CheckDuplicateNameCommand = new SqlCommand(CheckDuplication_Name, SysCon.SystemConnect);

                SqlDataReader NameReader = CheckDuplicateNameCommand.ExecuteReader();
                if (NameReader.Read())
                {
                    MessageBox.Show("Service Name already exists!", "Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtServiceName.Focus();
                    return;
                }
                else
                {
                    func_Update_Service();
                }
                NameReader.Close();
                NameReader.Dispose();
            }
             
            else if (Center_Code != txtCenterCode.Text)
            {
                    func_Update_Service();
            }

            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();
            }


        }

        private void func_Update_Service()
        {
            string UpdateRecord = "Update tbl_Services Set Service_Name = '" + txtServiceName.Text +
                    "',Service_Code = '" + txtServiceCode.Text + "',Center_Code = '" + txtCenterCode.Text + "' where pk_Service_Id = '" + GlobalClass.GlobalServiceId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateService = new SqlCommand();
            UpdateService.CommandType = CommandType.Text;
            UpdateService.CommandText = UpdateRecord;
            UpdateService.Connection = SysCon.SystemConnect;
            UpdateService.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Service Name = ' + '" + txtServiceName.Text + "'+ ' ; Code = '+ '" + txtServiceCode.Text + "' + ' ; Center Code = '+ '" + txtCenterCode.Text + "' + ' ;Id = ' + '" + GlobalClass.GlobalServiceId +"')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Service has been successfully updated!", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            txtServiceName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Service", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Check_Existence_in_Divisions();
                        break;
                    }

            }

            func_Reset();
        }
        private void func_Check_Existence_in_Divisions()
        {

            string Check_ID = "Select fk_Service_Id from tbl_Divisions where fk_Service_Id = ' " + GlobalClass.GlobalServiceId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand IDFinder = new SqlCommand(Check_ID, SysCon.SystemConnect);
            SqlDataReader IDReader = IDFinder.ExecuteReader();

            if (IDReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_Service();

            }

            IDReader.Close();
            IDReader.Dispose();

        }

        private void func_Delete_Service()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteService = new SqlCommand();
                DeleteService.CommandText = "Delete from tbl_Services where pk_Service_Id = '" + GlobalClass.GlobalServiceId + "'";
                DeleteService.CommandType = CommandType.Text;
                DeleteService.Connection = SysCon.SystemConnect;
                DeleteService.ExecuteNonQuery();

                MessageBox.Show("Service has been successfully deleted!", "Delete Service", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Service Name = ' + '" + txtServiceName.Text + "'+ ' ; Code = '+ '" + txtServiceCode.Text + "' + ' ; Center Code = '+ '" + txtCenterCode.Text + "' + ' ; Id =' + '" + GlobalClass.GlobalServiceId+"')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmServiceList frm_ServiceList = new frmServiceList();
            frm_ServiceList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalServiceId))
            {
                func_Retrieve_Service_Details();
            }
        }

        private void frmService_Load(object sender, EventArgs e)
        {

        }

        private void txtServiceName_MouseClick(object sender, MouseEventArgs e)
        {
            txtServiceName.BackColor = Color.Aquamarine;
        }

        private void txtServiceName_Leave(object sender, EventArgs e)
        {
            txtServiceName.BackColor = Color.White;
        }

        private void txtServiceCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtServiceCode.BackColor = Color.Aquamarine;
        }

        private void txtServiceCode_Leave(object sender, EventArgs e)
        {
            txtServiceCode.BackColor = Color.White;
        }

        private void txtCenterCode_MouseClick(object sender, MouseEventArgs e)
        {
            txtCenterCode.BackColor = Color.Aquamarine;
        }

        private void txtCenterCode_Leave(object sender, EventArgs e)
        {
            txtCenterCode.BackColor = Color.White;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void func_Retrieve_Service_Details()
        {
            string RetrieveService = "Select Service_Name,Service_Code,Center_Code from tbl_Services where pk_Service_Id = ' " + GlobalClass.GlobalServiceId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ServiceFinder = new SqlCommand(RetrieveService, SysCon.SystemConnect);
            SqlDataReader ServiceReader = ServiceFinder.ExecuteReader();

            if (ServiceReader.Read())
            {

                ServiceName = ServiceReader[0].ToString();
                ServiceCode = ServiceReader[1].ToString();
                Center_Code = ServiceReader[2].ToString();

                txtServiceName.Text = ServiceReader[0].ToString();
                txtServiceCode.Text = ServiceReader[1].ToString();
                txtCenterCode.Text = ServiceReader[2].ToString();

                txtServiceName.Focus();

            }
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }
    }
}
