using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace DataAccess
{
    public static class UserDataAccess
    {
        public static bool DataBaseBackUp(string location)
        {
            bool isBackUp = false;
            try
            {
                if (Convert.ToString(location) != string.Empty)
                {
                    string PathtobackUp = location;
                    string dbFileName = "BSM.mdb";
                    string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
                    string backTimeStamp = Path.GetFileNameWithoutExtension(dbFileName) + "_" + DateTime.Now.ToString("yyyy-MM-dd") + Path.GetExtension(dbFileName);
                    string destFileName = backTimeStamp + dbFileName;
                    destFileName = Path.Combine(PathtobackUp, destFileName);
                    File.Copy(CurrentDatabasePath, destFileName, true);
                    isBackUp = true;
                }
            }
            catch {}
            return isBackUp;
        }
        public static OleDbConnection DataBaseConnection()
        {
            OleDbConnection dbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\BSM.mdb");
            return dbConnection;
        }
        public static DataTable getRecordTable(string commandText)
        {
            DataTable retDataTable = new DataTable();
            try
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = commandText;
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    adp.Fill(retDataTable);
                }
            }
            catch(Exception ex){ throw ex; }
            return retDataTable;
        }

        public static int getScalerValue (string commandString)
        {
            int result = 0;
            OleDbConnection conn = new OleDbConnection(UserDataAccess.DataBaseConnection().ConnectionString);
            try
            {
                conn.Open();
                var cmd = new OleDbCommand(commandString, conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        reader.Read();
                        result = reader.GetInt32(0);
                    }
                }
            }
            catch
            {
                return 0;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public static bool userInsertUpdate(Entity.UserInfo userDetails, Entity.UserInfo currentUser)
        {
            bool returnValue = false;
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = UserDataAccess.DataBaseConnection();
                cmd.CommandType = CommandType.Text;
                if (userDetails.UserId == 0)
                {
                    cmd.CommandText = "INSERT INTO [UserInfo] ([User_Name],[Password],Address,Sex,EmailId,PhoneNo,IsAdmin,IsEdit,IsDelete,IsDeactive,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES(@userName,@password,@Address,@Sex,@EmailId,@PhoneNo,@IsAdmin,@IsEdit,@IsDelete,@IsDeactive,@EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                }
                else
                {                    
                    cmd.CommandText = "UPDATE UserInfo SET UserInfo.User_Name = @userName, UserInfo.[Password] = @password, UserInfo.Address = @Address, UserInfo.Sex = @Sex, UserInfo.EmailId = @EmailId, UserInfo.PhoneNo =  @PhoneNo, UserInfo.IsAdmin = @IsAdmin, UserInfo.IsEdit = @IsEdit, UserInfo.IsDelete = @IsDelete, UserInfo.IsDeactive = @IsDeactive, UserInfo.UpUserId = @UpUserId, UserInfo.UpDateTime = @UpDateTime WHERE(((UserInfo.UserId) = @UserId))";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@userName", userDetails.User_Name);
                cmd.Parameters.AddWithValue("@password", userDetails.Password);
                cmd.Parameters.AddWithValue("@Address", userDetails.Address);
                cmd.Parameters.AddWithValue("@Sex", userDetails.Sex);
                cmd.Parameters.AddWithValue("@EmailId", userDetails.EmailId);
                cmd.Parameters.AddWithValue("@PhoneNo", userDetails.PhoneNo);
                cmd.Parameters.AddWithValue("@IsAdmin", userDetails.IsAdmin);
                cmd.Parameters.AddWithValue("@IsEdit", userDetails.IsEdit);
                cmd.Parameters.AddWithValue("@IsDelete", userDetails.IsDelete);
                cmd.Parameters.AddWithValue("@IsDeactive", userDetails.IsDeactive);
                cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                if (userDetails.UserId == 0)
                {
                    cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@UserId", userDetails.UserId);
                }
                if(cmd.Connection.State == ConnectionState.Open)
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
        public static Entity.UserInfo login(string userName, string passsword)
        {
            Entity.UserInfo returnUserLogin = new Entity.UserInfo();
            try
            {

                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = UserDataAccess.DataBaseConnection();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM [UserInfo] WHERE User_Name=@userName and Password=@password";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@userName", userName);
                    cmd.Parameters.AddWithValue("@password", passsword);
                    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
                    DataTable returnDataTable = new DataTable();
                    adp.Fill(returnDataTable);
                   
                    if (returnDataTable.Rows.Count > 0)
                    {
                        returnUserLogin = clsComModile.ToObject<Entity.UserInfo>(returnDataTable.Rows[0]);
                    }
                }
                //returnUserLogin.CurrentYearId = getScalerValue("SELECT YearMaster.Year_Id FROM YearMaster WHERE (((YearMaster.Start_Date)<=#"+DateTime.Now.Date.ToString("MM/dd/yyyy")+"#) AND ((YearMaster.End_Date)>=#"+DateTime.Now.Date.ToString("MM/dd/yyyy")+"#))");
            }
            catch { }
            return returnUserLogin;
        }
    }
}
