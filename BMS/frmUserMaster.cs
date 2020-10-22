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
    public partial class frmUserMaster : Form
    {
        private DataTable dtGetFromDataBase = new DataTable();
        public frmUserMaster()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillData();
            ClearControl();
        }
        private void fillData()
        {
            try
            {
                dtGetFromDataBase = BAccess.UserBaccess.getRecordTable("SELECT * FROM UserInfo");
                dgvUserDetails.DataSource = dtGetFromDataBase;
                dgvUserDetails.Columns[0].Visible = false;
                dgvUserDetails.Columns[11].Visible = false;
                dgvUserDetails.Columns[12].Visible = false;
                dgvUserDetails.Columns[13].Visible = false;
                dgvUserDetails.Columns[14].Visible = false;
                dgvUserDetails.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvUserDetails.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearControl()
        {
            txtUserName.Tag = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmailId.Text = string.Empty;
            cboSex.SelectedIndex = 0;
            chkAdmin.Checked = false;
            chkDeactive.Checked = false;
            chkDelete.Checked = false;
            ChkEdit.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        private void dgvUserDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                dgvUserDetails["Password", e.RowIndex].Tag = e.Value;
                e.Value = new String('*', e.Value.ToString().Length);
            }
        }

        private void dgvUserDetails_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToString(dgvUserDetails["Password", e.RowIndex].Tag) != string.Empty)
                {
                    txtUserName.Tag = Convert.ToInt32(dgvUserDetails["UserId", e.RowIndex].Value);
                    txtUserName.Text = Convert.ToString(dgvUserDetails["User_Name", e.RowIndex].Value);
                    txtPassword.Text = Convert.ToString(dgvUserDetails["Password", e.RowIndex].Tag);
                    txtAddress.Text = Convert.ToString(dgvUserDetails["Address", e.RowIndex].Value);
                    txtPhone.Text = Convert.ToString(dgvUserDetails["PhoneNo", e.RowIndex].Value);
                    txtEmailId.Text = Convert.ToString(dgvUserDetails["EmailId", e.RowIndex].Value);
                    cboSex.SelectedText = Convert.ToString(dgvUserDetails["Sex", e.RowIndex].Value);
                    chkAdmin.Checked = Convert.ToBoolean(dgvUserDetails["IsAdmin", e.RowIndex].Value);
                    ChkEdit.Checked = Convert.ToBoolean(dgvUserDetails["IsEdit", e.RowIndex].Value);
                    chkDelete.Checked = Convert.ToBoolean(dgvUserDetails["IsDelete", e.RowIndex].Value);
                    chkDeactive.Checked = Convert.ToBoolean(dgvUserDetails["IsDeactive", e.RowIndex].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strCommand = string.Empty;
            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter user name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter password.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPassword.Focus();
                return;
            }
            if (ChkEdit.Checked == false && chkDelete.Checked == false && chkAdmin.Checked == false)
            {
                MessageBox.Show("Select any one of the wrights.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChkEdit.Focus();
                return;
            }
            try
            {
                bool InsertUpdateStatus = false;
                Entity.UserInfo userInfo = new Entity.UserInfo();
                userInfo.UserId = Convert.ToInt32(txtUserName.Tag);
                userInfo.User_Name = txtUserName.Text.Trim();
                userInfo.Password = txtPassword.Text.Trim();
                userInfo.Address = txtAddress.Text.Trim();
                userInfo.PhoneNo = txtPhone.Text.Trim();
                userInfo.EmailId = txtEmailId.Text.Trim();
                userInfo.Sex = cboSex.Text;
                userInfo.IsAdmin = chkAdmin.Checked;
                userInfo.IsEdit = ChkEdit.Checked;
                userInfo.IsDelete = chkDelete.Checked;
                userInfo.IsDeactive = chkDeactive.Checked;
                InsertUpdateStatus = BAccess.UserBaccess.userInsertUpdate(userInfo, DataUtil.currentUserInfo);
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
    }
}
