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
    public partial class frmItemMasterDetail : Form
    {
        private DataTable dtForSearch = new DataTable();
        private DataView dvSearch;
        private int itemMasterId = 0;
        public frmItemMasterDetail()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillDataIntoGrid();
            if(!DataUtil.currentUserInfo.IsEdit)
            {
                btnEdit.Enabled = false;
            }
        }
        private void fillDataIntoGrid()
        {
            string command = "SELECT ItemMst.[ItemId], ItemTypeMst.[ItemType], ItemMst.[Title], ItemMst.[Description], ItemMst.[Rate], ItemMst.PubYear, ItemMst.PubPlace, ItemMst.[volume], ItemMst.[Edition], ItemMst.[Language], ItemMst.[ISBN], ItemMst.[Author] FROM ItemMst INNER JOIN ItemTypeMst ON ItemMst.ItemTypeId = ItemTypeMst.ItemTypeMstId";
            dtForSearch = BAccess.BaItemMaster.getRecordTable(command);
            dtForSearch.TableName = "ItemMaster";
            dvSearch = dtForSearch.AsDataView();
            cboColumnName.Items.Clear();
            foreach(DataColumn dtColumn in dtForSearch.Columns)
            {
                if(!dtColumn.ColumnName.ToUpper().Contains("ID"))
                {
                    cboColumnName.Items.Add(dtColumn.ColumnName.ToString());
                }
            }
            dgvSearch.DataSource = dvSearch;
            dgvSearch.Columns[0].Visible = false;
            dgvSearch.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSearch.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cboColumnName.SelectedIndex = 0;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtsearch.Text.Trim() != string.Empty)
                {
                    dvSearch.RowFilter = cboColumnName.Text.Trim() + " Like '%" + txtsearch.Text.Trim() + "%'";
                    dgvSearch.DataSource = dvSearch;
                }
                else
                {
                    dvSearch.RowFilter = "";
                    dgvSearch.DataSource = dvSearch;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSearch_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            itemMasterId = Convert.ToInt32(dgvSearch["ItemId", e.RowIndex].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmItemMaster itemMaster = new frmItemMaster();
            //itemMaster.MdiParent = this.MdiParent;
            DialogResult result=itemMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                fillDataIntoGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmItemMaster itemMaster = new frmItemMaster(itemMasterId);
            //itemMaster.MdiParent = this.MdiParent;
            DialogResult result = itemMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                fillDataIntoGrid();
            }
        }
    }
}
