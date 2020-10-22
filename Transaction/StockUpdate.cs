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
    public partial class StockUpdate : Form
    {
        private DataTable dtStockMaster = new DataTable();
        private DataView dvSearch;
        private int stockMasterId = 0;
        private Entity.UserInfo currentUser;
        public Entity.UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }
        public StockUpdate()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillProductType();
            CreateColumnForStockData();
            fillStockMaster();
            fillColorBaseOnStock();
        }
        private void fillColorBaseOnStock()
        {
            foreach (DataGridViewRow item in dgvStockMasterDetails.Rows)
            {
                decimal purchaseStock = Convert.ToDecimal(item.Cells["Purchase_Stock"].Value);
                decimal salesstock = Convert.ToDecimal(item.Cells["Sales_Stock"].Value);
                decimal totalStock = Convert.ToDecimal(item.Cells["Total_Stock"].Value);
                if ((purchaseStock - 1) <= salesstock)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
                if ((purchaseStock - salesstock) != totalStock)
                {
                    item.DefaultCellStyle.BackColor = Color.Red;
                }
            }
            dgvStockMasterDetails.Refresh();
        }
        private void fillStockMaster()
        {
            try
            {
                dvSearch = new DataView();
                string command = "SELECT StockMst.StockMstId, StockMst.ItemId, ItemTypeMst.ItemTypeMstId, StockMst.PurStock AS Purchase_Stock, "
                               + "StockMst.SalesStock AS Sales_Stock, StockMst.CurrStock AS Total_Stock, ItemTypeMst.ItemType,ItemMst.Title AS Product_Name "
                               + "FROM(ItemMst INNER JOIN StockMst ON ItemMst.ItemId = StockMst.ItemId) INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId";
                dtStockMaster.Load(BAccess.BaItemMaster.getRecordTable(command).CreateDataReader());
                dvSearch = dtStockMaster.AsDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateColumnForStockData()
        {
            try
            {
                dtStockMaster = new DataTable();
                dtStockMaster.TableName = "Search";
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
                dcPurcahse_Details_Id.ColumnName = "StockMstId";
                DataColumn dcProduct_Master_Id = new DataColumn();
                dcProduct_Master_Id.AllowDBNull = true;
                dcProduct_Master_Id.DataType = typeof(int);
                dcProduct_Master_Id.DefaultValue = 0;
                dcProduct_Master_Id.ColumnName = "ItemId";
                DataColumn dcProduct_Type_Id = new DataColumn();
                dcProduct_Type_Id.AllowDBNull = true;
                dcProduct_Type_Id.DataType = typeof(int);
                dcProduct_Type_Id.DefaultValue = 0;
                dcProduct_Type_Id.ColumnName = "ItemTypeMstId";
                DataColumn dcRate = new DataColumn();
                dcRate.AllowDBNull = true;
                dcRate.DataType = typeof(decimal);
                dcRate.DefaultValue = decimal.Zero;
                dcRate.ColumnName = "Purchase_Stock";
                DataColumn dcQuantity = new DataColumn();
                dcQuantity.AllowDBNull = true;
                dcQuantity.DataType = typeof(decimal);
                dcQuantity.DefaultValue = decimal.Zero;
                dcQuantity.ColumnName = "Sales_Stock";
                DataColumn dcTotal_Rate = new DataColumn();
                dcTotal_Rate.AllowDBNull = true;
                dcTotal_Rate.DataType = typeof(decimal);
                dcTotal_Rate.DefaultValue = decimal.Zero;
                dcTotal_Rate.ColumnName = "Total_Stock";
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
                dtStockMaster.Columns.AddRange(new DataColumn[] { dcAutoNo, dcPurcahse_Details_Id, dcProduct_Master_Id, dcProduct_Type_Id, dcProduct_Type, dcProduct_Name, dcRate, dcQuantity, dcTotal_Rate });
                dvSearch = dtStockMaster.AsDataView();
                dgvStockMasterDetails.DataSource = dvSearch;
                foreach (DataGridViewColumn dgColumns in dgvStockMasterDetails.Columns)
                {
                    if (dgColumns.HeaderText.ToUpper().Contains("ID"))
                    {
                        dgColumns.Visible = false;
                    }
                }
                dgvStockMasterDetails.Columns["AutoNo"].Width = 60;
                dgvStockMasterDetails.Columns["Product_Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvStockMasterDetails.Columns["ItemType"].Width = 70;
                dgvStockMasterDetails.Columns["Purchase_Stock"].Width = 80;
                dgvStockMasterDetails.Columns["Sales_Stock"].Width = 80;
                dgvStockMasterDetails.Columns["Total_Stock"].Width = 80;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fillProductType()
        {
            try
            {
                DataTable dtProductType = BAccess.BaItemTypeMast.getRecordTable("SELECT ItemTypeMstId,ItemType FROM ItemTypeMst");
                cboProductType.DataSource = dtProductType;
                cboProductType.DisplayMember = "ItemType";
                cboProductType.ValueMember = "ItemTypeMstId";
                cboSearch.SelectedIndex = 0;
                cboProductType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StockUpdate_Load(object sender, EventArgs e)
        {
            ClearControl();
        }
        private void ClearControl()
        {
            try
            {
                stockMasterId = 0;
                cboProductType.SelectedIndex = -1;
                txtProductName.Text = string.Empty;
                txtProductName.Tag = string.Empty;
                txtPurchaseStock.Text = "0";
                txtSalesStock.Text = "0";
                txtTotalStock.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvStockMasterDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ClearControl();
                stockMasterId = Convert.ToInt32(dgvStockMasterDetails["StockMstId", e.RowIndex].Value);
                cboProductType.Text = Convert.ToString(dgvStockMasterDetails["ItemType", e.RowIndex].Value);
                txtProductName.Text = Convert.ToString(dgvStockMasterDetails["Product_Name", e.RowIndex].Value);
                txtProductName.Tag = Convert.ToString(dgvStockMasterDetails["ItemId", e.RowIndex].Value);
                txtPurchaseStock.Text = Convert.ToString(dgvStockMasterDetails["Purchase_Stock", e.RowIndex].Value);
                txtSalesStock.Text = Convert.ToString(dgvStockMasterDetails["Sales_Stock", e.RowIndex].Value);
                txtTotalStock.Text = Convert.ToString(dgvStockMasterDetails["Total_Stock", e.RowIndex].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(!currentUser.IsEdit)
                {
                    return;
                }
                decimal sumStock = Convert.ToDecimal(txtTotalStock.Text.Trim());
                if (sumStock < 0)
                {
                    MessageBox.Show("Your stock goose in minas.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    return;

                }
                if (stockMasterId > 0)
                {
                    if (BAccess.BaItemMaster.updateItemWiseStock(stockMasterId, Convert.ToInt32(txtPurchaseStock.Text.Trim()), Convert.ToInt32(txtSalesStock.Text),Convert.ToInt32(txtTotalStock.Text.Trim()), CurrentUser) == true)
                    {
                        MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CreateColumnForStockData();
                        fillStockMaster();
                        ClearControl();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        private void totalStock()
        {
            if (txtPurchaseStock.Text.Trim() == string.Empty)
            {
                txtPurchaseStock.Text = "0";
            }
            if (txtSalesStock.Text.Trim() == string.Empty)
            {
                txtSalesStock.Text = "0";
            }
            txtTotalStock.Text = (Convert.ToDecimal(txtPurchaseStock.Text.Trim()) - Convert.ToDecimal(txtSalesStock.Text.Trim())).ToString();
        }
        private void txtPurchaseStock_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPurchaseStock_TextChanged(object sender, EventArgs e)
        {
            totalStock();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() != string.Empty)
                {
                    dvSearch.RowFilter = cboSearch.Text.Trim() + " Like '%" + txtSearch.Text.Trim() + "%'";
                    dgvStockMasterDetails.DataSource = dvSearch;
                }
                else
                {
                    dvSearch.RowFilter = "";
                    dgvStockMasterDetails.DataSource = dvSearch;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStockMasterDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            decimal purchaseStock = Convert.ToDecimal(dgvStockMasterDetails["Purchase_Stock",e.RowIndex].Value);
            decimal salesstock = Convert.ToDecimal(dgvStockMasterDetails["Sales_Stock",e.RowIndex].Value);
            decimal totalStock = Convert.ToDecimal(dgvStockMasterDetails["Total_Stock",e.RowIndex].Value);
            if ((purchaseStock - 1) <= salesstock)
            {
                dgvStockMasterDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else if ((purchaseStock - salesstock) != totalStock)
            {
                dgvStockMasterDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            else
            {
                dgvStockMasterDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
