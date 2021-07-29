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
    public partial class frmArticleList : Form
    {
        public frmArticleList()
        {
            InitializeComponent();
        }

        private void frmArticleList_Load(object sender, EventArgs e)
        {
            func_Load_All_Articles();

            txtSearchArticle.Focus();

            GlobalClass.GlobalSubcategoryId = "";
           // GlobalClass.GlobalArticleId = "";
        
        }

        private void func_Load_All_Articles()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllArticles = "Select * from view_ArticleSubcat";

            SqlDataAdapter AllCategoriesAdapter = new SqlDataAdapter(AllArticles, SysCon.SystemConnect);

            string srctbl = "view_ArticleSubcat";

            DataSet ArticleData = new DataSet();

            AllCategoriesAdapter.Fill(ArticleData, srctbl);

            dgvArticles.DataSource = ArticleData.Tables["view_ArticleSubcat"];

            dgvArticles.RowHeadersWidth = 5;

            dgvArticles.Columns[0].Visible = false;
            dgvArticles.Columns[1].Visible = false;

            dgvArticles.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void txtSearchArticle_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvArticles.DataSource).DefaultView.RowFilter = "Article_Name LIKE '%" + txtSearchArticle.Text + "%'";

            if (dgvArticles.RowCount <= 0)
            {
                //MessageBox.Show("Article not exists.");
                txtSearchArticle.Text = "";

            }
        }

        private void dgvArticles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArticles.RowCount <= 0)
            {
                MessageBox.Show("No items to select..");
            }
            else
            {
                GlobalClass.GlobalArticleId = dgvArticles.CurrentRow.Cells[0].Value.ToString();
                ///MessageBox.Show(GlobalClass.GlobalArticleId);

                GlobalClass.GlobalSubcategoryId = dgvArticles.CurrentRow.Cells[1].Value.ToString();

                this.Close();

            }
        }

    

        private void txtSearchArticle_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchArticle.BackColor = Color.Aquamarine;
        }

        private void txtSearchArticle_Leave(object sender, EventArgs e)
        {
            txtSearchArticle.BackColor = Color.White;
        }
    }
}
