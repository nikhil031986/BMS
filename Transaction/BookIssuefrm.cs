using Entity;
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
    public partial class BookIssuefrm : Form
    {
        private DataTable dtPurchaseDetails = new DataTable();
        private DataTable dtPartyMaster = new DataTable();
        private ErrorProvider ep = new ErrorProvider();
        private string PurchaseDetailsID = string.Empty;
        private Entity.UserInfo currentUser;        
        Entity.BookIssue BookIssueMaster = new Entity.BookIssue();
        public UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
        public BookIssuefrm(int bookIssueid)
        {
            InitializeComponent();
            clearAllControl();
            fillDataFromDataBase(bookIssueid);
        }
        private void getMaxNumber()
        {
            int newInvoiceNo = BAccess.UserBaccess.getScalerValue("SELECT Max(BookIssue.[IssueNo]) AS BookIssueNo FROM BookIssue");
            newInvoiceNo = newInvoiceNo + 1;
            txtInvoiceNo.Text = newInvoiceNo.ToString();            
        }
        public BookIssuefrm()
        {
            InitializeComponent();
            clearAllControl();
            getMaxNumber();
        }
        private void clearAllControl()
        {
            BookIssueMaster = new Entity.BookIssue();
            CreateColumnControl();
            txtPartyName.Text =string.Empty;
            txtMobileNo.Text = string.Empty;
            txtInvoiceNo.Text = string.Empty;
            dtpIssueDate.Value= DateTime.Now;
            dtpReturnDate.Value =dtpIssueDate.Value.AddDays(5);
            txtInvoiceNo.Text = "0";            
            PurchaseDetailsID = string.Empty;
        }
        private void getPurchaseDetails(int bookMasterId)
        {
            try
            {
                CreateColumnControl();
                string strCommand = "SELECT BookIssueDetail.BookIssueDetailId AS BookIssueDetailId, BookIssueDetail.BookId AS BookId, ItemMst.Title AS Product_Name,"
                    + "ItemTypeMst.ItemType AS ItemType, BookIssueDetail.Qty AS Quantity, BookIssueDetail.ItemId AS ItemId, "
                    + "ItemMst.ItemTypeId AS ItemTypeId,BookIssueDetail.Qty AS PQuantity FROM (ItemMst INNER JOIN BookIssueDetail ON ItemMst.ItemId = BookIssueDetail.ItemId) "
                    + "INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId " +
                    "WHERE(((BookIssueDetail.BookId) = " + bookMasterId.ToString() + "))";
                dtPurchaseDetails.Load(BAccess.BaItemMaster.getRecordTable(strCommand).CreateDataReader());
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CreateColumnControl()
        {
            try
            {
                dtPurchaseDetails = new DataTable();
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
                dcPurcahse_Details_Id.ColumnName = "BookIssueDetailId";
                DataColumn dcPurchase_Master_Id = new DataColumn();
                dcPurchase_Master_Id.AllowDBNull = true;
                dcPurchase_Master_Id.DataType = typeof(int);
                dcPurchase_Master_Id.DefaultValue = 0;
                dcPurchase_Master_Id.ColumnName = "BookId";
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
                DataColumn dcQuantity = new DataColumn();
                dcQuantity.AllowDBNull = true;
                dcQuantity.DataType = typeof(int);
                dcQuantity.DefaultValue = 0;
                dcQuantity.ColumnName = "Quantity";
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
                dtPurchaseDetails.Columns.AddRange(new DataColumn[] { dcAutoNo, dcPurcahse_Details_Id, dcPurchase_Master_Id, dcProduct_Master_Id, dcProduct_Type_Id, dcProduct_Type, dcProduct_Name,  dcQuantity, dcPQuantity });
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
                }
                dgvProductDetails.Columns["Product_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvProductDetails.Columns["ItemType"].Width = 100;
                dgvProductDetails.Columns["Quantity"].Width = 70;
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

        private void dgvProductDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProductDetails[e.ColumnIndex, e.RowIndex].OwningColumn.HeaderText.ToUpper() == "QUANTITY")
                {
                    dgvProductDetails.BindingContext[dtPurchaseDetails].EndCurrentEdit();
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearAllControl();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
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

                BookIssueMaster.IssueNo = Convert.ToInt32(txtInvoiceNo.Text.Trim());
                BookIssueMaster.IssueDate = dtpIssueDate.Value;
                BookIssueMaster.ReturnDate = dtpReturnDate.Value;
                BookIssueMaster.PartyName = txtPartyName.Text.Trim();
                BookIssueMaster.MobileNo = txtMobileNo.Text.Trim();
                BookIssueMaster.Emailid = txtEmailId.Text.Trim();
                BookIssueMaster.IsReturn = chkReturnBook.Checked;
                InsertUpdateStatus = BAccess.BaBookIssue.insertBookIssueMaster(BookIssueMaster, dtPurchaseDetails, PurchaseDetailsID, CurrentUser);
                if (InsertUpdateStatus)
                {
                    MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }
        private void fillDataFromDataBase(int bookMasterId)
        {
            try
            {
                BookIssueMaster = BAccess.BaBookIssue.getbookIssueMaster(string.Empty,bookMasterId);
                if (BookIssueMaster.BookIssueId > 0)
                {
                    txtInvoiceNo.Text = BookIssueMaster.IssueNo.ToString();
                    dtpIssueDate.Value = BookIssueMaster.IssueDate;
                    dtpReturnDate.Value = BookIssueMaster.ReturnDate;
                    txtPartyName.Text = BookIssueMaster.PartyName;
                    txtMobileNo.Text = BookIssueMaster.MobileNo;
                    txtEmailId.Text = BookIssueMaster.Emailid;
                    chkReturnBook.Checked = BookIssueMaster.IsReturn;
                    getPurchaseDetails(BookIssueMaster.BookIssueId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearAllControl();
            }
        }
        
        private void txtInvoiceNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtInvoiceNo.Text.Trim() != string.Empty && txtInvoiceNo.Text.Trim() != "0")
            {
                try
                {
                    if (BookIssueMaster.BookIssueId <= 0)
                    {
                        BookIssueMaster = BAccess.BaBookIssue.getbookIssueMaster(txtInvoiceNo.Text.Trim());
                        if (BookIssueMaster.BookIssueId > 0)
                        {
                            txtInvoiceNo.Text = BookIssueMaster.IssueNo.ToString();
                            dtpIssueDate.Value = BookIssueMaster.IssueDate;
                            dtpReturnDate.Value = BookIssueMaster.ReturnDate;
                            txtPartyName.Text = BookIssueMaster.PartyName;
                            txtMobileNo.Text = BookIssueMaster.MobileNo;
                            txtEmailId.Text = BookIssueMaster.Emailid;
                            chkReturnBook.Checked = BookIssueMaster.IsReturn;
                            getPurchaseDetails(BookIssueMaster.BookIssueId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clearAllControl();
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
    }
}
