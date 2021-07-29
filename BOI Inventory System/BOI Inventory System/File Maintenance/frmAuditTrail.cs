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
    public partial class frmAuditTrail : Form
    {
        public frmAuditTrail()
        {
            InitializeComponent();
        }

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Activity();

            this.dgvTrail.RowsDefaultCellStyle.BackColor = Color.Aquamarine;
            this.dgvTrail.AlternatingRowsDefaultCellStyle.BackColor =
                Color.Azure;

            txtSearchActivity.Focus();
        }

        private void func_Load_All_Activity()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllActivities = "Select * from tbl_Audit_Trail";

            SqlDataAdapter AllActivitiesAdapter = new SqlDataAdapter(AllActivities, SysCon.SystemConnect);

            string srctbl = "tbl_Audit_Trail";

            DataSet ActivitiesData = new DataSet();

            AllActivitiesAdapter.Fill(ActivitiesData, srctbl);

            dgvTrail.DataSource = ActivitiesData.Tables["tbl_Audit_Trail"];

            dgvTrail.RowHeadersWidth = 5;

            //dgvTrail.Columns[0].Visible = false;
            //dgvTrail.Columns[1].Visible = false;

            dgvTrail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchActivity_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvTrail.DataSource).DefaultView.RowFilter = "Activity LIKE '%" + txtSearchActivity.Text + "%'";

            if (dgvTrail.RowCount <= 0)
            {
                //MessageBox.Show("Activity not exists.");
                txtSearchActivity.Text = "";

            }
        }

        private void txtSearchActivity_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchActivity.BackColor = Color.Aquamarine;
        }

        private void txtSearchActivity_Leave(object sender, EventArgs e)
        {
            txtSearchActivity.BackColor = Color.White;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvTrail.DataSource).DefaultView.RowFilter = "Full_Name LIKE '%" + txtUser.Text + "%'";

            if (dgvTrail.RowCount <= 0)
            {
                //MessageBox.Show("User does not exists.");
                txtUser.Text = "";

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Text = "";
            txtSearchActivity.Text = "";
        }

        private void dgvTrail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            txtUser.BackColor = Color.White;
        }

        private void txtUser_MouseClick(object sender, MouseEventArgs e)
        {
            txtUser.BackColor = Color.Aquamarine;
        }
    }
}
