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
    public partial class frmServiceList : Form
    {
        public frmServiceList()
        {
            InitializeComponent();
        }

        private void frmServiceList_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Services();

            //Clear value of SubCategoryID
            GlobalClass.GlobalServiceId = "";

            txtSearchServices.Focus();
        }

        private void func_Load_All_Services()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllServices = "Select * from tbl_Services";

            SqlDataAdapter AllServicesAdapter = new SqlDataAdapter(AllServices, SysCon.SystemConnect);

            string srctbl = "tbl_Services";

            DataSet ServicesData = new DataSet();

            AllServicesAdapter.Fill(ServicesData, srctbl);

            dgvServices.DataSource = ServicesData.Tables["tbl_Services"];

            dgvServices.RowHeadersWidth = 5;

            dgvServices.Columns[0].Visible = false;

            dgvServices.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchServices_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvServices.DataSource).DefaultView.RowFilter = "Service_Name LIKE '%" + txtSearchServices.Text + "%'";

            if (dgvServices.RowCount <= 0)
            {
                MessageBox.Show("Service not exists.");
                txtSearchServices.Text = "";

            }
        }

        private void dgvServices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvServices.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalServiceId = dgvServices.CurrentRow.Cells[0].Value.ToString();
                //  MessageBox.Show(GlobalClass.GlobalServiceId);
                this.Close();

            }
        }

        private void txtSearchServices_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchServices.BackColor = Color.Aquamarine;
        }

        private void txtSearchServices_Leave(object sender, EventArgs e)
        {
            txtSearchServices.BackColor = Color.White;
        }
    }
}
