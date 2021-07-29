using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Security.Cryptography;

namespace BOI_Inventory_System
{
    public partial class frmChangePassword : Form
    {
        public static string hash = "10034n@J(/)4L35@$P1!#1724";
        public string pword;
        public frmChangePassword()
        {
            InitializeComponent();
        }

        private void func_Encrypt_Password()
        {
            // decryption
            byte[] data = UTF8Encoding.UTF8.GetBytes(txtOldPassword.Text); // txtPassword = password
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

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void func_Reset()
        {
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";

            txtOldPassword.Focus();
        }

        private void func_Validate_Password()
        {
            string UserAccount = "Select * from tbl_System_Users where User_Name = '" + GlobalClass.GlobalUser + "' and Password = '"+ pword +"' ";

            //close connection
            SysCon.CloseConnection();

            //open connection
            SysCon.SystemConnect.Open();

            SqlCommand SearchAccount = new SqlCommand(UserAccount, SysCon.SystemConnect);

            SqlDataReader AccountReader = SearchAccount.ExecuteReader();

            //Check account if existing
            if (AccountReader.Read())
            {
                func_Encrypt_NewPassword();
                func_Update_Password();
                func_Reset();
            }
            else
            {
                MessageBox.Show("The old password you supply is incorrect ");
            }

            AccountReader.Close();
            AccountReader.Dispose();

            //Close Connection
             SysCon.SystemConnect.Close();

          }
        private void func_Update_Password()
        {
            string UpdateRecord = "Update tbl_System_Users Set Password = '" + pword + "' where User_Name = '" + GlobalClass.GlobalUser + "'";

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
                   "', 'Update Password , User  = ' + '" + GlobalClass.GlobalUser + "' )";

            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("User password has been successfully changed!", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void func_Encrypt_NewPassword()
        {
            //encryption
            byte[] data = UTF8Encoding.UTF8.GetBytes(txtNewPassword.Text); // txtNewPassword = password
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text == "" || txtNewPassword.Text == "" || txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Cannot continue transaction. All fields are required.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOldPassword.Focus();
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Password didn't match", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to change your password?", "Change Password", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Encrypt_Password();
                            func_Validate_Password();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("No changes will be made.", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            func_Reset();
                            break;
                        }
                }

               
            }
        }
    }
}
