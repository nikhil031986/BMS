namespace BMS
{
    partial class frmPartyMaster
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMobileno = new System.Windows.Forms.TextBox();
            this.txtemailid = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtPincode = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblMobileno = new System.Windows.Forms.Label();
            this.lblEmailId = new System.Windows.Forms.Label();
            this.lblPhonNo = new System.Windows.Forms.Label();
            this.lblPincode = new System.Windows.Forms.Label();
            this.lblcity = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblItemType = new System.Windows.Forms.Label();
            this.lblPartyName = new System.Windows.Forms.Label();
            this.lblPartyMaster = new System.Windows.Forms.Label();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.cboItemType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPartyMaster = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartyMaster)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvPartyMaster, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(813, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.Controls.Add(this.txtMobileno, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtemailid, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtPhoneNo, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtPincode, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtCity, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtAddress, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMobileno, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblEmailId, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPhonNo, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPincode, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.lblcity, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.lblAddress, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblItemType, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblPartyName, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPartyMaster, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPartyName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.cboItemType, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 3, 7);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(807, 222);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // txtMobileno
            // 
            this.txtMobileno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobileno.Location = new System.Drawing.Point(489, 86);
            this.txtMobileno.Name = "txtMobileno";
            this.txtMobileno.Size = new System.Drawing.Size(305, 22);
            this.txtMobileno.TabIndex = 16;
            // 
            // txtemailid
            // 
            this.txtemailid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtemailid.Location = new System.Drawing.Point(489, 57);
            this.txtemailid.Name = "txtemailid";
            this.txtemailid.Size = new System.Drawing.Size(305, 22);
            this.txtemailid.TabIndex = 14;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNo.Location = new System.Drawing.Point(489, 28);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(305, 22);
            this.txtPhoneNo.TabIndex = 12;
            // 
            // txtPincode
            // 
            this.txtPincode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPincode.Location = new System.Drawing.Point(91, 162);
            this.txtPincode.Name = "txtPincode";
            this.txtPincode.Size = new System.Drawing.Size(305, 22);
            this.txtPincode.TabIndex = 10;
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Location = new System.Drawing.Point(91, 134);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(305, 22);
            this.txtCity.TabIndex = 8;
            // 
            // txtAddress
            // 
            this.txtAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAddress.Location = new System.Drawing.Point(91, 86);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.tableLayoutPanel2.SetRowSpan(this.txtAddress, 2);
            this.txtAddress.Size = new System.Drawing.Size(305, 42);
            this.txtAddress.TabIndex = 6;
            // 
            // lblMobileno
            // 
            this.lblMobileno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMobileno.AutoSize = true;
            this.lblMobileno.Location = new System.Drawing.Point(412, 88);
            this.lblMobileno.Name = "lblMobileno";
            this.lblMobileno.Size = new System.Drawing.Size(71, 17);
            this.lblMobileno.TabIndex = 15;
            this.lblMobileno.Text = "Mobile No";
            // 
            // lblEmailId
            // 
            this.lblEmailId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEmailId.AutoSize = true;
            this.lblEmailId.Location = new System.Drawing.Point(412, 59);
            this.lblEmailId.Name = "lblEmailId";
            this.lblEmailId.Size = new System.Drawing.Size(71, 17);
            this.lblEmailId.TabIndex = 13;
            this.lblEmailId.Text = "Email Id";
            // 
            // lblPhonNo
            // 
            this.lblPhonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhonNo.AutoSize = true;
            this.lblPhonNo.Location = new System.Drawing.Point(412, 30);
            this.lblPhonNo.Name = "lblPhonNo";
            this.lblPhonNo.Size = new System.Drawing.Size(71, 17);
            this.lblPhonNo.TabIndex = 11;
            this.lblPhonNo.Text = "Phone No";
            // 
            // lblPincode
            // 
            this.lblPincode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPincode.AutoSize = true;
            this.lblPincode.Location = new System.Drawing.Point(3, 164);
            this.lblPincode.Name = "lblPincode";
            this.lblPincode.Size = new System.Drawing.Size(82, 17);
            this.lblPincode.TabIndex = 9;
            this.lblPincode.Text = "Pin Code";
            // 
            // lblcity
            // 
            this.lblcity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblcity.AutoSize = true;
            this.lblcity.Location = new System.Drawing.Point(3, 136);
            this.lblcity.Name = "lblcity";
            this.lblcity.Size = new System.Drawing.Size(82, 17);
            this.lblcity.TabIndex = 7;
            this.lblcity.Text = "City";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(3, 88);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 17);
            this.lblAddress.TabIndex = 5;
            this.lblAddress.Text = "Address";
            // 
            // lblItemType
            // 
            this.lblItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemType.AutoSize = true;
            this.lblItemType.Location = new System.Drawing.Point(3, 59);
            this.lblItemType.Name = "lblItemType";
            this.lblItemType.Size = new System.Drawing.Size(82, 17);
            this.lblItemType.TabIndex = 3;
            this.lblItemType.Text = "Type";
            // 
            // lblPartyName
            // 
            this.lblPartyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPartyName.AutoSize = true;
            this.lblPartyName.Location = new System.Drawing.Point(3, 30);
            this.lblPartyName.Name = "lblPartyName";
            this.lblPartyName.Size = new System.Drawing.Size(82, 17);
            this.lblPartyName.TabIndex = 1;
            this.lblPartyName.Text = "Party Name";
            // 
            // lblPartyMaster
            // 
            this.lblPartyMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPartyMaster.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblPartyMaster, 6);
            this.lblPartyMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartyMaster.Location = new System.Drawing.Point(3, 2);
            this.lblPartyMaster.Name = "lblPartyMaster";
            this.lblPartyMaster.Size = new System.Drawing.Size(801, 20);
            this.lblPartyMaster.TabIndex = 0;
            this.lblPartyMaster.Text = "Party Master";
            this.lblPartyMaster.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtPartyName
            // 
            this.txtPartyName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartyName.Location = new System.Drawing.Point(91, 28);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(305, 22);
            this.txtPartyName.TabIndex = 2;
            // 
            // cboItemType
            // 
            this.cboItemType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Items.AddRange(new object[] {
            "Customer",
            "H.O.",
            "Supplier"});
            this.cboItemType.Location = new System.Drawing.Point(91, 56);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(305, 24);
            this.cboItemType.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel2.SetColumnSpan(this.tableLayoutPanel3, 3);
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(637, 190);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(167, 29);
            this.tableLayoutPanel3.TabIndex = 17;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPartyMaster
            // 
            this.dgvPartyMaster.AllowUserToAddRows = false;
            this.dgvPartyMaster.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvPartyMaster.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPartyMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartyMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPartyMaster.Location = new System.Drawing.Point(3, 231);
            this.dgvPartyMaster.Name = "dgvPartyMaster";
            this.dgvPartyMaster.ReadOnly = true;
            this.dgvPartyMaster.RowTemplate.Height = 24;
            this.dgvPartyMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPartyMaster.Size = new System.Drawing.Size(807, 376);
            this.dgvPartyMaster.TabIndex = 1;
            this.dgvPartyMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartyMaster_RowEnter);
            // 
            // frmPartyMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 610);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmPartyMaster";
            this.Text = "Party Master";
            this.Load += new System.EventHandler(this.frmPartyMaster_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartyMaster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtMobileno;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtemailid;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtPincode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblMobileno;
        private System.Windows.Forms.Label lblEmailId;
        private System.Windows.Forms.Label lblPhonNo;
        private System.Windows.Forms.Label lblPincode;
        private System.Windows.Forms.Label lblcity;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblItemType;
        private System.Windows.Forms.Label lblPartyName;
        private System.Windows.Forms.Label lblPartyMaster;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.ComboBox cboItemType;
        private System.Windows.Forms.DataGridView dgvPartyMaster;
    }
}