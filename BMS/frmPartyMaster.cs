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
    public partial class frmPartyMaster : Form
    {
        private DataTable dtPartyMaster = new DataTable();        
        public frmPartyMaster()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillData();          
            ClearControl();
        }
        private void ClearControl()
        {
            txtPartyName.Tag = 0;
            txtPartyName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPincode.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtemailid.Text = string.Empty;
            txtMobileno.Text = string.Empty;
            cboItemType.SelectedValue = 1;
        }       
        private void fillData()
        {
            try
            {
                dtPartyMaster = BAccess.UserBaccess.getRecordTable("SELECT PartyMst.PartyId, PartyMst.PartyName, PartyMst.Type, PartyMst.Address, PartyMst.City, PartyMst.PinCode, PartyMst.PhoneNumber, PartyMst.EmailId, PartyMst.Mobile FROM PartyMst ");
                dgvPartyMaster.DataSource = dtPartyMaster;
                dgvPartyMaster.Columns[0].Visible = false;                             
                dgvPartyMaster.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvPartyMaster.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPartyMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtPartyName.Tag = Convert.ToInt32(dgvPartyMaster["PartyId", e.RowIndex].Value);
                txtPartyName.Text = Convert.ToString(dgvPartyMaster["PartyName", e.RowIndex].Value);
                txtAddress.Text = Convert.ToString(dgvPartyMaster["Address", e.RowIndex].Value);
                txtCity.Text = Convert.ToString(dgvPartyMaster["City", e.RowIndex].Value);
                txtPincode.Text = Convert.ToString(dgvPartyMaster["PinCode", e.RowIndex].Value);
                txtPhoneNo.Text = Convert.ToString(dgvPartyMaster["PhoneNumber", e.RowIndex].Value);
                txtemailid.Text = Convert.ToString(dgvPartyMaster["EmailId", e.RowIndex].Value);
                txtMobileno.Text = Convert.ToString(dgvPartyMaster["Mobile", e.RowIndex].Value);
                cboItemType.Text= Convert.ToString(dgvPartyMaster["Type", e.RowIndex].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPartyName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter party name.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartyName.Focus();
                return;
            }
            try
            {
                bool InsertUpdateStatus = false;
                Entity.PartyMaster partyMaster = new Entity.PartyMaster();
                partyMaster.PartyId = Convert.ToInt32(txtPartyName.Tag);
                partyMaster.PartyName = txtPartyName.Text.Trim();
                partyMaster.Type = cboItemType.Text;
                partyMaster.Mobile = txtMobileno.Text;
                partyMaster.PhoneNumber = txtPhoneNo.Text;
                partyMaster.PinCode = txtPincode.Text;
                partyMaster.Address = txtAddress.Text;
                partyMaster.City = txtCity.Text;
                partyMaster.EmailId = txtemailid.Text;          
                if(partyMaster.PartyId >0)
                {
                    if(!DataUtil.currentUserInfo.IsEdit)
                    {
                        return;
                    }
                }
                InsertUpdateStatus = BAccess.BaPartyMaster.partyMasterInsertUpdate(partyMaster, DataUtil.currentUserInfo);
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
        }

        private void frmPartyMaster_Load(object sender, EventArgs e)
        {
            ClearControl();
        }
    }
}
