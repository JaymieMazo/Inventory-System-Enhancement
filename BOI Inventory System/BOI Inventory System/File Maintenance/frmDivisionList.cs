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
    public partial class frmDivisionList : Form
    {
        public frmDivisionList()
        {
            InitializeComponent();
        }

        private void frmDivisionList_Load(object sender, EventArgs e)
        {
           // Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Divisions();
            txtSearchDivision.Focus();
        }

        private void func_Load_All_Divisions()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllDivisions = "Select * from view_ServicesDivision";

            SqlDataAdapter AllDivisionsAdapter = new SqlDataAdapter(AllDivisions, SysCon.SystemConnect);

            string srctbl = "view_ServicesDivision";

            DataSet DivisionsData = new DataSet();

            AllDivisionsAdapter.Fill(DivisionsData, srctbl);

            dgvDivision.DataSource = DivisionsData.Tables["view_ServicesDivision"];

            dgvDivision.RowHeadersWidth = 5;

            dgvDivision.Columns[0].Visible = false;
            dgvDivision.Columns[1].Visible = false;

            dgvDivision.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchDivision_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvDivision.DataSource).DefaultView.RowFilter = "Division_Name LIKE '%" + txtSearchDivision.Text + "%'";

            if (dgvDivision.RowCount <= 0)
            {
                MessageBox.Show("Division not exists.");
                txtSearchDivision.Text = "";

            }
        }

        private void dgvDivision_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDivision.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalDivisionId = dgvDivision.CurrentRow.Cells[0].Value.ToString();
                // MessageBox.Show(GlobalClass.GlobalDivisionId);
                this.Close();
            }
        }

        private void txtSearchDivision_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchDivision.BackColor = Color.Aquamarine;
        }

        private void txtSearchDivision_Leave(object sender, EventArgs e)
        {
            txtSearchDivision.BackColor = Color.White;
        }
    }
}
