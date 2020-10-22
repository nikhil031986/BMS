namespace Transaction
{
    partial class rptSales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crviewInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.rptInvoice1 = new Transaction.rptInvoice();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblFromDateToDate = new System.Windows.Forms.TableLayoutPanel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblFromDateToDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // crviewInvoice
            // 
            this.crviewInvoice.ActiveViewIndex = 0;
            this.crviewInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crviewInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.crviewInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crviewInvoice.Location = new System.Drawing.Point(3, 66);
            this.crviewInvoice.Name = "crviewInvoice";
            this.crviewInvoice.ReportSource = this.rptInvoice1;
            this.crviewInvoice.Size = new System.Drawing.Size(1227, 761);
            this.crviewInvoice.TabIndex = 0;
            this.crviewInvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.crviewInvoice, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tblFromDateToDate, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1233, 830);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tblFromDateToDate
            // 
            this.tblFromDateToDate.AutoSize = true;
            this.tblFromDateToDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblFromDateToDate.ColumnCount = 3;
            this.tblFromDateToDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFromDateToDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblFromDateToDate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblFromDateToDate.Controls.Add(this.btnViewReport, 2, 1);
            this.tblFromDateToDate.Controls.Add(this.dtpToDate, 1, 1);
            this.tblFromDateToDate.Controls.Add(this.dtpFromDate, 1, 0);
            this.tblFromDateToDate.Controls.Add(this.lblToDate, 0, 1);
            this.tblFromDateToDate.Controls.Add(this.lblFromDate, 0, 0);
            this.tblFromDateToDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFromDateToDate.Location = new System.Drawing.Point(3, 3);
            this.tblFromDateToDate.Name = "tblFromDateToDate";
            this.tblFromDateToDate.RowCount = 2;
            this.tblFromDateToDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFromDateToDate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblFromDateToDate.Size = new System.Drawing.Size(1227, 57);
            this.tblFromDateToDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(3, 5);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(74, 17);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(3, 34);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(74, 17);
            this.lblToDate.TabIndex = 1;
            this.lblToDate.Text = "To Date";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewReport.Location = new System.Drawing.Point(1088, 31);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(136, 23);
            this.btnViewReport.TabIndex = 2;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(83, 3);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 3;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(83, 31);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 22);
            this.dtpToDate.TabIndex = 4;
            // 
            // rptSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 830);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "rptSales";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.rptSales_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tblFromDateToDate.ResumeLayout(false);
            this.tblFromDateToDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crviewInvoice;
        private rptInvoice rptInvoice1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblFromDateToDate;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
    }
}