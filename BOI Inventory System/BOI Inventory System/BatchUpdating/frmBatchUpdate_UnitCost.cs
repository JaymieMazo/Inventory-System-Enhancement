using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace BOI_Inventory_System.BatchUpdating
{
    public partial class frmBatchUpdate_UnitCost : Form
    {
        public frmBatchUpdate_UnitCost()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            func_Reset();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvItems.Rows.Count == 0 || txtUnitCost.Text == "")
            {
                MessageBox.Show("Kindly select tthe items and indicate the Unit Cost .", "Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this batch of record? This process is irreversible.", "Batch Data Updating", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                          func_Update_Data();
                            break;
                        }

                    case DialogResult.No:
                        {
                            break;
                        }
                }
            }

        }
        private void func_Reset()
        {
            //Clear gridview contents
            if (dgvItems.DataSource != null)
            {
                dgvItems.DataSource = null;
            }
            else
            {
                dgvItems.Rows.Clear();
            }

            txtSearch.Text = "";
            txtUnitCost.Text = "";
            txtOldUCost.Text = "";
         
            func_Load_All_Items();

            cboCriteria.SelectedIndex = 0;
        }
        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Category_Name,Subcategory_Name,Subcategory_Code,Article_Code,Article_Name,Description,UOM,Serial_No,Unit_Cost,EUL_Name,Date_Acquired,Depreciated_Cost,Book_Value,Old_Property_No,New_Property_No,Status,Document_No,[Accountable Officer],Designation,[End User],[End User Unit],Inventory_Date,Remarks,EOS from view_Inventory_Details where (STATUS != 'EXPIRED')";
            //(Status != 'FOR ASSIGNMENT' AND Status!= 'EXPIRED'
            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
            dgvItems.Columns[0].Visible = false;
            dgvItems.Columns[3].Visible = false;
            dgvItems.Columns[4].Visible = false;
            dgvItems.RowHeadersWidth = 5;

            SysCon.SystemConnect.Close();


            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text == "")
            //{
            //    //
            //}
            //else
            //{

            //    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";

            //    if (dgvItems.RowCount <= 0)
            //    {
            //        MessageBox.Show("Item does not exists.");
            //        txtSearch.Text = "";

            //    }
            //}


            //lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void frmBatchUpdate_UnitCost_Load(object sender, EventArgs e)
        {
            func_Reset();
            func_Load_All_Items();
            cboCriteria.SelectedIndex = 0;
        }

        private void txtUnitCost_TextChanged(object sender, EventArgs e)
        {
            float num;
            bool isNumeric = float.TryParse(txtUnitCost.Text, out num);
            if (isNumeric)
            {
                //
            }
            else if (txtUnitCost.Text == "")
            {
                //
            }
            else
            {
                MessageBox.Show("Not a valid value for unit cost.", "Wrong Input");
                txtUnitCost.Text = "";
            }


        }
        private void func_Update_Data()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set Unit_Cost = @Unit_Cost where pk_Id = @pk_Id";
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    cmdUpdate.Parameters.Clear();
                    cmdUpdate.Parameters.AddWithValue("@Unit_Cost", txtUnitCost.Text);
                    cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                    cmdUpdate.ExecuteNonQuery();
                }
            }

            //Audit trail
            string user = "Insert into tbl_Audit_Trail Values (@Full_Name,@User_Name,@Date_Time,@Activity)";

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmd = new SqlCommand(user, SysCon.SystemConnect))
                {
                    {
                        cmd.Parameters.AddWithValue("@Full_Name", GlobalClass.GlobalName);
                        cmd.Parameters.AddWithValue("@User_Name", GlobalClass.GlobalUser);
                        cmd.Parameters.AddWithValue("@Date_Time", DateTime.Now.ToString());
                        cmd.Parameters.AddWithValue("@Activity", "Item Desciption : " + row.Cells[6].Value + " ; Unit Cost : " + txtUnitCost.Text+ "'");
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            MessageBox.Show("Unit Cost value/s has been successfully updated!", "Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            func_Reset();
            func_Load_All_Items();
        }

        private void txtOldUCost_TextChanged(object sender, EventArgs e)
        {
            float num;
            bool isNumeric = float.TryParse(txtUnitCost.Text, out num);
            if (isNumeric)
            {
                //
            }
            else if (txtUnitCost.Text == "")
            {
                //
            }
            else
            {
                MessageBox.Show("Not a valid value for unit cost.", "Wrong Input");
                txtOldUCost.Text = "";
            }
          

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtProcess_Click(object sender, EventArgs e)
        {
            if (txtOldUCost.Text == "" && txtSearch.Text == "")
            {
                MessageBox.Show("Please indicate searching criteria.");
            }
           if (txtSearch.Text != "" && txtUnitCost.Text == "")
            {
                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%'";
            }
            if (txtOldUCost.Text != "" && txtSearch.Text=="")
            {
                Convert.ToDouble(txtOldUCost.Text);

                if (cboCriteria.Text == ">")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost > '" + txtOldUCost.Text + "'";
                }
                else if (cboCriteria.Text == "<")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost < '" + txtOldUCost.Text + "'";
                }
                else if (cboCriteria.Text == "=")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost = '" + txtOldUCost.Text + "'";
                }
            }
            if (txtOldUCost.Text != "" && txtSearch.Text != "")
            {
                if (cboCriteria.Text == ">")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%' AND Unit_Cost > '" + txtOldUCost.Text + "'";
                }
                else if (cboCriteria.Text == "<")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%' AND Unit_Cost < '" + txtOldUCost.Text + "'";
                }
                else if (cboCriteria.Text == "=")
                {
                    ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearch.Text + "%' AND Unit_Cost = '" + txtOldUCost.Text + "'";
                }
            }

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("Item does not exists.");
                func_Reset();
            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }
    }
}
