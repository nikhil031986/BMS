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
    public partial class frmItemTypeMst : Form
    {
        private DataTable dtItemTypeMaster = new DataTable();
        public frmItemTypeMst()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillData();
            ClearControl();
        }
        private void ClearControl()
        {
            txtItemType.Tag = 0;
            txtItemType.Text = string.Empty;
            txtDesc.Text = string.Empty;
        }
        private void fillData()
        {
            try
            {
                dtItemTypeMaster = BAccess.UserBaccess.getRecordTable("SELECT * FROM ItemTypeMst");
                dgvItemTypeMaster.DataSource = dtItemTypeMaster;
                dgvItemTypeMaster.Columns[0].Visible = false;
                dgvItemTypeMaster.Columns[3].Visible = false;
                dgvItemTypeMaster.Columns[4].Visible = false;
                dgvItemTypeMaster.Columns[5].Visible = false;
                dgvItemTypeMaster.Columns[6].Visible = false;
                dgvItemTypeMaster.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvItemTypeMaster.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvItemTypeMaster.Columns[2].HeaderText = "Description";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItemTypeMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtItemType.Tag = Convert.ToInt32(dgvItemTypeMaster["ItemTypeMstId", e.RowIndex].Value);
                txtItemType.Text = Convert.ToString(dgvItemTypeMaster["ItemType", e.RowIndex].Value);
                txtDesc.Text = Convert.ToString(dgvItemTypeMaster["Desc", e.RowIndex].Value);
                if(!DataUtil.currentUserInfo.IsEdit)
                {
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtItemType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter item type.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtItemType.Focus();
                return;
            }
            try
            {
                bool InsertUpdateStatus = false;
                Entity.ItemTypeMsater itemTypeMaster = new Entity.ItemTypeMsater();
                itemTypeMaster.ItemType = txtItemType.Text.Trim();
                itemTypeMaster.Desc = txtDesc.Text.Trim();
                itemTypeMaster.ItemTypeMstId = Convert.ToInt32(txtItemType.Tag);                
                InsertUpdateStatus = BAccess.BaItemTypeMast.itemTypeInsertUpdate(itemTypeMaster, DataUtil.currentUserInfo);
                if (InsertUpdateStatus)
                {
                    MessageBox.Show("Data saved successfuly...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillData();
                    ClearControl();
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
            btnSave.Enabled = true;
        }

        private void frmItemTypeMst_Load(object sender, EventArgs e)
        {
            ClearControl();
        }
    }
}
