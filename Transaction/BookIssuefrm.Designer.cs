namespace Transaction
{
    partial class BookIssuefrm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvProductDetails = new System.Windows.Forms.DataGridView();
            this.chkReturnBook = new System.Windows.Forms.CheckBox();
            this.dtpIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblissueNo = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBookIssue = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lblMobileNo = new System.Windows.Forms.Label();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.txtEmailId = new System.Windows.Forms.TextBox();
            this.lblEmailId = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.dtpReturnDate = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(708, 541);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(163, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dgvProductDetails
            // 
            this.dgvProductDetails.AllowUserToDeleteRows = false;
            this.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductDetails.Location = new System.Drawing.Point(3, 175);
            this.dgvProductDetails.Name = "dgvProductDetails";
            this.dgvProductDetails.RowTemplate.Height = 24;
            this.dgvProductDetails.Size = new System.Drawing.Size(868, 360);
            this.dgvProductDetails.TabIndex = 1;
            this.dgvProductDetails.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductDetails_CellBeginEdit);
            this.dgvProductDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_CellEndEdit);
            this.dgvProductDetails.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_RowEnter);
            // 
            // chkReturnBook
            // 
            this.chkReturnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkReturnBook.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.chkReturnBook, 2);
            this.chkReturnBook.Location = new System.Drawing.Point(559, 29);
            this.chkReturnBook.Name = "chkReturnBook";
            this.chkReturnBook.Size = new System.Drawing.Size(306, 21);
            this.chkReturnBook.TabIndex = 10;
            this.chkReturnBook.Text = "Return Book";
            this.chkReturnBook.UseVisualStyleBackColor = true;
            // 
            // dtpIssueDate
            // 
            this.dtpIssueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpIssueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpIssueDate.Location = new System.Drawing.Point(91, 57);
            this.dtpIssueDate.Name = "dtpIssueDate";
            this.dtpIssueDate.Size = new System.Drawing.Size(228, 22);
            this.dtpIssueDate.TabIndex = 3;
            // 
            // lblissueNo
            // 
            this.lblissueNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblissueNo.AutoSize = true;
            this.lblissueNo.Location = new System.Drawing.Point(3, 31);
            this.lblissueNo.Name = "lblissueNo";
            this.lblissueNo.Size = new System.Drawing.Size(82, 17);
            this.lblissueNo.TabIndex = 0;
            this.lblissueNo.Text = "Issue No";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Location = new System.Drawing.Point(3, 59);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(82, 17);
            this.lblIssueDate.TabIndex = 2;
            this.lblIssueDate.Text = "IssueDate";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(91, 29);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(228, 22);
            this.txtInvoiceNo.TabIndex = 0;
            this.txtInvoiceNo.Text = "0";
            this.txtInvoiceNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceNo_KeyPress);
            this.txtInvoiceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtInvoiceNo_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Party Name";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblBookIssue, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtMobileNo, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblMobileNo, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.dtpIssueDate, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblissueNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIssueDate, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtInvoiceNo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtPartyName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtEmailId, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblEmailId, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.chkReturnBook, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblReturnDate, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpReturnDate, 4, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(868, 166);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblBookIssue
            // 
            this.lblBookIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBookIssue.AutoSize = true;
            this.lblBookIssue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.lblBookIssue, 5);
            this.lblBookIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookIssue.Location = new System.Drawing.Point(3, 0);
            this.lblBookIssue.Name = "lblBookIssue";
            this.lblBookIssue.Size = new System.Drawing.Size(862, 26);
            this.lblBookIssue.TabIndex = 0;
            this.lblBookIssue.Text = "Book Issue";
            this.lblBookIssue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobileNo.Location = new System.Drawing.Point(91, 113);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(228, 22);
            this.txtMobileNo.TabIndex = 7;
            // 
            // lblMobileNo
            // 
            this.lblMobileNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMobileNo.AutoSize = true;
            this.lblMobileNo.Location = new System.Drawing.Point(3, 115);
            this.lblMobileNo.Name = "lblMobileNo";
            this.lblMobileNo.Size = new System.Drawing.Size(82, 17);
            this.lblMobileNo.TabIndex = 6;
            this.lblMobileNo.Text = "Mobile No";
            // 
            // txtPartyName
            // 
            this.txtPartyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyName.Location = new System.Drawing.Point(91, 85);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(228, 22);
            this.txtPartyName.TabIndex = 5;
            // 
            // txtEmailId
            // 
            this.txtEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailId.Location = new System.Drawing.Point(91, 141);
            this.txtEmailId.Name = "txtEmailId";
            this.txtEmailId.Size = new System.Drawing.Size(228, 22);
            this.txtEmailId.TabIndex = 9;
            // 
            // lblEmailId
            // 
            this.lblEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmailId.AutoSize = true;
            this.lblEmailId.Location = new System.Drawing.Point(3, 143);
            this.lblEmailId.Name = "lblEmailId";
            this.lblEmailId.Size = new System.Drawing.Size(82, 17);
            this.lblEmailId.TabIndex = 8;
            this.lblEmailId.Text = "EmailId";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(559, 59);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(150, 17);
            this.lblReturnDate.TabIndex = 11;
            this.lblReturnDate.Text = "Return Date";
            this.lblReturnDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpReturnDate
            // 
            this.dtpReturnDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReturnDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturnDate.Location = new System.Drawing.Point(715, 57);
            this.dtpReturnDate.Name = "dtpReturnDate";
            this.dtpReturnDate.Size = new System.Drawing.Size(150, 22);
            this.dtpReturnDate.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvProductDetails, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(874, 586);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // BookIssuefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 586);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(892, 633);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(892, 633);
            this.Name = "BookIssuefrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Book Issue";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvProductDetails;
        private System.Windows.Forms.CheckBox chkReturnBook;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblBookIssue;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label lblMobileNo;
        private System.Windows.Forms.DateTimePicker dtpIssueDate;
        private System.Windows.Forms.Label lblissueNo;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.TextBox txtEmailId;
        private System.Windows.Forms.Label lblEmailId;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.DateTimePicker dtpReturnDate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}