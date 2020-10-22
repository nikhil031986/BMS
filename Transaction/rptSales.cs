using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transaction
{
    public partial class rptSales : Form
    {
        ReportDocument rpt = new ReportDocument();
        private int salesMasterId = 0;
        private string reportName = string.Empty;
        public string ReportName
        {
            get { return reportName; }
            set { reportName = value; }
        }
        public rptSales()
        {
            InitializeComponent();
            crviewInvoice.ReportSource = null;
            this.WindowState = FormWindowState.Maximized;
        }
        public rptSales(int _salesMasterId)
        {
            this.SalesMasterId = _salesMasterId;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            DataTable dtItemMaster = BAccess.BaItemMaster.getRecordTable("Select * from ItemMst");
            dtItemMaster.TableName = "ItemMst";
            DataTable dtItemType = BAccess.BaItemMaster.getRecordTable("Select * from ItemTypeMst");
            dtItemType.TableName = "ItemTypeMst";
            DataTable dtSalesMaster = BAccess.BaItemMaster.getRecordTable("Select * from SalesMst WHERE SalesMst.SalesMstId=" + salesMasterId.ToString());
            dtSalesMaster.TableName = "SalesMst";
            DataTable dtSalesDetails = BAccess.BaItemMaster.getRecordTable("Select * from SalesDetail WHERE SalesDetail.SalesMstId=" + salesMasterId.ToString());
            dtSalesDetails.TableName = "SalesDetail";
            DataSet dsForReport = new DataSet();
            dsForReport.Tables.Add(dtItemMaster);
            dsForReport.Tables.Add(dtItemType);
            dsForReport.Tables.Add(dtSalesMaster);
            dsForReport.Tables.Add(dtSalesDetails);
            rpt.Load(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("BMS.exe", "") + "rptInvoice.rpt");
            rpt.SetDataSource(dsForReport);
            crviewInvoice.ReportSource = rpt;
        }

        public int SalesMasterId
        {
            get { return salesMasterId; }
            set { salesMasterId = value; }
        }

        private void getFromDateToDate(bool visibale = false)
        {
            tblFromDateToDate.Visible = visibale;
        }

        private void rptSales_Load(object sender, EventArgs e)
        {
            if (SalesMasterId == 0)
            {
                if (reportName.ToUpper() == "RPTSALESREPORT" || reportName.ToUpper() == "RPTSTOCKVALUATION" || reportName.ToUpper() == "RPTPURCHASE")
                {
                    getFromDateToDate(true);
                }
                if (reportName.ToUpper() == "RPTCLOSINGSTOCK" || reportName.ToUpper() == "RPTBOOKISSUE" || reportName.ToUpper() == "STOCKVALUATION")
                {
                    getFromDateToDate(false);
                    DataSet dsForReport = new DataSet();
                    if (reportName.ToUpper() == "RPTCLOSINGSTOCK" || reportName.ToUpper() == "STOCKVALUATION")
                    {
                        DataTable dtItemMaster = BAccess.BaItemMaster.getRecordTable("Select * from ItemMst");
                        dtItemMaster.TableName = "ItemMst";
                        DataTable dtItemType = BAccess.BaItemMaster.getRecordTable("Select * from ItemTypeMst");
                        dtItemType.TableName = "ItemTypeMst";
                        dsForReport.Tables.Add(dtItemMaster);
                        dsForReport.Tables.Add(dtItemType);
                    }
                    if (reportName.ToUpper() == "RPTBOOKISSUE")
                    {
                        DataTable dtBookIssue = BAccess.BaItemMaster.getRecordTable("SELECT BookIssue.*, BookIssue.IsReturn FROM BookIssue WHERE (((BookIssue.IsReturn)=False))");
                        dtBookIssue.TableName = "BookIssue";
                        DataTable dtBookIssueDetails = BAccess.BaItemMaster.getRecordTable("SELECT BookIssueDetail.*, BookIssue.IsReturn FROM BookIssue INNER JOIN BookIssueDetail ON BookIssue.BookIssueId = BookIssueDetail.BookId WHERE (((BookIssue.IsReturn)=False))");
                        dtBookIssue.TableName = "BookIssueDetail";
                        DataTable dtItemMaster = BAccess.BaItemMaster.getRecordTable("SELECT ItemMst.*, BookIssue.IsReturn FROM BookIssue INNER JOIN (BookIssueDetail INNER JOIN ItemMst ON BookIssueDetail.ItemId = ItemMst.ItemId) ON BookIssue.BookIssueId = BookIssueDetail.BookId WHERE (((BookIssue.IsReturn)=False))");
                        dtItemMaster.TableName = "ItemMst";
                        DataTable dtItemType = BAccess.BaItemMaster.getRecordTable("SELECT ItemTypeMst.*, BookIssue.IsReturn FROM (BookIssue INNER JOIN (BookIssueDetail INNER JOIN ItemMst ON BookIssueDetail.ItemId = ItemMst.ItemId) ON BookIssue.BookIssueId = BookIssueDetail.BookId) INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId WHERE (((BookIssue.IsReturn)=False))");
                        dtItemType.TableName = "ItemTypeMst";
                        dsForReport.Tables.Add(dtItemMaster);
                        dsForReport.Tables.Add(dtItemType);
                        dsForReport.Tables.Add(dtBookIssue);
                        dsForReport.Tables.Add(dtBookIssueDetails);
                    }
                    rpt.Load(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("BMS.exe", "") + reportName + ".rpt");
                    rpt.SetDataSource(dsForReport);
                    crviewInvoice.ReportSource = rpt;
                }
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {

            DataTable dtItemMaster = BAccess.BaItemMaster.getRecordTable("Select * from ItemMst");
            dtItemMaster.TableName = "ItemMst";
            DataTable dtItemType = BAccess.BaItemMaster.getRecordTable("Select * from ItemTypeMst");
            dtItemType.TableName = "ItemTypeMst";
            DataTable dtSalesDetails = new DataTable();
            DataTable dtSalesMaster = new DataTable();
            if (reportName.ToUpper() == "RPTSALESREPORT")
            {
                dtSalesMaster = BAccess.BaItemMaster.getRecordTable("Select * from SalesMst");
                dtSalesMaster.TableName = "SalesMst";
                dtSalesDetails = BAccess.BaItemMaster.getRecordTable("Select * from SalesDetail");
                dtSalesDetails.TableName = "SalesDetail";
            }
            else
            {
                dtSalesMaster = BAccess.BaItemMaster.getRecordTable("Select * from PurMst");
                dtSalesMaster.TableName = "PurMst";
                dtSalesDetails = BAccess.BaItemMaster.getRecordTable("Select * from PurDetail");
                dtSalesDetails.TableName = "PurDetail";
            }
            DataSet dsForReport = new DataSet();
            dsForReport.Tables.Add(dtItemMaster);
            dsForReport.Tables.Add(dtItemType);
            dsForReport.Tables.Add(dtSalesMaster);
            dsForReport.Tables.Add(dtSalesDetails);
            rpt.Load(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("BMS.exe", "") + ReportName + ".rpt");
            rpt.SetDataSource(dsForReport);
            rpt.SetParameterValue("@FromDate", dtpFromDate.Value.ToString("yyyy/MM/dd"));
            rpt.SetParameterValue("@ToDate", dtpToDate.Value.ToString("yyyy/MM/dd"));
            crviewInvoice.ReportSource = rpt;
        }
    }
}
