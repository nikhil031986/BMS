using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmMdiBMS : Form
    {
        private System.Windows.Forms.Timer tgetDateAndTime;
        public frmMdiBMS()
        {
            InitializeComponent();
            this.Icon = BMS.Properties.Resources.library;
            tgetDateAndTime = new System.Windows.Forms.Timer();
            tgetDateAndTime.Interval = 100;
            tgetDateAndTime.Tick += new EventHandler(TimerEventProcessor);
            tgetDateAndTime.Start();
            lbltoolUserName.Text = "[User Name : " + DataUtil.currentUserInfo.User_Name.ToString() + "]";
        }
        private void GetCurrentDateTime()
        {
            this.Invoke(new MethodInvoker(() => lbltoolstripSystemDateTime.Text = "[Date :" + DateTime.Now.Date.ToString("dd/MM/yyyy") + " Time " + DateTime.Now.ToString("HH:mm:ss") + "]"));
        }
        private void TimerEventProcessor(object sender, EventArgs e)
        {
            GetCurrentDateTime();
        }

        private void openForm(string objectForm)
        {
            Form form = Application.OpenForms[objectForm];
            Assembly assembly = Assembly.GetExecutingAssembly();
            object createobject = assembly.CreateInstance("BMS." + objectForm) as object;
            ((Form)createobject).MdiParent = this;
            if (form == null)
            {
                ((Form)createobject).Show();
            }
            else
            {
                form.Close();
                ((Form)createobject).Show();
            }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            if (DataUtil.currentUserInfo.IsAdmin)
            {
                openForm("frmUserMaster");
            }
        }

        private void OpenFile(object sender, EventArgs e)
        {
            openForm("frmItemTypeMst");
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm("frmItemMasterDetail");
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTranForm("frmSales");
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTranForm("StockUpdate");
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTranForm("frmBookissue");
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm("frmPartyMaster");
        }
        private void openReportForm(string objectForm, string reportName)
        {
            Form form = Application.OpenForms[objectForm];
            Assembly assembly = Assembly.LoadFile(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("BMS.exe", "") + "\\Transaction.dll");
            object createobject = assembly.CreateInstance("Transaction." + objectForm) as object;
            ((Form)createobject).MdiParent = this;
            var propety = createobject.GetType().GetProperty("ReportName");
            propety.SetValue(createobject, reportName);
            if (form == null)
            {
                ((Form)createobject).Show();
            }
            else
            {
                form.Close();
                ((Form)createobject).Show();
            }
        }
        private void openTranForm(string objectForm)
        {
            Form form = Application.OpenForms[objectForm];
            Assembly assembly = Assembly.LoadFile(System.Reflection.Assembly.GetEntryAssembly().Location.Replace("BMS.exe", "") + "\\Transaction.dll");
            object createobject = assembly.CreateInstance("Transaction." + objectForm) as object;
            ((Form)createobject).MdiParent = this;
            var propety = createobject.GetType().GetProperty("CurrentUser");
            propety.SetValue(createobject, DataUtil.currentUserInfo);
            if (form == null)
            {
                ((Form)createobject).Show();
            }
            else
            {
                form.Close();
                ((Form)createobject).Show();
            }
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTranForm("frmpurchase");

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process installer = new Process();
            installer.StartInfo.FileName = Application.ExecutablePath;
            installer.Start();
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataUtil.currentUserInfo.IsAdmin)
            {
                openForm("winfBackup");
            }
            else
            {
                MessageBox.Show("Please contact your administrator.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReportForm("rptSales", "rptSalesReport");
        }

        private void closingStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BAccess.BaItemMaster.updateClosingStock())
            {
                openReportForm("rptSales", "StockValuation");
            }
        }

        private void inwardReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReportForm("rptSales", "rptPurchase");
        }

        private void stockValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReportForm("rptSales", "rptStockValuation");
        }

        private void yearMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm("frYearMaster");
        }

        private void boolIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openReportForm("rptSales", "rptBookIssue");
        }

        private void closingStockUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BAccess.BaItemMaster.updateClosingStock())
            {
                MessageBox.Show("Stock updated.", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void toolstripPurchase_Click(object sender, EventArgs e)
        {
            openTranForm("frmpurchase");
        }

        private void toolStripSales_Click(object sender, EventArgs e)
        {
            openTranForm("frmSales");
        }

        private void toolstripStockValuation_Click(object sender, EventArgs e)
        {
            if (BAccess.BaItemMaster.updateClosingStock())
            {
                openReportForm("rptSales", "StockValuation");
            }
        }
    }
}
