namespace Transaction
{
    partial class StockUpdate
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
            this.components = new System.ComponentModel.Container();
            this.txtSalesStock = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProductType = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblPurchaseStock = new System.Windows.Forms.Label();
            this.lblSalesStock = new System.Windows.Forms.Label();
            this.lblTotalStock = new System.Windows.Forms.Label();
            this.lblSerch = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtPurchaseStock = new System.Windows.Forms.TextBox();
            this.sendToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTotalStock = new System.Windows.Forms.TextBox();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.cboSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvStockMasterDetails = new System.Windows.Forms.DataGridView();
            this.ctmdgvStockMaster = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMasterDetails)).BeginInit();
            this.ctmdgvStockMaster.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSalesStock
            // 
            this.txtSalesStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtSalesStock, 2);
            this.txtSalesStock.Location = new System.Drawing.Point(92, 82);
            this.txtSalesStock.Name = "txtSalesStock";
            this.txtSalesStock.Size = new System.Drawing.Size(692, 20);
            this.txtSalesStock.TabIndex = 8;
            this.txtSalesStock.Text = "0";
            this.txtSalesStock.TextChanged += new System.EventHandler(this.txtPurchaseStock_TextChanged);
            this.txtSalesStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseStock_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblProductType
            // 
            this.lblProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(3, 7);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(83, 13);
            this.lblProductType.TabIndex = 0;
            this.lblProductType.Text = "Product Type";
            // 
            // lblProductName
            // 
            this.lblProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(3, 33);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(83, 13);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Product Name";
            // 
            // lblPurchaseStock
            // 
            this.lblPurchaseStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPurchaseStock.AutoSize = true;
            this.lblPurchaseStock.Location = new System.Drawing.Point(3, 59);
            this.lblPurchaseStock.Name = "lblPurchaseStock";
            this.lblPurchaseStock.Size = new System.Drawing.Size(83, 13);
            this.lblPurchaseStock.TabIndex = 5;
            this.lblPurchaseStock.Text = "Purchase Stock";
            // 
            // lblSalesStock
            // 
            this.lblSalesStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSalesStock.AutoSize = true;
            this.lblSalesStock.Location = new System.Drawing.Point(3, 85);
            this.lblSalesStock.Name = "lblSalesStock";
            this.lblSalesStock.Size = new System.Drawing.Size(83, 13);
            this.lblSalesStock.TabIndex = 7;
            this.lblSalesStock.Text = "Sales Stock";
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalStock.AutoSize = true;
            this.lblTotalStock.Location = new System.Drawing.Point(3, 111);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(83, 13);
            this.lblTotalStock.TabIndex = 9;
            this.lblTotalStock.Text = "TotalStock";
            // 
            // lblSerch
            // 
            this.lblSerch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSerch.AutoSize = true;
            this.lblSerch.Location = new System.Drawing.Point(3, 167);
            this.lblSerch.Name = "lblSerch";
            this.lblSerch.Size = new System.Drawing.Size(83, 13);
            this.lblSerch.TabIndex = 12;
            this.lblSerch.Text = "Search From";
            // 
            // txtProductName
            // 
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tableLayoutPanel1.SetColumnSpan(this.txtProductName, 2);
            this.txtProductName.Location = new System.Drawing.Point(92, 30);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(692, 20);
            this.txtProductName.TabIndex = 3;
            // 
            // txtPurchaseStock
            // 
            this.txtPurchaseStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtPurchaseStock, 2);
            this.txtPurchaseStock.Location = new System.Drawing.Point(92, 56);
            this.txtPurchaseStock.Name = "txtPurchaseStock";
            this.txtPurchaseStock.Size = new System.Drawing.Size(692, 20);
            this.txtPurchaseStock.TabIndex = 6;
            this.txtPurchaseStock.Text = "0";
            this.txtPurchaseStock.TextChanged += new System.EventHandler(this.txtPurchaseStock_TextChanged);
            this.txtPurchaseStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseStock_KeyPress);
            // 
            // sendToExcelToolStripMenuItem
            // 
            this.sendToExcelToolStripMenuItem.Name = "sendToExcelToolStripMenuItem";
            this.sendToExcelToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sendToExcelToolStripMenuItem.Text = "SendToExcel";
            // 
            // txtTotalStock
            // 
            this.txtTotalStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtTotalStock, 2);
            this.txtTotalStock.Location = new System.Drawing.Point(92, 108);
            this.txtTotalStock.Name = "txtTotalStock";
            this.txtTotalStock.Size = new System.Drawing.Size(692, 20);
            this.txtTotalStock.TabIndex = 10;
            this.txtTotalStock.Text = "0";
            this.txtTotalStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseStock_KeyPress);
            // 
            // cboProductType
            // 
            this.cboProductType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.cboProductType, 2);
            this.cboProductType.Enabled = false;
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Location = new System.Drawing.Point(92, 3);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(692, 21);
            this.cboProductType.TabIndex = 1;
            // 
            // cboSearch
            // 
            this.cboSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearch.FormattingEnabled = true;
            this.cboSearch.Items.AddRange(new object[] {
            "Product_Name",
            "ItemType"});
            this.cboSearch.Location = new System.Drawing.Point(92, 163);
            this.cboSearch.Name = "cboSearch";
            this.cboSearch.Size = new System.Drawing.Size(121, 21);
            this.cboSearch.TabIndex = 13;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtSearch, 2);
            this.txtSearch.Location = new System.Drawing.Point(219, 163);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(668, 20);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvStockMasterDetails
            // 
            this.dgvStockMasterDetails.AllowUserToAddRows = false;
            this.dgvStockMasterDetails.AllowUserToDeleteRows = false;
            this.dgvStockMasterDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dgvStockMasterDetails, 4);
            this.dgvStockMasterDetails.ContextMenuStrip = this.ctmdgvStockMaster;
            this.dgvStockMasterDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStockMasterDetails.Location = new System.Drawing.Point(3, 190);
            this.dgvStockMasterDetails.Name = "dgvStockMasterDetails";
            this.dgvStockMasterDetails.ReadOnly = true;
            this.dgvStockMasterDetails.Size = new System.Drawing.Size(884, 416);
            this.dgvStockMasterDetails.TabIndex = 15;
            this.dgvStockMasterDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStockMasterDetails_CellFormatting);
            this.dgvStockMasterDetails.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStockMasterDetails_RowEnter);
            // 
            // ctmdgvStockMaster
            // 
            this.ctmdgvStockMaster.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctmdgvStockMaster.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToExcelToolStripMenuItem});
            this.ctmdgvStockMaster.Name = "ctmdgvStockMaster";
            this.ctmdgvStockMaster.Size = new System.Drawing.Size(140, 26);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(728, 131);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 29);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblProductType, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblProductName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPurchaseStock, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSalesStock, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalStock, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblSerch, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtProductName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPurchaseStock, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSalesStock, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTotalStock, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cboProductType, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboSearch, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtSearch, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.dgvStockMasterDetails, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(890, 609);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // StockUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 609);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StockUpdate";
            this.Text = "StockUpdate";
            this.Load += new System.EventHandler(this.StockUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStockMasterDetails)).EndInit();
            this.ctmdgvStockMaster.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalesStock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblProductType;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblPurchaseStock;
        private System.Windows.Forms.Label lblSalesStock;
        private System.Windows.Forms.Label lblTotalStock;
        private System.Windows.Forms.Label lblSerch;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtPurchaseStock;
        private System.Windows.Forms.TextBox txtTotalStock;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.ComboBox cboSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStockMasterDetails;
        private System.Windows.Forms.ContextMenuStrip ctmdgvStockMaster;
        private System.Windows.Forms.ToolStripMenuItem sendToExcelToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}