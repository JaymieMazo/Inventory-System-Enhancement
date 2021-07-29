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
    public partial class frmSummaryPerEmployee : Form
    {
        double Acc_Depreciation, Book_Value;
        public frmSummaryPerEmployee()
        {
            InitializeComponent();
        }

        private void frmSummaryPerEmployee_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllInvtems = "Select * from view_Inventory_Details";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllInvtems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[1].Visible = false;
            dgvItems.Columns[2].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.Columns[22].Visible = false;
            dgvItems.Columns[26].Visible = false;
            dgvItems.Columns[30].Visible = false;
            dgvItems.Columns[31].Visible = false;
            dgvItems.Columns[32].Visible = false;
            dgvItems.Columns[32].Visible = false;
            dgvItems.Columns[38].Visible = false;
            dgvItems.Columns[39].Visible = false;
            //dgvItems.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmAcccountableOfficers frm_Accountable = new frmAcccountableOfficers();
            frm_Accountable.ShowDialog();

            func_Retrieve_AOfficer();

        }

        private void func_Retrieve_AOfficer()
        {
            string RetrieveOfficer = "Select Full_Name from view_EmployeeDivision where pk_Employee_Id = ' " + GlobalClass.GlobalOfficerId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand OfficerFinder = new SqlCommand(RetrieveOfficer, SysCon.SystemConnect);
            SqlDataReader OfficerReader = OfficerFinder.ExecuteReader();

            if (OfficerReader.Read())
            {
                txtName.Text = OfficerReader[0].ToString();
            }

            btnPrint.Enabled = true;

            OfficerReader.Close();
            OfficerReader.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            btnPrint.Enabled = false;

            GlobalClass.GlobalOfficerId = "";
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[Accountable Officer] LIKE '%" + txtName.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("No property accounted!");
                btnFind.Focus();

            }

            lblcount.Text = dgvItems.RowCount.ToString();

            //Update Depreciation Cost and Book Value

            func_Update_Dep_and_Book_Value();

            func_Load_All_Items();

            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[Accountable Officer] LIKE '%" + txtName.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
              //  MessageBox.Show("No property accounted!");
                btnFind.Focus();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }
        private void func_Update_Dep_and_Book_Value()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set Depreciated_Cost = @Depreciated_Cost,Book_Value =@Book_Value where pk_Id = @pk_Id";

            int x = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    string VarUcost = dgvItems.Rows[x].Cells[11].Value.ToString();
                    string EULife = dgvItems.Rows[x].Cells[12].Value.ToString();
                    string VarDateAcq = dgvItems.Rows[x].Cells[13].Value.ToString();

                    //Compute Depreciation and Book Value 
                    //Convert date of acquisition 
                    DateTime dt_Acq = Convert.ToDateTime(VarDateAcq);

                    //Get the difference from date today and date acquired
                    int MonthsUsed = (DateTime.Now.Year - dt_Acq.Year) * 12 + DateTime.Now.Month - dt_Acq.Month;

                    //get no. only from eul value
                    var E_UL = String.Join("", EULife.Where(Char.IsDigit));

                    //multiply to 12 to get value in months
                    double ESL = (Convert.ToDouble(E_UL) * 12);

                    //compute salvage cost / 5% of the unit cost
                    double Salvage_Value = (Convert.ToDouble(VarUcost) * .05);

                    //compute depreciation expense
                    double Depreciation_Exp = ((Convert.ToDouble(VarUcost) - Salvage_Value) / ESL);

                    //convert from date to month
                    double YearUsed = (Convert.ToDouble(MonthsUsed) / 12);

                    //Compute accumulated depreciation
                    Acc_Depreciation = System.Math.Round((Convert.ToDouble(Depreciation_Exp) * YearUsed), 2);

                    // Acc_Depreciation = Acc_Depreciation.ToString();

                    //Compute Book Value . Acquisition Cost - Accumulated Depreciation
                    Book_Value = ((Convert.ToDouble(VarUcost) - Acc_Depreciation));

                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                    cmdUpdate.Parameters.AddWithValue("@Depreciated_Cost", Acc_Depreciation);
                    cmdUpdate.Parameters.AddWithValue("@Book_Value", Book_Value);

                    cmdUpdate.ExecuteNonQuery();

                }
                x++;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (GlobalClass.GlobalOfficerId == "")
            {
                MessageBox.Show("Please select accountable officer!");
                btnFind.Focus();
            }
            else
            {
                frmReportViewer PreviewDialog = new frmReportViewer("Account_Report", "SELECT * FROM view_Inventory_Details where fk_Accountable_Employee_Id = '" + GlobalClass.GlobalOfficerId + "' order by [End User]");
                PreviewDialog.ShowDialog();
            }
         }

        }
    }
