using BAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction
{
    public static class clsCommonFunc
    {
        public enum ColumnType
        {
            TextBox = 0,
            ComboBox = 1,
            CheckBox = 2
        }
        /// <summary>
        /// AddColumnIntoDataTable
        /// </summary>
        /// <param name="dtManin"><b>Column</b> Add into this dtMain</param>
        /// <param name="strFormName"><b>Name</b> strFormName</param>
        public static void AddColumnIntoDataTable(ref DataTable dtManin, ref System.Windows.Forms.DataGridView dgv, string strFormName)
        {
            DataTable dtForColumn = new DataTable();
            try
            {
                string strCommand = "SELECT * FROM CreateGrid "
                  + "WHERE(((CreateGrid.FormName) = '" + strFormName + "')) order by SeqNo";
                dtForColumn.Load(BaItemMaster.getRecordTable(strCommand).CreateDataReader());
                dgv.Columns.Clear();
                foreach (DataRow drColumn in dtForColumn.Rows)
                {
                    DataColumn dcNewColumn = new DataColumn();
                    System.Windows.Forms.DataGridViewColumn dcdgv = null;
                     ColumnType ctype = (ColumnType)Convert.ToInt16(Convert.ToString(drColumn["ColumnType"]));
                    switch (ctype)
                    {
                        case ColumnType.TextBox:
                           dcdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
                            break;
                        case ColumnType.ComboBox:
                            dcdgv = new System.Windows.Forms.DataGridViewComboBoxColumn();
                            break;
                        case ColumnType.CheckBox:
                            dcdgv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
                            break;
                    }
                    dcdgv.DataPropertyName = drColumn["ColumnName"].ToString();
                    dcdgv.Name = drColumn["ColumnName"].ToString();
                    dcdgv.HeaderText = drColumn["DisplayName"].ToString();
                    dcdgv.Visible = Convert.ToBoolean(drColumn["Visible"]);
                    dcdgv.ReadOnly = Convert.ToBoolean(drColumn["ReadOnly"]);
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(drColumn["Width"])))
                    {
                        if (Convert.ToString(drColumn["Width"]).Trim().Contains("%"))
                        {
                            dcdgv.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
                        }
                        else
                        {
                            dcdgv.Width = Convert.ToInt32(drColumn["Width"]);
                        }
                    }
                    dgv.Columns.Add(dcdgv);
                    //System.Windows.Forms.DataGridViewTextBoxColumn dcdgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
                    //dcNewColumn.DataType = Type.GetType("System.Int32");
                    //Type dcType = Type.GetType("System."+drColumn["DataType"].ToString());

                    dcNewColumn.DataType = Type.GetType("System." + drColumn["DataType"].ToString()); ;
                    dcNewColumn.ColumnName = drColumn["ColumnName"].ToString();
                    if (Convert.ToBoolean(drColumn["AutoNo"]))
                    {
                        dcNewColumn.AutoIncrement = true;
                        dcNewColumn.AutoIncrementStep = Convert.ToInt64(drColumn["AutoSpeed"]);
                        dcNewColumn.AutoIncrementSeed = Convert.ToInt64(drColumn["SpeedSeq"]);
                    }
                    else
                    {
                        dcNewColumn.DefaultValue = Convert.ToString(drColumn["DefualtValue"]);
                    }
                    if (!String.IsNullOrWhiteSpace(drColumn["Expression"].ToString()))
                    {
                        dcNewColumn.Expression = drColumn["Expression"].ToString();
                    }
                    dtManin.Columns.Add(dcNewColumn);
                }
                dgv.DataSource = dtManin;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
