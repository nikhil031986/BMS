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
    public partial class frYearMaster : Form
    {
        private DataTable dtYearMaster = new DataTable();
        public frYearMaster()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillData();
            ClearControl();
        }
        private void ClearControl()
        {
            txtRemarks.Tag = 0;
            txtRemarks.Text = string.Empty;
            dtpEndDate.Value = DateTime.Now.Date;
            dtpFromDate.Value = DateTime.Now.Date;
        }
        private void fillData()
        {
            try
            {
                dtYearMaster = BAccess.UserBaccess.getRecordTable("SELECT YearMaster.* FROM YearMaster");
                dgvYearMaster.DataSource = dtYearMaster;
                dgvYearMaster.Columns[0].Visible = false;
                dgvYearMaster.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvYearMaster.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvYearMaster.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvYearMaster.Columns[4].Visible = false;
                dgvYearMaster.Columns[5].Visible = false;
                dgvYearMaster.Columns[6].Visible = false;
                dgvYearMaster.Columns[7].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int reordsCount = BAccess.UserBaccess.getScalerValue("SELECT Count(1) AS Counts FROM YearMaster WHERE (((YearMaster.Start_Date)<=#" + dtpFromDate.Value.ToString("MM/dd/yyyy") + "#) AND ((YearMaster.End_Date)>=#" + dtpFromDate.Value.ToString("MM/dd/yyyy") + "#))");
            if (reordsCount > 0 && Convert.ToInt32(txtRemarks.Tag) <= 0)
            {
                MessageBox.Show("From date and to date already exists into the system.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpFromDate.Focus();
                return;
            }
            try
            {
                bool InsertUpdateStatus = false;
                Entity.YearMaster yearMaster = new Entity.YearMaster();
                yearMaster.Year_Id = Convert.ToInt32(txtRemarks.Tag);
                yearMaster.Start_Date = dtpFromDate.Value;
                yearMaster.End_Date = dtpEndDate.Value;
                yearMaster.Remarks = txtRemarks.Text;
                if (yearMaster.Year_Id > 0)
                {
                    if (!DataUtil.currentUserInfo.IsEdit)
                    {
                        return;
                    }
                }
                InsertUpdateStatus = BAccess.BaYearMaster.yearMasterInsertUpdate(yearMaster, DataUtil.currentUserInfo);
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

        private void dgvYearMaster_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtRemarks.Tag = Convert.ToInt32(dgvYearMaster["Year_Id", e.RowIndex].Value);
                dtpFromDate.Text = Convert.ToString(dgvYearMaster["Start_Date", e.RowIndex].Value);
                dtpEndDate.Text = Convert.ToString(dgvYearMaster["End_Date", e.RowIndex].Value);
                txtRemarks.Text = Convert.ToString(dgvYearMaster["Remarks", e.RowIndex].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
    }
}
