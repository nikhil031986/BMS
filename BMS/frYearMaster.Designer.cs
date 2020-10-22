namespace BMS
{
    partial class frYearMaster
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
            this.tblYearMaster = new System.Windows.Forms.TableLayoutPanel();
            this.lblYearMaster = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.dgvYearMaster = new System.Windows.Forms.DataGridView();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.flControlButton = new System.Windows.Forms.FlowLayoutPanel();
            this.tblYearMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYearMaster)).BeginInit();
            this.flControlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblYearMaster
            // 
            this.tblYearMaster.AutoSize = true;
            this.tblYearMaster.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblYearMaster.ColumnCount = 4;
            this.tblYearMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblYearMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblYearMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblYearMaster.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tblYearMaster.Controls.Add(this.flControlButton, 2, 4);
            this.tblYearMaster.Controls.Add(this.dtpEndDate, 1, 2);
            this.tblYearMaster.Controls.Add(this.dtpFromDate, 1, 1);
            this.tblYearMaster.Controls.Add(this.txtRemarks, 1, 3);
            this.tblYearMaster.Controls.Add(this.lblRemarks, 0, 3);
            this.tblYearMaster.Controls.Add(this.dgvYearMaster, 0, 5);
            this.tblYearMaster.Controls.Add(this.lblEndDate, 0, 2);
            this.tblYearMaster.Controls.Add(this.lblStartDate, 0, 1);
            this.tblYearMaster.Controls.Add(this.lblYearMaster, 0, 0);
            this.tblYearMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblYearMaster.Location = new System.Drawing.Point(0, 0);
            this.tblYearMaster.Name = "tblYearMaster";
            this.tblYearMaster.RowCount = 6;
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tblYearMaster.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblYearMaster.Size = new System.Drawing.Size(848, 522);
            this.tblYearMaster.TabIndex = 0;
            // 
            // lblYearMaster
            // 
            this.lblYearMaster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYearMaster.AutoSize = true;
            this.tblYearMaster.SetColumnSpan(this.lblYearMaster, 4);
            this.lblYearMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearMaster.Location = new System.Drawing.Point(3, 3);
            this.lblYearMaster.Margin = new System.Windows.Forms.Padding(3);
            this.lblYearMaster.Name = "lblYearMaster";
            this.lblYearMaster.Size = new System.Drawing.Size(842, 24);
            this.lblYearMaster.TabIndex = 0;
            this.lblYearMaster.Text = "Year Master";
            this.lblYearMaster.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartDate
            // 
            this.lblStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(3, 35);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(74, 17);
            this.lblStartDate.TabIndex = 1;
            this.lblStartDate.Text = "From Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(3, 63);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(74, 17);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "To Date";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(3, 91);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(74, 17);
            this.lblRemarks.TabIndex = 1;
            this.lblRemarks.Text = "Remarks";
            // 
            // dgvYearMaster
            // 
            this.dgvYearMaster.AllowUserToAddRows = false;
            this.dgvYearMaster.AllowUserToDeleteRows = false;
            this.dgvYearMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblYearMaster.SetColumnSpan(this.dgvYearMaster, 4);
            this.dgvYearMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvYearMaster.Location = new System.Drawing.Point(3, 152);
            this.dgvYearMaster.Name = "dgvYearMaster";
            this.dgvYearMaster.ReadOnly = true;
            this.dgvYearMaster.RowHeadersVisible = false;
            this.dgvYearMaster.RowTemplate.Height = 24;
            this.dgvYearMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvYearMaster.Size = new System.Drawing.Size(842, 367);
            this.dgvYearMaster.TabIndex = 2;
            this.dgvYearMaster.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYearMaster_RowEnter);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.Location = new System.Drawing.Point(83, 89);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(200, 22);
            this.txtRemarks.TabIndex = 1;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(83, 33);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFromDate.TabIndex = 1;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndDate.CustomFormat = "dd-MM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(83, 61);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 22);
            this.dtpEndDate.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // flControlButton
            // 
            this.flControlButton.AutoSize = true;
            this.flControlButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblYearMaster.SetColumnSpan(this.flControlButton, 2);
            this.flControlButton.Controls.Add(this.btnSave);
            this.flControlButton.Controls.Add(this.button2);
            this.flControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flControlButton.Location = new System.Drawing.Point(289, 117);
            this.flControlButton.Name = "flControlButton";
            this.flControlButton.Size = new System.Drawing.Size(556, 29);
            this.flControlButton.TabIndex = 3;
            // 
            // frYearMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 522);
            this.Controls.Add(this.tblYearMaster);
            this.Name = "frYearMaster";
            this.Text = "Year Master";
            this.tblYearMaster.ResumeLayout(false);
            this.tblYearMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYearMaster)).EndInit();
            this.flControlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblYearMaster;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.DataGridView dgvYearMaster;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblYearMaster;
        private System.Windows.Forms.FlowLayoutPanel flControlButton;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
    }
}