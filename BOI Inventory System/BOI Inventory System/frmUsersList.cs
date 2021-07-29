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
    public partial class frmUsersList : Form
    {
        public frmUsersList()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmUsersList_Load(object sender, EventArgs e)
        {
            func_Load_All_Users();

            txtSearch.Focus();
        }

        private void func_Load_All_Users()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllUsers = "Select * from tbl_System_Users";

            SqlDataAdapter AllUsersAdapter = new SqlDataAdapter(AllUsers, SysCon.SystemConnect);

            string srctbl = "tbl_System_Users";

            DataSet UsersData = new DataSet();

            AllUsersAdapter.Fill(UsersData, srctbl);

            dgvUsers.DataSource = UsersData.Tables["tbl_System_Users"];

            dgvUsers.RowHeadersWidth = 5;

            dgvUsers.Columns[0].Visible = false;

           // dgvUsers.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUsers.Columns[7].Visible = false;

            SysCon.SystemConnect.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = "Full_Name LIKE '%" + txtSearch.Text + "%'";

            if (dgvUsers.RowCount <= 0)
            {
                MessageBox.Show("Name does not exists.");
                txtSearch.Text = "";

            }
           
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalUsersId = dgvUsers.CurrentRow.Cells[0].Value.ToString();
                this.Close();
            }

        }
    }
}
