using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmItemMaster : Form
    {
        private int ItemMasterId = 0;
        private Entity.ItemMaster itemMaster;
        public frmItemMaster()
        {
            InitializeComponent();
            fillItemType();
            itemMaster = new Entity.ItemMaster();
        }

        public frmItemMaster(int itemMasterId)
        {
            InitializeComponent();
            txtpurqty.Enabled = false;
            txtsalesquty.Enabled = false;
            txttotalquty.Enabled = false;
            //txtclosingquty.Enabled = false;      
            ItemMasterId = itemMasterId;
            fillItemType();
            fillData();
        }
        private void fillItemType()
        {
            DataTable dtItemType = BAccess.BaItemMaster.getRecordTable("SELECT ItemTypeMstId,ItemType FROM ItemTypeMst");
            cboItemtype.DataSource = dtItemType;
            cboItemtype.DisplayMember = "ItemType";
            cboItemtype.ValueMember = "ItemTypeMstId";
            cboItemtype.SelectedIndex = 0;
        }
        private void fillData()
        {
            itemMaster = new Entity.ItemMaster();
            itemMaster = BAccess.BaItemMaster.getItemMaster(ItemMasterId);
            cboItemtype.SelectedValue = itemMaster.ItemTypeId;
            txttitle.Text = itemMaster.Title;
            txtDescription.Text = itemMaster.Description;
            txtrateamount.Text = itemMaster.Rate.ToString();
            txtpublyear.Text = itemMaster.PubYear;
            txtpubplace.Text = itemMaster.PubPlace;
            txtpublisher.Text = itemMaster.Publisher;
            txtvolume.Text = itemMaster.Volume;
            txtedition.Text = itemMaster.Edition;
            txtLangage.Text = itemMaster.Language;
            txtISBN.Text = itemMaster.ISBN;
            txtautor.Text = itemMaster.Author;
            txtPurrate.Text = itemMaster.PurRate.ToString();
            txtSalesrate.Text = itemMaster.SalesRate.ToString();
            txtopnstock.Text = itemMaster.OpnignQty.ToString();
            txtdisrate.Text = itemMaster.Rate_Dic_per.ToString();
            txtrateamount.Text = itemMaster.Rate_Dic_Amount.ToString();
            txtclosingquty.Text = itemMaster.Closingqty.ToString();
            DataTable dtForItemMaster = BAccess.BaItemMaster.getRecordTable("SELECT * FROM StockMst WHERE ItemId =" + itemMaster.ItemId.ToString());
            txtpurqty.Text = dtForItemMaster.AsEnumerable().FirstOrDefault().Field<int>("PurStock").ToString();
            txtsalesquty.Text = dtForItemMaster.AsEnumerable().FirstOrDefault().Field<int>("SalesStock").ToString();
            txttotalquty.Text = dtForItemMaster.AsEnumerable().FirstOrDefault().Field<int>("CurrStock").ToString();
            txtclosingquty.Text = dtForItemMaster.AsEnumerable().FirstOrDefault().Field<int>("CurrStock").ToString();
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool recordInsertUpdate = true;
            if (txttitle.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter book titel.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txttitle.Focus();
                recordInsertUpdate = false;
                //return;
            }
            if (txtDescription.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter description.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                recordInsertUpdate = false;
                // return;
            }
            if (txtSalesrate.Text.Trim() == "0" || txtPurrate.Text.Trim() == "0" || string.IsNullOrWhiteSpace(txtSalesrate.Text) || string.IsNullOrWhiteSpace(txtPurrate.Text))
            {
                if (txtSalesrate.Text.Trim() == "0" || string.IsNullOrWhiteSpace(txtSalesrate.Text))
                {
                    MessageBox.Show("Enter sales rate.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSalesrate.Focus();
                    recordInsertUpdate = false;
                    // return;
                }
                if (txtPurrate.Text.Trim() == "0" && string.IsNullOrWhiteSpace(txtPurrate.Text))
                {
                    MessageBox.Show("Enter Purchase rate.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPurrate.Focus();
                    recordInsertUpdate = false;
                    //return;
                }
                //if(txtrateamount.Text.Trim() == "0")
                //{
                //    MessageBox.Show("Enter rate amount.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtrateamount.Focus();
                //    return;
                //}
            }
            if (recordInsertUpdate)
            {
                try
                {
                    bool InsertUpdateStatus = false;
                    itemMaster.ItemTypeId = Convert.ToInt32(cboItemtype.SelectedValue);
                    itemMaster.Title = txttitle.Text.Trim();
                    itemMaster.Description = txtDescription.Text.Trim();
                    itemMaster.Rate = Convert.ToInt32(txtrateamount.Text);
                    itemMaster.PubYear = txtpublyear.Text;
                    itemMaster.PubPlace = txtpubplace.Text;
                    itemMaster.Publisher = txtpublisher.Text;
                    itemMaster.Volume = txtvolume.Text;
                    itemMaster.Edition = txtedition.Text;
                    itemMaster.Language = txtLangage.Text;
                    itemMaster.ISBN = txtISBN.Text;
                    itemMaster.Author = txtautor.Text;
                    itemMaster.PurRate = Convert.ToDecimal(txtPurrate.Text);
                    itemMaster.SalesRate = Convert.ToDecimal(txtSalesrate.Text);
                    itemMaster.OpnignQty = Convert.ToInt32(txtopnstock.Text);
                    itemMaster.Rate_Dic_per = Convert.ToInt32(txtdisrate.Text);
                    itemMaster.Rate_Dic_Amount = Convert.ToDecimal(txtrateamount.Text);
                    itemMaster.Closingqty = Convert.ToInt32(txtclosingquty.Text.Trim());
                    InsertUpdateStatus = BAccess.BaItemMaster.itemMasterInsertUpdate(itemMaster, DataUtil.currentUserInfo);
                    if (InsertUpdateStatus)
                    {
                        MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSalesrate_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text) || Convert.ToString(((TextBox)sender).Text) == "0")
            {
                errProvider.SetError(((TextBox)sender), "Plese insert sales rate.");
                e.Cancel = true;
            }
            else
            {
                errProvider.SetError(((TextBox)sender), "");
            }
        }
    }
}
