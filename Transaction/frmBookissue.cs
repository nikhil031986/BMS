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
    public partial class frmBookissue : Form
    {   
        private DataTable dtForSearch = new DataTable();
        private DataView dvSearch;
        private int bookIssueId = 0;
        private Entity.UserInfo currentUser;
        private bool isEditCurrentBook = false;
        public Entity.UserInfo CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        public bool IsEditCurrentBook
        {
            get
            {
                return isEditCurrentBook;
            }

            set
            {
                isEditCurrentBook = value;
                if(isEditCurrentBook)
                {
                    btnEdit.Enabled = false;
                }
                else
                {
                    if (currentUser.IsEdit)
                    {
                        btnEdit.Enabled = true;
                    }
                    else
                    {
                        btnEdit.Enabled = false;
                    }
                }
            }
        }

        public frmBookissue()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            fillDataIntoGrid();
        }
      
        private void fillDataIntoGrid()
        {
            string command = "SELECT BookIssue.BookIssueId, BookIssue.IssueNo, BookIssue.IssueDate, BookIssue.ReturnDate, BookIssue.PartyName, BookIssue.MobileNo, BookIssue.Emailid, BookIssue.IsReturn FROM BookIssue";
            dtForSearch = BAccess.BaItemMaster.getRecordTable(command);
            dtForSearch.TableName = "ItemMaster";
            dvSearch = dtForSearch.AsDataView();
            cboColumnName.Items.Clear();
            foreach (DataColumn dtColumn in dtForSearch.Columns)
            {
                if (!dtColumn.ColumnName.ToUpper().Contains("ID") &&
                    !dtColumn.ColumnName.ToUpper().Contains("DATE") &&
                    !dtColumn.ColumnName.ToUpper().Contains("ISRETURN") &&
                    !dtColumn.ColumnName.ToUpper().Contains("NO"))
                {
                    cboColumnName.Items.Add(dtColumn.ColumnName.ToString());
                }
            }
            dgvSearch.DataSource = dvSearch;
            dgvSearch.Columns[0].Visible = false;          
            dgvSearch.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            bookIssueId = Convert.ToInt32(dgvSearch["BookIssueId", e.RowIndex].Value);           
            IsEditCurrentBook = Convert.ToBoolean(dgvSearch["IsReturn", e.RowIndex].Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookIssuefrm itemMaster = new BookIssuefrm();
            itemMaster.CurrentUser = currentUser;
            //itemMaster.MdiParent = this.MdiParent;
            DialogResult result = itemMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                fillDataIntoGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BookIssuefrm itemMaster = new BookIssuefrm(bookIssueId);
            itemMaster.CurrentUser = currentUser;
            //itemMaster.MdiParent = this.MdiParent;
            DialogResult result = itemMaster.ShowDialog();
            if (result == DialogResult.OK)
            {
                fillDataIntoGrid();
            }
        }
    }
}
