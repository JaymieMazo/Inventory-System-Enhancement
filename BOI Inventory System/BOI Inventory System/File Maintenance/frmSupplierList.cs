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

namespace BOI_Inventory_System
{
    public partial class frmSupplierList : Form
    {
        public frmSupplierList()
        {
            InitializeComponent();
        }

        private void frmSupplierList_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Supplier();

            //Clear value of SubCategoryID
            GlobalClass.GlobalSupplierId = "";

            txtSearchSupplier.Focus();

        }

        private void func_Load_All_Supplier()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllSupplier = "Select * from view_CatSupplier";

            SqlDataAdapter AllCategoriesAdapter = new SqlDataAdapter(AllSupplier, SysCon.SystemConnect);

            string srctbl = "view_CatSupplier";

            DataSet SupplierData = new DataSet();

            AllCategoriesAdapter.Fill(SupplierData, srctbl);

            dgvSupplier.DataSource = SupplierData.Tables["view_CatSupplier"];

            dgvSupplier.RowHeadersWidth = 5;

            dgvSupplier.Columns[0].Visible = false;
            dgvSupplier.Columns[1].Visible = false;

            dgvSupplier.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSupplier.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalSupplierId = dgvSupplier.CurrentRow.Cells[0].Value.ToString();
               // MessageBox.Show(GlobalClass.GlobalSupplierId);
                this.Close();

            }
        }

        private void txtSearchSupplier_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvSupplier.DataSource).DefaultView.RowFilter = "Supplier_Name LIKE '%" + txtSearchSupplier.Text + "%'";

            if (dgvSupplier.RowCount <= 0)
            {
                MessageBox.Show("Supplier not exists.");
                txtSearchSupplier.Text = "";

            }
        }

        private void txtSearchSupplier_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchSupplier.BackColor = Color.Aquamarine;
        }

        private void txtSearchSupplier_Leave(object sender, EventArgs e)
        {
            txtSearchSupplier.BackColor = Color.Aquamarine;
        }
    }
}
