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
using System.Security.Cryptography;

namespace BOI_Inventory_System
{
    public partial class frmSystemUserManagement : Form
    {
        string Full_Name,UserName;
        public static string hash = "10034n@J(/)4L35@$P1!#1724"; 
        public string pword;
        public frmSystemUserManagement()
        {
            InitializeComponent();
        }

        private void frmSystemUserManagement_Load(object sender, EventArgs e)
        {
            func_Load_Units();

            func_Reset();
        }

        private void func_Load_Units()
        {
            string Units = "Select pk_Division_Id,Unit from tbl_Divisions";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadUnits = new SqlCommand(Units, SysCon.SystemConnect);
            SqlDataReader UnitsReader = LoadUnits.ExecuteReader();

            while (UnitsReader.Read())
            {
                cboUnit.Items.Add(UnitsReader.GetValue(1));
            }

            UnitsReader.Close();
            UnitsReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
        private void func_Reset()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtRemarks.Text = "";

            cboUnit.Text = "";
            cboUnit.SelectedIndex = -1;

            cboUserType.Text = "";
            cboUserType.SelectedIndex = -1;

            txtFirstName.Focus();

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtPassword.Enabled = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalUsersId = "";

            frmUsersList frm_Users = new frmUsersList();
            frm_Users.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalUsersId))
            { func_Retrieve_Users(); txtFirstName.Focus(); btnSave.Enabled = false; btnUpdate.Enabled = true; btnDelete.Enabled = true; }
            else
            {
                func_Reset();
                btnSearch.Focus(); }

        }

        private void func_Retrieve_Users()
        {
          

            string RetrieveUsers = "Select * from tbl_System_Users where pk_User_Id = ' " + GlobalClass.GlobalUsersId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand UsersFinder = new SqlCommand(RetrieveUsers, SysCon.SystemConnect);
            SqlDataReader UsersReader = UsersFinder.ExecuteReader();

            if (UsersReader.Read())
            {
                txtFirstName.Text = UsersReader[1].ToString();
                txtMiddleName.Text = UsersReader[2].ToString();
                txtLastName.Text = UsersReader[3].ToString();
                Full_Name = UsersReader[4].ToString();
                txtUserName.Text = UsersReader[6].ToString();

              //  textBox1.Text = UsersReader[7].ToString();
                pword = UsersReader[7].ToString();

                cboUnit.Text = UsersReader[5].ToString();
                cboUserType.Text = UsersReader[8].ToString();
                txtRemarks.Text = UsersReader[9].ToString();

                
            }
            UsersReader.Close();
            UsersReader.Dispose();

            txtPassword.Enabled = true;

            func_Decrypt_Password();

            UserName = txtUserName.Text;

          //  txtPassword.Text = pword;


        }
        private void func_Decrypt_Password()
        {
            byte[] data = Convert.FromBase64String(pword); // textbox2 = encrypted text
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    txtPassword.Text = UTF8Encoding.UTF8.GetString(results);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "" || txtMiddleName.Text == "" || txtLastName.Text == "" ||  cboUserType.Text == "" || cboUnit.Text == "")
            {
                MessageBox.Show("Cannot continue saving! Fields are required.", "New System User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Generate_UserName();
                            txtPassword.Text = "123456";
                            func_Check_Duplication_AddUser();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Add New User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Generate_UserName()
        {
            string fname="";

            foreach (var part in txtFirstName.Text.Split(' '))
            {
                fname += part.Substring(0, 1).ToUpper();
            }

            string mname = txtMiddleName.Text;
            mname = mname.Substring(0, 1);
            string lname = txtLastName.Text;
            txtUserName.Text = (fname + mname + lname.Replace(" ",String.Empty));

            Full_Name = txtFirstName.Text + ' ' + txtMiddleName.Text + ' ' + txtLastName.Text;
        }

        private void func_EncryptPassword()
        {
            //encryption
            byte[] data = UTF8Encoding.UTF8.GetBytes(txtPassword.Text); // txtPassword = password
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    pword = Convert.ToBase64String(results, 0, results.Length);
                }
            }

        }
        private void func_Check_Duplication_AddUser()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select User_Name from tbl_System_Users where User_Name ='" + txtUserName.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("User Name already exists!", "New User", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return;
            }
            else
            {
                func_EncryptPassword();
                func_Add_User();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update User data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Check_Duplication_UpdUsers();
                        break;
                    }

                case DialogResult.No:
                    {
                        MessageBox.Show("No changes will be made.", "Updating User Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
            }
        }

        private void func_Check_Duplication_UpdUsers()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (UserName != txtUserName.Text)
            {
                string CheckDuplication_Code = "Select User_Name from tbl_System_Users where User_Name = '" + txtUserName.Text + "'";
                SqlCommand CheckDuplicateCodeCommand = new SqlCommand(CheckDuplication_Code, SysCon.SystemConnect);

                SqlDataReader CodeReader = CheckDuplicateCodeCommand.ExecuteReader();
                if (CodeReader.Read())
                {
                    MessageBox.Show("Username already exists!", "System Users", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFirstName.Focus();
                    return;
                }
                else
                {
                    func_Update_Users();
                }
                CodeReader.Close();
                CodeReader.Dispose();
            }
            else
            {
                func_Generate_UserName();
                func_EncryptPassword();
                func_Update_Users();
                func_Reset();
            }


        }
        private void func_Update_Users()
        {
            string UpdateRecord = "Update tbl_System_Users Set First_Name = '" + txtFirstName.Text +
                   "',Middle_Name = '" + txtMiddleName.Text + "', Last_Name ='" + txtLastName.Text + "', Full_Name ='" + Full_Name + "',Unit = '"+cboUnit.Text+"', User_Name = '"+ txtUserName.Text + "',Password = '"+pword+"', User_Type = '"+ cboUserType.Text +"', Remarks = '"+txtRemarks.Text +"' where pk_User_Id = '" + GlobalClass.GlobalUsersId + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateUser = new SqlCommand();
            UpdateUser.CommandType = CommandType.Text;
            UpdateUser.CommandText = UpdateRecord;
            UpdateUser.Connection = SysCon.SystemConnect;
            UpdateUser.ExecuteNonQuery();



            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update User = ' + '" + Full_Name + "'+ ' ; User Name = '+ '" + txtUserName.Text + "' + '; Unit = ' + '" + cboUnit.Text + "' + ' ;User Type = ' + '" + cboUserType.Text + "' + ' ; Remarks = ' + '" + txtRemarks.Text + "' )";

            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("User information has been successfully updated!", "Update User Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete User", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Delete_User();
                        break;
                    }

            }

            func_Reset();
        }
        private void func_Delete_User()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteUser = new SqlCommand();
                DeleteUser.CommandText = "Delete from tbl_System_Users where pk_User_Id = '" + GlobalClass.GlobalUsersId + "'";
                DeleteUser.CommandType = CommandType.Text;
                DeleteUser.Connection = SysCon.SystemConnect;
                DeleteUser.ExecuteNonQuery();

                MessageBox.Show("User has been successfully deleted!", "Delete User", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail
                //Insert  Activity to audit trail
                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete User = ' + '" + Full_Name + "'+ ' ; User Name = '+ '" + txtUserName.Text + "' + '; Unit = ' + '" + cboUnit.Text + "' + ' ;User Type = ' + '" + cboUserType.Text + "' + ' ; Remarks = ' + '" + txtRemarks.Text + "' )";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Division", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmEmployeesList frm_EmployeesList = new frmEmployeesList();
            frm_EmployeesList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalEmployeeId))
            {
                func_Retrieve_Employee_Details();
            }
        }

        private void func_Retrieve_Employee_Details()
        {
            string RetrieveEmployee = "Select * from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalEmployeeId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand EmployeeFinder = new SqlCommand(RetrieveEmployee, SysCon.SystemConnect);
            SqlDataReader EmployeeReader = EmployeeFinder.ExecuteReader();

            if (EmployeeReader.Read())
            {

                txtFirstName.Text = EmployeeReader[6].ToString();
                txtMiddleName.Text = EmployeeReader[7].ToString();
                txtLastName.Text = EmployeeReader[8].ToString();

                cboUnit.Text = EmployeeReader[5].ToString();

            }
            cboUserType.Focus();
        }

        private void func_Add_User()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewUser = "Insert into tbl_System_Users (First_Name,Middle_Name,Last_Name,Full_Name,Unit,User_Name,Password,User_Type,Remarks) Values('" + txtFirstName.Text +
               "', '" + txtMiddleName.Text + "','" + txtLastName.Text + "','"  + Full_Name + "','" + cboUnit.Text + "','" + txtUserName.Text + "','" + pword + "','" + cboUserType.Text + "' , '"+ txtRemarks.Text +"')";

            SqlCommand AddNewUser = new SqlCommand(NewUser, SysCon.SystemConnect);
            AddNewUser.ExecuteNonQuery();

            MessageBox.Show("New user has been successfully added!", "Add New User", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New User = ' + '" + Full_Name + "'+ ' ; User Name = '+ '" + txtUserName.Text + "' + '; Unit = ' + '" + cboUnit.Text + "' + ' ;User Type = ' + '" + cboUserType.Text + "' + ' ; Remarks = ' + '" + txtRemarks.Text + "' )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
        }
    }
}
