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
    public partial class frmPropertyTags : Form
    {
        string Id, PropertyNo, ItemDescription,IARNo;
        public frmPropertyTags()
        {
            InitializeComponent();
        }

        private void frmPropertyTags_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

            lblcount.Text = dgvItems.RowCount.ToString();
            lblcount2.Text = dgvItems2.RowCount.ToString();
            btnAdd.Enabled = false;


        }
        private void func_Load_All_Items()
        {

            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllItems = "Select * from view_Generated_Property_No where Status = 'For Assignment' and fk_Record_Id != 0";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllItems, SysCon.SystemConnect);

            string srctbl = "view_Generated_Property_No";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Generated_Property_No"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[6].Visible = false;

            dgvItems.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();
            lblcount2.Text = dgvItems2.RowCount.ToString();

        }

        private void func_Update_Receiving_Head()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
           // string UpdateRecord = "Update tbl_Inventory_Details Set Status = @Status,Remarks = @Remarks where Property_No = @Property_No";
            string UpdateRecord = "Update tbl_Receiving_Items_Head Set Remarks = @Remarks where IAR_No = @IAR_No";
            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@Remarks", "Item Description : " + row.Cells[3].Value + " ; Reason for cancellation of Property No. : " + txtRemarks.Text + " ; Property No. : " + row.Cells[2].Value);
                    cmdUpdate.Parameters.AddWithValue("@IAR_No", row.Cells[1].Value);
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearchCriteria.Text == "Item Description")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Item description does not exists!");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Property Number")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "DR No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "DR_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("DR No. does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (txtSearch.Text == "")
            {
                func_Load_All_Items();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvItems2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            func_Add_To_Grid();

            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dgvItems2.SelectedRows)
            {
                dgvItems2.Rows.RemoveAt(item.Index);
            }

            lblcount2.Text = dgvItems2.RowCount.ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            func_Load_All_Items();

            Reset();
        }

        private void Reset()
        {
            if (dgvItems2.DataSource != null)
            {
                dgvItems2.DataSource = null;
            }
            else
            {
                dgvItems2.Rows.Clear();
            }

            txtSearch.Text = "";
            cboSearchCriteria.Text = "";
            cboSearchCriteria.SelectedIndex = 0;
            txtRemarks.Text = "";

            lblcount2.Text = dgvItems2.RowCount.ToString();

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvItems2.Rows.Count == 0)
            {
                MessageBox.Show("Please select Property Number/s to cancel.", "Property No. Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if ( txtRemarks.Text == "")
            {
                MessageBox.Show("Please indicate reason for cancellation of property number.", "Property No. Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                {
                    DialogResult mes = MessageBox.Show("Do you really want to cancel the selected Property No/s.?", "Property No. Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    switch (mes)
                    {
                        case DialogResult.Yes:
                            {
                                func_Update_Status();
                                func_Update_Receiving_Head();
                                func_Load_All_Items();
                                Reset();
                                break;
                            }

                        case DialogResult.No:
                            {
                                MessageBox.Show("This will reset the fields.", "Property No. Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Reset();
                                break;
                            }
                    }
                }

              
            }
        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void txtRemarks_MouseClick(object sender, MouseEventArgs e)
        {
            txtRemarks.BackColor = Color.Aquamarine;
        }

        private void txtRemarks_Leave(object sender, EventArgs e)
        {
            txtRemarks.BackColor = Color.White;
        }

        private void func_Update_Status()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set Status = @Status,Remarks = @Remarks,fk_Accountable_Employee_Id =@fk_Accountable_Employee_Id,fk_End_User_Id=@fk_End_User_Id where Old_Property_No = @Property_No";
            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@Status", "CANCELLED PROPERTY NO.");
                    cmdUpdate.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
                    cmdUpdate.Parameters.AddWithValue("@Property_No", row.Cells[2].Value);
                    cmdUpdate.Parameters.AddWithValue("@fk_Accountable_Employee_Id", " ");
                    cmdUpdate.Parameters.AddWithValue("@fk_End_User_Id", " ");

                    cmdUpdate.ExecuteNonQuery();
                }
            }

            //Audit trail
            string user = "Insert into tbl_Audit_Trail Values (@Full_Name,@User_Name,@Date_Time,@Activity)";

            foreach (DataGridViewRow row in dgvItems2.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(user, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@Full_Name", GlobalClass.GlobalName);
                        cmd.Parameters.AddWithValue("@User_Name", GlobalClass.GlobalUser);
                        cmd.Parameters.AddWithValue("@Date_Time", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@Activity", "Cancel Property No. : " + row.Cells[2].Value + " ; Item Desciption : " + row.Cells[3].Value + " ; Reason for Cancellation : " + txtRemarks.Text + " ; Reference Number : " + row.Cells[1].Value );
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Property No/s.  has been successfully cancelled!", "Property No Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void func_Add_To_Grid()
        {
            int CurrentRow = dgvItems2.Rows.Add();

            dgvItems2.Rows[CurrentRow].Cells[0].Value = Id;
            dgvItems2.Rows[CurrentRow].Cells[1].Value = IARNo;
            dgvItems2.Rows[CurrentRow].Cells[2].Value = PropertyNo;
            dgvItems2.Rows[CurrentRow].Cells[3].Value = ItemDescription;
           

            txtSearch.Text = "";
            cboSearchCriteria.Text = "";
            cboSearchCriteria.SelectedIndex = -1;

        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = dgvItems.CurrentRow.Cells[0].Value.ToString();
            PropertyNo = dgvItems.CurrentRow.Cells[3].Value.ToString();
            ItemDescription = dgvItems.CurrentRow.Cells[4].Value.ToString();
            IARNo = dgvItems.CurrentRow.Cells[6].Value.ToString();

            btnAdd.Enabled = true;
        }
    }
}
