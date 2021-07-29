using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace BOI_Inventory_System
{
    public partial class frmAllInventoryItems : Form
    {
        double Acc_Depreciation, Book_Value;
    //    string IsInv_Value;
        public frmAllInventoryItems()
        {
            InitializeComponent();
        }

        private void frmAllInventoryItems_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();
            cboSearchCriteria.Focus();
            cboSearchCriteria.SelectedIndex = 0;

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
                    string VarUcost = dgvItems.Rows[x].Cells[7].Value.ToString();
                    string EULife = dgvItems.Rows[x].Cells[8].Value.ToString();
                    string VarDateAcq = dgvItems.Rows[x].Cells[9].Value.ToString();

                    if (VarUcost != "0" && EULife !="" && EULife != "0")
                    {
                        //Compute Depreciation and Book Value 
                        //Convert date of acquisition 
                        DateTime dt_Acq = Convert.ToDateTime(VarDateAcq);

                        //Get the difference from date today and date acquired
                        int MonthsUsed = (DateTime.Now.Year - dt_Acq.Year) * 12 + DateTime.Now.Month - dt_Acq.Month;

                        //get no. only from eul value
                        var E_UL = String.Join("", EULife.Where(Char.IsDigit));

                        //multiply to 12 to get value in months
                        double ESL = (Convert.ToDouble(E_UL));

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

                        if (Book_Value <= Salvage_Value)
                        {
                            cmdUpdate.Parameters.Clear();
                            cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                            cmdUpdate.Parameters.AddWithValue("@Depreciated_Cost", Acc_Depreciation);
                            cmdUpdate.Parameters.AddWithValue("@Book_Value", Salvage_Value);
                        }
                        else
                        {
                            cmdUpdate.Parameters.Clear();
                            cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                            cmdUpdate.Parameters.AddWithValue("@Depreciated_Cost", Acc_Depreciation);
                            cmdUpdate.Parameters.AddWithValue("@Book_Value", Book_Value);
                        }
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                x++;
            }
            func_Load_All_Items();
            MessageBox.Show("Data has been updated!", "Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllExItems = "Select pk_Id,Category_Name,Subcategory_Name,Article_Name,Description,UOM,Serial_No,Unit_Cost,EUL_Name,Date_Acquired,Depreciated_Cost,Book_Value,Warranty_Validity,Old_Property_No,New_Property_No,Location_Name,Mode_of_Acquisition,Status,Document_No,Date_Issued,Date_Received,[Accountable Officer],Designation,[End User],[End User Unit],Inventory_Date,Remarks,IsSubscribed,EOS,Office from view_Inventory_Details where Status  != 'CANCELLED PROPERTY NO.'";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllExItems, SysCon.SystemConnect);

            string srctbl = "view_Inventory_Details";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["view_Inventory_Details"];
            dgvItems.Columns[0].Visible = false;
            dgvItems.RowHeadersWidth = 5;

            //string query = "Select SUM (Unit_Cost) from view_Inventory_Details";
            //using (System.Data.IDbCommand command = new System.Data.OleDb.OleDbCommand(query))
            //{
            //    object result = command.ExecuteScalar();
            //    lblCost.Text = Convert.ToString(result);
            //}

            SysCon.SystemConnect.Close();
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

            if (cboSearchCriteria.Text == "Old Property Number")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Old_Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";

                }
            }
            if (cboSearchCriteria.Text == "New Property Number")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "New_Property_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Property Number does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Status")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Status LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Status does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Location")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Location_Name LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Location does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Unit")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[End User Unit] LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Unit does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Category")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Category_Name LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Category does not exists! ");
                    txtSearch.Text = "";

                }
            }
            if (cboSearchCriteria.Text == "Subcategory")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Subcategory_Name LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Subcategory does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Article")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Article_Name LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Article does not exists! ");
                    txtSearch.Text = "";

                }
            }

            if (cboSearchCriteria.Text == "Document No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Document_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Document No. does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (cboSearchCriteria.Text == "Serial No.")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Serial_No LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Serial No. does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (cboSearchCriteria.Text == "Service")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[End User Unit] LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Service Code name does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (cboSearchCriteria.Text == "Office")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Office LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("Service Code name does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (cboSearchCriteria.Text == "Unit Cost")
            {
                if (txtSearch.Text != "")
                {
                    Convert.ToDouble(txtSearch.Text);

                    if (cboParam.Text == ">")
                    {
                        ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost > '" + txtSearch.Text + "'";

                        if (dgvItems.RowCount <= 0)
                        {
                            //       txtSearch.Text = "";

                        }
                    }

                    if (cboParam.Text == "<")
                    {
                        ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost < '" + txtSearch.Text + "'";

                        if (dgvItems.RowCount <= 0)
                        {
                            //  txtSearch.Text = "";

                        }
                    }

                    if (cboParam.Text == "=")
                    {
                        ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Unit_Cost = '" + txtSearch.Text + "'";

                        if (dgvItems.RowCount <= 0)
                        {
                            //     txtSearch.Text = "";

                        }
                    }

                    if (cboParam.Text == "")
                    {
                        MessageBox.Show("Please select criteria for searching! ");
                        cboParam.Focus();
                    }
                }
            }


            if (cboSearchCriteria.Text == "End User")
            {

                ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "[End User] LIKE '%" + txtSearch.Text + "%'";

                if (dgvItems.RowCount <= 0)
                {
                    MessageBox.Show("End user does not exists! ");
                    txtSearch.Text = "";

                }
            }


            if (txtSearch.Text == "")
            {
                func_Load_All_Items();

            }

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void cboSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            if (cboSearchCriteria.Text == "Unit Cost")
            {
                cboParam.Enabled = true;
                cboParam.SelectedIndex = 0;
                cboParam.Focus();
            }
            else { cboParam.Enabled = false; cboParam.Text = ""; cboParam.SelectedIndex = -1; }
        }



        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearch.BackColor = Color.Aquamarine;
        }

        private void groupBox1_Leave(object sender, EventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cboParam.Enabled = false;
            txtSearch.Focus();
            cboSearchCriteria.SelectedIndex = 0;
            cboParam.Text = "";

            func_Load_All_Items();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Inventory_Items.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvItems, sfd.FileName);

                MessageBox.Show("Export Completed!", "Export Inventory Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtSearch.Text = "";
                cboParam.Enabled = false;
                txtSearch.Focus();
                cboSearchCriteria.SelectedIndex = 0;
                cboParam.Text = "";
            }

        }

        private void cboParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void func_Check_EOS_Items()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();
            string UpdateRecord = "Update tbl_Inventory_Details Set Status = @Status,Document_No =@Document_No,fk_Accountable_Employee_Id = @fk_Accountable_Employee_Id, fk_End_User_Id = @fk_End_User_Id where pk_Id = @pk_Id";

            int x = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
                {
                    string IsSubscribed = dgvItems.Rows[x].Cells[27].Value.ToString();
                    string EOS = dgvItems.Rows[x].Cells[28].Value.ToString();
                    string Stat = dgvItems.Rows[x].Cells[17].Value.ToString();
                    //MessageBox.Show(Stat);
                    //Check if Item is Subscribed
                    if ((IsSubscribed == "1") && (Stat != "EXPIRED"))
                    {
                        //convert string to date
                        DateTime EOS_Date = DateTime.Parse(EOS);
                        DateTime DateNow = DateTime.Now;

                        {
                            if (DateNow > EOS_Date)    //Check if EOS = True ; if already reached the End of Service
                            {
                                //Update Status as "EXPIRED" , Remove Document_No , Accountable Officer and End User
                                cmdUpdate.Parameters.Clear();
                                cmdUpdate.Parameters.AddWithValue("@pk_Id", row.Cells[0].Value);
                                cmdUpdate.Parameters.AddWithValue("@Status", "EXPIRED");
                                cmdUpdate.Parameters.AddWithValue("@Document_No", "");
                                cmdUpdate.Parameters.AddWithValue("@fk_Accountable_Employee_Id", "");
                                cmdUpdate.Parameters.AddWithValue("@fk_End_User_Id", "");

                                cmdUpdate.ExecuteNonQuery();
                            }
                        }
                    }
                    x++;
                }
            }
            func_Load_All_Items();
            MessageBox.Show("Data has been updated!", "Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_Update_Dep_and_Book_Value();
        }

        private void updateSubscriptionDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            func_Check_EOS_Items();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //private void func_Update_IsInvData()
        //{
        //    //close connection
        //    SysCon.CloseConnection();
        //    //open connection
        //    SysCon.SystemConnect.Open();
        //    string UpdateRecord = "Update tbl_Inventory_Details Set Is_Inventoried = @IsInv_Value";

        //    int x = 0;

        //    foreach (DataGridViewRow row in dgvItems.Rows)
        //    {
        //        using (SqlCommand cmdUpdate = new SqlCommand(UpdateRecord, SysCon.SystemConnect))
        //        {
        //            cmdUpdate.Parameters.Clear();
        //            cmdUpdate.Parameters.AddWithValue("@IsInv_Value", IsInv_Value);
        //            cmdUpdate.ExecuteNonQuery();

        //            //Audit trail
        //            //Insert  Activity to audit trail
        //            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
        //                   "', '" + GlobalClass.GlobalUser +
        //                   "', '" + DateTime.Now.ToString() +
        //                   "', 'Update Item : ' + '" + row.Cells[6].Value + "' + ' ; Is Inventoried? : ' + '" + IsInv_Value + "')";


        //            SqlCommand AuditTrail1 = new SqlCommand(user, SysCon.SystemConnect);
        //            AuditTrail1.ExecuteNonQuery();
        //        }
        //    }
        //    x++;

        //    func_Load_All_Items();
        //        MessageBox.Show("Data has been updated!", "Batch Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }

        //private void btnUpdate_Click_1(object sender, EventArgs e)
        //{
        //    if (chkIsInventoried.CheckState == CheckState.Checked)
        //    { IsInv_Value = "1"; }
        //    else { IsInv_Value = "0"; }

        //    DialogResult mes = MessageBox.Show("Do you really want to update this batch of record? This process is irreversible.", "Batch Updating of Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    switch (mes)
        //    {
        //        case DialogResult.Yes:
        //            {
        //                func_Update_IsInvData();
        //                break;
        //            }

        //        case DialogResult.No:
        //            {
        //                break;
        //            }
        //    }
        //}

        private void chkIsInventoried_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }
}
