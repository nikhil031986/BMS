using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;

namespace Transaction
{
    public partial class frmpurchase : Form
    {
        private DataTable dtPurchaseDetails = new DataTable();
        private DataTable dtPartyMaster = new DataTable();
        private ErrorProvider ep = new ErrorProvider();
        private string PurchaseDetailsID = string.Empty;
        private Entity.UserInfo currentUser;
        Entity.PurchaseMaster purchaseMaster = new Entity.PurchaseMaster();
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public frmpurchase()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillPartyMaster();
            clearAllControl();
        }
        private void fillPartyMaster()
        {
            dtPartyMaster = BAccess.BaPartyMaster.getRecordTable("SELECT PartyMst.PartyId, PartyMst.PartyName FROM PartyMst ");
            cboPartyName.DataSource = dtPartyMaster;
            cboPartyName.DisplayMember = "PartyName";
            cboPartyName.ValueMember = "PartyId";
            cboPartyName.SelectedIndex = 0;
        }
        private void getPurchaseDetails(int purchaseMaseterId)
        {
            try
            {
                CreateColumnControl();
                string strCommand = "SELECT PurDetail.PurDetailId AS Purcahse_Details_Id, PurDetail.PurMstId AS Purchase_Master_Id, ItemMst.Title AS Product_Name,"
                    + "ItemTypeMst.ItemType AS ItemType, PurDetail.Qty AS Quantity, PurDetail.Rate AS Rate,PurDetail.Dis AS Disc, PurDetail.ItemId AS ItemId, "
                    + "ItemMst.ItemTypeId AS ItemTypeId,PurDetail.Qty AS PQuantity FROM (ItemMst INNER JOIN PurDetail ON ItemMst.ItemId = PurDetail.ItemId) "
                    + "INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId " +
                    "WHERE(((PurDetail.PurMstId) = " + purchaseMaster.PurMstId + "))";
                dtPurchaseDetails.Load(BAccess.BaItemMaster.getRecordTable(strCommand).CreateDataReader());
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void clearAllControl(bool istxtinvoiceNo = false)
        {
            purchaseMaster = new Entity.PurchaseMaster();
            CreateColumnControl();
            cboPartyName.SelectedIndex = 0;
            txtdisAmount.Text = "0";
            if (!istxtinvoiceNo)
            {
                txtInvoiceNo.Text = string.Empty;
            }
            txtPayAmount.Text = "0";
            txtPendingAmount.Text = "0";
            txtTotalAmount.Text = "0";
            chkFullPayment.Checked = false;
            txtNetAmount.Text = "0";
            txtTotalAmount.Text = "0";
            PurchaseDetailsID = string.Empty;
        }
        private void CreateColumnControl()
        {
            try
            {
                
                dtPurchaseDetails = new DataTable();
                dgvProductDetails.DataSource = null;
                clsCommonFunc.AddColumnIntoDataTable(ref dtPurchaseDetails, ref dgvProductDetails, "Purchase");
                //BAccess.UserBaccess.AddColumnIntoDataTable(ref dtPurchaseDetails, "Purchase");
                dgvProductDetails.DataSource = dtPurchaseDetails;
                foreach (DataGridViewColumn dgColumns in dgvProductDetails.Columns)
                {
                    if (dgColumns.HeaderText.ToUpper().Contains("ID"))
                    {
                        dgColumns.Visible = false;
                    }
                    if (dgColumns.HeaderText == "PQuantity")
                    {
                        dgColumns.Visible = false;
                    }
                    if (dgColumns.HeaderText.ToUpper() == "DISCPER")
                    {
                        dgColumns.HeaderText = "Disc(%)";
                    }
                }
                dgvProductDetails.Columns["Product_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductDetails.Columns["ItemType"].Width = 100;
                dgvProductDetails.Columns["Rate"].Width = 70;
                dgvProductDetails.Columns["Quantity"].Width = 70;
                dgvProductDetails.Columns["Total_Rate"].Width = 70;
                dgvProductDetails.Columns["Total_Rate"].ReadOnly = true;
                dgvProductDetails.Columns["AutoNo"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvProductDetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                string command = string.Empty;
                if (e.ColumnIndex != -1 && e.RowIndex != -1)
                {
                    if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "ITEMTYPE")
                    {
                        command = "SELECT ItemTypeMstId,ItemType FROM ItemTypeMst";
                        frmsearch winfSearchControl = new frmsearch("ItemType", command, "ItemTypeMstId");
                        winfSearchControl.ShowDialog();
                        if (winfSearchControl.returnValue != string.Empty)
                        {
                            dgvProductDetails["ItemTypeId", e.RowIndex].Value = Convert.ToInt32(winfSearchControl.returnValue);
                            dgvProductDetails["ItemType", e.RowIndex].Value = Convert.ToString(winfSearchControl.returnCaption);
                        }
                    }
                    if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "PRODUCT_NAME")
                    {
                        string productType = Convert.ToString(dgvProductDetails["ItemTypeId", e.RowIndex].Value);
                        command = "SELECT ItemMst.[ItemId], ItemMst.[Title], ItemMst.[Description],ItemMst.[volume], ItemMst.[Edition], ItemMst.[Language], ItemMst.[Author] FROM ItemMst " + (productType.ToString() == "0" ? "" : " WHERE  ItemMst.ItemTypeId=" + productType.ToString());
                        frmsearch winfSearchControl = new frmsearch("Title", command, "ItemId");
                        winfSearchControl.ShowDialog();
                        if (winfSearchControl.returnValue != string.Empty)
                        {
                            Entity.ItemMaster currentItemMaster = BAccess.BaItemMaster.getItemMaster(Convert.ToInt32(winfSearchControl.returnValue));
                            dgvProductDetails["ItemId", e.RowIndex].Value = currentItemMaster.ItemId;
                            dgvProductDetails["Product_Name", e.RowIndex].Value = currentItemMaster.Title;
                            dgvProductDetails["Rate", e.RowIndex].Value = currentItemMaster.PurRate;
                            if (productType == "0" || productType == string.Empty)
                            {
                                Entity.ItemTypeMsater itemType = BAccess.BaItemTypeMast.getItemType(currentItemMaster.ItemTypeId);
                                dgvProductDetails["ItemTypeId", e.RowIndex].Value = itemType.ItemTypeMstId;
                                dgvProductDetails["ItemType", e.RowIndex].Value = itemType.ItemType;
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
        public void calculateTotalAmount()
        {
            dgvProductDetails.BindingContext[dtPurchaseDetails].EndCurrentEdit();
            var totalAmount = dtPurchaseDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
            txtTotalAmount.Text = Convert.ToString(totalAmount);
            txtNetAmount.Text = (totalAmount - Convert.ToDecimal(txtdisAmount.Text)).ToString();
            fillpendingAmount();
        }
        private void dgvProductDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "QUANTITY")
                {
                    dgvProductDetails.BindingContext[dtPurchaseDetails].EndCurrentEdit();
                }
                if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "DISC(%)")
                {
                    if (!String.IsNullOrWhiteSpace(Convert.ToString(dgvProductDetails[e.ColumnIndex, e.RowIndex].Value)) && Convert.ToString(dgvProductDetails["Disc", e.RowIndex].Value).Trim() == "0")
                    {
                        int discPer = Convert.ToInt32(dgvProductDetails[e.ColumnIndex, e.RowIndex].Value);
                        int qty = Convert.ToInt32(dgvProductDetails["Quantity", e.RowIndex].Value);
                        int amount = Convert.ToInt32(dgvProductDetails["Rate", e.RowIndex].Value);
                        int discAmount = ((amount * qty) * discPer) / 100;
                        dgvProductDetails["Disc", e.RowIndex].Value = discAmount;
                    }
                }
                if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "DISC")
                {
                    dgvProductDetails["DiscPer", e.RowIndex].Value = 0;
                }
                dgvProductDetails.BindingContext[dtPurchaseDetails].EndCurrentEdit();
                var totalAmount = dtPurchaseDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
                txtTotalAmount.Text = Convert.ToString(totalAmount);
                txtNetAmount.Text = (totalAmount - Convert.ToDecimal(txtdisAmount.Text)).ToString();
                fillpendingAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var totalAmount = dtPurchaseDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Sum(totalSum => totalSum.Field<decimal>("Total_Rate"));
                txtTotalAmount.Text = Convert.ToString(totalAmount);
                txtNetAmount.Text = (totalAmount - Convert.ToDecimal(txtdisAmount.Text)).ToString();
                fillpendingAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                dgvProductDetails["Product_Name", e.RowIndex].Style.BackColor = Color.LightSkyBlue;
                dgvProductDetails["ItemType", e.RowIndex].Style.BackColor = Color.LightSkyBlue;
            }
        }

        private void dgvProductDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //Do Nothing
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAllControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool InsertUpdateStatus = false;
            if (txtInvoiceNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please select atlist one item.");
                return;
            }
            if (dtPurchaseDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted).Count() == 0 ||
                dtPurchaseDetails.AsEnumerable().Where<DataRow>(filter => filter.RowState != DataRowState.Deleted && filter.Field<int>("Quantity") == 0).Count() > 0)
            {
                MessageBox.Show("Please select atlist one item.");
                return;
            }

            purchaseMaster.InvoidNo = txtInvoiceNo.Text.Trim();
            purchaseMaster.InvoiceDate = dtpInvoiceDate.Value;
            purchaseMaster.Partyid = (int)cboPartyName.SelectedValue;
            purchaseMaster.Pur_Amount = Convert.ToDecimal(txtTotalAmount.Text);
            purchaseMaster.TotalAmount = Convert.ToDecimal(txtNetAmount.Text);
            purchaseMaster.FullPayment = chkFullPayment.Checked;
            purchaseMaster.Dis_Amount = Convert.ToDecimal(txtdisAmount.Text);
            purchaseMaster.Desc = string.Empty;
            purchaseMaster.Pay_Amount = Convert.ToDecimal(txtPayAmount.Text);
            purchaseMaster.Pen_Amoun = Convert.ToDecimal(txtPendingAmount.Text);
            InsertUpdateStatus = BAccess.BaPurchaseMaster.insertPurchaseMaster(purchaseMaster, dtPurchaseDetails, PurchaseDetailsID, CurrentUser);
            if (InsertUpdateStatus)
            {
                MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAllControl();
            }
            txtInvoiceNo.Focus();
        }

        private void txtInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtInvoiceNo.Text.Trim() != string.Empty)
            {
                try
                {
                    purchaseMaster = BAccess.BaPurchaseMaster.getpurchaseMaster(txtInvoiceNo.Text.Trim());
                    if (purchaseMaster.PurMstId > 0)
                    {
                        txtInvoiceNo.Text = purchaseMaster.InvoidNo.ToString();
                        dtpInvoiceDate.Value = purchaseMaster.InvoiceDate;
                        cboPartyName.SelectedValue = purchaseMaster.Partyid;
                        txtTotalAmount.Text = purchaseMaster.Pur_Amount.ToString();
                        txtNetAmount.Text = purchaseMaster.TotalAmount.ToString();
                        chkFullPayment.Checked = purchaseMaster.FullPayment;
                        txtdisAmount.Text = purchaseMaster.Dis_Amount.ToString();
                        purchaseMaster.Desc = string.Empty;
                        txtPayAmount.Text = purchaseMaster.Pay_Amount.ToString();
                        txtPendingAmount.Text = purchaseMaster.Pen_Amoun.ToString();
                        getPurchaseDetails(purchaseMaster.PurMstId);
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

        private void dgvProductDetails_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                if (!currentUser.IsDelete)
                {
                    e.Cancel = true;
                    return;
                }
                if (dgvProductDetails["Purcahse_Details_Id", e.Row.Index].Value.ToString() != "0")
                {
                    PurchaseDetailsID = PurchaseDetailsID == string.Empty ? dgvProductDetails["Purcahse_Details_Id", e.Row.Index].Value.ToString() : PurchaseDetailsID + "," + dgvProductDetails["Purcahse_Details_Id", e.Row.Index].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtdisAmount_TextChanged(object sender, EventArgs e)
        {
            txtNetAmount.Text = (Convert.ToDecimal(txtTotalAmount.Text) - Convert.ToDecimal(txtdisAmount.Text)).ToString();
            fillpendingAmount();
        }
        private void fillpendingAmount()
        {
            decimal netAmount = Convert.ToDecimal(txtNetAmount.Text);
            decimal payamount = Convert.ToDecimal(txtPayAmount.Text);
            decimal pendingAmount = netAmount - payamount;
            txtPendingAmount.Text = pendingAmount.ToString();
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            fillpendingAmount();
        }

        private void dgvProductDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex >= 0 || e.RowIndex >= 0)
            {
                if (dgvProductDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() == "RATE" ||
                    dgvProductDetails.Columns[e.ColumnIndex].HeaderText.ToUpper() == "QUANTITY")
                {
                    double val;
                    Control edit = dgvProductDetails.EditingControl;
                    if (edit != null && !Double.TryParse(e.FormattedValue.ToString(), out val))
                    {
                        e.Cancel = true;
                        ep.SetError(edit, "Numeric value required");
                        ep.SetIconAlignment(edit, ErrorIconAlignment.MiddleLeft);
                        ep.SetIconPadding(edit, -10); // icon displays on left side of cell
                    }
                }
            }
        }

        private void txtdisAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (purchaseMaster.PurMstId > 0)
            {
                DialogResult mgResult = MessageBox.Show("Do you want to delete this record?", "Purchase", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (mgResult == DialogResult.Yes)
                {
                    try
                    {
                        bool InsertUpdateStatus = BAccess.BaPurchaseMaster.deletePurchase(purchaseMaster.PurMstId);
                        if (InsertUpdateStatus)
                        {
                            MessageBox.Show("Record deleted successfully.", "Purchasae", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmpurchase_Load(object sender, EventArgs e)
        {
            if (currentUser.IsDelete)
            {
                btnDelete.Visible = true;
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            frmEntry frmEnt = new frmEntry(purchaseMaster.PurMstId, "purchase", this);
            frmEnt.dtForAddRows = dtPurchaseDetails;
            frmEnt.Text = "Purchase Details";
            frmEnt.ShowDialog();
        }
    }
}
