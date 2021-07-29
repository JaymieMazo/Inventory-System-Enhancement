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
    public partial class frmPropertyCard : Form
    {
        public frmPropertyCard()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblcount.Text = dgvItems.RowCount.ToString();
            txtSearch.Text = "";
            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();

            }

            txtSearch.Text = "";
           
            txtSearch.Focus();

            GlobalClass.GlobalInvItemId = "";
        }

        private void frmPropertyCard_Load(object sender, EventArgs e)
        {
            lblcount.Text = dgvItems.RowCount.ToString();
            GlobalClass.GlobalInvItemId = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalInvItemId = "";

            frm_PropertyCardsItems frm_ItemsList = new frm_PropertyCardsItems();
            frm_ItemsList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalInvItemId))
            {
                func_Retrieve_Item();
            }
        }
        private void func_Retrieve_Item()
        {

            string RetrieveItems = "Select Description from view_Existing_Items_Details where pk_Id = ' " + GlobalClass.GlobalInvItemId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ItemFinder = new SqlCommand(RetrieveItems, SysCon.SystemConnect);
            SqlDataReader ItemReader = ItemFinder.ExecuteReader();

            if (ItemReader.Read())
            {
                txtSearch.Text = ItemReader[0].ToString();

            }
            ItemReader.Close();
            ItemReader.Dispose();

            func_Load_Item_History();
            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void func_Load_Item_History()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string ItemsHistory = "Select * from view_ItemHistory where fk_Inv_Id = '" + GlobalClass.GlobalInvItemId + "'";

            SqlDataAdapter HistoryAdapter = new SqlDataAdapter(ItemsHistory, SysCon.SystemConnect);

            string srctbl = "view_ItemHistory";

            DataSet ItemsData = new DataSet();

            HistoryAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_ItemHistory"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
           //dgvItems.Columns[2].Visible = false;
           //dgvItems.Columns[3].Visible = false;
        
           // dgvItems.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (GlobalClass.GlobalInvItemId == "")
            {
                MessageBox.Show("Please select item.");
            }
            else if (txtSearch.Text == "")
            {
                MessageBox.Show("Please select item.");
            }
            else
            {
                frmReportViewer PreviewDialog = new frmReportViewer("Property_Card", "SELECT * FROM view_ItemHistory where fk_Inv_Id = '" + GlobalClass.GlobalInvItemId + "' order by Date");
                PreviewDialog.ShowDialog(); 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
