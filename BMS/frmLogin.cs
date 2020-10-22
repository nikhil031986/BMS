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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Icon = BMS.Properties.Resources.library;
            fillYear();
        }
        private void fillYear()
        {
            DataTable dtYear = BAccess.UserBaccess.getRecordTable("SELECT YearMaster.Year_Id, YearMaster.Remarks FROM YearMaster ORDER BY YearMaster.Year_Id DESC");
            cboYear.DataSource = dtYear;
            cboYear.DisplayMember = "Remarks";
            cboYear.ValueMember = "Year_Id";
            cboYear.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Trim() == string.Empty)
            {
                error.SetError(txtUserID, "Enter User Name.");
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                error.SetError(txtPassword, "Enter Password.");
                return;
            }
            try
            {
                DataUtil.currentUserInfo = BAccess.UserBaccess.login(txtUserID.Text.Trim(), txtPassword.Text.Trim());
                DataUtil.currentUserInfo.CurrentYearId = Convert.ToInt32(cboYear.SelectedValue);
                if (DataUtil.currentUserInfo.UserId > 0)
                {
                    if (Convert.ToBoolean(DataUtil.currentUserInfo.IsDeactive) == false)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Please contact your administrator.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("The userid or password is incorrect.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {
            error.SetError(txtUserID, "");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            error.SetError(txtUserID, "");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
            base.OnKeyDown(e);
        }
    }
}
