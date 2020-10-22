using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaYearMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return UserDataAccess.getRecordTable(commandText);
        }
        public static Entity.YearMaster getYear(int yearMasterId)
        {
            Entity.YearMaster yearMaster = new Entity.YearMaster();
            DataTable dtForItemMaster = DaItemMaster.getRecordTable("SELECT * FROM YearMaster WHERE YearMaster.[Year_Id]=" + yearMasterId.ToString());
            DataRow firstRow = dtForItemMaster.AsEnumerable().FirstOrDefault();
            yearMaster.Year_Id = Convert.ToInt32(firstRow["Year_Id"]);
            yearMaster.Start_Date = Convert.ToDateTime(firstRow["Start_Date"]);
            yearMaster.End_Date = Convert.ToDateTime(firstRow["End_Date"]);
            yearMaster.Remarks = Convert.ToString(firstRow["Remarks"]);
            return yearMaster;
        }
        public static bool yearMasterInsertUpdate(Entity.YearMaster YearMaster, Entity.UserInfo currentUser)
        {
            bool returnValue = false;
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = UserDataAccess.DataBaseConnection();
                cmd.CommandType = CommandType.Text;
                if (YearMaster.Year_Id == 0)
                {
                    cmd.CommandText = "INSERT INTO [YearMaster] ([Start_Date],[End_Date],[Remarks],Ent_UserId,Ent_date,Update_UserId,Update_Date) VALUES(@Start_Date,@End_Date,@Remarks,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                }
                else
                {
                    cmd.CommandText = "UPDATE [YearMaster] SET YearMaster.Start_Date = @Start_Date, YearMaster.[End_Date] = @End_Date,YearMaster.Remarks=@Remarks,YearMaster.Update_UserId = @UpUserId, YearMaster.Update_Date = @UpDateTime WHERE(((YearMaster.Year_Id) = @Year_Id))";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Start_Date", YearMaster.Start_Date);
                cmd.Parameters.AddWithValue("@End_Date", YearMaster.End_Date);
                cmd.Parameters.AddWithValue("@Remarks", YearMaster.Remarks);
                cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                if (YearMaster.Year_Id == 0)
                {
                    cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Year_Id", YearMaster.Year_Id);
                }
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                returnValue = true;
            }
            return returnValue;
        }
    }
}
