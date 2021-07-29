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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BOI_Inventory_System
{
    public partial class frmReportViewer : Form
    {

        SqlDataAdapter ReportAdapter ;
        DataSet ReportDataset = new DataSet();

        public frmReportViewer()
        {
            InitializeComponent();
        }

        public frmReportViewer(String ReportName, String Query)
        {
            InitializeComponent();

            switch (ReportName)
            {
                case "Receiving_Report":
                    {
                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset,"view_Receiving_Report");

                        //Create Instance
                        Reports.rpt_Receiving_Report ReceivingReport = new Reports.rpt_Receiving_Report();

                        //Configure Crystal Report Settings
                        ReceivingReport.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        ReceivingReport.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = ReceivingReport;
                        crystalReportViewer1.Refresh();
                       
                        break;

                    }

                case "PAR_Report":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_PAR_Report PARReport = new Reports.rpt_PAR_Report();

                        //Configure Crystal Report Settings
                        PARReport.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        PARReport.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = PARReport;
                        crystalReportViewer1.Refresh();

                        break;

                    }


                case "ICS_Report":
                    {
                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_ICS ICSReport = new Reports.rpt_ICS();

                        //Configure Crystal Report Settings
                        ICSReport.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        ICSReport.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = ICSReport;
                        crystalReportViewer1.Refresh();

                        break;
                    }
                case "Property_Tag":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_Property_Tag Property_Tag= new Reports.rpt_Property_Tag();

                        //Configure Crystal Report Settings
                        Property_Tag.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Property_Tag.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Property_Tag;
                        crystalReportViewer1.Refresh();


                        break;
                    }

                case "Property_Tag_Small":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_Small_Tag Property_Tag_Small = new Reports.rpt_Small_Tag();

                        //Configure Crystal Report Settings
                        Property_Tag_Small.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Property_Tag_Small.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Property_Tag_Small;
                        crystalReportViewer1.Refresh();


                        break;
                    }

                case "Return_Slip":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_PullOutRecords");

                        //Create Instance
                        Reports.rpt_RS_Rep Return_Slip = new Reports.rpt_RS_Rep();

                        //Configure Crystal Report Settings
                        Return_Slip.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Return_Slip.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Return_Slip;
                        crystalReportViewer1.Refresh();
                        break;
                    }

                case "Account_Report":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_SummaryPerEmployee Account_Summary = new Reports.rpt_SummaryPerEmployee();

                        //Configure Crystal Report Settings
                        Account_Summary.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Account_Summary.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Account_Summary;
                        crystalReportViewer1.Refresh();
                        break;
                    }

                case "Inventory_Report":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rptInventoryReport Inventory_Summary = new Reports.rptInventoryReport();

                        //Configure Crystal Report Settings
                        Inventory_Summary.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Inventory_Summary.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Inventory_Summary;
                        crystalReportViewer1.Refresh();
                        break;
                    }

                case "Inventory_Details":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.rpt_InventoryList Inventory_Details = new Reports.rpt_InventoryList();

                        //Configure Crystal Report Settings
                        Inventory_Details.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Inventory_Details.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Inventory_Details;
                        crystalReportViewer1.Refresh();
                        break;
                    }


                case "Property_Card":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_ItemHistory");

                        //Create Instance
                        Reports.rpt_PropertyCard Property_Card = new Reports.rpt_PropertyCard();

                        //Configure Crystal Report Settings
                        Property_Card.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Property_Card.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Property_Card;
                        crystalReportViewer1.Refresh();
                        break;
                    }


                case "Transfer_Report":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Disposal_Record");

                        //Create Instance
                        Reports.rpt_Property_Transfer_Report Disposal_Report_Donation = new Reports.rpt_Property_Transfer_Report();

                        //Configure Crystal Report Settings
                        Disposal_Report_Donation.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Disposal_Report_Donation.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Disposal_Report_Donation;
                        crystalReportViewer1.Refresh();
                        break;
                    }


                case "IRP_Report":
                    {
                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Disposal_Record");

                        //Create Instance
                        Reports.rpt_IRP IRP = new Reports.rpt_IRP();

                        //Configure Crystal Report Settings
                        IRP.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        IRP.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = IRP;
                        crystalReportViewer1.Refresh();
                        break;
                    }

                case "IRRUP":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Disposal_Record");

                        //Create Instance
                        Reports.rpt_DisposalReport_Unserviceable IRRUP = new Reports.rpt_DisposalReport_Unserviceable();

                        //Configure Crystal Report Settings
                        IRRUP.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        IRRUP.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = IRRUP;
                        crystalReportViewer1.Refresh();
                        break;
                    }
                case "Inventory_Summary":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Summary");

                        //Create Instance
                        Reports.rptInventorySummary Inv_Summary = new Reports.rptInventorySummary();

                        //Configure Crystal Report Settings
                        Inv_Summary.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Inv_Summary.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Inv_Summary;
                        crystalReportViewer1.Refresh();
                        break;
                    }
                case "Inventory_PIF":
                    {

                        ReportAdapter = new SqlDataAdapter(Query, SysCon.SystemConnect);
                        ReportAdapter.Fill(ReportDataset, "view_Inventory_Details");

                        //Create Instance
                        Reports.RPT_PIF Inv_PIF = new Reports.RPT_PIF();

                        //Configure Crystal Report Settings
                        Inv_PIF.SetDatabaseLogon(SysCon.uid, SysCon.pwd);
                        Inv_PIF.SetDataSource(ReportDataset);

                        //Bind to crystalreportviewer
                        //CrystalReport

                        crystalReportViewer1.ReportSource = Inv_PIF;
                        crystalReportViewer1.Refresh();
                        break;
                    }

            }
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
    }
