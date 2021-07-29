using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BOI_Inventory_System
{
    public partial class frmMain : Form
    {
        public frmMain()
        {

            InitializeComponent();

            frmLogIn MyLoginDialog = new frmLogIn();
            MyLoginDialog.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {  
            //if Failed Authentication , close this form
            if (!GlobalClass.Authenticated)
            {
                this.Close();
            }
            toolStripStatusLabel2.Text = "Current User: ";
            toolStripStatusLabel1.Text = GlobalClass.GlobalName;

            GlobalClass.GlobalDateTime = dateTimePicker1.Value.ToString();

            if (GlobalClass.GlobalUserType != "ADMINISTRATOR")
            {
                btnUsers.Enabled = false;
            }
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
          

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmSystemUserManagement frm_UsersMngt = new frmSystemUserManagement();
            frm_UsersMngt.Show();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
        
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCategoryMaintenance_Click(object sender, EventArgs e)
        {
            frmCategories frm_Categories = new frmCategories();
            frm_Categories.Show();
        }

        private void btnSubCatMaintenance_Click(object sender, EventArgs e)
        {
            frmSubcategories frm_SubCategories = new frmSubcategories();
            frm_SubCategories.Show();
        }

        private void btnArticlesMaintenance_Click(object sender, EventArgs e)
        {

            frmArticles frm_Articles = new frmArticles();
            frm_Articles.Show();
        }

        private void btnItemHead_Click(object sender, EventArgs e)
        {
            frmItemsHead frm_ItemsHead = new frmItemsHead();
            frm_ItemsHead.Show();
        }

        private void btnReceiving_Click(object sender, EventArgs e)
        {
            File_Maintenance.frmReceivingItem frm_ReceivingItem = new File_Maintenance.frmReceivingItem();
            frm_ReceivingItem.Show();
        }

        private void btnESL_Click(object sender, EventArgs e)
        {
            frmESL frm_ESL = new frmESL();
            frm_ESL.Show();
        }

        private void btnSOE_Click(object sender, EventArgs e)
        {
            //frm_StatusOfEquipment frmStatusOfEquipment = new frm_StatusOfEquipment();
            //frmStatusOfEquipment.ShowDialog();

        }

        private void btnSupplierCategory_Click(object sender, EventArgs e)
        {
            File_Maintenance.frmSupplierCategory frm_SupplierCategory = new File_Maintenance.frmSupplierCategory();
            frm_SupplierCategory.Show();

        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            frmSuppliers frm_Suppliers = new frmSuppliers();
            frm_Suppliers.Show();
        }

        private void btnAuditTrail_Click(object sender, EventArgs e)
        {
            frmAuditTrail frm_AuditTrail = new frmAuditTrail();
            frm_AuditTrail.Show();
        }

        private void btnExisting_Click(object sender, EventArgs e)
        {
            frmExistingItem frm_ExistingItem = new frmExistingItem();
            frm_ExistingItem.Show();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            frmService frm_Services = new frmService();
            frm_Services.Show();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            File_Maintenance.frmDivision frm_Division = new File_Maintenance.frmDivision();
            frm_Division.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            frmBOIEmployees frm_BOIEmployees = new frmBOIEmployees();
            frm_BOIEmployees.Show();
        }

        private void btnAssignment_Click(object sender, EventArgs e)
        {
            frmAssignmentPerEmployee frm_Assignment = new frmAssignmentPerEmployee();
            frm_Assignment.Show();
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            frmLocation frm_Location = new frmLocation();
            frm_Location.Show();
        }

        private void btnPropertyTags_Click(object sender, EventArgs e)
        {
            frmPropertyTags frm_PropertyTags = new frmPropertyTags();
            frm_PropertyTags.Show();
        }

        private void btnInvItems_Click(object sender, EventArgs e)
        {
            frmAllInventoryItems frm_InvItems = new frmAllInventoryItems();
            frm_InvItems.Show();
        }

        private void btnPullOut_Click(object sender, EventArgs e)
        {
            frmPullOut frm_PullOUt = new frmPullOut();
            frm_PullOUt.Show();
        }

        private void btnRepairs_Click(object sender, EventArgs e)
        {
            frmItemsForRepair frm_ForRepair = new frmItemsForRepair();
            frm_ForRepair.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            frmSummaryPerEmployee frm_Summary = new frmSummaryPerEmployee();
            frm_Summary.Show();
        }

        private void btnInventoryReport_Click(object sender, EventArgs e)
        {
            frmInventorySummary frm_Inventory = new frmInventorySummary();
            frm_Inventory.Show();
        }

        private void btnInventories_Click(object sender, EventArgs e)
        {
            frmInventoryPerUser frm_Inventories = new frmInventoryPerUser();
            frm_Inventories.Show();
        }

        private void btnPropertyCard_Click(object sender, EventArgs e)
        {
            frmPropertyCard frm_Property_Card = new frmPropertyCard();
            frm_Property_Card.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void btnDisposalReport_Click(object sender, EventArgs e)
        {
        }

        private void btnItemReceived_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInventoryUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnRR_Click(object sender, EventArgs e)
        {
            frmReceivingHistory frm_Receiving_History = new frmReceivingHistory();
            frm_Receiving_History.Show();
        }

        private void btnPARICS_Click(object sender, EventArgs e)
        {
            frmAssignmentHistory frm_AssignmentHistory = new frmAssignmentHistory();
            frm_AssignmentHistory.Show();
        }

        private void btnRS_Click(object sender, EventArgs e)
        {
            frmPullOutHistory frm_PullOutHistory = new frmPullOutHistory();
            frm_PullOutHistory.Show();
        }

        private void btnRepairHistory_Click(object sender, EventArgs e)
        {
            frmRepairHIstory frm_RepairHistory = new frmRepairHIstory();
            frm_RepairHistory.Show();
        }

        private void btnDisposalHistory_Click(object sender, EventArgs e)
        {
            frmDisposalHistory frm_DisposalHistory = new frmDisposalHistory();
            frm_DisposalHistory.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnModeOfAcquisition_Click(object sender, EventArgs e)
        {
            frm_ModeofAcquisition frmModeofAcq = new frm_ModeofAcquisition();
            frmModeofAcq.Show();
        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
            if (tabControl2.SelectedIndex == 8)
            {
                frmAbout frm_About = new frmAbout();
                frm_About.ShowDialog();

                tabControl2.SelectedIndex = 0;
            }

           
        }

        private void btnReceiving_MouseHover(object sender, EventArgs e)
        {
            btnReceiving.Height = 96;
            btnReceiving.Width = 106;

        }

        private void btnReceiving_MouseLeave(object sender, EventArgs e)
        {
            btnReceiving.Height = 86;
            btnReceiving.Width = 96;

        }

        private void btnAssignment_MouseHover(object sender, EventArgs e)
        {
            btnAssignment.Height = 96;
            btnAssignment.Width = 106;

        }

        private void btnAssignment_MouseLeave(object sender, EventArgs e)
        {
            btnAssignment.Height = 86;
            btnAssignment.Width = 96;
        }

        private void btnPullOut_MouseHover(object sender, EventArgs e)
        {
            btnPullOut.Height = 96;
            btnPullOut.Width = 106;
        }

        private void btnPullOut_MouseLeave(object sender, EventArgs e)
        {
            btnPullOut.Height = 86;
            btnPullOut.Width = 96;

        }

        private void btnPropertyTags_MouseHover(object sender, EventArgs e)
        {
            btnPropertyTags.Height = 96;
            btnPropertyTags.Width = 106;

        }

        private void btnPropertyTags_MouseLeave(object sender, EventArgs e)
        {
            btnPropertyTags.Height = 86;
            btnPropertyTags.Width = 96;
        }

        private void btnRepairs_MouseHover(object sender, EventArgs e)
        {

            btnRepairs.Height = 96;
            btnRepairs.Width = 106;
        }

        private void btnRepairs_MouseLeave(object sender, EventArgs e)
        {
            btnRepairs.Height = 86;
            btnRepairs.Width = 96;
        }

        private void btnDisposal_Click(object sender, EventArgs e)
        {
            frmForDisposal frm_ForDisposal = new frmForDisposal();
            frm_ForDisposal.Show();
        }

        private void btnDisposal_MouseHover(object sender, EventArgs e)
        {
            btnDisposal.Height = 96;
            btnDisposal.Width = 106;
        }

        private void btnDisposal_MouseLeave(object sender, EventArgs e)
        {
            btnDisposal.Height = 86;
            btnDisposal.Width = 96;

        }

        private void btnExisting_MouseHover(object sender, EventArgs e)
        {
            btnExisting.Height = 96;
            btnExisting.Width = 106;
        }

        private void btnExisting_MouseLeave(object sender, EventArgs e)
        {
            btnExisting.Height = 86;
            btnExisting.Width = 96;
        }

     

        private void btnInvItems_MouseHover(object sender, EventArgs e)
        {
            btnInvItems.Height = 96;
            btnInvItems.Width = 106;

        }

        private void btnInvItems_MouseLeave(object sender, EventArgs e)
        {
            btnInvItems.Height = 86;
            btnInvItems.Width = 96;
        }

        private void btnInventories_MouseHover(object sender, EventArgs e)
        {
            btnInventories.Height = 96;
            btnInventories.Width = 106;
        }

        private void btnRR_MouseHover(object sender, EventArgs e)
        {
            btnRR.Height = 96;
            btnRR.Width = 106;
        }

        private void btnInventories_MouseLeave(object sender, EventArgs e)
        {
            btnInventories.Height = 86;
            btnInventories.Width = 96;
        }

        private void btnRR_MouseLeave(object sender, EventArgs e)
        {
            btnRR.Height = 86;
            btnRR.Width = 96;
        }

        private void btnPARICS_MouseHover(object sender, EventArgs e)
        {
            btnPARICS.Height = 96;
            btnPARICS.Width = 106;

        }

        private void btnPARICS_MouseLeave(object sender, EventArgs e)
        {
            btnPARICS.Height = 86;
            btnPARICS.Width = 96;
        }

        private void btnRS_MouseHover(object sender, EventArgs e)
        {
            btnRS.Height = 96;
            btnRS.Width = 106;
        }

        private void btnRS_MouseLeave(object sender, EventArgs e)
        {
            btnRS.Height = 86;
            btnRS.Width = 96;
        }

        private void btnRepairHistory_MouseHover(object sender, EventArgs e)
        {
            btnRepairHistory.Height = 96;
            btnRepairHistory.Width = 106;

        }

        private void btnRepairHistory_MouseLeave(object sender, EventArgs e)
        {
            btnRepairHistory.Height = 86;
            btnRepairHistory.Width = 96;
        }

        private void btnDisposalHistory_MouseLeave(object sender, EventArgs e)
        {
            btnDisposalHistory.Height = 86;
            btnDisposalHistory.Width = 96;
        }

        private void btnDisposalHistory_MouseHover(object sender, EventArgs e)
        {
            btnDisposalHistory.Height = 96;
            btnDisposalHistory.Width = 106;
        }

        private void btnReports_MouseHover(object sender, EventArgs e)
        {
            btnReports.Height = 96;
            btnReports.Width = 106;
        }

        private void btnReports_MouseLeave(object sender, EventArgs e)
        {
            btnReports.Height = 86;
            btnReports.Width = 96;
        }

        private void btnInventoryReport_MouseHover(object sender, EventArgs e)
        {
            btnInventoryReport.Height = 96;
            btnInventoryReport.Width = 106;
        }

        private void btnInventoryReport_MouseLeave(object sender, EventArgs e)
        {
            btnInventoryReport.Height = 86;
            btnInventoryReport.Width = 96;
        }

        private void btnPropertyCard_MouseHover(object sender, EventArgs e)
        {
            btnPropertyCard.Height = 96;
            btnPropertyCard.Width = 106;

        }

        private void btnPropertyCard_MouseLeave(object sender, EventArgs e)
        {
            btnPropertyCard.Height = 86;
            btnPropertyCard.Width = 96;

        }

        private void btnUsers_MouseLeave(object sender, EventArgs e)
        {
            btnUsers.Height = 86;
            btnUsers.Width = 96;
        }

        private void btnUsers_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnUsers_MouseHover(object sender, EventArgs e)
        {
            btnUsers.Height = 96;
            btnUsers.Width = 106;

        }

        private void btnDisposalHistory_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnCategoryMaintenance_MouseHover(object sender, EventArgs e)
        {
            btnCategoryMaintenance.Height = 96;
            btnCategoryMaintenance.Width = 100;
        }

        private void btnCategoryMaintenance_MouseLeave(object sender, EventArgs e)
        {
            btnCategoryMaintenance.Height = 86;
            btnCategoryMaintenance.Width = 96;
        }

        private void btnSubCatMaintenance_MouseHover(object sender, EventArgs e)
        {

            btnSubCatMaintenance.Height = 96;
            btnSubCatMaintenance.Width = 100;
        }
   

        private void btnSubCatMaintenance_MouseLeave(object sender, EventArgs e)
        {
            btnSubCatMaintenance.Height = 86;
            btnSubCatMaintenance.Width = 96;
    }

        private void btnArticlesMaintenance_MouseHover(object sender, EventArgs e)
        {
            btnArticlesMaintenance.Height = 96;
            btnArticlesMaintenance.Width = 100;

        }

        private void btnArticlesMaintenance_MouseLeave(object sender, EventArgs e)
        {
            btnArticlesMaintenance.Height = 86;
            btnArticlesMaintenance.Width = 96;

        }

        private void btnItemHead_MouseHover(object sender, EventArgs e)
        {
            btnItemHead.Height = 96;
            btnItemHead.Width = 100;

        }

        private void btnItemHead_MouseLeave(object sender, EventArgs e)
        {

            btnItemHead.Height = 86;
            btnItemHead.Width = 96;
        }

        private void btnESL_MouseLeave(object sender, EventArgs e)
        {
            btnESL.Height = 86;
            btnESL.Width = 96;
        }

        private void btnESL_MouseHover(object sender, EventArgs e)
        {
            btnESL.Height = 96;
            btnESL.Width = 100;
        }

        private void btnSupplierCategory_MouseHover(object sender, EventArgs e)
        {
            btnSupplierCategory.Height = 96;
            btnSupplierCategory.Width = 100;
        }

        private void btnSupplierCategory_MouseLeave(object sender, EventArgs e)
        {
            btnSupplierCategory.Height = 86;
            btnSupplierCategory.Width = 96;
        }

        private void btnSuppliers_MouseLeave(object sender, EventArgs e)
        {
            btnSuppliers.Height = 86;
            btnSuppliers.Width = 96;
        }

        private void btnSuppliers_MouseHover(object sender, EventArgs e)
        {
            btnSuppliers.Height = 96;
            btnSuppliers.Width = 100;
        }

        private void btnModeOfAcquisition_MouseHover(object sender, EventArgs e)
        {
            btnModeOfAcquisition.Height = 96;
            btnModeOfAcquisition.Width = 100;
        }

        private void btnModeOfAcquisition_MouseLeave(object sender, EventArgs e)
        {
            btnModeOfAcquisition.Height = 86;
            btnModeOfAcquisition.Width = 96;

        }

        private void btnServices_MouseHover(object sender, EventArgs e)
        {
            btnServices.Height = 96;
            btnServices.Width = 106;
        }

        private void btnServices_MouseLeave(object sender, EventArgs e)
        {
            btnServices.Height = 86;
            btnServices.Width = 96;
        }

        private void btnDivision_MouseHover(object sender, EventArgs e)
        {
            btnDivision.Height = 96;
            btnDivision.Width = 106;
        }

        private void btnDivision_MouseLeave(object sender, EventArgs e)
        {
            btnDivision.Height = 86;
            btnDivision.Width = 96;

        }

        private void btnEmployees_MouseHover(object sender, EventArgs e)
        {
            btnEmployees.Height = 96;
            btnEmployees.Width = 106;
        }

        private void btnEmployees_MouseLeave(object sender, EventArgs e)
        {
            btnEmployees.Height = 86;
            btnEmployees.Width = 96;

        }

        private void btnLocations_MouseHover(object sender, EventArgs e)
        {
            btnLocations.Height = 96;
            btnLocations.Width = 100;

        }

        private void btnLocations_MouseLeave(object sender, EventArgs e)
        {
            btnLocations.Height = 86;
            btnLocations.Width = 96;
        }

        private void btnAuditTrail_MouseHover(object sender, EventArgs e)
        {
            btnAuditTrail.Height = 96;
            btnAuditTrail.Width = 100;
        }

        private void btnAuditTrail_MouseLeave(object sender, EventArgs e)
        {
            btnAuditTrail.Height = 86;
            btnAuditTrail.Width = 96;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePassword frm_ChangePass = new frmChangePassword();
            frm_ChangePass.ShowDialog();
        }

        private void btnComponents_Click(object sender, EventArgs e)
        {
            Transactions.frmComponentList frmComponentsList = new Transactions.frmComponentList();
            frmComponentsList.Show();
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
            BatchUpdating.frmBatchUpdate frmBatchUp = new BatchUpdating.frmBatchUpdate();
            frmBatchUp.ShowDialog();
        }

        private void frmBatchCost_Click(object sender, EventArgs e)
        {
            BatchUpdating.frmBatchUpdate_UnitCost frmBatchUpCost = new BatchUpdating.frmBatchUpdate_UnitCost();
            frmBatchUpCost.ShowDialog();
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            BatchUpdating.frmBatchUpdateSubscribedItems frmSubscriptions = new BatchUpdating.frmBatchUpdateSubscribedItems();
            frmSubscriptions.Show();
        }

        private void btnInventoryUpdate_Click_1(object sender, EventArgs e)
        {
            BatchUpdating.frmBatchUpdateInventory frmBatchUpInv = new BatchUpdating.frmBatchUpdateInventory();
            frmBatchUpInv.ShowDialog();
        }
    }
}
