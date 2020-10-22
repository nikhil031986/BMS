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
    public partial class frmsearch : Form
    {
        private string searchColumnName = string.Empty;
        private string command = string.Empty;
        private DataTable dtSerchControl = new DataTable();
        private string dataValue = string.Empty;
        private string returnColumn = string.Empty;
        private string _returnCaption = string.Empty;
        private DataView dvForSearch;
        public string returnCaption
        {
            get { return _returnCaption; }
            set { _returnCaption = value; }
        }
        public string returnValue
        {
            get { return dataValue; }
            set { dataValue = value; }
        }
        public frmsearch()
        {
            InitializeComponent();
        }
        private void FillData()
        {
            try
            {
                dtSerchControl = BAccess.BaItemMaster.getRecordTable(command);
                dtSerchControl.TableName = "Search";
                dvForSearch = dtSerchControl.DefaultView;
                dgvSearchGrid.DataSource = dvForSearch;
                foreach(DataGridViewColumn dgcolumn in dgvSearchGrid.Columns)
                {
                    if(dgcolumn.HeaderText.ToUpper().Contains("ID"))
                    {
                        dgcolumn.Visible = false;
                    }
                    else
                    {
                        dgcolumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    }
                }
                dgvSearchGrid.Columns[searchColumnName].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public frmsearch(string SearchColumnName, string CommandName, string returnColumnValue)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            try
            {
                searchColumnName = SearchColumnName;
                command = CommandName;
                returnColumn = returnColumnValue;
                FillData();
                lblSerchControl.Text = searchColumnName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() != string.Empty)
                {
                    dvForSearch.RowFilter = searchColumnName + " Like '%" + txtSearch.Text.Trim() + "%'";
                }
                else
                {
                    dvForSearch.RowFilter = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                dgvSearchGrid.Focus();
            }
        }
        private void dgvSearchGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dataValue = Convert.ToString(dgvSearchGrid[returnColumn, dgvSearchGrid.CurrentCell.RowIndex].Value);
                _returnCaption = Convert.ToString(dgvSearchGrid[searchColumnName, dgvSearchGrid.CurrentCell.RowIndex].Value);
                this.Close();
            }
        }
    }
}
