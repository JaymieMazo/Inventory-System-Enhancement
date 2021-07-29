using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Security.Cryptography;

namespace BOI_Inventory_System
{

    
    public partial class frmLogIn : Form
    {
        static Int32 LoginAttempts = 0;
        public static string hash = "10034n@J(/)4L35@$P1!#1724"; 
        public string pword ;
        public frmLogIn()
        {
            InitializeComponent();
        }
              

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Cannot continue Log in.\nUsername and Password required.", "User Authentication", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
                //  func_Reset();
            }
            else
            {
                func_Encrypt_Password();
                func_Validate_User();
            }
        }
        private void func_Encrypt_Password()
        {
            // decryption
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
        private void func_Validate_User()
        {
            string UserAccount = "Select Full_Name,User_Name,pk_User_Id,User_Type from tbl_System_Users where User_Name = '" + txtUserName.Text + "' and Password = '" + pword + "'";

            //close connection
            SysCon.CloseConnection();

            //open connection
            SysCon.SystemConnect.Open();

            SqlCommand SearchAccount = new SqlCommand(UserAccount, SysCon.SystemConnect);

            SqlDataReader AccountReader = SearchAccount.ExecuteReader();

            //Check account if existing
            if (AccountReader.Read())
            {
                MessageBox.Show("Welcome " + txtUserName.Text + "\nAccess granted!", "User Authentication",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Get details for trailing
                string Name = AccountReader[0].ToString();
                string Uname = AccountReader[1].ToString();
                string dtime = DateTime.Now.ToString();
                string Uid = AccountReader[2].ToString();
                string UserType = AccountReader[3].ToString();

                //Getting user information
                GlobalClass.GlobalName = Name;
                GlobalClass.GlobalUser = Uname;
                GlobalClass.GlobalUserType = UserType;

                this.Close();

                AccountReader.Close();
                AccountReader.Dispose();

                //Insert Login Activity to audit trail
                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + Name +
                       "', '" + Uname +
                       "', '" + dtime +
                       "', 'User Log In')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                //Close Connection
                SysCon.SystemConnect.Close();

                //Is passed authentication?
                GlobalClass.Authenticated = true;

                this.Close();
            }
            else
            {
                LoginAttempts++;
                MessageBox.Show("Access Denied!\nTries Left ( " + (3 - LoginAttempts) + ")");
                txtUserName.Focus();
                //func_Reset();
                GlobalClass.Authenticated = false;

                if (LoginAttempts >= 3)
                {
                    MessageBox.Show("Unauthorized Access! This system will now close!", "User Authentication", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

        }

        private void btnLogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnLogIn_Enter(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void func_Reset()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtUserName.Focus();
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
            txtUserName.BackColor = Color.Aquamarine;
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            txtUserName.BackColor = Color.White;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            txtPassword.BackColor = Color.Aquamarine;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
        }

        private void frmLogIn_Load(object sender, EventArgs e)
        {
            txtUserName.Text = "jdmazo";
            txtPassword.Text = "123456";
            //User.name = "jai";
            //string test = User.name;
            //MessageBox.Show(User.name);
        }
    }
}
