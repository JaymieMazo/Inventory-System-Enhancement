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
    public partial class frmSubcategoryList : Form
    {
        public frmSubcategoryList()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSubcategoryList_Load(object sender, EventArgs e)
        {
            //Close current connection
            SysCon.CloseConnection();

            //Load categories data
            func_Load_All_Subcategories();

            //Clear value of SubCategoryID
            GlobalClass.GlobalSubcategoryId = "";

            txtSearchSubcat.Focus();
        }


        private void func_Load_All_Subcategories()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllSubcategories = "Select * from view_CatSubCat";

            SqlDataAdapter AllCategoriesAdapter = new SqlDataAdapter(AllSubcategories, SysCon.SystemConnect);

            string srctbl = "view_CatSubCat";

            DataSet SubcategoryData = new DataSet();

            AllCategoriesAdapter.Fill(SubcategoryData, srctbl);

            dgvSubcategories.DataSource = SubcategoryData.Tables["view_CatSubCat"];

            dgvSubcategories.RowHeadersWidth = 5;

            dgvSubcategories.Columns[0].Visible = false;

            dgvSubcategories.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void dgvSubcategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubcategories.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalSubcategoryId = dgvSubcategories.CurrentRow.Cells[0].Value.ToString();
                //MessageBox.Show(GlobalClass.GlobalSubcategoryId);
                this.Close();

            }
        }

        private void txtSearchSubcat_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvSubcategories.DataSource).DefaultView.RowFilter = "Subcategory_Name LIKE '%" + txtSearchSubcat.Text + "%'";

            if (dgvSubcategories.RowCount <= 0)
            {
                MessageBox.Show("Subcategory not exists.");
                txtSearchSubcat.Text = "";

            }
        }

        private void txtSearchSubcat_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchSubcat.BackColor = Color.Aquamarine;
        }

        private void txtSearchSubcat_Leave(object sender, EventArgs e)
        {
            txtSearchSubcat.BackColor = Color.White;
        }

        private void dgvSubcategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
