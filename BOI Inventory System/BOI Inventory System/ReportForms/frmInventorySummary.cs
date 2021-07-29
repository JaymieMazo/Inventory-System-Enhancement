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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BOI_Inventory_System
{
    public partial class frmInventorySummary : Form
    {
        public frmInventorySummary()
        {
            InitializeComponent();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            GlobalClass.GlobalArticleId = "";
            txtArticle.Text = "";
            txtCategory.Text = "";
            txtSubcategory.Text = "";

           frmArticleList frm_ArticleList = new frmArticleList();
           frm_ArticleList.ShowDialog();

            if (!String.IsNullOrEmpty(GlobalClass.GlobalArticleId))
            {
                func_Retrieve_Article_Details();
            }
        }

        private void func_Retrieve_Article_Details()
        {
            string RetrieveArticle = "Select * from view_ArticleSubcat where pk_Article_Id = ' " + GlobalClass.GlobalArticleId + "'";
            //close current connection
            SysCon.CloseConnection();
            //Open connection
            SysCon.SystemConnect.Open();

            SqlCommand ArticleFinder = new SqlCommand(RetrieveArticle, SysCon.SystemConnect);
            SqlDataReader ArticleReader = ArticleFinder.ExecuteReader();

            if (ArticleReader.Read())
            {

                txtCategory.Text = ArticleReader[2].ToString();
                txtSubcategory.Text = ArticleReader[3].ToString();
                txtArticle.Text = ArticleReader[5].ToString();
            }

            ArticleReader.Close();
            ArticleReader.Dispose();
            btnGenerate.Focus();
            btnGenerate.Enabled = true;

            groupBox1.Enabled = true;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == "")
            {
                MessageBox.Show("Please select criteria for the report generation");
                btnFind.Focus();
            }
            else if (GlobalClass.GlobalArticleId == "")
            {
                MessageBox.Show("Please select criteria for the report generation");
                btnFind.Focus();
            }
            else
            {

                frmReportViewer PreviewDialog = new frmReportViewer("Inventory_Report", "SELECT * FROM view_Inventory_Details where fk_Article_Id = '" + GlobalClass.GlobalArticleId + "' AND (Status != 'FOR DISPOSAL' and Status != 'CANCELLED PROPERTY NO.' and Status != 'RETURN TO SUPPLIER' and Status  != 'REPLACED BY SUPPLIER' and Status  != 'UNSERVICEABLE' and Status  != 'EXPIRED')");
                PreviewDialog.ShowDialog();
                func_Reset();
            }
        }

        private void frmInventorySummary_Load(object sender, EventArgs e)
        {
            btnFind.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult mes = MessageBox.Show("Do you really want to clear the text fields?", "Inventory Summary Report", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (mes)
            {
                case DialogResult.Yes:
                    {
                        func_Reset();
                        break;
                    }

                case DialogResult.No:
                    {
                        btnFind.Focus();
                        break;
                    }
            }
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
        }
        private void func_Reset()
        {
            btnGenerate.Enabled = false;

            txtCategory.Text = "";
            txtSubcategory.Text = "";
            txtArticle.Text = "";

        }
     
        private void summaryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Inventory_Summary", "SELECT * FROM view_Inventory_Summary where Category_Name != 'EXPENSE'AND (Status != 'FOR DISPOSAL' and Status != 'CANCELLED PROPERTY NO.' and Status != 'RETURN TO SUPPLIER' and Status  != 'REPLACED BY SUPPLIER' and Status  != 'UNSERVICEABLE' and Status  != 'EXPIRED')");
            PreviewDialog.ShowDialog();
        }

        private void pIFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReportViewer PreviewDialog = new frmReportViewer("Inventory_PIF", "SELECT * FROM view_Inventory_Details where Category_Name != 'EXPENSE'AND (Status != 'FOR DISPOSAL' and Status != 'CANCELLED PROPERTY NO.' and Status != 'RETURN TO SUPPLIER' and Status  != 'REPLACED BY SUPPLIER' and Status  != 'UNSERVICEABLE' and Status  != 'EXPIRED')");
            PreviewDialog.ShowDialog();
        }
    }   
 }
