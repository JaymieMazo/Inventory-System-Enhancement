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
    public partial class frmBOIEmployees : Form
    {
        string Division_Id, EmployeeName;
        public frmBOIEmployees()
        {
            InitializeComponent();
        }

        private void frmBOIEmployees_Load(object sender, EventArgs e)
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

        private void func_Reset()
        {
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";

            txtFirstName.Focus();

            cboUnit.Text = "";
            txtFullName.Text = "";
            txtDesignation.Text = "";
            cboUnit.Text = "";
            cboStatus.Text = "";
           
            cboUnit.SelectedIndex = -1;
            cboStatus.SelectedIndex = -1;

            btnSaveUpdate.Text = "Save";
            btnDelete.Enabled = false;

        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {

            if (txtFirstName.Text == "" || txtDesignation.Text=="" || cboUnit.Text=="" || cboStatus.Text=="" || txtMiddleName.Text=="" || txtLastName.Text=="")
            {

                MessageBox.Show("Cannot continue saving! All fields are required.", "New Employee Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (btnSaveUpdate.Text == "Save")
                {
                    DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_AddEmployee();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("All information you type will be lost.", "Adding Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                func_Reset();
                                break;
                            }
                    }
                }
                else
                {
                    DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Check_Duplication_UpdEmployee();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("No changes will be made", "Updating Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                    }

                }
            }


        }

        private void func_Check_Duplication_AddEmployee()
        {
            string MidI = txtMiddleName.Text;
            MidI = MidI.Substring(0, 1);
            txtFullName.Text = txtFirstName.Text + ' ' + MidI + '.' + ' ' + txtLastName.Text;

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Full_Name from tbl_BOI_Employees where Full_Name ='" + txtFullName.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Employee name already exists!", "BOI Employees", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }
            else
            {
                
                func_Add_Employee();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Employee()
        {
            string MidI = txtMiddleName.Text;
            MidI =MidI.Substring(0, 1);
            txtFullName.Text = txtFirstName.Text + ' ' + MidI + '.' +' ' + txtLastName.Text;

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewEmployee = "Insert into tbl_BOI_Employees (First_Name, Middle_Name, Last_Name,Full_Name,Designation,fk_Division_Id,Employment_Status) Values('"+ txtFirstName.Text +"', '"+ txtMiddleName.Text +"', '"+ txtLastName.Text +"','" + txtFullName.Text +
               "', '" + txtDesignation.Text + "','" + Division_Id + "', '" + cboStatus.Text + "')";

            SqlCommand AddNewEmployee = new SqlCommand(NewEmployee, SysCon.SystemConnect);
            AddNewEmployee.ExecuteNonQuery();
            
            //Add to End-User Table
            string NewEUser = "Insert into tbl_BOI_End_Users (First_Name, Middle_Name, Last_Name,User_Name,User_Designation,fk_Division_Id,Employment_Status) Values('" + txtFirstName.Text + "', '" + txtMiddleName.Text + "', '" + txtLastName.Text + "','" + txtFullName.Text +
              "', '" + txtDesignation.Text + "','" + Division_Id + "', '" + cboStatus.Text + "')";

            SqlCommand AddNewEUSer = new SqlCommand(NewEUser, SysCon.SystemConnect);
            AddNewEUSer.ExecuteNonQuery();

            //Add to Signatory Table
            string NewSignatory = "Insert into tbl_BOI_Signatories (First_Name, Middle_Name, Last_Name,Signatory_Name,Signatory_Designation,fk_Division_Id,Employment_Status) Values('" + txtFirstName.Text + "', '" + txtMiddleName.Text + "', '" + txtLastName.Text + "','" + txtFullName.Text +
              "', '" + txtDesignation.Text + "','" + Division_Id + "', '" + cboStatus.Text + "')";

            SqlCommand AddNewSignatory = new SqlCommand(NewSignatory, SysCon.SystemConnect);
            AddNewSignatory.ExecuteNonQuery();


            MessageBox.Show("New Employee has been successfully added!", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Employee Name = ' + '" + txtFullName.Text + "'+ ' ;  Designation = '+ '" + txtDesignation.Text + "' + ' ; Unit ' + '" + cboUnit.Text + "' + 'Employment Status = ' + '" + cboStatus.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            func_Reset();
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnit.SelectedIndex != -1)
            { func_Get_Division_Id(); }
        }

        private void func_Get_Division_Id()
        {
            //Close existing connection
            SysCon.CloseConnection();

            string Division = "Select pk_Division_Id from tbl_Divisions where Unit =  '" + cboUnit.Text + "'";

            SysCon.SystemConnect.Open();

            //Get ID from subcategory table
            SqlCommand SelectDivision_Id = new SqlCommand(Division, SysCon.SystemConnect);

            SqlDataReader DivisionIdReader = SelectDivision_Id.ExecuteReader();

            DivisionIdReader.Read();

            Division_Id = DivisionIdReader[0].ToString();

            DivisionIdReader.Close();

            //Close connection
            SysCon.SystemConnect.Close();

            // MessageBox.Show(Division_Id);

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

        private void btnSearch_Click(object sender, EventArgs e)
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

                Division_Id = EmployeeReader[1].ToString();
                txtFullName.Text = EmployeeReader[2].ToString();
                txtDesignation.Text = EmployeeReader[3].ToString();
                cboStatus.Text = EmployeeReader[4].ToString();
                txtFirstName.Text = EmployeeReader[6].ToString();
                txtMiddleName.Text = EmployeeReader[7].ToString();
                txtLastName.Text = EmployeeReader[8].ToString();

                cboUnit.Text = EmployeeReader[5].ToString();

                //copy to variable for comparison in updating
               
                EmployeeName = txtFullName.Text;

                txtFullName.Focus();

            }
            txtFullName.Focus();
            btnSaveUpdate.Text = "Update";
            btnDelete.Enabled = true;
        }

        private void func_Check_Duplication_UpdEmployee()
        {
            string MidI = txtMiddleName.Text;
            MidI = MidI.Substring(0, 1);
            txtFullName.Text = txtFirstName.Text + ' ' + MidI + '.' + ' ' + txtLastName.Text;

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            if (EmployeeName != txtFullName.Text)
            {
                string CheckDuplication = "Select Full_Name from tbl_BOI_Employees where Full_Name = '" + txtFullName.Text + "'";
                SqlCommand CheckDuplicateCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

                SqlDataReader EmployeeReader = CheckDuplicateCommand.ExecuteReader();
                if (EmployeeReader.Read())
                {
                    MessageBox.Show("Employee name already exists!", "BOI Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFullName.Focus();
                    return;
                }
                else
                {
                    func_Update_Employee();
                }
                EmployeeReader.Close();
                EmployeeReader.Dispose();
            }
        
            else
            {
                func_Update_Employee();
                //func_Reset();
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Employee", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Check_Existence_in_Inventory();
                        break;
                    }

            }

            func_Reset();
        }
        private void func_Check_Existence_in_Inventory()
        {

            string Check_EID = "Select fk_End_User_Id,fk_OIC,fk_Accountable_Employee_Id from tbl_Inventory_Details where fk_End_User_Id = ' " + GlobalClass.GlobalEmployeeId + "' or fk_OIC = ' " + GlobalClass.GlobalEmployeeId + "' or fk_Accountable_Employee_Id = ' " + GlobalClass.GlobalEmployeeId + "' ";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand EIDFinder = new SqlCommand(Check_EID, SysCon.SystemConnect);
            SqlDataReader EIDReader = EIDFinder.ExecuteReader();

            if (EIDReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                func_Delete_Employee();

            }

            EIDReader.Close();
            EIDReader.Dispose();

        }



        private void func_Delete_Employee()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteEmployee = new SqlCommand();
                DeleteEmployee.CommandText = "Delete from tbl_BOI_Employees where pk_Employee_Id = '" + GlobalClass.GlobalEmployeeId + "'";
                DeleteEmployee.CommandType = CommandType.Text;
                DeleteEmployee.Connection = SysCon.SystemConnect;
                DeleteEmployee.ExecuteNonQuery();

                //execute deletion to tbl_BOI_Signatories table
                SqlCommand DeleteSignatory = new SqlCommand();
                DeleteSignatory.CommandText = "Delete from tbl_BOI_Signatories where pk_Signatory_Id = '" + GlobalClass.GlobalEmployeeId + "'";
                DeleteSignatory.CommandType = CommandType.Text;
                DeleteSignatory.Connection = SysCon.SystemConnect;
                DeleteSignatory.ExecuteNonQuery();

                //execute deletion to tbl_BOI_End_Users
                SqlCommand DeleteEUser = new SqlCommand();
                DeleteEUser.CommandText = "Delete from tbl_BOI_End_Users where pk_EUser_Id = '" + GlobalClass.GlobalEmployeeId + "'";
                DeleteEUser.CommandType = CommandType.Text;
                DeleteEUser.Connection = SysCon.SystemConnect;
                DeleteEUser.ExecuteNonQuery();

                MessageBox.Show("Employee has been successfully deleted!", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //Insert  Activity to audit trail
                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                    "', '" + GlobalClass.GlobalUser +
                    "', '" + DateTime.Now.ToString() +
                    "', 'Delete Employee Name = ' + '" + txtFullName.Text + "'+ ' ; Designation = '+ '" + txtDesignation.Text + "' + ' ; Id = '+ '" + GlobalClass.GlobalEmployeeId + "' + '; Employment Status = ' + '" + cboStatus.Text + "' + ' ; Unit = ' + '" + cboUnit.Text + "' + ' ;Division Id = ' + '" + Division_Id + "' )";

                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFullName_MouseClick(object sender, MouseEventArgs e)
        {
            txtFullName.BackColor = Color.Aquamarine;
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            txtFullName.BackColor = Color.White;
        }

        private void txtDesignation_MouseClick(object sender, MouseEventArgs e)
        {
            txtDesignation.BackColor = Color.Aquamarine;
        }

        private void txtDesignation_Leave(object sender, EventArgs e)
        {
            txtDesignation.BackColor = Color.White;
        }

        private void cboUnit_Click(object sender, EventArgs e)
        {
            cboUnit.Items.Clear();
            func_Load_Units();
        }

        private void func_Update_Employee()
        {
            string UpdateRecord = "Update tbl_BOI_Employees Set Full_Name = '" + txtFullName.Text +
                   "',Designation = '" + txtDesignation.Text + "', fk_Division_Id  ='" + Division_Id + "' , Employment_Status  ='" + cboStatus.Text + "' , First_Name ='"+ txtFirstName.Text +"', Middle_Name ='"+ txtMiddleName.Text +"', Last_Name ='"+ txtLastName.Text +"' where pk_Employee_Id = '" + GlobalClass.GlobalEmployeeId + "'";
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateEmployee = new SqlCommand();
            UpdateEmployee.CommandType = CommandType.Text;
            UpdateEmployee.CommandText = UpdateRecord;
            UpdateEmployee.Connection = SysCon.SystemConnect;
            UpdateEmployee.ExecuteNonQuery();

            string UpdateEUsers = "Update tbl_BOI_End_Users Set User_Name = '" + txtFullName.Text +
                  "',User_Designation = '" + txtDesignation.Text + "', fk_Division_Id  ='" + Division_Id + "' , Employment_Status  ='" + cboStatus.Text + "' , First_Name ='" + txtFirstName.Text + "', Middle_Name ='" + txtMiddleName.Text + "', Last_Name ='" + txtLastName.Text + "' where pk_EUser_Id = '" + GlobalClass.GlobalEmployeeId + "'";

            //execute query update to tbl_BOI_End_Users table
            SqlCommand UpdateEUser = new SqlCommand();
            UpdateEUser.CommandType = CommandType.Text;
            UpdateEUser.CommandText = UpdateEUsers;
            UpdateEUser.Connection = SysCon.SystemConnect;
            UpdateEUser.ExecuteNonQuery();

            string UpdateSignatories = "Update tbl_BOI_Signatories Set Signatory_Name = '" + txtFullName.Text +
                "',Signatory_Designation = '" + txtDesignation.Text + "', fk_Division_Id  ='" + Division_Id + "' , Employment_Status  ='" + cboStatus.Text + "' , First_Name ='" + txtFirstName.Text + "', Middle_Name ='" + txtMiddleName.Text + "', Last_Name ='" + txtLastName.Text + "' where pk_Signatory_Id = '" + GlobalClass.GlobalEmployeeId + "'";

            //execute query update to tbl_BOI_Signatories table
            SqlCommand UpdateSignatory = new SqlCommand();
            UpdateSignatory.CommandType = CommandType.Text;
            UpdateSignatory.CommandText = UpdateSignatories;
            UpdateSignatory.Connection = SysCon.SystemConnect;
            UpdateSignatory.ExecuteNonQuery();

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Employee Name = ' + '" + txtFullName.Text + "'+ ' ; Designation = '+ '" + txtDesignation.Text + "' + ' ; Id = '+ '" + GlobalClass.GlobalEmployeeId + "' + '; Employment Status = ' + '" + cboStatus.Text + "' + ' ; Unit = ' + '" + cboUnit.Text + "' + ' ;Division Id = ' + '" + Division_Id + "' + ' ; First Name = '+ '" + txtFirstName.Text + "' + ' ; Middle Name = '+ '" + txtMiddleName.Text + "' + ' ; Last Name = '+ '" + txtLastName.Text + "' )";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Employee details has been successfully updated!", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
        }

    }
}
