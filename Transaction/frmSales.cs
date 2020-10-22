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
    public partial class frmSales : Form
    {
        private DataTable dtSalesDetails = new DataTable();
        private ErrorProvider ep = new ErrorProvider();
        private string SalesDetailsID = string.Empty;
        private Entity.UserInfo currentUser;
        Entity.SalesMaster salesMaster = new Entity.SalesMaster();
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public Entity.UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
        public frmSales()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            clearAllControl();
        }
        private void clearAllControl(bool istxtInvoiceNo = false)
        {
            salesMaster = new Entity.SalesMaster();
            CreateColumnControl();
            txtPartyName.Text = string.Empty;
            txtTotalAmount.Text = "0";
            if (!istxtInvoiceNo)
            {
                txtInvoiceNo.Text = "0";
            }
            dtpSalesDate.Value = DateTime.Now;
            txtDisAmount.Text = "0";
            txtNetAmount.Text = "0";
            txtRemarks.Text = string.Empty;
            SalesDetailsID = string.Empty;
            lblError.Text = string.Empty;
        }
        private void CreateColumnControl()
        {
            try
            {
                dtSalesDetails = new DataTable();
                DataColumn dcAutoNo = new DataColumn();
                dcAutoNo.AutoIncrement = true;
                dcAutoNo.AutoIncrementSeed = 1;
                dcAutoNo.AutoIncrementStep = 1;
                dcAutoNo.AllowDBNull = true;
                dcAutoNo.DataType = typeof(int);
                dcAutoNo.ColumnName = "AutoNo";
                DataColumn dcPurcahse_Details_Id = new DataColumn();
                dcPurcahse_Details_Id.AllowDBNull = true;
                dcPurcahse_Details_Id.DataType = typeof(int);
                dcPurcahse_Details_Id.DefaultValue = 0;
                dcPurcahse_Details_Id.ColumnName = "Sales_Details_Id";
                DataColumn dcPurchase_Master_Id = new DataColumn();
                dcPurchase_Master_Id.AllowDBNull = true;
                dcPurchase_Master_Id.DataType = typeof(int);
                dcPurchase_Master_Id.DefaultValue = 0;
                dcPurchase_Master_Id.ColumnName = "Sales_Master_Id";
                DataColumn dcProduct_Master_Id = new DataColumn();
                dcProduct_Master_Id.AllowDBNull = true;
                dcProduct_Master_Id.DataType = typeof(int);
                dcProduct_Master_Id.DefaultValue = 0;
                dcProduct_Master_Id.ColumnName = "ItemId";
                DataColumn dcProduct_Type_Id = new DataColumn();
                dcProduct_Type_Id.AllowDBNull = true;
                dcProduct_Type_Id.DataType = typeof(int);
                dcProduct_Type_Id.DefaultValue = 0;
                dcProduct_Type_Id.ColumnName = "ItemTypeId";
                DataColumn dcRate = new DataColumn();
                dcRate.AllowDBNull = true;
                dcRate.DataType = typeof(decimal);
                dcRate.DefaultValue = decimal.Zero;
                dcRate.ColumnName = "Rate";
                DataColumn dcQuantity = new DataColumn();
                dcQuantity.AllowDBNull = true;
                dcQuantity.DataType = typeof(int);
                dcQuantity.DefaultValue = 0;
                dcQuantity.ColumnName = "Quantity";
                DataColumn dcDisc = new DataColumn();
                dcDisc.AllowDBNull = true;
                dcDisc.DataType = typeof(int);
                dcDisc.DefaultValue = 0;
                dcDisc.ColumnName = "Disc";
                DataColumn dcDiscPer = new DataColumn();
                dcDiscPer.AllowDBNull = true;
                dcDiscPer.DataType = typeof(int);
                dcDiscPer.DefaultValue = 0;
                dcDiscPer.ColumnName = "DiscPer";
                DataColumn dcTotal_Rate = new DataColumn();
                dcTotal_Rate.AllowDBNull = true;
                dcTotal_Rate.DataType = typeof(decimal);
                dcTotal_Rate.DefaultValue = decimal.Zero;
                dcTotal_Rate.ColumnName = "Total_Rate";
                dcTotal_Rate.Expression = "(Rate*Quantity)-Disc";
                DataColumn dcProduct_Type = new DataColumn();
                dcProduct_Type.AllowDBNull = true;
                dcProduct_Type.DataType = typeof(string);
                dcProduct_Type.DefaultValue = string.Empty;
                dcProduct_Type.ColumnName = "ItemType";
                DataColumn dcProduct_Name = new DataColumn();
                dcProduct_Name.AllowDBNull = true;
                dcProduct_Name.DataType = typeof(string);
                dcProduct_Name.DefaultValue = string.Empty;
                dcProduct_Name.ColumnName = "Product_Name";
                DataColumn dcPQuantity = new DataColumn();
                dcPQuantity.AllowDBNull = true;
                dcPQuantity.DataType = typeof(int);
                dcPQuantity.DefaultValue = 0;
                dcPQuantity.ColumnName = "PQuantity";
                DataColumn dcStock = new DataColumn();
                dcStock.AllowDBNull = true;
                dcStock.DataType = typeof(int);
                dcStock.DefaultValue = 0;
                dcStock.ColumnName = "Stock";
                dtSalesDetails.Columns.AddRange(new DataColumn[] { dcAutoNo, dcPurcahse_Details_Id, dcPurchase_Master_Id, dcProduct_Master_Id, dcProduct_Type_Id, dcProduct_Type, dcProduct_Name, dcRate, dcQuantity, dcDiscPer, dcDisc, dcTotal_Rate, dcPQuantity, dcStock });
                dgvSalesDetails.DataSource = dtSalesDetails;
                foreach (DataGridViewColumn dgColumns in dgvSalesDetails.Columns)
                {
                    if (dgColumns.HeaderText.ToUpper().Contains("ID"))
                    {
                        dgColumns.Visible = false;
                    }
                    if (dgColumns.HeaderText == "PQuantity")
                    {
                        dgColumns.Visible = false;
                    }
                    if (dgColumns.HeaderText == "Stock")
                    {
                        dgColumns.Visible = false;
                    }
                    if (dgColumns.HeaderText.ToUpper() == "DISCPER")
                    {
                        dgColumns.HeaderText = "Disc(%)";
                    }
                }
                dgvSalesDetails.Columns["Product_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvSalesDetails.Columns["ItemType"].Width = 100;
                dgvSalesDetails.Columns["Rate"].Width = 70;
                dgvSalesDetails.Columns["Quantity"].Width = 70;
                dgvSalesDetails.Columns["Total_Rate"].Width = 70;
                dgvSalesDetails.Columns["Total_Rate"].ReadOnly = true;
                dgvSalesDetails.Columns["AutoNo"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void calculateTotalAmount()
        {
            dgvSalesDetails.BindingContext[dtSalesDetails].EndCurrentEdit();
            var totalAmount = dtSalesDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
            txtTotalAmount.Text = Convert.ToString(totalAmount);
            txtNetAmount.Text = (totalAmount - Convert.ToDecimal(txtDisAmount.Text)).ToString();            
        }
        private void dgvSalesDetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string command = string.Empty;
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    if (dgvSalesDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "ITEMTYPE")
                    {
                        command = "SELECT ItemTypeMstId,ItemType FROM ItemTypeMst";
                        frmsearch winfSearchControl = new frmsearch("ItemType", command, "ItemTypeMstId");
                        winfSearchControl.ShowDialog();
                        if (winfSearchControl.returnValue != string.Empty)
                        {
                            dgvSalesDetails["ItemTypeId", e.RowIndex].Value = Convert.ToInt32(winfSearchControl.returnValue);
                            dgvSalesDetails["ItemType", e.RowIndex].Value = Convert.ToString(winfSearchControl.returnCaption);
                        }
                    }
                    if (dgvSalesDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "PRODUCT_NAME")
                    {
                        string productType = Convert.ToString(dgvSalesDetails["ItemTypeId", e.RowIndex].Value);
                        command = "SELECT ItemMst.[ItemId], ItemMst.[Title], ItemMst.[Description], StockMst.[CurrStock],ItemMst.[volume], ItemMst.[Edition], ItemMst.[Language], ItemMst.[Author] FROM ItemMst INNER JOIN StockMst ON ItemMst.[ItemId] = StockMst.[ItemId]" + (productType.ToString() == "0" ? "" : " WHERE  ItemMst.[ItemTypeId]=" + productType.ToString());
                        frmsearch winfSearchControl = new frmsearch("Title", command, "ItemId");
                        winfSearchControl.ShowDialog();
                        if (winfSearchControl.returnValue != string.Empty)
                        {
                            Entity.ItemMaster currentItemMaster = BAccess.BaItemMaster.getItemMaster(Convert.ToInt32(winfSearchControl.returnValue));
                            dgvSalesDetails["ItemId", e.RowIndex].Value = currentItemMaster.ItemId;
                            dgvSalesDetails["Product_Name", e.RowIndex].Value = currentItemMaster.Title;
                            dgvSalesDetails["Rate", e.RowIndex].Value = currentItemMaster.SalesRate;
                            dgvSalesDetails["Stock", e.RowIndex].Value = currentItemMaster.CurrentStock;
                            if (productType == "0" || productType == string.Empty)
                            {
                                Entity.ItemTypeMsater itemType = BAccess.BaItemTypeMast.getItemType(currentItemMaster.ItemTypeId);
                                dgvSalesDetails["ItemTypeId", e.RowIndex].Value = itemType.ItemTypeMstId;
                                dgvSalesDetails["ItemType", e.RowIndex].Value = itemType.ItemType;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalesDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvSalesDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "QUANTITY")
                {
                    dgvSalesDetails.BindingContext[dtSalesDetails].EndCurrentEdit();
                }
                if (dgvSalesDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "DISC(%)")
                {
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dgvSalesDetails[e.ColumnIndex, e.RowIndex].Value)) && Convert.ToString(dgvSalesDetails["Disc", e.RowIndex].Value).Trim() == "0")
                    {
                        int discPer = Convert.ToInt32(dgvSalesDetails[e.ColumnIndex, e.RowIndex].Value);
                        int qty = Convert.ToInt32(dgvSalesDetails["Quantity", e.RowIndex].Value);
                        int amount = Convert.ToInt32(dgvSalesDetails["Rate", e.RowIndex].Value);
                        int discAmount = ((amount * qty) * discPer) / 100;
                        dgvSalesDetails["Disc", e.RowIndex].Value = discAmount;
                    }
                }
                if (dgvSalesDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "DISC")
                {
                    dgvSalesDetails["DiscPer", e.RowIndex].Value = 0;
                }
                dgvSalesDetails.BindingContext[dtSalesDetails].EndCurrentEdit();
                var totalAmount = dtSalesDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
                txtTotalAmount.Text = Convert.ToString(totalAmount);
                txtNetAmount.Text = decimalwithtwo(totalAmount - Convert.ToDecimal(txtDisAmount.Text));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string decimalwithtwo(decimal convertValue)
        {
            return decimal.Round(convertValue, 2, MidpointRounding.AwayFromZero).ToString();
        }
        private void dgvSalesDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var totalAmount = dtSalesDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
                txtTotalAmount.Text = Convert.ToString(totalAmount);                
                txtNetAmount.Text = decimalwithtwo(totalAmount - Convert.ToDecimal(txtDisAmount.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSalesDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgvSalesDetails["Product_Name", e.RowIndex].Style.BackColor = Color.LightSkyBlue;
                dgvSalesDetails["ItemType", e.RowIndex].Style.BackColor = Color.LightSkyBlue;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAllControl();
            getMaxInvoicNoFromDataBase();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool InsertUpdateStatus = false;
            if (txtInvoiceNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select atlist one item.");
                return;
            }
            if (dtSalesDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Count() == 0 ||
                dtSalesDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted && filter.Field<int>("Quantity") == 0).Count() > 0)
            {
                MessageBox.Show("Please select atlist one item.");
                return;
            }

            salesMaster.InvoiceNo = Convert.ToInt32(txtInvoiceNo.Text.Trim());
            salesMaster.SalesDate = dtpSalesDate.Value;
            salesMaster.PartyName = txtPartyName.Text.Trim();
            salesMaster.Total_Amount = Convert.ToDecimal(txtTotalAmount.Text);
            salesMaster.Sales_Amount = Convert.ToDecimal(txtNetAmount.Text);
            salesMaster.Dis_Amount = Convert.ToDecimal(txtDisAmount.Text);
            salesMaster.Desc = txtRemarks.Text.Trim();
            InsertUpdateStatus = BAccess.BaSalesMaster.insertSalesMaster(salesMaster, dtSalesDetails, SalesDetailsID, CurrentUser);
            if (InsertUpdateStatus)
            {
                MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (salesMaster.SalesMstId > 0)
                {
                    rptSales report = new rptSales(salesMaster.SalesMstId);
                    report.MdiParent = this.MdiParent;
                    report.Show();
                }
                clearAllControl();
                getMaxInvoicNoFromDataBase();
            }
            else
            {
                txtInvoiceNo.Focus();
            }
        }
        private void getSalesDetails(int purchaseMaseterId)
        {
            try
            {
                CreateColumnControl();
                string strCommand = "SELECT SalesDetail.SalesDetailId AS Sales_Details_Id, SalesDetail.SalesMstId AS Sales_Master_Id, ItemMst.Title AS Product_Name,"
                    + "ItemTypeMst.ItemType AS ItemType, SalesDetail.Qty AS Quantity, SalesDetail.Rate AS Rate,SalesDetail.Disc AS Disc, SalesDetail.ItemId AS ItemId, "
                    + "ItemMst.ItemTypeId AS ItemTypeId,SalesDetail.Qty AS PQuantity,StockMst.CurrStock AS Stock FROM ((ItemMst INNER JOIN SalesDetail ON ItemMst.ItemId = SalesDetail.ItemId) "
                    + "INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId) INNER JOIN StockMst ON ItemMst.ItemId = StockMst.ItemId " +
                    "WHERE(((SalesDetail.SalesMstId) = " + purchaseMaseterId.ToString() + "))";
                dtSalesDetails.Load(BAccess.BaItemMaster.getRecordTable(strCommand).CreateDataReader());
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void txtInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtInvoiceNo.Text.Trim() != string.Empty)
            {
                try
                {
                    salesMaster = BAccess.BaSalesMaster.getsalesMaster(txtInvoiceNo.Text.Trim());
                    if (salesMaster.SalesMstId > 0)
                    {
                        txtInvoiceNo.Text = salesMaster.InvoiceNo.ToString();
                        dtpSalesDate.Value = salesMaster.SalesDate;
                        txtPartyName.Text = salesMaster.PartyName;
                        txtTotalAmount.Text = salesMaster.Total_Amount.ToString();
                        txtNetAmount.Text = salesMaster.Sales_Amount.ToString();
                        txtDisAmount.Text = decimalwithtwo(salesMaster.Dis_Amount);
                        txtRemarks.Text = salesMaster.Desc;
                        getSalesDetails(salesMaster.SalesMstId);
                    }
                    else
                    {
                        clearAllControl(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearAllControl(true);
                }
            }
            else
            {
                clearAllControl(true);
            }
        }

        private void dgvSalesDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!currentUser.IsDelete)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                if (dgvSalesDetails["Sales_Details_Id", e.Row.Index].Value.ToString() != "0")
                {
                    SalesDetailsID = SalesDetailsID == string.Empty ? dgvSalesDetails["Sales_Details_Id", e.Row.Index].Value.ToString() : SalesDetailsID + "," + dgvSalesDetails["Sales_Details_Id", e.Row.Index].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDisAmount_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = decimalwithtwo((Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtDisAmount.Text)));
        }

        private void dgvSalesDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex >= 0)
            {
                if (dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() == "RATE" ||
                    dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() == "QUANTITY")
                {
                    double val;
                    Control edit = dgvSalesDetails.EditingControl;
                    if (edit != null && !Double.TryParse(e.FormattedValue.ToString(), out val))
                    {
                        lblError.Text = dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() + ": Numeric value required";
                        e.Cancel = true;
                        ep.SetError(edit, "Numeric value required");
                        ep.SetIconAlignment(edit, ErrorIconAlignment.MiddleLeft);
                        ep.SetIconPadding(edit, -10); // icon displays on left side of cell
                    }
                    else
                    {
                        if (dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() == "QUANTITY")
                        {
                            var currentStock = Convert.ToInt32(dgvSalesDetails["PQuantity", e.RowIndex].Value) + Convert.ToInt32(dgvSalesDetails["Stock", e.RowIndex].Value);
                            if (Convert.ToInt32(currentStock) < Convert.ToInt32(e.FormattedValue))
                            {
                                lblError.Text = dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() + ": Quantity greater than current stock[" + currentStock.ToString() + "]";
                                e.Cancel = true;
                                ep.SetError(edit, "Quantity greater than current stock[" + currentStock.ToString() + "]");
                                ep.SetIconAlignment(edit, ErrorIconAlignment.MiddleLeft);
                                ep.SetIconPadding(edit, -10); // icon displays on left side of cell
                            }
                            else
                            {
                                if (edit != null)
                                {
                                    ep.SetError(edit, "");
                                }
                                lblError.Text = dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper();
                            }
                        }
                        else
                        {
                            if (edit != null)
                            {
                                ep.SetError(edit, "");
                            }
                            lblError.Text = dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper();
                        }
                    }
                }
            }
        }

        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvSalesDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!lblError.Text.Contains(dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper()))
            {
                lblError.Text = dgvSalesDetails.Columns[e.ColumnIndex].HeaderText.ToUpper();
            }
        }

        private void dgvSalesDetails_Leave(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        private void txtTotalAmount_Enter(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (salesMaster.SalesMstId > 0)
            {
                rptSales report = new rptSales(salesMaster.SalesMstId);
                report.MdiParent = this.MdiParent;
                report.Show();
            }
        }
        private void getMaxInvoicNoFromDataBase()
        {
            clearAllControl();
            int newInvoiceNo = BAccess.UserBaccess.getScalerValue("SELECT Max(SalesMst.[InvoiceNo]) AS NewInvoiceNo FROM SalesMst WHERE (((SalesMst.Year_Id)=" + CurrentUser.CurrentYearId.ToString().Trim() + "))");
            newInvoiceNo = newInvoiceNo + 1;
            txtInvoiceNo.Text = newInvoiceNo.ToString();
            dtpSalesDate.Focus();
        }
        private void btnADD_Click(object sender, EventArgs e)
        {
            getMaxInvoicNoFromDataBase();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (salesMaster.SalesMstId> 0)
            {
                DialogResult mgResult = MessageBox.Show("Do you want to delete this record?", "Sales", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (mgResult == DialogResult.Yes)
                {
                    try
                    {
                        bool InsertUpdateStatus = BAccess.BaSalesMaster.deleteSales(salesMaster.SalesMstId);
                        if (InsertUpdateStatus)
                        {
                            MessageBox.Show("Record deleted successfully.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearAllControl();
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString(), "Purchase", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void frmSales_Load(object sender, EventArgs e)
        {
            if (currentUser.IsDelete)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;               
            }
            getMaxInvoicNoFromDataBase();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            frmEntry frmEnt = new frmEntry(salesMaster.SalesMstId, "sales", this);
            frmEnt.dtForAddRows = dtSalesDetails;
            frmEnt.Text = "Sales Details";
            frmEnt.ShowDialog();
        }
    }
}
