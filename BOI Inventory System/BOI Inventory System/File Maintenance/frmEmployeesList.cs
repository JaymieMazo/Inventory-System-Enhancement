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
    public partial class frmEmployeesList : Form
    {
        public frmEmployeesList()
        {
            InitializeComponent();
        }

        private void frmEmployeesList_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Employees();

            //Clear value of Employee
            GlobalClass.GlobalEmployeeId = "";

            txtName.Focus();

        }

        private void func_Load_All_Employees()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllEmployees = "Select * from view_EmployeeDivision";

            SqlDataAdapter AllEmpAdapter = new SqlDataAdapter(AllEmployees, SysCon.SystemConnect);

            string srctbl = "view_EmployeeDivision";

            DataSet EmployeeData = new DataSet();

            AllEmpAdapter.Fill(EmployeeData, srctbl);

            dgvEmployees.DataSource = EmployeeData.Tables["view_EmployeeDivision"];

            dgvEmployees.RowHeadersWidth = 5;

            dgvEmployees.Columns[0].Visible = false;
            dgvEmployees.Columns[1].Visible = false;
            dgvEmployees.Columns[6].Visible = false;
            dgvEmployees.Columns[7].Visible = false;
            dgvEmployees.Columns[8].Visible = false;

            dgvEmployees.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvEmployees.DataSource).DefaultView.RowFilter = "Full_Name LIKE '%" + txtName.Text + "%'";

            if (dgvEmployees.RowCount <= 0)
            {
                MessageBox.Show("Employee name not exists.");
                txtName.Text = "";

            }
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployees.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalEmployeeId = dgvEmployees.CurrentRow.Cells[0].Value.ToString();
                //  MessageBox.Show(GlobalClass.GlobalEmployeeId);
                this.Close();

            }
        }

        private void dgvEmployees_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void dgvEmployees_Enter(object sender, EventArgs e)
        {
          
        }

        private void dgvEmployees_KeyUp(object sender, KeyEventArgs e)
        {
             
        }

        private void dgvEmployees_KeyDown(object sender, KeyEventArgs e)
        {
              
        }

        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.BackColor = Color.Aquamarine;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            txtName.BackColor = Color.White;
        }
    }
}
