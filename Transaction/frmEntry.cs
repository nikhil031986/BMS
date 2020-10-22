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
    public partial class frmEntry : Form
    {

        public Form _pform = null;
        private DataTable _dtForAddRows = new DataTable();
        private DataTable dtForItemType = new DataTable();
        private DataTable dtForItemMaster = new DataTable();
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            if (keyData == (Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
            return base.ProcessDialogKey(keyData);
        }     
        public DataTable dtForAddRows
        {
            get
            {
                return _dtForAddRows;
            }
            set
            {
                _dtForAddRows = value;
            }
        }
        private string _baseFormName = string.Empty;
        private int _baseMasterId = 0;
        public frmEntry()
        {
            InitializeComponent();
        }
        private int itemTypeMasterId = 0;
        private int itemMasterId = 0;
        private string itemType = string.Empty;
        public frmEntry(int baseMasterId, string baseFormName, Form pform)
        {
            InitializeComponent();
            _baseFormName = baseFormName;
            _baseMasterId = baseMasterId;
            _pform = pform;
            fillItemType();
            fillItemMaster(itemTypeMasterId);
        }
        private void fillItemType()
        {
            dtForItemType = BAccess.BaItemMaster.getRecordTable("SELECT ItemTypeMstId,ItemType FROM ItemTypeMst");
            cboItemType.DataSource = dtForItemType;
            cboItemType.DisplayMember = "ItemType";
            cboItemType.ValueMember = "ItemTypeMstId";
            cboItemType.SelectedIndex = 0;
        }
        private void fillItemMaster(int itemMasterId)
        {
            if (itemMasterId == 0)
            {
                dtForItemMaster = BAccess.BaItemMaster.getRecordTable("SELECT ItemMst.ItemId,ItemMst.ItemTypeId, ItemMst.Title, ItemMst.purRate, ItemMst.salesRate, StockMst.CurrStock FROM StockMst INNER JOIN ItemMst ON StockMst.ItemId = ItemMst.ItemId");
            }
            else
            {
                dtForItemMaster = BAccess.BaItemMaster.getRecordTable("SELECT ItemMst.ItemId, ItemMst.ItemTypeId, ItemMst.Title, ItemMst.purRate, ItemMst.salesRate, StockMst.CurrStock FROM StockMst INNER JOIN ItemMst ON StockMst.ItemId = ItemMst.ItemId WHERE (((ItemMst.ItemTypeId)=" + itemMasterId.ToString() + "))");
            }
            cboItemName.DataSource = dtForItemMaster;
            cboItemName.DisplayMember = "Title";
            cboItemName.ValueMember = "ItemId";
            if (dtForItemMaster.Rows.Count > 0)
            {
                cboItemName.SelectedIndex = 0;
            }
            else
            {
                cboItemName.Text = "";
            }
        }
        private void txtint_KeyPress(object sender, KeyPressEventArgs e)
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
        private void calculateAmount()
        {
            checkValueIsNull();
            int discPer = Convert.ToInt32(txtDiscP.Text);
            int qty = Convert.ToInt32(txtQty.Text);
            int amount = Convert.ToInt32(txtRate.Text);
            int discAmount = discPer == 0 ? Convert.ToInt32(txtDisc.Text) : ((amount * qty) * discPer) / 100;
            int Netamount = (amount * qty) - discAmount;
            txtAmount.Text = Netamount.ToString();
        }
        private void checkValueIsNull()
        {
            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                txtQty.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txtRate.Text))
            {
                txtRate.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txtDiscP.Text))
            {
                txtDiscP.Text = "0";
            }
            if (string.IsNullOrWhiteSpace(txtDisc.Text))
            {
                txtDisc.Text = "0";
            }
        }

        private void calculateDiscAmount(bool isDiscPer)
        {
            checkValueIsNull();
            if (isDiscPer)
            {
                int discPer = Convert.ToInt32(txtDiscP.Text);
                int qty = Convert.ToInt32(txtQty.Text);
                int amount = Convert.ToInt32(txtRate.Text);
                int discAmount = ((amount * qty) * discPer) / 100;
                txtDisc.Text = discAmount.ToString();
            }
            else
            {
                txtDiscP.Text = "0";
            }
        }
        private void clearControl()
        {
            txtRate.Text = "0";
            txtQty.Text = "0";
            txtCurrentStock.Text = "0";
            txtDisc.Text = "0";
            txtDiscP.Text = "0";
            txtAmount.Text = "0";
            cboItemName.Focus();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = _dtForAddRows.NewRow();
            if (_baseFormName.ToUpper() == "PURCHASE")
            {
                DataRow drItem = dtForItemMaster.AsEnumerable().Where<DataRow>(o => o.Field<int>("ItemId") == itemMasterId).FirstOrDefault();
                dr["Purcahse_Details_Id"] = 0;
                dr["Purchase_Master_Id"] = _baseMasterId;
                dr["ItemId"] = drItem["ItemId"];
                dr["ItemTypeId"] = drItem["ItemTypeId"];
                dr["ItemType"] = itemType;
                dr["Product_Name"] = drItem["Title"];
                dr["Rate"] = txtRate.Text;
                dr["Quantity"] = txtQty.Text;
                dr["DiscPer"] = txtDiscP.Text;
                dr["Disc"] = txtDisc.Text;
                dr["Total_Rate"] = txtAmount.Text;
                dr["PQuantity"] = 0;
                _dtForAddRows.Rows.Add(dr);
                ((frmpurchase)this._pform).calculateTotalAmount();
                clearControl();
            }
            if (_baseFormName.ToUpper() == "SALES")
            {
                bool qtyValidation = true;
                int qty = Convert.ToInt32(txtQty.Text);
                int currentQty = Convert.ToInt32(txtCurrentStock.Text);
                if (qty > currentQty)
                {
                    MessageBox.Show("Quantity must be less then or equals to current quantity.", "Sales", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtQty.Focus();
                    qtyValidation = false;
                }
                if (qtyValidation)
                {
                    DataRow drItem = dtForItemMaster.AsEnumerable().Where<DataRow>(o => o.Field<int>("ItemId") == itemMasterId).FirstOrDefault();
                    dr["Sales_Details_Id"] = 0;
                    dr["Sales_Master_Id"] = _baseMasterId;
                    dr["ItemId"] = drItem["ItemId"];
                    dr["ItemTypeId"] = drItem["ItemTypeId"];
                    dr["ItemType"] = itemType;
                    dr["Product_Name"] = drItem["Title"];
                    dr["Rate"] = txtRate.Text;
                    dr["Quantity"] = txtQty.Text;
                    dr["DiscPer"] = txtDiscP.Text;
                    dr["Disc"] = txtDisc.Text;
                    dr["Total_Rate"] = txtAmount.Text;
                    dr["PQuantity"] = 0;
                    dr["Stock"] = drItem["CurrStock"];
                    _dtForAddRows.Rows.Add(dr);
                    ((frmSales)this._pform).calculateTotalAmount();
                    clearControl();
                }
            }

        }

        private void cboItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cboItemType.SelectedItem;
            DataRow row = vrow.Row;
            itemTypeMasterId = (int)row[0];
            itemType = (string)row[1];
            fillItemMaster(itemTypeMasterId);
        }

        private void cboItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView vrow = (DataRowView)cboItemName.SelectedItem;
            DataRow row = vrow.Row;
            itemMasterId = Convert.ToInt32(row[0]);
            DataRow drItem = dtForItemMaster.AsEnumerable().Where<DataRow>(o => o.Field<int>("ItemId") == itemMasterId).FirstOrDefault();
            if (_baseFormName.ToUpper() == "PURCHASE")
            {
                txtRate.Text = drItem["purRate"].ToString();
            }
            else
            {
                txtRate.Text = drItem["salesRate"].ToString();
            }
            txtCurrentStock.Text = drItem["CurrStock"].ToString();

        }

        private void txtDiscP_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            calculateAmount();
        }

        private void txtDisc_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDiscP_Validating(object sender, CancelEventArgs e)
        {
            calculateDiscAmount(true);
            calculateAmount();
        }

        private void txtDisc_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtDisc.Text) || Convert.ToString(txtDisc.Text) != "0")
            {
                calculateDiscAmount(false);
                calculateAmount();
            }
        }

        private void frmEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == System.Windows.Forms.Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}
