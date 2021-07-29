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
    public partial class frmItemsHead : Form
    {
        string ItemDesc;
        string ItemCode;
        string UOM;

        public frmItemsHead()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchItems.Text = "";

            func_Load_All_Items();

        }

        private void func_Reset()
        {
            txtItemDescription.Text = "";
            cboUOM.Text = "";
            cboUOM.SelectedIndex = -1;

            txtItemDescription.Focus();

            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            func_Load_All_Items();
            func_Load_UOM();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            func_Reset();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtItemDescription.Text == "" || cboUOM.Text == "")
            {

                MessageBox.Show("Cannot continue saving! All fields are required.", "Adding New Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemDescription.Focus();
            }
            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to add this record?", "Add New Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_AddItem();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Adding New Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
            }
        }

        private void func_Check_Duplication_AddItem()
        {
            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string CheckDuplication = "Select Description from tbl_Items_Head where Description ='" + txtItemDescription.Text + "'";

            SqlCommand CheckRecordCommand = new SqlCommand(CheckDuplication, SysCon.SystemConnect);

            SqlDataReader CReader = CheckRecordCommand.ExecuteReader();
            if (CReader.Read())
            {
                MessageBox.Show("Item with the same data already exists!", "New Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemDescription.Focus();
                return;
            }
            else
            {
                func_Add_Item();
            }

            CReader.Close();
            CReader.Dispose();
        }

        private void func_Add_Item()
        {

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            string NewItem = "Insert into tbl_Items_Head (Description,UOM) Values('" + txtItemDescription.Text +
               "', '" + cboUOM.Text + "')";

            SqlCommand AddNewItem = new SqlCommand(NewItem, SysCon.SystemConnect);
            AddNewItem.ExecuteNonQuery();

            MessageBox.Show("New item has been successfully added!", "Add Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Add New Item = ' + '" + txtItemDescription.Text + "'+ ' ; UOM = '+ '" + cboUOM.Text + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //Close Connection
            SysCon.SystemConnect.Close();

            txtItemDescription.Text = "";
            cboUOM.SelectedIndex = -1;

            txtSearchItems.Text = "";
            func_Load_All_Items();
        }

        private void frmItemsHead_Load(object sender, EventArgs e)
        {
            func_Load_All_Items();

            func_Load_UOM();

            txtItemDescription.Focus();
        }
        private void func_Load_UOM()
        {
            string UOM = "Select pk_UOM_Id,UOM from tbl_UOM";

            //Close existing connection
            SysCon.CloseConnection();

            //Open Connectiond
            SysCon.SystemConnect.Open();

            //Loading all categories
            SqlCommand LoadUOM = new SqlCommand(UOM, SysCon.SystemConnect);
            SqlDataReader UOMReader = LoadUOM.ExecuteReader();

            while (UOMReader.Read())
            {
                cboUOM.Items.Add(UOMReader.GetValue(1));
            }

            UOMReader.Close();
            UOMReader.Dispose();

            //Close connection
            SysCon.SystemConnect.Close();
        }
        private void func_Load_All_Items()
        {
            //Close current connection
            SysCon.CloseConnection();

            SysCon.SystemConnect.Open();

            string AllItems = "Select * from tbl_Items_Head";

            SqlDataAdapter AllItemsAdapter = new SqlDataAdapter(AllItems, SysCon.SystemConnect);

            string srctbl = "tbl_Items_Head";

            DataSet ItemsData = new DataSet();

            AllItemsAdapter.Fill(ItemsData, srctbl);

            dgvItems.DataSource = ItemsData.Tables["tbl_Items_Head"];

            dgvItems.RowHeadersWidth = 5;

            dgvItems.Columns[0].Visible = false;

            dgvItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            SysCon.SystemConnect.Close();

            lblcount.Text = dgvItems.RowCount.ToString();
        }

        private void txtSearchItems_TextChanged(object sender, EventArgs e)
        {
            ((DataTable)dgvItems.DataSource).DefaultView.RowFilter = "Description LIKE '%" + txtSearchItems.Text + "%'";

            if (dgvItems.RowCount <= 0)
            {
                MessageBox.Show("Item not exists.");
                txtSearchItems.Text = "";

            }

            if (txtSearchItems.Text != "")
            {
                btnClear.Enabled = true;
            }

            if (txtSearchItems.Text == "")
            {
                btnClear.Enabled = false;
            }

            lblcount.Text = dgvItems.RowCount.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtItemDescription.Text == "")
            {
                MessageBox.Show("Please select item to update.");
            }

            else if (cboUOM.Text == "")
            {
                MessageBox.Show("Please select unit of measurement to continue.");
            }

            else
            {
                DialogResult mes = MessageBox.Show("Do you really want to update this record?", "Update Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (mes)
                {
                    case DialogResult.Yes:
                        {
                            func_Check_Duplication_UpdItem();
                            break;
                        }

                    case DialogResult.No:
                        {
                            MessageBox.Show("All information you type will be lost.", "Updating Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            func_Reset();
                            break;
                        }
                }
              }
        }

        private void func_Check_Duplication_UpdItem()
        {
            if (ItemDesc != txtItemDescription.Text|| UOM != cboUOM.Text) 
            {
                //close connection
                SysCon.CloseConnection();
                //open connection
                SysCon.SystemConnect.Open();

                string CheckDuplication_ItemDesc = "Select Description,UOM from tbl_Items_Head where Description ='" + txtItemDescription.Text + "' and UOM ='"+cboUOM.Text+"'";
                SqlCommand CheckDuplicateItemCommand = new SqlCommand(CheckDuplication_ItemDesc, SysCon.SystemConnect);

                SqlDataReader ItemDescReader = CheckDuplicateItemCommand.ExecuteReader();
                if (ItemDescReader.Read())
                {
                    MessageBox.Show("Item description already exists!", "Item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtItemDescription.Focus();
                    return;
                }
                else
                {
                    func_Update_Item();
                }
                ItemDescReader.Close();
                ItemDescReader.Dispose();
            }
            else
            {
                MessageBox.Show("No changes has  been made!");
                func_Reset();
                
            }



        }

        private void func_Update_Item()
        {
            string UpdateRecord = "Update tbl_Items_Head Set Description = '" + txtItemDescription.Text +
                   "',UOM = '" + cboUOM.Text + "' where pk_Item_Code = '" + ItemCode + "'";

            //close connection
            SysCon.CloseConnection();
            //open connection
            SysCon.SystemConnect.Open();

            //execute query
            SqlCommand UpdateItems = new SqlCommand();
            UpdateItems.CommandType = CommandType.Text;
            UpdateItems.CommandText = UpdateRecord;
            UpdateItems.Connection = SysCon.SystemConnect;
            UpdateItems.ExecuteNonQuery();


            //Insert  Activity to audit trail
            string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                   "', '" + GlobalClass.GlobalUser +
                   "', '" + DateTime.Now.ToString() +
                   "', 'Update Item description = ' + '" + txtItemDescription.Text + "'+ ' ; UOM = '+ '" + cboUOM.Text + "' + ' ; Item Code = ' + '" + ItemCode + "')";


            SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
            AuditTrail.ExecuteNonQuery();

            //close connection
            SysCon.SystemConnect.Close();

            MessageBox.Show("Item has been successfully updated!", "Update Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
            func_Reset();
            txtItemDescription.Focus();

            txtSearchItems.Text = "";
            func_Load_All_Items();
        }

        private void txtItemDescription_TextChanged(object sender, EventArgs e)
        {
        }

        private void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            func_Click_Items();
        }

        private void func_Click_Items()
        {
            ItemCode = dgvItems.CurrentRow.Cells[0].Value.ToString();
            txtItemDescription.Text = dgvItems.CurrentRow.Cells[1].Value.ToString();
            cboUOM.Text = dgvItems.CurrentRow.Cells[2].Value.ToString();

            ItemDesc = txtItemDescription.Text;
            UOM = cboUOM.Text;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to delete this record?", "Delete Item", MessageBoxButtons.YesNo);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Check_Existence_in_Inventory();
                        break;
                    }

            }

            func_Reset();
        }

        private void func_Delete_Item()
        {
            try
            {
                //close connection
                SysCon.CloseConnection();

                //open connection
                SysCon.SystemConnect.Open();

                //execute deletion
                SqlCommand DeleteItem = new SqlCommand();
                DeleteItem.CommandText = "Delete from tbl_Items_Head where pk_Item_Code = '" + ItemCode + "'";
                DeleteItem.CommandType = CommandType.Text;
                DeleteItem.Connection = SysCon.SystemConnect;
                DeleteItem.ExecuteNonQuery();

                MessageBox.Show("Item has been successfully deleted!", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Insert  Activity to audit trail

                string user = "Insert into tbl_Audit_Trail (Full_Name,User_Name,Date_Time,Activity) Values ('" + GlobalClass.GlobalName +
                       "', '" + GlobalClass.GlobalUser +
                       "', '" + DateTime.Now.ToString() +
                       "', 'Delete Item description = ' + '" + txtItemDescription.Text + "'+ ' ; UOM = '+ '" + cboUOM.Text + "')";


                SqlCommand AuditTrail = new SqlCommand(user, SysCon.SystemConnect);
                AuditTrail.ExecuteNonQuery();

                txtSearchItems.Text = "";
                func_Load_All_Items();

            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void func_Check_Existence_in_Inventory()
        {
          
            string Check_ItemCode = "Select fk_Item_Code from tbl_Inventory_Details where fk_Item_Code = ' " + ItemCode + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand CodeFinder = new SqlCommand(Check_ItemCode, SysCon.SystemConnect);
            SqlDataReader CodeReader = CodeFinder.ExecuteReader();

            if (CodeReader.Read())
            {
                MessageBox.Show("This data cannot be deleted due to some dependency issue. \nPlease contact the System Administrator for assistance.", "Delete Item", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSearchItems.Text = "";
            }
            else
            {
                func_Delete_Item();

            }

            CodeReader.Close();
            CodeReader.Dispose();
        }



        private void btnUpdate_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void dgvItems_KeyUp(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void txtItemDescription_MouseClick(object sender, MouseEventArgs e)
        {
            txtItemDescription.BackColor = Color.Aquamarine;
        }

        private void txtItemDescription_Leave(object sender, EventArgs e)
        {
            txtItemDescription.BackColor = Color.White;
        }

        private void cboUOM_MouseClick(object sender, MouseEventArgs e)
        {
            cboUOM.BackColor = Color.Aquamarine;
        }

        private void cboUOM_Leave(object sender, EventArgs e)
        {
            cboUOM.BackColor = Color.White;
        }

        private void txtSearchItems_MouseClick(object sender, MouseEventArgs e)
        {
            txtSearchItems.BackColor = Color.Aquamarine;
        }

        private void txtSearchItems_Leave(object sender, EventArgs e)
        {
            txtSearchItems.BackColor = Color.White;
        }

        private void dgvItems_KeyDown(object sender, KeyEventArgs e)
        {
            func_Click_Items();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
