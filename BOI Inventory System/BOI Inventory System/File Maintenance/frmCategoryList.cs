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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Categories();
            txtSearchCat.Focus();
        }

        private void func_Load_All_Categories()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllCategories = "Select * from tbl_Category";

            SqlDataAdapter AllCategoriesAdapter = new SqlDataAdapter(AllCategories, SysCon.SystemConnect);

            string srctbl = "tbl_Category";

            DataSet CategoryData = new DataSet();

            AllCategoriesAdapter.Fill(CategoryData, srctbl);

            dgvCategories.DataSource = CategoryData.Tables["tbl_Category"];

            dgvCategories.RowHeadersWidth = 5;

            dgvCategories.Columns[0].Visible = false;

            dgvCategories.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchCat_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvCategories.DataSource).DefaultView.RowFilter = "Category_Name LIKE '%" + txtSearchCat.Text + "%'";

            if (dgvCategories.RowCount <= 0)
            {
                MessageBox.Show("Category not exists.");
                txtSearchCat.Text = "";

            }
        }

       private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategories.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalCategoryId = dgvCategories.CurrentRow.Cells[0].Value.ToString();
                // MessageBox.Show(GlobalClass.GlobalCategoryId);
                this.Close();
            }
        }

        private void txtSearchCat_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchCat.BackColor = Color.Aquamarine;
        }

        private void txtSearchCat_Leave(object sender, EventArgs e)
        {
            txtSearchCat.BackColor = Color.White;
        }
    }
}
