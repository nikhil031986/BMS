namespace Transaction
{
    partial class frmpurchase
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtpInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.lblinvoiceNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboPartyName = new System.Windows.Forms.ComboBox();
            this.gpPaymentDetails = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtPendingAmount = new System.Windows.Forms.TextBox();
            this.txtPayAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.chkFullPayment = new System.Windows.Forms.CheckBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.dgvProductDetails = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.txtdisAmount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.lblnetAmount = new System.Windows.Forms.Label();
            this.lbldisAmount = new System.Windows.Forms.Label();
            this.lbltotalAmount = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gpPaymentDetails.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvProductDetails, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 600);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dtpInvoiceDate, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblinvoiceNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtInvoiceNo, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboPartyName, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.gpPaymentDetails, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDetails, 2, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(826, 111);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dtpInvoiceDate
            // 
            this.dtpInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceDate.Location = new System.Drawing.Point(95, 56);
            this.dtpInvoiceDate.Name = "dtpInvoiceDate";
            this.dtpInvoiceDate.Size = new System.Drawing.Size(140, 22);
            this.dtpInvoiceDate.TabIndex = 3;
            // 
            // lblinvoiceNo
            // 
            this.lblinvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblinvoiceNo.AutoSize = true;
            this.lblinvoiceNo.Location = new System.Drawing.Point(3, 30);
            this.lblinvoiceNo.Name = "lblinvoiceNo";
            this.lblinvoiceNo.Size = new System.Drawing.Size(86, 17);
            this.lblinvoiceNo.TabIndex = 0;
            this.lblinvoiceNo.Text = "Invoice No";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Invoice Date";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(95, 28);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(140, 22);
            this.txtInvoiceNo.TabIndex = 1;
            this.txtInvoiceNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtInvoiceNo_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Party Name";
            // 
            // cboPartyName
            // 
            this.cboPartyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPartyName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPartyName.FormattingEnabled = true;
            this.cboPartyName.Location = new System.Drawing.Point(95, 84);
            this.cboPartyName.Name = "cboPartyName";
            this.cboPartyName.Size = new System.Drawing.Size(140, 24);
            this.cboPartyName.TabIndex = 5;
            // 
            // gpPaymentDetails
            // 
            this.gpPaymentDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.gpPaymentDetails, 2);
            this.gpPaymentDetails.Controls.Add(this.tableLayoutPanel3);
            this.gpPaymentDetails.Location = new System.Drawing.Point(531, 0);
            this.gpPaymentDetails.Margin = new System.Windows.Forms.Padding(0);
            this.gpPaymentDetails.Name = "gpPaymentDetails";
            this.gpPaymentDetails.Padding = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.tableLayoutPanel2.SetRowSpan(this.gpPaymentDetails, 4);
            this.gpPaymentDetails.Size = new System.Drawing.Size(295, 111);
            this.gpPaymentDetails.TabIndex = 7;
            this.gpPaymentDetails.TabStop = false;
            this.gpPaymentDetails.Text = "Payment Details";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.txtPendingAmount, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtPayAmount, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblPaymentAmount, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkFullPayment, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(282, 90);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // txtPendingAmount
            // 
            this.txtPendingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPendingAmount.Enabled = false;
            this.txtPendingAmount.Location = new System.Drawing.Point(121, 61);
            this.txtPendingAmount.Name = "txtPendingAmount";
            this.txtPendingAmount.Size = new System.Drawing.Size(158, 22);
            this.txtPendingAmount.TabIndex = 4;
            this.txtPendingAmount.Text = "0";
            // 
            // txtPayAmount
            // 
            this.txtPayAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayAmount.Location = new System.Drawing.Point(121, 30);
            this.txtPayAmount.Name = "txtPayAmount";
            this.txtPayAmount.Size = new System.Drawing.Size(158, 22);
            this.txtPayAmount.TabIndex = 2;
            this.txtPayAmount.Text = "0";
            this.txtPayAmount.TextChanged += new System.EventHandler(this.txtPayAmount_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Pending Amount";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Location = new System.Drawing.Point(3, 32);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(112, 17);
            this.lblPaymentAmount.TabIndex = 1;
            this.lblPaymentAmount.Text = "Amount";
            // 
            // chkFullPayment
            // 
            this.chkFullPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFullPayment.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.chkFullPayment, 2);
            this.chkFullPayment.Location = new System.Drawing.Point(3, 3);
            this.chkFullPayment.Name = "chkFullPayment";
            this.chkFullPayment.Size = new System.Drawing.Size(276, 21);
            this.chkFullPayment.TabIndex = 0;
            this.chkFullPayment.Text = "Full Payment";
            this.chkFullPayment.UseVisualStyleBackColor = true;
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(241, 84);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(44, 23);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "---";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // dgvProductDetails
            // 
            this.dgvProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductDetails.Location = new System.Drawing.Point(3, 120);
            this.dgvProductDetails.Name = "dgvProductDetails";
            this.dgvProductDetails.RowTemplate.Height = 24;
            this.dgvProductDetails.Size = new System.Drawing.Size(826, 339);
            this.dgvProductDetails.TabIndex = 1;
            this.dgvProductDetails.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvProductDetails_CellBeginEdit);
            this.dgvProductDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_CellEndEdit);
            this.dgvProductDetails.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_CellLeave);
            this.dgvProductDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductDetails_CellValidating);
            this.dgvProductDetails.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductDetails_RowEnter);
            this.dgvProductDetails.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvProductDetails_UserDeletedRow);
            this.dgvProductDetails.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProductDetails_UserDeletingRow);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.flowLayoutPanel1, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtNetAmount, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtdisAmount, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtTotalAmount, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblnetAmount, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbldisAmount, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbltotalAmount, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(539, 465);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(290, 132);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(37, 87);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 42);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(165, 7);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNetAmount.Enabled = false;
            this.txtNetAmount.Location = new System.Drawing.Point(124, 59);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(163, 22);
            this.txtNetAmount.TabIndex = 5;
            this.txtNetAmount.Text = "0";
            // 
            // txtdisAmount
            // 
            this.txtdisAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdisAmount.Location = new System.Drawing.Point(124, 31);
            this.txtdisAmount.Name = "txtdisAmount";
            this.txtdisAmount.Size = new System.Drawing.Size(163, 22);
            this.txtdisAmount.TabIndex = 3;
            this.txtdisAmount.Text = "0";
            this.txtdisAmount.TextChanged += new System.EventHandler(this.txtdisAmount_TextChanged);
            this.txtdisAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdisAmount_KeyPress);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(124, 3);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(163, 22);
            this.txtTotalAmount.TabIndex = 1;
            this.txtTotalAmount.Text = "0";
            // 
            // lblnetAmount
            // 
            this.lblnetAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnetAmount.AutoSize = true;
            this.lblnetAmount.Location = new System.Drawing.Point(3, 61);
            this.lblnetAmount.Name = "lblnetAmount";
            this.lblnetAmount.Size = new System.Drawing.Size(115, 17);
            this.lblnetAmount.TabIndex = 4;
            this.lblnetAmount.Text = "Net Amount";
            // 
            // lbldisAmount
            // 
            this.lbldisAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbldisAmount.AutoSize = true;
            this.lbldisAmount.Location = new System.Drawing.Point(3, 33);
            this.lbldisAmount.Name = "lbldisAmount";
            this.lbldisAmount.Size = new System.Drawing.Size(115, 17);
            this.lbldisAmount.TabIndex = 2;
            this.lbldisAmount.Text = "Discount Amount";
            // 
            // lbltotalAmount
            // 
            this.lbltotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbltotalAmount.AutoSize = true;
            this.lbltotalAmount.Location = new System.Drawing.Point(3, 5);
            this.lbltotalAmount.Name = "lbltotalAmount";
            this.lbltotalAmount.Size = new System.Drawing.Size(115, 17);
            this.lbltotalAmount.TabIndex = 0;
            this.lbltotalAmount.Text = "Total Amount";
            // 
            // frmpurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 600);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmpurchase";
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.frmpurchase_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.gpPaymentDetails.ResumeLayout(false);
            this.gpPaymentDetails.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductDetails)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtpInvoiceDate;
        private System.Windows.Forms.Label lblinvoiceNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboPartyName;
        private System.Windows.Forms.GroupBox gpPaymentDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtPendingAmount;
        private System.Windows.Forms.TextBox txtPayAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.CheckBox chkFullPayment;
        private System.Windows.Forms.DataGridView dgvProductDetails;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.TextBox txtdisAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label lblnetAmount;
        private System.Windows.Forms.Label lbldisAmount;
        private System.Windows.Forms.Label lbltotalAmount;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDetails;
    }
}