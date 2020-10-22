using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DaPartyMaster
    {
        public static DataTable getRecordTable(string commandText)
        {
            return UserDataAccess.getRecordTable(commandText);
        }
        public static bool partyMasterInsertUpdate(Entity.PartyMaster partyMaster, Entity.UserInfo currentUser)
        {
            bool returnValue = false;
            using (OleDbCommand cmd = new OleDbCommand())
            {
                cmd.Connection = UserDataAccess.DataBaseConnection();
                cmd.CommandType = CommandType.Text;
                if (partyMaster.PartyId == 0)
                {
                    cmd.CommandText = "INSERT INTO [PartyMst] ([Type],[PartyName],Address,City,PinCode,[PhoneNumber],[EmailId],Mobile,EntUserId,EntDateTime,UpUserId,UpDateTime) VALUES(@Type, PartyName, @Address, @City, @PinCode,@PhoneNumber,@EmailId, @Mobile, @EntUserId,@EntDateTime,@UpUserId,@UpDateTime)";
                }
                else
                {
                    cmd.CommandText = "UPDATE PartyMst SET PartyMst.Type = @Type, PartyMst.PartyName = @PartyName,PartyMst.Address=@Address,PartyMst.City=@City,PartyMst.PinCode=@PinCode,PartyMst.PhoneNumber=@PhoneNumber,PartyMst.EmailId=@EmailId,PartyMst.Mobile=@Mobile,PartyMst.UpUserId = @UpUserId, PartyMst.UpDateTime = @UpDateTime WHERE(((PartyMst.PartyId) = @PartyId))";
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", partyMaster.Type);
                cmd.Parameters.AddWithValue("@PartyName", partyMaster.PartyName);
                cmd.Parameters.AddWithValue("@Address", partyMaster.Address);
                cmd.Parameters.AddWithValue("@City", partyMaster.City);
                cmd.Parameters.AddWithValue("@PinCode", partyMaster.PinCode);
                cmd.Parameters.AddWithValue("@PhoneNumber", partyMaster.PhoneNumber);
                cmd.Parameters.AddWithValue("@EmailId", partyMaster.EmailId);
                cmd.Parameters.AddWithValue("@Mobile", partyMaster.Mobile);
                cmd.Parameters.AddWithValue("@UpUserId", currentUser.UserId);
                cmd.Parameters.AddWithValue("@UpDateTime", DateTime.Now.ToShortDateString());
                if (partyMaster.PartyId == 0)
                {
                    cmd.Parameters.AddWithValue("@EntUserId", currentUser.UserId);
                    cmd.Parameters.AddWithValue("@EntDateTime", DateTime.Now.ToShortDateString());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@PartyId", partyMaster.PartyId);
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
