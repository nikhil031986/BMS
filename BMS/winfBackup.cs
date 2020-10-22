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
    public partial class winfBackup : Form
    {
        public winfBackup()
        {
            InitializeComponent();
        }

        private void btnSelectLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtLocation.Text = fbd.SelectedPath.ToString();

            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            if(BAccess.UserBaccess.DataBaseBackUp(txtLocation.Text.Trim()))
            {
                MessageBox.Show("successful Backup! ");
                this.Close();
            }
        }
    }
}
